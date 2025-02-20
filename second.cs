using System;
using System.IO;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        string sourceFile = "source_large_file.txt";  // Replace with the path of a large file
        string destinationBufferedFile = "destination_buffered.txt";  // Destination file for buffered stream
        string destinationUnbufferedFile = "destination_unbuffered.txt";  // Destination file for unbuffered stream

        // Measure performance for BufferedStream
        Stopwatch stopwatch = new Stopwatch();

        // Buffered Stream Copy
        Console.WriteLine("Copying using BufferedStream...");
        stopwatch.Start();
        CopyFileWithBufferedStream(sourceFile, destinationBufferedFile);
        stopwatch.Stop();
        Console.WriteLine($"BufferedStream copy completed in: {stopwatch.ElapsedMilliseconds} ms");

        // Measure performance for FileStream (Unbuffered)
        stopwatch.Reset();
        Console.WriteLine("\nCopying using FileStream (Unbuffered)...");
        stopwatch.Start();
        CopyFileWithUnbufferedStream(sourceFile, destinationUnbufferedFile);
        stopwatch.Stop();
        Console.WriteLine($"Unbuffered FileStream copy completed in: {stopwatch.ElapsedMilliseconds} ms");
    }

    // Method to copy file using BufferedStream
    static void CopyFileWithBufferedStream(string sourceFile, string destinationFile)
    {
        const int bufferSize = 4096;  // 4 KB buffer size
        using (FileStream sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
        using (BufferedStream bufferedSourceStream = new BufferedStream(sourceStream))
        using (FileStream destinationStream = new FileStream(destinationFile, FileMode.Create, FileAccess.Write))
        using (BufferedStream bufferedDestinationStream = new BufferedStream(destinationStream))
        {
            byte[] buffer = new byte[bufferSize];
            int bytesRead;

            while ((bytesRead = bufferedSourceStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                bufferedDestinationStream.Write(buffer, 0, bytesRead);
            }
        }
    }

    // Method to copy file using FileStream (unbuffered)
    static void CopyFileWithUnbufferedStream(string sourceFile, string destinationFile)
    {
        const int bufferSize = 4096;  // 4 KB buffer size
        using (FileStream sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
        using (FileStream destinationStream = new FileStream(destinationFile, FileMode.Create, FileAccess.Write))
        {
            byte[] buffer = new byte[bufferSize];
            int bytesRead;

            while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                destinationStream.Write(buffer, 0, bytesRead);
            }
        }
    }
}
