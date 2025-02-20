using System;
using System.IO;
using System.Threading;

class Program
{
    static void Main()
    {
        // Create the pipe server and client stream for communication between threads
        AnonymousPipeServerStream pipeServer = new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.Inheritable);
        AnonymousPipeClientStream pipeClient = new AnonymousPipeClientStream(PipeDirection.In, pipeServer.GetClientHandleAsString());

        // Create threads for reading and writing to the pipe
        Thread writerThread = new Thread(() => WriteToPipe(pipeServer));
        Thread readerThread = new Thread(() => ReadFromPipe(pipeClient));

        // Start the threads
        writerThread.Start();
        readerThread.Start();

        // Wait for both threads to complete
        writerThread.Join();
        readerThread.Join();

        // Close the streams
        pipeServer.Close();
        pipeClient.Close();

        Console.WriteLine("Pipe communication complete.");
    }

    // Method to write data into the pipe (from the writer thread)
    static void WriteToPipe(AnonymousPipeServerStream pipeServer)
    {
        // Simulate writing data to the pipe
        string dataToSend = "Hello from the writer thread!";
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(dataToSend);

        // Write data to the pipe
        pipeServer.Write(buffer, 0, buffer.Length);
        pipeServer.Close(); // Close the pipe after writing
        Console.WriteLine("Writer thread finished writing to pipe.");
    }

    // Method to read data from the pipe (from the reader thread)
    static void ReadFromPipe(AnonymousPipeClientStream pipeClient)
    {
        byte[] buffer = new byte[1024];
        int bytesRead;

        // Read data from the pipe
        while ((bytesRead = pipeClient.Read(buffer, 0, buffer.Length)) > 0)
        {
            string dataReceived = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Reader thread received: " + dataReceived);
        }

        pipeClient.Close(); // Close the pipe after reading
        Console.WriteLine("Reader thread finished reading from pipe.");
    }
}
