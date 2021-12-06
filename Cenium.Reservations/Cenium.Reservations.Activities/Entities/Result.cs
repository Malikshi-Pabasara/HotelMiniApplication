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
 * Malikshi.P  11/03/2021    Created
 */



using Cenium.Framework.Data;
using Cenium.Reservations.Data;
using System.Collections.Generic;

namespace Cenium.Reservations.Activities.Entities
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
    [Entity]
    public class Result
    {

        /// <summary>
        /// Initializes a new instance of the ReservationsResult class
        /// </summary>
        public Result()
        {
            Reservations = new List<Reservation>();
        }

        /// <summary>
        /// Gets and sets list of Reservation objects
        /// </summary>
        [EntityMember(Order = 0)]
        public ICollection<Reservation> Reservations { get; set; }

    }

}

