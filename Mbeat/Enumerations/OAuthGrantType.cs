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

        public const string CLIENT_CREDENTIALS = "client_credentials";
        public const string REFRESH_TOKEN = "refresh_token";
        public const string PASSWORD = "password";

        public static readonly OAuthGrantType ClientCredentials = new OAuthGrantType(CLIENT_CREDENTIALS);
        public static readonly OAuthGrantType RefreshToken = new OAuthGrantType(REFRESH_TOKEN);
        public static readonly OAuthGrantType Password = new OAuthGrantType(PASSWORD);

        public override string ToString()
        {
            return _value;
        }
    }
}
