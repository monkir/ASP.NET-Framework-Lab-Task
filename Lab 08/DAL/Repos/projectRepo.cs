using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class projectRepo : Repo, IRepo<project, int, bool>
    {
        public List<project> All()
        {
            return db.project.ToList();
        }

        public bool create(project obj)
        {
            db.project.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool delete(int key)
        {
            throw new NotImplementedException();
        }

        public project get(int key)
        {
            throw new NotImplementedException();
        }

        public bool update(project obj)
        {
            throw new NotImplementedException();
        }
    }
}
