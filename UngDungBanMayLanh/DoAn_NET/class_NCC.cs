using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_NET
{
    public class class_NCC : class_xuLy
    {
        public int _stt { get; set; }
        public string _MaNCC { get; set; }
        public string _tenNCC { get; set; }
        public string _hinhNCC { get; set; }

        public List<class_NCC> load_ALL()
        {
            string lenh = "select*from NHACUNGCAP";
            return loadNCC(lenh);
        }

        public List<class_NCC> load_TimKiem_Ten(string ten)
        {
            string lenh = "select*from NHACUNGCAP where  tenNCC like N'%" + ten + "%'";
            return loadNCC(lenh);
        }

        public List<class_NCC> load_TimKiem_Ma(string ma)
        {
            string lenh = "select*from NHACUNGCAP where  MaNCC='" + ma + "'";
            return loadNCC(lenh);
        }

        public bool insert(string ma, string ten, string hinh)
        {
            string lenh = "insert into NHACUNGCAP values ('" + ma + "',N'" + ten + "',N'" + hinh + "')";
            return cauLenh(lenh);
        }

        public bool update(string ma, string ten, string hinh)
        {
            string lenh = "update NHACUNGCAP set tenNCC=N'" +ten + "', hinhNCC=N'" + hinh + "' where MaNCC='" + ma + "'";
            return cauLenh(lenh);
        }

        public bool delete(string ma)
        {
            string lenh = "delete from NHACUNGCAP where MaNCC='" + ma + "'";
            return cauLenh(lenh);
        }

        public int is_NCC(string ma)
        {
            string lenh = "select count(*) from NHACUNGCAP where MaNCC='" + ma + "'";
            return is_KT(lenh);
        }

        public int is_KhoaNgoai(string ma)
        {
            string lenh = "select count(*) from SANPHAM s where s.MaNCC='" + ma + "'";
            return is_KT(lenh);
        }

        public int countNCC()
        {
            string lenh = "select count(*) from NHACUNGCAP";
            return DemSL(lenh);
        }
    }
}
