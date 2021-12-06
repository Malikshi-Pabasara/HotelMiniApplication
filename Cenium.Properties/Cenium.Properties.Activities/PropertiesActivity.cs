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
using System.Linq;
using System.Collections.Generic;

using Cenium.Framework.Core.Attributes;
using Cenium.Framework.Logging;
using Cenium.Properties.Data;
using Cenium.Framework.Security;

namespace Cenium.Properties.Activities
{

    /// <summary>
    /// The PropertiesActivity class is an activity class that exposes data operation methods to the service layer. This class is responsible for applying business logic prior to making
    /// updates in the data store.
    /// </summary>
    /// <seealso cref="Cenium.Properties.Data.Property"/>
    /// <seealso cref="Cenium.Properties.Data.PropertiesEntitiesContext"/>
    [Activity("Property")]
    public class PropertiesActivity : IDisposable
    {

        private PropertiesEntitiesContext _ctx;
        private bool _disposeContext = true;

        /// <summary>
        /// Initializes a new instance of the PropertiesActivity class
        /// </summary>
        public PropertiesActivity()
        {
            _ctx = new PropertiesEntitiesContext();
        }

        /// <summary>
        /// Initializes a new instance of the PropertiesActivity class, sharing the context with other activities
        /// </summary>
        /// <param name="ctx">The shared context</param>
        internal PropertiesActivity(PropertiesEntitiesContext ctx)
        {
            _ctx = ctx;
            _disposeContext = false;
        }


        /// <summary>
        /// Activity query method that returns an IEnumerable&lt;Property&gt; instance. 
        /// </summary>
        /// <returns>A strongly type IEnumerable instance </returns>
        [ActivityMethod("Query", MethodType.Query, IsDefault = true)]
        [SecureResource("properties.administration", SecureResourcePermissionLevel.Read)]
        public IEnumerable<Property> Query()
        {
            Logger.TraceMethodEnter();

            var result = _ctx.Properties.ReadOnlyQuery().OrderBy(p => p.PropertyId);

            return Logger.TraceMethodExit(result) as IEnumerable<Property>;
        }


        /// <summary>
        /// Gets a Property instance from the datastore based on Property keys.
        /// </summary>
        /// <param name="propertyId">The key for Property</param>
        /// <returns>A Property instance, or null if there is no entities with the given key</returns>
        [ActivityMethod("Get", MethodType.Get, IsDefault = true)]
        [SecureResource("properties.administration", SecureResourcePermissionLevel.Read)]
        public Property Get(long propertyId)
        {
            Logger.TraceMethodEnter(propertyId);

            var result = _ctx.Properties.FindByKeys(propertyId);

            return Logger.TraceMethodExit(result) as Property;
        }


        /// <summary>
        /// Adds a new instance of Property to the data store
        /// </summary>
        /// <param name="property">The instance to add</param>
        /// <returns>The created instance</returns>
        [ActivityMethod("Create", MethodType.Create, IsDefault = true)]
        [SecureResource("properties.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Properties.Data.Property Create(Property property)
        {
            Logger.TraceMethodEnter(property);

            property = _ctx.Properties.Add(property);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(property.PropertyId)) as Property;
        }


        /// <summary>
        /// Updates a Property instance in the data store
        /// </summary>
        /// <param name="property">The instance to update</param>
        /// <returns>The updated instance</returns>
        [ActivityMethod("Update", MethodType.Update, IsDefault = true)]
        [SecureResource("properties.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Properties.Data.Property Update(Property property)
        {
            Logger.TraceMethodEnter(property);

            property = _ctx.Properties.Modify(property);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(property.PropertyId)) as Property;
        }


        /// <summary>
        /// Deletes a Property instance from the data store
        /// </summary>
        /// <param name="property">The instance to delete</param>
        [ActivityMethod("Delete", MethodType.Delete, IsDefault = true)]
        [SecureResource("properties.administration", SecureResourcePermissionLevel.Write)]
        public void Delete(Property property)
        {
            Logger.TraceMethodEnter(property);

            _ctx.Properties.Remove(property);
            _ctx.SaveChanges();

            Logger.TraceMethodExit();
        }


        /// <summary>
        /// Retrieves a single entity instance from the data store
        /// </summary>
        /// <param name="propertyId">The key for Property</param>
        /// <returns>A single Property instance, or null if the instance doesn't exist</returns>
        protected Property GetFromDatastore(long propertyId)
        {
            return _ctx.Properties.ReadOnlyQuery().Where(p => p.PropertyId == propertyId).FirstOrDefault();
        }

        /// <summary>
        /// Releases all resources used by this PropertiesActivity instance.
        /// </summary>
        public void Dispose()
        {
            if ((_ctx != null) && (_disposeContext))
                _ctx.Dispose();
            _ctx = null;
        }



    }

}
