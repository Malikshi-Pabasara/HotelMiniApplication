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


using Cenium.Framework.Component;
using Cenium.Framework.Component.Interface;
using System;
using System.Collections.Generic;

namespace Cenium.Rooms.Activities.Helpers.Reservations
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	internal static class ReservationHelper
    {

        const string ActivityName = "Reservations";

        private static IActivityFactory _reservationActivityFactory = ComponentManager.IsComponentInstalled(ActivityName) ? ActivityManager.GetActivityFactory(ActivityName) : null;
        private static IEntityFactory _reservationEntityFactory = ComponentManager.IsComponentInstalled(ActivityName) ? EntityManager.GetEntityFactory(ActivityName) : null;

        private static bool _isReservationAvailable = ((_reservationEntityFactory == null) || (_reservationActivityFactory == null)) ?
            false : _reservationActivityFactory.IsActivityAvailable("Reservation");

        /// <summary>
        /// Get reservation by reservation id.
        /// </summary>
        /// <param name="reservationId"></param>
        /// <returns></returns>
        public static ReservationRoomProxy GetReservationById(long reservationId)
        {
            if (!_isReservationAvailable)
                return null;

            var activity = _reservationActivityFactory.Create("Reservation");

            var result = ((activity == null) || (!activity.IsMethodAvailable("Get"))) ? null : activity.Get("Get", reservationId);

            if (result == null)
                return null;

            return new ReservationRoomProxy(result);
        }

        /// <summary>
        /// Get reservation by reservation.
        /// </summary>
        /// <param name="reservationId"></param>
        /// <returns></returns>
        public static List<long?> GetReservedRoomIdList(long reservationId)
        {
            if (!_isReservationAvailable)
                return null;

            var activity = _reservationActivityFactory.Create("Reservation");

            var result = ((activity == null) || (!activity.IsMethodAvailable("GetReservedRoomIdList"))) ? null : activity.Invoke("GetReservedRoomIdList", reservationId);

            if (result == null)
                return null;

            return (List<long?>)(result);
        }
    }

}
