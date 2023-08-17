using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Project1.BUS;

namespace Project1.DAL
{
    public class Order
    {
        public int ID;
        public string? note;
        
        public string? carName;
        public string? customerName;
        public string? salesName;
        public string? managerName;
        public string? showroomName;
        public string? showroomAddress;
        public string? phone;
        
        public string? requestTime;
        public string? processedRequestTime;
        public string? createOrderTime;
        public string? getCarTime;
        public long totalBill;

        public int carID;
        public int showroomID;
        public int customerID;
        public int state;
        public string? State;

        public void Delete(){
            using (MySqlCommand cmd = DBHelper.UseStored("delete_order"))
            {
                cmd.Parameters.Add("rq_order_id", MySqlDbType.Int32).Value=ID;
                cmd.ExecuteNonQuery();
            }
        }
        public void Create_request(){
            using (MySqlCommand cmd = DBHelper.UseStored("create_request"))
            {
                cmd.Parameters.Add("rq_note", MySqlDbType.VarChar).Value=note;
                cmd.Parameters.Add("rq_customer_id", MySqlDbType.Int32).Value=LoginController.accountant.ID;
                cmd.Parameters.Add("rq_car_id", MySqlDbType.Int32).Value=carID;
                cmd.Parameters.Add("rq_showroom_id", MySqlDbType.Int32).Value=showroomID;
                cmd.ExecuteNonQuery();
            }
        }
        public void Processed_request(){
            using (MySqlCommand cmd = DBHelper.UseStored("request_process"))
            {
                cmd.Parameters.Add("rq_sales_id", MySqlDbType.Int32).Value=LoginController.accountant.ID;
                cmd.Parameters.Add("rq_order_id", MySqlDbType.Int32).Value=ID;
                cmd.ExecuteNonQuery();
            }
        }
        public void Create_order(){
            using (MySqlCommand cmd = DBHelper.UseStored("create_order"))
            {
                
                cmd.Parameters.Add("rq_order_id", MySqlDbType.Int32).Value=ID;
                cmd.Parameters.Add("total_bill", MySqlDbType.Int64).Value=totalBill;
                cmd.ExecuteNonQuery();
            }
        }
        public void AlreadyGetCar(){
            using (MySqlCommand cmd = DBHelper.UseStored("already_get_car"))
            {
                cmd.Parameters.Add("rq_order_id", MySqlDbType.Int32).Value=ID;
                cmd.Parameters.Add("rq_car_id", MySqlDbType.Int32).Value=ID;
                cmd.ExecuteNonQuery();
            }
        }
    }
}