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
    public class memberController : ApiController
    {
        [Route("api/member/all")]
        [HttpGet]
        [logged]
        public HttpResponseMessage all()
        {
            return Request.CreateResponse(HttpStatusCode.OK, memberService.All());
        }
    }
}
