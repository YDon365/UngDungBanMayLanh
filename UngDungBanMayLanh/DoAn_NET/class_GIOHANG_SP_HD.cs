using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_NET
{
    public class class_GIOHANG_SP_HD:class_xuLy
    {
        public int _stt { get; set; }
        public int _slGH { get; set; }
        public int _gia { get; set; }
        public int _tong { get; set; }
        public int _MaHD { get; set; }
        public string _tenDN { get; set; }
        public string _MaSP { get; set; }
        public string _tenSP { get; set; }
        public string _hinhSP { get; set; }
        public string _ngayLap { get; set; }

        public List<class_GIOHANG_SP_HD> load_ALL()
        {
            string lenh = "select gh.MaSP,tenSP,gh.slGH,gh.gia,hd.ngayLap,sum(gh.slGH*gh.gia) as N'tong',hd.tongTien from GIOHANG gh, HOADON hd, SANPHAM sp where gh.MaHD=hd.MaHD and gh.MaSP=sp.MaSP  group by gh.MaSP,tenSP,gh.slGH,gh.gia,hd.ngayLap,hd.tongTien";
            return loadGH_SP_HD(lenh);
        }
       
        public List<class_GIOHANG_SP_HD> load_tenDN(string tendn)
        {
            string lenh = "select gh.MaHD,gh.tenDN,gh.MaSP,tenSP,gh.slGH,gh.gia,hd.ngayLap,sum(gh.slGH*gh.gia) as N'tong',hd.tongTien,sp.hinhSP from GIOHANG gh, HOADON hd, SANPHAM sp where gh.MaHD=hd.MaHD and gh.MaSP=sp.MaSP and tenDN='" + tendn + "' and gh.MaHD is not null group by gh.MaHD,gh.tenDN,gh.MaSP,tenSP,gh.slGH,gh.gia,hd.ngayLap,hd.tongTien,sp.hinhSP";
            return loadGH_SP_HD(lenh);
        }

        public List<class_GIOHANG_SP_HD> load_tenDN_tenSP(string tendn,string tenSP)
        {
            string lenh = "select gh.MaHD,gh.tenDN,gh.MaSP,tenSP,gh.slGH,gh.gia,hd.ngayLap,sum(gh.slGH*gh.gia) as N'tong',hd.tongTien,sp.hinhSP from GIOHANG gh, HOADON hd, SANPHAM sp where gh.MaHD=hd.MaHD and gh.MaSP=sp.MaSP and tenDN='" + tendn + "' and sp.tenSP like N'%" + tenSP + "%' and gh.MaHD is not null group by gh.MaHD,gh.tenDN,gh.MaSP,tenSP,gh.slGH,gh.gia,hd.ngayLap,hd.tongTien,sp.hinhSP";
            return loadGH_SP_HD(lenh);
        }
    }
}
