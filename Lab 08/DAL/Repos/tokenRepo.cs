using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class tokenRepo :Repo, IRepo<token, int, bool>
    {
        public List<token> All()
        {
            return db.token.ToList();
        }
        public bool create(token obj)
        {
            db.token.Add(obj);
            return db.SaveChanges() > 0;
        }
        public bool delete(int key)
        {
            throw new NotImplementedException();
        }

        public token get(int key)
        {
            throw new NotImplementedException();
        }

        public bool update(token obj)
        {
            throw new NotImplementedException();
        }
    }
}
