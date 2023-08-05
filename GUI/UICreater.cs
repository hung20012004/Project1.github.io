using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.GUI
{
    public class UICreater
    {
        public static int Warnning(string str){
            while(true){
                GoTo(7,33);
                Console.BackgroundColor=ConsoleColor.Red;Console.ForegroundColor=ConsoleColor.White;
                Console.Write("                  WARNING!                ");
                for(int i=0;i<6;i++){
                    GoTo(i+8,33);
                    Console.BackgroundColor=ConsoleColor.Red;
                    Console.Write("  ");
                    Console.BackgroundColor=ConsoleColor.White;
                    Console.Write("                                      ");
                    Console.BackgroundColor=ConsoleColor.Red;
                    Console.Write("  ");
                    Console.ResetColor();
                }
                Console.BackgroundColor=ConsoleColor.White;
                Console.ForegroundColor=ConsoleColor.Black;
                GoTo(10,37);Console.Write(" Do you want delete this "+str+" ?");
                GoTo(12,37);Console.Write(" y:Yes                   n:No ");
                GoTo(14,33);
                Console.BackgroundColor=ConsoleColor.Red;
                Console.Write("                                          ");
                Console.ResetColor();
                switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Y:
                            return 1;
                        case ConsoleKey.N:
                            return 2;
                    }
            }
        }
        public static void CreateUI(){
            for(int i=0;i<28;i++){
                Console.BackgroundColor=ConsoleColor.Gray;
                Console.Write("        ");
                Console.BackgroundColor=ConsoleColor.White;
                Console.Write(String.Format("{0,76}"," "));
                Console.BackgroundColor=ConsoleColor.Gray;
                Console.WriteLine("        ");
                Console.ResetColor();
            }
            Console.BackgroundColor=ConsoleColor.Blue;
            Console.ForegroundColor=ConsoleColor.White;
            GoTo(0,0);Console.Write("                       │                      │                      │                      ");
            GoTo(1,0);Console.Write("                       │                      │                      │                      ");
            GoTo(2,0);Console.Write("                       │                      │                      │                      ");
            Console.ForegroundColor=ConsoleColor.White;
            GoTo(1,0);Console.Write("          Home");
            GoTo(1,24);Console.Write("         Cars ");
            GoTo(1,48);Console.Write("        Sevice");
            GoTo(1,72);Console.Write("       Login");
            Console.BackgroundColor=ConsoleColor.DarkGray;
            GoTo(27,0);Console.Write("<<(?): Guide >>");
            Console.ResetColor();
        }   
        public static void CreateLayer(){
            Console.BackgroundColor=ConsoleColor.DarkGray;
            Console.ForegroundColor=ConsoleColor.White;
            for(int i=5;i<26;i++){
                GoTo(i,14);
                Console.Write(String.Format("{0,64}"," "));
                
            }
            Console.ResetColor();
        }   
        public static void GoTo(int top,int left){
            Console.CursorTop = top;
            Console.CursorLeft = left;
        }
        public static void Page(int fist,int end){
            Console.BackgroundColor=ConsoleColor.DarkGray;
            Console.ForegroundColor=ConsoleColor.White;
            GoTo(27,40);
            Console.WriteLine("<<Page "+fist+" / "+end+">>");
        }
    }
}