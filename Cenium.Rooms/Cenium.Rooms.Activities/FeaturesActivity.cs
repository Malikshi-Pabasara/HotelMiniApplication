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
using System.Linq;
using System.Collections.Generic;

using Cenium.Framework.Core.Attributes;
using Cenium.Framework.Logging;
using Cenium.Rooms.Data;
using Cenium.Framework.Security;

namespace Cenium.Rooms.Activities
{

    /// <summary>
    /// The FeaturesActivity class is an activity class that exposes data operation methods to the service layer. This class is responsible for applying business logic prior to making
    /// updates in the data store.
    /// </summary>
    /// <seealso cref="Cenium.Rooms.Data.Feature"/>
    /// <seealso cref="Cenium.Rooms.Data.RoomsEntitiesContext"/>
    [Activity("Feature")]
    public class FeaturesActivity : IDisposable
    {

        private RoomsEntitiesContext _ctx;
        private bool _disposeContext = true;

        /// <summary>
        /// Initializes a new instance of the FeaturesActivity class
        /// </summary>
        public FeaturesActivity()
        {
            _ctx = new RoomsEntitiesContext();
        }

        /// <summary>
        /// Initializes a new instance of the FeaturesActivity class, sharing the context with other activities
        /// </summary>
        /// <param name="ctx">The shared context</param>
        internal FeaturesActivity(RoomsEntitiesContext ctx)
        {
            _ctx = ctx;
            _disposeContext = false;
        }


        /// <summary>
        /// Activity query method that returns an IEnumerable&lt;Feature&gt; instance. 
        /// </summary>
        /// <returns>A strongly type IEnumerable instance </returns>
        [ActivityMethod("Query", MethodType.Query, IsDefault = true)]
        [ActivityResult("RoomTypes")]
        [SecureResource("features.administration", SecureResourcePermissionLevel.Read)]
        public IEnumerable<Feature> Query()
        {
            Logger.TraceMethodEnter();

            var result = _ctx.Features.ReadOnlyQuery().OrderBy(p => p.FeatureId);

            return Logger.TraceMethodExit(result) as IEnumerable<Feature>;
        }


        /// <summary>
        /// Gets a Feature instance from the datastore based on Feature keys.
        /// </summary>
        /// <param name="featureId">The key for Feature</param>
        /// <returns>A Feature instance, or null if there is no entities with the given key</returns>
        [ActivityMethod("Get", MethodType.Get, IsDefault = true)]
        [ActivityResult("RoomTypes")]
        [SecureResource("features.administration", SecureResourcePermissionLevel.Read)]
        public Feature Get(long featureId)
        {
            Logger.TraceMethodEnter(featureId);

            var result = _ctx.Features.FindByKeys(featureId);

            result.RoomTypeName = "test";

            return Logger.TraceMethodExit(result) as Feature;
        }


        /// <summary>
        /// Adds a new instance of Feature to the data store
        /// </summary>
        /// <param name="feature">The instance to add</param>
        /// <returns>The created instance</returns>
        [ActivityMethod("Create", MethodType.Create, IsDefault = true)]
        [ActivityResult("RoomTypes")]
        [SecureResource("features.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Rooms.Data.Feature Create(Feature feature)
        {
            Logger.TraceMethodEnter(feature);

            feature = _ctx.Features.Add(feature);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(feature.FeatureId)) as Feature;
        }


        /// <summary>
        /// Updates a Feature instance in the data store
        /// </summary>
        /// <param name="feature">The instance to update</param>
        /// <returns>The updated instance</returns>
        [ActivityMethod("Update", MethodType.Update, IsDefault = true)]
        [ActivityResult("RoomTypes")]
        [SecureResource("features.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Rooms.Data.Feature Update(Feature feature)
        {
            Logger.TraceMethodEnter(feature);

            _ctx.Features.AttachChildCollection<RoomType>(feature, "RoomTypes");
            feature = _ctx.Features.Modify(feature);
            _ctx.Features.SynchronizeChildCollection<RoomType>(feature, "RoomTypes");
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(feature.FeatureId)) as Feature;
        }


        /// <summary>
        /// Deletes a Feature instance from the data store
        /// </summary>
        /// <param name="feature">The instance to delete</param>
        [ActivityMethod("Delete", MethodType.Delete, IsDefault = true)]
        [ActivityResult("RoomTypes")]
        [SecureResource("features.administration", SecureResourcePermissionLevel.Write)]
        public void Delete(Feature feature)
        {
            Logger.TraceMethodEnter(feature);

            _ctx.Features.Remove(feature);
            _ctx.SaveChanges();

            Logger.TraceMethodExit();
        }


        /// <summary>
        /// Retrieves a single entity instance from the data store
        /// </summary>
        /// <param name="featureId">The key for Feature</param>
        /// <returns>A single Feature instance, or null if the instance doesn't exist</returns>
        protected Feature GetFromDatastore(long featureId)
        {
            return _ctx.Features.ReadOnlyQuery().Where(p => p.FeatureId == featureId).FirstOrDefault();
        }

        /// <summary>
        /// Releases all resources used by this FeaturesActivity instance.
        /// </summary>
        public void Dispose()
        {
            if ((_ctx != null) && (_disposeContext))
                _ctx.Dispose();
            _ctx = null;
        }



    }

}
