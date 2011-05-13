namespace Donios.DeveloperToolkit.Json
{
    using System;
    using System.Json;
    using System.ComponentModel;

    /// <summary>Methods for converting objects to Json objects</summary>
    public class Convert
    {
        /// <summary>Converts the specified entity to a Json Object</summary>
        /// <typeparam name="T">Type of the entity to convert</typeparam>
        /// <param name="entity">Entity to convert</param>
        /// <returns>Json formatted object</returns>
        public static JsonObject ToJson<T>(T entity)
        {
            JsonObject json = new JsonObject();
            foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(typeof(T)))
            {
                var value = propertyDescriptor.GetValue(entity);
                Type t = propertyDescriptor.PropertyType;
                if (value != null)
                {
                    JsonPrimitive prim;   
                    if (t == typeof(System.Boolean))
                        prim = new JsonPrimitive((bool)value);
                    else if (t == typeof(System.Uri))
                        prim = new JsonPrimitive((Uri)value);
                    else if (t == typeof(System.Decimal))
                        prim = new JsonPrimitive((Decimal)value);
                    else if (t == typeof(System.SByte))
                        prim = new JsonPrimitive((SByte)value);
                    else if (t == typeof(System.Char))
                        prim = new JsonPrimitive((Char)value);
                    else if (t == typeof(System.DateTimeOffset))
                        prim = new JsonPrimitive((DateTimeOffset)value);
                    else if (t == typeof(System.Byte))
                        prim = new JsonPrimitive((Byte)value);
                    else if (t == typeof(System.DateTime))
                        prim = new JsonPrimitive((DateTime)value);
                    else if (t == typeof(System.Int16))
                        prim = new JsonPrimitive((Int16)value);
                    else if (t == typeof(System.Int32))
                        prim = new JsonPrimitive((Int32)value);
                    else if (t == typeof(System.Int64))
                        prim = new JsonPrimitive((Int64)value);
                    else if (t == typeof(System.UInt32))
                        prim = new JsonPrimitive((UInt32)value);
                    else if (t == typeof(System.UInt64))
                        prim = new JsonPrimitive((UInt64)value);
                    else if (t == typeof(System.Double))
                        prim = new JsonPrimitive((double)value);
                    else if (t == typeof(System.Single))
                        prim = new JsonPrimitive((float)value);
                    else if (t == typeof(System.Guid))
                        prim = new JsonPrimitive((Guid)value);
                    else // System.String
                        prim = new JsonPrimitive((string)value);
                    json.Add(propertyDescriptor.Name, prim);
                }
            }
            return json;
        }
    }
}