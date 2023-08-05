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
    public class supervisorService
    {
        public static List<projectDTO> myProjects(int supID)
        {
            var data = DataAccessChannel.getSupervisor().get(supID).projects.ToList();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<project, projectDTO>());
            var mapper = config.CreateMapper();
            return mapper.Map<List<projectDTO>>(data);
        }
    }
}
