using RestSharp;
using Mbeat.Entities;

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
            return Post("/bmbyhood/sendsms", message);
        }

        public IRestResponse AddToContract(BrokerageContractData contractData)
        {
            return Post("/bmbyhood/addpropertytoagreement", contractData);
        }

        public IRestResponse SetClientReaction(ClientReactionOnProperty reaction)
        {
            return Post("/bmbyhood/setclientreaction", reaction);
        }

        public IRestResponse SetUserPassword(BmbyhoodUserPassword userPassword)
        {
            return Post("/bmbyhood/user-password-hash", userPassword);
        }

        public IRestResponse SetUser2FaEnabled(BmbyhoodUser2FaEnabled user2FaEnabled)
        {
            return Post("/bmbyhood/user-2fa-enabled", user2FaEnabled);
        }
    }
}
