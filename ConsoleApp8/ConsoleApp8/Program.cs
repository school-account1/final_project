using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            var con = new SqlConnection(@"data source=LAPTOP-53MHDDG7\SQLEXPRESS;database = Contact;Trusted_Connection=True;");
            SqlCommand cm = new SqlCommand("select id, Name, LastName, PhoneNumber, Email from person", con);
            SqlCommand cmwhere = new SqlCommand("select id, Name, LastName, PhoneNumber, Email from person where id = @id", con);
            cmwhere.Parameters.AddWithValue("@id", "1");

            string queryadd = "INSERT INTO person(Name, LastName, PhoneNumber, Email) VALUES(@Name,@LastName, @PhoneNumber, @Email)";


            string queryupdate = "UPDATE person SET Name = @Name, LastName = @LastName, PhoneNumber = @PhoneNumber, Email = @Email Where id = @Id";


            string querydelete = "DELETE from person Where id = @id";


            SqlCommand cmd = new SqlCommand(queryadd, con);

//            cmd.Parameters.AddWithValue("@Id", "4");
            cmd.Parameters.AddWithValue("@Name", "Bob");
            cmd.Parameters.AddWithValue("@LastName", "Leponge");
            cmd.Parameters.AddWithValue("@PhoneNumber", "678-843-5679");
            cmd.Parameters.AddWithValue("@Email", "eponge@mail.com");

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Done");
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    // Display Record
                    Console.WriteLine(sdr["id"] + " " + sdr["Name"] + " " + sdr["LastName"] + " " + sdr["PhoneNumber"] + " " + sdr["Email"]);
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine("bruh" + e.ToString());
            }
            finally
            {
                con.Close();
            }
        }
    }
}
