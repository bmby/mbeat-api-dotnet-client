using System;
using Mbeat.Entities;
using Mbeat.QueryParams;
using Mbeat.Rest.Interface;
using Mbeat.Rest.Response;
using RestSharp;

namespace Mbeat.Rest
{
    public class DreamsRest : MbeatRest
    {
        public DreamsRest(string baseUrl, AuthParams authParams) : base(baseUrl, authParams)
        {
        }

        public IRestResponse RegisterApp(DreamsRegistrationParams regParams)
        {
            return Post("/dreams/register-app", regParams);
        }

        public IRestResponse AddToWishList(DreamsRegistrationParams regParams)
        {
            return Post("/dreams/add-to-wish-list", regParams);
        }

        public IRestResponse EmailWishList(DreamsRegistrationParams regParams)
        {
            return Post("/dreams/email-wish-list", regParams);
        }

        public IRestResponse AddToLog(DreamsRegistrationParams regParams)
        {
            return Post("/dreams/add-to-log", regParams);
        }

        public IRestResponse RemoveFromWishList(DreamsRegistrationParams regParams)
        {
            return Post("/dreams/remove-from-wish-list", regParams);
        }

        public IWishListRestResponse WishList(WishListParams queryParams)
        {
            var response = Get("/dreams/wish-list", queryParams);

            return new WishListResponse(response);
        }

        public IRestResponse Paid(DreamsRegistrationParams regParams)
        {
            return Post("/dreams/paid", regParams);
        }

        public IRestResponse NextPayment(WishListParams regParams)
        {
            return Get("/dreams/next-payment", regParams);
        }

    }
}