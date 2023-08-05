using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.GUI;
using Project1.DAL;
using MySql.Data.MySqlClient;

namespace Project1.BUS
{
    public class OrderController
    {
        public void updateView(int showroom_ID){
            Order order=OrderView.createOrderLayer(showroom_ID);
            if(order.requestID!=0)
                order.Create();    
        }
        public List<Request> GetRequest(int showroom_ID){
            List<Request> requests=new List<Request>();
            using (MySqlCommand cmd = DBHelper.UseStored("get_request"))
            {
                cmd.Parameters.Add("rq_showroom_id", MySqlDbType.Int32).Value=showroom_ID;
                cmd.ExecuteNonQuery();
                using( MySqlDataReader reader =cmd.ExecuteReader()){
                    while (reader.Read())
                    {
                        Request temp=new Request();
                        temp.ID=reader.GetInt32("id");
                        temp.customerName= $"{reader["customer"]}";
                        temp.phone= $"{reader["phone"]}";
                        temp.address= $"{reader["address"]}";
                        temp.requestTime= $"{reader["request_time"]}";
                        temp.note= $"{reader["note"]}";
                        temp.carID=reader.GetInt32("car_id");
                        requests.Add(temp);
                    }
                }
            }
            return requests;
        }
        public List<Salesman> GetSalesman(int showroom_ID){
            List<Salesman> salesmans=new List<Salesman>();
            using (MySqlCommand cmd = DBHelper.UseStored("get_salesman"))
            {
                cmd.Parameters.Add("rq_showroom_id", MySqlDbType.Int32).Value=showroom_ID;
                cmd.ExecuteNonQuery();
                using( MySqlDataReader reader =cmd.ExecuteReader()){
                    while (reader.Read())
                    {
                        Salesman temp=new Salesman();
                        temp.ID=reader.GetInt32("id");
                        temp.Name= $"{reader["name"]}";
                        salesmans.Add(temp);
                    }
                }
            }
            return salesmans;
        }
    }
}