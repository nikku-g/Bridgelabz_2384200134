using System;

// Base class: Order
class Order
{
    public int OrderId { get; set; }
    public string OrderDate { get; set; }

    public Order(int orderId, string orderDate)
    {
        OrderId = orderId;
        OrderDate = orderDate;
    }

    public virtual void GetOrderStatus()
    {
        Console.WriteLine("Order placed");
    }
}

// Subclass: ShippedOrder
class ShippedOrder : Order
{
    public string TrackingNumber { get; set; }

    public ShippedOrder(int orderId, string orderDate, string trackingNumber) 
        : base(orderId, orderDate)
    {
        TrackingNumber = trackingNumber;
    }

    public override void GetOrderStatus()
    {
        Console.WriteLine("Order shipped with tracking number: " + TrackingNumber);
    }
}

// Subclass: DeliveredOrder
class DeliveredOrder : ShippedOrder
{
    public string DeliveryDate { get; set; }

    public DeliveredOrder(int orderId, string orderDate, string trackingNumber, string deliveryDate) 
        : base(orderId, orderDate, trackingNumber)
    {
        DeliveryDate = deliveryDate;
    }

    public override void GetOrderStatus()
    {
        Console.WriteLine("Order delivered on: " + DeliveryDate);
    }
}

// Main program
class Program
{
    static void Main()
    {
        Order order = new Order(101, "2024-02-08");
        ShippedOrder shippedOrder = new ShippedOrder(102, "2024-02-07", "TRACK12345");
        DeliveredOrder deliveredOrder = new DeliveredOrder(103, "2024-02-06", "TRACK67890", "2024-02-08");
        
        order.GetOrderStatus();
        shippedOrder.GetOrderStatus();
        deliveredOrder.GetOrderStatus();
    }
}
