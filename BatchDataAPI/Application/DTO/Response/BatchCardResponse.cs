using Application.DTO.Mapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTO.Response
{
    public class BatchCardResponse
    {
        public readonly BatchCard _batchCard;
        public readonly ICollection<UserData> _batchUsersData;

        public BatchCardResponse(BatchCard batchCard, ICollection<UserData> batchUsersData)
        {
            _batchCard = batchCard;
            _batchUsersData = batchUsersData;
        }

        [JsonPropertyName("Id")]
        public int BatchId { get { return _batchCard.BatchId; } set { _batchCard.BatchId = value; } }
        [JsonPropertyName("bank name")]
        public string? BankName { get { return _batchCard.BankFormatNav.Name; } set { _batchCard.BankFormatNav.Name = value; } }
        [JsonPropertyName("slogan")]
        public string? Slogan { get { return _batchCard.BankFormatNav.Slogan; } set { _batchCard.BankFormatNav.Slogan = value; } }
        [JsonPropertyName("logo")]
        public string? Logo { get { return _batchCard.BankFormatNav.Logo; } set { _batchCard.BankFormatNav.Logo = value; } }
        public List<UserDataResponse> UsersData { get { return MapperList.UserDataMapper(_batchUsersData); } }
    }
}
    