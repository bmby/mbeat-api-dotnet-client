using System;
using Mbeat.Entities;
using RestSharp;

namespace Mbeat.Rest
{
    public class BmbyhoodRest : MbeatRest
    {
        public BmbyhoodRest(string baseUrl, AuthParams authParams) : base(baseUrl, authParams)
        {
        }

        public IRestResponse SendEmail(BmbyhoodEmailMessage message)
        {
            return Post("/bmbyhood/sendemail", message);
        }

        public IRestResponse SendSms(BmbyhoodSmsMessage message)
        {
            return Post("/bmbyhood/sendesms", message);
        }
    }
}
