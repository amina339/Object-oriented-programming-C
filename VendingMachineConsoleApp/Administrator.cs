using System.Reflection;
using System.Security.Cryptography;
using System.Xml.Linq;

public class AdministratorUser
{
    private string _correctPassword = "M3124"; // пароль, нельзя вызвать напрямую

    private AdministratorUser() // Надпись при создании админа
    {
        Console.WriteLine("Режим администратора активирован");
    }

    public static AdministratorUser? Create(string inputPassword) // Статический метод для создания объекта класса
    {
        if (inputPassword == "М3124")
        {
            return new AdministratorUser(); // Создаем только при верном пароле
        }
        else
        {
            Console.WriteLine("Пароль неверный. Администраторский режим недоступен");
            return null; // Не создаем объект
        }
    }

    public void RefillProduct(Product product) // Пополняем продукт
    {
        product.IncreaseQuantity();
    }
}