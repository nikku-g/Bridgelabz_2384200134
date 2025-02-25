using System;
using System.IO;
using NUnit.Framework;

public class FileProcessor
{
    public void WriteToFile(string filename, string content)
    {
        File.WriteAllText(filename, content);
    }

    public string ReadFromFile(string filename)
    {
        if (!File.Exists(filename))
            throw new IOException("File not found.");

        return File.ReadAllText(filename);
    }
}

[TestFixture]
public class FileProcessorTests
{
    private FileProcessor _fileProcessor;
    private string _testFile;

    [SetUp]
    public void Setup()
    {
        _fileProcessor = new FileProcessor();
        _testFile = "testfile.txt";
    }

    [TearDown]
    public void Cleanup()
    {
        if (File.Exists(_testFile))
        {
            File.Delete(_testFile);
        }
    }

    [Test]
    public void WriteToFile_ShouldCreateFileAndWriteContent()
    {
        string content = "Hello, File!";
        _fileProcessor.WriteToFile(_testFile, content);

        Assert.IsTrue(File.Exists(_testFile), "File should exist after writing.");
        Assert.AreEqual(content, File.ReadAllText(_testFile), "Content should match.");
    }

    [Test]
    public void ReadFromFile_ShouldReturnCorrectContent()
    {
        string content = "Testing Read";
        File.WriteAllText(_testFile, content);

        string result = _fileProcessor.ReadFromFile(_testFile);
        Assert.AreEqual(content, result, "Read content should match written content.");
    }

    [Test]
    public void ReadFromFile_NonExistentFile_ShouldThrowIOException()
    {
        Assert.Throws<IOException>(() => _fileProcessor.ReadFromFile("nonexistent.txt"));
    }
}
