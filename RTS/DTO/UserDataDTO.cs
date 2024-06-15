
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTO.Response
{
    public class UserDataDTO
    {
        [JsonProperty("cardNumber")]
        public long CardNumber;

        [JsonProperty("userName")]
        public string? Name;

        [JsonProperty("userSurname")]
        public string? Surname;

        [JsonProperty("address")]
        public string? Addres;

        [JsonProperty("city")]
        public string? City;

        [JsonProperty("state")]
        public string? State;

        [JsonProperty("zipCode")]
        public int? ZipCode;
    }
}
