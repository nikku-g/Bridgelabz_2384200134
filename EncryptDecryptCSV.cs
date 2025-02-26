using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using CsvHelper;

namespace CSVEncryption.
{
    class Program
    {
        // Encryption Key (Must be 32 characters for AES-256)
        private static readonly string encryptionKey = "12345678901234567890123456789012";

        static void Main(string[] args)
        {
            string csvFilePath = "employees_encrypted.csv";

            // Sample employee data
            List<Employee> employees = new List<Employee>
            {
                new Employee { ID = 1, Name = "John Doe", Email = "john@example.com", Salary = "50000" },
                new Employee { ID = 2, Name = "Alice Smith", Email = "alice@example.com", Salary = "60000" },
                new Employee { ID = 3, Name = "Michael Brown", Email = "michael@example.com", Salary = "70000" }
            };

            // Encrypt and Write CSV
            EncryptAndWriteCsv(csvFilePath, employees);

            // Read and Decrypt CSV
            ReadAndDecryptCsv(csvFilePath);
        }

        // Encrypt and write data to CSV
        static void EncryptAndWriteCsv(string filePath, List<Employee> employees)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                // Encrypt sensitive fields before writing
                foreach (var emp in employees)
                {
                    emp.Email = Encrypt(emp.Email);
                    emp.Salary = Encrypt(emp.Salary);
                }

                csv.WriteRecords(employees);
            }
            Console.WriteLine($"Encrypted CSV saved: {filePath}");
        }

        // Read and decrypt CSV
        static void ReadAndDecryptCsv(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var employees = csv.GetRecords<Employee>();

                Console.WriteLine("\n Decrypted Employee Data:");
                foreach (var emp in employees)
                {
                    emp.Email = Decrypt(emp.Email);
                    emp.Salary = Decrypt(emp.Salary);
                    Console.WriteLine($"ID: {emp.ID}, Name: {emp.Name}, Email: {emp.Email}, Salary: {emp.Salary}");
                }
            }
        }

        //  Encrypt Data (AES-256)
        static string Encrypt(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(encryptionKey);
                aes.IV = new byte[16]; // Zero IV for simplicity

                using (var encryptor = aes.CreateEncryptor())
                {
                    byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
                    byte[] encryptedBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
                    return Convert.ToBase64String(encryptedBytes);
                }
            }
        }

        //  Decrypt Data (AES-256)
        static string Decrypt(string cipherText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(encryptionKey);
                aes.IV = new byte[16];

                using (var decryptor = aes.CreateDecryptor())
                {
                    byte[] cipherBytes = Convert.FromBase64String(cipherText);
                    byte[] decryptedBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                    return Encoding.UTF8.GetString(decryptedBytes);
                }
            }
        }

        //  Employee class
        public class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Salary { get; set; }
        }
    }
}