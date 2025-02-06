using System;
using System.Collections.Generic;

// Define the Patient class
class Patient
{
    public string PatientName { get; set; }
    public List<Doctor> Doctors { get; set; }

    public Patient(string name)
    {
        PatientName = name;
        Doctors = new List<Doctor>();
    }

    // Method to consult with a doctor
    public void ConsultWithDoctor(Doctor doctor)
    {
        if (!Doctors.Contains(doctor))
        {
            Doctors.Add(doctor);
            doctor.Consult(this);
        }
        else
        {
            Console.WriteLine($"{PatientName} has already consulted with Dr. {doctor.DoctorName}.");
        }
    }
}

// Define the Doctor class
class Doctor
{
    public string DoctorName { get; set; }
    public string Specialty { get; set; }
    public List<Patient> Patients { get; set; }

    public Doctor(string name, string specialty)
    {
        DoctorName = name;
        Specialty = specialty;
        Patients = new List<Patient>();
    }

    // Method to consult with a patient
    public void Consult(Patient patient)
    {
        if (!Patients.Contains(patient))
        {
            Patients.Add(patient);
        }
        Console.WriteLine($"Dr. {DoctorName} ({Specialty}) is consulting with {patient.PatientName}.");
    }

    // Display the patients seen by the doctor
    public void ShowPatients()
    {
        Console.WriteLine($"Dr. {DoctorName} has consulted the following patients:");
        if (Patients.Count == 0)
        {
            Console.WriteLine("No patients yet.");
        }
        else
        {
            foreach (var patient in Patients)
            {
                Console.WriteLine($"- {patient.PatientName}");
            }
        }
    }
}

// Define the Hospital class
class Hospital
{
    public string HospitalName { get; set; }
    public List<Doctor> Doctors { get; set; }
    public List<Patient> Patients { get; set; }

    public Hospital(string hospitalName)
    {
        HospitalName = hospitalName;
        Doctors = new List<Doctor>();
        Patients = new List<Patient>();
    }

    // Add a doctor to the hospital
    public void AddDoctor(Doctor doctor)
    {
        if (!Doctors.Contains(doctor))
        {
            Doctors.Add(doctor);
            Console.WriteLine($"Dr. {doctor.DoctorName} has been added to {HospitalName}");
        }
    }

    // Add a patient to the hospital
    public void AddPatient(Patient patient)
    {
        if (!Patients.Contains(patient))
        {
            Patients.Add(patient);
            Console.WriteLine($"{patient.PatientName} has been added to {HospitalName}");
        }
    }

    // Show the list of doctors and patients in the hospital
    public void ShowHospitalDetails()
    {
        Console.WriteLine($"Hospital: {HospitalName}");
        Console.WriteLine("Doctors:");
        foreach (var doctor in Doctors)
        {
            Console.WriteLine($"- Dr. {doctor.DoctorName}, Specialty: {doctor.Specialty}");
        }

        Console.WriteLine("Patients:");
        foreach (var patient in Patients)
        {
            Console.WriteLine($"- {patient.PatientName}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create the hospital
        Hospital hospital = new Hospital("Delhi AIIMS");

        // Create doctors
        Doctor doctor1 = new Doctor("Dr. Pranjal", "Surgery");
        Doctor doctor2 = new Doctor("Dr. Vijay", "Ortho");

        // Add doctors to the hospital
        hospital.AddDoctor(doctor1);
        hospital.AddDoctor(doctor2);

        // Create patients
        Patient patient1 = new Patient("Vaibhav");
        Patient patient2 = new Patient("Ankit");

        // Add patients to the hospital
        hospital.AddPatient(patient1);
        hospital.AddPatient(patient2);

        // Patients consult with doctors
        patient1.ConsultWithDoctor(doctor1); 
        patient2.ConsultWithDoctor(doctor1); 
        patient1.ConsultWithDoctor(doctor2); 

        // Show the patients consulted by each doctor
        doctor1.ShowPatients();
        doctor2.ShowPatients();

        // Show the list of all doctors and patients in the hospital
        hospital.ShowHospitalDetails();
    }
}
