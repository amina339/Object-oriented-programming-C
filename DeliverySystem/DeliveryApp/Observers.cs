using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IObserverStatus
{
    void Update(OrderStatusChangedDto dto);
}
public class Kitchen : IObserverStatus
{
    public void Update(OrderStatusChangedDto dto)
    {
        if (dto.Status == "Created")
            Console.WriteLine("Kitchen: start cooking");
    }
}
public class Client : IObserverStatus
{
    public void Update(OrderStatusChangedDto dto)
    {
        if (dto.Status == "Delivered")
            Console.WriteLine("Client: received the order");
    }
}
public class Courier : IObserverStatus
{
    public void Update(OrderStatusChangedDto dto)
    {
        if (dto.Status == "Prepared and waiting for the courier")
            Console.WriteLine("Courier: coming");
    }
}