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
 * Malikshi.P  10/31/2021    Created
 */


using System;
using System.Linq;
using System.Collections.Generic;

using Cenium.Framework.Core.Attributes;
using Cenium.Framework.Logging;
using Cenium.Reservations.Data;
using Cenium.Framework.Security;
using Cenium.Reservations.Activities.Helpers.Rooms;

namespace Cenium.Reservations.Activities
{

    /// <summary>
    /// The ReservationsActivity class is an activity class that exposes data operation methods to the service layer. This class is responsible for applying business logic prior to making
    /// updates in the data store.
    /// </summary>
    /// <seealso cref="Cenium.Reservations.Data.Reservation"/>
    /// <seealso cref="Cenium.Reservations.Data.ReservationsEntitiesContext"/>
    [Activity("Reservation")]
    public class ReservationsActivity : IDisposable
    {

        private ReservationsEntitiesContext _ctx;
        private bool _disposeContext = true;

        /// <summary>
        /// Initializes a new instance of the ReservationsActivity class
        /// </summary>
        public ReservationsActivity()
        {
            _ctx = new ReservationsEntitiesContext();
        }

        /// <summary>
        /// Initializes a new instance of the ReservationsActivity class, sharing the context with other activities
        /// </summary>
        /// <param name="ctx">The shared context</param>
        internal ReservationsActivity(ReservationsEntitiesContext ctx)
        {
            _ctx = ctx;
            _disposeContext = false;
        }


        /// <summary>
        /// Activity query method that returns an IEnumerable&lt;Reservation&gt; instance. 
        /// </summary>
        /// <returns>A strongly type IEnumerable instance </returns>
        [ActivityMethod("Query", MethodType.Query, IsDefault = true)]
        [SecureResource("reservations.administration", SecureResourcePermissionLevel.Read)]
        public IEnumerable<Reservation> Query()
        {
            Logger.TraceMethodEnter();

            var result = _ctx.Reservations.ReadOnlyQuery().OrderBy(p => p.ReservationId);

            return Logger.TraceMethodExit(result) as IEnumerable<Reservation>;
        }


        /// <summary>
        /// Gets a Reservation instance from the datastore based on Reservation keys.
        /// </summary>
        /// <param name="reservationId">The key for Reservation</param>
        /// <returns>A Reservation instance, or null if there is no entities with the given key</returns>
        [ActivityMethod("Get", MethodType.Get, IsDefault = true)]
        [SecureResource("reservations.administration", SecureResourcePermissionLevel.Read)]
        public Reservation Get(long reservationId)
        {
            Logger.TraceMethodEnter(reservationId);

            var result = _ctx.Reservations.FindByKeys(reservationId);

            return Logger.TraceMethodExit(result) as Reservation;
        }


        /// <summary>
        /// Adds a new instance of Reservation to the data store
        /// </summary>
        /// <param name="reservation">The instance to add</param>
        /// <returns>The created instance</returns>
        [ActivityMethod("Create", MethodType.Create, IsDefault = true)]
        [SecureResource("reservations.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Reservations.Data.Reservation Create(Reservation reservation)
        {
            Logger.TraceMethodEnter(reservation);

            reservation = _ctx.Reservations.Add(reservation);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(reservation.ReservationId)) as Reservation;
        }


        /// <summary>
        /// Updates a Reservation instance in the data store
        /// </summary>
        /// <param name="reservation">The instance to update</param>
        /// <returns>The updated instance</returns>
        [ActivityMethod("Update", MethodType.Update, IsDefault = true)]
        [SecureResource("reservations.administration", SecureResourcePermissionLevel.Write)]
        public Reservation Update(Reservation reservation)
        {
            Logger.TraceMethodEnter(reservation);

            reservation = _ctx.Reservations.Modify(reservation);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(reservation.ReservationId)) as Reservation;
        }


        /// <summary>
        /// Deletes a Reservation instance from the data store
        /// </summary>
        /// <param name="reservation">The instance to delete</param>
        [ActivityMethod("Delete", MethodType.Delete, IsDefault = true)]
        [SecureResource("reservations.administration", SecureResourcePermissionLevel.Write)]
        public void Delete(Reservation reservation)
        {
            Logger.TraceMethodEnter(reservation);
            //var roomId = reservation.RoomId;

            _ctx.Reservations.Remove(reservation);
            _ctx.SaveChanges();

            Logger.TraceMethodExit();
        }


        /// <summary>
        /// Check-In a Reservation instance from the data store
        /// </summary>
        /// <param name="reservation">The instance to delete</param>
        [ActivityMethod("CheckIn", MethodType.Invoke, IsDefault = false)]
        [SecureResource("reservations.administration", SecureResourcePermissionLevel.Write)]
        public Reservation CheckIn(Reservation reservation)
        {
            Logger.TraceMethodEnter(reservation);

            // Refresh Order
            reservation = _ctx.Reservations.ReadOnlyQuery().Where(o => o.ReservationId == reservation.ReservationId).FirstOrDefault();

            // Update status
            reservation.ReservationStatus = "CHECKED-IN";
            reservation = _ctx.Reservations.Modify(reservation);
            _ctx.SaveChanges();

            // make room status to Occupied using proxy
            RoomProxy room_proxy = new RoomProxy();
            room_proxy.RoomId = reservation.RoomId;
            room_proxy.Status = "OCCUPIED";

            RoomHelper.UpdateRoomReservationInfo(room_proxy);

            return Logger.TraceMethodExit(GetFromDatastore(reservation.ReservationId)) as Reservation;

        }

        /// <summary>
        /// Check-Out a Reservation instance from the data store
        /// </summary>
        /// <param name="reservation">The instance to delete</param>
        [ActivityMethod("CheckOut", MethodType.Invoke, IsDefault = false)]
        [SecureResource("reservations.administration", SecureResourcePermissionLevel.Write)]
        public Reservation CheckOut(Reservation reservation)
        {
            Logger.TraceMethodEnter(reservation);

            // Refresh Reservation
            reservation = _ctx.Reservations.ReadOnlyQuery().Where(o => o.ReservationId == reservation.ReservationId).FirstOrDefault();

            // Update status
            reservation.ReservationStatus = "CHECKED-OUT";
            reservation = _ctx.Reservations.Modify(reservation);
            _ctx.SaveChanges();

            // make room status to Dirty using proxy
            RoomProxy room_proxy = new RoomProxy();
            room_proxy.RoomId = reservation.RoomId;
            room_proxy.Status = "DIRTY";

            RoomHelper.UpdateRoomReservationInfo(room_proxy);
            return Logger.TraceMethodExit(GetFromDatastore(reservation.ReservationId)) as Reservation;

        }


        /// <summary>
        /// Retrieves a single entity instance from the data store
        /// </summary>
        /// <param name="reservationId">The key for Reservation</param>
        /// <returns>A single Reservation instance, or null if the instance doesn't exist</returns>
        protected Reservation GetFromDatastore(long reservationId)
        {
            return _ctx.Reservations.ReadOnlyQuery().Where(p => p.ReservationId == reservationId).FirstOrDefault();
        }

        /// <summary>
        /// Releases all resources used by this ReservationsActivity instance.
        /// </summary>
        public void Dispose()
        {
            if ((_ctx != null) && (_disposeContext))
                _ctx.Dispose();
            _ctx = null;
        }



    }

}
