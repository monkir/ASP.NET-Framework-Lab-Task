using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class supervisorRepo : Repo, IRepo<supervisor, int, bool>, IAuth<supervisor>
    {

        public supervisor Authentication(string username, string password)
        {
            var data = (from i in db.supervisor
                        where i.username.Equals(username) && i.password.Equals(password)
                        select i);
            if(data != null) { return data.SingleOrDefault(); }
            return null;
        }
        public List<supervisor> All()
        {
            return db.supervisor.ToList();
        }
        public bool create(supervisor obj)
        {
            db.supervisor.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool delete(int key)
        {
            db.supervisor.Remove(get(key));
            return db.SaveChanges() > 0;
        }

        public supervisor get(int key)
        {
            return db.supervisor.Find(key);
        }

        public bool update(supervisor obj)
        {
            db.supervisor.AddOrUpdate(obj);
            return db.SaveChanges() > 0;
        }
    }
}
