using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.DAL;
using Project1.BUS;
using System.Text.RegularExpressions;

namespace Project1.GUI
{
    public class  RequestView
    {
        public static Request requestFormLayer( Car car){
            Request request=new();
            Showroom showroom=new();
            while(true){
                Console.Clear();
                UICreater.CreateUI();
                UICreater.CreateLayer();
                //Console.WriteLine("_______REQUEST_______"); 
                UICreater.GoTo(9,22);
                Console.BackgroundColor=ConsoleColor.DarkGray;
                Console.ForegroundColor=ConsoleColor.White;
                Console.WriteLine("1. Showroom: "+showroom.Name);Console.CursorLeft = 22;
                Console.WriteLine("2. Car: "+car.Name);Console.CursorLeft = 22;
                Console.WriteLine("3. Name: "+request.customerName);Console.CursorLeft = 22;
                Console.WriteLine("4. Phone: "+request.phone);Console.CursorLeft = 22;
                Console.WriteLine("5. Address: "+request.address);Console.CursorLeft = 22;
                Console.WriteLine("6. Note: "+request.note);
                
                ConsoleKey choose=Console.ReadKey().Key;
                switch (choose){
                    case ConsoleKey.Enter:
                        if(request.customerName != null && request.address != null && request.carID!=0 && request.showroomID!=0 && request.phone!=null)
                            return request;    
                        else{
                            Console.WriteLine(request.customerName+" "+request.address+" "+request.carID+" "+request.showroomID+" "+request.phone);
                            Console.WriteLine("Please fill all information of the form!");
                            Console.ReadKey();
                            Console.ResetColor();
                        }
                        break;
                    case ConsoleKey.D1: 
                        showroom=chooseShowroomLayer();
                        request.showroomID=showroom.ID;
                        Console.ResetColor();
                        break;
                    case ConsoleKey.D2: 
                        car=SearchCarView.CarsLayer();
                        request.carID=car.ID;
                        break;
                    case ConsoleKey.D3:
                        UICreater.GoTo(11,31);
                        Console.CursorVisible = true;
                        request.customerName=Console.ReadLine();
                        Console.CursorVisible = false;
                        Console.ResetColor();
                        break;
                    case ConsoleKey.D4:
                        UICreater.GoTo(12,32);
                        Console.CursorVisible = true;
                        request.phone=Console.ReadLine();
                        if(!Regex.IsMatch(request.phone, @"^[0]\d\d\d\d\d\d\d\d\d")){
                            InvalidPhoneLayer();
                            request.phone=null;
                        }
                        Console.CursorVisible = false;
                        Console.ResetColor();
                        break;
                    case ConsoleKey.D5:
                        UICreater.GoTo(13,34);
                        Console.CursorVisible = true;
                        request.address=Console.ReadLine();
                        Console.CursorVisible = false;
                        Console.ResetColor();
                        break;
                    case ConsoleKey.D6:
                        UICreater.GoTo(14,35);
                        Console.CursorVisible = true;
                        request.note=Console.ReadLine();
                        Console.CursorVisible = false;
                        Console.ResetColor();
                        break;
                    case ConsoleKey.Escape:
                        return request;
                }
            }
        }
        public static Showroom chooseShowroomLayer(){
            RequestController requestController=new RequestController();
            List<Showroom> showrooms=requestController.getShowroomData();
            while(true){
                Console.Clear();
                Console.WriteLine("_______SHOWROOMS_______");
                for(int i=0;i<showrooms.Count();i++){
                    Console.WriteLine((i+1)+" : "+showrooms[i].Name);
                }
                ConsoleKey choose=Console.ReadKey().Key;
                switch (choose)
                {
                    case ConsoleKey.Escape : 
                        Showroom showroom=new();
                        return showroom; 
                    case ConsoleKey.D1 : 
                        return showrooms[0];
                    case ConsoleKey.D2 : 
                        return showrooms[1];
                     case ConsoleKey.D3 : 
                        return showrooms[2];
                    case ConsoleKey.D4 : 
                        return showrooms[3];
                    case ConsoleKey.D5 : 
                        return showrooms[4];
                    case ConsoleKey.D6 : 
                        return showrooms[5];
                    case ConsoleKey.D7 : 
                        return showrooms[6];
                    case ConsoleKey.D8 : 
                        return showrooms[7];
                    case ConsoleKey.D9 : 
                        return showrooms[8];
                }
            }
        }
        public static int ConfirmRequestLayer(){
            while(true){
                Console.Clear();
                Console.WriteLine("Confirm request");
                ConsoleKey choose= Console.ReadKey().Key;
                switch (choose){
                    case ConsoleKey.Y:
                        return 1;
                    case ConsoleKey.N:
                        return 0;
                }
            }  
        }
        public static void InvalidPhoneLayer(){}
        public void requestSuccessLayer(){}
        public void requestFailLayer(){}
        public void requestCanceledLayer(){}
    }
}