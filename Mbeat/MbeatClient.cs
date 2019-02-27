using System;
using System.Collections.Generic;
using Mbeat.Rest;
using Mbeat.Rest.Interface;

namespace Mbeat
{
    public class MbeatClient
    {
        private const string BaseUrl = "https://mbeat.bmby.com/api";

        private ClientsRest _clients;
        private OwnersRest _owners;
        private CrmTasksRest _crmTasks;
        private BmbyhoodRest _bmbyhood;
        private EmailRest _email;
        private SmsRest _sms;
        private DreamsRest _dreams;

        private readonly string _baseUrl;
        private readonly AuthParams _authParams;

        public MbeatClient(AuthParams authParams) : this(BaseUrl, authParams)
        {
        }

        public MbeatClient(string baseUrl, AuthParams authParams)
        {
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new Exception("endpoint argument is null or empty");
            }

            _baseUrl = baseUrl;
            _authParams = authParams;
        }

        public DreamsRest Dreams
        {
            get
            {
                if (_dreams == null)
                {
                    _dreams = new DreamsRest(_baseUrl, _authParams);
                }

                return _dreams;
            }
        }

        public ClientsRest Clients
        {
            get
            {
                if (_clients == null)
                {
                    _clients = new ClientsRest(_baseUrl, _authParams);
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
                    _owners = new OwnersRest(_baseUrl, _authParams);
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
                    _crmTasks = new CrmTasksRest(_baseUrl, _authParams);
                }

                return _crmTasks;
            }
        }

        public BmbyhoodRest Bmbyhood
        {
            get
            {
                if (_bmbyhood == null)
                {
                    _bmbyhood = new BmbyhoodRest(_baseUrl, _authParams);
                }

                return _bmbyhood;
            }
        }

        public SmsRest Sms
        {
            get
            {
                if (_sms == null)
                {
                    _sms = new SmsRest(_baseUrl, _authParams);
                }

                return _sms;
            }
        }

        public EmailRest Email
        {
            get
            {
                if (_email == null)
                {
                    _email = new EmailRest(_baseUrl, _authParams);
                }

                return _email;
            }
        }
    }
}