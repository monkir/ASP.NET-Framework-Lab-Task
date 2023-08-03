using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class loginRepo : Repo, IAuth<member>
    {
        member IAuth<member>.Authentication(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
