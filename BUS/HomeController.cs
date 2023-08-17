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
            switch (LoginController.accountant.department)
            {
                case "Admin":
                    updateAdminView();
                    break;
                case "Manager":
                    updateManagerView();
                    break;
                case "Sales":
                    updateSalesView();
                    break;
                case "Customer":
                    updateCustomerView();
                    break;
            }
        }
        public void updateAdminView(){
            UpdateCarController controller=new();
            controller.updateView();
        }
        public void updateManagerView(){
            while(true){
                int choose=HomeView.ManagerMenu();
                if(choose==-1) 
                    break;
                else switch (choose)
                {
                    case 1:
                        OrderController controller1=new();
                        controller1.updateManagerView();
                        break;
                    case 2:
                        StatisticController controller2=new();
                        controller2.updateView();
                        break;
                }
            }
        }
        public void updateSalesView(){
            while(true){
                int choose=HomeView.SalesMenu();
                if(choose==-1) 
                    break;
                else switch (choose)
                {
                    case 1:
                        OrderController controller1=new();
                        controller1.updateSalesView1();
                        break;
                    case 2:
                        OrderController controller2=new();
                        controller2.updateSalesView2();
                        break;
                    case 3:
                        OrderController controller3=new();
                        controller3.updateSalesView3();
                        break;
                }
            }
        }
        public void updateCustomerView(){
            while(true){
                int choose=HomeView.CustomerMenu();
                if(choose==-1) 
                    break;
                else switch (choose)
                {
                    case 1:
                        SearchCarController controller1=new();
                        controller1.updateView();
                        break;
                    case 2:
                        OrderController controller2=new();
                        Car car=new();
                        controller2.updateCustomerView1(car);
                        break;
                    case 3:
                        OrderController controller3=new();
                        controller3.updateCustomerView2();
                        break;
                    case 4: 
                        LoginView.ChangePassword();
                        break;
                }
            }
        }
    }
}