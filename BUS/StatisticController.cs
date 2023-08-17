using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.GUI;
using Project1.DAL;
using MySql.Data.MySqlClient;

namespace Project1.BUS
{
    public class StatisticController
    {
        public void updateView(){
            StatisticView.Menu();
        }
        public List<Order> CarStatistic(int month,int year){
            List<Order> orders=new();
            using (MySqlCommand cmd = DBHelper.UseStored("statistic_by_car"))
            {
                cmd.Parameters.Add("rq_month", MySqlDbType.Int32).Value=month;
                cmd.Parameters.Add("rq_year", MySqlDbType.Int32).Value=year;
                cmd.ExecuteNonQuery();
                using( MySqlDataReader reader =cmd.ExecuteReader()){
                    while (reader.Read())
                    {
                        Order temp=new ();
                        temp.carName= $"{reader["car"]}";
                        temp.totalBill=reader.GetInt64("sum(bill)");
                        orders.Add(temp);
                    }
                }
                }
            return orders;
        } 
        public List<Order> showroomStatistic(int month,int year){
            List<Order> orders=new();
            using (MySqlCommand cmd = DBHelper.UseStored("statistic_by_showroom"))
            {
                cmd.Parameters.Add("rq_month", MySqlDbType.Int32).Value=month;
                cmd.Parameters.Add("rq_year", MySqlDbType.Int32).Value=year;
                cmd.ExecuteNonQuery();
                using( MySqlDataReader reader =cmd.ExecuteReader()){
                    while (reader.Read())
                    {
                        Order temp=new ();
                        temp.carName= $"{reader["showroom"]}";
                        temp.totalBill=reader.GetInt64("sum(bill)");
                        orders.Add(temp);
                    }
                }
                }
            return orders;
        } 
    }
}