using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.GUI;
using Project1.DAL;

namespace Project1.BUS
{
    public class HomeController
    {
        public void updateView(){
            while(true){
                int choose=HomeView.MenuLayer();
                if (choose==0) break; 
                switch (choose)
                {
                    case 0:
                        break;
                    case 1: 
                        SearchCarController controller1=new SearchCarController();
                        controller1.updateView();   
                        break;
                    case 2: 
                        RequestController controller2=new RequestController();
                        Car car=new();
                        controller2.updateView(car);
                        break;
                    case 3:  
                        LoginController controller3=new LoginController();
                        controller3.updateView();
                        break;
                }  
            }
        }
    }
}