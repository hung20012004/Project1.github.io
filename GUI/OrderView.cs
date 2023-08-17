using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.DAL;
using Project1.BUS;

namespace Project1.GUI
{
    public class OrderView
    {
        
        public static Order createOrder(){
            Order order=new();
            while(true){
                UICreater.CreateUI();
                UICreater.CreateMenu(4,"                  CREATE ORDER                    ");
                UICreater.GoTo(13,38);Console.WriteLine("1 . Waiting order : "+order.ID);
                Console.CursorLeft=38;Console.WriteLine("2 . Total bill : "+order.totalBill);
                ConsoleKey choose=Console.ReadKey().Key;
                if(choose==ConsoleKey.Enter){
                    if(order.ID!=0 && order.totalBill!=0){
                        return order;
                    }
                    else{
                        Console.WriteLine("Please fill all information of the form!");
                        Console.ReadKey();
                    }
                }
                else switch (choose)
                {
                    case ConsoleKey.D1:
                        order=waitingOrder(); 
                        break;
                    case ConsoleKey.D2:
                        order.totalBill=Bill();
                        break;
                    case ConsoleKey.Escape:
                        return order=new();
                }
            }
        }  
            
        public static long Bill(){
            UICreater.GoTo(14,55);Console.Write("                    ");
            UICreater.GoTo(14,55);
            Console.CursorVisible = true;
            long totalBill=long.Parse( Console.ReadLine());
            Console.CursorVisible = false;
            return totalBill;
        }

