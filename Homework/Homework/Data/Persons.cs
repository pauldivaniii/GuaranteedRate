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

        public Boolean ReadFile(string filePath, out string errorMessage)
        {
            errorMessage = "";
            if (File.Exists(filePath))
            {
                StreamReader file = null;
                try
                {
                    string line;
                    file = new StreamReader(filePath);
                    while ((line = file.ReadLine()) != null)
                    {
                        ListOfPersons.Add(new Person(line));
                    }
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                    return false;
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
                errorMessage = "The input file: " + filePath + ", does not exist";
                return false;
            }
        }

        public IEnumerable<Person> OutputByGenderLastName()
        {
            return from person in ListOfPersons
            orderby person.Gender ascending, person.LastName ascending select person;        
        }

        public IEnumerable<Person> OutputByGender()
        {
            return from person in ListOfPersons
                   orderby person.Gender ascending
                   select person;
        }

        public IEnumerable<Person> OutputByBirthDate()
        {
            return from person in ListOfPersons
            orderby person.DateOfBirth ascending
            select person;
        }

        public IEnumerable<Person> OutputByLastNameDescending()
        {
            return from person in ListOfPersons
            orderby person.LastName descending
            select person;
        }

        public IEnumerable<Person> OutputByName()
        {
            return from person in ListOfPersons
                   orderby person.LastName, person.FirstName
                   select person;
        }
    }
}
