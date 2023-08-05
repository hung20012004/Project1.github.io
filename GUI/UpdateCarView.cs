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
        
        public static int MenuLayer(){
            while(true){
                Console.Clear();
                Console.WriteLine("1.Update car");
                Console.WriteLine("2.Create a new car");
                Console.WriteLine("Esc.Log out");
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
        public static Car CreateCarLayer(){
            Model model=new();
            Saloon saloon=new();
            Car car=new();
            while(true){
                Console.Clear();
                Console.WriteLine("_______Create car______");
                Console.WriteLine("1. Model: "+model.name);
                Console.WriteLine("2. Saloon: "+saloon.name);
                Console.WriteLine("3. Car information ");
                ConsoleKey choose= Console.ReadKey().Key;
                switch (choose){
                    case ConsoleKey.Escape or ConsoleKey.Enter:
                        car.Salloon_ID=saloon.ID;
                        return car;
                    case ConsoleKey.D1:
                        model=SearchCarView.ChooseModelLayer();
                        saloon=new();
                        break;
                    case ConsoleKey.D2:
                        saloon=SearchCarView.ChooseSaloonLayer(model);
                        break;
                    case ConsoleKey.D3:
                        car=InsertDetailLayer();
                        break;
                }
            }
        }
        public static Car InsertDetailLayer(){
            Car car=new();
            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("______Create Car______");
            Console.Write("Name: ");
            car.Name=Console.ReadLine();
            Console.Write("Engine: ");
            car.Engine=Console.ReadLine();
            Console.Write("Colors: ");
            car.Colors=Console.ReadLine();
            Console.Write("Uphostery: ");
            car.Uphostery=Console.ReadLine();
            Console.Write("Number of cylinder: ");
            car.Cylinder=int.Parse(Console.ReadLine());
            Console.Write("Displacement: ");
            car.Displacement=double.Parse(Console.ReadLine());
            Console.Write("Length: ");
            car.Length=double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            car.Width=double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            car.Height=double.Parse(Console.ReadLine());
            Console.Write("Weight: ");
            car.Weight=double.Parse(Console.ReadLine());
            Console.Write("Max speed: ");
            car.max_speed=int.Parse(Console.ReadLine());
            Console.Write("Number of door: ");
            car.door_num=int.Parse(Console.ReadLine());
            Console.Write("Number of seat: ");
            car.seat_num=int.Parse(Console.ReadLine());
            Console.Write("Price: ");
            car.Price=long.Parse(Console.ReadLine());
            Console.CursorVisible = true;
            return car;
        }
        public static Car UpdateCarLayer(){
            Console.CursorVisible = false;
            Car car=SearchCarView.CarsLayer();  
            if(car.ID!=0){         
                while(true){
                    Console.Clear();
                    UICreater.CreateUI();
                    
                    Console.BackgroundColor=ConsoleColor.White;
                    Console.ForegroundColor=ConsoleColor.Black;

                    UICreater.GoTo(7,12);Console.Write("1 . Engine: "+car.Engine);
                    UICreater.GoTo(8,12);Console.Write("2 . Price: "+car.Price);
                    UICreater.GoTo(9,12);Console.Write("3 . Colors: "+car.Colors);
                    UICreater.GoTo(10,12);Console.Write("4 . Uphostery "+car.Uphostery);
                    UICreater.GoTo(11,12);Console.Write("5 . Height: "+car.Height);
                    UICreater.GoTo(12,12);Console.Write("6 . Weight: "+car.Weight);
                    UICreater.GoTo(13,12);Console.Write("7 . Length: "+car.Length);
                    UICreater.GoTo(14,12);Console.Write("8 . Width: "+car.Width);
                    UICreater.GoTo(15,12);Console.Write("0 . Delete ");
                    ConsoleKey choose=Console.ReadKey().Key;
                    switch (choose)
                    {
                        case ConsoleKey.D1:
                            Console.CursorVisible = true;
                            UICreater.GoTo(7,12);Console.Write("1 . Engine:                                      ");
                            UICreater.GoTo(7,24);car.Engine=Console.ReadLine();
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.D2:
                            Console.CursorVisible = true;
                            UICreater.GoTo(8,12);Console.Write("2 . Price:                     ");
                            UICreater.GoTo(8,23);car.Price=long.Parse(Console.ReadLine());
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.D3:
                            Console.CursorVisible = true;
                            UICreater.GoTo(9,12);Console.Write("3 . Colors:                                                       ");
                            UICreater.GoTo(9,24);car.Colors=Console.ReadLine();
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.D4:
                            Console.CursorVisible = true;
                            UICreater.GoTo(10,12);Console.Write("4 . Uphostery:                                                    ");
                            UICreater.GoTo(10,27);car.Uphostery=Console.ReadLine();
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.D5:
                            Console.CursorVisible = true;
                            UICreater.GoTo(11,12);Console.Write("5 . Height:                     ");
                            UICreater.GoTo(11,24);car.Height=double.Parse(Console.ReadLine());
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.D6:
                            Console.CursorVisible = true;
                            UICreater.GoTo(12,12);Console.Write("6 . Weight:                     ");
                            UICreater.GoTo(12,24);car.Weight=double.Parse(Console.ReadLine());
                            Console.CursorVisible = false;
                            break;
                        case ConsoleKey.D7:
                            Console.CursorVisible = true;
                            UICreater.GoTo(13,12);Console.Write("7 . Length:                     ");
                            UICreater.GoTo(13,24);car.Length=double.Parse(Console.ReadLine());
                            Console.CursorVisible = false;
                            break;    
                        case ConsoleKey.D8:
                            Console.CursorVisible = true;
                            UICreater.GoTo(14,12);Console.Write("8 . Width:                     ");
                            UICreater.GoTo(14,23);car.Width=double.Parse(Console.ReadLine());
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
            Console.Clear();
            Console.WriteLine("This car had been existed in Database");
            Console.ReadKey();
        }
    }
}