using BLL.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class authService
    {
        public static string login(string username, string password)
        {
            var tk = DataAccessChannel.getMemberAuth().Authentication(username, password);
            if (tk != null) { return "member"; }
            var tk2 = DataAccessChannel.getSupervisorAuth().Authentication(username, password);
            if (tk2 != null) { return "super"; }
            return null;
        }
    }
}
