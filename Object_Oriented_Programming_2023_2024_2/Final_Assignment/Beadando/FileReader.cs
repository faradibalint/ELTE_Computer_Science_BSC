using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    public class FileReader
    {
        private string filePath;

        public FileReader(string filePath)
        {
            this.filePath = filePath;
        }

        public string[] ReadLines()
        {
            try
            {
                string[] lines = File.ReadAllLines(this.filePath);
                return lines;
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error reading file: {e.Message}");
                return new string[0];
            }
            
        }
    }
}
