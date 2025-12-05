using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public abstract class MenuComponent //composite - hierarchy of the menu 
{
    public string Name { get; set; }
    public string Description { get; set; }
    public abstract StringBuilder GetInfo();
    public MenuComponent(string name, string description)
    {
        Name = name;
        Description = description;
    }

}

public class MenuCategory : MenuComponent
{
    private List<MenuComponent> _dishes = new List<MenuComponent>();
    public IReadOnlyList<MenuComponent> Dishes => _dishes.AsReadOnly();
    public void Add(MenuComponent component) => _dishes.Add(component);
    public void Remove(MenuComponent component) => _dishes.Remove(component);
    public override StringBuilder GetInfo()
    {
        StringBuilder info = new StringBuilder();
        info.AppendLine(Name);
        info.AppendLine(Description);
        foreach (MenuComponent component in _dishes)
            info.AppendLine(component.GetInfo().ToString());
        return info;
    }
    public MenuCategory(string name, string description) : base(name, description) { }
}
public class MenuItem : MenuComponent
{
    public decimal Price { get; set; }
    public int CookingTime { get; set; }
    public override StringBuilder GetInfo()
    {
        StringBuilder info = new StringBuilder();
        info.AppendLine(Name);
        info.AppendLine(Description);
        info.AppendLine(Price.ToString());
        info.AppendLine(Description);
        return info;
    }
    public MenuItem(string name, string description, decimal price, int preparatoryTime) : base(name, description)
    {
        Price = price;
        CookingTime = preparatoryTime;
    }
}


