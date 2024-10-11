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
        public static List<projectDTO> myProjectsOpened(int supID)
        {
            var data = (from p in DataAccessChannel.getSupervisor().get(supID).projects
                        where p.status_now.Equals("open")
                        select p).ToList();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<project, projectDTO>());
            var mapper = config.CreateMapper();
            return mapper.Map<List<projectDTO>>(data);
        }
        public static List<projectDTO> myProjectsInProgress(int supID)
        {
            var data = (from p in DataAccessChannel.getSupervisor().get(supID).projects
                        where p.status_now.Equals("in progress")
                        select p).ToList();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<project, projectDTO>());
            var mapper = config.CreateMapper();
            return mapper.Map<List<projectDTO>>(data);
        }
        public static List<projectDTO> myProjectsCompleted(int supID)
        {
            var data = (from p in DataAccessChannel.getSupervisor().get(supID).projects
                        where p.status_now.Equals("completed")
                        select p).ToList();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<project, projectDTO>());
            var mapper = config.CreateMapper();
            return mapper.Map<List<projectDTO>>(data);
        }
        public static bool createProject(projectDTO proObj)
        {
            proObj.created_time = DateTime.Now;
            proObj.status_now = "open";
            var config = new MapperConfiguration(cfg => cfg.CreateMap<projectDTO, project>());
            var mapper = config.CreateMapper();
            return DataAccessChannel.getProject().create(mapper.Map<project>(proObj));
        }
        public static bool confirmProject(int sid, int pid)
        {
            var proObj = DataAccessChannel.getProject().get(pid);
            if (proObj.enrollments.ToList().Count < 3 || proObj.status_now.Equals("open") == false)
            {
                return false;
            }
            proObj.status_now = "in progress";
            return DataAccessChannel.getProject().update(proObj);
        }
        public static bool completeProject(int sid, int pid)
        {
            var proObj = DataAccessChannel.getProject().get(pid);
            if (proObj.status_now.Equals("in progress") == false)
            {
                return false;
            }
            proObj.status_now = "completed";
            return DataAccessChannel.getProject().update(proObj);
        }
    }
}
