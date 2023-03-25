using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using qldsv.Database;

namespace qldsv
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Connection connParams = new Connection("LAPTOP-BAODLQ", "QLDSV_TC", "sa", "1234");
            SqlConnection connection = new SqlConnection(connParams.ToString());

            try
            {
                connection.Open();
                Console.WriteLine("Connection successful");
                foreach (SinhVien item in SinhVien.GetAll(connection))
                {
                    Console.WriteLine("--{0}\t", item.ToString());
                    Console.WriteLine("------");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection failed: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
/*

 */