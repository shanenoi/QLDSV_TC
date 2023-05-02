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
            Program.bds_dspm.DataSource = dt;
            cmbKhoa.DataSource = Program.bds_dspm;
            cmbKhoa.DisplayMember = "TENKHOA"; cmbKhoa.ValueMember = "TENSERVER";
        }
        private int ktttdnsv(String msv, String pass)
        {
            String we = "execute SP_CHECK_DN_SINHVIEN '" + msv + "', '" + pass + "'";
            Program.Conn = connPublisher;

            Program.MyReader = Program.ExecSqlDataReader(we);
            if (Program.MyReader == null)
            {
                return 0;
            }

            Program.MyReader.Read();
            int ccwer = Program.MyReader.GetInt32(3);
            Console.WriteLine("--001", ccwer);
            return ccwer;
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

            Program.DBUserName = txtTaiKhoan.Text.Trim(); Program.DBPassword = txtMatKhau.Text.Trim();
            String strLenh = "exec SP_DANGNHAP '" + Program.DBUserName + "'";

            if (cbSinhVien.Checked)
            {
                Program.DBUserName = "loginsv";
                Program.DBPassword = "1234";
                strLenh = "exec SP_CHECK_DN_SINHVIEN '" + txtTaiKhoan.Text.Trim() + "', '" + txtMatKhau.Text.Trim() + "'";
            }

            Program.ServerName = cmbKhoa.SelectedValue.ToString();
            if (Program.EstablishDBConnection() == 0)
            {
                return;
            }

            Program.OriginDBUserName = Program.DBUserName;
            Program.OriginDBPassword = Program.DBPassword;

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
                if (cbSinhVien.Checked)
                {
                    String status = Program.MyReader.GetString(3);
                    switch (status)
                    {
                        case "0":
                            MessageBox.Show("Tài khoản đăng nhập không Tồn Tại", "Lỗi đăng nhập", MessageBoxButtons.OK);
                            txtTaiKhoan.Focus();
                            return;

                        case "1":
                            MessageBox.Show("Tài khoản đăng nhập không đúng mật khẩu", "Lỗi đăng nhập", MessageBoxButtons.OK);
                            txtTaiKhoan.Focus();
                            return;
                    }
                }
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

            if(!cbSinhVien.Checked)
            {
                Program.frmMain.rpgTaoLogin.Visible = true;
            }

            Program.khoaID = cmbKhoa.SelectedIndex;

            this.Close();
        }
    }
}
