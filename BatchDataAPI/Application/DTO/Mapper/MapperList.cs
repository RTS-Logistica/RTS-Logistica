using Application.DTO.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Mapper
{
    public class MapperList
    {
        public static List<UserDataResponse> UserDataMapper(ICollection<UserData> _userData)
        {
            List<UserDataResponse> usersDataDTO = new List<UserDataResponse>();
            if (_userData == null)
                return usersDataDTO;
            foreach (var item in _userData)
            {
                usersDataDTO.Add(new UserDataResponse(item));
            }
            return usersDataDTO;
        }
    }
}
