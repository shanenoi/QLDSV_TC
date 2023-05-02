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

        public static String OriginDBUserName = string.Empty;
        public static String OriginDBPassword = string.Empty;

        public static String RemoteLoginUserId = "htkn";
        public static String RemoteLoginUserPass = "1234";

        public static Main frmMain;

        public static String connstr;

        public static BindingSource bds_dspm = new BindingSource();

        public static int khoaID;

        public static int CheckDataHelper(String query)
        {
            SqlDataReader dataReader = Program.ExecSqlDataReader(query);

            // nếu null thì thoát luôn  ==> lỗi kết nối
            if (dataReader == null)
            {
                return -1;
            }
            dataReader.Read();
            int result = int.Parse(dataReader.GetValue(0).ToString());
            dataReader.Close();
            return result;
        }
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


        public static int EstablishDBConnection()
        {
            if (Conn != null && Conn.State == ConnectionState.Open)
                Conn.Close();
            try
            {
                connstr = "Data Source=" + ServerName + ";Initial Catalog=QLDSV_TC; User ID=" +
                          DBUserName + ";Password=" + DBPassword;
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

        public static DataTable ExecSqlDataTable(String cmd)
        {
            DataTable dt = new DataTable();
            if (Conn.State == ConnectionState.Closed) Program.Conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, Conn);
            da.Fill(dt);
            Conn.Close();
            return dt;
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