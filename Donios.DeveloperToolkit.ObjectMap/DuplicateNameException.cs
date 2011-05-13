using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Donios.DeveloperToolkit.DNA
{
    public class DuplicateNameException : System.Exception
    {
        public DuplicateNameException(string message) : base(message) { }
    }
}
