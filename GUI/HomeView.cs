using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.GUI
{
    public class HomeView
    {
        public static int MenuLayer(){
            while(true){
                Console.Clear();
                UICreater.CreateUI();
                ConsoleKey choose= Console.ReadKey().Key;
                
                switch (choose){
                    case ConsoleKey.Escape:
                        return 0;
                    case ConsoleKey.D1:
                        return 1;
                    case ConsoleKey.D2:
                        return 2;
                    case ConsoleKey.D3:
                        return 3;
                }
            }
                        
        }
    }
}