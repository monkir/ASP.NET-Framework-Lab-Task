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
    public class newsService
    {
        public static List<newsDTO> getAll()
        {
            var data = newsRepo.getAll();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<news, newsDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<newsDTO>>(data);
            return converted;
        }
        public static newsDTO get(int id)
        {
            var data = newsRepo.get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<news, newsDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<newsDTO>(data);
            return converted;
        }
        public static bool create(newsDTO n)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<news, newsDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<news>(n);
            var res = newsRepo.create(converted);
            return res;
        }
        public static bool update(newsDTO n)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<news, newsDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<news>(n);
            var res = newsRepo.update(converted);
            return res;
        }
        public static bool delete(int id)
        {
            var res = newsRepo.delete(id);
            return res;
        }
        public static List<newsDTO> getNewsByCategory(string cname)
        {
            List<news> result = (from c in categoryRepo.getAll()
                                 where c.name.Equals(cname)
                                 select c.newsList).SingleOrDefault();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<news, newsDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<newsDTO>>(result);
            return converted;
        }
        public static List<newsDTO> getNewsByDate(DateTime date)
        {
            List<news> result = (from n in newsRepo.getAll()
                                 where n.date.Equals(date)
                                 select n).ToList();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<news, newsDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<newsDTO>>(result);
            return converted;
        }
        public static List<newsDTO> getNewsByCategoryAndDate(string cname, DateTime date)
        {
            List<news> nListByCategory = (from c in categoryRepo.getAll()
                                          where c.name.Equals(cname)
                                          select c.newsList).SingleOrDefault();
            List<news> result = (from n in nListByCategory
                                 where n.date.Equals(date)
                                 select n).ToList();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<news, newsDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<newsDTO>>(result);
            return converted;
        }
    }
}
