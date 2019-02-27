using System;
namespace Mbeat.Entities
{
    public class WhishListItem : Entity
    {
        public int PropertyStatusId { get; set; }
        public int PropId { get; set; }
        public int Size { get; set; }
    }
}


        //, 'roomNum' => new \Zend\Db\Sql\Predicate\Expression('Appartments.Rooms')
        //, 'propType' => new \Zend\Db\Sql\Predicate\Expression('AppartmentType.Description')
        //, 'floorNum' => new \Zend\Db\Sql\Predicate\Expression('__NewProperties.Floor')
        //, 'bmbyPropId' => new \Zend\Db\Sql\Predicate\Expression('__NewProperties.PropID')
        //, 'engineId' => new \Zend\Db\Sql\Predicate\Expression('__NewProperties.Engine3DID')
        //, 'propNum' => new \Zend\Db\Sql\Predicate\Expression('ProjectHouses.HouseNum')
        //, 'status' => new \Zend\Db\Sql\Predicate\Expression('PropertiesStatus.StatusName')
        //,'priceListPrice')) ;
