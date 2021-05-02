using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moula.Customer.Data;
using Moula.Customer.Model.Entities;
using Newtonsoft.Json;

namespace Moula.Customer.Service
{
    public class CustomerService:ICustomerService
    {
        private readonly ICustomerDataAccess _customerDataAccess;

        public CustomerService(ICustomerDataAccess customerDataAccess)
        {
            _customerDataAccess = customerDataAccess;
        }
        public User GetByName(string name)
        {
            User user = _customerDataAccess.GetByName(name);


            // check if user exists before sorting payments by the newest date
            if (user != null)
            {
                user = SortPaymentsByDate(user);

            }
            return user;
        }

        public User GetByUserId(int userId)
        {
            User user = _customerDataAccess.GetByUserId(userId);

            // check if user exists before sorting payments by the newest date
            if (user != null)
            {
                user = SortPaymentsByDate(user);

            }
            return user;
        }

        private User SortPaymentsByDate(User user)
        {
            //check if an account has any payments before sorting the payments by the newest date. 
           user.Accounts
                .Where(x => x.Payments != null && x.Payments.Any()).ToList()
                .ForEach(a => a.Payments
                .Sort((x, y) => DateTime.Compare(y.Date, x.Date)));

            return user;
            
        }
    }
}
