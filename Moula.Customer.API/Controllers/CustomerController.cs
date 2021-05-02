using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Moula.Customer.Service;
using Moula.Customer.Model.Entities;
using Newtonsoft.Json;


namespace Moula.Customer.API.Controllers
{
    public class CustomerController : ApiController
    {

        private readonly ICustomerService _customerSerivce;

        //GET api/values
        public CustomerController(ICustomerService customerSerivce)
        {
            _customerSerivce = customerSerivce;
        }


        // GET api/Customer/UserId/2
        [HttpGet]
        [Route("api/Customer/UserId/{userId}")]
        public string GetBalanceById(int userId)
        {
            string response;
            try
            {
                //retrieve user's account balance based on user id
                User user = _customerSerivce.GetByUserId(userId);

                //return user's balance details if found record
                if (user == null)
                {
                    response = "No match";
                }
                else
                {
                    response = JsonConvert.SerializeObject(user, Formatting.None);
                }

            }
            catch (Exception ex)
            {
                response = "Error occured: " + ex.Message;
            }
            return response;
        }

        // GET api/Customer/Name/John
        [HttpGet]
        [Route("api/Customer/Name/{name}")]
        public string GetBalanceByName(string name)
        {
            string response;
            try
            {
                //retrieve user's account balance based on name
                User user = _customerSerivce.GetByName(name);

                //return user's balance details if found record
                if (user == null)
                {
                    response = "No match";
                }
                else
                {
                    response = JsonConvert.SerializeObject(user, Formatting.None);
                }

            }
            catch (Exception ex)
            {
                response = "Error occured: " + ex.Message;
            }
            return response;
        }
   
    }
}