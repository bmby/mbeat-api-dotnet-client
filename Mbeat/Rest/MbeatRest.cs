using System;
using RestSharp;
using System.Net;
using System.Linq;
using Mbeat.Entities;
using Newtonsoft.Json;
using Mbeat.QueryParams;
using Mbeat.Enumerations;
using System.Net.Security;
using Newtonsoft.Json.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace Mbeat.Rest
{
    public class MbeatRest
    {
        private readonly IRestClient _restClient;
        private readonly AuthParams _authParams;
        private readonly string _baseUrl;

        private const string TokenEndpoint = "https://identity.bmby.com/connect/token";
        private string _accessToken = string.Empty;
        private int _accessTokenExpiration = 0;

        private string GetAccessToken()
        {
            string token = string.Empty;

            switch(_authParams.GrantType.ToString())
            {
                case OAuthGrantType.CLIENT_CREDENTIALS:
                    token = GetAccessTokenForClientCridentials();
                    break;
                case OAuthGrantType.PASSWORD:
                    token = GetAccessTokenForResourceOwner();
                    break;
                case OAuthGrantType.REFRESH_TOKEN:
                    token = GetAccessTokenForRefreshToken();
                    break;
            }

            return token;
        }

        private string GetAccessTokenForClientCridentials()
        {
            int timestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            if (_accessToken == string.Empty || timestamp - 60 > _accessTokenExpiration)
            {
                var client = CreateRestClient(TokenEndpoint);
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

        private string GetAccessTokenForResourceOwner()
        {
            int timestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            if (_accessToken != string.Empty && timestamp - 60 < _accessTokenExpiration)
            {
                return _accessToken;
            }

            string refreshToken = _authParams.Storage != null ? _authParams.Storage.GetRefreshToken() : string.Empty;

            if (!string.IsNullOrEmpty(refreshToken))
            {
                return GetAccessTokenForRefreshToken(refreshToken);
            }

            var client = CreateRestClient(TokenEndpoint);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");

            string data = string.Empty;
            data += $"client_id={_authParams.ClientId}";
            data += $"&client_secret={_authParams.ClientSecret}";
            data += $"&grant_type={OAuthGrantType.Password}";
            data += $"&username={_authParams.Username}";
            data += $"&password={_authParams.Password}";
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

            if (_authParams.Storage != null && !string.IsNullOrEmpty(tokenResponse.RefreshToken))
            {
                _authParams.Storage.StoreRefreshToken(tokenResponse.RefreshToken);
            }

            return _accessToken;
        }

        string GetAccessTokenForRefreshToken(string existingRefreshToken = "")
        {
            int timestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            if (_accessToken != string.Empty && timestamp - 60 < _accessTokenExpiration)
            {
                return _accessToken;
            }

            string refreshToken = !string.IsNullOrEmpty(existingRefreshToken) ? existingRefreshToken :
                                         (_authParams.Storage != null ? _authParams.Storage.GetRefreshToken() : string.Empty);

            if (string.IsNullOrEmpty(refreshToken))
            {
                _accessToken = "";
                _accessTokenExpiration = 0;

                return _accessToken;
            }

            var client = CreateRestClient(TokenEndpoint);
            var request = new RestRequest(Method.POST);

            string data = string.Empty;
            data += $"client_id={_authParams.ClientId}";
            data += $"&client_secret={_authParams.ClientSecret}";
            data += $"&refresh_token={_authParams.ClientSecret}";
            data += $"&grant_type={OAuthGrantType.RefreshToken}";
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

        protected IRestResponse Get(string uri, Params queryParams)
        {
            string url = uri + (queryParams != null ? "?" + queryParams.QueryString : "");

            return Request(Method.GET, url, null);
        }

        protected IRestResponse Get(string uri)
        {
            return Get(uri, null);
        }

        protected IRestResponse Post(string uri, Entity entity)
        {
            return Request(Method.POST, uri, entity);
        }

        protected IRestResponse Put(string uri, Entity entity)
        {
            return Request(Method.PUT, uri, entity);
        }

        protected IRestResponse Delete(string uri, Params queryParams)
        {
            string url = uri + (queryParams != null ? "?" + queryParams.QueryString : "");

            return Request(Method.DELETE, url, null);
        }

        protected IRestResponse Delete(string uri)
        {
            return Delete(uri, null);
        }

        public MbeatRest(string baseUrl, AuthParams authParams)
        {
            _baseUrl = baseUrl;
            _restClient = CreateRestClient(_baseUrl);
            _authParams = authParams;
        }

        private IRestClient CreateRestClient(string baseUrl)
        {
            IRestClient restClient = new RestClient(baseUrl);
            restClient.RemoteCertificateValidationCallback += (message, cert, chain, sslPolicyErrors) =>
            {
                var certificate = cert as X509Certificate2;
                var request = message as HttpWebRequest;
                string mbeatApiEndpoint = $"{_baseUrl.TrimEnd('/')}/";
                if (request != null && certificate != null &&
                    request.RequestUri.AbsoluteUri.Contains(mbeatApiEndpoint) &&
                    sslPolicyErrors == SslPolicyErrors.RemoteCertificateNameMismatch)
                {
                    string commonName = certificate.GetNameInfo(X509NameType.SimpleName, false);
                    if (commonName == "*.bmby.com")
                    {
                        return true;
                    }
                }

                return sslPolicyErrors == SslPolicyErrors.None;
            };

            return restClient;
        }
    }
}
