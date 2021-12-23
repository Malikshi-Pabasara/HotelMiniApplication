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
 * Malikshi.P  11/01/2021    Created
 */




using Cenium.Framework.Component;
using Cenium.Framework.Component.Interface;
using Cenium.Reservations.Data;
using System;

namespace Cenium.Reservations.Activities.Helpers.Rooms
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	internal static class RoomHelper
    {

        const string ComponentName = "Rooms";

        private static IActivityFactory _roomActivityFactory = ComponentManager.IsComponentInstalled(ComponentName) ? ActivityManager.GetActivityFactory(ComponentName) : null;
        private static IEntityFactory _roomEntityFactory = ComponentManager.IsComponentInstalled(ComponentName) ? EntityManager.GetEntityFactory(ComponentName) : null;

        private static bool _isRoomAvailable = ((_roomEntityFactory == null) || (_roomActivityFactory == null)) ?
            false : _roomActivityFactory.IsActivityAvailable("Room"); //activity Name

        /// <summary>
        /// Update room's reservation dates.
        /// </summary>
        /// <param name="roomProxy"></param>
        /// <returns></returns>
        public static void UpdateRoomReservationInfo(RoomProxy roomProxy)
        {
            if (!_isRoomAvailable)
                return;

            var activity = _roomActivityFactory.Create("Room");
            var result = ((activity == null) || (!activity.IsMethodAvailable("UpdateRoomReservationInfo"))) ? null : activity.Invoke("UpdateRoomReservationInfo", roomProxy.EntityProxy);
            
        }

        //public static void AvailableRoomsInfo(Reservation reservation)
        //{
        //    var activity = _roomActivityFactory.Create("Room");
        //    var result = ((activity == null) || (!activity.IsMethodAvailable("Query"))) ? null : activity.Query("Query");

        //    var availableRooms = db.Rooms.Where(m => m.result.All(r => r.Departure <= reservation.ArrivalDate || r.Arrival >= reservation.DepartureDate)

        //}

        //create a proxy for room
        public static IEntityProxy CreateRoomProxy()
        {
            return _isRoomAvailable ? _roomEntityFactory.Create("Room") : null;
        }

    }

}

