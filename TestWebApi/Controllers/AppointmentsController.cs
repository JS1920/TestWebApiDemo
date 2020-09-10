using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TestWebApi.Models;
using System.Data.Entity;

namespace TestWebApi.Controllers
{
    public class AppointmentsController : ApiController
    {
        // GET: api/Appointments
        public IEnumerable<Appointment> Get()
        {
            return MockDB.Appointments.ToList();
        }

        // GET: api/Appointments/5
        public Appointment Get(int id)
        {
            return MockDB.Appointments.Where(a => a.Id == id).FirstOrDefault();
        }

        // POST: api/Appointments
        public HttpResponseMessage Post([FromBody]Appointment appointment)
        {
            int maxId = MockDB.Appointments.OrderByDescending(a => a.Id).Select(a => a.Id).FirstOrDefault();
            try
            {
                MockDB.Appointments.Add(new Appointment() { Id = maxId + 1, PatientId = appointment.PatientId, AppointmentTime = appointment.AppointmentTime, Notes = appointment.Notes, Year = appointment.Year, Price = appointment.Price });
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,appointment);
            }
            return Request.CreateResponse(HttpStatusCode.OK, appointment);
        }

        // PUT: api/Appointments/5
        public HttpResponseMessage Put(int id, [FromBody]Appointment appointment)
        {

            var appointmentToUpdate =   MockDB.Appointments.Where(a => a.Id == appointment.Id).FirstOrDefault();
            try
            {
                if (appointmentToUpdate != null)
                {
                    appointmentToUpdate.Notes += appointment.Notes;

                    if (appointmentToUpdate.AppointmentTime != appointment.AppointmentTime)
                        appointmentToUpdate.AppointmentTime = appointment.AppointmentTime;

                    if (appointmentToUpdate.Price != appointment.Price)
                        appointmentToUpdate.Price = appointment.Price;

                    if (appointmentToUpdate.Year != appointment.Year)
                        appointmentToUpdate.Year = appointment.Year;
                }
                else { }
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, appointment);
            }
            return Request.CreateResponse(HttpStatusCode.OK, appointment);
        }

        // DELETE: api/Appointments/5
        public HttpResponseMessage Delete(int id)
        {
            Appointment item = MockDB.Appointments.Where(a => a.Id == id).FirstOrDefault();
            try
            {
                if (item != null)
                {
                    MockDB.Appointments.Remove(item);
                }
                else { }
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, id);
            }
            return Request.CreateResponse(HttpStatusCode.OK, id);
        }
    }
}
