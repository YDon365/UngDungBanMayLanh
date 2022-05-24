using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_NET
{
    public class class_GH_SP:class_xuLy
    {
        public int _stt { get; set; }
        public int _slGH { get; set; }
        public int _gia { get; set; }
        public int _tong { get; set; }
        public string _tenDN { get; set; }
        public string _MaSP { get; set; }
        public string _tenSP { get; set; }
        public string _hinhSP { get; set; }

        public List<class_GH_SP> load_ALL()
        {
            string lenh = "select gh.tenDN,gh.MaSP,tenSP,gh.slGH,gh.gia,sum(gh.slGH*gh.gia) as N'tong',sp.hinhSP  from GIOHANG gh, SANPHAM sp where  gh.MaSP=sp.MaSP  and gh.MaHD is null  group by gh.tenDN,gh.MaSP,tenSP,gh.slGH,gh.gia,sp.hinhSP";
            return loadGH_SP(lenh);
        }

        public List<class_GH_SP> load_tenDN(string tendn)
        {
            string lenh = "select gh.tenDN,gh.MaSP,tenSP,gh.slGH,gh.gia,sum(gh.slGH*gh.gia) as N'tong',sp.hinhSP  from GIOHANG gh, SANPHAM sp where  gh.MaSP=sp.MaSP and tenDN='" + tendn + "' and gh.MaHD is null  group by gh.tenDN,gh.MaSP,tenSP,gh.slGH,gh.gia,sp.hinhSP";
            return loadGH_SP(lenh);
        }

        public List<class_GH_SP> load_tenDN_tenSP(string tendn,string tenSP)
        {
            string lenh = "select gh.tenDN,gh.MaSP,tenSP,gh.slGH,gh.gia,sum(gh.slGH*gh.gia) as N'tong',sp.hinhSP  from GIOHANG gh, SANPHAM sp where  gh.MaSP=sp.MaSP and tenDN='" + tendn + "' and tenSP like N'%" + tenSP + "%' and gh.MaHD is null  group by gh.tenDN,gh.MaSP,tenSP,gh.slGH,gh.gia,sp.hinhSP";
            return loadGH_SP(lenh);
        }

    
    }
}
