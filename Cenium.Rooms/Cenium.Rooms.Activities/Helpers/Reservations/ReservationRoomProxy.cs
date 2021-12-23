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
 * Malikshi.P  12/18/2021    Created
 */


using Cenium.Framework.Component.Interface;
using System;

namespace Cenium.Rooms.Activities.Helpers.Reservations
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	internal class ReservationRoomProxy : ProxyWrapperBase
    {

        public ReservationRoomProxy(IEntityProxy proxy) : base(proxy) { }

        public long ReservationId
        {
            get { return GetValue<long>("ReservationId"); }
            set { SetValue("ReservationId", value); }
        }

        public DateTime ArrivalDate
        {
            get { return GetValue<DateTime>("ArrivalDate"); }
            set { SetValue("ArrivalDate", value); }
        }

        public DateTime DepartureDate
        {
            get { return GetValue<DateTime>("DepartureDate"); }
            set { SetValue("DepartureDate", value); }
        }

        public long RoomTypeId
        {
            get { return GetValue<long>("RoomTypeId"); }
            set { SetValue("RoomTypeId", value); }
        }

    }

}
