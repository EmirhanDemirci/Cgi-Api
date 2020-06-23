using System;
using System.Collections.Generic;
using System.Text;
using Cgi_Api.Models;

namespace Cgi_Api.Services.Interfaces
{
    public interface IScheduleService
    {
        void create(Schedule schedule, int userId);
        void delete(Schedule schedule);
        List<Schedule> Get(int id);
    }
}
