using System.Reflection;
using System.Xml.Linq;

public class Product
{
    private int _id;
    public int Id // Уникальный идентификатор
    {
        set
        {
            _id = value;
        }
        get { return _id; }
    }

    private string product_type;
    public string ProductType  // Сам товар (эмодзи)
    {
        set
        {
            product_type = value;
        }
        get { return product_type; }
    }     

    public static string[] Food = { // Множество эмодзи-еды (для автоматической генерации товара)
            "🍎", "🍐", "🍊", "🍋", "🍌", "🍉", "🍇", "🍓", "🍈", "🍒", "🍑", "🥭", "🍍",
        "🥥", "🥝", "🍅", "🍆", "🥑", "🥦", "🥬", "🥒", "🌶", "🌽", "🥕", "🧄", "🧅",
        "🥔", "🍠", "🥐", "🥯", "🍞", "🥖", "🥨", "🧀", "🥚", "🍳", "🧈", "🥞", "🧇",
        "🥓", "🥩", "🍗", "🍖", "🦴", "🌭", "🍔", "🍟", "🍕", "🥪", "🥙", "🧆", "🌮",
        "🌯", "🥗", "🥘", "🥫", "🍝", "🍜", "🍲", "🍛", "🍣", "🍱", "🥟", "🦪", "🍤",
        "🍙", "🍚", "🍘", "🍥", "🥠", "🥮", "🍢", "🍡", "🍧", "🍨", "🍦", "🥧", "🧁",
        "🍰", "🎂", "🍮", "🍭", "🍬", "🍫", "🍿", "🥜", "🌰", "🍪", "🥛", "🍼", "🫖",
        "☕", "🍵", "🧃", "🥤", "🧋", "🍶", "🍺", "🍻", "🥂", "🍷", "🥃", "🍸", "🍹",
        "🧉", "🍾", "🧊"
        };
    private decimal _price;
    public decimal Price // Цена
    {
        set
        {
            _price = value;
        }
        get { return _price; }
    }               
    private int _quantity;
    public int Quantity // Количество в автомате
    {
        set
        {
            _quantity = value;
        }
        get { return _quantity; }
    }     

    public bool ChooseProduct() // Выбор продукта, возвращает истинность наличия продукта
    {
        if (Quantity < 1)
        {
            Console.WriteLine($"⚠️ Товар №{Id} ({ProductType}) закончился или был введен неверный Id. Выберите другой");
            return false;
        }
        else
        {
            Console.WriteLine($"ℹ️ Товар №{Id} ({ProductType}) выбран");
            return true;
        }
    }

    public bool ReduceProductQuantity() // Уменьшает кол-во при покупке
    {
        Quantity -= 1;
        Console.WriteLine($"✅ Вы приобрели товар №{Id} ({ProductType}).");
        return true;
    }

    public void IncreaseQuantity() // Пополнение товара администратором
    {
        int amount = (5 - Quantity);
        if (amount == 0) { Console.WriteLine("Товара достаточно"); }
        else
        {
            Quantity += amount;
            Console.WriteLine($"✅ Товар №{Id} ({ProductType}) пополнен. В наличии: {Quantity}");
        }
    }

    public Product(int id, string thing, decimal price, int quantity) //инициализируем объект
    {
        Id = id;
        ProductType = thing;
        Price = price;
        Quantity = quantity;
    }

}
