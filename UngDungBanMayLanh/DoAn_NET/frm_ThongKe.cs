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
    public partial class frm_ThongKe : Form
    {
        private void kich_Visible()
        {
            panel_KichKH.Visible = false;
            panel_KichNCC.Visible = false;
            panel_KichSPBan.Visible = false;
            panel_kichSPMoi.Visible = false;
            panel_KichTK.Visible = false;
                
            lbTongSP.Text = sp.countSP().ToString();
            lbTongKH.Text = kh.countKH().ToString();
            lbSNCC.Text = ncc.countNCC().ToString();
            lbDaBan.Text = hd.countHD().ToString();
        }


        class_KHACHHANG kh = new class_KHACHHANG();
        class_SANPHAM sp = new class_SANPHAM();
        class_NCC ncc = new class_NCC();
        class_HOADON hd = new class_HOADON();
        class_GH_KH_SP ghkhsp = new class_GH_KH_SP();
        class_GioHang gh = new class_GioHang();
        string link = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        public frm_ThongKe()
        {
            
            InitializeComponent();
            //không cho phép chỉnh sửa combox
            this.cbThuongHieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbThang_TK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void frm_ThongKe_Load(object sender, EventArgs e)
        {
            try
            {
                btThemKH.Enabled = btXoaKH.Enabled = btSuaKH.Enabled = true;
                btThemSP.Enabled = btXoaSP.Enabled = btSuaSP.Enabled = true;
                btThemNCC.Enabled = btXoaNCC.Enabled = btSuaNCC.Enabled = true;
                kich_Visible();
                panel_KichKH.Visible = true;

                data_KH.Rows.Clear();
                List<class_KHACHHANG> dsKH = kh.load_ALL();

                string link = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                foreach (class_KHACHHANG item in dsKH)
                {
                    string a = "trang.jpg";
                    if (item._hinhKH != "")
                        a = item._hinhKH;
                    Image hinh1 = Image.FromFile(link + @"\hinh\" + a);
                    hinh1 = resizeImage(hinh1, new Size(70, 40));
                    data_KH.Rows.Add(item._stt.ToString(), item._tenDN, item._matKhau, item._hoTen, hinh1, item._sdt, item._diaChi, item._ngaySinh, item._email, item._gioiTinh);
                }
                pnKH1.Height = 1;
                pnSP1.Height = 1;
                pnNCC1.Height = 1;
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

        string hinhKH = string.Empty;
        string hinhSP = string.Empty;
        string hinhNCC = string.Empty;
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

        private void panelKhachHang_Click(object sender, EventArgs e)
        {
            try
            {
                kich_Visible();
                panel_KichKH.Visible = true;
                btThemKH.Enabled = btXoaKH.Enabled = btSuaKH.Enabled = true;
                pnKH1.Height = 1;
                data_KH.Rows.Clear();
                List<class_KHACHHANG> dsKH = kh.load_ALL();
                foreach (class_KHACHHANG item in dsKH)
                {

                    string a = "trang.JPG";
                    if (item._hinhKH != "")
                        a = item._hinhKH;
                    Image hinh1 = Image.FromFile(link + @"\hinh\" + a);
                    hinh1 = resizeImage(hinh1, new Size(70, 40));
                    data_KH.Rows.Add(item._stt.ToString(), item._tenDN, item._matKhau, item._hoTen, hinh1, item._sdt, item._diaChi, item._ngaySinh, item._email, item._gioiTinh);
                }

                bunifuPages1.SelectTab("tabKH");
            }
            catch
            {
                MessageBox.Show("Lỗi hệ thống");
            }
            
        }

        private void panelSPMoi_Click(object sender, EventArgs e)
        {
            try
            {
                kich_Visible();
                btThemSP.Enabled = btXoaSP.Enabled = btSuaSP.Enabled = true;
                panel_kichSPMoi.Visible = true;
                cbThuongHieu.Items.Clear();
                data_SP.Rows.Clear();
                List<class_NCC> dsncc = ncc.load_ALL();
                foreach (class_NCC item in dsncc)
                    cbThuongHieu.Items.Add(item._MaNCC.Trim().Replace(" ", ""));//add vào combox và xoá all khoảng trắng

                List<class_SANPHAM> ds = sp.load_ALL();
                foreach (class_SANPHAM item in ds)
                {

                    string a = "trang.JPG";
                    if (item._hinhSP != "")
                        a = item._hinhSP;
                    Image hinh1 = Image.FromFile(link + @"\hinh\" + a);
                    hinh1 = resizeImage(hinh1, new Size(70, 40));
                    data_SP.Rows.Add(item._stt.ToString(), item._MaSP, item._tenSP, hinh1, item._slSP, item._donGia, item._MaNCC);
                }
                bunifuPages1.SelectTab("tabSPMoi");
            }
            catch
            {
                MessageBox.Show("Lỗi hệ thống");
            }
            
        }

        private void panelSPBan_Click(object sender, EventArgs e)  
        {
            try
            {
                kich_Visible();
                panel_KichSPBan.Visible = true;
                data_HoaDon.Rows.Clear();
                List<class_HOADON> ds = hd.load_ALL();

                foreach (class_HOADON item in ds)
                {

                    data_HoaDon.Rows.Add(item._stt.ToString(), item._MaHD, item._ngayLap, item._tongTien,item._dChi,item._sdt);
                }
                bunifuPages1.SelectTab("tabSPBan");
            }
            catch
            {
                MessageBox.Show("Lỗi hệ thống");
            }
            
        }

        private void panelNCC_Click(object sender, EventArgs e)
        {
            try
            {
                kich_Visible();
                btThemNCC.Enabled = btXoaNCC.Enabled = btSuaNCC.Enabled = true;
                panel_KichNCC.Visible = true;
                List<class_NCC> ds = ncc.load_ALL();
                data_ThuongHieu.Rows.Clear();
                foreach (class_NCC item in ds)
                {

                    string a = "trang.JPG";
                    if (item._hinhNCC != "")
                        a = item._hinhNCC;
                    Image hinh1 = Image.FromFile(link + @"\hinh\" + a);
                    hinh1 = resizeImage(hinh1, new Size(70, 40));
                    data_ThuongHieu.Rows.Add(item._stt.ToString(), item._MaNCC, item._tenNCC, hinh1);
                }
                bunifuPages1.SelectTab("tabThuongHieu");
            }
            catch
            {
                MessageBox.Show("Lỗi hệ thống");
            }
            
        }

        private void pnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                kich_Visible();
                panel_KichTK.Visible = true;
                data_ThongKe.Rows.Clear();
                List<class_HOADON> ds = hd.load_ALL();
                int tong = 0;
                foreach (class_HOADON item in ds)
                {
                    tong += item._tongTien;
                    data_ThongKe.Rows.Add(item._stt.ToString(), item._MaHD, item._ngayLap, item._tongTien);
                }
                lbTongTien_ThongKe.Text = tong + " VNĐ";
                bunifuPages1.SelectTab("tabThongKe");
            }
            catch
            {
                MessageBox.Show("Lỗi hệ thống");
            }
            
        }
        
        //KHÁCH HÀNG=====================================================
        private void btThemKH_Click(object sender, EventArgs e)
        {
            try
            {
                txtTenDN.Enabled = true;
                btXoaKH.Enabled = btSuaKH.Enabled = false;
                if (pnKH1.Height == 1)
                {
                    pnKH1.Height = 186;
                    txtTenDN.Text = "";
                    txtMK.Text = "1";
                    txtHoTen.Text = "";
                    txtSDT.Text = "1";
                    txtDiaChi.Text = "";
                    txtEmail.Text = "";
                    string a = "trang.jpg";
                    Image hinh1 = Image.FromFile(link + @"\hinh\" + a);
                    hinh1 = resizeImage(hinh1, new Size(70, 40));
                    picKH.Image = hinh1;
                }
                else
                {

                    //kiểm tra dữ liệu nhập
                    if (txtTenDN.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhâp tài khoản đăng nhập", "Thông báo");
                        txtTenDN.Select();
                        return;
                    }
                    if (txtMK.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhâp mật khẩu", "Thông báo");
                        txtMK.Select();
                        return;
                    }
                    if (txtHoTen.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhâp họ tên", "Thông báo");
                        txtHoTen.Select();
                        return;
                    }
                    if (txtSDT.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhâp số điện thoại", "Thông báo");
                        txtSDT.Select();
                        return;
                    }
                    if (txtEmail.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhâp Email", "Thông báo");
                        txtEmail.Select();
                        return;
                    }
                    if (txtDiaChi.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhâp địa chỉ", "Thông báo");
                        txtDiaChi.Select();
                        return;
                    }
                    string gioiTinh = string.Empty;
                    if (rdNam.Checked == true)
                        gioiTinh = "Nam";
                    if (rdNu.Checked == true)
                        gioiTinh = "Nữ";

                    //kiểm tra ngày
                    DateTime iDate = time_NgaySinh.Value;
                    if (!is_Ngay(iDate))
                    {
                        MessageBox.Show("Vui lòng chọn ngày sinh", "Thông báo");
                        return;
                    }
                    string ngaySinh = kh.chuyenNgaySinh(iDate);
                    //kiểm tra kiểu nhập email
                    if (!is_Email(txtEmail.Text))
                    {
                        MessageBox.Show("Nhập sai Email", "Thông báo");
                        txtEmail.Select();
                        return;
                    }

                    if (kh.is_KH(txtTenDN.Text) == 1)
                    {
                        MessageBox.Show("Tên tài khoản này đã tồn tại", "Thông báo");
                        txtTenDN.Select();
                        return;
                    }

                    if (hinhKH == "")
                        hinhKH = "trang.JPG";

                    if (kh.insert(txtTenDN.Text.Trim().Replace(" ", ""), txtMK.Text.Trim().Replace(" ", ""), txtHoTen.Text,
                        txtSDT.Text.Trim().Replace(" ", ""), txtDiaChi.Text, ngaySinh, txtEmail.Text.Trim().Replace(" ", ""),
                        gioiTinh, hinhKH))
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo");
                        data_KH.Rows.Clear();
                        btAnKH_Click(sender, e);
                        frm_ThongKe_Load(sender, e);
                    }
                    else
                        MessageBox.Show("Thêm thất bại");
                }
            }
            catch
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btXoaKH_Click(object sender, EventArgs e)
        {
            try
            {
                string tendn = data_KH.CurrentRow.Cells[1].Value.ToString().Trim().Replace(" ", "");

                if (gh.is_GH_Ten(tendn) == 1)
                {
                    MessageBox.Show("Khách hàng này có tồn tại khoá ngoại", "Thông báo");
                    return;
                }

                if(MessageBox.Show("Bạn có chắc muốn xoá khách hàng '"+tendn+"' không","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    if (kh.delete(tendn))
                    {
                        MessageBox.Show("Xoá thành công", "Thông báo");
                        //data_KH.Rows.Clear();
                        btAnKH_Click(sender, e);
                        frm_ThongKe_Load(sender, e);
                    }
                    else
                        MessageBox.Show("Xoá thất bại", "Thông báo");
                }
                
            }
            catch
            {
                MessageBox.Show("Xoá thất bại", "Thông báo");
            }
           
        }

        private void btSuaKH_Click(object sender, EventArgs e)
        {
            try
            {
                txtTenDN.Enabled = false;
                btXoaKH.Enabled = btThemKH.Enabled = false;
                if (pnKH1.Height == 1)
                    pnKH1.Height = 186;
                else
                {
                    
                    
                    //kiểm tra dữ liệu nhập                   
                    if (txtMK.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhâp mật khẩu", "Thông báo");
                        txtMK.Select();
                        return;
                    }
                    if (txtHoTen.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhâp họ tên", "Thông báo");
                        txtHoTen.Select();
                        return;
                    }
                    if (txtSDT.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhâp số điện thoại", "Thông báo");
                        txtSDT.Select();
                        return;
                    }
                    if (txtEmail.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhâp Email", "Thông báo");
                        txtEmail.Select();
                        return;
                    }
                    if (txtDiaChi.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhâp địa chỉ", "Thông báo");
                        txtDiaChi.Select();
                        return;
                    }
                    string gioiTinh = string.Empty;
                    if (rdNam.Checked == true)
                        gioiTinh = "Nam";
                    if (rdNu.Checked == true)
                        gioiTinh = "Nữ";

                    //kiểm tra ngày
                    DateTime iDate = time_NgaySinh.Value;
                    if (!is_Ngay(iDate))
                    {
                        MessageBox.Show("Vui lòng chọn ngày sinh", "Thông báo");
                        return;
                    }
                    string ngaySinh = kh.chuyenNgaySinh(iDate);
                    //kiểm tra kiểu nhập email
                    if (!is_Email(txtEmail.Text.Trim().Replace(" ","")))
                    {
                        MessageBox.Show("Nhập sai Email", "Thông báo");
                        txtEmail.Select();
                        return;
                    }
                    if (hinhKH == "")
                    {
                        List<class_KHACHHANG> layHinh = kh.load_TimKiem_TenDN(txtTenDN.Text);
                        foreach (class_KHACHHANG item in layHinh)
                        {
                            hinhKH = "trang.JPG";
                            if (item._hinhKH != "")
                                hinhKH = item._hinhKH;
                        }
                    }
                                          
                    if (MessageBox.Show("Bạn có chắc muốn sửa khách hàng '" + txtTenDN.Text + "' không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (kh.update(txtTenDN.Text.Trim().Replace(" ", ""), txtMK.Text.Trim().Replace(" ", ""), txtHoTen.Text,
                            txtSDT.Text.Trim().Replace(" ", ""), txtDiaChi.Text, ngaySinh, txtEmail.Text.Trim().Replace(" ", ""),
                            gioiTinh, hinhKH))
                        {
                            MessageBox.Show("Sửa thành công", "Thông báo");
                            data_KH.Rows.Clear();
                            btAnKH_Click(sender, e);
                            frm_ThongKe_Load(sender, e);
                        }
                        else
                            MessageBox.Show("Sửa thất bại");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sửa thất bại");
            }


        }

        private void btAnKH_Click(object sender, EventArgs e)
        {
            pnKH1.Height = 1;
            btXoaKH.Enabled = btSuaKH.Enabled =btThemKH.Enabled = true;
        }

        //SẢN PHẨM=====================================================
        private void btThemSP_Click(object sender, EventArgs e)
        {
            try
            {
                btSuaSP.Enabled = btXoaSP.Enabled = false;
                txtMaSP.Enabled = true;
                if (pnSP1.Height == 1)
                {
                    pnSP1.Height = 186;
                    txtMaSP.Text = "";
                    txtTenSP.Text = "";
                    txtSL.Text = "1";
                    txtGia.Text = "1";
                    string a = "trang.jpg";
                    Image hinh1 = Image.FromFile(link + @"\hinh\" + a);
                    hinh1 = resizeImage(hinh1, new Size(70, 40));
                    picSP.Image = hinh1;
                }
                else
                {
                    pnSP1.Height = 186;

                    if (txtMaSP.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhập mã sản phẩm", "Thông báo");
                        txtMaSP.Select();
                        return;
                    }

                    if (txtTenSP.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhập tên sản phẩm", "Thông báo");
                        txtTenSP.Select();
                        return;
                    }

                    if (txtSL.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhập số lượng sản phẩm", "Thông báo");
                        txtSL.Select();
                        return;
                    }

                    if (txtGia.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhập Giá sản phẩm", "Thông báo");
                        txtGia.Select();
                        return;
                    }

                    //kiểm tra mã sp đó đã tồn tại chưa
                    if (sp.is_SP(txtMaSP.Text) == 1)
                    {
                        MessageBox.Show("Mã sản phẩm đó đã tồn tại", "Thông báo");
                        txtMaSP.Select();
                        return;
                    }

                    if (hinhSP == "")
                        hinhSP = "trang.JPG";

                    string mancc = cbThuongHieu.Text;
                    if (sp.insert_SP(txtMaSP.Text, txtTenSP.Text, int.Parse(txtSL.Text), int.Parse(txtGia.Text), hinhSP, "trang.JPG", mancc))
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo");
                        data_SP.Rows.Clear();
                        btAnSP_Click(sender, e);
                        panelSPMoi_Click(sender, e);
                        return;
                    }
                    else
                        MessageBox.Show("Thêm thất bại");

                }
            }
            catch
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btXoaSP_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = data_SP.CurrentRow.Cells[1].Value.ToString().Trim().Replace(" ", "");

                if (gh.is_GH_maSP(ma) == 1)
                {
                    MessageBox.Show("Mã sản phẩm này có tồn tại khoá ngoại", "Thông báo");
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xoá Sản phẩm '" + ma + "' này không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (sp.delete_SP(ma))
                    {
                        MessageBox.Show("Xoá thành công", "Thông báo");
                        data_SP.Rows.Clear();
                        btAnSP_Click(sender, e);
                        panelSPMoi_Click(sender, e);
                        
                        return;
                    }
                    else
                        MessageBox.Show("Xoá thất bại", "Thông báo");
                }

            }
            catch
            {
                MessageBox.Show("Xoá thất bại", "Thông báo");
            }
        }

        private void btSuaSP_Click(object sender, EventArgs e)
        {
            try
            {
                btThemSP.Enabled = btXoaSP.Enabled = false;
                txtMaSP.Enabled = false;
                if (pnSP1.Height == 1)
                    pnSP1.Height = 186;
                else
                {
                    pnSP1.Height = 186;

                    if (txtTenSP.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhập tên sản phẩm", "Thông báo");
                        txtTenSP.Select();
                        return;
                    }

                    if (txtSL.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhập số lượng sản phẩm", "Thông báo");
                        txtSL.Select();
                        return;
                    }

                    if (txtGia.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhập Giá sản phẩm", "Thông báo");
                        txtGia.Select();
                        return;
                    }

                    if (hinhSP == "")
                    {
                        hinhSP = "trang.JPG";
                        List<class_SANPHAM> layHinh = sp.load_TimKiem_Ma(txtMaSP.Text);
                        foreach (class_SANPHAM item in layHinh)
                        {
                            if (item._hinhSP != "")
                                hinhSP = item._hinhSP;
                        }
                    }

                    string mancc = cbThuongHieu.Text;
                    if (sp.update_SP(txtMaSP.Text, txtTenSP.Text, int.Parse(txtSL.Text), int.Parse(txtGia.Text), hinhSP, "trang.JPG", mancc))
                    {
                        MessageBox.Show("Sửa thành công", "Thông báo");
                        data_SP.Rows.Clear();
                        btAnSP_Click(sender, e);
                        panelSPMoi_Click(sender, e);
                        return;
                    }
                    else
                        MessageBox.Show("sửa thất bại");
                   
                }
            }
            catch
            {
                MessageBox.Show("Sửa thất bại");
            }
            
        }

        private void btAnSP_Click(object sender, EventArgs e)
        {
            btThemSP.Enabled = btXoaSP.Enabled = btSuaSP.Enabled = true;
            pnSP1.Height = 1;
        }

        //Thương Hiệu=====================================================
        private void btThemNCC_Click(object sender, EventArgs e)
        {
            try
            {
                btSuaNCC.Enabled = btXoaNCC.Enabled = false;
                txtMaNCC.Enabled = true;
                if (pnNCC1.Height == 1)
                {
                    pnNCC1.Height = 186;
                    txtMaNCC.Text = "";
                    txtTenNCC.Text = "";
                    string a = "trang.jpg";
                    Image hinh1 = Image.FromFile(link + @"\hinh\" + a);
                    hinh1 = resizeImage(hinh1, new Size(70, 40));
                    picNCC.Image = hinh1;
                }
                else
                {


                    pnNCC1.Height = 186;

                    if (txtMaNCC.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhập Mã thương hiệu", "Thông báo");
                        txtMaNCC.Select();
                        return;
                    }

                    if (txtTenNCC.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhập tên thương hiệu", "Thông báo");
                        txtTenNCC.Select();
                        return;
                    }

                    //kiểm tra tồn tại mã thương hiệu
                    string a = txtMaNCC.Text.Trim().Replace(" ", "");
                    if (ncc.is_NCC(a) == 1)
                    {
                        MessageBox.Show("Mã thương hiệu đó đã tồn tại", "Thông báo");
                        txtMaNCC.Select();
                        return;
                    }

                    if (hinhNCC == "")
                        hinhNCC = "trang.JPG";

                    if (ncc.insert(txtMaNCC.Text, txtTenNCC.Text, hinhNCC))
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo");
                        data_ThuongHieu.Rows.Clear();
                        btAnNCC_Click(sender, e);
                        panelNCC_Click(sender, e);
                        return;
                    }
                    else
                        MessageBox.Show("Thêm thất bại", "Thông báo");
                }

            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
            
        }

        private void btXoaNCC_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = data_ThuongHieu.CurrentRow.Cells[1].Value.ToString().Trim().Replace(" ", "");

                if (ncc.is_KhoaNgoai(ma) == 1)
                {
                    MessageBox.Show("Khách hàng này có tồn tại khoá ngoại", "Thông báo");
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xoá Thương hiệu '" + ma + "' này không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (ncc.delete(ma))
                    {
                        MessageBox.Show("Xoá thành công", "Thông báo");
                        data_ThuongHieu.Rows.Clear();
                        btAnNCC_Click(sender, e);
                        panelNCC_Click(sender, e);
                        return;
                    }
                    else
                        MessageBox.Show("Xoá thất bại", "Thông báo");
                }

            }
            catch
            {
                MessageBox.Show("Xoá thất bại", "Thông báo");
            }
        }

        private void btSuaNCC_Click(object sender, EventArgs e)
        {
            try
            {
                btThemNCC.Enabled = btXoaNCC.Enabled = false;
                txtMaNCC.Enabled = false; ;
                if (pnNCC1.Height == 1)
                    pnNCC1.Height = 186;
                else
                {
                    pnNCC1.Height = 186;
                    if (txtTenNCC.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhập tên thương hiệu", "Thông báo");
                        txtTenNCC.Select();
                        return;
                    }

                    if (hinhNCC == "")
                    {
                        hinhNCC = "trang.JPG";
                        List<class_NCC> layHinh = ncc.load_TimKiem_Ma(txtMaNCC.Text);
                        foreach (class_NCC item in layHinh)
                        {                          
                            if (item._hinhNCC != "")
                                hinhNCC = item._hinhNCC;
                        }
                    }
                    if (ncc.update(txtMaNCC.Text, txtTenNCC.Text, hinhNCC))
                    {
                        MessageBox.Show("Sửa thành công", "Thông báo");
                        data_ThuongHieu.Rows.Clear();
                        btAnNCC_Click(sender, e);
                        panelNCC_Click(sender, e);
                        return;
                    }
                    else
                        MessageBox.Show("Sửa thất bại", "Thông báo");
                }
            }
            catch
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btAnNCC_Click(object sender, EventArgs e)
        {
            btThemNCC.Enabled = btXoaNCC.Enabled = btSuaNCC.Enabled = true;
            pnNCC1.Height = 1;
        }

        //Thông kề=====================================================
        private void btResertThongKe_Click(object sender, EventArgs e)
        {
            pnThongKe_Click(sender, e);
        }

        private void btTimKiem_ThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                kich_Visible();
                panel_KichTK.Visible = true;
                data_ThongKe.Rows.Clear();

                DateTime iDate = time_NgayHD_ThongKe.Value;
                string ngayThangNam = kh.chuyenNgaySinh(iDate);
                string[] catNgayThang = ngayThangNam.Trim().Split('/');
                int nam = int.Parse(catNgayThang[2].ToString());
                int thang = int.Parse(catNgayThang[1].ToString());
                int day = int.Parse(catNgayThang[0].ToString());

                List<class_HOADON> ds = hd.load_TimKiem_Ngay(nam, thang, day);
                int tong = 0;
                foreach (class_HOADON item in ds)
                {
                    tong += item._tongTien;
                    data_ThongKe.Rows.Add(item._stt.ToString(), item._MaHD, item._ngayLap, item._tongTien);
                }
                lbTongTien_ThongKe.Text = tong + " VNĐ";
                bunifuPages1.SelectTab("tabThongKe");
            }
            catch
            {
                MessageBox.Show("Lỗi hệ thống");
            }
        }

        private void btTongTien_TK_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime hienTai = DateTime.Today;
                if (int.Parse(txtNam_TK.Text) > hienTai.Year || int.Parse(txtNam_TK.Text) < 2015)
                {
                    MessageBox.Show("Vui lòng nhập đúng năm");
                    txtNam_TK.Select();
                    return;
                }

                int nam = int.Parse(txtNam_TK.Text);
                int thang = int.Parse(cbThang_TK.Text);

                List<class_HOADON> ds = hd.load_TimKiem_ThangNam(nam, thang);
                int tong = 0;
                foreach (class_HOADON item in ds)
                    tong += item._tongTien;
                txtTongTien_TK.Text = tong + " VNĐ";
            }
            catch
            {
                MessageBox.Show("Lỗi hệ thống");
            }
        }
        //chỉ cho nhập số=====================================================
        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void txtNam_TK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        //update hình =====================================================
        private void btLoadHinhKH_Click(object sender, EventArgs e)
        {
            hinhKH = string.Empty;
            OpenFileDialog opne = new OpenFileDialog();
            if (opne.ShowDialog() == DialogResult.OK)
            {
                string link = string.Empty;
                picKH.Image = Image.FromFile(opne.FileName);
                link = opne.FileName;

                //lấy tên hinh ảnh. bỏ đường dẫn
                string[] ten = link.Trim().Split('\\');//lấy tên hình

                this.hinhKH = ten[ten.Count() - 1];//gán hinh=tên hình vừa lấy
            }
        }

        private void btLoadHinhSP_Click_1(object sender, EventArgs e)
        {
            hinhSP = string.Empty;
            OpenFileDialog opne = new OpenFileDialog();
            if (opne.ShowDialog() == DialogResult.OK)
            {
                string link = string.Empty;
                picSP.Image = Image.FromFile(opne.FileName);
                link = opne.FileName;

                //lấy tên hinh ảnh. bỏ đường dẫn
                string[] ten = link.Trim().Split('\\');//lấy tên hình

                this.hinhSP = ten[ten.Count() - 1];//gán hinh=tên hình vừa lấy
            }
        }

        private void btLoadHinhNCC_Click(object sender, EventArgs e)
        {
            hinhNCC = string.Empty;
            OpenFileDialog opne = new OpenFileDialog();
            if (opne.ShowDialog() == DialogResult.OK)
            {
                string link = string.Empty;
                picNCC.Image = Image.FromFile(opne.FileName);
                link = opne.FileName;

                //lấy tên hinh ảnh. bỏ đường dẫn
                string[] ten = link.Trim().Split('\\');//lấy tên hình

                this.hinhNCC = ten[ten.Count() - 1];//gán hinh=tên hình vừa lấy
            }
        }

        //even select=====================================================
        private void data_KH_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtTenDN.Text = data_KH.CurrentRow.Cells[1].Value.ToString().Trim().Replace(" ", "");
                txtMK.Text = data_KH.CurrentRow.Cells[2].Value.ToString().Trim().Replace(" ", "");
                txtHoTen.Text = data_KH.CurrentRow.Cells[3].Value.ToString();

                txtSDT.Text = data_KH.CurrentRow.Cells[5].Value.ToString().Trim().Replace(" ", "");
                txtDiaChi.Text = data_KH.CurrentRow.Cells[6].Value.ToString();

                string[] ngayThang1 = data_KH.CurrentRow.Cells[7].Value.ToString().Trim().Split(' ');
                string[] ngayThang = ngayThang1[0].Trim().Split('/');
                int d = int.Parse(ngayThang[0].ToString());
                int m = int.Parse(ngayThang[1].ToString());
                int y = int.Parse(ngayThang[2].ToString());
                DateTime dt = new DateTime(y, m, d);
                time_NgaySinh.Value = dt;

                txtEmail.Text = data_KH.CurrentRow.Cells[8].Value.ToString().Trim().Replace(" ", "");
                string gioiTinh = data_KH.CurrentRow.Cells[9].Value.ToString();
                if (gioiTinh == "Nam")
                    rdNam.Checked = true;
                else
                    rdNu.Checked = true;

                List<class_KHACHHANG> layHinh = kh.load_TimKiem_TenDN(txtTenDN.Text);
                string a = string.Empty;
                a = "trang.JPG";
                foreach (class_KHACHHANG item in layHinh)
                {

                    if (item._hinhKH != "")
                        a = item._hinhKH;
                }
                Image hinh1 = Image.FromFile(link + @"\hinh\" + a);
                hinh1 = resizeImage(hinh1, new Size(70, 40));
                picKH.Image = hinh1;
            }
            catch
            {
                MessageBox.Show("Hệ thống lỗi");

            }

        }

        private void data_SP_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaSP.Text = data_SP.CurrentRow.Cells[1].Value.ToString().Trim().Replace(" ", "");
                txtTenSP.Text = data_SP.CurrentRow.Cells[2].Value.ToString();

                List<class_SANPHAM> layHinh = sp.load_TimKiem_Ma(txtMaSP.Text);
                string a = string.Empty;
                a = "trang.JPG";
                foreach (class_SANPHAM item in layHinh)
                {

                    if (item._hinhSP != "")
                        a = item._hinhSP;
                }
                Image hinh1 = Image.FromFile(link + @"\hinh\" + a);
                hinh1 = resizeImage(hinh1, new Size(70, 40));
                picSP.Image = hinh1;

                txtSL.Text = data_SP.CurrentRow.Cells[4].Value.ToString().Trim().Replace(" ", "");
                txtGia.Text = data_SP.CurrentRow.Cells[5].Value.ToString().Trim().Replace(" ", "");

                cbThuongHieu.Text = data_SP.CurrentRow.Cells[6].Value.ToString().Trim().Replace(" ", "");
            }
            catch
            {
                MessageBox.Show("Hệ thống lỗi");

            }
        }

        private void data_HoaDon_SelectionChanged(object sender, EventArgs e)
        {
            try
            {


                data_ChiTietHD.Rows.Clear();
                int ma = int.Parse(data_HoaDon.CurrentRow.Cells[1].Value.ToString());
                List<class_GH_KH_SP> ds = ghkhsp.load_MaHD(ma);

                foreach (class_GH_KH_SP item in ds)
                    data_ChiTietHD.Rows.Add(item._stt.ToString(), item._MaHD, item._hoTen, item._tenSP, item._slGH, item._gia, item._tong);
            }
            catch
            {
                MessageBox.Show("Hệ thống lỗi");

            }
        }

        private void data_ThuongHieu_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaNCC.Text = data_ThuongHieu.CurrentRow.Cells[1].Value.ToString().Trim().Replace(" ", "");// xoá all khoảng trống
                txtTenNCC.Text = data_ThuongHieu.CurrentRow.Cells[2].Value.ToString().Trim().Replace(" ", "");

                List<class_NCC> layHinh = ncc.load_TimKiem_Ma(txtMaNCC.Text);

                string a = string.Empty;
                a = "trang.JPG";
                foreach (class_NCC item in layHinh)
                {

                    if (item._hinhNCC != "")
                        a = item._hinhNCC;
                }
                Image hinh1 = Image.FromFile(link + @"\hinh\" + a);
                hinh1 = resizeImage(hinh1, new Size(160, 65));
                picNCC.Image = hinh1;
            }
            catch
            {
                MessageBox.Show("Hệ thống lỗi");

            }
        }

        
        private void btIn_Click(object sender, EventArgs e)
        {
            frm_InPhieu f = new frm_InPhieu(1);
            f.ShowDialog();
        }

        private void btInSP_Click(object sender, EventArgs e)
        {
            frm_InPhieu f = new frm_InPhieu(2);
            f.ShowDialog();
        }

    }
}
