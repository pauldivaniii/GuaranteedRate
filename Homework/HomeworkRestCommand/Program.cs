using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Homework.Data;
using Homework.Utilities;

namespace HomeworkRestCommand
{
    class Program
    {
        static IEnumerable<Person> outputList;

        static void Main(string[] args)
        {
            UtilityFunctions.WriteRestInstructions();
            while (1 == 1)
            {
                var input = Console.ReadKey();
                switch (input.KeyChar)
                {
                    case 'X':
                    case 'x':
                        return;
                    case '1':
                        GetRestPersonList("GetProductsByGender", "List Sorted By Gender and Last Name");
                        break;
                    case '2':
                        GetRestPersonList("GetProductsByBirthDate", "List Sorted By Gender and Last Name");
                        break;
                    case '3':
                        GetRestPersonList("GetProductsByName", "List Sorted By Gender and Last Name");
                        break;
                    case '4':
                        Put();
                        break;
                }
            }
        }
        public static async void GetRestPersonList(string apiCall, string title)
        {
            await RunApiGetCall(apiCall);

            if (outputList != null)
            {
                int count = 0;
                foreach (var item in outputList)
                {
                    count++;
                }
                UtilityFunctions.OutputListToConsole(outputList, title, UtilityFunctions.WriteRestInstructions);

                if (12 != count) Console.WriteLine(string.Format("The number of expected records: \"{0}\" does not match: \"{1}\"", "12", count.ToString()));
            }
            else
            {
                Console.WriteLine("GetProductsByBirthDate failed");
            }
        }

        private static async Task RunApiGetCall(string getApi)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:6028/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // New code:
                    string apiCall = "api/persons/" + getApi;
                    var response = await client.GetAsync(apiCall);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        outputList = JsonConvert.DeserializeObject<IEnumerable<Person>>(content);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write("REST Service Exception Occurred: " + ex.Message);
                outputList = null;
            }
        }

        private static void Put()
        {
            try
            {
                var person = new Person("Anthony|White|Male|Chartreuse|7/2/2012");
                var json = JsonConvert.SerializeObject(person);
                System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

                client.BaseAddress = new System.Uri("http://localhost:6028/api/persons/postperson");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                System.Net.Http.HttpContent content = new StringContent(json, UTF8Encoding.UTF8, "application/json");
                HttpResponseMessage messge = client.PostAsync("http://localhost:6028/api/persons/postperson", content).Result;
                if (messge.IsSuccessStatusCode)
                {
                    string result = messge.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("");
                    Console.WriteLine("The person was successfully added: " + (result.Length > 0 ? result : "No information was provided."));
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("REST Service Error Occurred: " + messge.ReasonPhrase);
                    outputList = null;
                }
            }
            catch (Exception ex)
            {
                Console.Write("REST Service Exception Occurred: " + ex.Message);
                outputList = null;
            }
        }
    }
}
