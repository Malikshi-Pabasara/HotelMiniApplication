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


using Cenium.Framework.Data;
using System;
using System.Collections.Generic;

namespace Cenium.Contacts.Activities.Entities.Extentions
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
    /// 
    [Entity]
    public class ContactReservationExtension
    {

        /// <summary>
        /// Initializes a new instance of the OrderContactExtension class
        /// </summary>
        public ContactReservationExtension()
        {

        }

        /// <summary>
        ///
        /// </summary>
        [EntityMember(Order = 0)]
        public ICollection<ContactReservationExtensionItem> Items { get; set; }


    }

}

