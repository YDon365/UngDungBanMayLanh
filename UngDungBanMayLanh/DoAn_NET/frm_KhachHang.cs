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
using System.Text.RegularExpressions;

namespace DoAn_NET
{
    public partial class frm_KhachHang : Form
    {

        string _tenDN, _mk, _hoTen, _sdt, _diaChi, _ngaySinh, _email, _gioiTinh, _hinhKH;
        string hinh;
        int tongTienDaMua = 0;
        int tongSLMua = 0;
        public frm_KhachHang()
        {
            InitializeComponent();
            bunifuPages1.SelectTab("tabDonHang");
            datepicNgaySinh.Value = DateTime.Today;
            
        }

        private void frm_KhachHang_Load(object sender, EventArgs e)
        {
            try
            {
                bunifuPages1.SelectTab("tabDonHang");
                datepicNgaySinh.Value = DateTime.Today;
                List<class_KHACHHANG> dsKH = kh.load_TimKiem_TenDN(this._tenDN);
                string ah = string.Empty;
                foreach (class_KHACHHANG item in dsKH)
                {
                    ah = "trang.jpg";
                    if (item._hinhKH != "")//kiểm tra xem hình có rỗng k
                        ah = item._hinhKH;
                    this._tenDN = item._tenDN.Replace(" ", "");
                    this._mk = item._matKhau.Replace(" ", "");
                    this._hoTen = item._hoTen;
                    this._sdt = item._sdt.Replace(" ", "");
                    this._diaChi = item._diaChi;
                    string[] catNgay = item._ngaySinh.Trim().Split(' ');
                    this._ngaySinh = catNgay[0];
                    this._email = item._email.Replace(" ", "");
                    this._gioiTinh = item._gioiTinh.Replace(" ", "");
                    this._hinhKH = ah;
                }

                string link = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                if (this._hinhKH != string.Empty)
                    picHinhKH.Image = Image.FromFile(link + @"\\hinh\\" + _hinhKH);
                lbTenDN.Text = this._tenDN;
                lbEmail.Text = this._email;
                lbGioiTinh.Text = this._gioiTinh;
                lbHoTen.Text = this._hoTen;
                lbNgaySinh.Text = this._ngaySinh;
                lbSDT.Text = this._sdt;
                txtDiaChi.Text = this._diaChi;
                string ten = this._tenDN;
                data_Mua.Rows.Clear();
                List<class_GIOHANG_SP_HD> dsDonMua = donMua.load_tenDN(ten);
                int tong = 0;
                int dem = 0;
                string a = string.Empty;
                foreach (class_GIOHANG_SP_HD item in dsDonMua)
                {
                    dem++;
                    tong += item._tong;
                    a = "trang.jpg";
                    if (item._hinhSP != "")//kiểm tra xem hình có rỗng k
                        a = item._hinhSP;
                    Image hinh1 = Image.FromFile(link + @"\hinh\" + a);
                    hinh1 = resizeImage(hinh1, new Size(70, 40));
                    data_Mua.Rows.Add(item._stt.ToString(), item._MaSP, item._tenSP, item._slGH, item._gia, item._tong, item._ngayLap, hinh1);
                }
                tongTienDaMua = tong;
                tongSLMua = dem;
                lbTongTienMua.Text = tong + " VNĐ";
            }
            catch
            {
                MessageBox.Show("Hệ thống lỗi");
            }
        }

        public frm_KhachHang(string tenDN, string mk, string hoTen, string sdt, string diaChi, string ngaySinh, string email, string gioiTinh, string hinh)
        {

            InitializeComponent();
            try
            {
                bunifuPages1.SelectTab("tabDonHang");
                datepicNgaySinh.Value = DateTime.Today;

                this._tenDN = tenDN.Replace(" ","");
                this._mk = mk.Replace(" ", "");
                this._hoTen = hoTen;
                this._sdt = sdt.Replace(" ", "");
                this._diaChi = diaChi;
                string[] catNgay = ngaySinh.Trim().Split(' ');
                this._ngaySinh = catNgay[0];
                this._email = email.Replace(" ", "");
                this._gioiTinh = gioiTinh.Replace(" ", "");

                List<class_KHACHHANG> dsKH = kh.load_TimKiem_TenDN(this._tenDN);
                string ah = string.Empty;
                foreach (class_KHACHHANG item in dsKH)
                {
                    ah = "trang.jpg";
                    if (item._hinhKH != "")//kiểm tra xem hình có rỗng k
                        ah = item._hinhKH;
                }
                this._hinhKH = ah;


                string link = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                if (this._hinhKH != string.Empty)
                    picHinhKH.Image = Image.FromFile(link + @"\\hinh\\" + _hinhKH);



                lbTenDN.Text = this._tenDN;
                lbEmail.Text = this._email;
                lbGioiTinh.Text = this._gioiTinh;
                lbHoTen.Text = this._hoTen;
                lbNgaySinh.Text = this._ngaySinh;
                lbSDT.Text = this._sdt;
                txtDiaChi.Text = this._diaChi;
                string ten = tenDN.Replace(" ", "");
                data_Mua.Rows.Clear();
                List<class_GIOHANG_SP_HD> dsDonMua = donMua.load_tenDN(ten);
                int tong = 0;
                int dem = 0;
                string a = string.Empty;
                foreach (class_GIOHANG_SP_HD item in dsDonMua)
                {
                    dem++;
                    tong += item._tong;
                    a = "trang.jpg";
                    if (item._hinhSP != "")//kiểm tra xem hình có rỗng k
                        a = item._hinhSP;
                    Image hinh1 = Image.FromFile(link + @"\hinh\" + a);
                    hinh1 = resizeImage(hinh1, new Size(70, 40));
                    data_Mua.Rows.Add(item._stt.ToString(), item._MaSP, item._tenSP, item._slGH, item._gia, item._tong, item._ngayLap, hinh1);
                }
                tongTienDaMua = tong;
                tongSLMua = dem;
                lbTongTienMua.Text = tong + " VNĐ";
            }
            catch
            {
                MessageBox.Show("Hệ thống lỗi");
            }
        }     

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        class_GioHang gh = new class_GioHang();
        class_KHACHHANG kh = new class_KHACHHANG();
        class_HOADON hd = new class_HOADON();
        class_GIOHANG_SP_HD donMua = new class_GIOHANG_SP_HD();
        class_GH_SP gioHang = new class_GH_SP();
        class_SANPHAM sp = new class_SANPHAM();
        string tenHinh=string.Empty;

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

        private void linkChinhSua_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                txtHoTenSua.Text = this._hoTen;
                txtDiaChiSua.Text = this._diaChi;
                txtEmailSua.Text = this._email;
                txtSDTSua.Text = this._sdt;

                string[] ngayThang1 = this._ngaySinh.Trim().Split(' ');
                string[] ngayThang = ngayThang1[0].Trim().Split('/');
                int d = int.Parse(ngayThang[0].ToString());
                int m = int.Parse(ngayThang[1].ToString());
                int y = int.Parse(ngayThang[2].ToString());
                DateTime dt = new DateTime(y, m, d);
                datepicNgaySinh.Value = dt;
                if (this._gioiTinh == "Nam")
                    rdNam.Checked = true;
                if (this._gioiTinh == "Nữ")
                    rdNu.Checked = true;
                string link = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                if (this._hinhKH != string.Empty)
                    picKHSua.Image = Image.FromFile(link + @"\\hinh\\" + _hinhKH);

                bunifuPages1.SelectTab("tabChinhSua");
            }
            catch
            {
                MessageBox.Show("Lỗi hệ thống");
            }
        }

