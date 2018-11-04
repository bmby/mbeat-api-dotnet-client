using System;
using Mbeat.Entities;
using RestSharp;

namespace Mbeat.Rest
{
    public class CrmTasksRest : MbeatRest
    {
        public CrmTasksRest(string endPoint, AuthParams authParams) : base(endPoint, authParams)
        {
        }

        public IRestResponse CreateCrmTask(CrmTask crmTask)
        {
            return Post("/crm", crmTask);
        }

        public IRestResponse UpdateCrmTask(CrmTask crmTask)
        {
            return Put("/crm", crmTask);
        }

        public IRestResponse DeleteCrmTask(int crmTaskId)
        {
            return Delete("/crm/" + crmTaskId);
        }
    }
}
