using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace qldsv
{
    public partial class DangNhap : Form
    {
        private SqlConnection connPublisher = new SqlConnection();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            if (KetNoi_CSDLGOC() == 0) return;
            LayDSPM("select * from Get_Subscribes");
        }
        
        private void LayDSPM(string query)
        {
            DataTable dt = new DataTable();
            if (connPublisher.State == ConnectionState.Closed) connPublisher.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, connPublisher);
            da.Fill(dt);
            connPublisher.Close();
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            cmbKhoa.DataSource = bs;
            cmbKhoa.DisplayMember = "TENKHOA"; cmbKhoa.ValueMember = "TENSERVER";
        }

        private int KetNoi_CSDLGOC()
        {
            if (connPublisher != null && connPublisher.State == ConnectionState.Open) connPublisher.Close();
            try
            {
                connPublisher.ConnectionString = Program.ConnStrPublisher;
                connPublisher.Open();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return 0;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text.Trim() == "" || txtMatKhau.Text.Trim() == "")
            {
                MessageBox.Show("Tài khoản đăng nhập không được trống", "Lỗi đăng nhập", MessageBoxButtons.OK);
                txtTaiKhoan.Focus();
                return;
            }

            String ServerName = cmbKhoa.SelectedValue.ToString();

            /*
             *
             * if ui.is_login_student:
             *   username = studentusername
             *   password = studentpassword
             * else
             *   username = txtTaiKhoan.Text
             *   password = txtMatKhau.Text
             * end
             * Program.EstablishDBConnection(ServerName, username, password) == 0
             *
             */

            if (Program.EstablishDBConnection(ServerName, txtTaiKhoan.Text, txtMatKhau.Text) == 0)
            {
                return;
            }

            String strLenh = "exec SP_DANGNHAP '" + Program.DBUserName + "'";
            Program.MyReader = Program.ExecSqlDataReader(strLenh);
            if (Program.MyReader == null)
            {
                return;
            }

            Program.MyReader.Read();

            Program.LoginUserID = Program.MyReader.GetString(0);
            if (Convert.IsDBNull(Program.LoginUserID))
            {
                MessageBox.Show("Login bạn nhập không có quyền truy cập dữ liệu\nBạn xem lại username, password", "", MessageBoxButtons.OK);
                return;
            }

            try
            {
                Program.LoginUserName = Program.MyReader.GetString(1);
                Program.LoginUserGroup = Program.MyReader.GetString(2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("---> Lỗi: " + ex.ToString());
                MessageBox.Show("Login bạn nhập không có quyền truy cập vào chương trình", "", MessageBoxButtons.OK);
                return;
            }

            Program.MyReader.Close();
            Program.Conn.Close();


            Program.frmMain.lblMAGV.Text = "MÃ GIẢNG VIÊN : " + Program.LoginUserID;
            Program.frmMain.lblHOTEN.Text = "HỌ VÀ TÊN : " + Program.LoginUserName;
            Program.frmMain.lblNHOM.Text = "NHÓM : " + Program.LoginUserGroup;

            Program.frmMain.Show();
            this.Visible = false;
        }
    }
}
