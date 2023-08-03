using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public bool delete(int key)
        {
            throw new NotImplementedException();
        }

        public member get(int key)
        {
            return db.member.Find(key);
        }

        public bool update(member obj)
        {
            throw new NotImplementedException();
        }
    }
}
