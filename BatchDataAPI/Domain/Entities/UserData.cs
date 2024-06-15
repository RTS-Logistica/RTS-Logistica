using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserData
    {
        public long CardNumber { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int AddressId { get; set; }
        public int BatchCardId { get; set; }

        public UserAddress? AddressNav { get; set; }
        //public BatchCard? BatchCardNav { get; set; }
    }
}
