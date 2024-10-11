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
        //[Route("api/member/all")]
        [HttpGet]
        [memberLogged]
        public HttpResponseMessage all()
        {
            return Request.CreateResponse(HttpStatusCode.OK, memberService.All());
        }
        [HttpGet]
        [memberLogged]
        [Route("api/member/project/open")]
        public HttpResponseMessage openProject() 
        {
            /*var tk = Request.Headers.Authorization.ToString();
            var exToken = authService.authorizeUser(tk);*/
            var data = memberService.openProject();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [memberLogged]
        [Route("api/member/myproject/all")]
        public HttpResponseMessage myProjects() 
        {
            var tk = Request.Headers.Authorization.ToString();
            var exToken = authService.authorizeUser(tk);
            var data = memberService.myProjects(exToken.userid);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [memberLogged]
        [Route("api/member/myproject/inprogress")]
        public HttpResponseMessage myProjectsInProgress() 
        {
            var tk = Request.Headers.Authorization.ToString();
            var exToken = authService.authorizeUser(tk);
            var data = memberService.myProjectsInProgress(exToken.userid);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [memberLogged]
        [Route("api/member/myproject/completed")]
        public HttpResponseMessage myProjectsCompleted() 
        {
            var tk = Request.Headers.Authorization.ToString();
            var exToken = authService.authorizeUser(tk);
            var data = memberService.myProjectsCompleted(exToken.userid);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [memberLogged]
        [Route("api/member/project/enrollment/{pid}")]
        public HttpResponseMessage enrollment(int pid)
        {
            var tk = Request.Headers.Authorization.ToString();
            var exToken = authService.authorizeUser(tk);
            if(memberService.enrollment(exToken.userid, pid))
                return Request.CreateResponse(HttpStatusCode.OK, "Message = enrolled");
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Message = not enrolled");

        }
    }
}
