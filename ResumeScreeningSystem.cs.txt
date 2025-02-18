using System;
using System.Collections.Generic;

namespace Generics
{
    // Abstract base class representing a general job role
    abstract class JobRole
    {
        public string name { get; set; }  // Name of the job role
        public string skills { get; set; } // Required skills for the job

        // Constructor to initialize the job role
        public JobRole(string name, string skills)
        {
            this.name = name;
            this.skills = skills;
        }

        // Abstract method that must be implemented by all derived classes
        public abstract void ShowDetails();
    }

    // SoftwareEngineer class inheriting from JobRole
    class SoftwareEngineer : JobRole
    {
        public string programmingLanguage { get; set; } // Programming languages for the role

        // Constructor to initialize a SoftwareEngineer role
        public SoftwareEngineer(string name, string skills, string programmingLanguage) : base(name, skills)
        {
            this.programmingLanguage = programmingLanguage;
        }

        // Implementation of ShowDetails() for SoftwareEngineer
        public override void ShowDetails()
        {
            // Display details of the software engineer role
            Console.WriteLine($"[Software Engineer] {name} - Programming Languages: {programmingLanguage} - Required Skills: {skills}");
        }
    }

    // DataScientist class inheriting from JobRole
    class DataScientist : JobRole
    {
        public string dataTools { get; set; } // Data analysis tools for the role

        // Constructor to initialize a DataScientist role
        public DataScientist(string name, string skills, string dataTools) : base(name, skills)
        {
            this.dataTools = dataTools;
        }

        // Implementation of ShowDetails() for DataScientist
        public override void ShowDetails()
        {
            // Display details of the data scientist role
            Console.WriteLine($"[Data Scientist] {name} - Data Tools: {dataTools} - Required Skills: {skills}");
        }
    }

    // Generic Resume class to store different types of job roles
    class Resume<T> where T : JobRole
    {
        private List<T> roles = new List<T>(); // List to store job roles

        // Constructor to initialize the resume with a list of roles
        public Resume()
        {
        }

        // Method to add a job role to the resume
        public void AddRoles(T role)
        {
            roles.Add(role); // Adds the role to the list
        }

        // Method to display all stored roles
        public void DisplayAllItems()
        {
            Console.WriteLine("\nAI - Driven Resume Screening System:");
            // Loop through all roles and display their details
            foreach (var role in roles)
            {
                role.ShowDetails();
            }
        }
    }

    // Main program class
    class Program
    {
        static void Main()
        {
            // Creating instances of job roles
            SoftwareEngineer softwareEngineerRole = new SoftwareEngineer("Software Engineer", "Problem-solving, Software Development", "C#, Java, Python");
            DataScientist dataScientistRole = new DataScientist("Data Scientist", "Data Analysis, Machine Learning", "Python, R, SQL");

            // Creating a resume and adding job roles
            Resume<SoftwareEngineer> softwareEngineerResume = new Resume<SoftwareEngineer>();
            softwareEngineerResume.AddRoles(softwareEngineerRole);

            Resume<DataScientist> dataScientistResume = new Resume<DataScientist>();
            dataScientistResume.AddRoles(dataScientistRole);

            // Displaying all stored job roles
            softwareEngineerResume.DisplayAllItems();
            dataScientistResume.DisplayAllItems();
        }
    }
}