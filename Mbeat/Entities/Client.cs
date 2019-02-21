using System;
using System.Collections.Generic;

namespace Mbeat.Entities
{
    public class Client : Entity
    {
        public int ClientId { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public ICollection<int> MediaId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FirstName2 { get; set; }
        public string LastName2 { get; set; }
        public string Email { get; set; }
        public bool NotRelevant { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneMobile { get; set; }
        public string PhoneAdditional { get; set; }
        public string Fax { get; set; }
        public string WebSite { get; set; }
        public string StreetAndNum { get; set; }
        public string AdditionalAddress { get; set; }
        public int CountryId { get; set; } = 0;
        public int AreaId { get; set; }
        public int CityId { get; set; }
        public int NeighborhoodId { get; set; }
        public int ZipCode { get; set; }
        public int StatusId { get; set; } = 0;
        public int IdNumber { get; set; }
        public string BirthPlace { get; set; }
        public string CompanyName { get; set; }
        public int FamilyStatusId { get; set; } = 0;
        public bool AllowedEmail { get; set; }
        public bool AllowedSms { get; set; }
        public int SeriousnessId { get; set; } = 0;
        public DateTime ClientDate { get; set; }
        public int RentSaleId { get; set; } = 0;
        public int MaxRooms { get; set; }
        public int MinRooms { get; set; }
        public int MinFloor { get; set; }
        public int MaxFloor { get; set; }
        public float Budget { get; set; }
    }
}