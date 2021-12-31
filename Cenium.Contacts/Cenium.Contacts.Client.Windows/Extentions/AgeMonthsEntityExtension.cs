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
 * Malikshi.P  12/31/2021    Created
 */

 
using Cenium.Framework.Client.AppResources.Metadata;
using Cenium.Framework.Client.Metadata;
using Cenium.Framework.Client.Model;
using System;

namespace Cenium.Contacts.Client.Windows.Extensions
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
    [RegisterEntityPropertyExtension("contacts.entityextension.agemonths")]
    public class AgeMonthsEntityExtension : IEntityPropertyExtension
    {
        private const string DateOfBirth = "DateOfBirth";
        /// <summary>
        /// Initializes a new instance of the AgeMonthsEntityExtension class
        /// </summary>
        public AgeMonthsEntityExtension()
        {

        }

        public object Get(Record record)
        {
            if (record == null)
                return string.Empty;

            var dateOfBirth = record.GetValue<DateTime>(DateOfBirth);

            if (dateOfBirth > DateTime.Now)
                return string.Empty;

            if (dateOfBirth != null && dateOfBirth != DateTime.MinValue)
                return GetMonths(dateOfBirth, DateTime.Today).ToString();

            return string.Empty;
        }
        public static int GetMonths(DateTime dateOfBirth, DateTime currentDate)
        {
            DateTime age = GetSubtractedAge(dateOfBirth, currentDate);
            // Min value is 01/01/0001
            // Actual age is say 24 yrs, 9 months and 3 days represented as timespan
            // Min Valye + actual age = 25 yrs , 10 months and 4 days.
            // Subtract our addition or 1 on all components to get the actual date.
            return age.Month - 1;
        }

        private static DateTime GetSubtractedAge(DateTime dateOfBirth, DateTime currentDate)
        {
            TimeSpan difference = currentDate.Subtract(dateOfBirth);

            // This is to convert the timespan to datetime object
            return DateTime.MinValue + difference;
        }

    }

}
