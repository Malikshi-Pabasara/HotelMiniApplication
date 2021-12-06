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





using Cenium.Framework.Component.Interface;
using Cenium.Reservations.Activities.Helpers.Rooms;

namespace Cenium.Reservations.Activities.Helpers.Rooms
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	internal class RoomProxy : ProxyWrapperBase
    {
        public RoomProxy()
        {
            base.EntityProxy = RoomHelper.CreateRoomProxy();
        }

        /// <summary>
        /// Initializes a new instance of the RoomReservationProxy class
        /// </summary>
        public RoomProxy(IEntityProxy proxy) : base(proxy) { }

        public long RoomId
        {
            get { return GetValue<long>("RoomId"); }
            set { SetValue("RoomId", value); }
        }

        public string RoomNumber
        {
            get { return GetValue<string>("RoomNumber"); }
            set { SetValue("RoomNumber", value); }
        }

        public string RoomType
        {
            get { return GetValue<string>("RoomTypeId"); }
            set { SetValue("RoomTypeId", value); }
        }

        public string Status
        {
            get { return GetValue<string>("Status"); }
            set { SetValue("Status", value); }
        }

        
    }

}

