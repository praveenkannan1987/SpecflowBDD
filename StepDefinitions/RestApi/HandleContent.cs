using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.StepDefinitions.RestApi
{
    public class HandleContent
    {
        public static T GetHandle<T>(RestResponse response) 
        { 
            var content = response.Content;
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
