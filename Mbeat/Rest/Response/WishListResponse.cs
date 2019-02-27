using System;
using System.Collections.Generic;
using Mbeat.Entities;
using Mbeat.Rest.Interface;
using Newtonsoft.Json;
using RestSharp;

namespace Mbeat.Rest.Response
{
    public class WishListResponse : RestResponse, IWishListRestResponse
    {
        private readonly IRestResponse _restResponse;

        public WishListResponse(IRestResponse restResponse)
        {
            _restResponse = restResponse;
        }

        public ICollection<WhishListItem> WishList 
        { 
            get
            {
                return JsonConvert.DeserializeObject<ICollection<WhishListItem>>(_restResponse.Content);
            }
        }
    }
}
