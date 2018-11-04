using System;
using Mbeat.Entities;
using RestSharp;
using Newtonsoft.Json;
using System.Net;
using Mbeat.Enumerations;

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
                request.AddParameter("application/x-www-form-urlencoded", $"client_id={_authParams.ClientId}&client_secret={_authParams.ClientSecret}&grant_type={OAuthGrantType.ClientCredentials}", ParameterType.RequestBody);
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

        private IRestResponse Request(string method, string uri, Entity entity)
        {
            var restRequest = new RestRequest(method)
            {
                Resource = uri
            };

            restRequest.AddHeader("content-type", "application/json");
            restRequest.AddHeader("Authorization", "Bearer " + _accessToken);

            if (entity != null)
            {
                restRequest.AddParameter("application/json", JsonConvert.SerializeObject(entity), ParameterType.RequestBody);
            }

            IRestResponse response = _restClient.Execute(restRequest);

            return response;
        }

        protected IRestResponse Post(string uri, Entity entity)
        {
            return Request("POST", uri, entity);
        }

        protected IRestResponse Put(string uri, Entity entity)
        {
            return Request("PUT", uri, entity);
        }

        protected IRestResponse Delete(string uri)
        {
            return Request("DELETE", uri, null);
        }

        public MbeatRest(string endPoint, AuthParams authParams)
        {
            _restClient = new RestClient(endPoint);
            _authParams = authParams;
        }
    }
}
