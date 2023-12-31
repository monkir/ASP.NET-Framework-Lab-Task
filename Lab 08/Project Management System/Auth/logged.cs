﻿using BLL.Services;
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
                actionContext.Response = actionContext.Request.CreateResponse(
                        System.Net.HttpStatusCode.Unauthorized, 
                        new {Message="No token is supllied in header"}
                    );
            }
            else
            {
                var exToken = authService.authorizeUser(authToken.ToString());
                if (exToken == null)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(
                            System.Net.HttpStatusCode.Unauthorized, 
                            new { Message = "Supplied token is not valid" }
                        );
                }
                else if(exToken.expireTime.CompareTo(DateTime.Now) < 0) 
                {
                    actionContext.Response = actionContext.Request.CreateResponse(
                            System.Net.HttpStatusCode.Unauthorized, 
                            new { Message = "Supplied token is expired" }
                        );
                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}