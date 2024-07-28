# Doctor Appointment Booking System

This is a Doctor Appointment Booking System built using ASP.NET Core Web API and PostgreSQL. The system allows patients to book appointments with doctors, manage their profiles, and provide feedback. Doctors can view their appointments and patient details. Admins can manage doctors, view patient information, and oversee appointments and feedback.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Database Setup](#database-setup)
- [Running the Application](#running-the-application)
- [API Endpoints](#api-endpoints)

## Features

- **Admin Module:**
  - Add, view, and manage doctors.
  - View patient details.
  - View appointment details.
  - View feedback from patients.

- **Doctor Module:**
  - View profile.
  - View appointments.
  - View patient details.

- **Patient Module:**
  - Register and log in.
  - Manage profile.
  - Book appointments.
  - View booking history.
  - Search for doctors.
  - Provide feedback.

## Technologies Used

- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- Swagger for API documentation

## Database Setup

Run the following SQL script to set up your PostgreSQL database:

```sql
-- Create the database
CREATE DATABASE doctor_appointment;

-- Connect to the database
\c doctor_appointment;

-- Create the tables
CREATE TABLE doctors (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100),
    speciality VARCHAR(100)
);

CREATE TABLE patients (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100)
);

CREATE TABLE appointments (
    id SERIAL PRIMARY KEY,
    doctor_id INT REFERENCES doctors(id),
    patient_id INT REFERENCES patients(id),
    date TIMESTAMP,
    slot VARCHAR(50)
);

CREATE TABLE feedbacks (
    id SERIAL PRIMARY KEY,
    patient_id INT REFERENCES patients(id),
    content TEXT
);
```

## Running the Application

1. Clone the repository:
   ```sh
   git clone https://github.com/yourusername/doctor-appointment-booking.git
   cd doctor-appointment-booking
   ```

2. Configure the PostgreSQL connection string in `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=doctor_appointment;Username=yourusername;Password=yourpassword"
     },
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft.AspNetCore": "Warning"
       }
     },
     "AllowedHosts": "*"
   }
   ```

3. Run the application:
   ```sh
   dotnet run
   ```

4. Open your browser and navigate to `https://localhost:5001/swagger` to view the API documentation.

## API Endpoints

### Admin Endpoints

- **Add Doctor**
  - **POST** `/api/doctors/add`
  - Request Body:
    ```json
    {
      "name": "Doctor Name",
      "speciality": "Speciality"
    }
    ```

- **Get Doctors**
  - **GET** `/api/doctors/all`

- **Get Doctor by ID**
  - **GET** `/api/doctors/{id}`

### Doctor Endpoints

- **Get Profile**
  - **GET** `/api/doctors/get-profile/{id}`

- **Get Appointments**
  - **GET** `/api/appointments/doctor/{doctorId}`

- **Get Patients**
  - **GET** `/api/patients/doctor/{doctorId}`

### Patient Endpoints

- **Register**
  - **POST** `/api/patients/register`
  - Request Body:
    ```json
    {
      "name": "Patient Name"
    }
    ```

- **Get Patient by ID**
  - **GET** `/api/patients/{id}`

- **Book Appointment**
  - **POST** `/api/appointments/book`
  - Request Body:
    ```json
    {
      "doctor_id": 1,
      "patient_id": 1,
      "date": "2024-08-01T09:00:00",
      "slot": "Morning"
    }
    ```

- **Get Appointment by ID**
  - **GET** `/api/appointments/{id}`

- **Get Booking History**
  - **GET** `/api/appointments/patient/{patientId}`

- **Search Doctor**
  - **GET** `/api/doctors/search`
  - Query Parameters: `search` (doctor name or speciality)

### Feedback Endpoints

- **Give Feedback**
  - **POST** `/api/feedbacks/give`
  - Request Body:
    ```json
    {
      "patient_id": 1,
      "content": "Great service!"
    }
    ```

- **Get Feedbacks**
  - **GET** `/api/feedbacks/all`

- **Get Feedback by ID**
  - **GET** `/api/feedbacks/{id}`

## Summary and Explanation

The Doctor Appointment Booking System is designed to manage the scheduling and booking of appointments between patients and doctors. It also includes functionalities for feedback management. The system is built using ASP.NET Core Web API and PostgreSQL, leveraging Entity Framework Core for database interactions. The project uses a database-first approach, and the steps include creating a PostgreSQL database, generating the database schema, scaffolding the models and DbContext, implementing services, and defining API endpoints.

### Project Structure

1. **Models**: Define the data models for Doctors, Patients, Appointments, and Feedbacks.
2. **Data**: Configure the DbContext for database interactions.
3. **DTOs**: Define Data Transfer Objects for API requests and responses.
4. **Extensions**: Provide static methods for converting between entities and DTOs.
5. **Services**: Implement business logic services.
6. **Controllers**: Define the API endpoints.
7. **Utils**: Implement the Result pattern for standardized API responses.

### Database Setup

1. **Create Database and Tables**:
   ```sql
   -- Create the database
   CREATE DATABASE doctor_appointment;

   -- Connect to the database
   \c doctor_appointment;

   -- Create the tables
   CREATE TABLE doctors (
       id SERIAL PRIMARY KEY,
       name VARCHAR(100),
       speciality VARCHAR(100)
   );

   CREATE TABLE patients (
       id SERIAL PRIMARY KEY,
       name VARCHAR(100)
   );

   CREATE TABLE appointments (
       id SERIAL PRIMARY KEY,
       doctor_id INT REFERENCES doctors(id),
       patient_id INT REFERENCES patients(id),
       date TIMESTAMP,
       slot VARCHAR(50)
   );

   CREATE TABLE feedbacks (
       id SERIAL PRIMARY KEY,
       patient_id INT REFERENCES patients(id),
       content TEXT
   );
   ```

2. **Insert Sample Data**:
   ```sql
   -- Insert data into Doctors table
   INSERT INTO doctors (name, speciality) VALUES 
   ('Dr. John Doe', 'Cardiology'),
   ('Dr. Jane Smith', 'Neurology'),
   ('Dr. Emily Davis', 'Pediatrics'),
   ('Dr. Michael Brown', 'Orthopedics'),
   ('Dr. Sarah Wilson', 'Dermatology'),
   ('Dr. David Clark', 'Gastroenterology'),
   ('Dr. Linda Johnson', 'Oncology'),
   ('Dr. James Anderson', 'Ophthalmology'),
   ('Dr. Robert Thompson', 'Endocrinology'),
   ('Dr. Mary Martinez', 'Rheumatology'),
   ('Dr. Patricia White', 'Psychiatry'),
   ('Dr. Christopher Harris', 'Urology'),
   ('Dr. Barbara Lewis', 'Hematology'),
   ('Dr. Richard Walker', 'Pulmonology'),
   ('Dr. Susan Hall', 'Nephrology'),
   ('Dr. Joseph Allen', 'Immunology'),
   ('Dr. Karen Young', 'Allergy and Immunology'),
   ('Dr. Thomas King', 'General Surgery'),
   ('Dr. Margaret Wright', 'Family Medicine'),
   ('Dr. Charles Scott', 'Infectious Disease');

   -- Insert data into Patients table
   INSERT INTO patients (name) VALUES 
   ('Alice Johnson'),
   ('Bob Smith'),
   ('Carol Williams'),
   ('David Brown'),
   ('Eve Davis'),
   ('Frank Miller'),
   ('Grace Wilson'),
   ('Hank Moore'),
   ('Ivy Taylor'),
   ('Jack Anderson'),
   ('Kathy Thomas'),
   ('Larry Jackson'),
   ('Mona White'),
   ('Nick Harris'),
   ('Olivia Martin'),
   ('Paul Thompson'),
   ('Quincy Garcia'),
   ('Rachel Martinez'),
   ('Steve Robinson'),
   ('Tina Clark');

   -- Insert data into Appointments table
   INSERT INTO appointments (doctor_id, patient_id, date, slot) VALUES 
   (1, 1, '2024-08-01 09:00:00', 'Morning'),
   (2, 2, '2024-08-02 10:00:00', 'Morning'),
   (3, 3, '2024-08-03 11:00:00', 'Morning'),
   (4, 4, '2024-08-04 14:00:00', 'Afternoon'),
   (5, 5, '2024-08-05 15:00:00', 'Afternoon'),
   (6, 6, '2024-08-06 09:00:00', 'Morning'),
   (7, 7, '2024-08-07 10:00:00', 'Morning'),
   (8, 8, '2024-08-08 11:00:00', 'Morning'),
   (9, 9, '2024-08-09 14:00:00', 'Afternoon'),
   (10, 10, '2024-08-10 15:00:00', 'Afternoon'),
   (11, 11, '2024-08-11 09:00:00', 'Morning'),
   (12, 12, '2024-08-12 10:00:00', 'Morning'),
   (13, 13, '2024-08-13 11:00:00', 'Morning'),
   (14, 14, '2024-08-14 14:00:00', 'Afternoon'),
   (15, 15, '2024-08-15 15:00:00', 'Afternoon'),
   (16, 16, '2024-08-16 09:00:00', 'Morning'),
   (17, 17, '2024-08-17 10:00:00', 'Morning'),
   (18, 18, '2024-08-18 11:00:00', 'Morning'),
   (19, 19, '2024-08-19 14:00:00', 'Afternoon'),
   (20, 20, '2024-08-20 15:00:00', 'Afternoon');

   -- Insert data into Feedbacks table
   INSERT INTO feedbacks (patient_id, content) VALUES 
   (1, 'Excellent care and attention to detail.'),
   (2, 'Very knowledgeable and helpful.'),
   (3, 'Friendly staff and a great experience.'),
   (4, 'Quick and efficient service.'),
   (5, 'Highly recommend this doctor.'),
   (6, 'Professional and courteous.'),
   (7, 'Great experience, will visit again.'),
   (8, 'Very satisfied with the treatment.'),
   (9, 'Helpful and caring staff.'),
   (10, 'Overall a positive experience.'),
   (11, 'Doctor was very attentive and kind.'),
   (12, 'Smooth process and excellent care.'),
   (13, 'Impressed with the professionalism.'),
   (14, 'Doctor was very patient and understanding.'),
   (15, 'Great service and friendly staff.'),
   (16, 'Highly professional and thorough.'),
   (17, 'Doctor provided clear explanations.'),
   (18, 'Efficient and compassionate care.'),
   (19, 'Very satisfied with the visit.'),
   (20, 'Exceptional service and care.');
   ```

3. **Scaffold Models and DbContext**:
   ```sh
   dotnet ef dbcontext scaffold "Host=localhost;Database=doctor_appointment;Username=yourusername;Password=yourpassword" Npgsql.EntityFrameworkCore.PostgreSQL -o Models -d
   ```

### API Implementation

1. **Models**:
   Define the data models for Doctors, Patients, Appointments, and Feedbacks.

2. **Data**:
   Configure the `BookingContext` for database interactions.

3. **DTOs**:
   Define Data Transfer Objects for API requests and responses.

4. **Extensions**:
   Provide static methods for converting between entities and DTOs.

5. **Services**:
   Implement business logic services.

6. **Controllers**:
   Define the API endpoints for Admin, Doctor, Patient, and Feedback services.

7. **Utils**:
   Implement the Result pattern for standardized API responses.

### Controllers

Implement the controllers to handle API requests using the services.

#### DoctorsController

```csharp
using Microsoft.AspNetCore.Mvc;
using DotNetCore8WebApi.DoctorAppointmentBookingSystem.DTOs;
using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Services;
using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Utils;

namespace DotNetCore8WebApi.DoctorAppointmentBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddDoctor([FromBody] CreateDoctorDTO doctorDto)
        {
            var result = await _doctorService.AddDoctorAsync(doctorDto);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetDoctors()
        {
            var result = await _doctorService.GetDoctorsAsync();
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctor(int id)
        {
            var result = await _doctorService.GetDoctorByIdAsync(id);
            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
        }
    }
}
```

#### PatientsController

```csharp
using Microsoft.AspNetCore.Mvc;
using DotNetCore8WebApi.DoctorAppointmentBookingSystem.DTOs;
using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Services;
using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Utils;

namespace DotNetCore8WebApi.DoctorAppointmentBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterPatient([FromBody] CreatePatientDTO patientDto)
        {
            var result = await _patientService.RegisterPatientAsync(patientDto);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetPatients()
        {
            var result = await _patientService.GetPatientsAsync();
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(int id)
        {
            var result = await _patientService.GetPatientByIdAsync(id);
            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
        }
    }
}
```

#### AppointmentsController

```csharp
using Microsoft.AspNetCore.Mvc;
using DotNetCore8WebApi.DoctorAppointmentBookingSystem.DTOs;
using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Services;
using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Utils;

namespace DotNetCore8WebApi.DoctorAppointmentBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("book")]
        public async Task<IActionResult> BookAppointment([FromBody] CreateAppointmentDTO appointmentDto)
        {
            var result = await _appointmentService.BookAppointmentAsync(appointmentDto);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAppointments()
        {
            var result = await _appointmentService.GetAppointmentsAsync();
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointment(int id)
        {
            var result = await _appointmentService.GetAppointmentByIdAsync(id);
            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
        }

        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> GetAppointmentsByDoctor(int doctorId)
        {
            var result = await _appointmentService.GetAppointmentsByDoctorIdAsync(doctorId);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetAppointmentsByPatient(int patientId)
        {
            var result = await _appointmentService.GetAppointmentsByPatientIdAsync(patientId);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }
    }
}
```

#### FeedbacksController

```csharp
using Microsoft.AspNetCore.Mvc;
using DotNetCore8WebApi.DoctorAppointmentBookingSystem.DTOs;
using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Services;
using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Utils;

namespace DotNetCore8WebApi.DoctorAppointmentBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbacksController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpPost("give")]
        public async Task<IActionResult> GiveFeedback([FromBody] CreateFeedbackDTO feedbackDto)
        {
            var result = await _feedbackService.GiveFeedbackAsync(feedbackDto);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetFeedbacks()
        {
            var result = await _feedbackService.GetFeedbacksAsync();
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeedback(int id)
        {
            var result = await _feedbackService.GetFeedbackByIdAsync(id);
            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
        }
    }
}
```

### Program.cs

Configure the services and middleware in `Program.cs`.

```csharp
using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Data;
using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<BookingContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
```

