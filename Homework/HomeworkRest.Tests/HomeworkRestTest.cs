using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Homework.Data;


namespace HomeworkRest.Tests
{
    [TestClass]
    public class HomeworkRestTest
    {
        const string webApiUrl = "http://localhost:6028/";
        IEnumerable<Person> outputList;

        [TestMethod]
        public void PutPersonTest()
        {

        }

        [TestMethod]
        public async void GetByBirthdayTest()
        {
            await RunApiGetCall("GetProductsByBirthDate");

            if (outputList != null)
            {
                int count = 0;
                foreach (var item in outputList){
                    count++;
                }

                Assert.AreEqual(12, count, string.Format("The number of expected records: \"{0}\" does not match: \"{1}\"", "12", count.ToString()));
            }
            else
            {
                Assert.Fail("GetProductsByBirthDate failed");
            }
        }

        private async Task RunApiGetCall(string getApi)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:6028/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync("api/persons/" + getApi);
                if (response.IsSuccessStatusCode)
                {
                    outputList = await response.Content.ReadAsAsync<IEnumerable<Person>>();
                }

            }
        }
    }
}
