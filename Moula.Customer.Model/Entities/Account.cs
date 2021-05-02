using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moula.Customer.Model.Entities
{ 
    public class Account
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string Status { get; set; }
        public string CloseReason { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
