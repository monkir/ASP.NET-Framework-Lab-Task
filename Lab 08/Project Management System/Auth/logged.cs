using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Project_Management_System.Auth
{
    public class logged: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            
            var authToken = actionContext.Request.Headers.Authorization;
            if (authToken == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.OK, new {Message="No token is supllied in header"});
            }
            base.OnAuthorization(actionContext);
        }
    }
}