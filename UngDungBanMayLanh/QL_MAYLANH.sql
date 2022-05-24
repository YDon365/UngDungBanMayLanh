go
use master
go
create database QL_MAYLANH
go
use QL_MAYLANH
go
create table KHACHHANG
(
	tenDN char(20) not null,
	matKhau char(20) not null,
	hoTen nvarchar(50),
	sdt char(20),
	diaChi ntext,
	ngaySinh date,
	email char(20),
	gioiTinh nvarchar(20),
	hinhKH nvarchar(500),
	constraint PK_KHACHHANG primary key(tenDN)
)
go
create table QUANLY
(
	tenDN char(20),
	matKhau char(20),
	quyen int default 1,--1 insert,update,delete KHACHHANG, 2--update,delete,insert  SANPHAM,NHACUNGCAP, 3--ADMIN
	constraint PK_QUANLY primary key(tenDN)
)
go
create table NHACUNGCAP
(
	MaNCC char(20),
	tenNCC nvarchar(50),
	hinhNCC nvarchar(500),
	constraint PK_NHACUNGCAP primary key(MaNCC)
)
go
create table SANPHAM
(
	MaSP char(20) not null,
	tenSP nvarchar(50),
	slSP int,
	donGia int,
	hinhSP nvarchar(500),
	hinhThongTin varchar(500),
	MaNCC char(20),
	constraint PK_SP primary key(MaSP)
)
go
create table GIOHANG
(
	MaHD int,
	tenDN char(20),
	MaSP char(20),
	slGH int,
	gia int,
)
go
create table HOADON
(
	MaHD int identity(1,1),
	tongTien int,
	ngayLap date,
	dChi nvarchar(500),
	sdt char(20),
	constraint PK_HOADON primary key(MaHD)
)
go
--Khoá ngoại
alter table SANPHAM
add constraint FK_SP_NCC foreign key(MaNCC) references NHACUNGCAP(MaNCC)

alter table GIOHANG
add constraint FK_GIOHANG_SP foreign key(MaSP) references SANPHAM(MaSP)

alter table GIOHANG
add constraint FK_GIOHANG_KH foreign key(tenDN) references KHACHHANG(tenDN)

alter table GIOHANG
add constraint FK_GIOHANG_HD foreign key(MaHD) references HOADON(MaHD)

--=========================Xử lý Ràng Buộc toàn vẹn=================================
go
--KHACHHANG
alter table KHACHHANG
add constraint CHEK_KH_gioiTinh check(gioiTinh=N'Nam' or gioiTinh=N'Nữ')
go
--SANPHAM
alter table SANPHAM
add Constraint CHEK_SP_donGia check(donGia>=0)

alter table SANPHAM
add Constraint CHEK_SP_slSP check(slSP>=0)
go
--GIOHANG
alter table GIOHANG
add Constraint CHEK_GH_gia check(gia>=0)

alter table GIOHANG
add Constraint CHEK_GH_slGH check(slGH>=0)

alter table GIOHANG
add Constraint defau_GH_gia default 0 for gia
go
--hoadon
alter table HOADON
add Constraint CHEK_HD_tongTien check(tongTien>=0)

alter table HOADON
add constraint defau_HD_tongTien default 0 for tongTien

---==========
--update gia trong giohang
go
create trigger TRIG_donGia on GIOHANG
for insert, update
as
begin
	update GIOHANG
	set gia=(select ct.donGia from SANPHAM ct,inserted i where ct.MaSP=i.MaSP)
	from inserted i
	where GIOHANG.MaSP=i.MaSP
