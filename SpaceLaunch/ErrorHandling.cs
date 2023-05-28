using System;
using System.IO;
using Space;


namespace Space
{
    public class ErrorHandling
    {
        public static void WriteToCsvFile(string fileName, string[] data)
        {
            try
            {
                File.WriteAllLines(fileName, data);
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error writing to the CSV file: {e.Message}");
            }
        }

        public static string[] ReadCsvFile(string fileName)
        {
            try
            {
                return File.ReadAllLines(fileName);
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error reading the CSV file: {e.Message}");
                return new string[0];
            }
        }
    }
}

