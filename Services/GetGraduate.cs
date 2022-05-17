using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//adding this
using iSchoolWebApp.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace iSchoolWebApp.Services
{
    public class GetGraduate
    {
        public async Task<List<Graduate>> getAllGraduate()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("degrees/graduate", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    //different/new code here...
                    //make json out of data (we have a big ass string here)
                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<String, List<Graduate>>>(data);


                    //now that i have the dictionary of 'undergraduate':List<Undergraduate>
                    //go thru this object and get it out using key value pairs

                    //first create a list to put it into
                    List<Graduate> gradList = new List<Graduate>();

                    //iterate through the data in rtnResults
                    foreach (KeyValuePair<String, List<Graduate>> kvp in rtnResults)
                    {
                        //goes through once in this loop
                        //peeling off 'undergraduate' in front of the data

                        //need another foreach 
                        //this is getting each individual undergraduate member
                        foreach (var item in kvp.Value)
                        {
                            gradList.Add(item);
                            //lets go see some data
                            Console.WriteLine(item.degreeName);
                        }
                    }

                    return gradList;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Graduate> gradList = new List<Graduate>();
                    return gradList;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Graduate> gradList = new List<Graduate>();
                    return gradList;
                    //return "Exception"; ;
                }
            }
        }
    }
}
