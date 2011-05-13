namespace Donios
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>Every project must have a Hello World class.</summary>
    public class HelloWorld
    {
        private HelloWorld()
        {
        }

        /// <summary>Returns a string with the specified name.</summary>
        /// <param name="name">Name. to use in the returned string</param>
        /// <returns>Hello [name]!</returns>
        public string SayHello(string name)
        {
            return string.Format("Hello {0}!", name);
        }
    }
}
