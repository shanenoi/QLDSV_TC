using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using qldsv.Database;


namespace qldsv
{
    static class Program
    {
        public static BindingSource bds_dspm = new BindingSource();
        public static String connstr_publisher = "Data Source=LAPTOP-BAODLQ; Initial Catalog=QLDSV_TC; Integrated Security = True";
        public static SqlConnection Conn = new SqlConnection();
        public static String URL_Connect;
        public static String ServerName = "LAPTOP-BAODLQ";
        public static String Database = "QLDSV_TC";
        public static String MLoginDN = string.Empty;
        public static String PasswordDN = string.Empty;
        public static String MLogin = string.Empty;
        public static String MPassword = string.Empty;
        public static int MKhoa = 0;
        public static SqlDataReader MyReader;
        public static String UserName = string.Empty;
        public static String MHoten = string.Empty;
        public static String MGroup = string.Empty;
        public static Main frmMain;
        public static DangNhap frmDangNhap;




        public static SqlDataReader ExecSqlDataReader(String strLenh)
        {
            SqlDataReader myReader;
            SqlCommand sqlcmd = new SqlCommand(strLenh, Program.Conn);

            //xác định kiểu lệnh cho sqlcmd là kiểu text.
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandTimeout = 600;
            if (Program.Conn.State == ConnectionState.Closed) Program.Conn.Open();
            try
            {
                myReader = sqlcmd.ExecuteReader();
                return myReader;
            }
            catch (SqlException ex)
            {
                Program.Conn.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }


        public static int KetNoi()
        {
            if (Program.Conn != null && Program.Conn.State == ConnectionState.Open)
                // đóng đối tượng kết nối
                Program.Conn.Close();
            try
            {
                Program.URL_Connect = "Data Source=" + Program.ServerName + ";Initial Catalog=" +
                      Program.Database + ";User ID=" +
                      Program.MLogin + ";Password=" + Program.MPassword;
                Program.Conn.ConnectionString = Program.URL_Connect;

                // mở đối tượng kết nối
                Program.Conn.Open();
                return 1;
            }

            catch (Exception e)
            {
                MessageBox.Show("---> Lỗi kết nối cơ sở dữ liệu.\n---> Bạn xem lại Username và Password.\n " + e.Message, string.Empty, MessageBoxButtons.OK);
                return 0;
            }
        }

        [STAThread]
        static void Main()
        {
            //Connection connParams = new Connection("LAPTOP-BAODLQ", "QLDSV_TC", "sa", "1234");
            //SqlConnection connection = new SqlConnection(connParams.ToString());

            //try
            //{
            //    connection.Open();
            //    Console.WriteLine("Connection successful");
            //    foreach (SinhVien item in SinhVien.GetAll(connection))
            //    {
            //        Console.WriteLine("--{0}\t", item.ToString());
            //        Console.WriteLine("------");
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Connection failed: " + ex.Message);
            //}
            //finally
            //{
            //    connection.Close();
            //}
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmMain = new Main();
            Application.Run(frmMain);
        }
    }
}
/*

 */