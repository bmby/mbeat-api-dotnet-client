using System;
using System.Collections.Generic;
using Mbeat.Enumerations;

namespace Mbeat
{
    public class AuthParams
    {
        public const string UsersReadScope = "mbeatAPI.users.read";
        public const string UsersWriteScope = "mbeatAPI.users.write";
        public const string ClientsReadScope = "mbeatAPI.clients.read";
        public const string ClientsWriteScope = "mbeatAPI.clients.write";
        public const string OwnersReadScope = "mbeatAPI.owners.read";
        public const string OwnersWriteScope = "mbeatAPI.owners.write";
        public const string CrmReadScope = "mbeatAPI.crm.read";
        public const string CrmWriteScope = "mbeatAPI.crm.write";

        public AuthParams
        (
            OAuthGrantType grantType, 
            ICollection<string> scopes, 
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

        public ICollection<string> Scopes { get; }

        public string ClientId { get; }

        public string ClientSecret { get; }

        public string Username { get; }

        public string Password { get; }
    }
}
