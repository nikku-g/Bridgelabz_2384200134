using System;
using System.Collections.Generic;

class HospitalTriageSystem
{
    // Patient class to represent each patient with a name and severity
    public class Patient
    {
        public string Name { get; set; }
        public int Severity { get; set; }

        public Patient(string name, int severity)
        {
            Name = name;
            Severity = severity;
        }
    }

    // Method to simulate the triage system using a PriorityQueue
    public static void TriagePatients(List<Patient> patients)
    {
        // Create a PriorityQueue where higher severity has higher priority
        // PriorityQueue sorts elements with lower numbers having higher priority
        PriorityQueue<Patient, int> patientQueue = new PriorityQueue<Patient, int>();

        // Enqueue each patient with their severity (severity is the priority)
        foreach (var patient in patients)
        {
            patientQueue.Enqueue(patient, -patient.Severity);  // Invert severity to treat higher severity first
        }

        Console.WriteLine("Treating patients in order of severity:");

        // Process patients by severity (dequeue the most severe first)
        while (patientQueue.Count > 0)
        {
            var patient = patientQueue.Dequeue();
            Console.WriteLine($"Treating {patient.Name} with severity {(-patient.Severity)}");
        }
    }

    static void Main()
    {
        // List of patients (name, severity)
        List<Patient> patients = new List<Patient>
        {
            new Patient("John", 3),
            new Patient("Alice", 5),
            new Patient("Bob", 2)
        };

        // Simulate the triage system and treat patients
        TriagePatients(patients);
    }
}
