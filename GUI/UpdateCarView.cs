using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.DAL;
using Project1.BUS;

namespace Project1.GUI
{
    public class UpdateCarView
    {
        public static Car CreateCar(){
            Model model=new();
            Saloon saloon=new();
            Car car=new();
            while(true){
                UICreater.CreateUI();
                UICreater.CreateMenu(5,"                   INSERT CAR                     ");
                UICreater.GoTo(13,25);Console.WriteLine(" 1 . Model: "+model.name);
                Console.CursorLeft=25;Console.WriteLine(" 2 . Saloon: "+saloon.name);
                Console.CursorLeft=25;Console.WriteLine(" 3 . Car information ");
                ConsoleKey choose= Console.ReadKey().Key;
                switch (choose){
                    case ConsoleKey.Escape or ConsoleKey.Enter:
                        car.Salloon_ID=saloon.ID;
                        return car;
                    case ConsoleKey.D1:
                        model=SearchCarView.ChooseModel();
                        saloon=new();
                        break;
                    case ConsoleKey.D2:
                        saloon=SearchCarView.ChooseSaloon(model);
                        break;
                    case ConsoleKey.D3:
                        car=InsertDetail();
                        break;
                }
            }
        }
        public static Car InsertDetail(){
            Console.CursorVisible = false;
            Car car=new();          
                while(true){
                    Console.Clear();
                    UICreater.CreateUI();
                    UICreater.GoTo(8,7);   Console.WriteLine("                                   INSERT DETAIL                               ");
                    Console.CursorLeft=7;  Console.WriteLine("───────────────────────────────────────────────────────────────────────────────");
                    Console.CursorLeft = 9;Console.WriteLine("1 . Engine             │ "+car.Engine);
                    Console.CursorLeft = 9;Console.WriteLine("2 . Number of Cylinder │ "+car.Cylinder);
                    Console.CursorLeft = 9;Console.WriteLine("3 . Displacement       │ "+car.Displacement);
                    Console.CursorLeft = 9;Console.WriteLine("4 . Max speed          │ "+car.max_speed);
                    Console.CursorLeft = 9;Console.WriteLine("5 . Price              │ "+car.Price);
                    Console.CursorLeft = 9;Console.WriteLine("6 . Colors             │ "+car.Colors);
                    Console.CursorLeft = 9;Console.WriteLine("7 . Uphostery          │ "+car.Uphostery);
                    Console.CursorLeft = 9;Console.WriteLine("8 . Height             │ "+car.Height);
                    Console.CursorLeft = 9;Console.WriteLine("9 . Weight             │ "+car.Weight);
                    Console.CursorLeft = 9;Console.WriteLine("A . Length             │ "+car.Length);
                    Console.CursorLeft = 9;Console.WriteLine("B . Width              │ "+car.Width);
                    Console.CursorLeft = 9;Console.WriteLine("C . Quantity in stock  │ "+car.quantity);
                    Console.CursorLeft = 9;Console.WriteLine("D . Number of door     │ "+car.door_num);
                    Console.CursorLeft = 9;Console.WriteLine("E . Number of seat     │ "+car.seat_num);
                    ConsoleKey choose=Console.ReadKey().Key;
                    switch (choose)
                    {
                        case ConsoleKey.D1:
                            Console.CursorVisible = true;
                            UICreater.GoTo(10,34);car.Engine=Console.ReadLine();
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.D2:
                            Console.CursorVisible = true;
                            UICreater.GoTo(11,34);car.Cylinder=int.Parse(Console.ReadLine());
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.D3:
                            Console.CursorVisible = true;
                            UICreater.GoTo(12,34);car.Displacement=double.Parse(Console.ReadLine());
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.D4:
                            Console.CursorVisible = true;
                            UICreater.GoTo(13,34);car.max_speed=int.Parse(Console.ReadLine());
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.D5:
                            Console.CursorVisible = true;
                            UICreater.GoTo(14,34);car.Price=long.Parse(Console.ReadLine());
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.D6:
                            Console.CursorVisible = true;
                            UICreater.GoTo(15,34);car.Colors=Console.ReadLine();
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.D7:
                            Console.CursorVisible = true;
                            UICreater.GoTo(16,34);car.Uphostery=Console.ReadLine();
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.D8:
                            Console.CursorVisible = true;
                            UICreater.GoTo(17,34);car.Height=double.Parse(Console.ReadLine());
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.D9:
                            Console.CursorVisible = true;
                            UICreater.GoTo(18,34);car.Weight=double.Parse(Console.ReadLine());
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.A:
                            Console.CursorVisible = true;
                            UICreater.GoTo(19,34);car.Length=double.Parse(Console.ReadLine());
                            Console.CursorVisible = false;
                            break;    
                        case ConsoleKey.B:
                            Console.CursorVisible = true;
                            UICreater.GoTo(20,34);car.Width=double.Parse(Console.ReadLine());
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.C:
                            Console.CursorVisible = true;
                            UICreater.GoTo(21,34);car.quantity=int.Parse(Console.ReadLine());
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.D:
                            Console.CursorVisible = true;
                            UICreater.GoTo(21,34);car.door_num=int.Parse(Console.ReadLine());
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.E:
                            Console.CursorVisible = true;
                            UICreater.GoTo(21,34);car.seat_num=int.Parse(Console.ReadLine());
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.Escape: 
                            return new();        
                        case ConsoleKey.Enter: 
                            return car;         
                    }
                }
        }
        public static Car UpdateCar(){
            Console.CursorVisible = false;
            Car car=SearchCarView.Cars();  
            if(car.ID!=0){         
                while(true){
                    Console.Clear();
                    UICreater.CreateUI();
                    UICreater.GoTo(8,7);   Console.WriteLine("                                   UPDATE DETAIL                               ");
                    Console.CursorLeft=7;  Console.WriteLine("───────────────────────────────────────────────────────────────────────────────");
                    Console.CursorLeft = 9;Console.WriteLine("1 . Engine             │ "+car.Engine);
                    Console.CursorLeft = 9;Console.WriteLine("2 . Price              │ "+car.Price);
                    Console.CursorLeft = 9;Console.WriteLine("3 . Colors             │ "+car.Colors);
                    Console.CursorLeft = 9;Console.WriteLine("4 . Uphostery          │ "+car.Uphostery);
                    Console.CursorLeft = 9;Console.WriteLine("5 . Height             │ "+car.Height);
                    Console.CursorLeft = 9;Console.WriteLine("6 . Weight             │ "+car.Weight);
                    Console.CursorLeft = 9;Console.WriteLine("7 . Length             │ "+car.Length);
                    Console.CursorLeft = 9;Console.WriteLine("8 . Width              │ "+car.Width);
                    Console.CursorLeft = 9;Console.WriteLine("9 . Quantity in stock  │ "+car.quantity);
                    Console.CursorLeft = 9;Console.WriteLine("0 . Delete ");
                    ConsoleKey choose=Console.ReadKey().Key;
                    switch (choose)
                    {
                        case ConsoleKey.D1:
                            Console.CursorVisible = true;
                            UICreater.GoTo(10,9);Console.Write("1 . Engine            │                          ");
                            UICreater.GoTo(10,34);car.Engine=Console.ReadLine();
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.D2:
                            Console.CursorVisible = true;
                            UICreater.GoTo(11,9);Console.Write("2 . Price             │                        ");
                            UICreater.GoTo(11,34);car.Price=long.Parse(Console.ReadLine());
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.D3:
                            Console.CursorVisible = true;
                            UICreater.GoTo(12,9);Console.Write("3 . Colors            │                                           ");
                            UICreater.GoTo(12,34);car.Colors=Console.ReadLine();
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.D4:
                            Console.CursorVisible = true;
                            UICreater.GoTo(13,9);Console.Write("4 . Uphostery          │                                           ");
                            UICreater.GoTo(13,34);car.Uphostery=Console.ReadLine();
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.D5:
                            Console.CursorVisible = true;
                            UICreater.GoTo(14,9);Console.Write("5 . Height             │                            ");
                            UICreater.GoTo(14,34);car.Height=double.Parse(Console.ReadLine());
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.D6:
                            Console.CursorVisible = true;
                            UICreater.GoTo(15,9);Console.Write("6 . Weight             │                            ");
                            UICreater.GoTo(15,34);car.Weight=double.Parse(Console.ReadLine());
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.D7:
                            Console.CursorVisible = true;
                            UICreater.GoTo(16,9);Console.Write("7 . Length             │                           ");
                            UICreater.GoTo(16,34);car.Length=double.Parse(Console.ReadLine());
                            Console.CursorVisible = false;
                            break;    
                        case ConsoleKey.D8:
                            Console.CursorVisible = true;
                            UICreater.GoTo(17,9);Console.Write("8 . Width              │                              ");
                            UICreater.GoTo(17,34);car.Width=double.Parse(Console.ReadLine());
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.D9:
                            Console.CursorVisible = true;
                            UICreater.GoTo(18,9);Console.Write("9 . Quantity in stock  │                              ");
                            UICreater.GoTo(18,34);car.quantity=int.Parse(Console.ReadLine());
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.D0:
                            car.Name="Delete";
                            return car;
                        case ConsoleKey.Escape or ConsoleKey.Enter:
                            return car;                
                    }
                }
            }
            return car;
        }
        public static void WarningExistedCar(){
            UICreater.CreateUI();
            UICreater.CreateMenu(3,"                     WARNING                      ");
            UICreater.GoTo(13,25);Console.WriteLine(" This car had been existed in Database ");
            Console.ReadKey();
        }
    }
}