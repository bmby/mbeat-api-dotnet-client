using System;
using System.Collections.Generic;

namespace Mbeat.Entities
{
    public class Owner : Entity
    {
        public int OwnerId { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public ICollection<int> MediaId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FirstName2 { get; set; }
        public string LastName2 { get; set; }
        public string Email { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneMobile { get; set; }
        public string PhoneAdditional { get; set; }
        public string Fax { get; set; }
        public int AreaId { get; set; }
        public int CityId { get; set; }
        public int NeighborhoodId { get; set; }
        public int ZipCode { get; set; }
        public int StreetId { get; set; }
        public string HouseNum { get; set; }
        public int StatusId { get; set; } = 0;
        public int IdNumber { get; set; }
        public string BirthPlace { get; set; }
        public string CompanyName { get; set; }
        public int FamilyStatusId { get; set; }
        public bool AllowedEmail { get; set; }
        public bool AllowedSms { get; set; }
        public int SeriousnessId { get; set; } = 0;
        public DateTime OwnerDate { get; set; }
        public bool Urgent { get; set; }
        public bool IsPrivate { get; set; }
        public bool UserPublic { get; set; }
        public int BrokerageStatusId { get; set; } = 0;
        public int RentSaleId { get; set; } = 0;
        public int PropCountryId { get; set; }
        public int PropAreaId { get; set; }
        public int PropCityId { get; set; }
        public int PropNeighborhoodId { get; set; }
        public int PropStreetId { get; set; }
        public string PropHouseNum { get; set; }
        public DateTime PropDate { get; set; }
        public string ApartmentNum { get; set; }
        public int TotalApartmentCount { get; set; }
        public int Floor { get; set; }
        public float TotalFloors { get; set; }
        public float RoomsNum { get; set; }
        public bool Elevator { get; set; }
        public int BedroomsNum { get; set; }
        public int BathroomsNum { get; set; }
        public int ToiletRoomsNum { get; set; }
        public int PropTypeId { get; set; }
        public int PlotSize { get; set; }
        public int BalconySize { get; set; }
        public int GardenSize { get; set; }
        public int StorageSize { get; set; }
        public int ParkingsTypeId { get; set; }
        public int ParkingsCount { get; set; }
        public int Price1 { get; set; }
        public int Price2 { get; set; }
        public int PreviousPrice { get; set; }
        public DateTime ClearingDate { get; set; }//?
        public bool Exclusivity { get; set; }
        public DateTime ExclusivityDate { get; set; }
        public int StepsNum { get; set; }
        public string Comments { get; set; }
        public int CurrencyId { get; set; }
        public ICollection<int> WindDirection { get; set; }
        public ICollection<int> Additions { get; set; }
    }
}
