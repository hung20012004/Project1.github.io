using System;
using System.Data;
using System.Text;
using Project1.GUI;
using Project1.BUS;
using Project1.DAL;
namespace Project1
{
    class Program{
        
        
        static void Main(string[] args){    
            Console.WindowWidth = 93;
            Console.WindowHeight = 28;
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            DBHelper.GetConnection();
            DBHelper.OpenConnection();

            HomeController controller=new HomeController();
            controller.updateView();
            
            DBHelper.CloseConnection();
        }
        
    }
}
