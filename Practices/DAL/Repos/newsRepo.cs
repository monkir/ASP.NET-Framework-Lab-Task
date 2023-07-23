using DAL.EF;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class newsRepo
    {
        public static List<news> getAll()
        {
            var db = new apiContext();
            return db.news.ToList();
        }
        public static news get(int id)
        {
            var db = new apiContext();
            return db.news.Find(id);
        }
        public static bool create(news n)
        {
            var db = new apiContext();
            db.news.Add(n);
            return db.SaveChanges() > 0;
        }
        public static bool update(news n)
        {
            var db = new apiContext();
            db.news.AddOrUpdate(n);
            return db.SaveChanges() > 0;
        }
        public static bool delete(int id)
        {
            var db = new apiContext();
            var exNews = db.news.Find(id);
            db.news.Remove(exNews);
            return db.SaveChanges() > 0;
        }
    }
}
