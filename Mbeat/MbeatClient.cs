using System;
using System.Collections.Generic;
using Mbeat.Rest;

namespace Mbeat
{
    public class MbeatClient
    {
        private const string EndPoint = "https://mbeat.bmby.com/api";

        private ClientsRest _clients;
        private PropertiesRest _properties;
        private OwnersRest _owners;
        private CrmTasksRest _crmTasks;

        private readonly string _endPoint;

        public MbeatClient() : this(EndPoint)
        {
        }

        public MbeatClient(string endPoint)
        {
            if (string.IsNullOrEmpty(endPoint))
            {
                throw new Exception("endpoint argument is null or empty");
            }

            _endPoint = endPoint;
        }

        public ClientsRest Clients
        {
            get
            {
                if (_clients == null)
                {
                    _clients = new ClientsRest(_endPoint);
                }

                return _clients;
            }
        }

        public PropertiesRest Properties 
        {
            get
            {
                if (_properties == null)
                {
                    _properties = new PropertiesRest(_endPoint);
                }

                return _properties;
            }
        }

        public OwnersRest Owners
        {
            get
            {
                if (_owners == null)
                {
                    _owners = new OwnersRest(_endPoint);
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
                    _crmTasks = new CrmTasksRest(_endPoint);
                }

                return _crmTasks;
            }
        }
    }
}