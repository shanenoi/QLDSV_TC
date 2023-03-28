using qldsv.Database;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace qldsv
{
    static class Program
    {
        public static String ConnStrPublisher = "Data Source=LAPTOP-BAODLQ; Initial Catalog=QLDSV_TC; Integrated Security = True";
        public static SqlConnection Conn = new SqlConnection();
        public static SqlDataReader MyReader;

        public static String ServerName = "LAPTOP-BAODLQ";
        public static String DBName = "QLDSV_TC";
        public static String DBUserName = string.Empty;
        public static String DBPassword = string.Empty;

        public static String LoginUserID = string.Empty;
        public static String LoginUserName = string.Empty;
        public static String LoginUserGroup = string.Empty;

        public static Main frmMain;

        public static SqlDataReader ExecSqlDataReader(String strLenh)
        {
            SqlDataReader myReader;
            SqlCommand sqlcmd = new SqlCommand(strLenh, Conn);

            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandTimeout = 600;
            if (Conn.State == ConnectionState.Closed) Conn.Open();
            try
            {
                myReader = sqlcmd.ExecuteReader();
                return myReader;
            }
            catch (SqlException ex)
            {
                Conn.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }


        public static int EstablishDBConnection(String ServerName, String DBUserName, String DBPassword)
        {
            if (Conn != null && Conn.State == ConnectionState.Open)
                Conn.Close();
            try
            {
                Connection c = new Connection(ServerName, DBName, DBUserName, DBPassword);
                Conn = c.Connect(Conn);
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmMain = new Main();
            Application.Run(frmMain);
        }
    }
}