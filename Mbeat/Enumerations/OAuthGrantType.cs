using System;
namespace Mbeat.Enumerations
{
    public sealed class OAuthGrantType
    {

        private readonly string _value;

        private OAuthGrantType(string value)
        {
            _value = value;
        }

        public static readonly OAuthGrantType ClientCredentials = new OAuthGrantType("client_credentials");
        public static readonly OAuthGrantType RefreshToken = new OAuthGrantType("refresh_token");
        public static readonly OAuthGrantType Password = new OAuthGrantType("password");

        public override string ToString()
        {
            return _value;
        }
    }
}
