using System;

// Base class: Device
class Device
{
    public string DeviceId { get; set; }
    public string Status { get; set; }

    public Device(string deviceId, string status)
    {
        DeviceId = deviceId;
        Status = status;
    }

    public virtual void DisplayStatus()
    {
        Console.WriteLine("Device ID: {0}, Status: {1}", DeviceId, Status);
    }
}

// Subclass: Thermostat
class Thermostat : Device
{
    public int TemperatureSetting { get; set; }

    public Thermostat(string deviceId, string status, int temperatureSetting) : base(deviceId, status)
    {
        TemperatureSetting = temperatureSetting;
    }

    public override void DisplayStatus()
    {
        base.DisplayStatus();
        Console.WriteLine("Temperature Setting: {0}°C", TemperatureSetting);
    }
}

// Main program
class Program
{
    static void Main()
    {
        Thermostat thermostat = new Thermostat("TH123", "Online", 22);
        thermostat.DisplayStatus();
    }
}
