using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class enrollmentRepo : Repo, IRepo<enrollment, int, bool>
    {
        public List<enrollment> All()
        {
            return db.enrollment.ToList();
        }

        public bool create(enrollment obj)
        {
            db.enrollment.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool delete(int key)
        {
            throw new NotImplementedException();
        }

        public enrollment get(int key)
        {
            throw new NotImplementedException();
        }

        public bool update(enrollment obj)
        {
            throw new NotImplementedException();
        }
    }
}
