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
using Cenium.Rooms.Activities.Helpers.Reservations;

namespace Cenium.Rooms.Activities
{

    /// <summary>
    /// The RoomsActivity class is an activity class that exposes data operation methods to the service layer. This class is responsible for applying business logic prior to making
    /// updates in the data store.
    /// </summary>
    /// <seealso cref="Cenium.Rooms.Data.Room"/>
    /// <seealso cref="Cenium.Rooms.Data.RoomsEntitiesContext"/>
    [Activity("Room")]
    public class RoomsActivity : IDisposable
    {

        private RoomsEntitiesContext _ctx;
        private bool _disposeContext = true;

        /// <summary>
        /// Initializes a new instance of the RoomsActivity class
        /// </summary>
        public RoomsActivity()
        {
            _ctx = new RoomsEntitiesContext();
        }

        /// <summary>
        /// Initializes a new instance of the RoomsActivity class, sharing the context with other activities
        /// </summary>
        /// <param name="ctx">The shared context</param>
        internal RoomsActivity(RoomsEntitiesContext ctx)
        {
            _ctx = ctx;
            _disposeContext = false;
        }


        /// <summary>
        /// Activity query method that returns an IEnumerable&lt;Room&gt; instance. 
        /// </summary>
        /// <returns>A strongly type IEnumerable instance </returns>
        [ActivityMethod("Query", MethodType.Query, IsDefault = true)]
        [ActivityResult("RoomTypes")]
        [ActivityResult("Features")]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Read)]
        public IEnumerable<Room> Query()
        {
            Logger.TraceMethodEnter();

            var result = _ctx.Rooms.ReadOnlyQuery().OrderBy(p => p.RoomId);

            return Logger.TraceMethodExit(result) as IEnumerable<Room>;
        }
        /// <summary>
        /// Activity query method that returns an IEnumerable&lt;Room&gt; instance. 
        /// </summary>
        /// <returns>A strongly type IEnumerable instance </returns>
        [ActivityMethod("TestQuery", MethodType.Query, IsDefault = false)]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Read)]
        public IEnumerable<Room>TestQuery()
        {
            Logger.TraceMethodEnter();

            var result = _ctx.Rooms.ReadOnlyQuery().OrderBy(p => p.RoomId);

            return Logger.TraceMethodExit(result) as IEnumerable<Room>;
        }

        /// <summary>
        /// Gets a Room instance from the datastore based on Room keys.
        /// </summary>
        /// <param name="roomId">The key for Room</param>
        /// <returns>A Room instance, or null if there is no entities with the given key</returns>
        [ActivityMethod("Get", MethodType.Get, IsDefault = true)]
        [ActivityResult("RoomTypes")]
        [ActivityResult("Features")]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Read)]
        public Room Get(long roomId)
        {
            Logger.TraceMethodEnter(roomId);

            var result = _ctx.Rooms.FindByKeys(roomId);

            return Logger.TraceMethodExit(result) as Room;
        }


        /// <summary>
        /// Adds a new instance of Room to the data store
        /// </summary>
        /// <param name="room">The instance to add</param>
        /// <returns>The created instance</returns>
        [ActivityMethod("Create", MethodType.Create, IsDefault = true)]
        [ActivityResult("RoomTypes")]
        [ActivityResult("Features")]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Rooms.Data.Room Create(Room room)
        {
            Logger.TraceMethodEnter(room);

            room = _ctx.Rooms.Add(room);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(room.RoomId)) as Room;
        }


        /// <summary>
        /// Updates a Room instance in the data store
        /// </summary>
        /// <param name="room">The instance to update</param>
        /// <returns>The updated instance</returns>
        [ActivityMethod("Update", MethodType.Update, IsDefault = true)]
        [ActivityResult("RoomTypes")]
        [ActivityResult("Features")]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Rooms.Data.Room Update(Room room)
        {
            Logger.TraceMethodEnter(room);

            room = _ctx.Rooms.Modify(room);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(room.RoomId)) as Room;
        }


        /// <summary>
        /// Deletes a Room instance from the data store
        /// </summary>
        /// <param name="room">The instance to delete</param>
        [ActivityMethod("Delete", MethodType.Delete, IsDefault = true)]
        [ActivityResult("RoomTypes")]
        [ActivityResult("Features")]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Write)]
        public void Delete(Room room)
        {
            Logger.TraceMethodEnter(room);

            _ctx.Rooms.Remove(room);
            _ctx.SaveChanges();

            Logger.TraceMethodExit();
        }

        /// <summary>
        /// Updates a Room instance in the data store
        /// </summary>
        /// <param name="room">The instance to update</param>
        /// <returns>The updated instance</returns>
        [ActivityMethod("UpdateRoomReservationInfo", MethodType.Invoke, IsDefault = true)]
        [ActivityResult("RoomTypes")]
        [ActivityResult("Features")]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Write)]
        public void UpdateRoomReservationInfo(Room room)
        {
            Logger.TraceMethodEnter(room);
            
            var roomStatus = room.Status;

            // Refresh Room
            room = _ctx.Rooms.ReadOnlyQuery().Where(o => o.RoomId == room.RoomId).FirstOrDefault();
            if (room != null) {
                room.Status = roomStatus;
                room = _ctx.Rooms.Modify(room);
                _ctx.SaveChanges();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reservationId"></param>
        /// <returns></returns>
        [ActivityMethod("GetAvailable", MethodType.Query)]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Read)]
        public IEnumerable<Room> GetAvailable(long reservationId)
        {
            Logger.TraceMethodEnter();

            var reservation = ReservationHelper.GetReservationById(reservationId);
            DateTime startDate = reservation.ArrivalDate;
            DateTime endDate = reservation.DepartureDate;

            var reservedRoomIdList = ReservationHelper.GetReservedRoomIdList(reservationId);

            var result = _ctx.Rooms.ReadOnlyQuery().Where(r => r.RoomTypeId == reservation.RoomTypeId && r.Status != "DIRTY" && !reservedRoomIdList.Contains(r.RoomId));

            return Logger.TraceMethodExit(result) as IEnumerable<Room>;
        }

        /// <summary>
        /// Confirms a Reservation instance from the data store
        /// </summary>
        /// <param name="room">The instance to delete</param>
        [ActivityMethod("Clean", MethodType.Invoke, IsDefault = false)]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Write)]
        public Room Clean(Room room)
        {
            Logger.TraceMethodEnter(room);

            // Refresh Order
            room = _ctx.Rooms.ReadOnlyQuery().Where(o => o.RoomId == room.RoomId).FirstOrDefault();

            // Update status
            room.Status = "Clean";
            room = _ctx.Rooms.Modify(room);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(room.RoomId)) as Room;

        }
        /// 
        /// 
        /// <summary>
        /// Retrieves a single entity instance from the data store
        /// </summary>
        /// <param name="roomId">The key for Room</param>
        /// <returns>A single Room instance, or null if the instance doesn't exist</returns>
        protected Room GetFromDatastore(long roomId)
        {
            return _ctx.Rooms.ReadOnlyQuery().Where(p => p.RoomId == roomId).FirstOrDefault();
        }

        /// <summary>
        /// Releases all resources used by this RoomsActivity instance.
        /// </summary>
        public void Dispose()
        {
            if ((_ctx != null) && (_disposeContext))
                _ctx.Dispose();
            _ctx = null;
        }
    }
}
