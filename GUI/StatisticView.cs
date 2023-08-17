using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.BUS;
using Project1.DAL;

namespace Project1.GUI
{
    public class StatisticView
    {
        public static void Menu(){
            while(true){
                UICreater.CreateUI();
                UICreater.CreateMenu(4,"                    STATISTIC                     ");
                UICreater.GoTo(13,38);Console.WriteLine("1 . Statistic by car");
                UICreater.GoTo(14,38);Console.WriteLine("2 . Statistic by showroom");
                ConsoleKey choose= Console.ReadKey().Key;
                if (choose==ConsoleKey.Escape) break;
                else
                    switch (choose){
                        case ConsoleKey.D1:
                            StatisticCar();
                            break;
                        case ConsoleKey.D2:
                            StatisticShowroom();
                            break;

                    }
            }            
        }
        public static void StatisticCar(){
            int year=2023;
            int month=1;
            while(true){
                UICreater.CreateUI();
                StatisticController controller=new();
                List<Order> orders=controller.CarStatistic(month,year);
                UICreater.GoTo(8,7); Console.WriteLine("                                              CAR STATISTIC                              ");
                Console.CursorLeft=7;Console.WriteLine("─────────────────────────────────────────────────────────────────────────────────────────────────────────");
                Console.CursorLeft=7;Console.WriteLine("                                        F1. Year: "+year);
                Console.CursorLeft=7;Console.WriteLine("                                        F2. Month: "+month);
                Console.CursorLeft=7;Console.WriteLine("───────────────────────────────────────────────────┬─────────────────────────────────────────────────────");
                Console.CursorLeft=7;Console.WriteLine("                           CAR                     │                  REVENUE                           ");
                Console.CursorLeft=7;Console.WriteLine("───────────────────────────────────────────────────┼─────────────────────────────────────────────────────");
                if(orders.Count()==0){
                    UICreater.GoTo(16,53);
                    Console.Write("No result!"); 
                }  
                else 
                    for(int i=0;i<orders.Count;i++){
                        Console.CursorLeft=7;Console.WriteLine(string.Format("{0,-51}","               "+orders[i].carName)+"│               "+orders[i].totalBill+"vnđ");
                    }  
                ConsoleKey choose=Console.ReadKey().Key;
                if(choose==ConsoleKey.Escape) break;    
                else{
                    switch (choose){
                        case ConsoleKey.F1:
                            UICreater.GoTo(10,57);
                            Console.CursorVisible = true;
                            Console.WriteLine("                      ");
                            UICreater.GoTo(10,57);
                            year=int.Parse(Console.ReadLine());
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.F2:
                            Console.CursorVisible = true;
                            UICreater.GoTo(11,58);
                            Console.WriteLine("                      ");
                            UICreater.GoTo(11,58);
                            month=int.Parse(Console.ReadLine());
                            Console.CursorVisible = false;
                            break;
                        }   
                    }
                
            }
        }
        public static void StatisticShowroom(){
        int year=2023;
            int month=1;
            while(true){
                UICreater.CreateUI();
                StatisticController controller=new();
                List<Order> orders=controller.showroomStatistic(month,year);
                UICreater.GoTo(8,7); Console.WriteLine("                                           SHOWROOM STATISTIC                            ");
                Console.CursorLeft=7;Console.WriteLine("─────────────────────────────────────────────────────────────────────────────────────────────────────────");
                Console.CursorLeft=7;Console.WriteLine("                                        F1. Year: "+year);
                Console.CursorLeft=7;Console.WriteLine("                                        F2. Month: "+month);
                Console.CursorLeft=7;Console.WriteLine("───────────────────────────────────────────────────┬─────────────────────────────────────────────────────");
                Console.CursorLeft=7;Console.WriteLine("                      SHOWROOM                     │                  REVENUE                           ");
                Console.CursorLeft=7;Console.WriteLine("───────────────────────────────────────────────────┼─────────────────────────────────────────────────────");
                if(orders.Count()==0){
                    UICreater.GoTo(16,53);
                    Console.Write("No result!"); 
                }  
                else 
                    for(int i=0;i<orders.Count;i++){
                        Console.CursorLeft=7;Console.WriteLine(string.Format("{0,-51}","               "+orders[i].showroomName)+"│               "+orders[i].totalBill+"vnđ");
                    }  
                ConsoleKey choose=Console.ReadKey().Key;
                if(choose==ConsoleKey.Escape) break;    
                else{
                    switch (choose){
                        case ConsoleKey.F1:
                            UICreater.GoTo(10,57);
                            Console.CursorVisible = true;
                            Console.WriteLine("                      ");
                            UICreater.GoTo(10,57);
                            year=int.Parse(Console.ReadLine());
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.F2:
                            Console.CursorVisible = true;
                            UICreater.GoTo(11,58);
                            Console.WriteLine("                      ");
                            UICreater.GoTo(11,58);
                            month=int.Parse(Console.ReadLine());
                            Console.CursorVisible = false;
                            break;
                        }   
                    }
                
            }
        }
            
    }
}