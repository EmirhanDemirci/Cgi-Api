using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cgi_Api.DataAccess.Data;
using Cgi_Api.Models;
using Cgi_Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cgi_Api.Services
{
    public class ShiftServices : IShiftService
    {
        private readonly ApplicationDbContext _dbContext;

        public ShiftServices(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Shift Get(int id)
        {
            var cgiShift = _dbContext.Shift.Find(id);

            if (cgiShift == null)
            {
                //if it doesnt exists
                return null;
            }

            return cgiShift;
        }

        public List<Shift> GetAll()
        {
            var users = _dbContext.Shift.ToList();
            return users;
        }

        public void Put(int id, Shift shift)
        {

            if (id == shift.Id)
            {
                _dbContext.Entry(shift).State = EntityState.Modified;
                try
                {
                    _dbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public void Post(Shift shift)
        {
            _dbContext.Shift.Add(shift);
            _dbContext.SaveChanges();
        }

        public Shift Delete(int id)
        {
            var cgiShift = _dbContext.Shift.Find(id);
            if (cgiShift != null)
            {
                _dbContext.Shift.Remove(cgiShift);
                _dbContext.SaveChanges();

                return cgiShift;
            }
            return null;
        }
    }
}
