using System;
using System.Collections.Generic;

namespace Mbeat.Entities
{
    public class CrmTask : Entity
    {
        public int TaskId { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int OwnerId { get; set; }
        public int ClientId { get; set; }
        public string Priority { get; set; }
        public ICollection<int> AdditionalUsers { get; set; }
    }
}
