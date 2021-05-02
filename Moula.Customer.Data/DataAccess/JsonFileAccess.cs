using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Configuration;
using Moula.Customer.Model.Entities;
using Newtonsoft.Json;

namespace Moula.Customer.Data
{
    public class JsonFileAccess: ICustomerDataAccess
    {
        private const string JSON_FILENAME = "CustomerFile";
        private string _filepath;
        public JsonFileAccess()
        {
            var FileName = ConfigurationManager.AppSettings[JSON_FILENAME];

            _filepath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Remove(0, 6) + FileName;
        }

        public User GetByName(string name)
        {
            return GetUser(x => x.Name == name);
        }

        public User GetByUserId(int userId)
        {
            return GetUser(x => x.UserId == userId);
        }

        private User GetUser(Predicate<User> filter)
        {
            var json = System.IO.File.ReadAllText(_filepath);
            var Users = JsonConvert.DeserializeObject<IEnumerable<User>>(json);
            return Users.FirstOrDefault(x => filter(x));

            //IEnumerable<User> Users = JsonConvert.DeserializeObject<IEnumerable<User>>(json);
            //IEnumerable<User> SortedUsers =Users.OrderByDescending(i => i.Accounts.OrderByDescending(t => t.Payments.OrderByDescending(c=>c.Date)));

            //return SortedUsers.FirstOrDefault(x => filter(x));

        }
    }
}
