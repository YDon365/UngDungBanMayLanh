using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_NET
{
    public partial class frm_DangNhap : Form
    {
        public frm_DangNhap()
        {
            InitializeComponent();
        }

        class_KHACHHANG kh = new class_KHACHHANG();
        class_QUANLY ql = new class_QUANLY();
        private void btDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                //kiểm tra dữ liệu nhập
                if (txtTenDN.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập");
                    txtTenDN.Select();
                    return;
                }

                if (txtMatKhauDN.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu");
                    txtMatKhauDN.Select();
                    return;
                }
                //kiểm tra đúng sai
                if (kh.is_DangNhap(txtTenDN.Text, txtMatKhauDN.Text) == 0 && ql.is_DangNhap(txtTenDN.Text, txtMatKhauDN.Text) == 0)
                {
                    MessageBox.Show("sai tài khoản hoặc mật khẩu");
                    txtTenDN.Select();
                    return;
                }
                if (kh.is_DangNhap(txtTenDN.Text, txtMatKhauDN.Text) == -1)
                {
                    MessageBox.Show("đăng nhập thật bại");
                    txtTenDN.Select();
                    return;
                }



                if (kh.is_DangNhap(txtTenDN.Text, txtMatKhauDN.Text) == 1)
                {
                    List<class_KHACHHANG> dt = kh.load_TimKiem_TenDN(txtTenDN.Text);
                    MessageBox.Show("đăng nhập thành công");
                    this.Hide();
                    string tenDN = string.Empty;
                    string mk = string.Empty;
                    string hoTen = string.Empty;
                    string sdt = string.Empty;
                    string diaChi = string.Empty;
                    string ngaySinh = string.Empty;
                    string email = string.Empty;
                    string gioiTinh = string.Empty;
                    string hinh = string.Empty;
                    foreach (class_KHACHHANG item in dt)
                    {
                        tenDN = item._tenDN;
                        mk = item._matKhau;
                        hoTen = item._hoTen;
                        sdt = item._sdt;
                        diaChi = item._diaChi;
                        ngaySinh = item._ngaySinh;
                        email = item._email;
                        gioiTinh = item._gioiTinh;
                        hinh = item._hinhKH;
                    }
                    frmMain f = new frmMain(tenDN, mk, hoTen, sdt, diaChi, ngaySinh, email, gioiTinh, hinh);
                    f.Show();
                }

                if (ql.is_DangNhap(txtTenDN.Text, txtMatKhauDN.Text) == 1)
                {
                    List<class_QUANLY> dt1 = ql.load_TimKiem(txtTenDN.Text);
                    MessageBox.Show("đăng nhập thành công");
                    this.Hide();
                    string tenDN1 = string.Empty;
                    string mk1 = string.Empty;
                    int quyen = 1;
                    foreach (class_QUANLY item in dt1)
                    {
                        tenDN1 = item._tenDN;
                        mk1 = item._matKhau;
                        quyen = item._quyen;
                    }
                    frmMain f = new frmMain(tenDN1, mk1, quyen);
                    f.Show();
                }
            }
            catch
            {
                MessageBox.Show("Hệ thống lỗi");
            }
        }

        private void linkDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmMain f = new frmMain();
            f.Show();
        }

        private void linkHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmMain f = new frmMain();
            f.Show();
        }

        private void linkQuenMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Liên hệ với chủ shop: 0392630204");
        }
    }
}
