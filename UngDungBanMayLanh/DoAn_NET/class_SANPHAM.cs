using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_NET
{
    public class class_SANPHAM:class_xuLy
    {
        public int _stt { get; set; }
        public string _MaSP { get; set; }
        public string _tenSP { get; set; }
        public int _slSP { get; set; }
        public int _donGia { get; set; }
        public string _hinhSP { get; set; }
        public string _hinhThongTin { get; set; }
        public string _MaNCC { get; set; }

        public List<class_SANPHAM> load_ALL()
        {
            string lenh = "select*from SANPHAM";
            return loadSP(lenh);
        }

        public List<class_SANPHAM> load_TimKiem(string ten)
        {
            string lenh = "select*from SANPHAM where tenSP like N'%" + ten + "%'";
            return loadSP(lenh);
        }

        public List<class_SANPHAM> load_TimKiem_Ma(string ma)
        {
            string lenh = "select*from SANPHAM where  MaSP='" + ma + "'";
            return loadSP(lenh);
        }

        public bool insert_SP(string maSP, string tenSP, int sl, int gia, string hinhSP, string hinhTT, string maNCC)
        {
            string lenh = "insert into SANPHAM values('"+maSP+"',N'"+tenSP+"',"+sl+","+gia+",'"+hinhSP+"','"+hinhTT+"','"+maNCC+"')";
            return cauLenh(lenh);
        }

        public bool update_SP(string maSP, string tenSP, int sl, int gia, string hinhSP, string hinhTT, string maNCC)
        {
            string lenh = "update SANPHAM set tenSP=N'"+tenSP+"', slSP="+sl+", donGia="+gia+",hinhSP=N'"+hinhSP+"',hinhThongTin=N'"+hinhTT+"', MaNCC='"+maNCC+"' where MaSP='"+maSP+"'";
            return cauLenh(lenh);
        }

        public bool update_SP_sl(string maSP, int sl)
        {
            string lenh = "update SANPHAM set  slSP=" + sl + " where MaSP='" + maSP + "'";
            return cauLenh(lenh);
        }

        public bool delete_SP(string ma)
        {
            string lenh = "delete from SANPHAM where MaSP='"+ma+"'";
            return cauLenh(lenh);
        }

        public int is_SP(string ma)
        {
            string lenh = "select count(*) from SANPHAM where MaSP='"+ma+"'";
            return is_KT(lenh);
        }

        public int countSP()
        {
            string lenh = "select count(*) from SANPHAM";
            return DemSL(lenh);
        }

        //public int is_KhoaNgoai(string ma)
        //{
        //    string lenh = "select count(*) from GIO where MaSP='" + ma + "'";
        //    return is_KT(lenh);
        //}
    }
}
