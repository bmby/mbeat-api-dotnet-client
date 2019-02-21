using System;
namespace Mbeat.Entities
{
    public class EmailMessage : Entity
    {
        public EmailAddress To { get; set; }
        public EmailAddress From { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
