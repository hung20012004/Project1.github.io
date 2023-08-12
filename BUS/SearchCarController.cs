using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.DAL;
using Project1.GUI;
using MySql.Data.MySqlClient;

namespace Project1.BUS
{
    public class SearchCarController
    {
        public void updateView(){
            while(true){
                Car car=SearchCarView.Cars();
                if(car.ID!=0){
                    if(SearchCarView.CarDetail(car)==1){
                        OrderController controller=new();
                        controller.updateCustomerView1(car);
                    }
                }
                else if(car.ID==0) break;
            }
        }
        public List<Car> getData(int modelID,int saloonID,long fistPrice,long lastPrice){
            List<Car> cars=new List<Car>();
            using (MySqlCommand cmd = DBHelper.UseStored("get_cars"))
            {
                cmd.Parameters.Add("rq_model_id", MySqlDbType.Int32).Value=modelID;
                cmd.Parameters.Add("rq_saloon_id", MySqlDbType.Int32).Value=saloonID;
                cmd.Parameters.Add("rq_fist_price", MySqlDbType.Int64).Value=fistPrice;
                cmd.Parameters.Add("rq_last_price", MySqlDbType.Int64).Value=lastPrice;
                cmd.ExecuteNonQuery();
                using( MySqlDataReader reader =cmd.ExecuteReader()){
                    while (reader.Read())
                    {
                        Car temp=new Car();
                        temp.ID=reader.GetInt32("id");
                        temp.Name= $"{reader["name"]}";
                        temp.Engine= $"{reader["engine"]}";
                        temp.Colors= $"{reader["colors"]}";
                        temp.Uphostery= $"{reader["uphostery"]}";
                        temp.Cylinder= reader.GetInt32("cylinder");
                        temp.Displacement= reader.GetDouble("displacement");
                        temp.Length=reader.GetDouble("length");
                        temp.Weight=reader.GetDouble("weight");
                        temp.Height=reader.GetDouble("height");
                        temp.Width=reader.GetInt32("width");
                        temp.max_speed=reader.GetInt32("max_speed");
                        temp.door_num=reader.GetInt32("door_num");
                        temp.seat_num=reader.GetInt32("seat_num");
                        temp.Price=reader.GetInt64("price");
                        temp.quantity=reader.GetInt32("quantity_in_stock");
                        cars.Add(temp);
                    }
                }
                return cars;
            }
        }
        public List<Model> getModelData(){
            List<Model> models=new List<Model>();
            using (MySqlCommand cmd = DBHelper.UseStored("get_model"))
                    {
                        cmd.ExecuteNonQuery();
                        using( MySqlDataReader reader =cmd.ExecuteReader()){
                            while (reader.Read())
                            {
                                Model temp=new Model();
                                temp.ID= reader.GetInt32("id");
                                temp.name= $"{reader["name"]}";
                                models.Add(temp);
                            }
                        }
                    }
            return models;
        }
        public List<Saloon> getSaloonData(int modelID){
            List<Saloon> saloons=new List<Saloon>();
            using (MySqlCommand cmd = DBHelper.UseStored("get_saloon"))
                    {
                        cmd.Parameters.Add("rq_model_id", MySqlDbType.Int32).Value=modelID;
                        cmd.ExecuteNonQuery();
                        using( MySqlDataReader reader =cmd.ExecuteReader()){
                            while (reader.Read())
                            {
                                Saloon temp=new Saloon();
                                temp.ID= reader.GetInt32("id");
                                temp.name= $"{reader["name"]}";
                                saloons.Add(temp);
                            }
                        }
                    }
            return saloons;
        }
        
    }
}