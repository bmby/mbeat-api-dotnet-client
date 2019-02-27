using System;
using Mbeat.Enumerations;

namespace Mbeat.Entities
{
    public class DreamsRegistrationParams : Entity
    {
        public string DeviceId { get; set; }
        public DeviceType DeviceType { get; set; }
    }
}
