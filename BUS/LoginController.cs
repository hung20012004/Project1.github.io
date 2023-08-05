using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.DAL;
using Project1.GUI;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace Project1.BUS
{
    public class LoginController
    {

        public void updateView(){    
            Accountant acc=LoginView.LoginLayer();        
            if(acc!=null){
                acc=checkAccount(acc);
                if(acc.department=="admin")
                    AdminAccount();
                else if(acc.department=="manager")
                    SalesManagerAccount(acc.showroom_ID);
                else    
                    LoginView.loginFail();
            }
        }
        public void SalesManagerAccount(int showroom_ID){
            while(true){
                int choose=LoginView.SalesManagerMenuLayer();
                OrderController controller1=new OrderController();
                StatisticController controller2=new StatisticController();
                if(choose==0) break;
                else
                    switch (choose)
                    {
                        case 1: 
                            controller1.updateView(showroom_ID);
                            break;
                        case 2:
                            break;
                    }
            }
        }
        public void AdminAccount(){
            UpdateCarController controller=new UpdateCarController();
            controller.updateView();
        }
        public Accountant checkAccount(Accountant accountant){
            using (MySqlCommand cmd = DBHelper.UseStored("check_account"))
                {
                    cmd.Parameters.Add("rq_id", MySqlDbType.Int32).Value=accountant.ID;
                    cmd.Parameters.Add("rq_password", MySqlDbType.VarChar).Value=accountant.password;
                    cmd.ExecuteNonQuery();
                    using( MySqlDataReader reader =cmd.ExecuteReader()){
                        while (reader.Read())
                        {
                            accountant.department= $"{reader["department"]}";
                            accountant.showroom_ID= reader.GetInt32("showroom_id");
                        }
                    }
                }
            return accountant;
        }
        
    }
}