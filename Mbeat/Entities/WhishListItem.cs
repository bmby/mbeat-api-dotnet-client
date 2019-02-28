using System;
namespace Mbeat.Entities
{
    public class WhishListItem : DreamsEntity
    {
        public int PropertyStatusId { get; set; }
        public int PropId { get; set; }
        public int Size { get; set; }
        public int RoomNum { get; set; }
        public string PropType { get; set; }
        public int FloorNum { get; set; }
        public int BmbyPropId { get; set; }
        public string EngineId { get; set; }
        public int PropNum { get; set; }
        public int Status { get; set; }
        public float PriceListPrice { get; set; }
    }
}
