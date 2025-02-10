using System;
using System.Collections.Generic;

// Interface for managing medical records
public interface IMedicalRecord
{
    void AddRecord(string record);
    void ViewRecords();
}

// Abstract class representing a hospital patient
public abstract class Patient 
{
    protected string patientId;
    protected string name;
    protected int age;
    
    protected string diagnosis { get; set; } // Stores patient diagnosis
    protected string medicalHistory { get; set; } // Stores medical history

    // Constructor to initialize patient details
    public Patient(string patientId, string name, int age, string diagnosis, string medicalHistory)
    {
        this.patientId = patientId;
        this.name = name;
        this.age = age;
        this.diagnosis = diagnosis;
        this.medicalHistory = medicalHistory;
    }

    // Abstract method to calculate the medical bill
    public abstract double CalculateBill();

    // Method to get patient details
    public void GetPatientDetails()
    {
        Console.WriteLine($"Patient ID: {patientId}\nName: {name}\nAge: {age}");
    }
}   

// Class representing an In-Patient
public class InPatient : Patient , IMedicalRecord
{
    private List<string> MedicalRecords = new List<string>();
    private double dailyCharge;
    private int numberOfDays;
    
    public InPatient(string patientId, string name, int age, string diagnosis, string medicalHistory, double dailyCharge, int numberOfDays)
        : base(patientId, name, age, diagnosis, medicalHistory) 
    {
        this.dailyCharge = dailyCharge;
        this.numberOfDays = numberOfDays;
    }

    // Calculate total bill based on daily charge and number of days
    public override double CalculateBill()
    {
        return dailyCharge * numberOfDays;
    }
    
    // Add a medical record for the patient
    public void AddRecord(string record) 
    {
        MedicalRecords.Add(record);
    }

    // View medical records
    public void ViewRecords() 
    {
        Console.WriteLine("Medical Records:");
        foreach (var record in MedicalRecords) 
        {
            Console.WriteLine(record);
        }
    }
}

// Class representing an Out-Patient
public class OutPatient : Patient , IMedicalRecord
{
    private List<string> MedicalRecords = new List<string>();
    private double consultationFee;
    
    public OutPatient(string patientId, string name, int age, string diagnosis, string medicalHistory, double consultationFee)
        : base(patientId, name, age, diagnosis, medicalHistory) 
    {
        this.consultationFee = consultationFee;
    }

    // Calculate total bill based on consultation fee
    public override double CalculateBill()
    {
        return consultationFee;
    }
    
    // Add a medical record for the patient
    public void AddRecord(string record) 
    {
        MedicalRecords.Add(record);
    }

    // View medical records
    public void ViewRecords() 
    {
        Console.WriteLine("Medical Records:");
        foreach (var record in MedicalRecords) 
        {
            Console.WriteLine(record);
        }
    }
}

// Main program class
internal class Program
{
    public static void Main(string[] args)
    {
        // Creating an In-Patient instance
        Patient inpatient = new InPatient("Patient101", "Vanshita", 25, "Flu", "No prior history", 2000, 3);
        
        // Creating an Out-Patient instance
        Patient outpatient = new OutPatient("Patient102", "Simran", 30, "Cold", "Allergic to penicillin", 500);
        
        // Display details and bill for In-Patient
        inpatient.GetPatientDetails();
        Console.WriteLine("Total Bill: " + inpatient.CalculateBill());
        
        // Display details and bill for Out-Patient
        outpatient.GetPatientDetails();
        Console.WriteLine("Total Bill: " + outpatient.CalculateBill());
        
        // Adding and viewing medical records for In-Patient
        IMedicalRecord medicalRecordIn = (IMedicalRecord)inpatient;
        medicalRecordIn.AddRecord("Flu treatment started.");
        medicalRecordIn.ViewRecords();
        
        // Adding and viewing medical records for Out-Patient
        IMedicalRecord medicalRecordOut = (IMedicalRecord)outpatient;
        medicalRecordOut.AddRecord("Cold medicine prescribed.");
        medicalRecordOut.ViewRecords();
    }
}