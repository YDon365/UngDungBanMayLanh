using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_NET
{
    public class class_GioHang:class_xuLy
    {
        public int _stt { get; set; }
        public int _slGH { get; set; }
        public int _gia { get; set; }
        public int _MaHD { get; set; }
        public string _tenDN { get; set; }
        public string _MaSP { get; set; }
        

        public List<class_GioHang> load_ALL()
        {
            string lenh = "select*from GIOHANG";
            return loadGH(lenh);
        }

        public List<class_GioHang> load_NULL_TenDN(string tenDN)
        {
            string lenh = "select*from GIOHANG where MaHD is null and tenDN='"+tenDN+"'";
            return loadGH(lenh);
        }

        public List<class_GioHang> load_Not_NULL_TenDN(string tenDN)
        {
            string lenh = "select*from GIOHANG where MaHD is not null and tenDN='" + tenDN + "'";
            return loadGH(lenh);
        }

        

        public bool insert(string tenDN,string maSP,int sl)
        {
            string lenh = "insert into GIOHANG(MaHD,tenDN,MaSP,slGH) values (null,'" + tenDN + "','" + maSP + "'," + sl + ")";
            return cauLenh(lenh);
        }

        public bool update(int mahd,string tenDN, string maSP, int sl)
        {
            string lenh = "update GIOHANG set MaHD="+mahd+",slGH="+sl+" where tenDN='" + tenDN + "' and MaSP='"+maSP+"'";
            return cauLenh(lenh);
        }

        public bool update_MaHD(int mahd, string tenDN, string maSP)
        {
            string lenh = "update GIOHANG set MaHD=" + mahd + " where tenDN='" + tenDN + "' and MaSP='" + maSP + "' and MaHD is null";
            return cauLenh(lenh);
        }

        public bool update_NULL( string tenDN, string maSP, int sl)
        {
            string lenh = "update GIOHANG set slGH=" + sl + " where tenDN='" + tenDN + "' and MaSP='" + maSP + "' and MaHD is null";
            return cauLenh(lenh);
        }

        public bool delete_TenDN_maSP(string tendn,string ma)
        {
            string lenh = "delete from GIOHANG where tenDN='" + tendn + "' and MaSP='" + ma + "' and MaHD is null";
            return cauLenh(lenh);
        }


        public int is_GH_Ten_maSP(string ten,string ma)
        {
            string lenh = "select count(*) from GIOHANG where tenDN='" + ten + "' and MaSP='" + ma + "'";
            return is_KT(lenh);
        }

        public int is_GH_Ten_maSP_Null(string ten, string ma)
        {
            string lenh = "select count(*) from GIOHANG where tenDN='" + ten + "' and MaSP='" + ma + "' and MaHD is null";
            return is_KT(lenh);
        }

        public int is_GH_maSP( string ma)
        {
            string lenh = "select count(*) from GIOHANG where MaSP='" + ma + "'";
            return is_KT(lenh);
        }

        public int is_GH_Ten(string ten)
        {
            string lenh = "select count(*) from GIOHANG where tenDN='" + ten + "'";
            return is_KT(lenh);
        }

        public int dem_GH_Ten(string ten)
        {
            string lenh = "select count(*) from GIOHANG where tenDN='" + ten + "' and MaHD is null";
            return DemSL(lenh);
        }

        public int dem_NULL_TenDN_MaSP(string tenDN, string maSP)
        {
            string lenh = "select slGH from GIOHANG where MaHD is null and tenDN='" + tenDN + "' and MaSP='" + maSP + "'";
            return DemSL(lenh);
        }
    }
}
