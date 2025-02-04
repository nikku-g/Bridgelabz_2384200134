
using System;

class Circle {

	private float radius {get; set;}
	public Circle() {
		radius = 20.5f;
	}
	public Circle(float radius) {
		this.radius = radius;
	}
	
	public static void Main(string[] args) {
		Circle circle = new Circle(25f);
		Console.WriteLine("Radius you entered: {0}", circle.radius);
		Console.ReadLine();
	}
}

