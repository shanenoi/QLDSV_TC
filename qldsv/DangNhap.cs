using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace qldsv
{
    public partial class DangNhap : Form
    {
        private SqlConnection conn_publisher = new SqlConnection();
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
            if (conn_publisher.State == ConnectionState.Closed) conn_publisher.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, conn_publisher);
            da.Fill(dt);
            conn_publisher.Close();
            Program.bds_dspm.DataSource = dt;
            cmbKhoa.DataSource = Program.bds_dspm;
            cmbKhoa.DisplayMember = "TENKHOA"; cmbKhoa.ValueMember = "TENSERVER";
        }

        private int KetNoi_CSDLGOC()
        {
            if (conn_publisher != null && conn_publisher.State == ConnectionState.Open) conn_publisher.Close();
            try
            {
                conn_publisher.ConnectionString = Program.connstr_publisher;
                conn_publisher.Open();
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

                // trỏ con trỏ chuột về ô user...
                txtTaiKhoan.Focus();
                return;
            }

            Program.MLogin = txtTaiKhoan.Text;
            Program.MPassword = txtMatKhau.Text;

           

            Program.MKhoa = cmbKhoa.SelectedIndex;

            Program.MLoginDN = Program.MLogin;
            Program.PasswordDN = Program.MPassword;
            Program.ServerName = cmbKhoa.SelectedValue.ToString();

            if (Program.KetNoi() == 0)
            {
                return;
            }

            String strLenh = "exec SP_DANGNHAP '" + Program.MLogin + "'" ;
            Program.MyReader = Program.ExecSqlDataReader(strLenh);
            if (Program.MyReader == null)
            {
                return;
            }

            Program.MyReader.Read();

            Program.UserName = Program.MyReader.GetString(0);     // Lay user name
            if (Convert.IsDBNull(Program.UserName))
            {
                MessageBox.Show("Login bạn nhập không có quyền truy cập dữ liệu\nBạn xem lại username, password", "", MessageBoxButtons.OK);
                return;
            }

            try
            {
                Program.MHoten = Program.MyReader.GetString(1);
                Program.MGroup = Program.MyReader.GetString(2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("---> Lỗi: " + ex.ToString());
                MessageBox.Show("Login bạn nhập không có quyền truy cập vào chương trình", "", MessageBoxButtons.OK);
                return;
            }

            Program.MyReader.Close();
            Program.Conn.Close();


            // hiện thông tin tài khoản
            Program.frmMain.lblMAGV.Text = "MÃ GIẢNG VIÊN : " + Program.UserName;
            Program.frmMain.lblHOTEN.Text = "HỌ VÀ TÊN : " + Program.MHoten;
            Program.frmMain.lblNHOM.Text = "NHÓM : " + Program.MGroup;

            Program.frmMain.Show();
            this.Visible = false;
        }
    }
}
