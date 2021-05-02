using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moula.Customer.Service;
using Moula.Customer.Data;
using Moula.Customer.Model.Entities;


namespace Moula.Customer.Test
{
    public class MockCustomerService : ICustomerService
    {
        private readonly ICustomerDataAccess _testCustomerDataAccess;
        public MockCustomerService()
        {
            _testCustomerDataAccess = new JsonFileAccess();
        }

        public User GetByName(string name)
        {
            return null;
        }

        public User GetByUserId(int userId)
        {
            return null;
        }


    }
}
