/*
 * Copyright (c) Cenium AS. All Right Reserved
 *
 * This source is subject to the Cenium License.
 * Please see the License.txt file for more information.
 * All other rights reserved.
 * 
 * http://www.cenium.com
 * 
 * Change History:
 * 
 * User        Date          Comment
 * ----------- ------------- --------------------------------------------------------------------------------------------
 * Malikshi.P  12/30/2021    Created
 */

using Cenium.Framework.Client;
using Cenium.Framework.Client.AppResources.UI;
using Cenium.Framework.Client.Model;
using Cenium.Framework.Client.Windows;
using Cenium.Framework.Client.Windows.Pages;
using Cenium.Framework.Client.Windows.Pages.Actions;
using Cenium.Framework.ComponentModel;
using System;
using System.ComponentModel;
using System.Windows;

namespace Cenium.Reservations.Client.Windows.Actions
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
    /// 
    [RegisterActionType("reservations.checkoutaction")]
    public class CheckOutAction : AbstractActionHandler
    {
        private Record _record = null;

        /// <summary>
        /// Initializes a new instance of the InitializeAction class
        /// </summary>
        public CheckOutAction()
        {
            IsActionEnabled = true;
            IsActionItemRequired = true;
        }

        /// <summary>
        /// Evaluates the conditions when the ActionItem property is set.
        /// </summary>
        /// <returns>true if the conditions are fullfilled; otherwise false</returns>
        protected override bool EvaluateConditions()
        {
            bool test = base.EvaluateConditions();
            if (test)
            {
                if (ClientConnector.Current.CheckUserAccess("Reservations/Reservation/CheckOut"))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Action to execute when generating prices.
        /// </summary>
        protected override void OnExecute()
        {
            var rec = GetRecord();

            if (rec == null)
            {
                MessageBox.Show("Unable to find record.");
                return;
            }
            else if (rec.State == RecordState.Added || rec.IsDirty)
            {
                MessageBox.Show("Please save changes.");
                return;
            }
            else if (((rec["ReservationStatus"].ToString() != "CHECKED-IN")))
            {
                MessageBox.Show("You can only check out reservations that have checked in status.");
                return;
            }
            else if (rec["ContactId"] == null)
            {
                MessageBox.Show("Please add a contact before checking in.");
                return;
            }
            else if (String.IsNullOrWhiteSpace((String)rec["RoomTypeCode"]))
            {
                MessageBox.Show("The reservation does not have a room type so no room can be assigned.");
                return;
            }
            else if (((String.IsNullOrWhiteSpace(rec["RoomNumber"] as String))))
            {
                MessageBox.Show("The reservation to be checked in needs to have a room number assigned.");
                return;
            }
            else
            {
                // CheckOut is not Equal to CheckOut Date
                DateTime endDate = (DateTime)rec["DepartureDate"];
                
                    if (endDate.Date > System.DateTime.Today.Date)
                    {
                        MessageBox.Show("Share reservation should be managed in manage shares and can not be checked out before departure date.", "Early Check Out Not Allowed", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                

                    CheckInProcess(rec);
            }

        }

        private void CheckInProcess(Record rec)
        {

            string executingMessageTitle = "Checking Out. Please wait...";
            string executingMessage = "Checking Out Reservation...";

            CheckInImpl(rec, executingMessageTitle, executingMessage);

        }

        private void CheckInImpl(Record request, string executingMessageTitle, string executingMessage)
        {
            WindowManager.ShowPageProgress(Owner, executingMessageTitle, executingMessage);

            MessageBoxResult result = MessageBox.Show("Do you want to check-out the reservation?", "Check-Out", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                WindowManager.ShowPageProgress(Owner, "Check Out Reservation", "Check Out Reservation...");

                try
                {
                    ClientConnector.Current.InvokeAsync(new ServiceInvokeParameters
                    {
                        ServiceMethod = "Reservations/Reservation/CheckOut",
                        Record = request,
                        IncludeChildren = true,
                        UserState = request
                    }, Finished);

                }
                catch (Exception ex)
                {
                    WindowManager.HidePageProgress(Owner);

                    MessageBox.Show(string.Format("{0}\n{1}\n{2}", "Error occured when doing Check In.",
                        "Error message: ", ex.Message),
                        "Check In Failed");
                }
            }
        }

        private void Finished(ServiceOperationResult result)
        {
            WindowManager.HidePageProgress(Owner);
            if (!result.IsError)
            {
                var oldValue = ActionItem;
                Record rec = result.State as Record;
                rec.Merge(result.Result as Record, true);
                Invalidate();

                EventDispatchManager.ExecuteOnUIThread(
                    (Action)delegate ()
                    {
                        MessageBox.Show("Reservation has been set to cheked out", "Check-Out", MessageBoxButton.OK, MessageBoxImage.Information);
                    });
            }
            else
            {
                EventDispatchManager.ExecuteOnUIThread(
                    (Action)delegate ()
                    {
                        MessageBox.Show(string.Format("{0}\n{1}\n{2}", "An error occured when doing check out.",
                            "Error message: ", result.Error.Message),
                            "Check Out did not Complete.", MessageBoxButton.OK, MessageBoxImage.Error);
                    });
            }
            Invalidate();

        }
        protected virtual RecordModel GetPageModel()
        {
            var page = Owner as CListPage;

            if ((page == null) || (page.PageModel == null))
                return null;

            return page.PageModel.Data as RecordModel;
        }

        protected Record GetRecord()
        {
            if (Owner == null)
                return null;

            if (ActionItem != null)
            {
                var rec = ActionItem as RecordItem;
                return rec.Item;
            }
            return null;
        }

        /// <summary>
        /// Called when the ActionItem property changes. 
        /// </summary>
        /// <remarks>
        /// This method attaches PropertyChanged event handlers to the ActionItem object if the object implements the INotifyPropertyChanged interface
        /// </remarks>
        /// <param name="oldValue">The old ActionItem value</param>
        /// <param name="newValue">The new ActionItem value</param>
        protected override void OnActionItemChanged(object oldValue, object newValue)
        {
            base.OnActionItemChanged(oldValue, newValue);
            var oldNotify = oldValue as INotifyPropertyChanged;
            var newNotify = newValue as INotifyPropertyChanged;
            var newItem = newValue as RecordItem;

            if (oldNotify != null)
            {
                DetachRecordListener(_record);
                oldNotify.PropertyChanged -= OnActionItemPropertyChanged;
            }

            if (newNotify != null)
            {
                newNotify.PropertyChanged += OnActionItemPropertyChanged;
                if (newItem != null)
                    AttachRecordListener(newItem.Item);
            }

        }

        private void OnActionItemPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            var recordItem = sender as RecordItem;
            if ((recordItem != null) && ("Item".Equals(args.PropertyName)))
            {
                DetachRecordListener(_record);
                AttachRecordListener(recordItem.Item);
            }
            Invalidate();
        }

        private void DetachRecordListener(Record record)
        {
            _record = null;
            if (record == null)
                return;
            record.PropertyChanged -= OnActionItemPropertyChanged;
        }

        private void AttachRecordListener(Record record)
        {
            _record = record;
            if (record == null)
                return;
            record.PropertyChanged += OnActionItemPropertyChanged;
        }

    }
}
