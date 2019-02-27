using System;
using System.Collections.Generic;
using Mbeat.Enumerations;
using Mbeat.Rest.Interface;

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
            ITokenStorage storage = null,
            string username = "", 
            string password = ""
        )
        {
            if ((!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(password)) && storage == null)
            {
                throw new Exception("You must implemet storage for refresh token");
            }

            if ((!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(password)) && grantType != OAuthGrantType.Password)
            {
                throw new Exception("You are using wrong grant type, use password");
            }

            GrantType = grantType;
            Scopes = scopes;
            ClientId = clientId;
            ClientSecret = clientSecret;
            Username = username;
            Password = password;
            Storage = storage;
        }

        public OAuthGrantType GrantType { get; }

        public ICollection<Scope> Scopes { get; }

        public string ClientId { get; }

        public string ClientSecret { get; }

        public string Username { get; }

        public string Password { get; }

        public ITokenStorage Storage { get; }
    }
}
