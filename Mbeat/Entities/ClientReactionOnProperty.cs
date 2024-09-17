using System;
using Mbeat.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mbeat.Entities
{
    public class ClientReactionOnProperty : Entity
    {
        public int ClientId { get; set; }
        public int OwnerId { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ClientReaction Reaction { get; set; }
        public bool CreateTask { get; set; } = false;
    }
}
