using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.DAL;
using Project1.BUS;

namespace Project1.GUI
{
    public class SearchCarView
    {
        public static long fistPrice;
        public static long lastPrice;
        public static Car Cars(){
            Model model = new();
            Saloon saloon=new();
            fistPrice=0;
            lastPrice=long.MaxValue;
            Car car=new();
            while(true){
                SearchCarController controller=new SearchCarController();
                List<Car> cars=controller.getData(model.ID,saloon.ID,fistPrice,lastPrice);
                int last= cars.Count / 9;
                if (cars.Count % 9 != 0) last++;
                int fist=1;
                while(true){
                    Console.Clear();
                    UICreater.CreateUI();
                    UICreater.Page(fist,last);
                    if(model.ID==0) model.name="All"; 
                    if(saloon.ID==0) saloon.name="All"; 
                    UICreater.GoTo(8,28);Console.WriteLine("F1. Model: "+String.Format("{0,-12}",model.name)+"F2. Saloon: "+saloon.name);
                    UICreater.GoTo(9,28);Console.Write("F3. Price: "+String.Format("{0:0,0 vnđ}",fistPrice)+" to ");
                    if(lastPrice==long.MaxValue)
                        Console.Write("00 vnđ");
                    else
                        Console.WriteLine(String.Format("{0:0,0 vnđ}",lastPrice));
                    int ord=1;
                    if(cars.Count()==0){
                        UICreater.GoTo(11,43);
                        Console.Write("No result!");
                        if(Console.ReadKey().Key==ConsoleKey.Escape) 
                            return new();
                    }
                    else{
                        for(int i=fist*9-9;i<fist*9;i++){
                            UICreater.GoTo(11+ord,12);
                            if(i==cars.Count()) break;
                            Console.WriteLine(ord+" . "+String.Format("{0,-39}",cars[i].Name)+String.Format("{0:0,0 vnđ}",cars[i].Price));
                            ord++;
                        }
                        ConsoleKey choose= Console.ReadKey().Key;

                        if(choose==ConsoleKey.F1||choose==ConsoleKey.F2||choose==ConsoleKey.F3){
                            switch (choose)
                            {
                                case ConsoleKey.F1:
                                    model=ChooseModel();
                                    saloon=new();
                                    break;
                                case ConsoleKey.F2:
                                    saloon=ChooseSaloon(model);
                                    break;
                                case ConsoleKey.F3:
                                    ChoosePriceRange();
                                    break; 
                            }
                            break;
                        }
                        else switch (choose)
                            {
                                case ConsoleKey.RightArrow:
                                    if(fist!=last)
                                        fist++;
                                    break;
                                case ConsoleKey.LeftArrow :
                                    if(fist>1)
                                        fist--;
                                    break;
                                case ConsoleKey.Escape : 
                                    return new(); 
                                case ConsoleKey.D1 : 
                                    car=cars[(fist-1)*9]; 
                                    return car; 
                                case ConsoleKey.D2 : 
                                    if((fist-1)*9+1<cars.Count()){
                                        car=cars[(fist-1)*9+1];
                                        return car; 
                                    }
                                    break;
                                case ConsoleKey.D3 : 
                                    if((fist-1)*9+2<cars.Count()){
                                        car=cars[(fist-1)*9+2];
                                        return car; 
                                    }
                                    break; 
                                case ConsoleKey.D4 : 
                                    if((fist-1)*9+3<cars.Count()){
                                        car=cars[(fist-1)*9+3];
                                        return car; 
                                    }
                                    break; 
                                case ConsoleKey.D5 : 
                                    if((fist-1)*9+4<cars.Count()){
                                        car=cars[(fist-1)*9+4];
                                        return car; 
                                    }
                                    break;
                                case ConsoleKey.D6 : 
                                    if((fist-1)*9+5<cars.Count()){
                                        car=cars[(fist-1)*9+5];
                                        return car; 
                                    }
                                    break;
                                case ConsoleKey.D7 : 
                                    if((fist-1)*9+6<cars.Count()){
                                        car=cars[(fist-1)*9+6];
                                        return car; 
                                    }
                                    break;
                                case ConsoleKey.D8 : 
                                    if((fist-1)*9+7<cars.Count()){
                                        car=cars[(fist-1)*9+7];
                                        return car; 
                                    }
                                    break;
                                case ConsoleKey.D9 : 
                                    if((fist-1)*9+8<cars.Count()){
                                        car=cars[(fist-1)*9+8];
                                        return car; 
                                    }
                                    break;  

                        }
                    }
                }
            }
        }
        public static void ChoosePriceRange(){
            Console.CursorVisible = true;
            UICreater.GoTo(9,39);
            Console.Write(string.Format("{0,44}"," "));
            UICreater.GoTo(9,39);
            try
            {
                fistPrice=long.Parse( Console.ReadLine());
                UICreater.GoTo(9,50);
                Console.Write(" vnđ to ");
                lastPrice=long.Parse( Console.ReadLine());
            }
            catch (System.Exception)
            {
                fistPrice=0;
                lastPrice=long.MaxValue;
            }     
            Console.CursorVisible = false;
        }
        public static Model ChooseModel(){
            
            SearchCarController controller=new();
            List<Model> models=controller.getModelData();
            Model model=new();
            UICreater.CreateUI();
            UICreater.CreateMenu(7,"                       MODEL                      ");
            UICreater.GoTo(13,25);Console.WriteLine("0 . All");
            for(int i=0;i<models.Count();i++){
                Console.CursorLeft=25;Console.WriteLine((i+1)+" . "+models[i].name);
            }
            ConsoleKey choose=Console.ReadKey().Key;
            switch (choose)
            {
                case ConsoleKey.Escape : 
                    model.ID=0;
                    break;
                case ConsoleKey.D0 : 
                    model.ID=0;
                    break;
                case ConsoleKey.D1 : 
                    model=models[0];
                    break;
                case ConsoleKey.D2 : 
                    model=models[1];
                    break;
                case ConsoleKey.D3 : 
                    model=models[2]; 
                    break;
                case ConsoleKey.D4 : 
                    model=models[3];   
                    break;
            }
            return model;
        }
        public static Saloon ChooseSaloon(Model model){
            SearchCarController controller=new();
            List<Saloon> saloons=controller.getSaloonData(model.ID);
            int last= saloons.Count / 9;
            if (saloons.Count % 9 != 0) last++;
            int fist=1;
            while(true){
                UICreater.CreateUI();
                UICreater.CreateMenu(10,"                      SALOON                      ");
                UICreater.Page(fist,last);
                int ord=1;
                UICreater.GoTo(12,25);Console.WriteLine("0 . All");
                for(int i=fist*9-9;i<fist*9;i++){
                    UICreater.GoTo(12+ord,25);
                    if(i==saloons.Count) break;
                    Console.WriteLine(ord+" . "+saloons[i].name);
                    ord++;
                }
                ConsoleKey choose=Console.ReadKey().Key;
                switch (choose)
                {
                    case ConsoleKey.RightArrow:
                        if(fist!=last)
                            fist++;
                        break;
                    case ConsoleKey.LeftArrow :
                        if(fist>1)
                            fist--;
                        break;
                    case ConsoleKey.D0 or ConsoleKey.Escape:
                        Saloon saloon=new();
                        return saloon;
                    case ConsoleKey.D1 : 
                        return saloons[0];
                    case ConsoleKey.D2 : 
                        if(saloons.Count()>1)
                            return saloons[1];
                        break;
                    case ConsoleKey.D3 : 
                        if(saloons.Count()>2)
                            return saloons[2];  
                        break;
                    case ConsoleKey.D4 :
                        if(saloons.Count()>3) 
                            return saloons[3];    
                        break;
                    case ConsoleKey.D5 : 
                        if(saloons.Count()>4)
                            return saloons[4];
                        break;
                    case ConsoleKey.D6 : 
                        if(saloons.Count()>5)
                            return saloons[5];
                        break;
                    case ConsoleKey.D7 : 
                        if(saloons.Count()>6)
                            return saloons[6];  
                        break;
                    case ConsoleKey.D8 :
                        if(saloons.Count()>7) 
                            return saloons[7];    
                        break;
                    case ConsoleKey.D9 : 
                        if(saloons.Count()>8)
                            return saloons[8];    
                        break;
                }
            }
        }
        public static int CarDetail(Car car){
            Console.Clear();
            UICreater.CreateUI();
            UICreater.GoTo(8,7); Console.WriteLine("                                    DETAIL                                     ");
            Console.CursorLeft=7;Console.WriteLine("───────────────────────────────────────────────────────────────────────────────");
            Console.CursorLeft=9;Console.WriteLine("Car               │ "+car.Name );Console.CursorLeft = 9;
            if(car.quantity!=0)
                Console.WriteLine("State             │ Available");
            else Console.WriteLine("State             │ Not available");
            Console.CursorLeft = 9;
            Console.WriteLine("Price              │ "+String.Format("{0:0,0 vnđ}",car.Price));Console.CursorLeft = 9;
            Console.WriteLine("Engine             │ "+car.Engine);Console.CursorLeft = 9;
            if(car.Displacement!=0)
                Console.WriteLine("Displacement       │ "+car.Displacement);Console.CursorLeft = 9;
            if(car.Cylinder!=0)
            Console.WriteLine("Number of cylinder │ "+car.Cylinder);Console.CursorLeft = 9;
            Console.WriteLine("Max speed          │ "+car.max_speed);Console.CursorLeft = 9;
            Console.WriteLine("Colors             │ "+car.Colors);Console.CursorLeft = 9;
            Console.WriteLine("Uphostery          │ "+car.Uphostery);Console.CursorLeft = 9;
            Console.WriteLine("Number of door     │ "+car.door_num);Console.CursorLeft = 9;
            Console.WriteLine("Number of seat     │ "+car.seat_num);Console.CursorLeft = 9;
            Console.WriteLine("Height             │ "+car.Height);Console.CursorLeft = 9;
            Console.WriteLine("Weight             │ "+car.Weight);Console.CursorLeft = 9;
            Console.WriteLine("Length             │ "+car.Length);Console.CursorLeft = 9;
            Console.WriteLine("Width              │ "+car.Width);Console.CursorLeft = 9;
            ConsoleKey choose= Console.ReadKey().Key;
            switch (choose)
                {
                case ConsoleKey.Enter:
                    return 1;
                }
            return 0;
        }
        
    }
}