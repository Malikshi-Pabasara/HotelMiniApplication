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



namespace Cenium.Contacts.Data
{

    [Entity]
    [Table("Contacts_Contacts")]
    public partial class Contact
    {


        #region Variables

        private long _contactId;
        private string _name;
        private Nullable<System.DateTime> _dateOfBirth;
        private string _idNumber;
        private string _address1;
        private string _address2;
        private string _city;
        private string _gender;
        private string _firstName;
        private string _lastName;
        private string _passportNo;
        private string _middleName;
        private Nullable<System.Guid> _primaryImageRef;
        private string _number;
        private ICollection<Phone> _phones;
        private ICollection<Email> _emails;
        private Guid _tenantId = Guid.Empty;

        #endregion


        #region Primitive Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [EntityMember(IsReadOnly = true, Order = 0, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual long ContactId
        {
            get { return _contactId; }
            set { _contactId = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 1, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 2, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        [DateTimeFormat(DateTimeFormat.DateTime)]
        public virtual Nullable<System.DateTime> DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 3, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string IdNumber
        {
            get { return _idNumber; }
            set { _idNumber = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 4, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 5, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string Address2
        {
            get { return _address2; }
            set { _address2 = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 6, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string City
        {
            get { return _city; }
            set { _city = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 7, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 8, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 9, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 10, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string PassportNo
        {
            get { return _passportNo; }
            set { _passportNo = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 11, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 12, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual Nullable<System.Guid> PrimaryImageRef
        {
            get { return _primaryImageRef; }
            set { _primaryImageRef = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 13, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string Number
        {
            get { return _number; }
            set { _number = value; }
        }


        #endregion


        #region Navigation Properties

        [EntityMember(IsReadOnly = false, Order = 14)]
        public virtual ICollection<Phone> Phones
        {
            get { return _phones; }
            set { _phones = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 15)]
        public virtual ICollection<Email> Emails
        {
            get { return _emails; }
            set { _emails = value; }
        }


        #endregion


        #region Framework Properties

        /// <summary>
        /// Tenant identifier, for internal framework usage only
        /// </summary>
        [EntityMember(IsReadOnly = true, IsHidden = true, Order = 16, IsQueryable = false, IsSortable = false)]
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
        [EntityMember(IsReadOnly = true, Order = 17, IsHidden = true, IsQueryable = false, IsSortable = false)]
        public virtual byte[] RowVersion
        {
            get;
            set;
        }


        #endregion

    }

}
