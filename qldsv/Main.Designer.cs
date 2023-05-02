
namespace qldsv
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnLop = new DevExpress.XtraBars.BarButtonItem();
            this.btnTaoLogin = new DevExpress.XtraBars.BarButtonItem();
            this.btnTaoDangNhap = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSV = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgTaoLogin = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMAGV = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblHOTEN = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNHOM = new System.Windows.Forms.ToolStripStatusLabel();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barBtnMonHoc = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.barButtonItem1,
            this.barBtnLop,
            this.btnTaoLogin,
            this.btnTaoDangNhap,
            this.barBtnSV,
            this.barBtnMonHoc});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 7;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
            this.ribbonControl1.Size = new System.Drawing.Size(758, 158);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Đăng nhập";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barBtnLop
            // 
            this.barBtnLop.Caption = "Lớp";
            this.barBtnLop.Id = 2;
            this.barBtnLop.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barBtnLop.ImageOptions.SvgImage")));
            this.barBtnLop.Name = "barBtnLop";
            this.barBtnLop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnLop_ItemClick);
            // 
            // btnTaoLogin
            // 
            this.btnTaoLogin.Caption = "Tạo Login";
            this.btnTaoLogin.Id = 3;
            this.btnTaoLogin.Name = "btnTaoLogin";
            // 
            // btnTaoDangNhap
            // 
            this.btnTaoDangNhap.Caption = "Tạo Login";
            this.btnTaoDangNhap.Id = 4;
            this.btnTaoDangNhap.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTaoDangNhap.ImageOptions.SvgImage")));
            this.btnTaoDangNhap.Name = "btnTaoDangNhap";
            this.btnTaoDangNhap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.TaoLoginClick);
            // 
            // barBtnSV
            // 
            this.barBtnSV.Caption = "Sinh viên";
            this.barBtnSV.Id = 5;
            this.barBtnSV.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barBtnSV.ImageOptions.SvgImage")));
            this.barBtnSV.Name = "barBtnSV";
            this.barBtnSV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSV_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.rpgTaoLogin});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Hệ thống";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // rpgTaoLogin
            // 
            this.rpgTaoLogin.ItemLinks.Add(this.btnTaoDangNhap);
            this.rpgTaoLogin.Name = "rpgTaoLogin";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Quản trị";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barBtnLop);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barBtnSV);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMAGV,
            this.lblHOTEN,
            this.lblNHOM});
            this.statusStrip1.Location = new System.Drawing.Point(0, 461);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(758, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblMAGV
            // 
            this.lblMAGV.Name = "lblMAGV";
            this.lblMAGV.Size = new System.Drawing.Size(41, 17);
            this.lblMAGV.Text = "MAGV";
            // 
            // lblHOTEN
            // 
            this.lblHOTEN.Name = "lblHOTEN";
            this.lblHOTEN.Size = new System.Drawing.Size(45, 17);
            this.lblHOTEN.Text = "HOTEN";
            // 
            // lblNHOM
            // 
            this.lblNHOM.Name = "lblNHOM";
            this.lblNHOM.Size = new System.Drawing.Size(45, 17);
            this.lblNHOM.Text = "NHOM";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.barBtnMonHoc);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // barBtnMonHoc
            // 
            this.barBtnMonHoc.Caption = "Môn học";
            this.barBtnMonHoc.Id = 6;
            this.barBtnMonHoc.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barBtnMonHoc.ImageOptions.SvgImage")));
            this.barBtnMonHoc.Name = "barBtnMonHoc";
            this.barBtnMonHoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnMonHoc_ItemClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 483);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "Main";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel lblMAGV;
        public System.Windows.Forms.ToolStripStatusLabel lblHOTEN;
        public System.Windows.Forms.ToolStripStatusLabel lblNHOM;
        public DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgTaoLogin;
        private DevExpress.XtraBars.BarButtonItem barBtnLop;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnTaoLogin;
        private DevExpress.XtraBars.BarButtonItem btnTaoDangNhap;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarButtonItem barBtnSV;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem barBtnMonHoc;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
    }
}

