using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.GUI
{
    public class StatisticView
    {
        public static void Menu(){
            while(true){
                Console.Clear();
                while(true){
                    Console.WriteLine("_______STATISTIC______");
                    Console.WriteLine("1.Statistic by showroom");
                    Console.WriteLine("2.Statistic by car");
                    ConsoleKey choose= Console.ReadKey().Key;
                    if (choose==ConsoleKey.Escape) break;
                    else
                    switch (choose){
                        case ConsoleKey.D1:
                            StatistcCar();
                            break;
                        case ConsoleKey.D2:
                            StatistcShowroom();
                            break;

                    }
                }
            }            
        }
        public static void StatistcShowroom(){}
        public static void StatistcCar(){}
    }
}