using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{    
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>
            {
                new User {Name = "Иван", Age = 31, Sex = "Male", Balance = 400},
                new User {Name = "Женя", Age = 24, Sex = "Male", Balance = 21000},
                new User {Name = "Даша", Age = 22, Sex = "Female", Balance = 570},
                new User {Name = "Лёша", Age = 25, Sex = "Male", Balance = 14758},
                new User {Name = "Соня", Age = 27, Sex = "Female", Balance = 4792}
            };

            var oldestAge = users.Max(a => a.Age);
            var selectedUsers = users.Where(a => a.Age == oldestAge);
            Console.WriteLine("Больше всех лет: ");
            foreach (User user in selectedUsers)
                Console.WriteLine("{0} - {1}", user.Name, user.Age);

            var bigMoney = users.Max(b => b.Balance);
            var selectedUsers1 = users.Where(b => b.Balance == bigMoney);
            Console.WriteLine("\nБольше всех денег: ");
            foreach (User user in selectedUsers1)
                Console.WriteLine("{0} - {1}", user.Name, user.Balance);

            var selectedUsers3 = users.Where(b => b.Balance == bigMoney || b.Age == oldestAge);
            Console.WriteLine("\nБольше всех денег и лет: ");
            foreach (User user in selectedUsers3)
                Console.WriteLine("{0}", user.Name);

            var selectedUsers4 = users.Where(b => b.Balance > 4000);
            Console.WriteLine("\nБаланс больше 4000: ");
            int i = 0;
            foreach (User user in selectedUsers4)
                {
                Console.WriteLine("{0}", user.Name);
                i++;
                }
            Console.WriteLine("\nОбщее количество человек, у которых баланс больше 4000: {0}", i);

            var sortedUsersAge = users.OrderByDescending(a => a.Age); //по убыванию
            Console.WriteLine("\nСортировка по возрасту:");
            foreach (User user in sortedUsersAge)
                Console.WriteLine("{0} - {1} - {2} - {3}", user.Name, user.Age, user.Sex, user.Balance);

            var sortedUsersSex = users.OrderByDescending(s => s.Sex);
            Console.WriteLine("\nСортировка по полу:");
            foreach (User user in sortedUsersSex)
                Console.WriteLine("{0} - {1} - {2} - {3}", user.Name, user.Age, user.Sex, user.Balance);

            var sortedUsersBalance = users.OrderBy(b => b.Balance); //по возрастанию
            Console.WriteLine("\nСортировка по балансу:");
            foreach (User user in sortedUsersBalance)
                Console.WriteLine("{0} - {1} - {2} - {3}", user.Name, user.Age, user.Sex, user.Balance);

            Console.ReadLine();
        }
    }
}
