using System;
namespace Mbeat.Enumerations
{
    public class DeviceType
    {
        private readonly string _value;

        private DeviceType(string value)
        {
            _value = value;
        }

        public static readonly DeviceType Desktop = new DeviceType("desktop");
        public static readonly DeviceType Mobile = new DeviceType("mobile");


        public override string ToString()
        {
            return _value;
        }
    }
}