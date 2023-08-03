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
    public class memberService
    {
        public static List<memberDTO> All()
        {
            var data = DataAccessChannel.getMember().All();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<member, memberDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<List<memberDTO>>(data);
        }
    }
}
