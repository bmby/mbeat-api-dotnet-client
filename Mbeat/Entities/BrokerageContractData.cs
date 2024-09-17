using System;
namespace Mbeat.Entities
{
    public class BrokerageContractData : Entity
    {
        public int ProjectId { get; set; }
        public int OwnerId { get; set; }
        public int ClientId { get; set; }
    }
}
