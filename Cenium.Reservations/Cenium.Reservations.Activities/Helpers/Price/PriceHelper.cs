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
using System.Collections.Generic;

namespace Cenium.Reservations.Activities.Helpers.Price
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
    internal static class PriceHelper
    {
        const string ActivityName = "Prices";

        private static IActivityFactory _priceActivityFactory = ComponentManager.IsComponentInstalled(ActivityName) ? ActivityManager.GetActivityFactory(ActivityName) : null;
        private static IEntityFactory _priceEntityFactory = ComponentManager.IsComponentInstalled(ActivityName) ? EntityManager.GetEntityFactory(ActivityName) : null;

        private static bool _isReservationAvailable = ((_priceEntityFactory == null) || (_priceActivityFactory == null)) ?
            false : _priceActivityFactory.IsActivityAvailable("Price");

        /// <summary>
        /// Get reservation by reservation id.
        /// </summary>
        /// <param name="roomTypeId"></param>
        /// <returns></returns>
        public static PriceReservationProxy GetPriceById(long roomTypeId)
        {
            if (!_isReservationAvailable)
                return null;

            var activity = _priceActivityFactory.Create("Price");

            var result = ((activity == null) || (!activity.IsMethodAvailable("GetPrice"))) ? null : activity.Get("GetPrice", roomTypeId);

            if (result == null)
                return null;
            
            return new PriceReservationProxy(result);
        }

    }
}
