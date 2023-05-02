using System;
using System.Windows.Forms;

namespace qldsv
{
    public partial class Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Main()
        {
            InitializeComponent();
            this.rpgTaoLogin.Visible = false;
            this.IsMdiContainer = true;
        }

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Console.WriteLine("trigger");
            Form frm = this.CheckExists(typeof(DangNhap));
            if (frm != null) frm.Activate();
            else
            {
                DangNhap f = new DangNhap();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void TaoLoginClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(TaoLogin));
            if (frm != null) frm.Activate();
            else
            {
                TaoLogin f = new TaoLogin();
                f.Visible = false;
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barBtnLop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(Lop));
            if (frm != null) frm.Activate();
            else
            {
                Lop f = new Lop();
                f.Visible = false;
                f.MdiParent = this;
                f.Show();
            }

        }

        private void barBtnSV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(SinhVien));
            if (frm != null) frm.Activate();
            else
            {
                SinhVien f = new SinhVien();
                f.Visible = false;
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barBtnMonHoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(MonHoc));
            if (frm != null) frm.Activate();
            else
            {
                MonHoc f = new MonHoc();
                f.Visible = false;
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}
