using news_portal_API_task.EF.Models;
using news_portal_API_task.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity.Migrations;

namespace news_portal_API_task.Controllers
{
    public class newsController : ApiController
    {
        [HttpGet]
        [Route("api/news/all")]
        public HttpResponseMessage list()
        {
            var db = new apiContext();
            var result = db.news.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, convert(result));
        }
        [HttpPost]
        [Route("api/news/add")]
        public HttpResponseMessage add(news obj)
        {
            var db = new apiContext();
            try
            {
                db.news.Add(obj);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }
        }
        [HttpPut]
        [Route("api/news/update")]
        public HttpResponseMessage update(news obj)
        {
            var db = new apiContext();
            try
            {
                var exNews = db.news.Find(obj.id);
                db.Entry(exNews).CurrentValues.SetValues(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "updated" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }
        }
        [HttpDelete]
        [Route("api/news/delete/{id}")]
        public HttpResponseMessage delete(int id)
        {
            var db = new apiContext();
            try
            {
                db.news.Remove(db.news.Find(id));
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "removed" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/news/find/{id}")]
        public HttpResponseMessage find(int id)
        {
            var db = new apiContext();
            try
            {
                var result = db.news.Find(id);
                return Request.CreateResponse(HttpStatusCode.OK, convert(result));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }
        }
        object convert(news news)
        {
            return new
            {
                title = news.title,
                date = news.date.ToShortDateString(),
                description = news.description,
                cid = news.cid,
                category = news.Category.name
            };
        }
        object convert(List<news> news)
        {
            return news.Select(i => convert(i) as object).ToList();
        }
    }
}