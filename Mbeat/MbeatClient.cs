using System;
using System.Collections.Generic;
using Mbeat.Rest;

namespace Mbeat
{
    public class MbeatClient
    {
        private const string EndPoint = "https://mbeat.bmby.com/api";

        private ClientsRest _clients;
        private OwnersRest _owners;
        private CrmTasksRest _crmTasks;

        private readonly string _endPoint;
        private readonly AuthParams _authParams;

        public MbeatClient(AuthParams authParams) : this(EndPoint, authParams)
        {
        }

        public MbeatClient(string endPoint, AuthParams authParams)
        {
            if (string.IsNullOrEmpty(endPoint))
            {
                throw new Exception("endpoint argument is null or empty");
            }

            _endPoint = endPoint;
            _authParams = authParams;
        }

        public ClientsRest Clients
        {
            get
            {
                if (_clients == null)
                {
                    _clients = new ClientsRest(_endPoint, _authParams);
                }

                return _clients;
            }
        }

        public OwnersRest Owners
        {
            get
            {
                if (_owners == null)
                {
                    _owners = new OwnersRest(_endPoint, _authParams);
                }

                return _owners;
            }
        }

        public CrmTasksRest CrmTasks
        {
            get
            {
                if (_crmTasks == null)
                {
                    _crmTasks = new CrmTasksRest(_endPoint, _authParams);
                }

                return _crmTasks;
            }
        }
    }
}