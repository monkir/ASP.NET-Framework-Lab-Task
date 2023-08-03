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
    public class categoryRepo
    {
        public static List<category> getAll()
        {
            var db = new apiContext();
            return db.categories.ToList();
        }
        public static category get(int id)
        {
            var db = new apiContext();
            return db.categories.Find(id);
        }
        public static bool create(category n)
        {
            var db = new apiContext();
            db.categories.Add(n);
            return db.SaveChanges() > 0;
        }
        public static bool update(category n)
        {
            var db = new apiContext();
            db.categories.AddOrUpdate(n);
            return db.SaveChanges() > 0;
        }
        public static bool delete(int id)
        {
            var db = new apiContext();
            var excategory = db.categories.Find(id);
            if(excategory == null)
                return false;
            db.categories.Remove(excategory);
            return db.SaveChanges() > 0;
        }
    }
}
