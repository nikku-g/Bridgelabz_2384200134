using System;

class Animal {
	public string Name {get; set;}
	public int Age {get; set;}
	
	public Animal (string Name, int Age) {
		this.Name = Name;
		this.Age = Age;
	}
	
	public virtual void MakeSound() {
		Console.WriteLine("Animal makes a sound.");
	}
}

// Inheriting Animal class in Dog class //
class Dog : Animal {
	
	public Dog (string Name, int Age) : base(Name, Age) {}
	
	public override void MakeSound() {
		Console.WriteLine("Dog barks.");
	}
}

// Inheriting Animal class in Cat class //
class Cat : Animal {
	
	public Cat (string Name, int Age) : base(Name, Age) {}
	
	public override void MakeSound() {
		Console.WriteLine("Cat meows.");
	}
}

// Inheriting Animal class in Bird class //
class Bird : Animal {
	
	public Bird (string Name, int Age) : base(Name, Age) {}
	public override void MakeSound() {
		Console.WriteLine("Bird chirps.");
	}
}

class Program {
	public static void Main() {
		
		// Creating objects for various animals //
		Animal myAnimal = new Animal("Animal", 5);
		myAnimal.MakeSound();
		Dog myDog = new Dog("Tommy", 4);
		myDog.MakeSound();
		Cat myCat = new Cat("Kitty", 6);
		myCat.MakeSound();
		Bird myBird = new Bird("Tweety", 5);
		myBird.MakeSound();
		
	}
}