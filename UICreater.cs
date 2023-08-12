using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Project1.BUS;

namespace Project1
{
    public class UICreater
    {
        
        public static void CreateUI(){
            string? user;
            if(LoginController.accountant.ID==0)
                user="USER";
            else    
                user=LoginController.accountant.name;
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│┌───────────────┬─────────────────────────────────────────────────────────────────────────┐│");
            Console.WriteLine("││               │                                                                    (?)  ││");
            Console.WriteLine("││               │                    WELLCOME "+string.Format("{0,-20}",user)+"                        ││");
            Console.WriteLine("││               │                                                                         ││");
            Console.WriteLine("│└───────────────┴─────────────────────────────────────────────────────────────────────────┘│");
            Console.WriteLine("│                                                                                           │");
            Console.WriteLine("│     ┌───────────────────────────────────────────────────────────────────────────────┐     │");
            Console.WriteLine("│     │                                                                               │     │");
            Console.WriteLine("│     │                                                                               │     │");
            Console.WriteLine("│     │                                                                               │     │");
            Console.WriteLine("│     │                                                                               │     │");
            Console.WriteLine("│     │                                                                               │     │");
            Console.WriteLine("│     │                                                                               │     │");
            Console.WriteLine("│     │                                                                               │     │");
            Console.WriteLine("│     │                                                                               │     │");
            Console.WriteLine("│     │                                                                               │     │");
            Console.WriteLine("│     │                                                                               │     │");
            Console.WriteLine("│     │                                                                               │     │");
            Console.WriteLine("│     │                                                                               │     │");
            Console.WriteLine("│     │                                                                               │     │");
            Console.WriteLine("│     │                                                                               │     │");
            Console.WriteLine("│     │                                                                               │     │");
            Console.WriteLine("│     │                                                                               │     │");
            Console.WriteLine("│     │                                                                               │     │");
            Console.WriteLine("│     └───────────────────────────────────────────────────────────────────────────────┘     │");
            Console.WriteLine("│                                                                                           │");
            Console.WriteLine("└───────────────────────────────────────────────────────────────────────────────────────────┘");
        }   
        public static void CreateMenu(int row,string title){
            
            GoTo(9,20);Console.WriteLine("┌──────────────────────────────────────────────────┐");
            Console.CursorLeft = 20;Console.WriteLine("│"+title+"│");
            Console.CursorLeft = 20;Console.WriteLine("│┌────────────────────────────────────────────────┐│");
            for(int i=0;i<row;i++){
                Console.CursorLeft = 20;Console.WriteLine("││                                                ││");
            }
            Console.CursorLeft = 20;Console.WriteLine("│└────────────────────────────────────────────────┘│");
            Console.CursorLeft = 20;Console.WriteLine("└──────────────────────────────────────────────────┘");
        }   
        public static void GoTo(int top,int left){
            Console.CursorTop = top;
            Console.CursorLeft = left;
        }
        public static void Page(int fist,int end){
            GoTo(26,38);
            Console.WriteLine("<<Page "+fist+" / "+end+">>");
        }
        
    }
}