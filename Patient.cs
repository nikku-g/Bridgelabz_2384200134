using System;

class Patient
{
    // Static variable shared among all patients
    public static string HospitalName = "City Hospital";
    
    // Static counter to keep track of total patients admitted
    private static int totalPatients = 0;

    // Readonly variable to uniquely identify each patient
    public readonly int PatientID;

    // Instance variables for name, age, and ailment
    public string Name { get; set; }
    public int Age { get; set; }
    public string Ailment { get; set; }

    // Constructor to initialize patient details
    public Patient(string name, int age, string ailment)
    {
        this.Name = name;
        this.Age = age;
        this.Ailment = ailment;
        
        // Assigning a unique Patient ID
        this.PatientID = ++totalPatients;
    }

    // Static method to get total number of patients
    public static int GetTotalPatients()
    {
        return totalPatients;
    }

    // Static method to display total patients count
    public static void DisplayTotalPatients()
    {
        Console.WriteLine($"Total patients admitted: {totalPatients}");
    }

    // Method to display patient details
    public void DisplayPatientDetails()
    {
        Console.WriteLine($"Hospital: {HospitalName}");
        Console.WriteLine($"Patient ID: {PatientID}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Ailment: {Ailment}");
    }
}

class Program
{
    // Define the maximum number of patients that can be handled
    static int maxPatients = 100;
    static Patient[] patients = new Patient[maxPatients];
    static int currentPatientCount = 0;

    static void Main()
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Hospital Management System");
            Console.WriteLine("1. Add Patient");
            Console.WriteLine("2. Update Patient Information");
            Console.WriteLine("3. Delete Patient Record");
            Console.WriteLine("4. Generate Report by Ailment");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddPatient();
                    break;
                case 2:
                    UpdatePatientInfo();
                    break;
                case 3:
                    DeletePatientRecord();
                    break;
                case 4:
                    GenerateReportByAilment();
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void AddPatient()
    {
        if (currentPatientCount >= maxPatients)
        {
            Console.WriteLine("\nCannot add more patients. Hospital is at full capacity.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("\nEnter Patient Details:");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Age: ");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.Write("Ailment: ");
        string ailment = Console.ReadLine();

        // Create a new Patient and add it to the array
        patients[currentPatientCount] = new Patient(name, age, ailment);
        currentPatientCount++;

        Console.WriteLine("\nPatient added successfully!");
        Console.WriteLine($"Patient ID: {patients[currentPatientCount - 1].PatientID}");
        Console.WriteLine($"Total Patients: {Patient.GetTotalPatients()}");
        Console.ReadKey();
    }

    static void UpdatePatientInfo()
    {
        Console.WriteLine("\nEnter Patient ID to Update:");
        int patientID = Convert.ToInt32(Console.ReadLine());

        Patient patientToUpdate = null;
        for (int i = 0; i < currentPatientCount; i++)
        {
            if (patients[i].PatientID == patientID)
            {
                patientToUpdate = patients[i];
                break;
            }
        }

        if (patientToUpdate != null)
        {
            Console.WriteLine($"\nUpdating details for Patient ID: {patientToUpdate.PatientID}");
            Console.Write("New Name (Leave empty to keep unchanged): ");
            string newName = Console.ReadLine();
            Console.Write("New Age (Leave empty to keep unchanged): ");
            string newAgeStr = Console.ReadLine();
            Console.Write("New Ailment (Leave empty to keep unchanged): ");
            string newAilment = Console.ReadLine();

            if (!string.IsNullOrEmpty(newName)) patientToUpdate.Name = newName;
            if (!string.IsNullOrEmpty(newAgeStr)) patientToUpdate.Age = Convert.ToInt32(newAgeStr);
            if (!string.IsNullOrEmpty(newAilment)) patientToUpdate.Ailment = newAilment;

            Console.WriteLine("\nPatient information updated successfully!");
        }
        else
        {
            Console.WriteLine("Patient not found!");
        }
        Console.ReadKey();
    }

    static void DeletePatientRecord()
    {
        Console.WriteLine("\nEnter Patient ID to Delete:");
        int patientID = Convert.ToInt32(Console.ReadLine());

        int indexToDelete = -1;
        for (int i = 0; i < currentPatientCount; i++)
        {
            if (patients[i].PatientID == patientID)
            {
                indexToDelete = i;
                break;
            }
        }

        if (indexToDelete != -1)
        {
            // Shift remaining patients
            for (int i = indexToDelete; i < currentPatientCount - 1; i++)
            {
                patients[i] = patients[i + 1];
            }

            // Set last element to null
            patients[currentPatientCount - 1] = null;
            currentPatientCount--;

            Console.WriteLine("\nPatient record deleted successfully!");
        }
        else
        {
            Console.WriteLine("Patient not found!");
        }
        Console.ReadKey();
    }

    static void GenerateReportByAilment()
    {
        Console.WriteLine("\nEnter Ailment to Generate Report:");
        string ailment = Console.ReadLine();

        bool reportGenerated = false;
        for (int i = 0; i < currentPatientCount; i++)
        {
            if (patients[i].Ailment.Equals(ailment, StringComparison.OrdinalIgnoreCase))
            {
                patients[i].DisplayPatientDetails();
                Console.WriteLine();
                reportGenerated = true;
            }
        }

        if (!reportGenerated)
        {
            Console.WriteLine("No patients found with the specified ailment.");
        }
        Console.ReadKey();
    }
}