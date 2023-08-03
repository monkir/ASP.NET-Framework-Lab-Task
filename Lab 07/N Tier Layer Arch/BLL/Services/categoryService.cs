using BLL.DTOs;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.EF.Models;

namespace BLL.Services
{
    public class categoryService
    {
        public static List<categoryDTO> getAll()
        {
            var data = categoryRepo.getAll();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<category, categoryDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<categoryDTO>>(data);
            return converted;
        }
        public static categoryDTO get(int id)
        {
            var data = categoryRepo.get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<category, categoryDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<categoryDTO>(data);
            return converted;
        }
        public static bool create(categoryDTO n)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<categoryDTO, category>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<category>(n);
            var res = categoryRepo.create(converted);
            return res;
        }
        public static bool update(categoryDTO n)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<categoryDTO, category>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<category>(n);
            var res = categoryRepo.update(converted);
            return res;
        }
        public static bool delete(int id)
        {
            var res = categoryRepo.delete(id);
            return res;
        }

    }
}
