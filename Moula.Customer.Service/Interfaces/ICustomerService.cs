using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moula.Customer.Model.Entities;

namespace Moula.Customer.Service
{
    public interface ICustomerService
    {
        User GetByName(string name);

        User GetByUserId(int userId);
    }
}
