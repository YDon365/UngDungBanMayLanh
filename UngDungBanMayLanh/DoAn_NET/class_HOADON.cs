using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_NET
{
    public class class_HOADON:class_xuLy
    {

        public int _stt { get; set; }
        public int _MaHD { get; set; }
        public int _tongTien { get; set; }
        public string _ngayLap { get; set; }
        public string _dChi { get; set; }
        public string _sdt { get; set; }

        public List<class_HOADON> load_ALL()
        {
            string lenh = "select*from HOADON";
            return loadHD(lenh);
        }

        public List<class_HOADON> load_TimKiem(int ma)
        {
            string lenh = "select*from HOADON where MaHD="+ma+"";
            return loadHD(lenh);
        }

        public List<class_HOADON> load_TimKiem_Ngay(int nam,int thang,int ngay)
        {
            string lenh = "select * from HOADON where YEAR(ngayLap) =" + nam + " and month(ngayLap)=" + thang + " and DAY(ngayLap)=" + ngay + "";
            return loadHD(lenh);
        }

        public List<class_HOADON> load_TimKiem_ThangNam(int nam, int thang)
        {
            string lenh = "select * from HOADON where YEAR(ngayLap) =" + nam + " and month(ngayLap)=" + thang + "";
            return loadHD(lenh);
        }
        
        public bool insert( string ngay,string dchi,string sdt,int tong)
        {
            string lenh = "set dateformat dmy insert into HOADON(ngayLap,dChi,sdt,tongTien) values ('" + ngay + "',N'" + dchi + "','" + sdt + "',"+tong+")";
            return cauLenh(lenh);
        }

        public bool update(int ma, int tien, string ngay)
        {
            string lenh = "set dateformat dmy update HOADON set tongTien=" + tien + ", ngayLap='" + ngay + "' where MaHD=" + ma + "";
            return cauLenh(lenh);
        }

        public bool delete(int ma)
        {
            string lenh = "delete from HOADON where MaHD=" + ma + "";
            return cauLenh(lenh);
        }

        public int is_HD(int ma)
        {
            string lenh = "select count(*) from HOADON where MaHD=" + ma + "";
            return is_KT(lenh);
        }

        public int countHD()
        {
            string lenh = "select count(*) from HOADON";
            return DemSL(lenh);
        }

        public int LayMaHD_Max()
        {

            string lenh = "select MAX(MaHD) from HOADON";
            return DemSL(lenh);
        }
    }
}
