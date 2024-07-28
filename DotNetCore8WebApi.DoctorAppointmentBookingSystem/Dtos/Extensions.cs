namespace DotNetCore8WebApi.DoctorAppointmentBookingSystem.Dtos
{
    public static class Extensions
    {
        public static DoctorDTO ToDto(this Doctor doctor)
        {
            return new DoctorDTO
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Speciality = doctor.Speciality
            };
        }

        public static Doctor ToEntity(this CreateDoctorDTO doctorDto)
        {
            return new Doctor
            {
                Name = doctorDto.Name,
                Speciality = doctorDto.Speciality
            };
        }

        public static PatientDTO ToDto(this Patient patient)
        {
            return new PatientDTO
            {
                Id = patient.Id,
                Name = patient.Name
            };
        }

        public static Patient ToEntity(this CreatePatientDTO patientDto)
        {
            return new Patient
            {
                Name = patientDto.Name
            };
        }

        public static AppointmentDTO ToDto(this Appointment appointment)
        {
            return new AppointmentDTO
            {
                Id = appointment.Id,
                DoctorId = (int)appointment.DoctorId,
                PatientId = (int)appointment.PatientId,
                Date = (DateTime)appointment.Date,
                Slot = appointment.Slot
            };
        }

        public static Appointment ToEntity(this CreateAppointmentDTO appointmentDto)
        {
            return new Appointment
            {
                DoctorId = appointmentDto.DoctorId,
                PatientId = appointmentDto.PatientId,
                Date = appointmentDto.Date,
                Slot = appointmentDto.Slot
            };
        }

        public static FeedbackDTO ToDto(this Feedback feedback)
        {
            return new FeedbackDTO
            {
                Id = feedback.Id,
                PatientId = (int)feedback.PatientId,
                Content = feedback.Content
            };
        }

        public static Feedback ToEntity(this CreateFeedbackDTO feedbackDto)
        {
            return new Feedback
            {
                PatientId = feedbackDto.PatientId,
                Content = feedbackDto.Content
            };
        }
    }
}