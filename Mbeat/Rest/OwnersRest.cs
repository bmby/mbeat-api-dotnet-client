using System;
using Mbeat.Entities;
using RestSharp;

namespace Mbeat.Rest
{
    public class OwnersRest : MbeatRest
    {
        public OwnersRest(string endPoint, AuthParams authParams) : base(endPoint, authParams)
        {
        }

        public IRestResponse CreateOwner(Owner owner)
        {
            return Post("/owners", owner);
        }

        public IRestResponse UpdateOwner(Owner owner)
        {
            return Put("/owners", owner);
        }

        public IRestResponse DeleteOwner(int ownerId)
        {
            return Delete("/owners/" + ownerId);
        }
    }
}