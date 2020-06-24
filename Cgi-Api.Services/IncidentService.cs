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
            MailAddress from = new MailAddress("cgiproftaak75@gmail.com");
            MailMessage message = new MailMessage(from, to);
            var dbUser2 = _dbContext.Users.FirstOrDefault(x => x.Id == id);

            message.Subject = "Good morning, employee";
            message.Body = $@"<img src=""https://bntqb.org/wp-content/uploads/2019/04/CGI_logo.png"" width=""250px"" heigth=""250px"" alt=""Logo"" /><br /> I need help with a incident can you help me? <br /> Greetings, {dbUser2.FirstName} {dbUser2.LastName}";
            message.IsBodyHtml = true;
            try
            {
                using (var client = new SmtpClient("smtp.gmail.com"))
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("cgiproftaak75@gmail.com", "rachelsmolen");
                    client.EnableSsl = true;
                    client.Port = 587;
                    client.Send(message);
                };
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
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

        public void Delete(int incidentId, int id)
        {
            if (incidentId != 0 && id != 0)
            {
                var user = _dbContext.Incident.Find(id);
                if (user != null)
                {
                    var userToBeDeleted = _dbContext.Incident.Find(incidentId);

                    MailAddress to = new MailAddress(userToBeDeleted.Email);
                    MailAddress from = new MailAddress("cgiproftaak75@gmail.com");
                    MailMessage message = new MailMessage(from, to);
                    var dbUser2 = _dbContext.Users.FirstOrDefault(x => x.Id == id);

                    message.Subject = "Deleted incident, employee";
                    message.Body = $@"<img src=""https://bntqb.org/wp-content/uploads/2019/04/CGI_logo.png"" width=""250px"" heigth=""250px"" alt=""Logo"" /><br /> Deleted the incident <br /> Greetings, {dbUser2.FirstName} {dbUser2.LastName}";
                    message.IsBodyHtml = true;
                    try
                    {
                        using (var client = new SmtpClient("smtp.gmail.com"))
                        {
                            client.UseDefaultCredentials = false;
                            client.Credentials = new NetworkCredential("cgiproftaak75@gmail.com", "rachelsmolen");
                            client.EnableSsl = true;
                            client.Port = 587;
                            client.Send(message);
                        };
                    }

                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }


                    if (userToBeDeleted != null)
                    {
                        _dbContext.Incident.Remove(userToBeDeleted);
                        _dbContext.SaveChanges();
                    }
                }
            }
        }

        public void Success(int incidentId, int id)
        {
            if (incidentId != 0 && id != 0)
            {
                var user = _dbContext.Incident.Find(id);
                if (user != null)
                {
                    var userToBeDeleted = _dbContext.Incident.Find(incidentId);

                    MailAddress to = new MailAddress(userToBeDeleted.Email);
                    MailAddress from = new MailAddress("cgiproftaak75@gmail.com");
                    MailMessage message = new MailMessage(from, to);
                    var dbUser2 = _dbContext.Users.FirstOrDefault(x => x.Id == id);

                    message.Subject = "Completed incident, employee";
                    message.Body = $@"<img src=""https://bntqb.org/wp-content/uploads/2019/04/CGI_logo.png"" width=""250px"" heigth=""250px"" alt=""Logo"" /><br /> Incident fixed <br /> Greetings, {dbUser2.FirstName} {dbUser2.LastName}";
                    message.IsBodyHtml = true;
                    try
                    {
                        using (var client = new SmtpClient("smtp.gmail.com"))
                        {
                            client.UseDefaultCredentials = false;
                            client.Credentials = new NetworkCredential("cgiproftaak75@gmail.com", "rachelsmolen");
                            client.EnableSsl = true;
                            client.Port = 587;
                            client.Send(message);
                        };
                    }

                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }


                    if (userToBeDeleted != null)
                    {
                        _dbContext.Incident.Remove(userToBeDeleted);
                        _dbContext.SaveChanges();
                    }
                }
            }
        }
    }
}

