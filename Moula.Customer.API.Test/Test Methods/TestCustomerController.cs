using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moula.Customer.Service;
using Moula.Customer.Data;
using Moula.Customer.API.Controllers;

namespace Moula.Customer.Test
{
    [TestClass]
    public class TestCustomerController
    {
        [TestMethod]
        public void GetBalanceById_ShouldReturnSameResponseWithSameID()
        {
            int userId = 1;
            string expectedResult = "{\"UserId\":1,\"Name\":\"Johan\",\"Accounts\":[{\"AccountId\":1,\"Name\":\"Johan1\",\"Balance\":100.0,\"Status\":\"Open\",\"CloseReason\":\"\",\"Payments\":[{\"PaymentId\":1,\"Amount\":100.0,\"Date\":\"2016-01-02T00:00:00\"}]},{\"AccountId\":2,\"Name\":\"Johan2\",\"Balance\":300.0,\"Status\":\"Open\",\"CloseReason\":\"\",\"Payments\":[{\"PaymentId\":4,\"Amount\":400.0,\"Date\":\"2009-02-03T00:00:00\"},{\"PaymentId\":3,\"Amount\":300.0,\"Date\":\"2000-01-03T00:00:00\"}]}]}";
            
            //generate a mock data access object to local storage file: Files\Customers.json in nunit test project
            ICustomerDataAccess testCustomerDataAccess=new JsonFileAccess();

            //pass the mocke data access object to the service 
            ICustomerService customerservice = new CustomerService(testCustomerDataAccess);

            //pass the service object to customer controller in API and retrieve the data
            var controller = new CustomerController(customerservice);
            string actualResult = controller.GetBalanceById(userId);
            
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetBalanceById_ShouldReturnDifferentResponseWithDifferentUserID()
        {
            int userId = 2;
            string expectedResult = "{\"UserId\":1,\"Name\":\"Johan\",\"Accounts\":[{\"AccountId\":1,\"Name\":\"Johan1\",\"Balance\":100.0,\"Status\":\"Open\",\"CloseReason\":\"\",\"Payments\":[{\"PaymentId\":1,\"Amount\":100.0,\"Date\":\"2016-01-02T00:00:00\"}]},{\"AccountId\":2,\"Name\":\"Johan2\",\"Balance\":300.0,\"Status\":\"Open\",\"CloseReason\":\"\",\"Payments\":[{\"PaymentId\":4,\"Amount\":400.0,\"Date\":\"2009-02-03T00:00:00\"},{\"PaymentId\":3,\"Amount\":300.0,\"Date\":\"2000-01-03T00:00:00\"}]}]}";

            //generate a mock data access object to local storage file: Files\Customers.json in nunit test project
            ICustomerDataAccess testCustomerDataAccess = new JsonFileAccess();

            //pass the mocke data access object to the service 
            ICustomerService customerservice = new CustomerService(testCustomerDataAccess);

            //pass the service object to customer controller in API and retrieve the data
            var controller = new CustomerController(customerservice);
            string actualResult = controller.GetBalanceById(userId);

            Assert.IsNotNull(actualResult);
            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetGetBalanceByName_ShouldReturnSameResponseWithSameName()
        {
            string name = "Johan";
            string expectedResult = "{\"UserId\":1,\"Name\":\"Johan\",\"Accounts\":[{\"AccountId\":1,\"Name\":\"Johan1\",\"Balance\":100.0,\"Status\":\"Open\",\"CloseReason\":\"\",\"Payments\":[{\"PaymentId\":1,\"Amount\":100.0,\"Date\":\"2016-01-02T00:00:00\"}]},{\"AccountId\":2,\"Name\":\"Johan2\",\"Balance\":300.0,\"Status\":\"Open\",\"CloseReason\":\"\",\"Payments\":[{\"PaymentId\":4,\"Amount\":400.0,\"Date\":\"2009-02-03T00:00:00\"},{\"PaymentId\":3,\"Amount\":300.0,\"Date\":\"2000-01-03T00:00:00\"}]}]}";

            //generate a mock data access object to local storage file: Files\Customers.json in nunit test project
            ICustomerDataAccess testCustomerDataAccess = new JsonFileAccess();

            //pass the mocke data access object to the service 
            ICustomerService customerservice = new CustomerService(testCustomerDataAccess);

            //pass the service object to customer controller in API and retrieve the data
            var controller = new CustomerController(customerservice);
            string actualResult = controller.GetBalanceByName(name);

            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetGetBalanceByName_ShouldReturnDifferentResponseWithDifferentName()
        {
            string name = "Sheri";
            string expectedResult = "{\"UserId\":1,\"Name\":\"Johan\",\"Accounts\":[{\"AccountId\":1,\"Name\":\"Johan1\",\"Balance\":100.0,\"Status\":\"Open\",\"CloseReason\":\"\",\"Payments\":[{\"PaymentId\":1,\"Amount\":100.0,\"Date\":\"2016-01-02T00:00:00\"}]},{\"AccountId\":2,\"Name\":\"Johan2\",\"Balance\":300.0,\"Status\":\"Open\",\"CloseReason\":\"\",\"Payments\":[{\"PaymentId\":4,\"Amount\":400.0,\"Date\":\"2009-02-03T00:00:00\"},{\"PaymentId\":3,\"Amount\":300.0,\"Date\":\"2000-01-03T00:00:00\"}]}]}";

            //generate a mock data access object to local storage file: Files\Customers.json in nunit test project
            ICustomerDataAccess testCustomerDataAccess = new JsonFileAccess();

            //pass the mocke data access object to the service 
            ICustomerService customerservice = new CustomerService(testCustomerDataAccess);

            //pass the service object to customer controller in API and retrieve the data
            var controller = new CustomerController(customerservice);
            string actualResult = controller.GetBalanceByName(name);

            Assert.IsNotNull(actualResult);
            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetGetBalanceById_ShouldReturnNoResultWithUserIdNotExisted()
        {
            int userid = 3;
            string expectedResult = "No match";

            //generate a mock data access object to local storage file: Files\Customers.json in nunit test project
            ICustomerDataAccess testCustomerDataAccess = new JsonFileAccess();

            //pass the mocke data access object to the service 
            ICustomerService customerservice = new CustomerService(testCustomerDataAccess);

            //pass the service object to customer controller in API and retrieve the data
            var controller = new CustomerController(customerservice);
            string actualResult = controller.GetBalanceById(userid);

            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetGetBalanceByName_ShouldReturnNoResultWithNameNotExisted()
        {
            string name = "Peter";
            string expectedResult = "No match";

            //generate a mock data access object to local storage file: Files\Customers.json in nunit test project
            ICustomerDataAccess testCustomerDataAccess = new JsonFileAccess();

            //pass the mocke data access object to the service 
            ICustomerService customerservice = new CustomerService(testCustomerDataAccess);

            //pass the service object to customer controller in API and retrieve the data
            var controller = new CustomerController(customerservice);
            string actualResult = controller.GetBalanceByName(name);

            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
