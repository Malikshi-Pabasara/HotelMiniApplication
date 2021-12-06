/*
 * Copyright (c) Cenium AS. All Right Reserved
 *
 * This source is subject to the Cenium License.
 * Please see the License.txt file for more information.
 * All other rights reserved.
 * 
 * http://www.cenium.com
 * 
 * This code was generated from a template. Changes to this file may cause incorrect behavior 
 * and will be lost if the code is regenerated. 
*/


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

using Cenium.Framework.Data;
using Cenium.Framework.Core.Attributes;
using Cenium.Framework.Context;
using Cenium.Framework.ComponentModel;



namespace Cenium.Reservations.Data
{

    [Entity]
    [Table("Reservations_Reservations")]
    public partial class Reservation
    {


        #region Variables

        private long _reservationId;
        private string _number;
        private long _propertyId;
        private long _roomId;
        private long _contactId;
        private Nullable<System.DateTime> _arrivalDate;
        private Nullable<System.DateTime> _departureDate;
        private string _reservationStatus;
        private Guid _tenantId = Guid.Empty;

        #endregion


        #region Primitive Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [EntityMember(IsReadOnly = true, Order = 0, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual long ReservationId
        {
            get { return _reservationId; }
            set { _reservationId = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 1, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string Number
        {
            get { return _number; }
            set { _number = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 2, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual long PropertyId
        {
            get { return _propertyId; }
            set { _propertyId = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 3, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual long RoomId
        {
            get { return _roomId; }
            set { _roomId = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 4, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual long ContactId
        {
            get { return _contactId; }
            set { _contactId = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 5, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        [DateTimeFormat(DateTimeFormat.DateTime)]
        public virtual Nullable<System.DateTime> ArrivalDate
        {
            get { return _arrivalDate; }
            set { _arrivalDate = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 6, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        [DateTimeFormat(DateTimeFormat.DateTime)]
        public virtual Nullable<System.DateTime> DepartureDate
        {
            get { return _departureDate; }
            set { _departureDate = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 7, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string ReservationStatus
        {
            get { return _reservationStatus; }
            set { _reservationStatus = value; }
        }


        #endregion


        #region Framework Properties

        /// <summary>
        /// Tenant identifier, for internal framework usage only
        /// </summary>
        [EntityMember(IsReadOnly = true, IsHidden = true, Order = 8, IsQueryable = false, IsSortable = false)]
        public virtual Guid TenantId
        {
            get { return _tenantId; }
            set { _tenantId = value; }
        }

        /// <summary>
        /// Concurrency control version number
        /// </summary>
        [Timestamp]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [EntityMember(IsReadOnly = true, Order = 9, IsHidden = true, IsQueryable = false, IsSortable = false)]
        public virtual byte[] RowVersion
        {
            get;
            set;
        }


        #endregion

    }

}