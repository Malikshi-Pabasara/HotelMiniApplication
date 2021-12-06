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
 * Malikshi.P  11/01/2021    Created
 */


using Cenium.Framework.Component.Interface;

namespace Cenium.Reservations.Activities.Helpers
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>

    internal abstract class ProxyWrapperBase
    {
        private IEntityProxy _proxy;

        /// <summary>
        /// Initializes a new instance of the ProxyWrapperBase class
        /// </summary>
        /// <param name="proxy">The entity proxy to wrap</param>
        protected ProxyWrapperBase(IEntityProxy proxy)
        {
            _proxy = proxy;
        }

        /// <summary>
        /// Initializes a new instance of the ProxyWrapperBase class
        /// </summary>
        protected ProxyWrapperBase()
        { }

        /// <summary>
        /// Gets a strongly typed value from the proxy entity, if the property is available
        /// </summary>
        /// <typeparam name="T">The value type</typeparam>
        /// <param name="name">The name of the property</param>
        /// <returns>The value of the property, or default(T) if the property does not exist, is the wrong type or is null</returns>
        protected T GetValue<T>(string name)
        {
            if (_proxy == null)
                return default(T);

            if (_proxy.IsPropertyAvailable(name))
            {
                var value = _proxy[name];
                if (value != null)
                    if (typeof(T).IsInstanceOfType(value))
                        return (T)value;
            }
            return default(T);
        }

        protected void SetValue(string name, object value)
        {
            if ((_proxy == null) || (!_proxy.IsPropertyAvailable(name)))
                return;

            _proxy[name] = value;
        }

        public IEntityProxy EntityProxy
        {
            get { return _proxy; }
            set { _proxy = value; }
        }
    }
}