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


using Cenium.Framework.Component.Interface;
using System;

namespace Cenium.Reservations.Activities.Helpers.Price
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	
    internal class PriceReservationProxy : ProxyWrapperBase
    {
        /// <summary>
        /// Initializes a new instance of the RoomReservationProxy class
        /// </summary>
        public PriceReservationProxy(IEntityProxy proxy) : base(proxy) { }

        public long PriceId
        {
            get { return GetValue<long>("PriceId"); }
            set { SetValue("PriceId", value); }
        }

        public double Amount
        {
            get { return GetValue<double>("Amount"); }
            set { SetValue("Amount", value); }
        }
    }
}
