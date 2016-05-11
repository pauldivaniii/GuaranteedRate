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
            //
            // Read in the 3 data files in the DataFiles folder
            //
            persons.ReadFile("DataFiles/PipeDelimitedData.txt");
            persons.ReadFile("DataFiles/CommaDelimitedData.txt");
            persons.ReadFile("DataFiles/SpaceDelimitedData.txt");

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
                        UtilityFunctions.OutputListToConsole(persons.OutputByGenderLastName(), "List Sorted By Gender and Last Name");
                        break;
                    case '2':
                        UtilityFunctions.OutputListToConsole(persons.OutputByBirthDate(), "List Sorted By Birth Date");
                        break;
                    case '3':
                        UtilityFunctions.OutputListToConsole(persons.OutputByLastName(), "List Sorted By Last Name Descending");
                        break;
                }
            }
        }
    }
}
