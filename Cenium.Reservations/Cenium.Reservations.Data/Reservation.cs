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
        private long _propertyContextId;
        private long _roomId;
        private long _contactId;
        private System.DateTime _arrivalDate;
        private System.DateTime _departureDate;
        private string _reservationStatus = "Confirmed";
        private string _roomNumber;
        private string _price;
        private Nullable<bool> _paymentDone;
        private string _contactName;
        private long _roomTypeId;
        private string _roomTypeCode;
        private string _propertyContextName;
        private string _balance;
        private string _discount;
        private string _paymentNumber;
        private string _number;
        private string _paymentMethod;
        private string _totalAmount;
        private Nullable<long> _totalDays;
        private string _nameOnCard;
        private string _creditCardNumber;
        private string _cVV;
        private Nullable<System.DateTime> _expiryDate;
        private string _paymentStatus;
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
        public virtual long PropertyContextId
        {
            get { return _propertyContextId; }
            set { _propertyContextId = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 2, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual long RoomId
        {
            get { return _roomId; }
            set { _roomId = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 3, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual long ContactId
        {
            get { return _contactId; }
            set { _contactId = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 4, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        [DateTimeFormat(DateTimeFormat.DateTime)]
        public virtual System.DateTime ArrivalDate
        {
            get { return _arrivalDate; }
            set { _arrivalDate = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 5, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        [DateTimeFormat(DateTimeFormat.DateTime)]
        public virtual System.DateTime DepartureDate
        {
            get { return _departureDate; }
            set { _departureDate = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 6, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string ReservationStatus
        {
            get { return _reservationStatus; }
            set { _reservationStatus = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 7, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string RoomNumber
        {
            get { return _roomNumber; }
            set { _roomNumber = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 8, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string Price
        {
            get { return _price; }
            set { _price = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 9, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual Nullable<bool> PaymentDone
        {
            get { return _paymentDone; }
            set { _paymentDone = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 10, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string ContactName
        {
            get { return _contactName; }
            set { _contactName = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 11, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual long RoomTypeId
        {
            get { return _roomTypeId; }
            set { _roomTypeId = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 12, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string RoomTypeCode
        {
            get { return _roomTypeCode; }
            set { _roomTypeCode = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 13, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string PropertyContextName
        {
            get { return _propertyContextName; }
            set { _propertyContextName = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 14, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 15, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string Discount
        {
            get { return _discount; }
            set { _discount = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 16, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string PaymentNumber
        {
            get { return _paymentNumber; }
            set { _paymentNumber = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 17, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string Number
        {
            get { return _number; }
            set { _number = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 18, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string PaymentMethod
        {
            get { return _paymentMethod; }
            set { _paymentMethod = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 19, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string TotalAmount
        {
            get { return _totalAmount; }
            set { _totalAmount = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 20, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual Nullable<long> TotalDays
        {
            get { return _totalDays; }
            set { _totalDays = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 21, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string NameOnCard
        {
            get { return _nameOnCard; }
            set { _nameOnCard = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 22, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string CreditCardNumber
        {
            get { return _creditCardNumber; }
            set { _creditCardNumber = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 23, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string CVV
        {
            get { return _cVV; }
            set { _cVV = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 24, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        [DateTimeFormat(DateTimeFormat.DateTime)]
        public virtual Nullable<System.DateTime> ExpiryDate
        {
            get { return _expiryDate; }
            set { _expiryDate = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 25, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string PaymentStatus
        {
            get { return _paymentStatus; }
            set { _paymentStatus = value; }
        }


        #endregion


        #region Framework Properties

        /// <summary>
        /// Tenant identifier, for internal framework usage only
        /// </summary>
        [EntityMember(IsReadOnly = true, IsHidden = true, Order = 26, IsQueryable = false, IsSortable = false)]
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
        [EntityMember(IsReadOnly = true, Order = 27, IsHidden = true, IsQueryable = false, IsSortable = false)]
        public virtual byte[] RowVersion
        {
            get;
            set;
        }


        #endregion

    }

}
