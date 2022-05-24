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
    public partial class frm_InPhieu : Form
    {
        int _Kieu = 0;
        public frm_InPhieu()
        {
            InitializeComponent();
        }

        public frm_InPhieu(int a)
        {
            InitializeComponent();
            _Kieu = a;
        }

        private void frm_InKHACHHANG_Load(object sender, EventArgs e)
        {
            try
            {
                if(_Kieu==1)
                {
                    cr_KHACHHANG rpt = new cr_KHACHHANG();
                    crystalReportViewer1.ReportSource = rpt;

                    rpt.SetDatabaseLogon("sa", "01633845790", "DESKTOP-E9SGVT8", "QL_MAYLANH");

                    crystalReportViewer1.Refresh();
                    crystalReportViewer1.DisplayStatusBar = false;
                    crystalReportViewer1.DisplayToolbar = true;
                }
                if (_Kieu == 2)
                {
                    cr_SANPHAM rpt = new cr_SANPHAM();
                    crystalReportViewer1.ReportSource = rpt;

                    rpt.SetDatabaseLogon("sa", "01633845790", "DESKTOP-E9SGVT8", "QL_MAYLANH");

                    crystalReportViewer1.Refresh();
                    crystalReportViewer1.DisplayStatusBar = false;
                    crystalReportViewer1.DisplayToolbar = true;
                }


                
            }
            catch
            {
                MessageBox.Show("Hệ thống lỗi");
            }
        }     
    }
}
