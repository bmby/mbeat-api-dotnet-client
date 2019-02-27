using System;
using System.Collections.Generic;
using Mbeat.Entities;
using RestSharp;

namespace Mbeat.Rest.Interface
{
    public interface IWishListRestResponse : IRestResponse
    {
        ICollection<WhishListItem> WishList { get; }
    }
}
