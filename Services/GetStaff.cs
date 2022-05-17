using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//these we had to include
using iSchoolWebApp.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace iSchoolWebApp.Services
{
    public class GetStaff
    {
        public async Task<List<Staff>> getAllStaff()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("people/staff", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    //different/new code here...
                    //make json out of data (we have a big ass string here)
                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<String, List<Staff>>>(data);


                    //now that i have the dictionary of 'faculty':List<Faculty>
                    //go thru this object and get it out using key value pairs

                    //first create a list to put it into
                    List<Staff> staffList = new List<Staff>();

                    //iterate through the data in rtnResults
                    foreach (KeyValuePair<String, List<Staff>> kvp in rtnResults)
                    {
                        //goes through once in this loop
                        //peeling off 'faculty' in front of the data

                        //need another foreach 
                        //this is getting each individual faculty member
                        foreach (var item in kvp.Value)
                        {
                            staffList.Add(item);

                            Console.WriteLine(item.username);
                            //lets go see some data
                        }
                    }

                    return staffList;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Staff> staffList = new List<Staff>();
                    return staffList;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Staff> staffList = new List<Staff>();
                    return staffList;
                }

            }
        }
    }
}
