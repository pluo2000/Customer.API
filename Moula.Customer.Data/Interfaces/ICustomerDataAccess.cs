using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moula.Customer.Model.Entities;

namespace Moula.Customer.Data
{
    public interface ICustomerDataAccess
    {
        User GetByName(string name);
        User GetByUserId(int userId);
    }
}
