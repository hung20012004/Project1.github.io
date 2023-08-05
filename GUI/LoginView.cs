using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.DAL;

namespace Project1.GUI
{
    public class LoginView
    {
        public static Accountant LoginLayer(){
            Accountant acc=new();
            Console.Clear();
            UICreater.CreateUI();
            UICreater.CreateLayer();
            Console.CursorVisible = true;
            UICreater.GoTo(9,22);
            Console.BackgroundColor=ConsoleColor.DarkGray;
            Console.ForegroundColor=ConsoleColor.White;
            Console.WriteLine("ID:");
            
            while(true){
                try
                {
                    UICreater.GoTo(9,26); acc.ID=int.Parse(Console.ReadLine());
                    break;
                }
                catch (System.Exception)
                {
                    UICreater.GoTo(9,26); Console.WriteLine("ID must include 6 number digit");
                }
            }    
            UICreater.GoTo(10,22);Console.Write("Password:");
            UICreater.GoTo(10,32);acc.password=Console.ReadLine();
            Console.CursorVisible = false;
            UICreater.GoTo(11,22);Console.WriteLine("Confirm login? Y/N");
            while(true){
                ConsoleKey choose=Console.ReadKey().Key;
                switch (choose)
                {
                    case ConsoleKey.Y:
                        return acc;
                    case ConsoleKey.N:
                        return acc=new();
                }
            }
            Console.ResetColor();
        }
        public static void loginFail(){
            Console.Clear();
            Console.WriteLine("Login unsuccess!");
            Console.ReadKey();
        }
        public static int SalesManagerMenuLayer(){
                
            while(true){
                Console.Clear();
                Console.WriteLine("1.Create order");
                Console.WriteLine("2.Statistic");
                Console.WriteLine("Esc.Log out");
                ConsoleKey choose= Console.ReadKey().Key;
                switch (choose){
                    case ConsoleKey.Escape:
                        return 0;
                    case ConsoleKey.D1:
                        return 1;
                    case ConsoleKey.D2:
                        return 2;
                }
            }
        }
    }
}