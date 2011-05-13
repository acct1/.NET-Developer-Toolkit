namespace Donios.DeveloperToolkit.ObjectMap.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Donios.DeveloperToolkit.ObjectMap;

    internal class ObjectMap : ObjectMapBase
    {
        /// <summary>Initialize the object map</summary>
        public ObjectMap()
        {
            AddMap<Car,MorphedCar>(
                (model, data) =>
                {
                    if (model != null)
                    {
                        // add mappings
                        data.Color = model.Color;
                        data.Doors = model.Doors;
                        data.HasSatelliteRadio = model.HasSatelliteRadio;
                    }
                }
            );

            // Add more maps here
        }
    }
}
