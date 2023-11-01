create database QLSinhVien;

create table KHOA
(
	MaKhoa char(5) primary key,
	TenKhoa nvarchar(50)
);

create table LOP
(
	MaLop char(5) primary key,
	TenLop nvarchar(10),
	MaKhoa char(5) foreign key (MaKhoa) references KHOA(MaKhoa)
);

create table SINHVIEN
(
	MaSV char(5) primary key,
	HoTen nvarchar(50),
	NgSinh datetime,
	MaLop char(5) foreign key (MaLop) references LOP(MaLop)
);

create table MONHOC
(
	MaMH char(5) primary key,
	TenMH nvarchar(50)
);

create table DIEM
(
	MaSV char(5),
	MaMH char(5),
	Diem float,
	primary key (MaSV, MaMH),
	foreign key (MaSV) references SINHVIEN(MaSV),
	foreign key (MaMH) references MONHOC(MaMH)
);
