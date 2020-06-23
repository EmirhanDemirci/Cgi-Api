using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Cgi_Api.DataAccess.Data;
using Cgi_Api.Models;
using Cgi_Api.Services.Interfaces;

namespace Cgi_Api.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly ApplicationDbContext _dbContext;

        public ScheduleService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void create(Schedule schedule, int userId)
        {
            schedule.UserId = userId;
            var dbUser = _dbContext.Schedule.FirstOrDefault(x => x.UserId == schedule.UserId);
            var date = schedule.Date.AddDays(1);
            schedule.Date = date;
            _dbContext.Schedule.Add(schedule);
            _dbContext.SaveChanges();
        }

        public void delete(Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public List<Schedule> Get(int id)
        {
            List<Schedule> emptyList = new List<Schedule>();
            if (id != 0)
            {
                var scheduleId = _dbContext.Schedule.FirstOrDefault(x => x.UserId == id);
                if (scheduleId != null && scheduleId.UserId == id)
                {
                    var ScheduleTasks = _dbContext.Schedule.ToList();
                    foreach (var item in ScheduleTasks)
                    {
                        if (item.UserId == id)
                        {
                            emptyList.Add(item);
                        }
                    }
                    return emptyList;
                }
            }
            return null;
        }
    }
}