end
go
----update tongTien HD
--create trigger TRIG_HOADON_Tongtien on GIOHANG
--for insert, update
--as
--begin
--	update HOADON
--	set tongTien=tongTien+(select sum(i.gia*i.slGH) from HOADON hd,inserted i
--													where hd.MaHD=i.MaHD )
--	from HOADON hd, inserted i
--	where hd.MaHD=i.MaHD 
--end
go
---------===================NHẬP liệu===============
--======KHACHHANG
set dateformat dmy insert into KHACHHANG values 
('don','123',N'Y Don','0123456789',N'TP.HCM','01/01/2000','don365@gmail.com',N'Nam','1.jpg'),
('thanh','123',N'Công Thành','0123456789',N'Hà Nội','03/05/1998','thanh@gmail.com',N'Nữ','thanh.jpg'),
('vu','123',N'Thảo Vũ','0123456789',N'TP.HCM','29/05/2001','vu@gmail.com',N'Nam','3.jpg'),
('nhi','123',N'Thảo Nhi','0123456789',N'Đà nắng','12/12/2005','nhi@gmail.com',N'Nữ','1.jpg')
go
--========QUANLY
insert into QUANLY values
('admin','1234',3),
('nv1','1234',1),
('nv2','1234',2)
go
--===========NHACUNGCAP
insert into NHACUNGCAP values
('LG',N'LG','NCC_LG.png'),
('SAMSUM',N'Samsum','NCC_Samsum.png'),
('TOSHIBA',N'Toshiba','NCC_Toshiba.png'),
('HITACHI',N'Hitachi','NCC_Hitachi.jpg')
go
--===========SANPHAM
insert into SANPHAM values
('SP01',N'Máy Lạnh LG Inverter 1.0 HP V10APH1',100,10590000,'LG_V10APH1.JPG','LG_V10APH1_ThongTin.JPG',null),
('SP02',N'Máy Lạnh LG Inverter 1.0 HP V10ENW1',98,83900000,'LG_V10ENW1.JPG','LG_V10ENW1_ThongTin.JPG',null),
('SP03',N'Máy Lạnh LG Inverter 1.5 HP V13APIUV',26,12490000,'LG_V13APIUV.JPG','LG_V13APIUV_ThongTin.JPG',null),
('SP04',N'Máy Lạnh LG Inverter 1.0 HP V10APIUV',62,10790000,'LG_V10APIUV.jpg','LG_V10APIUV_ThongTin.JPG',null),
('SP05',N'Máy lạnh Samsung Inverter 1 HP AR10TYHYCWKNSV',30,8690000,'SAMSUM_AR10TYHYCWKNSV.jpg','SAMSUM_AR10TYHYCWKNSV_ThongTin.JPG',null),
('SP06',N'Máy Lạnh Samsung Inverter 1.5 HP AR13TYHYCWKNSV',68,10890000,'SAMSUM_AR13TYHYCWKNSV.jpg','SAMSUM_AR13TYHYCWKNSV_ThongTin.JPG',null),
('SP07',N'Máy Lạnh Samsung Inverter 1.0 Hp AR10TYGCDWKNSV',48,11590000,'SAMSUM_AR10TYGCDWKNSV.JPG','SAMSUM_AR10TYGCDWKNSV_ThongTin.JPG',null),
('SP08',N'Máy Lạnh TOSHIBA Inverter 1.0 HP RAS-H10D2KCVG-V',52,9990000,'TOSHIBA_RAS-H10D2KCVG-V.jpg','TOSHIBA_RAS-H10D2KCVG-V_ThongTin.JPG',null),
('SP09',N'Máy Lạnh TOSHIBA Inverter 2.5 HP RAS-H24E2KCVG-V',37,24590000,'TOSHIBA_RAS-H24E2KCVG-V.JPG','TOSHIBA_RAS-H24E2KCVG-V_ThongTin.JPG',null),
('SP10',N'Máy Lạnh TOSHIBA Inverter 1.5 HP RAS-H13L3KCVG-V',28,12990000,'TOSHIBA_RAS-H13L3KCVG-V.JPG','TOSHIBA_RAS-H13L3KCVG-V_ThongTin.JPG',null),
('SP11',N'Máy Lạnh TOSHIBA Inverter 1.5 HP RAS-H13C3KCVG-V',15,12990000,'TOSHIBA_RAS-H13C3KCVG-V.JPG','TOSHIBA_RAS-H13C3KCVG-V_ThongTin.JPG',null),
('SP12',N'Máy Lạnh TOSHIBA Inverter 2.0 HP RAS-H18J2KCVRG-V',50,22990000,'TOSHIBA_RAS-H18J2KCVRG-V.JPG','TOSHIBA_RAS-H18J2KCVRG-V_ThongTin.JPG',null),
('SP13',N'Máy Lạnh HITACHI Inverter 1.5 HP RAS-DX13CGV-W',50,12990000,'HITACHI_RAS-DX13CGV-W.jpg','HITACHI_RAS-DX13CGV-W_ThongTin.JPG',null),
('SP14',N'Máy Lạnh HITACHI RAS-18CGV/RAC-DX18CGV',50,13990000,'HITACHI_RAS-18CGV-RAC-DX18CGV.JPG','HITACHI_RAS-18CGV-RAC-DX18CGV_ThongTin.JPG',null)

update SANPHAM
set MaNCC='LG' where MaSP='SP01' or MaSP='SP02' or MaSP='SP03' or MaSP='SP04' 

update SANPHAM
set MaNCC='SAMSUM' where MaSP='SP05' or MaSP='SP06' or MaSP='SP07'

update SANPHAM
set MaNCC='TOSHIBA' where MaSP='SP08' or MaSP='SP09' or MaSP='SP10' or MaSP='SP11' or MaSP='SP12'

update SANPHAM
set MaNCC='HITACHI' where MaSP='SP13' or MaSP='SP14'

go
--====HOADON
set dateformat dmy insert into HOADON(ngayLap,dChi,sdt,tongTien) values('15/02/2021','TP.HCM','0123456789',167530000)
set dateformat dmy insert into HOADON(ngayLap,dChi,sdt,tongTien) values('20/05/2021',N'Đà nắng','023564895',150800000)
set dateformat dmy insert into HOADON(ngayLap,dChi,sdt,tongTien) values('30/10/2021',N'TP.HCM','025694585',24580000)
go
--========GIOHANG
insert into GIOHANG(MaHD,tenDN,MaSP,slGH) values(null,'don','SP14',3)
insert into GIOHANG(MaHD,tenDN,MaSP,slGH) values(null,'don','SP01',1)
insert into GIOHANG(MaHD,tenDN,MaSP,slGH) values(1,'don','SP01',2)
insert into GIOHANG(MaHD,tenDN,MaSP,slGH) values(1,'don','SP02',1)
insert into GIOHANG(MaHD,tenDN,MaSP,slGH) values(1,'don','SP03',5)
insert into GIOHANG(MaHD,tenDN,MaSP,slGH) values(2,'thanh','SP06',3)
insert into GIOHANG(MaHD,tenDN,MaSP,slGH) values(2,'thanh','SP14',4)
insert into GIOHANG(MaHD,tenDN,MaSP,slGH) values(2,'thanh','SP11',1)
insert into GIOHANG(MaHD,tenDN,MaSP,slGH) values(2,'thanh','SP09',2)
insert into GIOHANG(MaHD,tenDN,MaSP,slGH) values(3,'don','SP14',1)
insert into GIOHANG(MaHD,tenDN,MaSP,slGH) values(3,'don','SP01',1)

go