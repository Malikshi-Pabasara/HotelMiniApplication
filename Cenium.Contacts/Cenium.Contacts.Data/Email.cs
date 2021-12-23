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
    [Table("Contacts_Emails")]
    public partial class Email
    {


        #region Variables

        private long _emailId;
        private string _emailAddress;
        private long _contactId;
        private Contact _contact;
        private Guid _tenantId = Guid.Empty;

        #endregion


        #region Primitive Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [EntityMember(IsReadOnly = true, Order = 0, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual long EmailId
        {
            get { return _emailId; }
            set { _emailId = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 1, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }


        #endregion


        #region Navigation Properties

        /// <summary>
        /// Foreign key property for Contact
        /// </summary>
        [Required]
        [ForeignKey("Contact")]
        [EntityMember(IsReadOnly = false, Order = 2, Reference = "Contact", IsQueryable = false, IsSortable = false)]
        public virtual long ContactId
        {
            get { return _contactId; }
            set { _contactId = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 3)]
        public virtual Contact Contact
        {
            get { return _contact; }
            set { _contact = value; }
        }


        #endregion


        #region Framework Properties

        /// <summary>
        /// Tenant identifier, for internal framework usage only
        /// </summary>
        [EntityMember(IsReadOnly = true, IsHidden = true, Order = 4, IsQueryable = false, IsSortable = false)]
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
        [EntityMember(IsReadOnly = true, Order = 5, IsHidden = true, IsQueryable = false, IsSortable = false)]
        public virtual byte[] RowVersion
        {
            get;
            set;
        }


        #endregion

    }

}
