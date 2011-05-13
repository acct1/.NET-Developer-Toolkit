namespace Donios.DeveloperToolkit.ObjectMap
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>Base class for an Object-to-Object mapper</summary>
    /// <remarks>Code adapted from http://antix.co.uk/Blog/Object-Object-Mapping </remarks>
    public abstract class ObjectMapBase
    {
        private static Dictionary<Tuple<Type, Type>, object> _maps = new Dictionary<Tuple<Type, Type>, object>();

        /// <summary>Add a new object-to-object mapping</summary>
        /// <typeparam name="TFrom">Source type</typeparam>
        /// <typeparam name="TTo">Destination type</typeparam>
        /// <param name="map">Mapping delegate</param>
        protected void AddMap<TFrom, TTo>(Action<TFrom, TTo> map)
            where TFrom : class
            where TTo : class
        {
            _maps.Add(Tuple.Create(typeof(TFrom), typeof(TTo)), map);
        }

        /// <summary>Converts an object based on the object-to-object map</summary>
        /// <typeparam name="TFrom">Source type</typeparam>
        /// <typeparam name="TTo">Destination type</typeparam>
        /// <param name="from">Source object</param>
        /// <param name="to">Destination object</param>
        protected void Map<TFrom, TTo>(TFrom from, TTo to)
        {
            var key = Tuple.Create(typeof(TFrom), typeof(TTo));
            var map = (Action<TFrom, TTo>)_maps[key];

            if (map == null)
                throw new Exception(
                    string.Format("No map defined for {0} => {1}",
                        typeof(TFrom).Name, typeof(TTo).Name));
            map(from, to);
        }

        /// <summary>Converts one object to another based on the object-to-object mappings that have been defined.</summary>
        /// <typeparam name="TTo">Source type</typeparam>
        /// <param name="from">Destination type</param>
        /// <returns>Destination type hydrated with data from the Source type</returns>
        public TTo Convert<TTo, TFrom>(TFrom from)
        {
            if (from != null)
            {
                TTo returnObject = Activator.CreateInstance<TTo>();
                Map(from, returnObject);
                return returnObject;
            }
            return default(TTo);
        }
    }
}
