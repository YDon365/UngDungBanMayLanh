using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DoAn_NET
{
    public partial class item_SP : UserControl
    {
        public string _maSP { get; set; }
        public string _tenSP { get; set; }
        public string _hinh { get; set; }
        public int _gia { get; set; }
        public string _tenDN { get; set; }
        public int _sl { get; set; }

        public item_SP()
        {
            InitializeComponent();
        }

        class_GioHang gh = new class_GioHang();
        string link = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        public item_SP(string maSP, string tenSP,int sl, int gia, string hinh)
        {
            InitializeComponent();
            this._tenDN = "";
            this._gia = gia;
            this._tenSP = tenSP;
            this._sl = sl;
            this._maSP = maSP;
            this._hinh = hinh;
        }

        public item_SP(string tendn,string maSP, string tenSP,int sl, int gia, string hinh)
        {
            InitializeComponent();
            
            this._tenDN = tendn;
            this._gia = gia;
            this._tenSP = tenSP;
            this._sl = sl;
            this._maSP = maSP;
            this._hinh = hinh;
        }

        private void item_SP_Load(object sender, EventArgs e)
        {
            lb_itemGiaSP.Text =this._gia+ " VNĐ";
            lb_itemTenSP.Text = this._tenSP;
            lbSL.Text = this._sl+"";
            string a = "trang.jpg";
            if (this._hinh != "")
                a = this._hinh;
            Image hinh1 = Image.FromFile(link + @"\hinh\" + a);
            hinh1 = resizeImage(hinh1, new Size(300, 100));
            pic_itemSP.Image = hinh1;
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void bt_itemMua_Click(object sender, EventArgs e)
        {
            try
            {
                if (this._tenDN == "")
                {
                    MessageBox.Show("Bạn chưa đăng nhập");
                    return;
                }
                if(int.Parse(lbSL.Text)==0)
                {
                    MessageBox.Show("Tạm thời sản phẩm này đã hết");
                    return;
                }
                //kiểm tra xem sản phẩm này đã có trong giỏ hàng chưa
                if (gh.is_GH_Ten_maSP_Null(this._tenDN.Replace(" ", ""), this._maSP.Replace(" ", "")) == 1)
                {
                    //số lượng cũ trong giỏ hàng
                    int sl  = gh.dem_NULL_TenDN_MaSP(this._tenDN.Replace(" ", ""), this._maSP.Replace(" ", ""));
                    
                    if (gh.update_NULL(this._tenDN, this._maSP.Replace(" ", ""), sl+1))
                    {
                        MessageBox.Show("Thêm vào giỏ hàng thành công");
                        return;
                    }
                }
                else
                {
                    if (this._tenDN.Replace(" ", "") == "admin" && this._tenDN.Replace(" ", "") == "nv2" && this._tenDN.Replace(" ", "") == "nv1")
                        return;
                    if (gh.insert(this._tenDN, this._maSP.Replace(" ", ""), 1))
                    {
                        MessageBox.Show("Thêm vào giỏ hàng thành công");
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Hệ thống lỗi");
            }
            

        }

        
    }
}
