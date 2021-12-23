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
 * Malikshi.P  12/22/2021    Created
 */


using Cenium.Framework.Data;
using System;

namespace Cenium.Contacts.Data
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
        [EntityInfo(ValueListProperties = "Name,Gender,PassportNo,IdNumber", PrimaryDisplayProperty = "ContactName")]
        public partial class Contact
    {
        


    }

}
