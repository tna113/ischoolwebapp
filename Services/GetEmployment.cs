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
                    //get introduction
                    HttpResponseMessage response = await client.GetAsync("employment/", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    var rtnResult = JsonConvert.DeserializeObject<EmploymentRootModel>(data);
                    return rtnResult;

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
