using System;
using Mbeat.Entities;
using RestSharp;
using Newtonsoft.Json;
using System.Net;
using Mbeat.Enumerations;
using System.Linq;
using Newtonsoft.Json.Serialization;

namespace Mbeat.Rest
{
    public class MbeatRest
    {
        private readonly IRestClient _restClient;
        private readonly AuthParams _authParams;

        private const string TokenEndpoint = "https://identity.bmby.com/connect/token";
        private string _accessToken = string.Empty;
        private int _accessTokenExpiration = 0;

        private string GetAccessToken()
        {
            int timestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            if (_accessToken == string.Empty || timestamp - 60 > _accessTokenExpiration)
            {
                var client = new RestClient(TokenEndpoint);
                var request = new RestRequest(Method.POST);
                request.AddHeader("content-type", "application/x-www-form-urlencoded");

                string data = string.Empty;
                data += $"client_id={_authParams.ClientId}";
                data += $"&client_secret={_authParams.ClientSecret}";
                data += $"&grant_type={OAuthGrantType.ClientCredentials}";
                data += $"&scope={string.Join(" ", _authParams.Scopes)}";

                request.AddParameter("application/x-www-form-urlencoded", data, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw response.ErrorException;
                }

                var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(response.Content);

                _accessToken = tokenResponse.AccessToken;
                _accessTokenExpiration = timestamp + tokenResponse.ExpiresIn;
            }

            return _accessToken;
        }

        private IRestResponse Request(Method method, string uri, Entity entity)
        {
            var restRequest = new RestRequest(method)
            {
                Resource = uri
            };

            restRequest.AddHeader("content-type", "application/json");
            restRequest.AddHeader("Authorization", "Bearer " + GetAccessToken());

            if (entity != null)
            {
                restRequest.AddParameter("application/json", 
                                         JsonConvert.SerializeObject(entity, new JsonSerializerSettings
                                         {
                                             ContractResolver = new CamelCasePropertyNamesContractResolver()
                                         }), 
                                         ParameterType.RequestBody);
            }

            IRestResponse response = _restClient.Execute(restRequest);

            return response;
        }

        protected IRestResponse Post(string uri, Entity entity)
        {
            return Request(Method.POST, uri, entity);
        }

        protected IRestResponse Put(string uri, Entity entity)
        {
            return Request(Method.PUT, uri, entity);
        }

        protected IRestResponse Delete(string uri)
        {
            return Request(Method.DELETE, uri, null);
        }

        public MbeatRest(string baseUrl, AuthParams authParams)
        {
            _restClient = new RestClient(baseUrl);
            _authParams = authParams;
        }
    }
}
