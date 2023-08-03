using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;

namespace News_Portal_3_tiers_Arch.Controllers
{
    public class newsController : ApiController
    {
        [HttpGet]
        [Route("api/news/all")]
        public HttpResponseMessage getAll()
        {
            var data = newsService.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/news/add")]
        public HttpResponseMessage create(newsDTO obj)
        {
            newsService.create(obj);
            return Request.CreateResponse(HttpStatusCode.OK, new { message = "created" });
        }
        [HttpPut]
        [Route("api/news/update")]
        public HttpResponseMessage update(newsDTO obj)
        {
            newsService.update(obj);
            return Request.CreateResponse(HttpStatusCode.OK, new { message = "updated" });
        }
        [HttpDelete]
        [Route("api/news/delete/{id}")]
        public HttpResponseMessage delete(int id)
        {
            newsService.delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, new { message = "deleted" });
        }
        [HttpGet]
        [Route("api/news/find/{id}")]
        public HttpResponseMessage get(int id)
        {
            var data = newsService.get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/news/category/{cname}")]
        public HttpResponseMessage getNewsByCategory(string cname)
        {
            var data = newsService.getNewsByCategory(cname);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/news/date/{date}")]
        public HttpResponseMessage getNewsByDate(string date)
        {
            DateTime dt;
            if (DateTime.TryParse(date, out dt) == false)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Date is not in correct format" });
            }
            var data = newsService.getNewsByDate(dt);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        //date or category
        [Route("api/news/{doc}")]
        public HttpResponseMessage getNewsByDateOrCategory(string doc)
        {
            DateTime dt;
            if (DateTime.TryParse(doc, out dt))
            {
                var data = newsService.getNewsByDate(dt);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                var data = newsService.getNewsByCategory(doc);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
        }
        [HttpGet]
        [Route("api/news/{cname}/{date}")]
        public HttpResponseMessage getNewsByCategoryAndDate(string cname, DateTime date)
        {
            var data = newsService.getNewsByCategoryAndDate(cname, date);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
