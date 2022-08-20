﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Mangement_System
{
    
    class Customer : DBconnection
    {

        public string Name { get; set; }
        public string Address { get; set; }

        public string Nic { get; set; }

        public string Phone { get; set; }



        public void register(string Name,string Address,string Nic,string Phone)
        {
            DBconnection db = new DBconnection();
            db.Connect();
       
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO customer(cname,caddress,ctel,cnic) VALUES(@name,@address,@tel,@nic)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = db.conn;

                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = Name;
                cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = Address;
                cmd.Parameters.Add("@tel", MySqlDbType.VarChar).Value = Phone;
                cmd.Parameters.Add("@nic", MySqlDbType.VarChar).Value = Nic;


                cmd.ExecuteNonQuery();
                db.conn.Close();
            }
           

        }


        public void update(string Name, string Address, string Nic, string Phone)
        {
            DBconnection db = new DBconnection();
            db.Connect();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE customer SET `cname`=@name,`caddress`=@address,`ctel`=@tel WHERE `cnic`=@nic";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = db.conn;

                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = Name;
                cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = Address;
                cmd.Parameters.Add("@tel", MySqlDbType.VarChar).Value = Phone;
                cmd.Parameters.Add("@nic", MySqlDbType.VarChar).Value = Nic;
               

                cmd.ExecuteNonQuery();
                db.conn.Close();
            }
        }

        //delete

        public void delete(string Nic)
        {
            DBconnection db = new DBconnection();
            db.Connect();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE FROM `customer` WHERE `cnic`=@nic";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = db.conn;


                cmd.Parameters.Add("@nic", MySqlDbType.VarChar).Value = Nic;


                cmd.ExecuteNonQuery();
                db.conn.Close();
            }
        }

    }
}
