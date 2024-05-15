using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BatchCard
    {
        public int BatchId { get; set; }
        public int BankFormatId { get; set; }
        public BankFormat BankFormatNav { get; set; }
        public ICollection<UserData> UserDataCollection { get; set; }
    }
}
