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
    /// The PhonesActivity class is an activity class that exposes data operation methods to the service layer. This class is responsible for applying business logic prior to making
    /// updates in the data store.
    /// </summary>
    /// <seealso cref="Cenium.Contacts.Data.Phone"/>
    /// <seealso cref="Cenium.Contacts.Data.ContactsEntitiesContext"/>
    [Activity("Phone")]
    public class PhonesActivity : IDisposable
    {

        private ContactsEntitiesContext _ctx;
        private bool _disposeContext = true;

        /// <summary>
        /// Initializes a new instance of the PhonesActivity class
        /// </summary>
        public PhonesActivity()
        {
            _ctx = new ContactsEntitiesContext();
        }

        /// <summary>
        /// Initializes a new instance of the PhonesActivity class, sharing the context with other activities
        /// </summary>
        /// <param name="ctx">The shared context</param>
        internal PhonesActivity(ContactsEntitiesContext ctx)
        {
            _ctx = ctx;
            _disposeContext = false;
        }


        /// <summary>
        /// Activity query method that returns an IEnumerable&lt;Phone&gt; instance. 
        /// </summary>
        /// <returns>A strongly type IEnumerable instance </returns>
        [ActivityMethod("Query", MethodType.Query, IsDefault = true)]
        [SecureResource("phones.administration", SecureResourcePermissionLevel.Read)]
        public IEnumerable<Phone> Query()
        {
            Logger.TraceMethodEnter();

            var result = _ctx.Phones.ReadOnlyQuery().OrderBy(p => p.PhoneId);

            return Logger.TraceMethodExit(result) as IEnumerable<Phone>;
        }


        /// <summary>
        /// Gets a Phone instance from the datastore based on Phone keys.
        /// </summary>
        /// <param name="phoneId">The key for Phone</param>
        /// <returns>A Phone instance, or null if there is no entities with the given key</returns>
        [ActivityMethod("Get", MethodType.Get, IsDefault = true)]
        [SecureResource("phones.administration", SecureResourcePermissionLevel.Read)]
        public Phone Get(long phoneId)
        {
            Logger.TraceMethodEnter(phoneId);

            var result = _ctx.Phones.FindByKeys(phoneId);

            return Logger.TraceMethodExit(result) as Phone;
        }


        /// <summary>
        /// Adds a new instance of Phone to the data store
        /// </summary>
        /// <param name="phone">The instance to add</param>
        /// <returns>The created instance</returns>
        [ActivityMethod("Create", MethodType.Create, IsDefault = true)]
        [SecureResource("phones.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Contacts.Data.Phone Create(Phone phone)
        {
            Logger.TraceMethodEnter(phone);

            phone = _ctx.Phones.Add(phone);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(phone.PhoneId)) as Phone;
        }


        /// <summary>
        /// Updates a Phone instance in the data store
        /// </summary>
        /// <param name="phone">The instance to update</param>
        /// <returns>The updated instance</returns>
        [ActivityMethod("Update", MethodType.Update, IsDefault = true)]
        [SecureResource("phones.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Contacts.Data.Phone Update(Phone phone)
        {
            Logger.TraceMethodEnter(phone);

            phone = _ctx.Phones.Modify(phone);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(phone.PhoneId)) as Phone;
        }


        /// <summary>
        /// Deletes a Phone instance from the data store
        /// </summary>
        /// <param name="phone">The instance to delete</param>
        [ActivityMethod("Delete", MethodType.Delete, IsDefault = true)]
        [SecureResource("phones.administration", SecureResourcePermissionLevel.Write)]
        public void Delete(Phone phone)
        {
            Logger.TraceMethodEnter(phone);

            _ctx.Phones.Remove(phone);
            _ctx.SaveChanges();

            Logger.TraceMethodExit();
        }


        /// <summary>
        /// Retrieves a single entity instance from the data store
        /// </summary>
        /// <param name="phoneId">The key for Phone</param>
        /// <returns>A single Phone instance, or null if the instance doesn't exist</returns>
        protected Phone GetFromDatastore(long phoneId)
        {
            return _ctx.Phones.ReadOnlyQuery().Where(p => p.PhoneId == phoneId).FirstOrDefault();
        }

        /// <summary>
        /// Releases all resources used by this PhonesActivity instance.
        /// </summary>
        public void Dispose()
        {
            if ((_ctx != null) && (_disposeContext))
                _ctx.Dispose();
            _ctx = null;
        }



    }

}
