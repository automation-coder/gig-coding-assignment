using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigCodingAssignment.com.gig.assignment.util
{
    class RestActions
    {
        private static RestClient client = null;
        private static RestRequest request;
        private static IRestResponse response = new RestResponse();
        
        public static void Initialize(String baseUrl)
        {
            if (client == null)
            {
                client = new RestClient(baseUrl);
            }
        }

        public static IRestResponse Post(string endpoint, Object requestObj)
        {
            request = new RestRequest(endpoint, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(JsonActions.GetJsonStringFromObject(requestObj));
            return Execute(request);
        }

        public static IRestResponse Get(string endpoint)
        {
            request = new RestRequest(endpoint, Method.GET);
            return Execute(request);
        }

        private static IRestResponse Execute(RestRequest request)
        {
            try
            {
                response = client.Execute(request);
            }
            catch(Exception exception)
            {
                //Adding the Exception details to the response
                response.ErrorException = exception;
                response.ErrorMessage = exception.Message;
            }
            return response;
        }
    }
}
