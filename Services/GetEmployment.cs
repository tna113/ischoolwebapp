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
    public class GetEmployment
    {
        public async Task<EmploymentRootModel> getAllEmployment()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //iterate through array and put each inside empRoot to return
                //string[] url = {"introduction/","degreeStatistics/","employers/","careers/","coopTable/","employmentTable/"};
                //int count = 0;

                try {
                    EmploymentRootModel empRoot = new EmploymentRootModel();

                    //LATER: use foreach(var item in url iterate through instead of packing one at a time
                    
                    //get introduction
                    HttpResponseMessage response = await client.GetAsync("employment/", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var rtnResult = await response.Content.ReadAsStringAsync();
                    var resultIntro = JsonConvert.DeserializeObject<Dictionary<String, List<Introduction>>>(introData);
                    foreach(KeyValuePair<String, List<Introduction>> kvp in resultIntro) { }

                    return empRoot;

                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    EmploymentRootModel empRootModel = new EmploymentRootModel();
                    return empRootModel;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    EmploymentRootModel empRootModel = new EmploymentRootModel();
                    return empRootModel;
                }
            }
        }
    }
}
