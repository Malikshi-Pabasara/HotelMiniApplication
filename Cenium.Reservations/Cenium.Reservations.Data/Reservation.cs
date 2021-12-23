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
    [PropertyContextEntity("PropertyContextId")]
    public partial class Reservation
    {


        #region Variables

        private long _reservationId;
        private string _number;
        private long _propertyContextId;
        private long _roomId;
        private long _contactId;
        private System.DateTime _arrivalDate;
        private System.DateTime _departureDate;
        private string _reservationStatus = "Confirmed";
        private string _roomNumber;
        private string _price;
        private bool _paymentDone;
        private string _contactName;
        private Nullable<long> _roomTypeId;
        private string _roomTypeCode;
        private string _propertyContextName;
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
        public virtual long PropertyContextId
        {
            get { return _propertyContextId; }
            set { _propertyContextId = value; }
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

        [Required]
        [EntityMember(IsReadOnly = false, Order = 5, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        [DateTimeFormat(DateTimeFormat.DateTime)]
        public virtual System.DateTime ArrivalDate
        {
            get { return _arrivalDate; }
            set { _arrivalDate = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 6, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        [DateTimeFormat(DateTimeFormat.DateTime)]
        public virtual System.DateTime DepartureDate
        {
            get { return _departureDate; }
            set { _departureDate = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 7, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string ReservationStatus
        {
            get { return _reservationStatus; }
            set { _reservationStatus = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 8, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string RoomNumber
        {
            get { return _roomNumber; }
            set { _roomNumber = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 9, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string Price
        {
            get { return _price; }
            set { _price = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 10, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual bool PaymentDone
        {
            get { return _paymentDone; }
            set { _paymentDone = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 11, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string ContactName
        {
            get { return _contactName; }
            set { _contactName = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 12, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual Nullable<long> RoomTypeId
        {
            get { return _roomTypeId; }
            set { _roomTypeId = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 13, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string RoomTypeCode
        {
            get { return _roomTypeCode; }
            set { _roomTypeCode = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 14, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string PropertyContextName
        {
            get { return _propertyContextName; }
            set { _propertyContextName = value; }
        }


        #endregion


        #region Framework Properties

        /// <summary>
        /// Tenant identifier, for internal framework usage only
        /// </summary>
        [EntityMember(IsReadOnly = true, IsHidden = true, Order = 15, IsQueryable = false, IsSortable = false)]
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
        [EntityMember(IsReadOnly = true, Order = 16, IsHidden = true, IsQueryable = false, IsSortable = false)]
        public virtual byte[] RowVersion
        {
            get;
            set;
        }


        #endregion

    }

}
