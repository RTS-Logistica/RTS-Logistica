using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTO.Response
{
    public class UserDataResponse
    {
        public readonly UserData _userData;
        public UserDataResponse(UserData userData) { 
            _userData = userData;
        }

        [JsonPropertyName("card number")]
        public long CardNumber { get { return _userData.CardNumber; } set { _userData.CardNumber = value; } }
        [JsonPropertyName("user name")]
        public string? Name { get { return _userData.Name; } set { _userData.Name = value; } }
        [JsonPropertyName("user surname")]
        public string? Surname { get { return _userData.Surname; } set { _userData.Surname = value; } }
        [JsonPropertyName("address")]
        public string? Addres { get { return _userData.AddressNav.Address; } set { _userData.AddressNav.Address = value; } }
        [JsonPropertyName("city")]
        public string? City { get { return _userData.AddressNav.City; } set { _userData.AddressNav.City = value; } }
        [JsonPropertyName("state")]
        public string? State { get { return _userData.AddressNav.State; } set { _userData.AddressNav.State = value; } }
        [JsonPropertyName("zip code")]
        public int? ZipCode { get { return _userData.AddressNav.ZipCode; } set { _userData.AddressNav.ZipCode = (int)value; } }

    }
}
