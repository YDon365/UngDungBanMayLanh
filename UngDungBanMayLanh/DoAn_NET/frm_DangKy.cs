using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace DoAn_NET
{
    public partial class frm_DangKy : Form
    {
        public frm_DangKy()
        {
            InitializeComponent();
        }

        class_KHACHHANG kh = new class_KHACHHANG();

        //kiểm tra email
        public static bool is_Email(string email)
        {
            email = email ?? string.Empty;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(email))
                return true;
            else
                return false;
        }

        //Kiểm tra ngày tháng chọn có vượt qua ngày hiện tại
        public bool is_Ngay(DateTime iDate)
        {
            if (iDate >= DateTime.Today)
                return false;
            return true;
        }

        private void btTiepTheo_Click(object sender, EventArgs e)
        {
            try
            {


                if (txtTenDN.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập tên tài khoản");
                    txtTenDN.Select();
                    return;
                }
                if (txtMK.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu");
                    txtMK.Select();
                    return;
                }
                if (txtResetMK.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập Reset lại mật khẩu");
                    txtResetMK.Select();
                    return;
                }

                //kiểm tra mật khẩu nhập với reset mật khẩu có = nhau
                if (txtResetMK.Text != txtMK.Text)
                {
                    MessageBox.Show("Bạn nhập sai Reset mật khẩu");
                    txtResetMK.Select();
                    txtResetMK.Clear();
                    return;
                }
                if (kh.is_KH(txtTenDN.Text) == 1)
                {
                    MessageBox.Show("Đã tồn tại tên tài khoản đó", "Thông báo");
                    txtTenDN.Select();
                    return;
                }
                //
                bunifuPages1.SelectTab("tab2");
            }
            catch
            {
                MessageBox.Show("Hệ thống lỗi");
            }
        }

        string hinh = string.Empty;
        
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            //chỉ được nhập số
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                //kiểm tra dữ liệu nhập
                if (txtHoTen.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập họ tên");
                    txtHoTen.Select();
                    return;
                }
                if (txtSDT.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập số điện thoại");
                    txtSDT.Select();
                    return;
                }
                if (txtDiaChi.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập Đại chỉ");
                    txtDiaChi.Select();
                    return;
                }
                if (txtEmail.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập Email");
                    txtEmail.Select();
                    return;
                }

                //lấy string ngày sinh
                DateTime iDate = date_NgaySinh.Value;
                if (!is_Ngay(iDate))
                {
                    MessageBox.Show("Vui lòng chọn lại ngày sinh. làm sao bạn sinh ở tường lại được");
                    return;
                }
                string ngaySinh = kh.chuyenNgaySinh(iDate);

                //kiểm tra dữ liệu email
                if (!is_Email(txtEmail.Text))
                {
                    MessageBox.Show("Bạn nhập sai email");
                    txtEmail.Select();
                    return;
                }

                //lấy giới tính
                string gioiTinh = string.Empty;
                if (rdNam.Checked == true)
                    gioiTinh = "Nam";
                if (rdNu.Checked == true)
                    gioiTinh = "Nữ";



                if (kh.insert(txtTenDN.Text, txtMK.Text, txtHoTen.Text, txtSDT.Text, txtDiaChi.Text, ngaySinh, txtEmail.Text, gioiTinh, this.hinh))
                {

                    MessageBox.Show("Đăng ký thành công");
                    //đang lỗi ở đây
                    frm_DangNhap d = new frm_DangNhap();
                    d.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Đăng ký thất bại");
            }
            catch
            {
                MessageBox.Show("Hệ thống lỗi");
            }
        }

        private void btUpdateHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog opne = new OpenFileDialog();
            if (opne.ShowDialog() == DialogResult.OK)
            {
                string link = string.Empty;
                pic_HinhKH.Image = Image.FromFile(opne.FileName);
                link = opne.FileName;

                //lấy tên hinh ảnh. bỏ đường dẫn
                string[] ten = link.Trim().Split('\\');//lấy tên hình

                this.hinh = ten[ten.Count() - 1];//gán hinh=tên hình vừa lấy
            }
        }

        private void btHome_Click(object sender, EventArgs e)
        {
            frmMain f = new frmMain();
            f.Show();
            this.Hide();
        }




    }
}
