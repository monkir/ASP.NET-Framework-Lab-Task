using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class authService
    {
        public static tokenDTO login(string username, string password)
        {
            var memberData = DataAccessChannel.getMemberAuth().Authentication(username, password);
            if (memberData != null) 
            {
                //return "member"; 
                var tk = Guid.NewGuid().ToString();
                token newToken = DataAccessChannel.getToken().create(
                        new DAL.EF.Models.token()
                        {
                            token_string = tk,
                            userid = memberData.id,
                            userrole = "member",
                            expireTime = DateTime.Now.AddMinutes(2)
                        }
                    );
                var config = new MapperConfiguration(cfg => cfg.CreateMap<token, tokenDTO>());
                var mapper = config.CreateMapper();
                return mapper.Map<tokenDTO>(newToken);
            }
            var supervisorData = DataAccessChannel.getSupervisorAuth().Authentication(username, password);
            if (supervisorData != null)
            {
                //return "supervisor"; 
                var tk = Guid.NewGuid().ToString();
                token newToken = DataAccessChannel.getToken().create(
                        new DAL.EF.Models.token()
                        {
                            token_string = tk,
                            userid = supervisorData.id,
                            userrole = "supervisor",
                            expireTime = DateTime.Now.AddMinutes(2)
                        }
                    );
                var config = new MapperConfiguration(cfg => cfg.CreateMap<token, tokenDTO>());
                var mapper = config.CreateMapper();
                return mapper.Map<tokenDTO>(newToken);
            }

            return null;
        }
        public static tokenDTO authorizeUser(string tk)
        {
            var data = DataAccessChannel.getToken().All();
            var exToken = (from t in data
                           where t.token_string.Equals(tk)
                           select t).SingleOrDefault();
            if(exToken != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<token, tokenDTO>());
                var mapper = config.CreateMapper();
                return mapper.Map<tokenDTO>(exToken);
            }
            return null;
        }
    }
}
