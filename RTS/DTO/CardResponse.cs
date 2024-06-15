using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTO.Response
{
    public class CardResponse
    {
        [JsonProperty("Id")]
        public int BatchId;

        [JsonProperty("bankName")]
        public string? BankName;

        [JsonProperty("slogan")]
        public string? Slogan;

        [JsonProperty("logo")]
        public string? Logo;

        public UserDataDTO UsersData;
    }
}
    