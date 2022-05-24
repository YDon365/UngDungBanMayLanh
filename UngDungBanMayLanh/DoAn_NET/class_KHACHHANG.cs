using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DoAn_NET
{
    public class class_KHACHHANG :class_xuLy
    {
        SqlConnection con = new SqlConnection("Data Source =DESKTOP-E9SGVT8; Initial Catalog = QL_MAYLANH; User ID =sa; Password = 01633845790");

        public int _stt { get; set; }
        public string _tenDN { get; set; }
        public string _matKhau { get; set; }
        public string _hoTen { get; set; }
        public string _sdt { get; set; }
        public string _diaChi { get; set; }
        public string _ngaySinh { get; set; }
        public string _email { get; set; }
        public string _gioiTinh { get; set; }
        public string _hinhKH { get; set; }


        public List<class_KHACHHANG> load_ALL()
        {
            string lenh = "select*from KHACHHANG";
            return loadKH(lenh);
        }

        public List<class_KHACHHANG> load_TimKiem_TenDN(string ten)
        {
            string lenh = "select*from KHACHHANG where TenDN='" + ten + "'";
            return loadKH(lenh);
        }

        public List<class_KHACHHANG> load_TimKiem_hoTen(string ten)
        {
            string lenh = "select*from KHACHHANG where hoTen like N'%" + ten + "%'";
            return loadKH(lenh);
        }

        public bool insert(string tenDN,string mk,string hoten,string sdt,string diachi,string ngaysinh,string email,string gioitinh,string hinh)
        {
            string lenh = "set dateformat dmy insert into KHACHHANG values ('"+tenDN+"','"+mk+"',N'"+hoten+"','"+sdt+"',N'"+diachi+"','"+ngaysinh+"','"+email+"',N'"+gioitinh+"',N'"+hinh+"')";
            return cauLenh(lenh);
        }

        public bool update(string tenDN, string mk, string hoten, string sdt, string diachi, string ngaysinh, string email, string gioitinh, string hinh)
        {
            string lenh = "set dateformat dmy update KHACHHANG set matKhau='"+mk+"', hoTen=N'"+hoten+"', sdt='"+sdt+"',diaChi=N'"+diachi+"',ngaySinh='"+ngaysinh+"',email='"+email+"',gioiTinh=N'"+gioitinh+"',hinhKH=N'"+hinh+"' where tenDN='"+tenDN+"'";
            return cauLenh(lenh);
        }

        public bool delete(string tenDN)
        {
            string lenh = "delete from KHACHHANG where tenDN='"+tenDN+"'";
            return cauLenh(lenh);
        }

        public int is_KH(string tenDN)
        {
            string lenh = "select count(*) from KHACHHANG where tenDN='" + tenDN + "'";
            return is_KT(lenh);
        }

        public int countKH()
        {
            string lenh = "select count(*) from KHACHHANG";
            return DemSL(lenh);
        }

        public int is_DangNhap(string ten,string mk)
        {
            try
            {
                string lenh = "select * from KHACHHANG where tenDN='" + ten + "' and matKhau='" + mk + "'";
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
