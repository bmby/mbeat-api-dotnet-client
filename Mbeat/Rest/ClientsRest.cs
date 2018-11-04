using System;
using Mbeat.Entities;
using RestSharp;

namespace Mbeat.Rest
{
    public class ClientsRest : MbeatRest
    {
        public ClientsRest(string endPoint, AuthParams authParams) : base(endPoint, authParams)
        {
        }

        public IRestResponse CreateClient(Client client)
        {
            return Post("/clients", client);
        }

        public IRestResponse UpdateClient(Client client)
        {
            return Put("/clients", client);
        }

        public IRestResponse DeleteClient(int clientId)
        {
            return Delete("/clients/" + clientId);
        }
    }
}
