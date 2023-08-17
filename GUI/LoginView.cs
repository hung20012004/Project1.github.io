using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.BUS;
using Project1.DAL;

namespace Project1.GUI
{
    public class LoginView
    {
        
        public static int Menu(){
            while(true){
                UICreater.CreateUI();
                UICreater.CreateMenu(4,"                      LOGIN                       ");
                UICreater.GoTo(13,38);Console.WriteLine("1 . Login");
                UICreater.GoTo(14,38);Console.WriteLine("2 . Register");
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
        public static int ChangePassword(){
            string? oldPass=null;
            string? warnning1=null;
            string? newPass=null;
            string? warnning2=null;
            while(true){
                UICreater.CreateUI();
                UICreater.CreateMenu(7,"                  CHANGE PASSWORD                 ");
                UICreater.GoTo(13,38);Console.WriteLine("1 . Password     : "+oldPass);
                UICreater.GoTo(14,38);Console.WriteLine(warnning1);
                UICreater.GoTo(15,38);Console.WriteLine("2 . New password : "+newPass);
                UICreater.GoTo(16,38);Console.WriteLine(warnning2);
                ConsoleKey choose= Console.ReadKey().Key;
                switch (choose){
                    case ConsoleKey.Escape:
                        return 0;
                    case ConsoleKey.Enter:
                        if(oldPass==LoginController.accountant.password && newPass!=null && warnning2==""){
                            LoginController.accountant.password=newPass;
                            LoginController.accountant.ChangePassword();
                            return 1;
                        }
                        else{
                            UICreater.GoTo(17,38);Console.Write("Please fill all information of the form!");
                            Console.ReadKey();
                        }
                            
                        break;
                    case ConsoleKey.D1:
                        Console.CursorVisible = true;
                        UICreater.GoTo(13,57);Console.Write("                    ");
                        UICreater.GoTo(13,57);oldPass=Console.ReadLine();
                        if (oldPass!=LoginController.accountant.password)
                            warnning1="Password doesn't exactly!";
                        else warnning1="";
                        Console.CursorVisible = false;
                        break;
                    case ConsoleKey.D2:
                        Console.CursorVisible = true;
                        UICreater.GoTo(15,57);Console.Write("                    ");
                        UICreater.GoTo(15,57);newPass=Console.ReadLine();
                        if (newPass.Count()<6)
                            warnning2="New password too short!";
                        else warnning2="";
                        Console.CursorVisible = false;
                        break;
                }
            }
        }
        public static Accountant Register(){
            Accountant account=new();
            string? warnning1="";
            string? warnning2="";
            string? warnning3="";
            while(true){
                UICreater.CreateUI();
                UICreater.CreateMenu(11,"                 CREATE ACCOUNT                   ");
                UICreater.GoTo(13,38);Console.WriteLine("1 . Username : "+account.Username);
                Console.CursorLeft=38;Console.WriteLine(warnning1);
                Console.CursorLeft=38;Console.WriteLine("2 . Password : "+account.password);
                Console.CursorLeft=38;Console.WriteLine(warnning2);
                Console.CursorLeft=38;Console.WriteLine("3 . Name     : "+account.name);
                Console.CursorLeft=38;Console.WriteLine();
                Console.CursorLeft=38;Console.WriteLine("4 . Phone    : "+account.phone);
                Console.CursorLeft=38;Console.WriteLine(warnning3);
                ConsoleKey choose=Console.ReadKey().Key;
                switch (choose)
                {
                    case ConsoleKey.D1:
                        Console.CursorVisible = true;
                        UICreater.GoTo(13,53);Console.Write("                            ");
                        UICreater.GoTo(13,53);account.Username=Console.ReadLine();
                        if(!account.CheckUsername()){
                            warnning1="Username have been existed";
                        } else warnning1="";
                            
                        Console.CursorVisible = false;
                        break;
                    case ConsoleKey.D2:
                        Console.CursorVisible = true;
                        UICreater.GoTo(15,53);Console.Write("                         ");
                        UICreater.GoTo(15,53);account.password=Console.ReadLine();
                        if(account.password.Count()<6){
                            warnning2="Password too short";
                        } else warnning2="";
                        Console.CursorVisible = false;
                        break;
                    case ConsoleKey.D3:
                        Console.CursorVisible = true;
                        UICreater.GoTo(17,53);Console.Write("                        ");
                        UICreater.GoTo(17,53);account.name=Console.ReadLine();
                        Console.CursorVisible = false;
                        break;
                    case ConsoleKey.D4:
                        Console.CursorVisible = true;
                        UICreater.GoTo(19,53);Console.Write("                         ");
                        UICreater.GoTo(19,53);account.phone=Console.ReadLine();
                        if(!account.CheckPhone()){
                            warnning3="This phone have been existed";
                        }
                        else warnning3="";
                        Console.CursorVisible = false;
                        break;
                    case ConsoleKey.Escape:
                        return new();
                    case ConsoleKey.Enter:
                        if(account.Username!=null && account.password!=null && account.phone!=null && account.phone!=null && warnning1==""&&warnning2==""&warnning3=="")
                            return account;
                        else {
                            UICreater.GoTo(21,38);
                            Console.WriteLine("  Please fill all information of the form");
                            Console.ReadLine();
                            break;
                        }   

                }
            }
        }
        public static Accountant Login(){
            Accountant acc=new();
            UICreater.CreateUI();
            UICreater.CreateMenu(5,"                      LOGIN                       ");
            Console.CursorVisible = true;
            UICreater.GoTo(13,38);Console.WriteLine("Username:");
            UICreater.GoTo(14,38);Console.Write("Password:");
            UICreater.GoTo(13,48); acc.Username=Console.ReadLine(); 
            UICreater.GoTo(14,48);acc.password=Console.ReadLine();
            
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
            UICreater.GoTo(15,38);Console.Write("         Login unsuccess!");
            Console.ReadKey();
        }
    }
}