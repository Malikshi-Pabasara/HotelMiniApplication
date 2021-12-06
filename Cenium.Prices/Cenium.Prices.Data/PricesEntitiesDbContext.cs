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



namespace Cenium.Prices.Data
{

    /// <summary>
    /// Provides facilities for querying and working with entities as objects.
    /// </summary>
    /// <remarks>
    /// This is an internal infrastructure class and should not be called directly by the developer.
    /// </remarks>
    public partial class PricesEntitiesDbContext : DbContextBase, IDisposable
    {


        #region Constructors

        /// <summary>
        /// Creates a new instance of the PricesEntitiesDbContext class
        /// </summary>
        /// <param name="connection">The connection string to use when creating the context.</param>
        public PricesEntitiesDbContext(string connection) : base(connection)
        {
        }


        #endregion


        #region DbSet properties

        /// <summary>
        /// Returns a typed entity set of Price that is used to perform create, read, update, delete (CRUD) operations.
        /// </summary>
        public virtual DbSet<Price> Prices
        {
            get;
            set;
        }


        #endregion

    }

}
