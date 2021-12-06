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

using System;
using System.Windows;

using Cenium.Framework.Client;
using Cenium.Framework.Client.AppResources.UI;
using Cenium.Framework.Client.Windows.Controls;
using Cenium.Framework.Client.Windows.Controls.Data;
using Cenium.Framework.Client.Windows.Converters;
using Cenium.Framework.Client.Windows.Media;

namespace Cenium.Properties.Client.Windows
{
    /// <summary>
    /// Performs client initialization upon startup for the Properties component
    /// </summary>
	public class PropertiesClientInitializer : IInitializer
    {
        private const string IconPath = "/Cenium.Properties.Client.Windows;component/Resources/Icons/{0}.png";


        public void Initialize()
        {
            // Register layout controls here
            //ControlManager.RegisterLayoutControl("Properties.controls.mycontrol", new MyControlLayoutControlFactory());

            // Icons
            IconManager.Register("Properties.icon.component", string.Format(IconPath, "Properties"));

        }

    }
}
