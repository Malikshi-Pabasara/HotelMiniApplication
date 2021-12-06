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
    /// The RoomTypesActivity class is an activity class that exposes data operation methods to the service layer. This class is responsible for applying business logic prior to making
    /// updates in the data store.
    /// </summary>
    /// <seealso cref="Cenium.Rooms.Data.RoomType"/>
    /// <seealso cref="Cenium.Rooms.Data.RoomsEntitiesContext"/>
    [Activity("RoomType")]
    public class RoomTypesActivity : IDisposable
    {

        private RoomsEntitiesContext _ctx;
        private bool _disposeContext = true;

        /// <summary>
        /// Initializes a new instance of the RoomTypesActivity class
        /// </summary>
        public RoomTypesActivity()
        {
            _ctx = new RoomsEntitiesContext();
        }

        /// <summary>
        /// Initializes a new instance of the RoomTypesActivity class, sharing the context with other activities
        /// </summary>
        /// <param name="ctx">The shared context</param>
        internal RoomTypesActivity(RoomsEntitiesContext ctx)
        {
            _ctx = ctx;
            _disposeContext = false;
        }


        /// <summary>
        /// Activity query method that returns an IEnumerable&lt;RoomType&gt; instance. 
        /// </summary>
        /// <returns>A strongly type IEnumerable instance </returns>
        [ActivityMethod("Query", MethodType.Query, IsDefault = true)]
        [ActivityResult("Features")]
        [SecureResource("roomtypes.administration", SecureResourcePermissionLevel.Read)]
        public IEnumerable<RoomType> Query()
        {
            Logger.TraceMethodEnter();

            var result = _ctx.RoomTypes.ReadOnlyQuery().OrderBy(p => p.RoomTypeId);

            return Logger.TraceMethodExit(result) as IEnumerable<RoomType>;
        }


        /// <summary>
        /// Gets a RoomType instance from the datastore based on RoomType keys.
        /// </summary>
        /// <param name="roomTypeId">The key for RoomType</param>
        /// <returns>A RoomType instance, or null if there is no entities with the given key</returns>
        [ActivityMethod("Get", MethodType.Get, IsDefault = true)]
        [SecureResource("roomtypes.administration", SecureResourcePermissionLevel.Read)]
        public RoomType Get(long roomTypeId)
        {
            Logger.TraceMethodEnter(roomTypeId);

            var result = _ctx.RoomTypes.FindByKeys(roomTypeId);

            return Logger.TraceMethodExit(result) as RoomType;
        }


        /// <summary>
        /// Adds a new instance of RoomType to the data store
        /// </summary>
        /// <param name="roomType">The instance to add</param>
        /// <returns>The created instance</returns>
        [ActivityMethod("Create", MethodType.Create, IsDefault = true)]
        [SecureResource("roomtypes.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Rooms.Data.RoomType Create(RoomType roomType)
        {
            Logger.TraceMethodEnter(roomType);

            roomType = _ctx.RoomTypes.Add(roomType);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(roomType.RoomTypeId)) as RoomType;
        }


        /// <summary>
        /// Updates a RoomType instance in the data store
        /// </summary>
        /// <param name="roomType">The instance to update</param>
        /// <returns>The updated instance</returns>
        [ActivityMethod("Update", MethodType.Update, IsDefault = true)]
        [SecureResource("roomtypes.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Rooms.Data.RoomType Update(RoomType roomType)
        {
            Logger.TraceMethodEnter(roomType);
            _ctx.RoomTypes.AttachChildCollection<Feature>(roomType, "Features");
            roomType = _ctx.RoomTypes.Modify(roomType);
            _ctx.RoomTypes.SynchronizeChildCollection<Feature>(roomType, "Features");
            _ctx.SaveChanges();
            return Logger.TraceMethodExit(GetFromDatastore(roomType.RoomTypeId)) as RoomType;
        }


        /// <summary>
        /// Deletes a RoomType instance from the data store
        /// </summary>
        /// <param name="roomType">The instance to delete</param>
        [ActivityMethod("Delete", MethodType.Delete, IsDefault = true)]
        [SecureResource("roomtypes.administration", SecureResourcePermissionLevel.Write)]
        public void Delete(RoomType roomType)
        {
            Logger.TraceMethodEnter(roomType);

            _ctx.RoomTypes.Remove(roomType);
            _ctx.SaveChanges();

            Logger.TraceMethodExit();
        }


        /// <summary>
        /// Retrieves a single entity instance from the data store
        /// </summary>
        /// <param name="roomTypeId">The key for RoomType</param>
        /// <returns>A single RoomType instance, or null if the instance doesn't exist</returns>
        protected RoomType GetFromDatastore(long roomTypeId)
        {
            return _ctx.RoomTypes.ReadOnlyQuery().Where(p => p.RoomTypeId == roomTypeId).FirstOrDefault();
        }

        /// <summary>
        /// Releases all resources used by this RoomTypesActivity instance.
        /// </summary>
        public void Dispose()
        {
            if ((_ctx != null) && (_disposeContext))
                _ctx.Dispose();
            _ctx = null;
        }

    }

}
