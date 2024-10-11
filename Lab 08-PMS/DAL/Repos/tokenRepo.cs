using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class tokenRepo :Repo, IRepo<token, int, token>
    {
        public List<token> All()
        {
            return db.token.ToList();
        }
        public token create(token obj)
        {
            db.token.Add(obj);
            db.SaveChanges();
            return obj;
        }
        public token delete(int key)
        {
            db.token.Remove(get(key));
            return null;
        }

        public token get(int key)
        {
            return db.token.Find(key);
        }

        public token update(token obj)
        {
            throw new NotImplementedException();
        }
    }
}
