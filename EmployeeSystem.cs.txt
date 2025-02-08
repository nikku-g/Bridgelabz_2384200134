using System;

class Employee {
	public string Name {get; set;}
	public int Id {get; set;}
	public double Salary {get; set;}
	
	public Employee(string name, int id, double salary) {
		this.Name = name;
		this.Id = id;
		this.Salary = salary;
	}
	
	public virtual void DisplayDetails() {
		Console.WriteLine("Name: {0}, Id: {1}, Salary: {2}", Name, Id, Salary);
	}
}

class Manager : Employee {
	public int TeamSize {get; set;}
	
	public Manager(string name, int id, double salary, int teamSize) : base(name, id, salary) {
		this.TeamSize = teamSize;
	}
	
	public override void DisplayDetails() {
		Console.WriteLine("--Manager Details--");
		base.DisplayDetails();
		Console.WriteLine("Team Size: {0}", TeamSize);
		Console.WriteLine();
	}
}

class Developer : Employee {
	public string ProgrammingLanguage {get; set;}
	
	public Developer(string name, int id, double salary, string ProgrammingLanguage) : base(name, id, salary) {
		this.ProgrammingLanguage = ProgrammingLanguage;
	}
	
	public override void DisplayDetails() {
		Console.WriteLine("--Developer Details--");
		base.DisplayDetails();
		Console.WriteLine("Programming Language: {0}", ProgrammingLanguage);
		Console.WriteLine();
	}
}

class Intern : Employee {
	public string InternshipDuration {get; set;}
	
	public Intern(string name, int id, double salary, string InternshipDuration) : base(name, id, salary) {
		this.InternshipDuration = InternshipDuration;
	}
	
	public override void DisplayDetails() {
		Console.WriteLine("--Intern Details--");
		base.DisplayDetails();
		Console.WriteLine("Internship Duration: {0}", InternshipDuration);
	}
}

class Program {
	public static void Main() {
		Manager manager = new Manager("Naresh", 243, 43000, 11);
		Developer developer = new Developer("Rajesh", 543, 34000, "C#");
		Intern intern = new Intern("Gaurav", 893, 21000, "3 months");
		
		manager.DisplayDetails();
		developer.DisplayDetails();
		intern.DisplayDetails();
	}
}