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


using Cenium.Framework.Component;
using Cenium.Framework.Component.Interface;
using System;

namespace Cenium.Prices.Activities.Helper.RoomType
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	internal static class RoomTypeHelper
    {
        const string ActivityName = "Rooms";

        private static IActivityFactory _roomtypeActivityFactory = ComponentManager.IsComponentInstalled(ActivityName) ? ActivityManager.GetActivityFactory(ActivityName) : null;
        private static IEntityFactory _roomtypeEntityFactory = ComponentManager.IsComponentInstalled(ActivityName) ? EntityManager.GetEntityFactory(ActivityName) : null;

        private static bool _isReservationAvailable = ((_roomtypeEntityFactory == null) || (_roomtypeActivityFactory == null)) ?
            false : _roomtypeActivityFactory.IsActivityAvailable("RoomType");

        /// <summary>
        /// Get reservation by reservation id.
        /// </summary>
        /// <param name="roomTypeId"></param>
        /// <returns></returns>
        public static RoomTypePriceProxy GetPriceCodeById(long roomTypeId)
        {
            if (!_isReservationAvailable)
                return null;

            var activity = _roomtypeActivityFactory.Create("RoomType");

            var result = ((activity == null) || (!activity.IsMethodAvailable("Get"))) ? null : activity.Get("Get", roomTypeId);

            if (result == null)
                return null;

            return new RoomTypePriceProxy(result);
        }
        
    }

}
