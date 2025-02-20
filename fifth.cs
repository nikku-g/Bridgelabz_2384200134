using System;
using System.IO;

class Program
{
    static void Main()
    {
        string originalFilePath = "original_image.jpg";  // Replace with the path of your image
        string newFilePath = "new_image.jpg";  // Replace with the path to save the new image

        // Verify that the original image file exists
        if (!File.Exists(originalFilePath))
        {
            Console.WriteLine("The original image file does not exist.");
            return;  // Exit if the original file does not exist
        }

        // Convert image file to byte array and write to new image file
        byte[] imageBytes = ConvertImageToByteArray(originalFilePath);
        if (imageBytes != null)
        {
            WriteByteArrayToImage(imageBytes, newFilePath);

            // Verify if the new image file matches the original one
            if (VerifyFilesIdentical(originalFilePath, newFilePath))
            {
                Console.WriteLine("The new image file is identical to the original.");
            }
            else
            {
                Console.WriteLine("The new image file is NOT identical to the original.");
            }
        }
        else
        {
            Console.WriteLine("Failed to convert the image to a byte array.");
        }
    }

    // Method to convert the image file to a byte array
    static byte[] ConvertImageToByteArray(string filePath)
    {
        // Check if the file exists
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"File '{filePath}' not found.");
            return null;
        }

        // Read the file into a byte array using MemoryStream
        byte[] fileBytes = File.ReadAllBytes(filePath);
        return fileBytes;
    }

    // Method to write the byte array to a new image file
    static void WriteByteArrayToImage(byte[] imageBytes, string filePath)
    {
        // Write the byte array to the new image file
        File.WriteAllBytes(filePath, imageBytes);
        Console.WriteLine("The byte array has been written to the new image file.");
    }

    // Method to verify if two files are identical by comparing their lengths and contents
    static bool VerifyFilesIdentical(string file1, string file2)
    {
        // Check if both files exist
        if (!File.Exists(file1) || !File.Exists(file2))
        {
            return false;
        }

        // Compare file sizes first
        FileInfo fileInfo1 = new FileInfo(file1);
        FileInfo fileInfo2 = new FileInfo(file2);

        if (fileInfo1.Length != fileInfo2.Length)
        {
            return false;
        }

        // If file sizes match, compare the actual content byte by byte
        byte[] file1Bytes = File.ReadAllBytes(file1);
        byte[] file2Bytes = File.ReadAllBytes(file2);

        for (int i = 0; i < file1Bytes.Length; i++)
        {
            if (file1Bytes[i] != file2Bytes[i])
            {
                return false;
            }
        }

        return true;
    }
}
