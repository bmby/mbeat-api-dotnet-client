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
                    "",
                    ""
                );

            }
            catch (Exception ex)
            {

            }

        }
    }
}
