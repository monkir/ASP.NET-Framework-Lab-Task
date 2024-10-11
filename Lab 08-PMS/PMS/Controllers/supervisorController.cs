using BLL.DTOs;
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
        [HttpGet]
        [Route("api/supervisor/project/open")]
        [supervisorLogged]
        public HttpResponseMessage myProjectOpened()
        {
            var tk = Request.Headers.Authorization.ToString();
            var exToken = authService.authorizeUser(tk);
            var data = supervisorService.myProjectsOpened(exToken.userid);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/supervisor/project/inprogress")]
        [supervisorLogged]
        public HttpResponseMessage myProjectInProgress()
        {
            var tk = Request.Headers.Authorization.ToString();
            var exToken = authService.authorizeUser(tk);
            var data = supervisorService.myProjectsInProgress(exToken.userid);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/supervisor/project/completed")]
        [supervisorLogged]
        public HttpResponseMessage myProjectCompleted()
        {
            var tk = Request.Headers.Authorization.ToString();
            var exToken = authService.authorizeUser(tk);
            var data = supervisorService.myProjectsCompleted(exToken.userid);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/supervisor/project/create")]
        [supervisorLogged]
        public HttpResponseMessage mypost(projectDTO proObj)
        {
            var tk = Request.Headers.Authorization.ToString();
            var exToken = authService.authorizeUser(tk);
            proObj.sid = exToken.userid;
            if (supervisorService.createProject(proObj))
                return Request.CreateResponse(HttpStatusCode.OK, "Message = created");
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Message = not created");
        }
        [HttpPost]
        [Route("api/supervisor/project/confirm/{pid}")]
        [supervisorLogged]
        public HttpResponseMessage confirmProject(int pid)
        {
            var tk = Request.Headers.Authorization.ToString();
            var exToken = authService.authorizeUser(tk);
            if (supervisorService.confirmProject(exToken.userid, pid))
                return Request.CreateResponse(HttpStatusCode.OK, "Message = confrimed");
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Message = not confirmed");
        }
        [HttpPost]
        [Route("api/supervisor/project/complete/{pid}")]
        [supervisorLogged]
        public HttpResponseMessage completeProject(int pid)
        {
            var tk = Request.Headers.Authorization.ToString();
            var exToken = authService.authorizeUser(tk);
            if (supervisorService.completeProject(exToken.userid, pid))
                return Request.CreateResponse(HttpStatusCode.OK, "Message = confrimed");
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Message = not confirmed");
        }

    }
}
