using System;
using Mbeat;
using Mbeat.Entities;
using Mbeat.Enumerations;
using System.Collections.Generic;

namespace Test
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            try 
            {
                var authParams = new AuthParams(
                    OAuthGrantType.ClientCredentials,
                    new List<Scope> { Scope.BmbyhoodWriteScope },
                    "bmbyhood@mbeatapi.bmby.com",
                    "WIuyce0Iqt4YvVSvIhRNGMxYXVWAudrVd7rpQpO4"
                );

                var bmbyClient = new MbeatClient(authParams);
                var result = bmbyClient.Bmbyhood.AddToContract(new BrokerageContractData { OwnerId = 3407038, ClientId = 17608152, ProjectId = 4717 });

            }
            catch (Exception ex)
            {

            }

        }
    }
}
