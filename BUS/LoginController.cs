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
        public static Accountant accountant=new();
        public static void updateView(){   
            while(true){ 
                accountant=new();
                int choose=LoginView.Menu();
                if(choose==1){  
                    accountant=LoginView.Login();      
                    if(checkAccount()){ 
                        HomeController controller=new();
                        controller.updateView();
                    }
                    else LoginView.loginFail();
                }
                else if(choose==2){
                    accountant=LoginView.Register(); 
                    if(accountant.Username!=null)
                        accountant.Create();
                }
                else break;
            }
        }
        public static bool checkAccount(){
            using (MySqlCommand cmd = DBHelper.UseStored("check_account"))
                {
                    cmd.Parameters.Add("rq_username", MySqlDbType.VarChar).Value=accountant.Username;
                    cmd.Parameters.Add("rq_password", MySqlDbType.VarChar).Value=accountant.password;
                    cmd.ExecuteNonQuery();
                    using( MySqlDataReader reader =cmd.ExecuteReader()){
                        while (reader.Read())
                        {
                            accountant.ID= reader.GetInt32("id");
                            accountant.department= $"{reader["department"]}";
                            accountant.showroom_ID= reader.GetInt32("showroom_id");
                            accountant.name= $"{reader["name"]}";
                            accountant.phone= $"{reader["phone"]}";
                        }
                    }
                }
            if(accountant.ID!=0)
                return true;
            return false;
        }
        
    }
}