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
 * Malikshi.P  12/16/2021    Created
 */


using Cenium.Framework.Data;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cenium.Rooms.Data
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
    [EntityInfo(ValueListProperties = "RoomNumber,Status", PrimaryDisplayProperty = "RoomNumber")]
    public partial class Room
    {
    }

}
