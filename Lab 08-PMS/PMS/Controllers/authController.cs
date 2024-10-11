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
            var tk = authService.login(login.username, login.password);
            if(tk != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, tk );
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, new { message = "Invalid credential" });
            }
        }
    }
}
