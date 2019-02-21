using System;
using System.Collections.Generic;
using Mbeat.Enumerations;

namespace Mbeat
{
    public class AuthParams
    {
        public AuthParams
        (
            OAuthGrantType grantType, 
            ICollection<Scope> scopes, 
            string clientId, 
            string clientSecret = "", 
            string username = "", 
            string password = ""
        )
        {
            GrantType = grantType;
            Scopes = scopes;
            ClientId = clientId;
            ClientSecret = clientSecret;
            Username = username;
            Password = password;
        }

        public OAuthGrantType GrantType { get; }

        public ICollection<Scope> Scopes { get; }

        public string ClientId { get; }

        public string ClientSecret { get; }

        public string Username { get; }

        public string Password { get; }
    }
}
