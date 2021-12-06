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
 * Malikshi.P  11/23/2021    Created
 */

using System;
using Cenium.Framework;
using Cenium.Framework.Security;

[assembly: Component("Rooms")]
[assembly: ComponentDescription("Rooms", "Provide a description of what the component does here.", "")]
[assembly: ComponentVersion("1.0.0.0", "")]

[assembly: SecureResourceType("rooms.administration", "Full Administration", "Full administration of rooms.")]
[assembly: SecureResourceType("features.administration", "Full Administration", "Full administration of room features.")]
[assembly: SecureResourceType("roomtypes.administration", "Full Administration", "Full administration of room types.")]