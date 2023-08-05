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
                int choose = UpdateCarView.MenuLayer(); 
                if(choose==-1) break;
                else
                switch (choose)
                {
                    case 1:
                        Car car1=UpdateCarView.UpdateCarLayer();
                        if(car1.Name!=null){
                            if(car1.Name=="Delete")
                                car1.Delete();
                            else
                            car1.Update();
                        }
                        break;
                    case 2:
                        Car car2=UpdateCarView.CreateCarLayer();
                        if(car2.Name!=null)
                            car2.Create();
                        break;
                }
                
            }
        }
        
    }
}