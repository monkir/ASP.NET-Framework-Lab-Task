using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }
        public bool create(supervisor obj)
        {
            throw new NotImplementedException();
        }

        public bool delete(int key)
        {
            throw new NotImplementedException();
        }

        public supervisor get(int key)
        {
            throw new NotImplementedException();
        }

        public bool update(supervisor obj)
        {
            throw new NotImplementedException();
        }
    }
}
