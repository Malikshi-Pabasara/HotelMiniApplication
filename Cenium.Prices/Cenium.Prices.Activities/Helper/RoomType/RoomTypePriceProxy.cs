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

namespace Cenium.Prices.Activities.Helper.RoomType
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	internal class RoomTypePriceProxy : ProxyWrapperBase
    {

        public RoomTypePriceProxy(IEntityProxy proxy) : base(proxy) { }

        public long RoomTypeId
        {
            get { return GetValue<long>("RoomTypeId"); }
            set { SetValue("RoomTypeId", value); }
        }

        public string PriceCode
        {
            get { return GetValue<string>("PriceCode"); }
            set { SetValue("PriceCode", value); }
        }

    }

}
