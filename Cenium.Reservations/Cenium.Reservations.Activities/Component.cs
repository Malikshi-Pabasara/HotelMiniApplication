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
 * Malikshi.P  10/28/2021    Created
 */

using System;
using Cenium.Framework;
using Cenium.Framework.Security;

[assembly: Component("Reservations")]
[assembly: ComponentDescription("Reservations", "Provide a description of what the component does here.", "")]
[assembly: ComponentVersion("1.0.0.0", "")]
[assembly: SecureResourceType("reservations.administration", "Full Administration", "Full administration of reservations.")]

