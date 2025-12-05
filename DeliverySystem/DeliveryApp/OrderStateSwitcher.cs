using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IOrderState
{
    string Status { get; }

    void OnEnter(OrderStatusService service);

    void Next(OrderStatusService service);
}

public class CreatedState : IOrderState
{
    public string Status => "Created";

    public void OnEnter(OrderStatusService service)
    {
        OrderStatusChangedDto new_dto = new OrderStatusChangedDto(service.Order.Id, Status);
        service.NotifyObservers(new_dto);
    }

    public void Next(OrderStatusService service)
    {
        service.SetState(new PreparingState());
    }
}
public class PreparingState : IOrderState
{
    public string Status => "Preparing";

    public void OnEnter(OrderStatusService service)
    {
        OrderStatusChangedDto new_dto = new OrderStatusChangedDto(service.Order.Id, Status);
        service.NotifyObservers(new_dto);
    }

    public void Next(OrderStatusService service)
    {
        service.SetState(new WaitingCourierState());
    }
}
public class WaitingCourierState : IOrderState
{
    public string Status => "Prepared and waiting for the courier";

    public void OnEnter(OrderStatusService service)
    {
        OrderStatusChangedDto new_dto = new OrderStatusChangedDto(service.Order.Id, Status);
        service.NotifyObservers(new_dto);
    }

    public void Next(OrderStatusService service)
    {
        service.SetState(new ComingState());
    }
}

public class ComingState : IOrderState
{
    public string Status => "Coming";

    public void OnEnter(OrderStatusService service)
    {
        OrderStatusChangedDto new_dto = new OrderStatusChangedDto(service.Order.Id, Status);
        service.NotifyObservers(new_dto);
    }

    public void Next(OrderStatusService service)
    {
        service.SetState(new DeliveredState());
    }
}
public class DeliveredState : IOrderState
{
    public string Status => "Delivered";

    public void OnEnter(OrderStatusService service)
    {
        OrderStatusChangedDto new_dto = new OrderStatusChangedDto(service.Order.Id, Status);
        service.NotifyObservers(new_dto);
    }

    public void Next(OrderStatusService service)
    {
    }
}


