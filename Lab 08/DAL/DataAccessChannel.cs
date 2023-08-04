using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessChannel
    {
        public static IRepo<project, int, bool> getProject() { return new projectRepo(); }
        public static IRepo<member, int, bool> getMember() { return new memberRepo(); }
        public static IRepo<supervisor, int, bool> getSupervisor() {  return new supervisorRepo(); }
        public static IRepo<token, int, token> getToken() {  return new tokenRepo(); }
        public static IAuth<member> getMemberAuth() { return new memberRepo(); }
        public static IAuth<supervisor> getSupervisorAuth() { return new supervisorRepo(); }
    }
}
