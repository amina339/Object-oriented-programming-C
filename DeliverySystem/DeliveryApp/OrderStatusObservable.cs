using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface IObservable<T> where T: DTO
{
    void AddObserver(IObserverStatus o);
    void RemoveObserver(IObserverStatus o);
    void NotifyObservers(T dto);
}
public class OrderStatusService : IObservable<OrderStatusChangedDto>
{
    public Order Order { get; }

    private IOrderState _state;

    private List<IObserverStatus> _observers = new List<IObserverStatus>();
    public OrderStatusService(Order order)
    {
        Order = order;
        _state = new CreatedState();
    } 

    public void SetState(IOrderState newState)
    {
        _state = newState;
        Order.Status = _state.Status;
        _state.OnEnter(this);
    }
    public void NextState()
    {
        _state.Next(this);
    }
    public void NotifyObservers(OrderStatusChangedDto dto) 
    {
        foreach (IObserverStatus observer in _observers)
        {
            observer.Update(dto); 
        }
    }
    public void AddObserver(IObserverStatus observer)
    {
        _observers.Add(observer);
    }
    public void RemoveObserver(IObserverStatus observer)
    {
        _observers.Remove(observer);
    }
}