using System;
using EmployeManagement.Models;
using EmployeManagement.Interfaces;
using EmployeManagement.Models;
using EmployeManagement.Services;

namespace EmployeManagement
{
    class Program
    {
        static void Main(string[] args)
        {

            do
            {
                Console.WriteLine("Seciminizi Edin");
                Console.WriteLine("1. Departameantlerin siyahisini gostermek");
                Console.WriteLine("2. Departamenet yaratmaq");
                Console.WriteLine("3. Departmanetde deyisiklik etmek");
                Console.WriteLine("4. Iscilerin siyahisini gostermek");
                Console.WriteLine("5. Departamentdeki iscilerin siyahisini gostermrek");
                Console.WriteLine("6. Isci elave etmek");
                Console.WriteLine("7. Isci uzerinde deyisiklik etmek");
                Console.WriteLine("8. Departamentden isci silinmesi");
                Console.WriteLine("9. exit");

                int choose;
                while (!int.TryParse(Console.ReadLine(), out choose) || choose < 1 || choose > 9)
                {
                    Console.WriteLine("Duzgun Secim Edin");
                }

                switch (choose)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        Console.WriteLine("Tesekkurler Sagolun");
                        return;
                }
            } while (true);
        }
    }
}