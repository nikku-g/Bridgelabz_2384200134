
using System;

class Person {
	private string name {get; set;}
	private int age {get; set;}
	
	// Parametrized Constructor //
	public Person(string name, int age) {
		this.name = name;
		this.age = age;
	}
	
	// Copy Constructor //
	public Person(Person other) {
		this.name = other.name;
		this.age = other.age;
	}
	
	public void display() {
		Console.WriteLine("Name: {0}, Age: {1}", name, age);
	}
	
	public static void Main(string[] args) {
		// Parametrized Constructor Calling //
		Person original = new Person("Ramesh", 30);
		Console.WriteLine("Original Details: ");
		original.display();
		
		// Copy Constructor Calling //
		Person copied = new Person(original);
		Console.WriteLine("Copied Details: ");
		copied.display();
	}
}

