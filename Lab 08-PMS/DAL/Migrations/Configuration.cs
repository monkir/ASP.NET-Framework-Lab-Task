namespace DAL.Migrations
{
    using DAL.EF.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.pmsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.pmsContext context)
        {
            /*for (int i = 0; i < 10; i++)
            {
                context.member.Add(
                    new EF.Models.member()
                    {
                        username = "member" + i.ToString(),
                        password = "123",
                    }
                );
                context.supervisor.Add(
                    new EF.Models.supervisor()
                    {
                        username = "super" + i.ToString(),
                        password = "123",
                    }
                );
            }
            Random random = new Random();
            for (int i = 0; i < 30; i++)
            {
                project p = new EF.Models.project()
                {
                    sid = random.Next(1, 10),
                    name = "project" + i.ToString(),
                    description = Guid.NewGuid().ToString(),
                    created_time = DateTime.Today,
                    status_now = "open"
                };
                context.project.AddOrUpdate(p);
            }*/
        }
    }
}
