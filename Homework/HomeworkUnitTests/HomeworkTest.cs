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
    }
}
