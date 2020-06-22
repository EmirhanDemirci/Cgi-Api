using System;
using System.Collections.Generic;
using System.Text;
using Cgi_Api.Models;

namespace Cgi_Api.Services.Interfaces
{
    public interface IShiftService
    {
        Shift Get(int id);
        List<Shift> GetAll();
        void Put(int id, Shift shift);
        void Post(Shift shift);
        Shift Delete(int id);
    }
}
