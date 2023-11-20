using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;
using static System.Net.Mime.MediaTypeNames;
using RestSharp.Authenticators;
using System.Net;
using NUnit.Framework;
using Newtonsoft.Json;
using TestProject.Model.RestAPIModel;
using System;
using TechTalk.SpecFlow.CommonModels;

namespace TestProject.StepDefinitions.RestApi
{
    [Binding]
    public sealed class RestAPI
    {
        private IWebDriver driver;
        private RestClient _restClient;
        public SingleUserAPI RestApi;
        public RestResponse response;
        public HttpStatusCode statusCode;
        public RestAPI(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"I send a GET request for single user ""([^""]*)""")]
        public async void GivenISendAGETRequestForSingleUser(string id)
        {
            Console.WriteLine("Hi");
            var options = new RestClientOptions("https://reqres.in/");
            _restClient = new RestClient(options);
            var request = new RestRequest("https://reqres.in/api/users/" + id);
            response=_restClient.ExecuteGet(request);
            
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int p0)
        {
            statusCode = response.StatusCode;
            var code = (int) statusCode;
            Assert.AreEqual(200, code);
        }

        [Then(@"the response for last_name contain ""([^""]*)""")]
        public void ThenTheResponseForContain(string text)
        {
            var content = HandleContent.GetHandle<SingleUserAPI>(response);
            Assert.AreEqual(text, content.data.last_name.ToString());
        }


    }
}
