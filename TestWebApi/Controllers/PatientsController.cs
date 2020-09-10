using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestWebApi.Models;

namespace TestWebApi.Controllers
{
    public class PatientsController : ApiController
    {
        // GET: api/Patients
        public IEnumerable<Patient> Get()
        {
            return MockDB.Patients.ToList();
        }

        // GET: api/Patients/5
        public Patient Get(int id)
        {
            return MockDB.Patients.Where(a => a.Id == id).FirstOrDefault();
        }

        // POST: api/Patients
        public HttpResponseMessage Post([FromBody]Patient patient)
        {
            int maxId = MockDB.Patients.OrderByDescending(a => a.Id).Select(a => a.Id).FirstOrDefault();
            var appntmnts = MockDB.Appointments.Where(a => a.PatientId == patient.Id).ToList();
            try
            {
                MockDB.Patients.Add(new Patient() { Id = maxId + 1, FirstName = patient.FirstName, LastName = patient.LastName, DateOfBirth = patient.DateOfBirth, Appointments = appntmnts});
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, patient);
            }
            return Request.CreateResponse(HttpStatusCode.OK, patient);
        }

        // PUT: api/Patients/5
        public HttpResponseMessage Put(int id, [FromBody]Patient patient)
        {
            var patientToUpdate = MockDB.Patients.Where(a => a.Id == patient.Id).FirstOrDefault();
            try
            {
                if (patientToUpdate != null)
                {

                    if (patientToUpdate.FirstName != patient.FirstName)
                        patientToUpdate.FirstName = patient.FirstName;

                    if (patientToUpdate.LastName != patient.LastName)
                        patientToUpdate.LastName = patient.LastName;

                    if (patientToUpdate.DateOfBirth != patient.DateOfBirth)
                        patientToUpdate.DateOfBirth = patient.DateOfBirth;

                    if (patientToUpdate.Appointments.Count()!= patient.Appointments.Count())
                    {
                        patientToUpdate.Appointments = patient.Appointments;
                    }
                }
                else { }
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, patient);
            }
            return Request.CreateResponse(HttpStatusCode.OK, patient);
        }

        // DELETE: api/Patients/5
        public HttpResponseMessage Delete(int id)
        {
            Patient item = MockDB.Patients.Where(a => a.Id == id).FirstOrDefault();
            try
            {
                if (item != null)
                {
                    MockDB.Patients.Remove(item);
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
