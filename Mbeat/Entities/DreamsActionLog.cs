using System;
namespace Mbeat.Entities
{
    public class DreamsActionLog : DreamsEntity
    {
        public string Action { get; set; }
        public object ActionData { get; set; }
    }
}
