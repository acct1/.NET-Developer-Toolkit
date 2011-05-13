namespace Donios.DeveloperToolkit.IO
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>Functionality for writing files</summary>
    public class FileWriter
    {
        private FileWriter()
        { }

        /// <summary>Writes a string to the specified file</summary>
        /// <param name="filePath">Path to the file including the file name</param>
        /// <param name="fileContent">String to write to the file</param>
        public static void WriteToFile(string filePath, string fileContent)
        {
            using (StreamWriter outfile = new StreamWriter(filePath))
            {
                outfile.Write(fileContent);
            }
        }
    }
}