using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.GUI
{
    public class HomeView
    {
        public static int CustomerMenu(){
            while(true){
                UICreater.CreateUI();
                UICreater.CreateMenu(6,"                  CUSTOMER MENU                   ");
                UICreater.GoTo(13,38);Console.WriteLine(" 1 . Cars");
                Console.CursorLeft=38;Console.WriteLine(" 2 . Create request");
                Console.CursorLeft=38;Console.WriteLine(" 3 . My request");
                Console.CursorLeft=38;Console.WriteLine(" 4 . Change password");
                ConsoleKey choose= Console.ReadKey().Key;
                switch (choose){
                    case ConsoleKey.Escape:
                        return -1;
                    case ConsoleKey.D1:
                        return 1;
                    case ConsoleKey.D2:
                        return 2;
                    case ConsoleKey.D3:
                        return 3;
                    case ConsoleKey.D4:
                        return 4;
                }
            }
                        
        }
        public static int ManagerMenu(){
            while(true){
                UICreater.CreateUI();
                UICreater.CreateMenu(4,"                  MANAGER MENU                    ");
                UICreater.GoTo(13,38);Console.WriteLine(" 1 . Create order");
                Console.CursorLeft=38;Console.WriteLine(" 2 . Statistic");
                ConsoleKey choose= Console.ReadKey().Key;
                switch (choose){
                    case ConsoleKey.Escape:
                        return -1;
                    case ConsoleKey.D1:
                        return 1;
                    case ConsoleKey.D2:
                        return 2;
                }
            }
                        
        }
        public static int SalesMenu(){
            while(true){
                UICreater.CreateUI();
                UICreater.CreateMenu(5,"                   SALES MENU                     ");
                UICreater.GoTo(13,38);Console.WriteLine(" 1 . Requests");
                Console.CursorLeft=38;Console.WriteLine(" 2 . View processing request");
                Console.CursorLeft=38;Console.WriteLine(" 3 . My processed request");
                ConsoleKey choose= Console.ReadKey().Key;
                switch (choose){
                    case ConsoleKey.Escape:
                        return -1;
                    case ConsoleKey.D1:
                        return 1;
                    case ConsoleKey.D2:
                        return 2;
                    case ConsoleKey.D3:
                        return 3;
                }
            }
                        
        }
        public static int AdminMenu(){
            while(true){
                UICreater.CreateUI();
                UICreater.CreateMenu(4,"                   ADMIN MENU                     ");
                UICreater.GoTo(13,38);Console.WriteLine(" 1 . Update car");
                Console.CursorLeft=38;Console.WriteLine(" 2 . Insert car");
                ConsoleKey choose= Console.ReadKey().Key;
                switch (choose){
                    case ConsoleKey.Escape:
                        return -1;
                    case ConsoleKey.D1:
                        return 1;
                    case ConsoleKey.D2:
                        return 2;
                }
            }
                        
        }
    }
}