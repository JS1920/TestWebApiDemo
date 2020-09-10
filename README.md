# TestWebApi


Create a Asp MVC Web API project in visual studio called: TestWebApi

Add 2 controllers to the api and each should contain a Get, Post, Put and Delete method:
PatientsController
AppointmentsController

Create 2 models with the following properties:
Appointment
Id (int)
PatientId (int)
AppointmentTime (DateTime)
Notes (string) (length = 200)

Patient
Id (int)
FirstName (string) (length = 50)
LastName (string) (length = 50)
DateOfBirth (datetime)
Appointments (List)

Create a static data source for getting patients and appointments. Each list should contain 5 entries.(e.g.):

var patients = new List<Patient>();
patients.Add(new Patient () Id = 1, FirstName = "Patient First 1", LastName = "Patient Last 1", DateOfBirth = "01/01/1971", );
Create a project (any type you choose) and use it to retrieve and save data from the API
