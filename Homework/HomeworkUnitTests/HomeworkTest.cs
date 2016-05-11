using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework.Data;
using Homework.Utilities;

namespace HomeworkUnitTests
{
    [TestClass]
    public class HomeworkTest
    {
        [TestMethod]
        public void UtilitiesBufferedStringTest()
        {
            string output = UtilityFunctions.BufferedString("This is a test", 24);

            Assert.AreEqual(24, output.Length, "The length of the output string is equal to the desired length: 24");

            output = UtilityFunctions.BufferedString("This is a test", 10);

            Assert.AreEqual(10, output.Length, "The length of the output string is shorter but equal to the desired length: 10");
        }

        [TestMethod]
        public void UtilitiesCenteredBufferedStringTest()
        {
            string title = "This is a test title";
            int length = 118;
            int start = (length - title.Length) / 2;

            string output = UtilityFunctions.CenteredBufferedString(title, length);
            int firstNonBlank = output.IndexOf(title);

            Assert.AreEqual(start, firstNonBlank, "The string was not centered around a character width of 118");
        }        

        [TestMethod]
        public void PersonCreateTest()
        {
            var person = new Person("James|Smith|Male|Red|6/13/1945");

            Assert.AreEqual("James", person.FirstName, string.Format("The first names do not match: \"{0}\" and \"{1}\"", "James", person.FirstName));
            Assert.AreEqual("Smith", person.LastName, string.Format("The last names do not match: \"{0}\" and \"{1}\"", "Smith", person.LastName));
            Assert.AreEqual("Male", person.Gender, string.Format("The gender does not match: \"{0}\" and \"{1}\"", "Male", person.Gender));
            Assert.AreEqual("Red", person.FavoriteColor, string.Format("The favorite color does not match: \"{0}\" and \"{1}\"", "Red", person.FavoriteColor));
            Assert.AreEqual(DateTime.Parse("6/13/1945"), person.DateOfBirth, string.Format("The Date of Birth does not match: \"{0}\" and \"{1}\"", "6/13/1945", person.DateOfBirth.ToShortDateString()));
        }      

        [TestMethod]
        public void PersonsReadFileTest()
        {
            try
            {
                string errorMessage;
                var persons = new Persons();
                if (persons.ReadFile("./DataFiles/UnitTestSortingFile.txt", out errorMessage))
                {
                    Assert.AreEqual(6, persons.ListOfPersons.Count, string.Format("The number of expected records: \"{0}\" does not match: \"{1}\"", "6", persons.ListOfPersons.Count.ToString()));
                }
                else
                {
                    Assert.Fail("An unexpected exception occurred: " + errorMessage);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("An unexpected exception occurred: " + ex.Message);
            }
        }

        [TestMethod]
        public void PersonsReadNonExistentFileTest()
        {
            try
            {
                string errorMessage;
                var persons = new Persons();
                if (!persons.ReadFile("BadFileName.txt", out errorMessage))
                {
                    Assert.IsTrue(errorMessage.Contains("does not exist"), "ReadFile failed for a reason other than a bad file:" + errorMessage);
                }
                else
                {
                    Assert.Fail("PersonsReadNonExistentFileTest should have failed for a bad file path");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("An unexpected exception occurred: " + ex.Message);
            }
        }

        [TestMethod]
        public void PersonsReadBadDelimiterFileTest()
        {
            try
            {
                string errorMessage;
                var persons = new Persons();
                if (!persons.ReadFile("UnitTestDataWithDelimiterError.txt", out errorMessage))
                {
                    Assert.IsTrue(errorMessage.Contains("does not exist"), "ReadFile failed for a reason other than a bad file:" + errorMessage);
                }
                else
                {
                    Assert.Fail("PersonsReadBadDelimiterFileTest should have failed for a delimter test failure.");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("PersonsReadBadDelimiterFileTest: An unexpected exception occurred: " + ex.Message);
            }
        }

        [TestMethod]
        public void PersonsReadBadDateFileTest()
        {
            try
            {
                string errorMessage;
                var persons = new Persons();
                if (!persons.ReadFile("./DataFiles/UnitTestDataWithDateOfBirthError.txt", out errorMessage))
                {
                    Assert.IsTrue(errorMessage.Contains("number of tokens") || errorMessage.Contains("Invalid Date"), "ReadFile failed for a reason other than a bad file:" + errorMessage);
                }
                else
                {
                    Assert.Fail("PersonsReadBadDateFileTest should have failed for a delimter test failure.");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("PersonsReadBadDateFileTest: An unexpected exception occurred: " + ex.Message);
            }
        }

        [TestMethod]
        public void PersonsOutputByGenderLastNameTest()
        {
            try
            {
                string errorMessage;
                var persons = new Persons();
                if (persons.ReadFile("./DataFiles/UnitTestSortingFile.txt", out errorMessage))
                {
                    var output = persons.OutputByGenderLastName();
                    Person lastPerson = null;
                    foreach (var person in output)
                    {
                        if (lastPerson != null)
                        {
                            Boolean testValue = person.Gender.CompareTo(lastPerson.Gender) > 0 || person.LastName.CompareTo(lastPerson.LastName) > 0;
                            Assert.IsTrue(testValue, string.Format("PersonsOutputByGenderLastNameTest: previous last name: \"{0}\" is greater then current: \"{1}\"", lastPerson.LastName, person.LastName));
                        }
                        lastPerson = person;
                    }
                }
                else
                {
                    Assert.Fail("PersonsOutputByGenderLastNameTest failed: "  + errorMessage);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("PersonsOutputByGenderLastNameTest: An unexpected exception occurred: " + ex.Message);
            }
        }

        [TestMethod]
        public void PersonsOutputByBirthDateTest()
        {
            try
            {
                string errorMessage;
                var persons = new Persons();
                if (persons.ReadFile("./DataFiles/UnitTestSortingFile.txt", out errorMessage))
                {
                    var output = persons.OutputByBirthDate();
                    Person lastPerson = null;
                    foreach (var person in output)
                    {
                        if (lastPerson != null)
                        {
                            Assert.IsTrue(person.DateOfBirth.CompareTo(lastPerson.DateOfBirth) > 0, string.Format("PersonsOutputByBirthDateTest: previous date of birth: \"{0}\" is greater then current: \"{1}\"", lastPerson.DateOfBirth.ToShortDateString(), person.DateOfBirth.ToShortDateString()));
                        }
                        lastPerson = person;
                    }
                }
                else
                {
                    Assert.Fail("PersonsOutputByBirthDateTest failed: " + errorMessage);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("PersonsOutputByBirthDateTest: An unexpected exception occurred: " + ex.Message);
            }
        }

        [TestMethod]
        public void PersonsOutputByLastNameDescendingTest()
        {
            try
            {
                string errorMessage;
                var persons = new Persons();
                if (persons.ReadFile("./DataFiles/UnitTestSortingFile.txt", out errorMessage))
                {
                    var output = persons.OutputByLastNameDescending();
                    Person lastPerson = null;
                    foreach (var person in output)
                    {
                        if (lastPerson != null)
                        {
                            Assert.IsTrue(person.LastName.CompareTo(lastPerson.LastName) < 0, string.Format("PersonsOutputByLastNameDescendingTest: previous last name: \"{0}\" is greater then current: \"{1}\"", lastPerson.LastName, person.LastName));
                        }
                        lastPerson = person;
                    }
                }
                else
                {
                    Assert.Fail("PersonsOutputByLastNameDescendingTest failed: " + errorMessage);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("PersonsOutputByLastNameDescendingTest: An unexpected exception occurred: " + ex.Message);
            }
        }
    }
}
