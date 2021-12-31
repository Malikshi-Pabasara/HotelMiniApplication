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
 * Malikshi.P  01/01/2022    Created
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
        [RegisterActionType("rooms.cleanaction")]
        public class CleanAction : AbstractActionHandler
        {
            private Record _record = null;

            /// <summary>
            /// Initializes a new instance of the InitializeAction class
            /// </summary>
            public CleanAction()
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
                    if (ClientConnector.Current.CheckUserAccess("Rooms/Room/Clean"))
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
            else
            {
                MessageBoxResult result = MessageBox.Show("Do you want to clean the room?",
               "cancel", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    WindowManager.ShowPageProgress(Owner, "clean Room", "clean Room..");

                    ClientConnector.Current.InvokeAsync(new ServiceInvokeParameters
                    {
                        ServiceMethod = "Rooms/Room/Clean",
                        Record = rec,
                        IncludeChildren = true,
                        UserState = rec
                    }, Finished);
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
                            MessageBox.Show("Room has been set to cleaned", "Clean", MessageBoxButton.OK, MessageBoxImage.Information);
                        });
                
                }
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

