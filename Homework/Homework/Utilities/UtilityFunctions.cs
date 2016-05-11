using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework.Data;

namespace Homework.Utilities
{
    public static class UtilityFunctions
    {
        /// <summary>
        /// Writes the instruction set to the console for the user. (No Unit Test)
        /// </summary>
        public static void WriteInstructions()
        {
            Console.WriteLine("Instructions: ");
            Console.WriteLine("   Enter: 1 for a list sorted by Gender amd Last Name.");
            Console.WriteLine("   Enter: 2 for a list sorted by Birth Date.");
            Console.WriteLine("   Enter: 3 for a list sorted by Last Name (Descending).");
            Console.WriteLine("   Enter: X to exit the program.");
        }
        /// <summary>
        /// Outputs the input sorted list to the console (No Unit Test)
        /// Clears the screen.
        /// Writes the input sorted list to the console
        /// and then rewrites the instructions.
        /// </summary>
        /// <param name="sortedList"></param>
        public static void OutputListToConsole(IEnumerable<Person> sortedList, string title)
        {
            Console.Clear();
            Console.WriteLine(CenteredBufferedString(title, 118));
            Console.WriteLine("");
            Console.WriteLine(header);
            foreach (Person person in sortedList)
            {
                Console.WriteLine(BufferedString(person.FirstName, 22) + "|" +
                    BufferedString(person.LastName, 22) + "|" +
                    BufferedString(person.Gender, 18) + "|" +
                    BufferedString(person.FavoriteColor, 27) + "|" +
                    BufferedString(person.DateOfBirth.ToString("MM/dd/yyyy"), 17));
            }
            WriteInstructions();
        }
        //
        // Notes on the settings for an attractive layout of the results:
        //                              1         2 2          1         2 2          1       1          1         2      2          1      1
        //                     1234567890123456789012|1234567890123456789012|123456789012345678|123456789012345678901234567|12345678901234567
        const string header = "      First Name      |      Last Name       |      Gender      |           Color           |  Date of Birth  ";
        //                     12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
        const string buffer = "                                                                                                              ";
        /// <summary>
        /// Outputs a string of the input length buffering the string with spaces.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string BufferedString(string value, int length)
        {
            string output = " " + value + buffer;
            while (output.Length < length)
            {
                output += buffer;
            }
            return (" " + value + buffer).Substring(0, length);
        }
        /// <summary>
        /// Output a buffer that is centered around 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string CenteredBufferedString(string value, int length)
        {
            int valueLength = value.Length;
            int start = (length - valueLength) / 2;
            string b2 = buffer;
            if (start > buffer.Length)
            {
                while (b2.Length < start)
                {
                    b2 += buffer;
                }
            }
            return b2.Substring(0, start) + value;
        }
    }
}
