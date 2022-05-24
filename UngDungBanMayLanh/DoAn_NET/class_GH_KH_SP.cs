using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_NET
{
    public class class_GH_KH_SP:class_xuLy
    {
        public int _stt { get; set; }
        public int _tong { get; set; }
        public string _MaSP { get; set; }
        public string _tenSP { get; set; }
        public string _hoTen { get; set; }
        public int _slGH { get; set; }
        public int _gia { get; set; }
        public int _MaHD { get; set; }
        public string _tenDN { get; set; }

       public List<class_GH_KH_SP> load_MaHD(int ma)
        {
            string lenh = "select gh.MaHD,kh.hoTen,sp.tenSP,gh.slGH,gh.gia,sum(gh.gia*gh.slGH) as 'tong' from GIOHANG gh,SANPHAM sp, KHACHHANG kh where gh.MaSP=sp.MaSP and gh.tenDN=kh.tenDN and gh.MaHD=" + ma + " group by gh.MaHD,kh.hoTen,sp.tenSP,gh.slGH,gh.gia";
            return loadGH_GH_KH_SP(lenh);
        }

    }
}
