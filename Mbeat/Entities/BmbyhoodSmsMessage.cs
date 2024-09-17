using System;
namespace Mbeat.Entities
{
    public class BmbyhoodSmsMessage : SmsMessage
    {
        public int ProjectId { get; set; }
        public int? UserId { get; set; }
    }
}
