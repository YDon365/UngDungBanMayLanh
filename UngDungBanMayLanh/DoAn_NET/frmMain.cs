using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DoAn_NET
{
    public partial class frmMain : Form
    {
     
        string _tenDN, _mk,_hoTen,_sdt,_diaChi,_ngaySinh,_email,_gioiTinh,_hinhKH;
        int _quyen;

        public frmMain()
        {
            InitializeComponent();
            Pane_TenKH.Visible = false;
            Pic_AnhKH.Visible = false;
            btDangXuat.Visible = false;
            btThoat.Visible = false;

            this.panelChinh.Controls.Clear();
            frm_Home frm2 = new frm_Home();
            frm2.TopLevel = false;
            panelChinh.Controls.Add(frm2);
            frm2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm2.Dock = DockStyle.Fill;
            frm2.Show();
           
        }

        public frmMain(string tenDN, string mk, string hoTen, string sdt, string diaChi, string ngaySinh, string email, string gioiTinh, string hinh)
        {
            InitializeComponent();
            try
            {
                xuLy_DangNhap();

                this._tenDN = tenDN;
                this._mk = mk;
                this._hoTen = hoTen;
                this._sdt = sdt;
                this._diaChi = diaChi;
                this._ngaySinh = ngaySinh;
                this._email = email;
                this._gioiTinh = gioiTinh;
                this._hinhKH = hinh;
                string link = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                if (this._hinhKH != string.Empty)
                    Pic_AnhKH.Image = Image.FromFile(link + @"\\hinh\\" + _hinhKH);
                lbTenKH.Text = hoTen;

                this.panelChinh.Controls.Clear();
                frm_Home frm2 = new frm_Home();
                frm2.TopLevel = false;
                panelChinh.Controls.Add(frm2);
                frm2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm2.Dock = DockStyle.Fill;
                frm2.Show();
            }
            catch
            {
                MessageBox.Show("Hệ thống lỗi");
            }


        }

        public frmMain(string tenDN, string mk, int quyen)
        {
            InitializeComponent();
            try
            {
                xuLy_DangNhap();

                this._tenDN = tenDN;
                this._mk = mk;
                this._quyen = quyen;

                lbTenKH.Text = tenDN;
                this.panelChinh.Controls.Clear();
                frm_Home frm2 = new frm_Home();
                frm2.TopLevel = false;
                panelChinh.Controls.Add(frm2);
                frm2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm2.Dock = DockStyle.Fill;
                frm2.Show();
            }
            catch
            {
                MessageBox.Show("Hệ thống lỗi");
            }
        }

        class_KHACHHANG kh = new class_KHACHHANG();
     
        private void bnfbt_DangNhap_Click(object sender, EventArgs e)
        {         
            frm_DangNhap dn = new frm_DangNhap();
            dn.Show();
            this.Hide();
        }

        private void btHome_Click(object sender, EventArgs e)
        {
            try
            {


                this.panelChinh.Controls.Clear();
                frm_Home frm2 = new frm_Home();
                frm2.TopLevel = false;
                panelChinh.Controls.Add(frm2);
                frm2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm2.Dock = DockStyle.Fill;
                frm2.Show();
            }
            catch
            {
                MessageBox.Show("Hệ thống lỗi");
            }
        }

        private void btThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbTenKH.Text.Length == 0)
                {
                    frm_DangNhap dn = new frm_DangNhap();
                    dn.Show();
                    this.Hide();
                }

                if (lbTenKH.Text.Length > 0)
                {
                    if (lbTenKH.Text.Trim().Replace(" ", "") != "admin" && lbTenKH.Text.Trim().Replace(" ", "") != "nv1" && lbTenKH.Text.Trim().Replace(" ", "") != "nv2")
                    {
                        btGioHang_Click(sender, e);
                    }
                    else
                    {
                        this.panelChinh.Controls.Clear();
                        frm_ThongKe frm2 = new frm_ThongKe();
                        frm2.TopLevel = false;
                        panelChinh.Controls.Add(frm2);
                        frm2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                        frm2.Dock = DockStyle.Fill;
                        frm2.Show();
                    }

                }
            }
            catch
            {
                MessageBox.Show("Hệ thống lỗi");
            }
        }

        private void btTuVan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nếu bạn có thắc mắc vui lòng liên hệ: 0392630204", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void btCaiDat_Click(object sender, EventArgs e)
        {
            if(panelMenuChinh.Width==100)
            {
                update_WithMenu();
            }
            if(lbTenKH.Text.Length>0)
            {
                if (lbTenKH.Text.Length>1 &&btDangXuat.Visible == false)
                    btDangXuat.Visible = true;
                else
                    btDangXuat.Visible = false;
            }
            

            if (btThoat.Visible == false)
                btThoat.Visible = true;
            else
                btThoat.Visible = false;
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn có chắc là muốn thoát ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (dl == DialogResult.Yes)
                this.Close();
        }
        
        private void btGioHang_Click(object sender, EventArgs e)
        {
            try
            {
                string tenDN, mk, hoTen, sdt, diaChi, ngaySinh, email, gioiTinh, hinh;
                tenDN = this._tenDN;
                mk = this._mk;
                hoTen = this._hoTen;
                sdt = this._sdt;
                diaChi = this._diaChi;
                ngaySinh = this._ngaySinh;
                email = this._email;
                gioiTinh = this._gioiTinh;
                hinh = this._hinhKH;

                this.panelChinh.Controls.Clear();
                if (lbTenKH.Text.Length == 0)
                {
                    frm_DangNhap dn = new frm_DangNhap();
                    dn.Show();
                    this.Hide();
                }

                if (lbTenKH.Text.Length > 0)
                {
                    if (lbTenKH.Text.Replace(" ", "") != "admin" && lbTenKH.Text.Replace(" ", "") != "nv1" && lbTenKH.Text.Replace(" ", "") != "nv2")
                    {
                        frm_KhachHang frm2 = new frm_KhachHang(tenDN, mk, hoTen, sdt, diaChi, ngaySinh, email, gioiTinh, hinh);
                        frm2.TopLevel = false;
                        panelChinh.Controls.Add(frm2);
                        frm2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                        frm2.Dock = DockStyle.Fill;
                        frm2.Show();
                    }
                    else
                    {
                        this.panelChinh.Controls.Clear();
                        frm_ThongKe frm2 = new frm_ThongKe();
                        frm2.TopLevel = false;
                        panelChinh.Controls.Add(frm2);
                        frm2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                        frm2.Dock = DockStyle.Fill;
                        frm2.Show();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Hệ thống lỗi");
            }
            
                 
              
        }

        private void btMenu_Click_1(object sender, EventArgs e)
        {
            update_WithMenu();
        }

        private void bt_DangKy_Click(object sender, EventArgs e)
        {
            frm_DangKy dn = new frm_DangKy();
            dn.Show();
            this.Hide();
           
        }

        private void linkChungToi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Thành viên: Y Don Rbăm 2001190776 \nHuỳnh Lê Công Thành 2001190815\nEmail: maylanhvip@gmail.com\nSĐT: 012346789\nĐịa chỉ: 55T Trường Chinh, Tây Thạnh, Tân Phú");
        }

        private void btDangXuat_Click(object sender, EventArgs e)
        {
            btHome_Click(sender, e);

            Pane_TenKH.Visible = false;
            Pic_AnhKH.Visible = false;
            btDangXuat.Visible = false;
            btThoat.Visible = false;
            bt_DangKy.Visible = true;
            bt_DangNhap.Visible = true;
            lbTenKH.Text = "";
            this._tenDN = "";
            this._mk = "";
            this._hoTen = "";
            this._sdt = "";
            this._diaChi = "";
            this._ngaySinh = "";
            this._email = "";
            this._gioiTinh = "";
            this._hinhKH = "";
        }

        private void Pic_AnhKH_Click(object sender, EventArgs e)
        {
            if (this._tenDN.Replace(" ", "") != "admin" && this._tenDN.Replace(" ", "") != "nv2" && this._tenDN.Replace(" ", "") != "nv1")
                btGioHang_Click(sender, e);
        }

        private void Pane_TenKH_Click(object sender, EventArgs e)
        {
            if (this._tenDN.Replace(" ", "") != "admin" && this._tenDN.Replace(" ", "") != "nv2" && this._tenDN.Replace(" ", "") != "nv1")
                btGioHang_Click(sender, e);
        }
        public void xuLy_DangNhap()
        {
            Pic_AnhKH.Width = 68;
            Pane_TenKH.Width = 200;
            Pane_TenKH.Visible = true;
            Pic_AnhKH.Visible = true;
            bt_DangKy.Visible = false;
            bt_DangNhap.Visible = false;

        }
        public void update_WithMenu()
        {
            if (panelMenuChinh.Width == 194)
            {
                panelMenuChinh.Width = 100;
                btCaiDat.Width = 100;
                btGioHang.Width = 100;
                btHome.Width = 100;
                btSanPham.Width = 100;
                btTuVan.Width = 100;
                btThongKe.Width = 100;
                btMenu.Width = 100;

                btMenu.Text = "";
                btCaiDat.Text = "";
                btGioHang.Text = "";
                btHome.Text = "";
                btSanPham.Text = "";
                btTuVan.Text = "";
                btThongKe.Text = "";
                btThoat.Visible = false;
                btDangXuat.Visible = false;
                linkChungToi.Location = new Point(7, 499);
            }
            else
            {
                panelMenuChinh.Width = 194;
                btCaiDat.Width = 180;
                btGioHang.Width = 180;
                btHome.Width = 180;
                btSanPham.Width = 180;
                btTuVan.Width = 180;
                btThongKe.Width = 180;
                btMenu.Width = 180;

                btMenu.Text = "Menu";
                btCaiDat.Text = "Cài đặt";
                btGioHang.Text = "Giỏ hàng";
                btHome.Text = "Home";
                btSanPham.Text = "Sản phẩm";
                btTuVan.Text = "Tư vấn";
                btThongKe.Text = "Thống kề";
                linkChungToi.Location = new Point(42, 499);
            }
        }

        private void btSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                this.panelChinh.Controls.Clear();
                if (this._tenDN == null)
                {
                    frm_SANPHAM frm2 = new frm_SANPHAM();
                    frm2.TopLevel = false;
                    panelChinh.Controls.Add(frm2);
                    frm2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    frm2.Dock = DockStyle.Fill;
                    frm2.Show();
                }
                else
                {
                    frm_SANPHAM frm2 = new frm_SANPHAM(this._tenDN.Replace(" ", ""), "");
                    frm2.TopLevel = false;
                    panelChinh.Controls.Add(frm2);
                    frm2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    frm2.Dock = DockStyle.Fill;
                    frm2.Show();
                }
            }
            catch
            {
                MessageBox.Show("Hệ thống lỗi");
            }
            
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                this.panelChinh.Controls.Clear();
                if (this._tenDN == null)
                {
                    frm_SANPHAM frm2 = new frm_SANPHAM(txtTimKiem.Text);
                    frm2.TopLevel = false;
                    panelChinh.Controls.Add(frm2);
                    frm2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    frm2.Dock = DockStyle.Fill;
                    frm2.Show();
                }
                else
                {
                    frm_SANPHAM frm2 = new frm_SANPHAM(this._tenDN.Replace(" ", ""), txtTimKiem.Text);
                    frm2.TopLevel = false;
                    panelChinh.Controls.Add(frm2);
                    frm2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    frm2.Dock = DockStyle.Fill;
                    frm2.Show();
                }
            }
            catch
            {
                MessageBox.Show("Hệ thống lỗi");
            }
        }

   
  
    }
}
