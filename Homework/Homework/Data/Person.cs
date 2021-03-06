﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Homework.Data
{
    public class Person
    {
        [JsonConstructor]
        public Person(string FirstName, string LastName, string Gender, string FavoriteColor, string DateOfBirth)
        {
            DateTime dateOfBirthDate;
            if (!DateTime.TryParse(DateOfBirth, out dateOfBirthDate)){
                throw new Exception(string.Format("Invalid Date of Birth Entered: \"{0}\"", DateOfBirth));
            }
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Gender = Gender;
            this.FavoriteColor = FavoriteColor;
            this.DateOfBirth = dateOfBirthDate;
        }

        public Person(string inputLine)
        {
            string[] tokens = inputLine.Split(new char[] { '|', ',',' ' });
            if (tokens.Length != 5) {
                Console.WriteLine(string.Format("The number of tokens {0} needs to be 5. Input Line: \"{1}\"", tokens.Length.ToString(), inputLine));
                throw new Exception(string.Format("The number of tokens {0} needs to be 5. Input Line: \"{1}\"", tokens.Length.ToString(), inputLine));
            }
            DateTime dateOfBirth;
            if (!DateTime.TryParse(tokens[4], out dateOfBirth)){
                Console.WriteLine(string.Format("Invalid Date of Birth Entered: {0}. Input Line: \"{1}\"", tokens[4], inputLine));
                throw new Exception(string.Format("Invalid Date of Birth Entered: {0}.Input Line: \"{1}\"", tokens[4], inputLine));
            }
            FirstName = tokens[0];
            LastName = tokens[1];
            Gender = tokens[2];
            FavoriteColor = tokens[3];
            DateOfBirth = dateOfBirth;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Gender { get; private set; }
        public string FavoriteColor { get; private set; }
        public DateTime DateOfBirth { get; private set; }
    }
}
