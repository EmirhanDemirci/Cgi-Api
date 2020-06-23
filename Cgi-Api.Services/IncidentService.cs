using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using Cgi_Api.DataAccess.Data;
using Cgi_Api.Models;
using Cgi_Api.Services.Helpers;
using Cgi_Api.Services.Interfaces;

namespace Cgi_Api.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly ApplicationDbContext _dbContext;

        public IncidentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Incident incident, int id)
        {
            MailAddress to = new MailAddress(incident.Email);
            MailAddress from = new MailAddress("cgiproftaak@yandex.com");

            MailMessage message = new MailMessage(from, to);
            var dbUser2 = _dbContext.Users.FirstOrDefault(x => x.Id == id);

            message.Subject = "Good morning, employee";
            message.Body = $"Wilt u mijn taak overnemen Groetjes, {dbUser2.FirstName}";

            SmtpClient client = new SmtpClient("smtp.yandex.com", 587)
            {
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("cgiproftaak@yandex.com", "rachelsmolen"),

            };
            client.Send(message);
            incident.UserId = id;
            var dbUser = _dbContext.Incident.FirstOrDefault(x => x.UserId == id);
            _dbContext.Incident.Add(incident);
            _dbContext.SaveChanges();
        }

        public List<Incident> Get(int id)
        {
            List<Incident> emptyList = new List<Incident>();
            if (id != 0)
            {
                var incidentId = _dbContext.Incident.FirstOrDefault(x => x.UserId == id);
                if (incidentId != null && incidentId.UserId == id)
                {
                    var Incidents = _dbContext.Incident.ToList();
                    foreach (var item in Incidents)
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

