using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework.Data;
using Homework.Utilities;

namespace Homework
{
    class Program
    {
        /// <summary>
        /// The main routine reads in the three input files  and then
        /// sits and reads a single command key from the keyboard, performing the
        /// action prescribed by that instruction.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Persons persons = new Persons();
            string errorMessage;
            //
            // Read in the 3 data files in the DataFiles folder
            //
            if (!persons.ReadFile("DataFiles/PipeDelimitedData.txt", out errorMessage))
            {
                Console.WriteLine(string.Format("An error occurred parsing file: \"{0}\": {1}", "DataFiles/PipeDelimitedData.txt", errorMessage));
            }
            if (!persons.ReadFile("DataFiles/CommaDelimitedData.txt", out errorMessage))
            {
                Console.WriteLine(string.Format("An error occurred parsing file: \"{0}\": {1}", "DataFiles/CommaDelimitedData.txt", errorMessage));
            }
            if (!persons.ReadFile("DataFiles/SpaceDelimitedData.txt", out errorMessage))
            {
                Console.WriteLine(string.Format("An error occurred parsing file: \"{0}\": {1}", "DataFiles/SpaceDelimitedData.txt", errorMessage));
            }

            UtilityFunctions.WriteInstructions();
            while (1 == 1)
            {
                var input = Console.ReadKey();
                switch(input.KeyChar)
                {
                    case 'X':
                    case 'x':
                        return;
                    case '1':
                        UtilityFunctions.OutputListToConsole(persons.OutputByGenderLastName(), "List Sorted By Gender and Last Name", UtilityFunctions.WriteInstructions);
                        break;
                    case '2':
                        UtilityFunctions.OutputListToConsole(persons.OutputByBirthDate(), "List Sorted By Birth Date", UtilityFunctions.WriteInstructions);
                        break;
                    case '3':
                        UtilityFunctions.OutputListToConsole(persons.OutputByLastNameDescending(), "List Sorted By Last Name Descending", UtilityFunctions.WriteInstructions);
                        break;
                }
            }
        }
    }
}
