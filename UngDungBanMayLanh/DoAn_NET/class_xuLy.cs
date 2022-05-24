using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DoAn_NET
{
   public class class_xuLy
    {
       SqlConnection con = new SqlConnection("Data Source =DESKTOP-E9SGVT8; Initial Catalog = QL_MAYLANH; User ID =sa; Password = 01633845790");

       public bool cauLenh(string lenh)
       {
           try
           {
               if (con.State == ConnectionState.Closed)
                   con.Open();

               SqlCommand cmd = new SqlCommand(lenh, con);
               cmd.ExecuteNonQuery();
               if (con.State == ConnectionState.Open)
                   con.Close();
               return true;

           }
           catch
           {
               return false;
           }
       }

       public int is_KT(string lenh)
       {
           try
           {
               if (con.State == ConnectionState.Closed)
                   con.Open();
               SqlCommand cmd1 = new SqlCommand(lenh, con);
               cmd1.ExecuteNonQuery();
               int kq = (int)cmd1.ExecuteScalar();
               if (kq >= 1)
                   return 1;//có tồn tại
               return 0;//không tôn tại
           }
           catch
           {
               return -1;//lỗi
           }
       }

       public int DemSL(string lenh)
       {
           try
           {
               if (con.State == ConnectionState.Closed)
                   con.Open();
               SqlCommand cmd1 = new SqlCommand(lenh, con);
               cmd1.ExecuteNonQuery();
               int kq = (int)cmd1.ExecuteScalar();
               
               return kq;
           }
           catch
           {
               return 0;//lỗi
           }
       }
       //chuyển ngày tháng năm giờ => ngày tháng năm
       public string chuyenNgaySinh(DateTime iDate)
       {
           DateTime dt = new DateTime(iDate.Year, iDate.Month, iDate.Day, 1, 1, 1, 1);//nam,thang,day,gio,phut,giay,mini giay
           string ngaySinh = String.Format("{0:d}", dt);
           return ngaySinh;
       }

       //Khách hàng
       public List<class_KHACHHANG> loadKH(string lenh)
       {
           List<class_KHACHHANG> listKH = new List<class_KHACHHANG>();
           try
           {
               if (con.State == ConnectionState.Closed)
                   con.Open();
               SqlCommand cmd = new SqlCommand(lenh, con);
               int stt = 1;
               SqlDataReader ds = cmd.ExecuteReader();
               while (ds.Read())
               {
                   class_KHACHHANG dtKH = new class_KHACHHANG();
                   dtKH._stt = stt;
                   dtKH._tenDN = ds["tenDN"].ToString();
                   dtKH._matKhau = ds["matKhau"].ToString();
                   dtKH._hoTen = ds["hoTen"].ToString();
                   dtKH._sdt = ds["sdt"].ToString();
                   dtKH._diaChi = ds["diaChi"].ToString();
                   dtKH._ngaySinh = ds["ngaySinh"].ToString();
                   dtKH._email = ds["email"].ToString();
                   dtKH._gioiTinh = ds["gioiTinh"].ToString();
                   dtKH._hinhKH = ds["hinhKH"].ToString();
                   stt++;
                   listKH.Add(dtKH);
               }
               ds.Close();
               if (con.State == ConnectionState.Open)
                   con.Close();
               return listKH;

           }
           catch
           {
               return null;
           }
       }
    
       //Hoá đơn
       public List<class_HOADON> loadHD(string lenh)
       {
           List<class_HOADON> list = new List<class_HOADON>();
           try
           {
               if (con.State == ConnectionState.Closed)
                   con.Open();
               SqlCommand cmd = new SqlCommand(lenh, con);
               int stt = 1;
               SqlDataReader ds = cmd.ExecuteReader();
               while (ds.Read())
               {
                   class_HOADON dt = new class_HOADON();
                   dt._stt = stt;
                   dt._MaHD = int.Parse(ds["MaHD"].ToString());
                   dt._tongTien = int.Parse(ds["tongTien"].ToString());
                   dt._ngayLap = ds["ngayLap"].ToString();
                   dt._dChi = ds["dChi"].ToString();
                   dt._sdt = ds["sdt"].ToString();
                   stt++;
                   list.Add(dt);
               }
               ds.Close();
               if (con.State == ConnectionState.Open)
                   con.Close();
               return list;

           }
           catch
           {
               return null;
           }
       }

       //Thương hiệu
       public List<class_NCC> loadNCC(string lenh)
       {
           List<class_NCC> list = new List<class_NCC>();
           try
           {
               if (con.State == ConnectionState.Closed)
                   con.Open();
               SqlCommand cmd = new SqlCommand(lenh, con);
               int stt = 1;
               SqlDataReader ds = cmd.ExecuteReader();
               while (ds.Read())
               {
                   class_NCC dt = new class_NCC();
                   dt._stt = stt;
                   dt._MaNCC = ds["MaNCC"].ToString();
                   dt._tenNCC = ds["tenNCC"].ToString();
                   dt._hinhNCC = ds["hinhNCC"].ToString();
                   stt++;
                   list.Add(dt);
               }
               ds.Close();
               if (con.State == ConnectionState.Open)
                   con.Close();
               return list;

           }
           catch
           {
               return null;
           }
       }

       //Sản phẩm
       public List<class_SANPHAM> loadSP(string lenh)
       {
           List<class_SANPHAM> list = new List<class_SANPHAM>();
           try
           {
               if (con.State == ConnectionState.Closed)
                   con.Open();
               SqlCommand cmd = new SqlCommand(lenh, con);
               int stt = 1;
               SqlDataReader ds = cmd.ExecuteReader();
               while (ds.Read())
               {
                   class_SANPHAM dt = new class_SANPHAM();
                   dt._stt = stt;
                   dt._MaSP = ds["MaSP"].ToString();
                   dt._tenSP = ds["tenSP"].ToString();
                   dt._slSP = int.Parse(ds["slSP"].ToString());
                   dt._donGia = int.Parse(ds["donGia"].ToString());
                   dt._hinhSP = ds["hinhSP"].ToString();
                   dt._hinhThongTin = ds["hinhThongTin"].ToString();
                   dt._MaNCC = ds["MaNCC"].ToString();
                   
                   stt++;
                   list.Add(dt);
               }
               ds.Close();
               if (con.State == ConnectionState.Open)
                   con.Close();
               return list;

           }
           catch
           {
               return null;
           }
       }

       //Quản lý
       public List<class_QUANLY> loadQL(string lenh)
       {
           List<class_QUANLY> list = new List<class_QUANLY>();
           try
           {
               if (con.State == ConnectionState.Closed)
                   con.Open();
               SqlCommand cmd = new SqlCommand(lenh, con);
               int stt = 1;
               SqlDataReader ds = cmd.ExecuteReader();
               while (ds.Read())
               {
                   class_QUANLY dt = new class_QUANLY();
                   dt._stt = stt;
                   dt._tenDN = ds["tenDN"].ToString();
                   dt._matKhau = ds["matKhau"].ToString();
                   dt._quyen = int.Parse(ds["quyen"].ToString());
                   stt++;
                   list.Add(dt);
               }
               ds.Close();
               if (con.State == ConnectionState.Open)
                   con.Close();
               return list;

           }
           catch
           {
               return null;
           }
       }

       //Giỏ hàng 
       public List<class_GioHang> loadGH(string lenh)
       {
           List<class_GioHang> list = new List<class_GioHang>();
           try
           {
               if (con.State == ConnectionState.Closed)
                   con.Open();
               SqlCommand cmd = new SqlCommand(lenh, con);
               int stt = 1;
               SqlDataReader ds = cmd.ExecuteReader();
               while (ds.Read())
               {
                   class_GioHang dt = new class_GioHang();
                   dt._stt = stt;
                   dt._MaHD = int.Parse(ds["MaHD"].ToString());
                   dt._tenDN = ds["tenDN"].ToString();
                   dt._MaSP = ds["MaSP"].ToString();   
                   dt._slGH = int.Parse(ds["slGH"].ToString());
                   dt._gia = int.Parse(ds["gia"].ToString());
                   stt++;
                   list.Add(dt);
               }
               ds.Close();
               if (con.State == ConnectionState.Open)
                   con.Close();
               return list;

           }
           catch
           {
               return null;
           }
       }

       //giỏ hàng sản phẩm HD
       public List<class_GIOHANG_SP_HD> loadGH_SP_HD(string lenh)
       {
           List<class_GIOHANG_SP_HD> list = new List<class_GIOHANG_SP_HD>();
           try
           {
               if (con.State == ConnectionState.Closed)
                   con.Open();
               SqlCommand cmd = new SqlCommand(lenh, con);
               int stt = 1;
               SqlDataReader ds = cmd.ExecuteReader();
               while (ds.Read())
               {
                   class_GIOHANG_SP_HD dt = new class_GIOHANG_SP_HD();
                   dt._stt = stt;
                   dt._MaHD = int.Parse(ds["MaHD"].ToString());
                   dt._tenDN = ds["tenDN"].ToString();
                   dt._MaSP = ds["MaSP"].ToString();
                   dt._tenSP = ds["tenSP"].ToString();
                   dt._slGH = int.Parse(ds["slGH"].ToString());
                   dt._gia = int.Parse(ds["gia"].ToString());
                   dt._ngayLap = ds["ngayLap"].ToString();
                   dt._tong = int.Parse(ds["tong"].ToString());
                   dt._hinhSP = ds["hinhSP"].ToString();
                   stt++;
                   list.Add(dt);
               }
               ds.Close();
               if (con.State == ConnectionState.Open)
                   con.Close();
               return list;

           }
           catch
           {
               return null;
           }
       }

       //giỏ hàng Khách hàng sản phẩm
       public List<class_GH_KH_SP> loadGH_GH_KH_SP(string lenh)
       {
           List<class_GH_KH_SP> list = new List<class_GH_KH_SP>();
           try
           {
               if (con.State == ConnectionState.Closed)
                   con.Open();
               SqlCommand cmd = new SqlCommand(lenh, con);
               int stt = 1;
               SqlDataReader ds = cmd.ExecuteReader();
               while (ds.Read())
               {
                   class_GH_KH_SP dt = new class_GH_KH_SP();
                   dt._stt = stt;
                   dt._MaHD = int.Parse(ds["MaHD"].ToString());
                   dt._tenSP = ds["tenSP"].ToString();
                   dt._slGH = int.Parse(ds["slGH"].ToString());
                   dt._gia = int.Parse(ds["gia"].ToString());
                   dt._tong = int.Parse(ds["tong"].ToString());
                   dt._hoTen = ds["hoTen"].ToString();
                   stt++;
                   list.Add(dt);
               }
               ds.Close();
               if (con.State == ConnectionState.Open)
                   con.Close();
               return list;

           }
           catch
           {
               return null;
           }
       }

       //Giỏ hàng sản phẩm
       public List<class_GH_SP> loadGH_SP(string lenh)
       {
           List<class_GH_SP> list = new List<class_GH_SP>();
           try
           {
               if (con.State == ConnectionState.Closed)
                   con.Open();
               SqlCommand cmd = new SqlCommand(lenh, con);
               int stt = 1;
               SqlDataReader ds = cmd.ExecuteReader();
               while (ds.Read())
               {
                   class_GH_SP dt = new class_GH_SP();
                   dt._stt = stt;
                   dt._tenDN = ds["tenDN"].ToString();
                   dt._MaSP = ds["MaSP"].ToString();
                   dt._tenSP = ds["tenSP"].ToString();
                   dt._slGH = int.Parse(ds["slGH"].ToString());
                   dt._gia = int.Parse(ds["gia"].ToString());
                   dt._tong = int.Parse(ds["tong"].ToString());
                   dt._hinhSP = ds["hinhSP"].ToString();
                   stt++;
                   list.Add(dt);
               }
               ds.Close();
               if (con.State == ConnectionState.Open)
                   con.Close();
               return list;
           }
           catch
           {
               return null;
           }
       }

    }
}
