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
 * Malikshi.P  12/06/2021    Created
 */


using System;
using System.Linq;
using System.Collections.Generic;

using Cenium.Framework.Core.Attributes;
using Cenium.Framework.Logging;
using Cenium.Contacts.Data;
using Cenium.Framework.Security;

namespace Cenium.Contacts.Activities
{

    /// <summary>
    /// The EmailsActivity class is an activity class that exposes data operation methods to the service layer. This class is responsible for applying business logic prior to making
    /// updates in the data store.
    /// </summary>
    /// <seealso cref="Cenium.Contacts.Data.Email"/>
    /// <seealso cref="Cenium.Contacts.Data.ContactsEntitiesContext"/>
    [Activity("Email")]
    public class EmailsActivity : IDisposable
    {

        private ContactsEntitiesContext _ctx;
        private bool _disposeContext = true;

        /// <summary>
        /// Initializes a new instance of the EmailsActivity class
        /// </summary>
        public EmailsActivity()
        {
            _ctx = new ContactsEntitiesContext();
        }

        /// <summary>
        /// Initializes a new instance of the EmailsActivity class, sharing the context with other activities
        /// </summary>
        /// <param name="ctx">The shared context</param>
        internal EmailsActivity(ContactsEntitiesContext ctx)
        {
            _ctx = ctx;
            _disposeContext = false;
        }


        /// <summary>
        /// Activity query method that returns an IEnumerable&lt;Email&gt; instance. 
        /// </summary>
        /// <returns>A strongly type IEnumerable instance </returns>
        [ActivityMethod("Query", MethodType.Query, IsDefault = true)]
        [SecureResource("emails.administration", SecureResourcePermissionLevel.Read)]
        public IEnumerable<Email> Query()
        {
            Logger.TraceMethodEnter();

            var result = _ctx.Emails.ReadOnlyQuery().OrderBy(p => p.EmailId);

            return Logger.TraceMethodExit(result) as IEnumerable<Email>;
        }


        /// <summary>
        /// Gets a Email instance from the datastore based on Email keys.
        /// </summary>
        /// <param name="emailId">The key for Email</param>
        /// <returns>A Email instance, or null if there is no entities with the given key</returns>
        [ActivityMethod("Get", MethodType.Get, IsDefault = true)]
        [SecureResource("emails.administration", SecureResourcePermissionLevel.Read)]
        public Email Get(long emailId)
        {
            Logger.TraceMethodEnter(emailId);

            var result = _ctx.Emails.FindByKeys(emailId);

            return Logger.TraceMethodExit(result) as Email;
        }


        /// <summary>
        /// Adds a new instance of Email to the data store
        /// </summary>
        /// <param name="email">The instance to add</param>
        /// <returns>The created instance</returns>
        [ActivityMethod("Create", MethodType.Create, IsDefault = true)]
        [SecureResource("emails.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Contacts.Data.Email Create(Email email)
        {
            Logger.TraceMethodEnter(email);

            email = _ctx.Emails.Add(email);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(email.EmailId)) as Email;
        }


        /// <summary>
        /// Updates a Email instance in the data store
        /// </summary>
        /// <param name="email">The instance to update</param>
        /// <returns>The updated instance</returns>
        [ActivityMethod("Update", MethodType.Update, IsDefault = true)]
        [SecureResource("emails.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Contacts.Data.Email Update(Email email)
        {
            Logger.TraceMethodEnter(email);

            email = _ctx.Emails.Modify(email);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(email.EmailId)) as Email;
        }


        /// <summary>
        /// Deletes a Email instance from the data store
        /// </summary>
        /// <param name="email">The instance to delete</param>
        [ActivityMethod("Delete", MethodType.Delete, IsDefault = true)]
        [SecureResource("emails.administration", SecureResourcePermissionLevel.Write)]
        public void Delete(Email email)
        {
            Logger.TraceMethodEnter(email);

            _ctx.Emails.Remove(email);
            _ctx.SaveChanges();

            Logger.TraceMethodExit();
        }


        /// <summary>
        /// Retrieves a single entity instance from the data store
        /// </summary>
        /// <param name="emailId">The key for Email</param>
        /// <returns>A single Email instance, or null if the instance doesn't exist</returns>
        protected Email GetFromDatastore(long emailId)
        {
            return _ctx.Emails.ReadOnlyQuery().Where(p => p.EmailId == emailId).FirstOrDefault();
        }

        /// <summary>
        /// Releases all resources used by this EmailsActivity instance.
        /// </summary>
        public void Dispose()
        {
            if ((_ctx != null) && (_disposeContext))
                _ctx.Dispose();
            _ctx = null;
        }



    }

}
