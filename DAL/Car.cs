using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Project1.DAL
{
    public class Car
    {
        public int ID;
        public string? Name;
        public int Salloon_ID;
        public string? Engine;
        public string? Colors;
        public string? Uphostery;
        public double Displacement;
        public double Length;
        public double Width;
        public double Height;
        public double Weight;
        public long Price;
        public int Cylinder;
        public int max_speed;
        public int door_num;
        public int seat_num;
        public int quantity;
        public void Update(){
            using (MySqlCommand cmd = DBHelper.UseStored("update_car"))
            {
                cmd.Parameters.Add("rq_car_id", MySqlDbType.Int32).Value=ID;
                cmd.Parameters.Add("rq_engine", MySqlDbType.VarChar).Value=Engine;
                cmd.Parameters.Add("rq_colors", MySqlDbType.VarChar).Value=Colors;
                cmd.Parameters.Add("rq_uphostery", MySqlDbType.VarChar).Value=Uphostery;
                cmd.Parameters.Add("rq_cylinder", MySqlDbType.Int32).Value=Cylinder;
                cmd.Parameters.Add("rq_displacement", MySqlDbType.Double).Value=Displacement;
                cmd.Parameters.Add("rq_length", MySqlDbType.Double).Value=Length;
                cmd.Parameters.Add("rq_width", MySqlDbType.Double).Value=Width;
                cmd.Parameters.Add("rq_height", MySqlDbType.Double).Value=Height;
                cmd.Parameters.Add("rq_weight", MySqlDbType.Double).Value=Weight;
                cmd.Parameters.Add("rq_max_speed", MySqlDbType.Int32).Value=max_speed;
                cmd.Parameters.Add("rq_seat_num", MySqlDbType.Int32).Value=seat_num;
                cmd.Parameters.Add("rq_door_num", MySqlDbType.Int32).Value=door_num;
                cmd.Parameters.Add("rq_price", MySqlDbType.Int64).Value=Price;
                cmd.Parameters.Add("rq_quantity", MySqlDbType.Int32).Value=quantity;
                cmd.ExecuteNonQuery();
            }
        }
        public void Delete(){
            using (MySqlCommand cmd = DBHelper.UseStored("delete_cars"))
            {
               cmd.Parameters.Add("rq_car_id", MySqlDbType.Int32).Value=ID;
                cmd.ExecuteNonQuery();
            }
        }
        public void Create(){
            using (MySqlCommand cmd = DBHelper.UseStored("create_car"))
            {
                cmd.Parameters.Add("rq_name", MySqlDbType.VarChar).Value=Name;
                cmd.Parameters.Add("rq_saloon_id", MySqlDbType.Int32).Value=Salloon_ID;
                cmd.Parameters.Add("rq_engine", MySqlDbType.VarChar).Value=Engine;
                cmd.Parameters.Add("rq_colors", MySqlDbType.VarChar).Value=Colors;
                cmd.Parameters.Add("rq_uphostery", MySqlDbType.VarChar).Value=Uphostery;
                cmd.Parameters.Add("rq_cylinder", MySqlDbType.Int32).Value=Cylinder;
                cmd.Parameters.Add("rq_displacement", MySqlDbType.Double).Value=Displacement;
                cmd.Parameters.Add("rq_length", MySqlDbType.Double).Value=Length;
                cmd.Parameters.Add("rq_width", MySqlDbType.Double).Value=Width;
                cmd.Parameters.Add("rq_height", MySqlDbType.Double).Value=Height;
                cmd.Parameters.Add("rq_weight", MySqlDbType.Double).Value=Weight;
                cmd.Parameters.Add("rq_max_speed", MySqlDbType.Int32).Value=max_speed;
                cmd.Parameters.Add("rq_seat_num", MySqlDbType.Int32).Value=seat_num;
                cmd.Parameters.Add("rq_door_num", MySqlDbType.Int32).Value=door_num;
                cmd.Parameters.Add("rq_price", MySqlDbType.Int64).Value=Price;
                cmd.Parameters.Add("rq_quantity", MySqlDbType.Int32).Value=quantity;
                cmd.ExecuteNonQuery();
            }
        }

    }
}