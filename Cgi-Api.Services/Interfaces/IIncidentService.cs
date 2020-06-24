using System;
using System.Collections.Generic;
using System.Text;
using Cgi_Api.Models;

namespace Cgi_Api.Services.Interfaces
{
    public interface IIncidentService
    { 
        void Create(Incident incident, int id);
        List<Incident> Get(int id);
        void Delete(int incidentId, int id);
        void Success(int incidentId, int id);
    }
}
