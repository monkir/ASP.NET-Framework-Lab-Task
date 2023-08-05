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
            db.project.Remove(get(key));
            return db.SaveChanges() > 0;
        }

        public project get(int key)
        {
            return db.project.Find(key);
        }

        public bool update(project obj)
        {
            db.project.AddOrUpdate(obj);
            return db.SaveChanges() > 0;
        }
    }
}
