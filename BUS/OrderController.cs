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
        public void updateCustomerView1(Car car){
            Order request=OrderView.requestForm(car);
            if(request.carID!=0){
                request.Create_request();
            }
        }
        public void updateCustomerView2(){
            
            while(true){
                Order order=OrderView.customerRequest();
                if(order.ID!=0){
                    switch (order.state)
                    {
                        case 1 or 2 or 3:
                            if(OrderView.OrderMenu1()==1)
                                order.Delete();
                            break;
                        case 4:
                            if(OrderView.OrderMenu2(order)==1)
                            order.AlreadyGetCar(); 
                            break;
                        case 5:
                            OrderView.OrderMenu3(order);
                            break;
                    }
                }
                else break;
            }
        }
        public void updateManagerView(){
            while(true){
                Order order=OrderView.createOrder();
                if(order.ID==0) break;
                else order.Create_order();
            }
        }
        public void updateSalesView1(){
            while(true){
                Order order=OrderView.waitingRequest();
                if(order.ID==0)
                    break;
                else{   
                    if(CheckRequestQuantity()==5)
                        OrderView.tooMuchRequest();
                    else
                        order.Processed_request(); 
                }
            }
        }
        public void updateSalesView2(){
            while(true){
                Order order=OrderView.processingRequest();
                if(order.ID==0)
                    break;
                else{   
                    int result=OrderView.processResult();
                    if(result==0) order.Delete();
                    else
                    updateProcessResult(order,result);
                }
            }
        }
        public void updateSalesView3(){
            OrderView.processedRequest();
        }
        public List<Order> GetProcessedRequest(){
            List<Order> orders=new();
            using (MySqlCommand cmd = DBHelper.UseStored("processed_request"))
            {
                cmd.Parameters.Add("rq_showroom_id", MySqlDbType.Int32).Value=LoginController.accountant.showroom_ID;
                cmd.Parameters.Add("rq_sales_id", MySqlDbType.Int32).Value=LoginController.accountant.ID;
                cmd.ExecuteNonQuery();
                using( MySqlDataReader reader =cmd.ExecuteReader()){
                    while (reader.Read())
                    {
                        Order temp=new();
                        temp.customerName= $"{reader["customer"]}";
                        temp.carName= $"{reader["car"]}";
                        temp.phone= $"{reader["phone"]}";
                        temp.ID=reader.GetInt32("id");
                        temp.state=reader.GetInt32("state");
                        switch (temp.state)
                        {
                            case 3: 
                                temp.State="Waiting create order";
                                break;
                            case 4: 
                                temp.State="Have been payment";
                                break;
                            case 5: 
                                temp.State="Already get car";
                                break;
                        }
                        temp.requestTime= $"{reader["request_time"]}";
                        temp.processedRequestTime= $"{reader["processed_request_time"]}";
                        temp.note= $"{reader["note"]}";
                        orders.Add(temp);
                    }
                }
            }
            return orders;
        }
        public List<Order> GetWaitingRequest(){
            List<Order> orders=new();
            using (MySqlCommand cmd = DBHelper.UseStored("get_request"))
            {
                cmd.Parameters.Add("rq_showroom_id", MySqlDbType.Int32).Value=LoginController.accountant.showroom_ID;
                cmd.ExecuteNonQuery();
                using( MySqlDataReader reader =cmd.ExecuteReader()){
                    while (reader.Read())
                    {
                        Order temp=new();
                        temp.customerName= $"{reader["customer"]}";
                        temp.carName= $"{reader["car"]}";
                        temp.phone= $"{reader["phone"]}";
                        temp.ID=reader.GetInt32("id");
                        temp.requestTime= $"{reader["request_time"]}";
                        temp.note= $"{reader["note"]}";
                        orders.Add(temp);
                    }
                }
            }
            return orders;
        }
        public List<Order> GetProcessingRequest(){
            List<Order> orders=new();
            using (MySqlCommand cmd = DBHelper.UseStored("get_processing_request"))
            {
                cmd.Parameters.Add("rq_sales_id", MySqlDbType.Int32).Value=LoginController.accountant.ID;
                cmd.ExecuteNonQuery();
                using( MySqlDataReader reader =cmd.ExecuteReader()){
                    while (reader.Read())
                    {
                        Order temp=new();
                        temp.customerName= $"{reader["customer"]}";
                        temp.carName= $"{reader["car"]}";
                        temp.phone= $"{reader["phone"]}";
                        temp.ID=reader.GetInt32("id");
                        temp.requestTime= $"{reader["request_time"]}";
                        temp.note= $"{reader["note"]}";
                        orders.Add(temp);
                    }
                }
            }
            return orders;
        }
        public int CheckRequestQuantity(){
            int quantity=0;
            using (MySqlCommand cmd = DBHelper.UseStored("check_request_quantity"))
            {
                cmd.Parameters.Add("rq_sales_id", MySqlDbType.Int32).Value=LoginController.accountant.ID;
                cmd.ExecuteNonQuery();
                using( MySqlDataReader reader =cmd.ExecuteReader()){
                    while (reader.Read())
                    {
                        quantity=reader.GetInt32("quantity");
                    }
                }
            }
            return quantity;
        }
        public void updateProcessResult(Order order,int result){
            if(result!=-1)
                using (MySqlCommand cmd = DBHelper.UseStored("request_process_result"))
                {
                    cmd.Parameters.Add("rq_sales_id", MySqlDbType.Int32).Value=LoginController.accountant.ID;
                    cmd.Parameters.Add("rq_order_id", MySqlDbType.Int32).Value=order.ID;
                    cmd.Parameters.Add("result", MySqlDbType.Int32).Value=result;
                    cmd.ExecuteNonQuery();
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
        public List<Order> GetWaitingOrder(){
            List<Order> orders=new();
            using (MySqlCommand cmd = DBHelper.UseStored("get_waiting_order"))
            {
                cmd.Parameters.Add("rq_showroom_id", MySqlDbType.Int32).Value=LoginController.accountant.showroom_ID;
                cmd.ExecuteNonQuery();
                using( MySqlDataReader reader =cmd.ExecuteReader()){
                    while (reader.Read())
                    {
                        Order temp=new();
                        temp.ID=reader.GetInt32("id");
                        temp.carName= $"{reader["car"]}";
                        temp.customerName= $"{reader["customer"]}";
                        temp.salesName= $"{reader["sales"]}";
                        temp.requestTime= $"{reader["request_time"]}";
                        temp.processedRequestTime= $"{reader["processed_request_time"]}";
                        orders.Add(temp);
                    }
                }
            }
            return orders;
        }
        public List<Order> GetMyOrder(){
            List<Order> orders=new();
            using (MySqlCommand cmd = DBHelper.UseStored("get_customer_order"))
            {
                cmd.Parameters.Add("rq_customer_id", MySqlDbType.Int32).Value=LoginController.accountant.ID;
                cmd.ExecuteNonQuery();
                using( MySqlDataReader reader =cmd.ExecuteReader()){
                    while (reader.Read())
                    {
                        Order temp=new();
                        temp.ID=reader.GetInt32("id");
                        temp.carID=reader.GetInt32("car_id");
                        temp.carName= $"{reader["car"]}";
                        temp.requestTime= $"{reader["request_time"]}";
                        temp.state=reader.GetInt32("state");
                        switch (temp.state)
                        {
                            case 0:
                                temp.State="Cancelled";
                                temp.totalBill=0;
                                break;
                            case 1:
                                temp.State="Waiting";
                                temp.totalBill=0;
                                break;
                            case 2:
                                temp.State="Processing";
                                temp.totalBill=0;
                                break;
                            case 3:
                                temp.State="Processed";
                                temp.totalBill=0;
                                break;
                            case 4:
                                temp.State="Already paid";
                                temp.showroomAddress=$"{reader["address"]}";
                                temp.showroomName=$"{reader["name"]}";
                                temp.managerName=$"{reader["manager_name"]}";
                                temp.salesName=$"{reader["sales"]}";
                                temp.customerName=$"{reader["customer"]}";
                                temp.totalBill=reader.GetInt64("bill");
                                break;
                            case 5:
                                temp.State="Already get car";
                                temp.showroomAddress=$"{reader["address"]}";
                                temp.showroomName=$"{reader["name"]}";
                                temp.managerName=$"{reader["manager_name"]}";
                                temp.salesName=$"{reader["sales"]}";
                                temp.customerName=$"{reader["customer"]}";
                                temp.totalBill=reader.GetInt64("bill");
                                break;
                        }
                        
                        temp.processedRequestTime= $"{reader["processed_request_time"]}";
                        temp.createOrderTime= $"{reader["create_order_time"]}";
                        temp.getCarTime= $"{reader["get_car_time"]}";
                        orders.Add(temp);
                    }
                }
            }
            return orders;
        }
    }
}