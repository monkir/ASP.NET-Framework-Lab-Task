using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project_Management_System.Controllers
{
    public class projectController : ApiController
    {
        [Route("api/project/all")]
        [HttpGet]
        public HttpResponseMessage all()
        {
            return Request.CreateResponse(HttpStatusCode.OK, projectService.All());
        }
        [Route("api/project/get/{id}")]
        [HttpGet]
        public HttpResponseMessage get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, projectService.get(id));
        }
    }
}
