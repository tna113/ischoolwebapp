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
    public class GetCourse
    {
        public async Task<List<Course>> getAllCourse()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try {
                    HttpResponseMessage response = await client.GetAsync("course/", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    //what's returned is an array of objects in a BIG STRING
                    var rtnResults = JsonConvert.DeserializeObject<List<Course>>(data);

                    List<Course> courseList = rtnResults;


                    return courseList;
                }

                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Course> courseList = new List<Course>();
                    return courseList;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Course> courseList = new List<Course>();
                    return courseList;
                    //return "Exception"; ;
                }
            }
        }
    }
}
