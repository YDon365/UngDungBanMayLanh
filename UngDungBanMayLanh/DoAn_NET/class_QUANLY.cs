using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DoAn_NET
{
    public class class_QUANLY:class_xuLy
    {
        SqlConnection con = new SqlConnection("Data Source =DESKTOP-E9SGVT8; Initial Catalog = QL_MAYLANH; User ID =sa; Password = 01633845790");

        public int _stt { get; set; }
        public string _tenDN { get; set; }
        public string _matKhau { get; set; }
        public int _quyen { get; set; }

        public List<class_QUANLY> load_ALL()
        {
            string lenh = "select*from QUANLY";
            return loadQL(lenh);
        }

        public List<class_QUANLY> load_TimKiem(string ten)
        {
            string lenh = "select*from QUANLY where  tenDN='" + ten + "'";
            return loadQL(lenh);
        }

        public bool insert(string ma, string mk, int quyen)
        {
            string lenh = "insert into QUANLY values ('" + ma + "','" + mk + "'," + quyen + ")";
            return cauLenh(lenh);
        }

        public bool update(string ma, string mk, int quyen)
        {
            string lenh = "update QUANLY set matKhau='" + mk + "', quyen=" + quyen + " where tenDN='" + ma + "'";
            return cauLenh(lenh);
        }

        public bool delete(string ma)
        {
            string lenh = "delete from QUANLY where tenDN='" + ma + "'";
            return cauLenh(lenh);
        }

        public int is_QL(string ma)
        {
            string lenh = "select count(*) from QUANLY where tenDN='" + ma + "'";
            return is_KT(lenh);
        }

        public int countQL()
        {
            string lenh = "select count(*) from QUANLY";
            return DemSL(lenh);
        }

        public int is_DangNhap(string ten, string mk)
        {
            try
            {
                string lenh = "select *from QUANLY where tenDN='" + ten + "' and matKhau='" + mk + "'";
                SqlDataAdapter da = new SqlDataAdapter(lenh, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    return 1;//dăng nhập thành công
                return 0;//đăng nhập thất bại
            }
            catch
            {
                return -1;//lỗi
            }
        }
    }
}
