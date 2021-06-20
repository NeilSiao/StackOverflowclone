using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StackOverflow.ServiceLayers;
using StackOverflow.ViewModels;
namespace StackOverflow.ApiControllers
{
    public class AccountController : ApiController
    {
        readonly IUserService us;
        public AccountController(IUserService us)
        {
            this.us = us;
        }

        public string Get(string Email)
        {
            if(this.us.GetUsersByEmail(Email) != null)
            {
                return "Found";
            }
            else
            {
                return "Not Found";
            }
        }
    }
}
