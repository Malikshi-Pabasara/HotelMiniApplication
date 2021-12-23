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


using Cenium.Framework.ComponentModel;
using Cenium.Framework.Data;
using System;
using System.ComponentModel;

namespace Cenium.Contacts.Activities.Entities.Extentions
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>

    [Entity]
    public class ContactReservationExtensionItem
    {

        /// <summary>
        /// Initializes a new instance of the OrderContactExtensionItem class
        /// </summary>
        public ContactReservationExtensionItem()
        {

        }

        /// <summary>
        ///
        /// </summary>
        [EntityMember(Order = 0, IsKey = true)]
        public long ReservationId { get; set; }

        /// <summary>
        ///
        /// </summary>
        [EntityMember(Order = 1)]
        public string Number { get; set; }

        /// <summary>
        ///
        /// </summary>
        [EntityMember(Order = 2)]
        [DateTimeFormat(DateTimeFormat.DateTime)]
        public DateTime ArrivalDate { get; set; }

        /// <summary>
        ///
        /// </summary>
        [EntityMember(Order = 3)]
        [DateTimeFormat(DateTimeFormat.DateTime)]
        public DateTime DepartureDate { get; set; }

        /// <summary>
        ///
        /// </summary>
        [EntityMember(Order = 4)]
        public string ReservationStatus { get; set; }

        /// <summary>
        ///
        /// </summary>
        [EntityMember(Order = 5)]
        public string RoomNumber { get; set; }

        /// <summary>
        ///
        /// </summary>
        [EntityMember(Order = 6)]
        public long PropertyId { get; set; }

        /// <summary>
        ///
        /// </summary>
        [EntityMember(Order = 7)]
        public long RoomId { get; set; }
        

    }

}

