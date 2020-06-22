using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
            var dbuser2 = _dbContext.Users.FirstOrDefault(x => x.Id == userId);
            var dbUser = _dbContext.Schedule.FirstOrDefault(x => x.User.Id == schedule.User.Id);
            if (dbUser == null)
            {
                _dbContext.Schedule.Add(schedule);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("User not valid");
            }
        }

        public void delete(Schedule schedule)
        {
            throw new NotImplementedException();
        }
    }
}
