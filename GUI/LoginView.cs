using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.DAL;

namespace Project1.GUI
{
    public class LoginView
    {
        
        public static int Menu(){
            while(true){
                UICreater.CreateUI();
                UICreater.CreateMenu(4,"                      LOGIN                       ");
                UICreater.GoTo(13,25);Console.WriteLine("1 . Login");
                UICreater.GoTo(14,25);Console.WriteLine("2 . Register");
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
        public static Accountant Register(){
            Accountant account=new();
            while(true){
                UICreater.CreateUI();
                UICreater.GoTo(8,7); Console.WriteLine("                                  CREATE ACCOUNT                               ");
                Console.CursorLeft=7;Console.WriteLine("───────────────────────────────────────────────────────────────────────────────");
                Console.CursorLeft=9;Console.WriteLine("1 . Username : "+account.Username);
                Console.CursorLeft=9;Console.WriteLine("2 . Password : "+account.password);
                Console.CursorLeft=9;Console.WriteLine("3 . Name     : "+account.name);
                Console.CursorLeft=9;Console.WriteLine("4 . Phone    : "+account.phone);
                ConsoleKey choose=Console.ReadKey().Key;
                switch (choose)
                {
                    case ConsoleKey.D1:
                        Console.CursorVisible = true;
                        UICreater.GoTo(10,24);account.Username=Console.ReadLine();
                        Console.CursorVisible = false;
                        break;
                    case ConsoleKey.D2:
                        Console.CursorVisible = true;
                        UICreater.GoTo(11,24);account.password=Console.ReadLine();
                        Console.CursorVisible = false;
                        break;
                    case ConsoleKey.D3:
                        Console.CursorVisible = true;
                        UICreater.GoTo(12,24);account.name=Console.ReadLine();
                        Console.CursorVisible = false;
                        break;
                    case ConsoleKey.D4:
                        Console.CursorVisible = true;
                        UICreater.GoTo(13,24);account.phone=Console.ReadLine();
                        Console.CursorVisible = false;
                        break;
                    case ConsoleKey.Escape:
                        return new();
                    case ConsoleKey.Enter:
                        return account;
                }
            }
        }
        public static Accountant Login(){
            Accountant acc=new();
            UICreater.CreateUI();
            UICreater.CreateMenu(4,"                      LOGIN                       ");
            Console.CursorVisible = true;
            UICreater.GoTo(13,25);Console.WriteLine("Username:");
            UICreater.GoTo(14,25);Console.Write("Password:");
            UICreater.GoTo(13,35); acc.Username=Console.ReadLine(); 
            UICreater.GoTo(14,35);acc.password=Console.ReadLine();
            
            Console.CursorVisible = false;
            while(true){
                ConsoleKey choose=Console.ReadKey().Key;
                switch (choose)
                {
                    case ConsoleKey.Enter:
                        return acc;
                    case ConsoleKey.Escape:
                        return acc=new();
                }
            }
        }
        public static void loginFail(){
            Console.Clear();
            Console.WriteLine("Login unsuccess!");
            Console.ReadKey();
        }
    }
}