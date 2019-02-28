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

        public IRestResponse AddToWishList(AddToWishListItem item)
        {
            return Post("/dreams/add-to-wish-list", item);
        }

        public IRestResponse EmailWishList(DreamsEntity clientId)
        {
            return Post("/dreams/email-wish-list", clientId);
        }

        public IRestResponse AddToLog(DreamsActionLog actionLog)
        {
            return Post("/dreams/add-to-log", actionLog);
        }

        public IRestResponse RemoveFromWishList(WishListRemoveParams removeParams)
        {
            return Delete("/dreams/remove-from-wish-list", removeParams);
        }

        public IWishListRestResponse GetWishList(WishListParams queryParams)
        {
            var response = Get("/dreams/wish-list", queryParams);

            return new WishListResponse(response);
        }
    }
}