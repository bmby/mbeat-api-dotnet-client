using System;
namespace Mbeat.Enumerations
{
    public class Scope
    {
        private readonly string _value;

        private Scope(string value)
        {
            _value = value;
        }

        public static readonly Scope UsersReadScope = new Scope("mbeatAPI.users.read");
        public static readonly Scope UsersWriteScope = new Scope("mbeatAPI.users.write");
        public static readonly Scope ClientsReadScope = new Scope("mbeatAPI.clients.read");
        public static readonly Scope ClientsWriteScope = new Scope("mbeatAPI.clients.write");
        public static readonly Scope OwnersReadScope = new Scope("mbeatAPI.owners.read");
        public static readonly Scope OwnersWriteScope = new Scope("mbeatAPI.owners.write");
        public static readonly Scope CrmReadScope = new Scope("mbeatAPI.crm.read");
        public static readonly Scope CrmWriteScope = new Scope("mbeatAPI.crm.write");
        public static readonly Scope BmbyhoodReadScope = new Scope("mbeatAPI.bmbyhood.read");
        public static readonly Scope BmbyhoodWriteScope = new Scope("mbeatAPI.bmbyhood.write");
        public static readonly Scope EmailScope = new Scope("mbeatAPI.email");
        public static readonly Scope SmsWriteScope = new Scope("mbeatAPI.sms");


        public override string ToString()
        {
            return _value;
        }
    }
}