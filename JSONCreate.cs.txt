using System;
using Newtonsoft.Json;

class Create_Json
{
    public void Create()
    {
        var Student = new
        {
            Name = "Suresh",
            Age = 20,
            Subjects = new string[] { "Programming Reference", "Intro to C#", "Play with JS" }
        };

        string Student_Details = JsonConvert.SerializeObject(Student, Formatting.Indented);
        Console.WriteLine(Student_Details);
    }
}