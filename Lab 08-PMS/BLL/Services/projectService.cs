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
    public class projectService
    {
        public static List<projectDTO> All()
        {
            var data = DataAccessChannel.getProject().All();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<project, projectDTO>());
            var mapper = config.CreateMapper();
            return mapper.Map<List<projectDTO>>(data);
        }
        public static projectDTO get(int id)
        {
            var data = DataAccessChannel.getProject().get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<project, projectDTO>());
            var mapper = config.CreateMapper();
            return mapper.Map<projectDTO>(data);
        }
    }
}
