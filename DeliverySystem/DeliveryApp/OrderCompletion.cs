using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OrderCompletion //FluentBuilder
{
    public bool _hasExtraSauce { get; }
    public bool _hasExtraSpice { get; }
    public bool _hasExtraCultre { get; }
    public List<MenuItem> _menuItems { get; }

    public OrderCompletion(bool hasExtraSauce, bool hasExtraSpice, bool hasExtraCultre, List<MenuItem> menuItems)
    {
        _hasExtraSauce = hasExtraSauce;
        _hasExtraSpice = hasExtraSpice;
        _hasExtraCultre = hasExtraCultre;
        _menuItems = menuItems;
    }
}
public interface IOrderCompletionBuilder
{
    IOrderCompletionBuilder AddExtraSauce();
    IOrderCompletionBuilder AddExtraSpice();
    IOrderCompletionBuilder AddExtraCultre();
    IOrderCompletionBuilder AddMenuItems(List<MenuItem> menuItems);  
    OrderCompletion Build();
}
public class OrderBuilder : IOrderCompletionBuilder
{
    private bool _hasExtraSauce;
    private bool _hasExtraSpice;
    private bool _hasExtraCultre;
    private List<MenuItem> _menuItems;

    public IOrderCompletionBuilder AddExtraSauce()
    {
        _hasExtraSauce = true;
        return this;
    }
    public IOrderCompletionBuilder AddExtraSpice()
    {
        _hasExtraSpice = true;
        return this; // Возвращаем интерфейс
    }
    public IOrderCompletionBuilder AddExtraCultre()
    {
        _hasExtraCultre = true;
        return this;
    }

    public IOrderCompletionBuilder AddMenuItems(List<MenuItem> menuItems)
    {
        _menuItems = menuItems;
        return this;
    }
    public OrderCompletion Build()
    {
        return new OrderCompletion(_hasExtraSauce, _hasExtraSpice, _hasExtraCultre, _menuItems);
    }
}