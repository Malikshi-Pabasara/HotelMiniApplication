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

    /// <summary>
    /// Provides facilities for querying and working with entities as objects
    /// </summary>
    public partial class RoomsEntitiesContext : EntityContext, IDisposable
    {


        #region Constructors

        /// <summary>
        /// Creates a new instance of the <c>RoomsEntitiesContext</c> class.
        /// </summary>
        public RoomsEntitiesContext()
        {
        }


        #endregion


        #region EntityCollection properties

        /// <summary>
        /// Returns a typed EntityCollection of Room that is used to perform create, read, update, delete (CRUD) operations.
        /// </summary>
        public virtual EntityCollection<Room> Rooms
        {
            get { return GetEntityCollection<Room>(); }
        }

        /// <summary>
        /// Returns a typed EntityCollection of RoomType that is used to perform create, read, update, delete (CRUD) operations.
        /// </summary>
        public virtual EntityCollection<RoomType> RoomTypes
        {
            get { return GetEntityCollection<RoomType>(); }
        }

        /// <summary>
        /// Returns a typed EntityCollection of Feature that is used to perform create, read, update, delete (CRUD) operations.
        /// </summary>
        public virtual EntityCollection<Feature> Features
        {
            get { return GetEntityCollection<Feature>(); }
        }

        /// <summary>
        /// Returns a typed EntityCollection of RoomTypeFeature that is used to perform create, read, update, delete (CRUD) operations.
        /// </summary>
        public virtual EntityCollection<RoomTypeFeature> RoomTypeFeatures
        {
            get { return GetEntityCollection<RoomTypeFeature>(); }
        }


        #endregion


        #region Protected methods and properties

        /// <summary>
        /// Creates the underlying DbContext instance. 
        /// </summary>
        /// <param name="connection">The database connection string</param>
        /// <returns>A new RoomsEntitiesDbContext instance</returns>
        protected override DbContext CreateDbContext(string connection)
        {
            return new RoomsEntitiesDbContext(connection);
        }


        #endregion


        #region Static methods and properties

        static RoomsEntitiesContext()
        {
            Database.SetInitializer<RoomsEntitiesDbContext>(new ScriptDatabaseInitializer<RoomsEntitiesDbContext>());
        }


        #endregion

    }

}