        private void linkGioHang_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                btMua.Enabled = true;
                pnSua1.Height = 1;
                pnChinh.Height = 1;
                data_gioHang.Rows.Clear();
                string a = this._tenDN.Trim().Replace(" ", "");
                List<class_GH_SP> dsgioHang = gioHang.load_tenDN(a);
                string link = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                int tong = 0;
                string aa = string.Empty;
                foreach (class_GH_SP item in dsgioHang)
                {
                    tong += item._tong;
                    aa = "trang.jpg";
                    if (item._hinhSP != "")
                        aa = item._hinhSP;
                    Image hinh1 = Image.FromFile(link + @"\hinh\" + aa);
                    hinh1 = resizeImage(hinh1, new Size(70, 40));
                    data_gioHang.Rows.Add(item._stt.ToString(), item._MaSP, item._tenSP, hinh1, item._slGH, item._gia, item._tong);
                }
                lbTongTienGH.Text = tong + " VNĐ";
                if (tong == 0)
                    btMua.Enabled = false;
                bunifuPages1.SelectTab("tabGioHang");
            }
            catch
            {
                MessageBox.Show("Lỗi hệ thống");
            }

        }

        private void linkDonHang_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {   
            try
            {
                data_Mua.Rows.Clear();
                string link = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                List<class_GIOHANG_SP_HD> dsDonMua = donMua.load_tenDN(this._tenDN.Replace(" ", ""));
                int tong = 0;
                int dem = 0;
                string a = string.Empty;
                foreach (class_GIOHANG_SP_HD item in dsDonMua)
                {
                    dem++;
                    tong += item._tong;
                    a = "trang.jpg";
                    if (item._hinhSP != "")//kiểm tra xem hình có rỗng k
                        a = item._hinhSP;
                    Image hinh1 = Image.FromFile(link + @"\hinh\" + a);
                    hinh1 = resizeImage(hinh1, new Size(70, 40));
                    data_Mua.Rows.Add(item._stt.ToString(), item._MaSP, item._tenSP, item._slGH, item._gia, item._tong, item._ngayLap, hinh1);
                }
                tongTienDaMua = tong;
                lbTongTienMua.Text = tong+ " NVĐ";
                bunifuPages1.SelectTab("tabDonHang");
            }
            catch
            {
                MessageBox.Show("Hệ thống lỗi");
            }
        }

        private void linkThongKe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                //gio hang
                data_gioHang.Rows.Clear();
                string a = this._tenDN.Trim().Replace(" ", "");
                List<class_GH_SP> dsgioHang = gioHang.load_tenDN(a);
                string link = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                int tong = 0;
                string aa = string.Empty;
                int d1 = 0;
                foreach (class_GH_SP item in dsgioHang)
                {
                    d1++;
                    tong += item._tong;
                }

                //hoa don
                List<class_GIOHANG_SP_HD> dsDonMua = donMua.load_tenDN(this._tenDN.Replace(" ", ""));
                int tong1 = 0;
                int dem1 = 0;
                foreach (class_GIOHANG_SP_HD item in dsDonMua)
                {
                    dem1++;
                    tong1 += item._tong;
                }
                ////////////////////////

                int dem = gh.dem_GH_Ten(this._tenDN.Replace(" ", ""));
                cire_TongCho.Value = d1;
                cire_TongMua.Value = dem1;//tongSLMua;
                lbTongTien.Text = tong1+" VNĐ";//tongTienDaMua + " VNĐ";
                bunifuPages1.SelectTab("tabThongKe");
            }
            catch
            {
                MessageBox.Show("Hệ thống lỗi");
            }
        }

        private void linkDoiMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bunifuPages1.SelectTab("tabDoiMK");
        }
        
        private void btUpdateHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog opne = new OpenFileDialog();
            if (opne.ShowDialog() == DialogResult.OK)
            {
                string link = string.Empty;
                picKHSua.Image = Image.FromFile(opne.FileName);
                link = opne.FileName;

                //lấy tên hinh ảnh. bỏ đường dẫn
                string[] ten = link.Trim().Split('\\');//lấy tên hình

                this.hinh = ten[ten.Count() - 1];//gán hinh=tên hình vừa lấy
            }
        }

        private void btLuuThayDoi_Click(object sender, EventArgs e)
        {
            try
            {
                //kiểm tra nhập liệu
                if (txtMK_Cu.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu cũ");
                    txtMK_Cu.Select();
                    return;
                }
                if (txtMK_Moi.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu mới");
                    txtMK_Moi.Select();
                    return;
                }
                if (txtMK_Reset.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập reset mật khẩu mới");
                    txtMK_Reset.Select();
                    return;
                }

                //kiểm tra mật khẩu có đúng hay k
                if (kh.is_DangNhap(lbTenDN.Text, txtMK_Cu.Text) == 0)
                {
                    MessageBox.Show("Sai mật khẩu cũ");
                    txtMK_Cu.Select();
                    return;
                }
                if (kh.is_DangNhap(lbTenDN.Text, txtMK_Cu.Text) == -1)
                {
                    MessageBox.Show("lỗi");
                    txtMK_Cu.Select();
                    return;
                }

                //kiểm tra mật khẩu mới có giống nhau k
                if (txtMK_Moi.Text != txtMK_Reset.Text)
                {
                    MessageBox.Show("Reset mật khẩu mới sai");
                    txtMK_Reset.Select();
                    return;
                }

                
                //update
                if (kh.update(this._tenDN.Replace(" ",""), txtMK_Moi.Text, this._hoTen, this._sdt, this._diaChi, this._ngaySinh, this._email, this._gioiTinh, this._hinhKH))
                {
                    this._mk = txtMK_Moi.Text.Replace(" ", "");
                    MessageBox.Show("Thay đổi thành công");
                }                  
                else
                    MessageBox.Show("Thất bại");

            }
            catch
            {
                MessageBox.Show("Lỗi hệ thống");
            }
            
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            try
            {
                //kiểm tra dữ liệu nhập
                if (txtHoTenSua.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập họ và tên ");
                    txtHoTenSua.Select();
                    return;
                }
                if (txtEmailSua.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập Email");
                    txtEmailSua.Select();
                    return;
                }
                if (txtDiaChiSua.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập Địa chỉ");
                    txtDiaChiSua.Select();
                    return;
                }
                if (txtSDTSua.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập Số điện thoại");
                    txtSDTSua.Select();
                    return;
                }
                //kiểm tra xem khách hàng muốn sửa cái j
                //địa chỉ

                //email

                if (!is_Email(txtEmailSua.Text.Trim()))
                {
                    MessageBox.Show("Bạn nhập sai Email");
                    txtEmailSua.Select();
                    return;
                }
                //ngày sinh
                DateTime iDate = datepicNgaySinh.Value;
                if (iDate == DateTime.Today)
                {
                    MessageBox.Show("Vui lòng chọn lại ngày sinh. làm sao bạn sinh ở tường lại được");
                    return;
                }
                string ngaySinh = kh.chuyenNgaySinh(iDate);

                //giới tính
                string gioiTinh = string.Empty;
                if (rdNam.Checked == true)
                    gioiTinh = "Nam";
                if (rdNu.Checked == true)
                    gioiTinh = "Nữ";

                if (hinh == null || hinh == string.Empty)
                    hinh = this._hinhKH;
                //update           
                if (kh.update(this._tenDN, this._mk, txtHoTenSua.Text, txtSDTSua.Text, txtDiaChiSua.Text, ngaySinh, txtEmailSua.Text, gioiTinh, hinh))
                {
                    frm_KhachHang_Load(sender, e);
                    MessageBox.Show("Sửa Thành công\nLần đăng nhập tiếp theo sẽ hiện thị phần mới sửa");
                }
                else
                    MessageBox.Show("Sửa thất bại");
            }
            catch
            {
                MessageBox.Show("Lỗi hệ thống");
            }
            
            
        }

        private void txtSDTSua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSDT_NhanHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void xoáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string ten = this._tenDN.Replace(" ", "");
                string ma = data_gioHang.CurrentRow.Cells[1].Value.ToString().Replace(" ","");
                string tenSP = data_gioHang.CurrentRow.Cells[2].Value.ToString();
                if(MessageBox.Show("Bạn có chắc là muốn xoá Sản phẩm "+tenSP+" này không","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Stop)==DialogResult.Yes)
                {
                    if (gh.delete_TenDN_maSP(ten, ma))
                    {
                        MessageBox.Show("Xoá thành công");
                        bunifuPages1.SelectTab("tabGioHang");
                        return;
                    }
                    else
                        MessageBox.Show("Xoá thất bại");

                }
            }
            catch
            {
                MessageBox.Show("Lỗi hệ thống");
            }
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pnSua1.Height == 1)
            {
                btMua.Visible = true;
                pnSua1.Height = 119;
                pnChinh.Height = 1;
            }
            else
            {
                btMua.Visible = true;
                pnSua1.Height = 1;
                pnChinh.Height = 1;

            }
        }

        private void btTimGio_Click(object sender, EventArgs e)
        {
            try
            {
                string tim = string.Empty;
                if (txtTimGio.Text.Length == 0)
                    tim = " ";
                else
                    tim = txtTimGio.Text;

                data_gioHang.Rows.Clear();
                pnChinh.Height = 1;
                string a = this._tenDN.Trim().Replace(" ", "");
                List<class_GH_SP> dsgioHang = gioHang.load_tenDN_tenSP(a,tim);
                string link = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                int tong = 0;
                string aa = string.Empty;
                foreach (class_GH_SP item in dsgioHang)
                {

                    tong += item._tong;
                    aa = "trang.jpg";
                    if (item._hinhSP != "")//kiểm tra xem hình có rỗng k
                        aa = item._hinhSP;
                    Image hinh1 = Image.FromFile(link + @"\hinh\" + aa);
                    hinh1 = resizeImage(hinh1, new Size(70, 40));
                    data_gioHang.Rows.Add(item._stt.ToString(), item._MaSP, item._tenSP, hinh1, item._slGH, item._gia, item._tong);
                }
                lbTongTienGH.Text = tong + " VNĐ";
                bunifuPages1.SelectTab("tabGioHang");
            }
            catch
            {
                MessageBox.Show("Lỗi hệ thống");
            }
        }

        private void btTim_Mua_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtTim_Mua.Text.Length==0)
                {
                    MessageBox.Show("Vui lòng nhập tên sản phẩm bạn muốn tìm");
                    txtTim_Mua.Select();
                    return;
                }
                data_Mua.Rows.Clear();
                string a = this._tenDN.Trim().Replace(" ", "");

                List<class_GIOHANG_SP_HD> dsDonMua = donMua.load_tenDN_tenSP(a,txtTim_Mua.Text);
                int tong = 0;
                int dem = 0;
                string aa = string.Empty;
                string link = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                foreach (class_GIOHANG_SP_HD item in dsDonMua)
                {
                    dem++;
                    tong += item._tong;
                    aa = "trang.jpg";
                    if (item._hinhSP != "")//kiểm tra xem hình có rỗng k
                        aa = item._hinhSP;
                    Image hinh1 = Image.FromFile(link + @"\hinh\" + aa);
                    hinh1 = resizeImage(hinh1, new Size(70, 40));
                    data_Mua.Rows.Add(item._stt.ToString(), item._MaSP, item._tenSP, item._slGH, item._gia, item._tong, item._ngayLap, hinh1);
                }
                lbTongTienMua.Text = tong + " VNĐ";
                bunifuPages1.SelectTab("tabDonHang");
            }
            catch
            {
                MessageBox.Show("Lỗi hệ thống");
            }
        }

        private void data_gioHang_SelectionChanged(object sender, EventArgs e)
        {
            txtMaSP_GH.Text = data_gioHang.CurrentRow.Cells[1].Value.ToString().Replace(" ", "");
            txtTenSP_GH.Text = data_gioHang.CurrentRow.Cells[2].Value.ToString();
            txtSL_GH.Text = data_gioHang.CurrentRow.Cells[4].Value.ToString();
        }

        private void btLuu_GH_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSL_GH.Text.Length == 0)
                {
                    MessageBox.Show("Chưa nhập số lượng");
                    txtSL_GH.Select();
                    return;
                }

                if(int.Parse(txtSL_GH.Text)==0)
                {
                    xoáToolStripMenuItem_Click(sender, e);
                    return;
                }

                string ma = data_gioHang.CurrentRow.Cells[1].Value.ToString().Replace(" ", "");
                if (gh.update_NULL(this._tenDN.Replace(" ", ""), ma, int.Parse(txtSL_GH.Text)))
                    MessageBox.Show("Sửa thành công");
                else
                    MessageBox.Show("Sửa thất bại");
                pnSua1.Height = 1;
                btMua.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Lỗi hệ thống");
            }

        }

        private void txtSL_GH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }


        private void btHoanThanh_Click(object sender, EventArgs e)
        {
            try
            {
                pnSua1.Height = 1;
                
                string[] tien = lbTongTienGH.Text.Split(' ');
                int tongTien = int.Parse(tien[0]);

                if(txtDiaChi_NhanHang.Text.Length==0)
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ nhận hàng");
                    return;
                }

                if(txtSDT_NhanHang.Text.Length==0)
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại nhận hàng");
                    return;
                }
                string dc = txtDiaChi_NhanHang.Text;
                string sdt = txtSDT_NhanHang.Text;
                string tt = lbTongTienGH.Text;
                
                DateTime iDate = DateTime.Today;
                string ngay = hd.chuyenNgaySinh(iDate);
                if (hd.insert( ngay,txtDiaChi_NhanHang.Text,txtSDT_NhanHang.Text.Replace(" ",""),tongTien) == false)
                {
                    MessageBox.Show("Lỗi");
                    return;
                }
                
                int maHD = hd.LayMaHD_Max();
                if (MessageBox.Show("Đơn hàng của bạn \n Địa chỉ giao: " + dc + " \n SĐT: " + sdt + " \n Tổng tiền: " + lbTongTienGH.Text + " \n Bạn có chắc muốn mua", "Thông tin đơn hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    List<class_GH_SP> dsgh = gioHang.load_tenDN(this._tenDN.Replace(" ", ""));
                    //kiểm tra số lượng 
                    foreach (class_GH_SP item in dsgh)
                    {
                        List<class_SANPHAM> dssp = sp.load_TimKiem_Ma(item._MaSP.Replace(" ", ""));
                        foreach (class_SANPHAM itemsp in dssp)
                        {
                            int sl = itemsp._slSP - item._slGH;
                            if (sl < 0)
                            {
                                MessageBox.Show("Số lượng sản phẩm " + itemsp._tenSP + " hiện có trong shop không đủ");
                                hd.delete(maHD);
                                return;
                            }
                            
                        }
                    }       
                    //mua hàng
                    foreach (class_GH_SP item in dsgh)
                    {
                        List<class_SANPHAM> dssp = sp.load_TimKiem_Ma(item._MaSP.Replace(" ", ""));
                        foreach (class_SANPHAM itemsp in dssp)
                        {
                            int sl = itemsp._slSP - item._slGH;                            
                            if (!sp.update_SP_sl(itemsp._MaSP.Replace(" ", ""), sl))
                            {
                                MessageBox.Show("Đặt hàng thất bại");
                                hd.delete(maHD);
                                return;
                            }
                        }
                        if (!gh.update_MaHD(maHD, this._tenDN.Replace(" ", ""), item._MaSP.Replace(" ", "")))
                        {
                            MessageBox.Show("Lưu thất bại");
                            hd.delete(maHD);
                            return;
                        }
                        
                    }                                       
                }
                else
                {
                    hd.delete(maHD);
                    return;
                }
                MessageBox.Show("Mua thành công");
                pnChinh.Height = 1;
            }
            catch
            {
                
                MessageBox.Show("Hệ thống lỗi");

            }
        }

        private void btMua_Click(object sender, EventArgs e)
        {
            txtTimGio.Text = "";
            btTimGio_Click(sender, e);
            pnSua1.Height = 1;
            pnChinh.Height = 200;
            txtSDT_NhanHang.Text = lbSDT.Text;
            txtDiaChi_NhanHang.Text = txtDiaChi.Text;
        }

       

        
    }
}
