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
 * Malikshi.P  12/20/2021    Created
 */


using Cenium.Contacts.Activities.Entities.Extentions;
using Cenium.Framework.Activities;
using System;
using System.Linq;

namespace Cenium.Reservations.Activities.ResourceHelpers
{
    /// <summary>
    /// Table hook to Rewards.RewardContact table.
    /// </summary>
    
    [ActivityResultExtension("Contacts/Contact/Get/{ContactId}", "ReservationExtension", "ReservationExtension.Items")]

    public class ContactResultHandlerFactory : AbstractActivityResultHandlerFactory
    {
        /// <summary>
        /// Initializes a new instance of the ContactInfoResultHandlerFactory class
        /// </summary>
        public ContactResultHandlerFactory()
            : base(typeof(ContactReservationExtension), "Contacts.Contact", "ReservationExtension")
        {

        }
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        protected override IActivityResultExtensionHandler CreateHandler()
        {
            return new ContactInfoHandler();
        }

        private class ContactInfoHandler : ReservationResultHandler, IActivityResultExtensionHandler
        {
            public override void CreateOrUpdate(string parentEntity, object parentKey, object entity)
            {

            }

            public override void Delete(string parentEntity, object parentKey, object entity)
            {

            }

            public override object Get(string parentEntity, object parentKey)
            {
                var id = SafeGetLongKey(parentKey);

                var result = new ContactReservationExtension();

                result.Items = Context.Reservations.ReadOnlyQuery()
                    .Where(w => w.ContactId == id).Select(s => new ContactReservationExtensionItem()
                    {
                        ReservationId = s.ReservationId,
                        Number = s.Number,
                        ArrivalDate = s.ArrivalDate,
                        DepartureDate = s.DepartureDate,
                        ReservationStatus = s.ReservationStatus,
                        RoomNumber = s.RoomNumber,
                        RoomId = s.RoomId,
                    }).ToList();

                return result;
            }
        }

    }

}
