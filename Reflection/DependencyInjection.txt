using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

// Custom attribute to mark constructors for dependency injection
[AttributeUsage(AttributeTargets.Constructor)]
public class InjectAttribute : Attribute { }

public class SimpleContainer
{
    private Dictionary<Type, Type> _registrations = new();
    
    // Registers an interface with its concrete implementation
    public void Register<TInterface, TImplementation>() where TImplementation : TInterface
        => _registrations[typeof(TInterface)] = typeof(TImplementation);
    
    // Resolves an instance of the requested type
    public object Resolve(Type type)
    {
        if (!_registrations.ContainsKey(type)) throw new Exception($"{type.Name} not registered");
        
        Type implementationType = _registrations[type];
        
        // Find a constructor marked with [Inject] or the first available constructor
        ConstructorInfo constructor = implementationType.GetConstructors()
            .FirstOrDefault(c => c.GetCustomAttribute<InjectAttribute>() != null) 
            ?? implementationType.GetConstructors().First();
        
        // Resolve constructor parameters recursively
        object[] parameters = constructor.GetParameters()
            .Select(p => Resolve(p.ParameterType))
            .ToArray();
        
        // Create an instance of the class with resolved dependencies
        return constructor.Invoke(parameters);
    }
    
    // Generic method to resolve a type
    public T Resolve<T>() => (T)Resolve(typeof(T));
}

// Example usage
public interface IService { void Execute(); }
public class Service : IService { public void Execute() => Console.WriteLine("Service Running"); }

public class Consumer
{
    private IService _service;
    
    // Constructor with [Inject] attribute for dependency injection
    [Inject]
    public Consumer(IService service) { _service = service; }
    
    public void Run() => _service.Execute();
}

class Program
{
    static void Main()
    {
        var container = new SimpleContainer();
        
        // Register dependencies
        container.Register<IService, Service>();
        container.Register<Consumer, Consumer>();
        
        // Resolve an instance of Consumer and execute the method
        var consumer = container.Resolve<Consumer>();
        consumer.Run();
    }
}