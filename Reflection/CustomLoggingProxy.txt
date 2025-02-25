using System;
using System.Reflection;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Messaging;
interface IGreeting
{
    void SayHello();
}
class Hello : IGreeting
{
    public void SayHello()
    {
        Console.WriteLine("Hello, World!");
    }
}
class CustomProxy : RealProxy
{
    private readonly IGreeting _target;
    public CustomProxy(IGreeting target) : base(typeof(IGreeting))
    {
        _target = target;
    }
    public override IMessage Invoke(IMessage msg)
    {
        Console.WriteLine("Before method call...");
        var methodCall = msg as IMethodCallMessage;
        var result = methodCall.MethodBase.Invoke(_target, methodCall.Args);
        Console.WriteLine("After method call...");
        return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
    }
}
class ReflectionProxyExample
{
    static void Main()
    {
        IGreeting original = new Hello();
        IGreeting proxyInstance = (IGreeting)new CustomProxy(original).GetTransparentProxy();
        proxyInstance.SayHello();
    }
}