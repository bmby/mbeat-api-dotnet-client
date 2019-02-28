using System;
namespace Mbeat.QueryParams
{
    public class WishListRemoveParams : Params
    {
        public int? BmbyClientId { get; set; }
        public int PropertyId { get; set; }
    }
}
