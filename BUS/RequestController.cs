using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.DAL;
using Project1.GUI;
using MySql.Data.MySqlClient;

namespace Project1.BUS
{
    public class RequestController
    {
        public void updateView(Car car){
            Request request=RequestView.requestFormLayer(car);
            if(request.customerName!=null){
                request.Create();
            }
        }
        public List<Showroom> getShowroomData(){
            List<Showroom> showrooms=new List<Showroom>();
            using (MySqlCommand cmd = DBHelper.UseStored("get_showroom"))
                    {
                        cmd.ExecuteNonQuery();
                        
                        using( MySqlDataReader reader =cmd.ExecuteReader()){
                            while (reader.Read())
                            {
                                Showroom temp=new Showroom();
                                temp.ID= reader.GetInt32("id");
                                temp.Name= $"{reader["name"]}";
                                temp.Address= $"{reader["address"]}";
                                temp.Hotline= $"{reader["hotline"]}";
                                showrooms.Add(temp);
                            }
                        }
                    }
            return showrooms;
        }
    }
}