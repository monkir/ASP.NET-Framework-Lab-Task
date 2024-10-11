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
    internal class memberRepo : Repo, IRepo<member, int, bool>, IAuth<member>
    {
        public member Authentication(string username, string password)
        {
            var data = (from i in db.member
                        where i.username.Equals(username)  && i.password.Equals(password)
                        select i);
            if(data != null ) { return data.SingleOrDefault(); }
            return null;
        }
        public List<member> All()
        {
            return db.member.ToList();
        }
        public bool create(member obj)
        {
            db.member.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool delete(int key)
        {
            db.member.Remove(get(key));
            return db.SaveChanges() > 0;
        }

        public member get(int key)
        {
            return db.member.Find(key);
        }

        public bool update(member obj)
        {
            db.member.AddOrUpdate(obj);
            return db.SaveChanges() > 0;
        }
    }
}
