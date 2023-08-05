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
        
        public static Order createOrderLayer(int showroom_ID){
            Order order=new();
            Request request=new();
            Salesman salesman=new();
            while(true){
                Console.Clear();
                Console.WriteLine("1. RequestID : "+order.requestID);
                Console.WriteLine("2. Salesman : "+ salesman.Name);
                Console.WriteLine("3. Total bill : "+order.totalBill);
                ConsoleKey choose=Console.ReadKey().Key;
                if(choose==ConsoleKey.Enter){
                    if(order.requestID!=0 && order.salesmanID!=0 && order.totalBill!=0){
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
                        request= ChooseRequestLayer(showroom_ID);
                        if(request.ID!=0)
                            order.requestID=request.ID;
                        break;
                    case ConsoleKey.D2: 
                        salesman=ChooseSalesmanLayer(showroom_ID);
                        if(salesman.ID!=0)
                            order.salesmanID=salesman.ID;
                        break;
                    case ConsoleKey.D3:
                        order.totalBill=Bill();
                        break;
                    case ConsoleKey.Escape:
                        return order=new();
                }
            }
        }  
        public static Request ChooseRequestLayer(int showroom_ID){
            Request request=new();
            OrderController controller=new OrderController();
            List<Request> requests=controller.GetRequest(showroom_ID);
            ConsoleKey choose=ConsoleKey.Backspace;
            if(requests.Count==0){
                Console.Clear();
                Console.WriteLine("You don't have any request!");
                Console.ReadKey();
                return request;
            }
            else
            {
            int end=requests.Count()/9;
            if (requests.Count()%9!=0) end++;
            int page=1;
            while(true){
                Console.Clear();
                if(choose==ConsoleKey.RightArrow && page!=end){
                    page++;
                }
                if(choose==ConsoleKey.LeftArrow && page>1){
                    page--;
                }
                Console.WriteLine("Page: "+page+" / "+end);
                int ord=1;
                for(int i=page*9-9;i<page*9;i++){
                    if(i==requests.Count()) 
                        break;
                    Console.WriteLine(ord+" . "+requests[i].ID+" "+requests[i].customerName+" "+requests[i].phone+" "+requests[i].address);
                    ord++;
                }
                choose= Console.ReadKey().Key;

                switch (choose)
                {
                    case ConsoleKey.Escape : 
                        return request; 
                    case ConsoleKey.D1 : 
                        return requests[(page-1)*9]; 
                    case ConsoleKey.D2 : 
                        if((page-1)*9+1<requests.Count()){
                            return requests[(page-1)*9+1]; 
                        }
                        break;
                    case ConsoleKey.D3 : 
                        if((page-1)*9+2<requests.Count())
                            return requests[(page-1)*9+2]; 
                        break; 
                    case ConsoleKey.D4 : 
                        if((page-1)*9+3<requests.Count())
                            return requests[(page-1)*9+3]; 
                        break; 
                    case ConsoleKey.D5 : 
                        if((page-1)*9+4<requests.Count())
                            return requests[(page-1)*9+4]; 
                        break;
                    case ConsoleKey.D6 : 
                        if((page-1)*9+5<requests.Count())
                            return requests[(page-1)*9+5]; 
                        break;
                    case ConsoleKey.D7 : 
                        if((page-1)*9+6<requests.Count())
                            return requests[(page-1)*9+6]; 
                        break;
                    case ConsoleKey.D8 : 
                        if((page-1)*9+7<requests.Count())
                            return requests[(page-1)*9+7]; 
                        break;
                    case ConsoleKey.D9 : 
                        if((page-1)*9+8<requests.Count())
                            return requests[(page-1)*9+8]; 
                        break;  
                }
            }
            }
        }
        public static Salesman ChooseSalesmanLayer(int showroom_ID){
            Salesman salesman=new();
            OrderController controller=new();
            List<Salesman> salesmans =controller.GetSalesman(showroom_ID);
            ConsoleKey choose=ConsoleKey.A;
            int end=salesmans.Count()/9;
            if (salesmans.Count()%9!=0) end++;
            int page=1;
            while(true){
                Console.Clear();
                if(choose==ConsoleKey.RightArrow && page!=end){
                    page++;
                }
                if(choose==ConsoleKey.LeftArrow && page>1){
                    page--;
                }
                Console.WriteLine("Page: "+page+" / "+end);
                int ord=1;
                for(int i=page*9-9;i<page*9;i++){
                    if(i==salesmans.Count()) 
                        break;
                    Console.WriteLine(ord+" . "+salesmans[i].Name);
                    ord++;
                }
                choose= Console.ReadKey().Key;

                switch (choose)
                {
                    case ConsoleKey.Escape : 
                        return salesman; 
                    case ConsoleKey.D1 : 
                        return salesmans[(page-1)*9];
                    case ConsoleKey.D2 : 
                        if((page-1)*9+1<salesmans.Count)
                            return salesmans[(page-1)*9+1];  
                        break;
                    case ConsoleKey.D3 : 
                        if((page-1)*9+2<salesmans.Count)
                            return salesmans[(page-1)*9+2]; 
                        break; 
                    case ConsoleKey.D4 : 
                        if((page-1)*9+3<salesmans.Count)
                            return salesmans[(page-1)*9+3];
                        break; 
                    case ConsoleKey.D5 : 
                        if((page-1)*9+4<salesmans.Count)
                            return salesmans[(page-1)*9+4];
                        break;
                    case ConsoleKey.D6 : 
                        if((page-1)*9+5<salesmans.Count)
                            return salesmans[(page-1)*9+5];
                        break;
                    case ConsoleKey.D7 : 
                        if((page-1)*9+6<salesmans.Count)
                            return salesmans[(page-1)*9+6];
                        break;
                    case ConsoleKey.D8 : 
                        if((page-1)*9+7<salesmans.Count)
                            return salesmans[(page-1)*9+7];   
                        break;
                    case ConsoleKey.D9 : 
                        if((page-1)*9+8<salesmans.Count)
                            return salesmans[(page-1)*9+8];
                        break;  
                }
            }
        }  
        public static long Bill(){
            Console.Clear();
            Console.CursorVisible = true;
            Console.Write("Enter total bill : ");
            long totalBill=long.Parse( Console.ReadLine());
            Console.CursorVisible = false;
            return totalBill;
        }
    }

}