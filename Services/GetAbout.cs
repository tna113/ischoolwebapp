using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using iSchoolWebApp.Models;

namespace iSchoolWebApp.Services
{
    public class GetAbout
    {
        public async Task<About> getAb()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                try 
                {
                    HttpResponseMessage response = new HttpResponseMessage();
                    response = await client.GetAsync(
                        "about/",HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    //turn it into JSON and cast into <About>
                    var rtnResults = JsonConvert.DeserializeObject<About>(data);
                    //don't need - it is already an About object...
                    //since there is only one About
                    //About abt = new About();
                    //abt = rtnResults;
                    return rtnResults;

                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    About ab = new About();
                    return ab;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    About ab = new About();
                    return ab;
                }


            }
            
        }
    }
}
// for GetFaculty - just didn't want to waste time re-writing it.
/*
  			
  
 */