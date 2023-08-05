using BLL.Services;
using Project_Management_System.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project_Management_System.Controllers
{
    public class supervisorController : ApiController
    {
        [HttpGet]
        [Route("api/supervisor/mydata")]
        [supervisorLogged]
        public HttpResponseMessage mydata()
        {
            var tk = Request.Headers.Authorization.ToString();
            var exToken = authService.authorizeUser(tk);
            return Request.CreateResponse(HttpStatusCode.OK, exToken);
        }
        [HttpGet]
        [Route("api/supervisor/project/all")]
        [supervisorLogged]
        public HttpResponseMessage myProject()
        {
            var tk = Request.Headers.Authorization.ToString();
            var exToken = authService.authorizeUser(tk);
            var data = supervisorService.myProjects(exToken.userid);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
