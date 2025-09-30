using System.Reflection;
using System.Xml.Linq;

public static class MoneyCollector
{
    private static decimal _totalAmount = 20; // Автомат имеет начальную сумму в 20 рублей

    public static void AddCoin(decimal sum) // Статический метод для подсчета полученных монет
    {
        _totalAmount += sum;
    }

    public static bool GetTotal() // Выдача денег администратору
    {
        while (true)
        {
            Console.Write($"ℹ️ В автомате {_totalAmount} руб. Забрать всю сумму (да), забрать часть (часть): ");

            string answer = Console.ReadLine();

            if (answer == "да")
            {
                Console.WriteLine($"🪙 Вы забрали {_totalAmount} руб.");
                _totalAmount = 0;
                return true;
            }
            else if (answer == "часть")
            {
                while (true)
                {
                    Console.WriteLine("Внесите сумму, которую хотите забрать: ");
                    string amount = Console.ReadLine();
                    if (decimal.TryParse(amount, out decimal coin))
                    {
                        if (coin <= _totalAmount) // Проверяем, что можем выдать нужную сумму
                        {
                            Console.WriteLine($"🪙 Вы забрали {coin} руб.");
                            _totalAmount -= coin;
                            Console.WriteLine($"ℹ️ В автомате осталось {_totalAmount} руб.");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Невозможно выдать такую сумму. Отменить операцию (д/н): ");
                            string answer_2 = Console.ReadLine();
                            if (answer_2 == "д")
                            {
                                return false;
                            }
                            else if (answer_2 != "н" && answer_2 != "д")
                            {
                                Console.WriteLine("Некорректный ввод. Попробуйте еще раз");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод. Попробуйте еще раз");
                    }
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Попробуйте еще раз");
            }
        }
            
    }
}

