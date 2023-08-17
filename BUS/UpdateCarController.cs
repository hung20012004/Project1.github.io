using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.DAL;
using Project1.GUI;
using MySql.Data.MySqlClient;

namespace Project1.BUS
{
    public class UpdateCarController
    {
        public void updateView(){
            
            while(true){
                int choose = HomeView.AdminMenu();
                if(choose==-1) break;
                else
                switch (choose)
                {
                    case 1:
                        Car car1=UpdateCarView.UpdateCar();
                        if(car1.Name!=null){
                            if(car1.Name=="Delete")
                                car1.Delete();
                            else
                            car1.Update();
                        }
                        break;
                    case 2:
                        Car car2=UpdateCarView.CreateCar();
                        if(car2.Name!=null)
                        try
                        {
                            car2.Create();
                            UpdateCarView.InsertCarSuccess();
                        }
                        catch (System.Exception)
                        {
                            
                            UpdateCarView.WarningExistedCar();
                        }
                            
                        break;
                }
                
            }
        }
        
    }
}