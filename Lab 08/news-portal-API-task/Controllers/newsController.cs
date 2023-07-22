using news_portal_API_task.EF.Models;
using news_portal_API_task.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity.Migrations;
using System.Xml.Linq;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace news_portal_API_task.Controllers
{
    public class newsController : ApiController
    {
        [HttpGet]
        [Route("api/news/all")]
        public HttpResponseMessage list()
        {
            try
            {
                var db = new apiContext();
                var result = db.news.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, convert(result));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }
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
                if(exNews != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "No news founded with id " + obj.id.ToString() });
                }
                db.Entry(exNews).CurrentValues.SetValues(obj);
                db.SaveChanges();
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
                var exNews = db.news.Find(id);
                if (exNews != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "No news founded with id " + id.ToString() });
                }
                db.news.Remove(exNews);
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
                if (result == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "No news founded with id " + id.ToString() });
                }
                return Request.CreateResponse(HttpStatusCode.OK, convert(result));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/news/category/{cname}")]
        public HttpResponseMessage getNewsByCategory(string cname)
        {
            var db = new apiContext();
            try
            {
                List<news> result = (from c in db.categories
                               where c.name.Equals(cname)
                               select c.newsList).SingleOrDefault();
                return Request.CreateResponse(HttpStatusCode.OK, convert(result));
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/news/date/{date}")]
        public HttpResponseMessage getNewsByDate(string date)
        {
            DateTime dt;
            if (DateTime.TryParse(date, out dt) == false)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new {message  = "Date is not in correct format"});
            }
            var db = new apiContext();
            try
            {
                List<news> result = (from n in db.news
                               where n.date.Equals(dt)
                               select n).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, convert(result));
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }
        }
        [HttpGet]
        //date or category
        [Route("api/news/{doc}")]
        public HttpResponseMessage getNewsByDateOrCategory(string doc)
        {
            DateTime dt;
            var db = new apiContext();
            if (DateTime.TryParse(doc, out dt))
            {
                try
                {
                    List<news> result = (from n in db.news
                                   where n.date.Equals(dt)
                                   select n).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, convert(result));
                }
                catch(Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
                }
            }
            else
            {
                try
                {
                    List<news> result = (from c in db.categories
                                         where c.name.Equals(doc)
                                         select c.newsList).SingleOrDefault();
                    return Request.CreateResponse(HttpStatusCode.OK, convert(result));
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
                }
            }
            
        }
        [HttpGet]
        [Route("api/news/{cname}/{date}")]
        public HttpResponseMessage getNewsByCategoryAndDate(string cname, DateTime date)
        {
            var db = new apiContext();
            try
            {
                List<news> nListByCategory = (from c in db.categories
                                     where c.name.Equals(cname)
                                     select c.newsList).SingleOrDefault();
                List<news> result = (from n in nListByCategory
                                     where n.date.Equals(date)
                                     select n).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, convert(result));
            }
            catch(Exception ex)
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
            //return news.Select(i => convert(i) as object).ToList();
            return (from obj in news select convert(obj)).ToList();
        }
    }
}