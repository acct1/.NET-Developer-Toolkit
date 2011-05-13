using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Donios.DeveloperToolkit.DNA
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple=false, Inherited=true)]
    public class MorphAttribute : System.Attribute
    {
        public string Name { get; set; }

        public MorphAttribute()
        {
        }
    }
}
