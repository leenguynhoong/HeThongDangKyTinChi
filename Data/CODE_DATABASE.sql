create database dtbtt1

use dtbtt1
go

create table TaiKhoan
(
	TenTaiKhoan varchar(10) primary key
	,MatKhau nvarchar(20)
	,HoTen nvarchar(30)
	,Quyen Bit
	,NgayTao Date
	,NgaySua Date
	,NguoiTao nvarchar(30)
	,NguoiSua nvarchar(30)
)

create table MonHoc
(
	 MaMon int primary key
	,TenMon nvarchar(20)
	,NgayTao Date
	,NgaySua Date
	,NguoiTao nvarchar(30)
	,NguoiSua nvarchar(30)
)

create table DangKyTin
(
	MaDangKy int primary key IDENTITY(1,1)
	,TenTaiKhoan varchar(10) foreign key references TaiKhoan(TenTaiKhoan)
	,MaMon int NOT NULL foreign key references MonHoc(MaMon)
	,NgayTao Date
	,NgaySua Date
	,NguoiTao nvarchar(30) 
	,NguoiSua nvarchar(30)
)
Insert into TaiKhoan (TenTaiKhoan,MatKhau,HoTen,Quyen,NgayTao,NguoiTao)
values('2','koco','Hung',1,'2015-02-15','Lê Nguyên Hưng')
Insert into TaiKhoan (TenTaiKhoan,MatKhau,HoTen,Quyen,NgayTao,NguoiTao)
values('admin','admin','Admin1',0,'2015-02-15','Thanh An')
Insert into TaiKhoan (TenTaiKhoan,MatKhau,HoTen,Quyen,NgayTao,NguoiTao)
values('admin2','admin2','Admin2',0,'2015-02-15','Tám Bốn')
Insert into TaiKhoan (TenTaiKhoan,MatKhau,HoTen,Quyen,NgayTao,NguoiTao)
values('1000','mot','Nam',1,'2017-02-25','Lê Nam')
Insert into TaiKhoan (TenTaiKhoan,MatKhau,HoTen,Quyen,NgayTao,NguoiTao)
values('1','1','Huy',1,'2022-02-15','Gia Huy')
Insert into TaiKhoan (TenTaiKhoan,MatKhau,HoTen,Quyen,NgayTao,NguoiTao)
values('3','2','Nam',1,'2018-04-11','Thành Nam')


Insert into Monhoc (MaMon,TenMon,NgayTao,NguoiTao)
values(1,'Toan','2022-02-15','GiaHuy')
Insert into Monhoc (MaMon,TenMon,NgayTao,NguoiTao)
values(2,'Anh','2022-02-14','GiaHuy')
Insert into Monhoc (MaMon,TenMon,NgayTao,NguoiTao)
values(3,'Van','2022-02-15','GiaHuy')
Insert into Monhoc (MaMon,TenMon,NgayTao,NguoiTao)
values(4,'The duc','2022-02-13','GiaHuy')
Insert into Monhoc (MaMon,TenMon,NgayTao,NguoiTao) 
values(5,'Hoa','2022-02-15','GiaHuy')


--declare @idtentk int 
--select @idtentk = 42
--while @idtentk >=42 and @idtentk <= 50
--begin
--	declare @idmon int
--	select @idmon = 4
--	while @idmon >=4 and @idmon <= 242
--	begin
--		insert into DangKyTin(TenTaiKhoan,MaMon,NgayTao,NguoiTao) values(@idtentk ,@idmon,'2022-02-15','GiaHuy')
--		select @idmon = @idmon + 1
--	end
--	select @idtentk = @idtentk + 1
--end

Insert into DangKyTin(TenTaiKhoan,MaMon,NgayTao,NguoiTao)
values(3,1,'2022-02-15','Thành Nam')
Insert into DangKyTin(TenTaiKhoan,MaMon,NgayTao,NguoiTao) 
values(1,1,'2022-02-15','Gia Huy')
Insert into DangKyTin(TenTaiKhoan,MaMon,NgayTao,NguoiTao) 
values(1,3,'2022-02-15','Gia Huy')
Insert into DangKyTin(TenTaiKhoan,MaMon,NgayTao,NguoiTao) 
values(1,4,'2022-02-15','Gia Huy')

--drop table TaiKhoan
--drop table MonHoc
--drop table DangKyTin