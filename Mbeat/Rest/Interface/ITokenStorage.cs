using System;
namespace Mbeat.Rest.Interface
{
    public interface ITokenStorage
    {
        void StoreRefreshToken(string token);
        string GetRefreshToken();
    }
}
