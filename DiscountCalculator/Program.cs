using System;

namespace DiscountСalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вы хотите добавить новый продукт? 1 - да, 2 - нет");

            int.TryParse(Console.ReadLine(), out var answer);

            if (answer != 1)
                return;

            CreateProduct();

            Console.ReadLine();
        }

        private static void CreateProduct()
        {
            var product = new Product();

            Console.WriteLine("Введите название продукта");

            product.Name = Console.ReadLine();

            Console.WriteLine("Введите стоимость продукта");

            int.TryParse(Console.ReadLine(), out var price);

            while (price <= 0)
            {
                Console.WriteLine("Стоимость продукта не была введена или она была введена с ошибкой. Пожалуйста, введите стоимость продукта ещё раз");

                int.TryParse(Console.ReadLine(), out price);
            }

            product.Price = price;

            Console.WriteLine("Выберите тип скидки 1 - процент от стоимости, 2 - сумма от стоимости, 3 - подарочная карта");

            int.TryParse(Console.ReadLine(), out var answer2);

            while (answer2 != 1 & answer2 != 2 & answer2 != 3)
            {
                Console.WriteLine("Некорректный ответ");

                Console.WriteLine("Выберите тип скидки 1 - процент от стоимости, 2 - сумма от стоимости,  3 - подарочная карта");

                int.TryParse(Console.ReadLine(), out answer2);
            }

            if (answer2 == 1)
            {
                Console.WriteLine("Введите значение скидки на товар (в % от общей стоимости)");

                int.TryParse(Console.ReadLine(), out var percentDiscountValue);

                while (percentDiscountValue > 100 || percentDiscountValue < 0)
                {
                    Console.WriteLine("Значение скидки не было введено или оно было введено с ошибкой. Пожалуйста, введите значение скидки (в % от общей стоимости) ещё раз");

                    int.TryParse(Console.ReadLine(), out percentDiscountValue);
                }

                int discountValue = product.Price * percentDiscountValue / 100;

                product.DiscountValue = discountValue;
            }

            if (answer2 == 2 || answer2 == 3)
            {
                Console.WriteLine("Введите значение скидки на товар");

                int.TryParse(Console.ReadLine(), out var discountValue);

                while (discountValue < 0)
                {
                    Console.WriteLine("Значение скидки не было введено или оно было введено с ошибкой. Пожалуйста, введите значение скидки ещё раз");

                    int.TryParse(Console.ReadLine(), out discountValue);
                }

                product.DiscountValue = discountValue;                
            }

            int answer31 = 0; // глобальная переменная

            if (answer2 == 1 || answer2 == 2)
            {
                Console.WriteLine("У скидки есть срок действия? 1 - да, 2 - нет");

                int.TryParse(Console.ReadLine(), out var answer3);

                while (answer3 != 1 & answer3 != 2)
                {
                    Console.WriteLine("Некорректный ответ");

                    Console.WriteLine("У скидки есть срок действия? 1 - да, 2 - нет");

                    int.TryParse(Console.ReadLine(), out answer3);
                }

                answer31 = answer3; // преобразование локальной переменной в глобальную
            }
                                    
            if (answer31 == 1 || answer2 == 3) 
            {
                Console.WriteLine("Введите дату начала действия скидки (dd.mm.yyyy)");

                DateTime.TryParse(Console.ReadLine(), out var startSellDate);
                
                if (startSellDate != DateTime.MinValue)
                {
                    product.StartSellDate = startSellDate;
                }

                Console.WriteLine("Введите дату окончания действия скидки (dd.mm.yyyy)");

                DateTime.TryParse(Console.ReadLine(), out var endSellDate);

                if (endSellDate != DateTime.MinValue)
                {
                    product.EndSellDate = endSellDate;
                }
            }

            if (answer31 == 2)
            {
                product.StartSellDate = DateTime.UtcNow.AddDays(-1); //устанавливает вчера как дату начала действия скидки

                product.EndSellDate = DateTime.UtcNow.AddDays(1);    //устанавливает завтра как дату окончания действия скидки               
            }
            
            Console.WriteLine($"Вы успешно добавили новый продукт: {product.Name}, стоимость - {product.Price}р. {product.GetSellInformation()}");
        }
    }
}
