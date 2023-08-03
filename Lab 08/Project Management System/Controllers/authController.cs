using BLL.Services;
using Project_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project_Management_System.Controllers
{
    public class authController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage login(loginModel login)
        {
            var data = authService.login(login.username, login.password);
            return Request.CreateResponse(HttpStatusCode.OK, data );
        }
    }
}
