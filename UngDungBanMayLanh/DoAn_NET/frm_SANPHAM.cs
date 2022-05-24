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
    public partial class frm_SANPHAM : Form
    {
        public string _tenDN { get; set; }
        public string _tenSP { get; set; }

        public frm_SANPHAM()
        {
            InitializeComponent();
            
        }

        public frm_SANPHAM(string tendn, string tenSp)
        {
            InitializeComponent();
            this._tenDN = tendn;
            this._tenSP = tenSp;

        }

        public frm_SANPHAM(string tenSp)
        {
            InitializeComponent();
            this._tenSP = tenSp;
        }



       


        class_SANPHAM sp = new class_SANPHAM();
        //đang làm ở đây
        private void frm_SANPHAM_Load(object sender, EventArgs e)
        {
            try
            {
                List<class_SANPHAM> ds = new List<class_SANPHAM>();
                if (this._tenSP != "")
                    ds = sp.load_TimKiem(this._tenSP);
                else
                    ds = sp.load_ALL();

                if (this._tenDN == null)
                {

                    foreach (class_SANPHAM item in ds)
                    {
                        item_SP i = new item_SP(item._MaSP, item._tenSP,item._slSP ,item._donGia, item._hinhSP);//item._MaSP, item._tenSP, item._donGia, item._hinhSP
                        pnSP.Controls.Add(i);
                    }
                }
                else
                {
                    foreach (class_SANPHAM item in ds)
                    {
                        item_SP i = new item_SP(this._tenDN, item._MaSP, item._tenSP,item._slSP ,item._donGia, item._hinhSP);//item._MaSP, item._tenSP, item._donGia, item._hinhSP
                        pnSP.Controls.Add(i);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Lỗi hệ thống");
            }
        }
    }
}
