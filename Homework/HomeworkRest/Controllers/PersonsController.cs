using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Homework.Data;

namespace HomeworkRest.Controllers
{
    public class PersonsController : ApiController
    {
        Persons persons = new Persons();

        public PersonsController()
        {
            persons.ListOfPersons.Add(new Person("John", "Brown", "Male", "Blue", "01/23/1967"));
            persons.ListOfPersons.Add(new Person("James", "Smith", "Male", "Red", "3/8/2010"));
            persons.ListOfPersons.Add(new Person("John", "Johnson", "Male", "Orange", "12/17/1979"));
            persons.ListOfPersons.Add(new Person("Robert", "Williams", "Male", "Yellow", "4/13/1979"));
            persons.ListOfPersons.Add(new Person("Michael", "Jones", "Male", "Green", "5/19/1968"));
            persons.ListOfPersons.Add(new Person("Elizabeth", "Hernandez", "Female", "Electric_ultramarine", "12/14/1976"));
            persons.ListOfPersons.Add(new Person("Linda", "King", "Female", "Electric_violet", "10/24/1979"));
            persons.ListOfPersons.Add(new Person("Barbara", "Wright", "Female", "Electric_yellow", "2/26/2003"));
            persons.ListOfPersons.Add(new Person("Susan", "Lopez", "Female", "Emerald", "9/13/1980"));
            persons.ListOfPersons.Add(new Person("Jessica", "Hill", "Female", "Eton_blue", "10/3/1943"));
            persons.ListOfPersons.Add(new Person("Margaret", "Scott", "Female", "Fallow", "6/25/1966"));
            persons.ListOfPersons.Add(new Person("Sarah", "Green", "Female", "Falu_red", "10/3/1968"));
        }

        public HttpResponseMessage PostPerson(Person person)
        {
            try
            {
                persons.ListOfPersons.Add(person);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public HttpResponseMessage SavePerson()
        {
            try
            {
                //persons.ListOfPersons.Add(new Person(person));
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public IEnumerable<Person> GetProductsByGender()
        {
            return persons.OutputByGender();
        }

        public IEnumerable<Person> GetProductsByBirthDate()
        {
            return persons.OutputByBirthDate();
        }

        public IEnumerable<Person> GetProductsByName()
        {
            return persons.OutputByName();
        }
    }
}
