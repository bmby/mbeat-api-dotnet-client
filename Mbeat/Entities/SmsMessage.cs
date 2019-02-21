using System;
namespace Mbeat.Entities
{
    public class SmsMessage : Entity
    {
        public string PhoneNumber { get; set; }
        public string SenderPhoneNumber { get; set; }
        public string Message { get; set; }
    }
}
