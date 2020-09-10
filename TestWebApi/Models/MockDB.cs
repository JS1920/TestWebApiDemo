using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApi.Models
{
    /// <summary>
    /// Mock DB class
    /// </summary>
    public static class MockDB
    {
        static MockDB()
        {
            Patients = new List<Patient>();
            Appointments = new List<Appointment>();
            InsertAllAppointment();
            InsertAllPatients();
        }

        public static List<Appointment> Appointments { get; set;}
        public static List<Patient> Patients { get; set;}

        internal static void InsertAllAppointment()
        {
            Appointments.Add(new Appointment() { Id = 1, PatientId = 2, AppointmentTime = Convert.ToDateTime("09/11/2020 11:00 AM"), Notes = "Doctor Note for patient 2", Year = 2020, Price = 20 });
            Appointments.Add(new Appointment() { Id = 2, PatientId = 5, AppointmentTime = Convert.ToDateTime("09/11/2020 11:15 AM"), Notes = "Doctor Note for patient 5", Year = 2020, Price = 20 });
            Appointments.Add(new Appointment() { Id = 3, PatientId = 3, AppointmentTime = Convert.ToDateTime("09/11/2020 11:30 AM"), Notes = "Doctor Note for patient 3", Year = 2020, Price = 20 });
            Appointments.Add(new Appointment() { Id = 4, PatientId = 1, AppointmentTime = Convert.ToDateTime("09/11/2020 1:00 PM"), Notes = "Doctor Note for patient 1", Year = 2020, Price = 20 });
            Appointments.Add(new Appointment() { Id = 5, PatientId = 4, AppointmentTime = Convert.ToDateTime("09/11/2020 3:00 PM"), Notes = "Doctor Note for patient 4", Year = 2020, Price = 20 });
        }

        internal static void InsertAllPatients()
        {
            Patients.Add(new Patient() { Id = 1, FirstName = "Patient First 1", LastName = "Patient Last 1", DateOfBirth = Convert.ToDateTime("11/01/1971"), Appointments = Appointments.Where(i => i.PatientId == 1).ToList() });
            Patients.Add(new Patient() { Id = 2, FirstName = "Patient First 2", LastName = "Patient Last 2", DateOfBirth = Convert.ToDateTime("12/13/1972"), Appointments = Appointments.Where(i => i.PatientId == 2).ToList() });
            Patients.Add(new Patient() { Id = 3, FirstName = "Patient First 3", LastName = "Patient Last 3", DateOfBirth = Convert.ToDateTime("03/15/1973"), Appointments = Appointments.Where(i => i.PatientId == 3).ToList() });
            Patients.Add(new Patient() { Id = 4, FirstName = "Patient First 4", LastName = "Patient Last 4", DateOfBirth = Convert.ToDateTime("07/27/1974"), Appointments = Appointments.Where(i => i.PatientId == 4).ToList() });
            Patients.Add(new Patient() { Id = 5, FirstName = "Patient First 5", LastName = "Patient Last 5", DateOfBirth = Convert.ToDateTime("10/06/1975"), Appointments = Appointments.Where(i => i.PatientId == 5).ToList() });
        }
    }
}
