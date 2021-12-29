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



namespace Cenium.Rooms.Data
{

    [Entity]
    [Table("Rooms_Rooms")]
    public partial class Room
    {


        #region Variables

        private long _roomId;
        private string _roomNumber;
        private string _status;
        private string _name;
        private string _description;
        private Nullable<double> _roomWidth;
        private Nullable<double> _roomLength;
        private string _priceCode;
        private long _propertyContextId;
        private Nullable<double> _squareMeters;
        private Nullable<double> _ceilingHeight;
        private string _property;
        private long _roomTypeId;
        private RoomType _roomType;
        private Guid _tenantId = Guid.Empty;

        #endregion


        #region Primitive Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [EntityMember(IsReadOnly = true, Order = 0, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual long RoomId
        {
            get { return _roomId; }
            set { _roomId = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 1, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string RoomNumber
        {
            get { return _roomNumber; }
            set { _roomNumber = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 2, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 3, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 4, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 5, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual Nullable<double> RoomWidth
        {
            get { return _roomWidth; }
            set { _roomWidth = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 6, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual Nullable<double> RoomLength
        {
            get { return _roomLength; }
            set { _roomLength = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 7, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string PriceCode
        {
            get { return _priceCode; }
            set { _priceCode = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 8, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual long PropertyContextId
        {
            get { return _propertyContextId; }
            set { _propertyContextId = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 9, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual Nullable<double> SquareMeters
        {
            get { return _squareMeters; }
            set { _squareMeters = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 10, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual Nullable<double> CeilingHeight
        {
            get { return _ceilingHeight; }
            set { _ceilingHeight = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 11, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string Property
        {
            get { return _property; }
            set { _property = value; }
        }


        #endregion


        #region Navigation Properties

        /// <summary>
        /// Foreign key property for RoomType
        /// </summary>
        [Required]
        [ForeignKey("RoomType")]
        [EntityMember(IsReadOnly = false, Order = 12, Reference = "RoomType", IsQueryable = false, IsSortable = false)]
        public virtual long RoomTypeId
        {
            get { return _roomTypeId; }
            set { _roomTypeId = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 13)]
        public virtual RoomType RoomType
        {
            get { return _roomType; }
            set { _roomType = value; }
        }


        #endregion


        #region Framework Properties

        /// <summary>
        /// Tenant identifier, for internal framework usage only
        /// </summary>
        [EntityMember(IsReadOnly = true, IsHidden = true, Order = 14, IsQueryable = false, IsSortable = false)]
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
        [EntityMember(IsReadOnly = true, Order = 15, IsHidden = true, IsQueryable = false, IsSortable = false)]
        public virtual byte[] RowVersion
        {
            get;
            set;
        }


        #endregion

    }

}
