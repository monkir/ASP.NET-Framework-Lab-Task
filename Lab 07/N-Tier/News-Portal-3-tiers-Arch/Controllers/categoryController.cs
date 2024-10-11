using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace News_Portal_3_tiers_Arch.Controllers
{
    public class categoryController : ApiController
    {
        [HttpGet]
        [Route("api/category/all")]
        public HttpResponseMessage getAll()
        {
            var data = categoryService.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/category/add")]
        public HttpResponseMessage create(categoryDTO obj)
        {
            categoryService.create(obj);
            return Request.CreateResponse(HttpStatusCode.OK, new { message = "created" });
        }
        [HttpPut]
        [Route("api/category/update")]
        public HttpResponseMessage update(categoryDTO obj)
        {
            categoryService.update(obj);
            return Request.CreateResponse(HttpStatusCode.OK, new { message = "updated" });
        }
        [HttpDelete]
        [Route("api/category/delete/{id}")]
        public HttpResponseMessage delete(int id)
        {
            categoryService.delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, new { message = "deleted" });
        }
        [HttpGet]
        [Route("api/category/find/{id}")]
        public HttpResponseMessage get(int id)
        {
            var data = categoryService.get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
