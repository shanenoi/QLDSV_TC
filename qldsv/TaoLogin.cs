using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qldsv
{
    public partial class TaoLogin : Form
    {
        public TaoLogin()
        {
            InitializeComponent();
        }

        private SqlConnection connPublisher = new SqlConnection();

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

        private void LoadMGVRole(object sender, EventArgs e)
        {

            if (KetNoi_CSDLGOC() == 0) return;
            LayDSMaGV("select * from GIANGVIEN");
            LayDSNhom();
        }


        private void LayDSNhom()
        {
            List<String> listNhom = new List<string>();
            if (Program.LoginUserGroup == "PGV")
            {
                listNhom.Add("PGV");
                listNhom.Add("KHOA");
            }
            if (Program.LoginUserGroup == "KHOA")
            {
                listNhom.Add("KHOA");
            }
            if (Program.LoginUserGroup == "PKT")
            {
                listNhom.Add("PKT");
            }
            cmbNhom.DataSource = listNhom;
        }

        private void LayDSMaGV(String query)
        {
            DataTable dt = new DataTable();
            if (Program.Conn.State == ConnectionState.Closed) Program.Conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, Program.Conn);
            da.Fill(dt);
            BindingSource bds = new BindingSource();
            bds.DataSource = dt;
            cmbMaGV.DataSource = bds;
            cmbMaGV.DisplayMember = "MAGV"; cmbMaGV.ValueMember = "MAGV";
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Trim() == "" || txtPass.Text.Trim() == "")
            {
                MessageBox.Show("Tài khoản đăng nhập không được trống", "Lỗi tạo tài khoản", MessageBoxButtons.OK);
                txtLogin.Focus();
                return;
            }

           
            String subLenh = " EXEC    @return_value = [dbo].[SP_TAOLOGIN] " +

                " @LGNAME = N'" + txtLogin.Text.Trim() + "', " +
                " @PASS = N'" + txtPass.Text.Trim() + "', " +
                " @USERNAME = N'" + cmbMaGV.SelectedValue.ToString() + "', " +
                " @ROLE = N'" + cmbNhom.SelectedValue.ToString() + "' ";

            String strLenh = " DECLARE @return_value int " + subLenh +
             " SELECT  'Return Value' = @return_value ";

            int resultCheckLogin = Program.CheckDataHelper(strLenh);


            if (resultCheckLogin == -1)
            {
                MessageBox.Show("Lỗi kết nối với database. Mời ban xem lại !", "", MessageBoxButtons.OK);
                this.Close();
            }
            if (resultCheckLogin == 1)
            {
                errorProvider.SetError(this.txtLogin, "Login bị trùng . Mời bạn nhập login khác !");
            }
            else if (resultCheckLogin == 2)
            {
                errorProvider.SetError(this.cmbMaGV, "Giảng viên đã có tài khoản rồi !");

            }
            else if (resultCheckLogin == 3)
            {
                MessageBox.Show("Lỗi thực thi trong cơ sơ dữ liệu !", "", MessageBoxButtons.OK);
            }
            else if (resultCheckLogin == 0)
            {
                MessageBox.Show("Tạo tài khoản thành công !", "", MessageBoxButtons.OK);

            }


        }
    }
}