        public static Order waitingOrder(){
            Order order=new();
            OrderController controller=new();
            List<Order> orders=controller.GetWaitingOrder();
            ConsoleKey choose=ConsoleKey.Backspace;
            if(orders.Count==0){
                UICreater.CreateUI();
                UICreater.GoTo(10,30);
                Console.WriteLine("Don't have any waiting order!");
                Console.ReadKey();
                return order=new();
            }
            else{
            int end=orders.Count/9;
            if (orders.Count%9!=0) end++;
            int page=1;
            while(true){
                UICreater.CreateUI();
                UICreater.Page(page,end);
                UICreater.GoTo(8,7); Console.WriteLine("               CAR                  │    CUSTOMER NAME     │       SALES NAME     │    PROCESSED TIME    ");
                Console.CursorLeft=7;Console.WriteLine("────────────────────────────────────┼──────────────────────┼──────────────────────┼──────────────────────");
                if(choose==ConsoleKey.RightArrow && page!=end){
                    page++;
                }
                if(choose==ConsoleKey.LeftArrow && page>1){
                    page--;
                }
                int ord=1;
                for(int i=page*9-9;i<page*9;i++){
                    if(i==orders.Count()) 
                        break;
                    Console.CursorLeft=9;Console.WriteLine(string.Format("{0,-34}",ord+" . "+orders[i].carName) +"│ "+string.Format("{0,-21}",orders[i].customerName)+"│ "+string.Format("{0,-21}",orders[i].salesName)+"│ "+orders[i].processedRequestTime);
                    Console.CursorLeft=7;Console.WriteLine("                                    │                      │                      │     ");
                    ord++;
                }
                choose= Console.ReadKey().Key;

                switch (choose)
                {
                    case ConsoleKey.Escape : 
                        return order=new(); 
                    case ConsoleKey.D1 : 
                        return orders[(page-1)*9]; 
                    case ConsoleKey.D2 : 
                        if((page-1)*9+1<orders.Count){
                            return orders[(page-1)*9+1]; 
                        }
                        break;
                    case ConsoleKey.D3 : 
                        if((page-1)*9+2<orders.Count)
                            return orders[(page-1)*9+2]; 
                        break; 
                    case ConsoleKey.D4 : 
                        if((page-1)*9+3<orders.Count)
                            return orders[(page-1)*9+3]; 
                        break; 
                    case ConsoleKey.D5 : 
                        if((page-1)*9+4<orders.Count())
                            return orders[(page-1)*9+4]; 
                        break;
                    case ConsoleKey.D6 : 
                        if((page-1)*9+5<orders.Count())
                            return orders[(page-1)*9+5]; 
                        break;
                    case ConsoleKey.D7 : 
                        if((page-1)*9+6<orders.Count())
                            return orders[(page-1)*9+6]; 
                        break;
                    case ConsoleKey.D8 : 
                        if((page-1)*9+7<orders.Count())
                            return orders[(page-1)*9+7]; 
                        break;
                    case ConsoleKey.D9 : 
                        if((page-1)*9+8<orders.Count())
                            return orders[(page-1)*9+8]; 
                        break;  
                }
            }
            }
        }
        public static Order requestForm( Car car){
            Order order=new();
            order.carID=car.ID;
            Showroom showroom=new();
            while(true){
                UICreater.CreateUI();
                UICreater.CreateMenu(7,"                  REQUEST FORM                    ");
                UICreater.GoTo(13,38);Console.WriteLine(" 1 . Showroom: "+showroom.Name);
                Console.CursorLeft=38;Console.WriteLine(" 2 . Car: "+car.Name);
                Console.CursorLeft=38;Console.WriteLine(" 3 . Note: "+order.note);
                ConsoleKey choose=Console.ReadKey().Key;
                switch (choose){
                    case ConsoleKey.Enter:
                        if(order.carID!=0 && order.showroomID!=0 )
                            return order;    
                        else{
                            UICreater.GoTo(17,38);Console.WriteLine("Please fill all information of the form!");
                            Console.ReadKey();
                        }
                        break;
                    case ConsoleKey.D1: 
                        showroom=chooseShowroom();
                        order.showroomID=showroom.ID;
                        break;
                    case ConsoleKey.D2: 
                        car=SearchCarView.Cars();
                        order.carID=car.ID;
                        break;
                    case ConsoleKey.D3:
                        UICreater.GoTo(15,49);
                        Console.CursorVisible = true;
                        order.note=Console.ReadLine();
                        Console.CursorVisible = false;
                        break;
                    case ConsoleKey.Escape:
                        return order=new();
                }
            }
        }
        public static Showroom chooseShowroom(){
            OrderController controller=new();
            List<Showroom> showrooms=controller.getShowroomData();
            while(true){
                UICreater.CreateUI();
                UICreater.CreateUI();
                UICreater.CreateMenu(11,"                     SHOWROOM                     ");
                UICreater.GoTo(13,38);
                for(int i=0;i<showrooms.Count();i++){
                    Console.CursorLeft=38;Console.WriteLine((i+1)+" : "+showrooms[i].Name);
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
        public static Order waitingRequest(){
            UICreater.CreateUI();
            Order order=new();
            OrderController controller=new();
            List<Order> orders=controller.GetWaitingRequest();
            ConsoleKey choose=ConsoleKey.Backspace;
            if(orders.Count==0){
                UICreater.CreateUI();
                UICreater.GoTo(10,30);Console.WriteLine("Doesn't have any waiting request!");
                Console.ReadKey();
                return order;
            }
            else
            {
            int end=orders.Count/9;
            if (orders.Count%9!=0) end++;
            int page=1;
            while(true){
                UICreater.CreateUI();
                UICreater.Page(page,end);
                UICreater.GoTo(8,7); Console.WriteLine("                  CAR                  │     CUSTOMER NAME      │    PHONE   │        REQUEST TIME    ");
                Console.CursorLeft=7;Console.WriteLine("───────────────────────────────────────┼────────────────────────┼────────────┼───────────────────────────");
                if(choose==ConsoleKey.RightArrow && page!=end){ 
                    page++;
                }
                if(choose==ConsoleKey.LeftArrow && page>1){
                    page--;
                }
                int ord=1;
                for(int i=page*9-9;i<page*9;i++){
                    if(i==orders.Count()) 
                        break;
                    Console.CursorLeft=9;Console.WriteLine(string.Format("{0,-37}",ord+" . "+orders[i].carName)+"│ "+string.Format("{0,-23}",orders[i].customerName)+"│ "+orders[i].phone+" │ "+orders[i].requestTime);
                    Console.CursorLeft=7;Console.WriteLine("                                       │                        │            │    ");
                    ord++;
                }
                choose= Console.ReadKey().Key;

                switch (choose)
                {
                    case ConsoleKey.Escape : 
                        return order=new(); 
                    case ConsoleKey.D1 : 
                        return orders[(page-1)*9]; 
                    case ConsoleKey.D2 : 
                        if((page-1)*9+1<orders.Count){
                            return orders[(page-1)*9+1]; 
                        }
                        break;
                    case ConsoleKey.D3 : 
                        if((page-1)*9+2<orders.Count)
                            return orders[(page-1)*9+2]; 
                        break; 
                    case ConsoleKey.D4 : 
                        if((page-1)*9+3<orders.Count)
                            return orders[(page-1)*9+3]; 
                        break; 
                    case ConsoleKey.D5 : 
                        if((page-1)*9+4<orders.Count)
                            return orders[(page-1)*9+4]; 
                        break;
                    case ConsoleKey.D6 : 
                        if((page-1)*9+5<orders.Count)
                            return orders[(page-1)*9+5]; 
                        break;
                    case ConsoleKey.D7 : 
                        if((page-1)*9+6<orders.Count)
                            return orders[(page-1)*9+6]; 
                        break;
                    case ConsoleKey.D8 : 
                        if((page-1)*9+7<orders.Count)
                            return orders[(page-1)*9+7]; 
                        break;
                    case ConsoleKey.D9 : 
                        if((page-1)*9+8<orders.Count)
                            return orders[(page-1)*9+8]; 
                        break;  
                }
            }
            }
        }
        public static Order processingRequest(){
            UICreater.CreateUI();
            UICreater.GoTo(10,12);
            Order order=new();
            OrderController controller=new();
            List<Order> orders=controller.GetProcessingRequest();
            ConsoleKey choose=ConsoleKey.Backspace;
            if(orders.Count==0){
                UICreater.CreateUI();
                UICreater.GoTo(10,43);Console.WriteLine("Doesn't have any proccessing request!");
                Console.ReadKey();
                return order;
            }
            else{
                
                while(true){
                    UICreater.CreateUI();
                    UICreater.GoTo(8,7); Console.WriteLine("                  CAR                  │     CUSTOMER NAME      │    PHONE   │        REQUEST TIME    ");
                    Console.CursorLeft=7;Console.WriteLine("───────────────────────────────────────┼────────────────────────┼────────────┼───────────────────────────");
                    for(int i=0;i<orders.Count;i++){
                        Console.CursorLeft=9;Console.WriteLine(string.Format("{0,-37}",i+1+" . "+orders[i].carName)+"│ "+string.Format("{0,-23}",orders[i].customerName)+"│ "+orders[i].phone+" │ "+orders[i].requestTime);
                        Console.CursorLeft=7;Console.WriteLine("                                       │                        │            │        ");
                    }
                    choose= Console.ReadKey().Key;

                    switch (choose)
                    {
                        case ConsoleKey.Escape : 
                            return order=new(); 
                        case ConsoleKey.D1 : 
                            return orders[0]; 
                        case ConsoleKey.D2 : 
                            if(orders.Count>1){
                                return orders[1]; 
                            }
                            break;
                        case ConsoleKey.D3 : 
                            if(orders.Count>2)
                                return orders[2]; 
                            break; 
                        case ConsoleKey.D4 : 
                            if(orders.Count>3)
                                return orders[3]; 
                            break; 
                        case ConsoleKey.D5 : 
                            if(orders.Count>4)
                                return orders[4]; 
                            break;
                    }
                }
            }
        }
        public static void processedRequest(){
            UICreater.CreateUI();
            UICreater.GoTo(10,12);
            OrderController controller=new();
            List<Order> orders=controller.GetProcessedRequest();
            ConsoleKey choose=ConsoleKey.Backspace;
            if(orders.Count==0){
                UICreater.CreateUI();
                UICreater.GoTo(10,43);Console.WriteLine("Don't have any processed request!");
                Console.ReadKey();
            }
            else{
                
                int end=orders.Count/9;
                if (orders.Count%9!=0) end++;
                int page=1;
                while(true){
                    UICreater.CreateUI();
                    UICreater.Page(page,end);
                    UICreater.GoTo(8,7); Console.WriteLine("                  CAR                  │         CUSTOMER NAME         │              STATE    ");
                    Console.CursorLeft=7;Console.WriteLine("───────────────────────────────────────┼───────────────────────────────┼─────────────────────────────────");
                    if(choose==ConsoleKey.RightArrow && page!=end){
                        page++;
                    }
                    if(choose==ConsoleKey.LeftArrow && page>1){
                        page--;
                    }
                    
                    int ord=1;
                    for(int i=page*9-9;i<page*9;i++){
                        if(i==orders.Count()) 
                            break;
                        Console.CursorLeft=9;Console.WriteLine(string.Format("{0,-37}",orders[i].carName)+"│ "+string.Format("{0,-30}",orders[i].customerName)+"│ "+orders[i].State);
                        Console.CursorLeft=7;Console.WriteLine("                                       │                               │ ");
                        ord++;
                    }
                    choose= Console.ReadKey().Key;
                    if(choose==ConsoleKey.Escape)
                        break;
                }
            }
        }
        public static int processResult(){
            while(true){
                Console.Clear();
                UICreater.CreateUI();
                UICreater.CreateMenu(5,"                     RESULT                       ");
                UICreater.GoTo(13,38);Console.WriteLine(" 1 . Complete");
                Console.CursorLeft=38;Console.WriteLine(" 2 . Give up");
                Console.CursorLeft=38;Console.WriteLine(" 3 . Delete");
                ConsoleKey choose=Console.ReadKey().Key;
                switch(choose){
                    case ConsoleKey.D1:
                        return 1;
                    case ConsoleKey.D2:
                        return 2;
                    case ConsoleKey.D3:
                        return 0;
                    case ConsoleKey.Escape:
                        return -1;
                }
            }

        }
        public static void tooMuchRequest(){
            UICreater.CreateUI();
            UICreater.CreateMenu(4,"                    WARNING                      ");
            UICreater.GoTo(13,38);Console.WriteLine(" You have too much processing request!");
            Console.CursorLeft=38;Console.WriteLine(" Please complete your requests!");
            Console.ReadKey();
        }
        
        public static Order customerRequest(){
            Order order=new();
            OrderController controller=new();
            List<Order> orders=controller.GetMyOrder();
            ConsoleKey choose=ConsoleKey.Backspace;
            Console.Clear();
            if(orders.Count==0){
                UICreater.CreateUI();
                UICreater.GoTo(10,43);
                Console.WriteLine("Doesn't have any request!");
                Console.ReadKey();
                return order;
            }
            else{
                
                while(true){
                    UICreater.CreateUI();
                    UICreater.GoTo(8,7); Console.WriteLine("                  CAR                  │       STATE      │         BILL      │       PAYMENT TIME    ");
                    Console.CursorLeft=7;Console.WriteLine("───────────────────────────────────────┼──────────────────┼───────────────────┼──────────────────────────");
                    for(int i=0;i<orders.Count;i++){
                        Console.CursorLeft=9;Console.WriteLine(string.Format("{0,-37}",i+1+" . "+orders[i].carName) +"│ "+string.Format("{0,-17}",orders[i].State)+"│  "+string.Format("{0,-17}",orders[i].totalBill+"vnđ")+"│  "+orders[i].createOrderTime);
                        Console.CursorLeft=7;Console.WriteLine("                                       │                  │                   │ ");
                    }
                    choose= Console.ReadKey().Key;

                    switch (choose)
                    {
                        case ConsoleKey.Escape : 
                            return order=new(); 
                        case ConsoleKey.D1 : 
                            return orders[0]; 
                        case ConsoleKey.D2 : 
                            if(orders.Count>1)
                                return orders[1]; 
                            break;
                        case ConsoleKey.D3 : 
                            if(orders.Count>2)
                                return orders[2]; 
                            break; 
                        case ConsoleKey.D4 : 
                            if(orders.Count>3)
                                return orders[3]; 
                            break; 
                        case ConsoleKey.D5 : 
                            if(orders.Count>4)
                                return orders[4]; 
                            break;
                        case ConsoleKey.D6 : 
                            if(orders.Count>5)
                                return orders[5]; 
                            break; 
                        case ConsoleKey.D7 : 
                            if(orders.Count>6)
                                return orders[6]; 
                            break; 
                        case ConsoleKey.D8 : 
                            if(orders.Count>7)
                                return orders[7]; 
                            break;
                        case ConsoleKey.D9 : 
                            if(orders.Count>8)
                                return orders[8]; 
                            break;
                    }
                }
            }
        }
        public static int OrderMenu1(){
            while(true){
                UICreater.CreateUI();
                UICreater.CreateMenu(3,"                    ORDER MENU                    ");
                UICreater.GoTo(13,38);Console.WriteLine("1 . Cancel order");
                while(true){
                    ConsoleKey choose=Console.ReadKey().Key;
                    if(choose==ConsoleKey.D1)
                        return 1;
                    else return 0;
                }
            }
        }
        public static int OrderMenu2(Order order){
            UICreater.CreateUI();
            UICreater.CreateMenu(4,"                    ORDER MENU                    ");
            UICreater.GoTo(13,38);Console.WriteLine("1 . Check invoice");
            UICreater.GoTo(14,38);Console.Write("2 . Comfirm already get car");
            while(true){
                ConsoleKey choose=Console.ReadKey().Key;
                if(choose==ConsoleKey.D1)
                    checkInvoice(order);
                else if(choose==ConsoleKey.D2)
                    return 1;
                else return 0;
            }
        }
        public static int OrderMenu3(Order order){
            UICreater.CreateUI();
            UICreater.CreateMenu(3,"                    ORDER MENU                    ");
            UICreater.GoTo(13,38);Console.WriteLine("1 . Check invoice");
            while(true){
                ConsoleKey choose=Console.ReadKey().Key;
                if(choose==ConsoleKey.D1)
                    checkInvoice(order);
                else return 0;
            }
            
        }
        public static void checkInvoice(Order order){
            UICreater.CreateUI();
            UICreater.GoTo(8,7); Console.WriteLine("                                               INVOICE                                  ");
            Console.CursorLeft=7;Console.WriteLine("─────────────────────────────────────────────────────────────────────────────────────────────────────────");
            Console.CursorLeft=9;Console.WriteLine("Order ID          : "+order.ID);
            Console.CursorLeft=9;Console.WriteLine("Create order time : "+order.createOrderTime);
            Console.CursorLeft=7;Console.WriteLine("─────────────────────────────────────────────────────────────────────────────────────────────────────────");
            Console.CursorLeft=9;Console.WriteLine("Customer name     : "+order.customerName);
            Console.CursorLeft=9;Console.WriteLine("Customer phone    : "+LoginController.accountant.phone);
            Console.CursorLeft=7;Console.WriteLine("─────────────────────────────────────────────────────────────────────────────────────────────────────────");
            Console.CursorLeft=9;Console.WriteLine("Showroom          : "+order.showroomName);
            Console.CursorLeft=9;Console.WriteLine("Address           : "+order.showroomAddress);
            Console.CursorLeft=9;Console.WriteLine("         ");
            Console.CursorLeft=9;Console.WriteLine("        ┌─────────────────────────────────────┬───────────────────┬──────────────────────────┐");
            Console.CursorLeft=9;Console.WriteLine("        │                 Car                 │   Total payment   │       Payment time       |");
            Console.CursorLeft=9;Console.WriteLine("        ├─────────────────────────────────────┼───────────────────┼──────────────────────────┤");
            Console.CursorLeft=9;Console.WriteLine("        │ "+string.Format("{0,-36}",order.carName)+"│ "+string.Format("{0,18}",order.totalBill+" vnđ")+"│ "+string.Format("{0,-25}",order.createOrderTime)+"│");
            Console.CursorLeft=9;Console.WriteLine("        └─────────────────────────────────────┴───────────────────┴──────────────────────────┘");
            Console.CursorLeft=9;Console.WriteLine("");
            Console.CursorLeft=9;Console.WriteLine("            Salesmanager                           Sales                          Customer            ");
            Console.CursorLeft=9;Console.WriteLine("");
            Console.CursorLeft=9;Console.WriteLine("                                                                                                   ");
            Console.CursorLeft=9;Console.WriteLine("       "+string.Format("{0,-24}",order.managerName)+"            "+string.Format("{0,-24}",order.salesName)+"            "+order.customerName);
            Console.ReadKey();

        } 
    }

}