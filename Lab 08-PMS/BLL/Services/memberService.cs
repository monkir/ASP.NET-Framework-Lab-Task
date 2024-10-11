using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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
        public static List<projectDTO> openProject()
        {
            var data = (from p in DataAccessChannel.getProject().All()
                        where p.status_now.Equals("open")
                        select p).ToList();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<project, projectDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<List<projectDTO>>(data);
        }
        public static List<projectDTO> myProjects(int mid)
        {
            var eData = DataAccessChannel.getMember().get(mid).enrollments;
            var pData = (from e in eData select e.project).ToList();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<project, projectDTO>());
            var mapper = config.CreateMapper();
            return mapper.Map<List<projectDTO>>(pData);
        }
        public static List<projectDTO> myProjectsInProgress(int mid)
        {
            var eData = DataAccessChannel.getMember().get(mid).enrollments;
            var pData = (
                             from e in eData 
                             where e.project.status_now.Equals("in progress") 
                             select e.project
                         ).ToList();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<project, projectDTO>());
            var mapper = config.CreateMapper();
            return mapper.Map<List<projectDTO>>(pData);
        }
        public static List<projectDTO> myProjectsCompleted(int mid)
        {
            var eData = DataAccessChannel.getMember().get(mid).enrollments;
            var pData = (
                             from e in eData
                             where e.project.status_now.Equals("completed")
                             select e.project
                         ).ToList();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<project, projectDTO>());
            var mapper = config.CreateMapper();
            return mapper.Map<List<projectDTO>>(pData);
        }
        public static bool enrollment(int mid, int pid)
        {
            var data = (from e in DataAccessChannel.getEnrollment().All()
                        where e.pid == pid && e.mid == mid
                        select e).ToList();
            if(data.Count > 0) { return false; }
            enrollmentDTO obj = new enrollmentDTO()
            {
                mid = mid,
                pid = pid
            };
            var config = new MapperConfiguration(cfg => cfg.CreateMap<enrollmentDTO, enrollment>());
            var mapper = new Mapper(config);
            return DataAccessChannel.getEnrollment().create(mapper.Map<enrollment>(obj));
        }
    }
}
