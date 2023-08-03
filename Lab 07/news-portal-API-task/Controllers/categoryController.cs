﻿using news_portal_API_task.EF.Models;
using news_portal_API_task.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace news_portal_API_task.Controllers
{
    public class categoryController : ApiController
    {
        [HttpGet]
        [Route("api/category/all")]
        public HttpResponseMessage list()
        {
            try
            {
                var db = new apiContext();
                var result = db.categories.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, convert(result));
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }
            
        }
        [HttpPost]
        [Route("api/category/add")]
        public HttpResponseMessage add(category obj)
        {
            var db = new apiContext();
            try
            {
                db.categories.Add(obj);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }
        }
        [HttpPut]
        [Route("api/category/update")]
        public HttpResponseMessage update(category obj)
        {
            var db = new apiContext();
            try
            {
                var exCategory = db.categories.Find(obj.id);
                if (exCategory == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "No category founded with id " + obj.id.ToString() });
                }
                db.Entry(exCategory).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "updated" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }
        }
        [HttpDelete]
        [Route("api/category/delete/{id}")]
        public HttpResponseMessage delete(int id)
        {
            var db = new apiContext();
            try
            {
                var exCategory = db.categories.Find(id);
                if (exCategory == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "No category founded with id " + id.ToString() });
                }
                db.categories.Remove(exCategory);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "removed" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/category/find/{id}")]
        public HttpResponseMessage find(int id)
        {
            var db = new apiContext();
            try
            {
                var result = db.categories.Find(id);
                if(result== null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "No category founded with id "+id.ToString()});
                }
                return Request.CreateResponse(HttpStatusCode.OK, convert(result));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }
        }
        object convert(category category)
        {
            return new
            {
                id = category.id,
                name = category.name,
            };
        }
        object convert(List<category> categories)
        {
            //return categories.Select(i => convert(i) as object).ToList();
            return (from category in categories select convert(category)).ToList();
        }
    }
}