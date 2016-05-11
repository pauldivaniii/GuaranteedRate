using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Data
{
    public class Persons
    {
        public Persons()
        {
            ListOfPersons = new List<Person>();
        }
 
        public List<Person> ListOfPersons;

        public Boolean ReadFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                StreamReader file = null;
                try
                {
                    string line;
                    file = new StreamReader(filePath);
                    while ((line = file.ReadLine()) != null)
                    {
                        try
                        {
                            ListOfPersons.Add(new Person(line));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error parsing input person line: " + ex.Message);
                        }
                    }
                }
                finally
                {
                    if (file != null)
                        file.Close();
                }
                return true;
            }
            else
            {
                Console.WriteLine("The input file: " + filePath + ", does not exist");
                return false;
            }
        }

        public IEnumerable<Person> OutputByGenderLastName()
        {
            return from person in ListOfPersons
            orderby person.Gender ascending, person.LastName ascending select person;        }

        public IEnumerable<Person> OutputByBirthDate()
        {
            return from person in ListOfPersons
            orderby person.DateOfBirth ascending
            select person;
        }

        public IEnumerable<Person> OutputByLastName()
        {
            return from person in ListOfPersons
            orderby person.LastName descending
            select person;
        }
    }
}
