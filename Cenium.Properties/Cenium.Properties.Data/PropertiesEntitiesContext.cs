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



namespace Cenium.Properties.Data
{

    /// <summary>
    /// Provides facilities for querying and working with entities as objects
    /// </summary>
    public partial class PropertiesEntitiesContext : EntityContext, IDisposable
    {


        #region Constructors

        /// <summary>
        /// Creates a new instance of the <c>PropertiesEntitiesContext</c> class.
        /// </summary>
        public PropertiesEntitiesContext()
        {
        }


        #endregion


        #region EntityCollection properties

        /// <summary>
        /// Returns a typed EntityCollection of Property that is used to perform create, read, update, delete (CRUD) operations.
        /// </summary>
        public virtual EntityCollection<Property> Properties
        {
            get { return GetEntityCollection<Property>(); }
        }


        #endregion


        #region Protected methods and properties

        /// <summary>
        /// Creates the underlying DbContext instance. 
        /// </summary>
        /// <param name="connection">The database connection string</param>
        /// <returns>A new PropertiesEntitiesDbContext instance</returns>
        protected override DbContext CreateDbContext(string connection)
        {
            return new PropertiesEntitiesDbContext(connection);
        }


        #endregion


        #region Static methods and properties

        static PropertiesEntitiesContext()
        {
            Database.SetInitializer<PropertiesEntitiesDbContext>(new ScriptDatabaseInitializer<PropertiesEntitiesDbContext>());
        }


        #endregion

    }

}
