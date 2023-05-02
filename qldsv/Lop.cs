using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qldsv
{
    public partial class Lop : Form
    {
        private BindingSource bds_dspm = new BindingSource();
        private String makhoa = "";

        private int position = 0;
        private string option = "";
        private string oldMaLop = "";
        private string oldTenLop = "";

        public Lop()
        {
            InitializeComponent();
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsLop.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void Lop_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.lopTableAdapter.Connection.ConnectionString = Program.connstr;
            this.svTableAdapter.Connection.ConnectionString = Program.connstr;

            this.lopTableAdapter.Fill(this.DS.LOP);
            this.svTableAdapter.Fill(this.DS.SINHVIEN);

            this.bds_dspm.DataSource = Program.bds_dspm.DataSource;

            makhoa = ((DataRowView)bdsLop[0])["MAKHOA"].ToString();

            bds_dspm.Filter = "TENSERVER NOT LIKE '%SERVER3'";
            cmbKhoa.DataSource = bds_dspm;
            cmbKhoa.DisplayMember = "TENKHOA"; cmbKhoa.ValueMember = "TENSERVER";
            //cmbKhoa.SelectedIndex = 1;
            cmbKhoa.SelectedIndex = Program.khoaID;

            if (Program.LoginUserGroup == "PGV")
            {
                cmbKhoa.Enabled = true;
            }
            else cmbKhoa.Enabled = false;

            barBtnThem.Enabled = barBtnXoa.Enabled = barBtnSua.Enabled = LopGridControl.Enabled = true;
            barBtnPhuchoi.Enabled = grbNhapLop.Enabled = false;
        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.SelectedValue.ToString() == "System.Data.DataRowView") return;

            Program.ServerName = cmbKhoa.SelectedValue.ToString();

            if (Program.khoaID == cmbKhoa.SelectedIndex)
            {
                Program.DBUserName = Program.OriginDBUserName;
                Program.DBPassword = Program.OriginDBPassword;
            }
            else
            {
                Program.DBUserName = Program.RemoteLoginUserId;
                Program.DBPassword = Program.RemoteLoginUserPass;
            }

            if(Program.EstablishDBConnection() == 0)
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới");
            }
            else
            {
                this.lopTableAdapter.Connection.ConnectionString = Program.connstr;
                this.svTableAdapter.Connection.ConnectionString = Program.connstr;

                this.lopTableAdapter.Fill(this.DS.LOP);
                this.svTableAdapter.Fill(this.DS.SINHVIEN);

                makhoa = ((DataRowView)bdsLop[0])["MAKHOA"].ToString();
            }
        }

        private bool validateInput()
        {

            if (txtMaLop.Text.Trim().Equals(""))
            {

                MessageBox.Show("Mã lớp không được để trống !");
                txtMaLop.Focus();
                return false;
            }
            if (txtTenLop.Text.Trim().Equals(""))
            {
                MessageBox.Show("Tên lớp không được để trống !");
                txtTenLop.Focus();
                return false;
            }
            if (txtKhoaHoc.Text.Trim().Equals(""))
            {
                MessageBox.Show("Khóa học không được để trống !");
                txtKhoaHoc.Focus();
                return false;
            }
            if (option == "add")
            {
                string query1 = "DECLARE  @return_value int \n"
                            + "EXEC  @return_value = SP_CHECKID \n"
                            + "@Code = N'" + txtMaLop.Text + "',@Type = N'MALOP' \n"
                            + "SELECT  'Return Value' = @return_value ";
                int resultMa = Program.CheckDataHelper(query1);
                if (resultMa == -1)
                {
                    MessageBox.Show("Lỗi kết nối với database. Mời ban xem lại !", "", MessageBoxButtons.OK);
                    this.Close();
                }
                if (resultMa == 1)
                {
                    MessageBox.Show("Mã lớp đã tồn tại ở Khoa hiên tại !");
                    txtMaLop.Focus();
                    return false;
                }
                if (resultMa == 2)
                {
                    MessageBox.Show("Mã lớp đã tồn tại ở Khoa khác !");
                    txtMaLop.Focus();
                    return false;
                }

                string query2 = "DECLARE @return_value int \n"
                               + "EXEC @return_value = SP_CHECKNAME \n"
                               + "@Name = N'" + txtTenLop.Text + "', @Type = N'TENLOP' \n"
                               + "SELECT 'Return Value' = @return_value ";
                int resultTen = Program.CheckDataHelper(query2);
                if (resultTen == -1)
                {
                    MessageBox.Show("Lỗi kết nối với Database. Mời bạn xem lại !", "", MessageBoxButtons.OK);
                    this.Close();
                }
                if (resultTen == 1)
                {
                    MessageBox.Show("Tên lớp đã có rồi !");
                    txtTenLop.Focus();
                    return false;
                }
                if (resultTen == 2)
                {
                    MessageBox.Show("Tên lớp đã tồn tại ở Khoa khác !");
                    txtTenLop.Focus();
                    return false;
                }
            }
            if (option == "update")
            {
                if (!this.txtMaLop.Text.Trim().ToString().Equals(oldMaLop))// Nếu mã lớp thay đổi so với ban đầu
                {
                    //TODO: Check mã lớp có tồn tại chưa
                    string query1 = "DECLARE  @return_value int \n"
                                + "EXEC  @return_value = SP_CHECKID \n"
                                + "@Code = N'" + txtMaLop.Text + "',@Type = N'MALOP' \n"
                                + "SELECT  'Return Value' = @return_value ";

                    int resultMa = Program.CheckDataHelper(query1);
                    if (resultMa == -1)
                    {
                        MessageBox.Show("Lỗi kết nối với database. Mời ban xem lại !", "", MessageBoxButtons.OK);
                        this.Close();
                    }
                    if (resultMa == 1)
                    {
                        MessageBox.Show("Mã lớp đã tồn tại ở Khoa hiên tại !");
                        txtMaLop.Focus();
                        return false;
                    }
                    if (resultMa == 2)
                    {
                        MessageBox.Show("Mã lớp đã tồn tại ở Khoa khác !");
                        txtMaLop.Focus();
                        return false;
                    }
                }
                if (!this.txtTenLop.Text.Trim().ToString().Equals(oldTenLop))
                {
                    // TODO : Check tên lớp có tồn tại chưa
                    string query2 = "DECLARE @return_value int \n"
                                   + "EXEC @return_value = SP_CHECKNAME \n"
                                   + "@Name = N'" + txtTenLop.Text + "', @Type = N'TENLOP' \n"
                                   + "SELECT 'Return Value' = @return_value ";
                    int resultTen = Program.CheckDataHelper(query2);
                    if (resultTen == -1)
                    {
                        MessageBox.Show("Lỗi kết nối với Database. Mời bạn xem lại !", "", MessageBoxButtons.OK);
                        this.Close();
                    }
                    if (resultTen == 1)
                    {
                        MessageBox.Show("Tên lớp đã tồn tại!");
                        txtTenLop.Focus();
                        return false;
                    }
                    if (resultTen == 2)
                    {
                        MessageBox.Show("Tên lớp đã tồn tại ở Khoa khác !");
                        txtTenLop.Focus();
                        return false;
                    }
                }
            }
            return true;
        }

        private void gridViewLop_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if(bdsLop.Position > 0)
            {
                position = bdsLop.Position;
            }
        }

        private void barBtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            option = "add";
            position = bdsLop.Position;
            grbNhapLop.Enabled = true;
            bdsLop.AddNew();
            txtMaKhoa.Text = makhoa;
            txtKhoaHoc.Text = txtMaLop.Text = txtTenLop.Text = "";
            barBtnThem.Enabled = barBtnSua.Enabled = barBtnXoa.Enabled = barBtnLammoi.Enabled = barBtnThoat.Enabled = false;
            barBtnGhi.Enabled = barBtnPhuchoi.Enabled = true;

            LopGridControl.Enabled = false;
        }

        private void barBtnPhuchoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LopGridControl.Enabled = true;
            if (option == "add") bdsLop.RemoveCurrent();
            bdsLop.CancelEdit();

            if (option == "add") bdsLop.Position = position;

            grbNhapLop.Enabled = false;
            barBtnThem.Enabled = barBtnSua.Enabled = barBtnXoa.Enabled = barBtnLammoi.Enabled = barBtnThoat.Enabled = true;
            option = "";
            barBtnPhuchoi.Enabled = barBtnGhi.Enabled = false;
            cmbKhoa.Enabled = true;

        }

        private void barBtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            option = "update";
            oldMaLop = txtMaLop.Text.Trim();
            oldTenLop = txtTenLop.Text.Trim();

            position = bdsLop.Position;
            grbNhapLop.Enabled = true;
            barBtnThem.Enabled = barBtnSua.Enabled = barBtnXoa.Enabled = barBtnLammoi.Enabled = barBtnThoat.Enabled = false;
            barBtnGhi.Enabled = barBtnPhuchoi.Enabled = true;
            LopGridControl.Enabled = false;
            cmbKhoa.Enabled = false;
        }

        private void barBtnLammoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.lopTableAdapter.Fill(this.DS.LOP);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void barBtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsSV.Count > 0)
            {
                MessageBox.Show("Không thể xóa lớp này vì Lớp đã có sinh viên.", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thực sự muốn xóa Lớp này??", "Xác nhận.", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    bdsLop.RemoveCurrent();
                    this.lopTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.lopTableAdapter.Update(this.DS.LOP);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa Lớp.\nBạn hãy xóa lại\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.lopTableAdapter.Fill(this.DS.LOP);
                    return;
                }
            }
            if (bdsLop.Count == 0) barBtnXoa.Enabled = false;
            barBtnLammoi.Enabled = true;
            if (position > 0)
            {
                bdsLop.Position = position;
            }
        }

        private void barBtnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool check = this.validateInput();
            if (check)
            {
                DialogResult confirm = MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào Database?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (confirm == DialogResult.OK)
                {
                    try
                    {
                        bdsLop.EndEdit();
                        bdsLop.ResetCurrentItem();
                        //Console.WriteLine("hello");
                        this.lopTableAdapter.Connection.ConnectionString = Program.connstr;
                        lopTableAdapter.Update(this.DS.LOP);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ghi dữ liệu thất lại. Vui lòng kiểm tra lại!\n" + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    barBtnThem.Enabled = barBtnSua.Enabled = barBtnXoa.Enabled = barBtnLammoi.Enabled = barBtnThoat.Enabled = true;
                    barBtnGhi.Enabled = barBtnPhuchoi.Enabled = false;
                    cmbKhoa.Enabled = true;
                    LopGridControl.Enabled = true;
                    option = "";
                }
            }
            else return;

            if (position > 0) bdsLop.Position = position;
        }

        private void barBtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
