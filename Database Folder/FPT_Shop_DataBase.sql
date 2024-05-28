create database FPTShop
go
-- drop database FPTShop
use FPTShop
go


CREATE TABLE ThuongHieu (
    maThuongHieu NVARCHAR(20) PRIMARY KEY NOT NULL,
    tenThuongHieu NVARCHAR(255) NOT NULL,
    quocGia NVARCHAR(255)
);
go


CREATE TABLE LoaiSP (
    maLoai NVARCHAR(20) PRIMARY KEY NOT NULL,
    tenLoai NVARCHAR(255) NOT NULL,
    moTa NVARCHAR(500),
    --maLoaiCha NVARCHAR(20) NOT NULL,
    --FOREIGN KEY (maLoaiCha) REFERENCES LoaiSP(maLoai)
);
go


CREATE TABLE SanPham (
    maSP NVARCHAR(20) PRIMARY KEY NOT NULL,
    tenSP NVARCHAR(255) NOT NULL,
    moTa NVARCHAR(500),
    Gia FLOAT NOT NULL,
    maThuongHieu NVARCHAR(20) NOT NULL,
    maLoai NVARCHAR(20) NOT NULL,
    soLuongTrongKho INT,
    NgayNhap DATE,
    Anh NVARCHAR(1000),
    FOREIGN KEY (maThuongHieu) REFERENCES ThuongHieu(maThuongHieu),
    FOREIGN KEY (maLoai) REFERENCES LoaiSP(maLoai)
);
go


CREATE TABLE KhachHang (
    maKH NVARCHAR(20) PRIMARY KEY NOT NULL,
    tenKH NVARCHAR(255) NOT NULL,
	gioiTinh NVARCHAR(20) NOT NULL,
    diaChi NVARCHAR(500),
    SDT NVARCHAR(20)
);
go


CREATE TABLE NhanVien (
    maNV NVARCHAR(20) PRIMARY KEY NOT NULL,
    tenNV NVARCHAR(255) NOT NULL,
	gioiTinh NVARCHAR(10) NOT NULL,
	ngaySinh DATE NOT NULL, 
	SDT NVARCHAR(20) NOT NULL,
    luong FLOAT,
	diaChi NVARCHAR(200) NOT NULL
);
go


CREATE TABLE ChiNhanh (
    maChiNhanh NVARCHAR(20) PRIMARY KEY NOT NULL,
    tenChiNhanh NVARCHAR(255) NOT NULL,
    diaChi NVARCHAR(500),
    SDT NVARCHAR(20)
	-- maSP NVARCHAR(20), 
    -- FOREIGN KEY (maSP) REFERENCES SanPham(maSP)
);
go


CREATE TABLE DonHang (
    maDonHang NVARCHAR(20) PRIMARY KEY NOT NULL,
    maKH NVARCHAR(20) NOT NULL,
    ngayMua DATE,
    tongDonHang FLOAT NOT NULL,
    tinhTrangDatHang NVARCHAR(50),
    phuongThucThanhToan NVARCHAR(50),
    maSP NVARCHAR(20) NOT NULL,
    soLuong INT,
    giaTungSP FLOAT,
	phanTramGiamGia INT,
	maChiNhanh NVARCHAR(20),
	maNV NVARCHAR(20) NOT NULL,
    FOREIGN KEY (maNV) REFERENCES NhanVien(maNV),
    FOREIGN KEY (maKH) REFERENCES KhachHang(maKH),
    FOREIGN KEY (maSP) REFERENCES SanPham(maSP),
	FOREIGN KEY (maChiNhanh) REFERENCES ChiNhanh(maChiNhanh)
);
go


CREATE TABLE PhieuNhapKho (
    maPNK NVARCHAR(20) PRIMARY KEY NOT NULL,
	tenSP NVARCHAR(255) NOT NULL,
    ngayNhap DATE,
    tongDonGia FLOAT,
	soLuong INT,
    maNV NVARCHAR(20) NOT NULL,
    FOREIGN KEY (maNV) REFERENCES NhanVien(maNV)
);
go


-- Ma giam gia = voucher = discount (giam gia)
-- ma la noi dung cua ma, VD: DMM123123 de add ma
--CREATE TABLE Voucher (
--    maVoucher NVARCHAR(20) PRIMARY KEY NOT NULL,
--	maDonHang NVARCHAR(20), 
--    maSP NVARCHAR(20),
--    ma NVARCHAR(50) NOT NULL,
--    phanTramGiamGia int NOT NULL,
--    ngayHetHan DATE
--	FOREIGN KEY (maDonHang) REFERENCES DonHang(maDonHang),
--    FOREIGN KEY (maSP) REFERENCES SanPham(maSP)
--);
--go

CREATE TABLE DangNhap ( 
	TaiKhoan NVARCHAR(50) PRIMARY KEY NOT NULL,
	MatKhau NVARCHAR(50) 
);
go


--ALTER TABLE NhanVien
--ADD CONSTRAINT FK_NhanVien_ChiNhanh FOREIGN KEY (maChiNhanh) REFERENCES ChiNhanh(maChiNhanh);
--go

--ALTER TABLE PhieuNhapKho
--ADD CONSTRAINT FK_PhieuNhapKho_NhanVien FOREIGN KEY (maNV) REFERENCES NhanVien(maNV);
--go

--ALTER TABLE Voucher
--ADD CONSTRAINT FK_Voucher_AnotherTable FOREIGN KEY (maTruongTrongVoucher) REFERENCES AnotherTable(maTruongTrongAnotherTable);
--go
INSERT INTO DangNhap(TaiKhoan,MatKhau)
VALUES (N'Nguyen Van Than',N'1402'),
		(N'Le Nguyen Tien Phu',N'1234'),
		(N'abc',N'123123')
GO


INSERT INTO ThuongHieu(maThuongHieu,tenThuongHieu,quocGia)
VALUES (N'TH001',N'SamSung',N'Han Quoc'),
		(N'TH002',N'XiaoMi',N'Trung Quoc'),
		(N'TH003',N'Redmi',N'Trung Quoc'),
		(N'TH004',N'Iphone',N'My'),
		(N'TH005',N'Asus',N'Dai Loan'),
		(N'TH006',N'MSI',N'Dai Loan'),
		(N'TH007',N'JBL',N'My')	 ,
		(N'TH008',N'Acer',N'Dai Loan')	 ,
		(N'TH009',N'Lenovo',N'Trung Quoc')	 ,
		(N'TH010',N'HP',N'My') ,
		(N'TH011',N'Dell',N'My')	   ,
		(N'TH012',N'Oppo',N'Trung Quoc')  ,
		(N'TH013',N'Vivo',N'Trung Quoc')	  ,
		(N'TH014',N'Intel',N'My')	,
		(N'TH015',N'GigaByte',N'Dai Loan')	 ,
		(N'TH016',N'CorSair',N'My')	  ,
		(N'TH017',N'Kingston',N'My')	 ,
		(N'TH018',N'Sony',N'Nhat Ban')	 ,
		(N'TH019',N'MarShall',N'Anh') ,
		(N'TH020',N'Realme',N'Trung Quoc')
GO


INSERT INTO LoaiSP(maLoai,tenLoai,moTa)
VALUES (N'LSP001',N'Dien Thoai Di Dong',N'Dien Thoai Di Dong Thong Minh Gia Uu Dai'),
		(N'LSP002',N'LapTop',N'LapTop Sinh Vien Cau Hinh Cao, Thoai Mai Hoc Tap'),
		(N'LSP003',N'Linh Kien Dien Tu',N'Linh Kien Thay The Cho Cac Thiet Bi Dien Tu Bi Hu Hong'),
		(N'LSP004',N'Do Dung Gia Dung',N'Gom Cac San Pham Phuc Vu Cho Nhu Cau Gia Dinh'),
		(N'LSP005',N'Loa',N'Loa Hay Chat Am Tot, Thoai Mai The Hien Chat Toi'),
		(N'LSP006',N'Tai Nghe',N'Tai Nghe Tre Trung Nho Gon Va Hien Dai')
GO


INSERT INTO SanPham (maSP, tenSP, moTa, Gia, maThuongHieu,maLoai,soLuongTrongKho,NgayNhap,Anh)
VALUES (N'SP001', N'Iphone 15 Pro Max', N'512GB, mau sac titan trang', 25900000, N'TH004',N'LSP001',23,'2024/01/05',N'D:\img\ip15prm.jpg'),
		(N'SP002', N'LapTop Asus Tuf Dash F15', N'core i7 Gen 11', 37900000, N'TH005',N'LSP002',14,'2024/04/28',N'D:\img\tufdashf15.jpg'),
		(N'SP003', N'Xiaomi Mi 13T Pro', N'512GB, mau sac xanh reu', 14900000, N'TH002',N'LSP001',23,'2024/04/28',N'D:\img\13tpro.png'),
		(N'SP004', N'SamSung Galaxy S24 Ultra 5G', N'1TB, man hinh 2K+', 38590000, N'TH001',N'LSP001',23,'2024/03/11',N'D:\img\samsung-galaxy-s24-ultra-vang-1.jpg'),
		(N'SP005', N'MSI Gaming Stealth 16 AI Studio A1VGG Ultra 9 185H', N'2TB SSD, 32GB RAM', 64990000, N'TH006',N'LSP002',23,'2024/03/11',N'D:\img\80528_laptop_msi_gaming_stealth_16_ai_studio__a1vgg_089vn___4_.jpg'),
		(N'SP006', N'AirPods Pro Gen 2', N'USB-C', 25900000, N'TH004',N'LSP006',23,'2024/01/05',N'D:\img\AirPods Pro Gen 2.jpg'),
		(N'SP007', N'Loa Bluetooth JBL Pulse 5', N'IP 67, 40W', 5490000, N'TH007',N'LSP005',23,'2024/02/16',N'D:\img\jbl.jpg')	 ,
		(N'SP008', N'Laptop Acer Gaming Aspire 5 A515 58GM 53PZ', N'i5 13420H/8GB/512GB/4GB RTX2050/Win11', 15990000, N'TH008',N'LSP002',23,'2024/02/16',N'D:\img\acer-aspire-a515-58gm-53pz-i5-nxkq4sv008-2.jpg')  ,
		(N'SP009', N'Laptop Acer Gaming Aspire 5 A515 58GM 51LB', N'i5 13420H/16GB/512GB/4GB RTX2050/Win11', 16990000, N'TH008',N'LSP002',23,'2024/02/16',N'D:\img\acer-aspire-a515-58gm-53pz-i5-nxkq4sv008-2.jpg'),
		(N'SP010', N'Laptop HP Gaming VICTUS 15 fa1139TX', N'i5 12450H/16GB/512GB/4GB RTX2050/144Hz/Win11', 19290000, N'TH008',N'LSP002',23,'2024/02/16',N'D:\img\6571_53322_laptop_hp_gaming_victus_15_fa1139tx_2.jpg'),
		(N'SP011', N'Laptop MSI Gaming GF63 Thin 12UCX', N'i5 12450H/16GB/512GB/4GB RTX2050/144Hz/Win11', 16990000, N'TH006',N'LSP002',23,'2024/02/16',N'D:\img\56 (2)-1100x1100w.png'),
		(N'SP012', N'Laptop Lenovo LOQ Gaming 15IAX9', N'i5 12450HX/16GB/512GB/6GB RTX3050/144Hz/Win11', 21490000, N'TH009',N'LSP002',23,'2024/02/16',N'D:\img\51zAVEyzvcL._AC_.jpg'),
		(N'SP013', N'Laptop Acer Gaming Nitro 5 Tiger AN515 58 769J', N'i7 12700H/8GB/512GB/4GB RTX3050/144Hz/Win11', 21990000, N'TH008',N'LSP002',23,'2024/02/16',N'D:\img\vk42qIQR.jpg'),
		(N'SP014', N'Laptop Asus TUF Gaming F15 FX507ZC4', N'i5 12500H/16GB/1TB/4GB RTX3050/144Hz/Win11', 21990000, N'TH005',N'LSP002',23,'2024/02/16',N'D:\img\OIP.jpg'),
		(N'SP015', N'Laptop MSI Gaming GF63 Thin 12UC', N'Laptop MSI Gaming GF63 Thin 12UC', 18990000, N'TH006',N'LSP002',23,'2024/02/16',N'D:\img\pc-portable-msi-gaming-katana-i7-12gen-8go-512go-ssd-rtx-4050-6g-9s7-158571-640.jpg'),
		(N'SP016', N'Laptop HP Gaming VICTUS 15 fa1139TX', N'i5 12450H/16GB/512GB/4GB RTX2050/144Hz/Win11', 19290000, N'TH010',N'LSP002',23,'2024/02/16',N'D:\img\43834_laptop_hp_victus_15_fa0115tx_7c0x1pa_anphatpc6.jpg'),
		(N'SP017', N'Laptop HP Gaming VICTUS 16 s0077AX', N'R7 7840HS/16GB/512GB/144Hz/6GB RTX3050/Win11', 24090000, N'TH010',N'LSP002',23,'2024/02/16',N'D:\img\1699416099-hp-gaming-victus-16-s0077ax-r7-8c5n6pa-glr-2.jpg'),
		(N'SP018', N'Laptop MSI Gaming GF63 Thin 12VE', N'i5 12450H/8GB/512GB/6GB RTX4050/144Hz/Win11', 21490000, N'TH006',N'LSP002',23,'2024/02/16',N'D:\img\6559385ld.jpg'),
		(N'SP019', N'Laptop gaming Dell G15 5530 i9H161W11GR4060', N'Intel® Core™ i9-13900HX (36 MB cache, 24 cores, 32 threads, up to 5.40 GHz Turbo)', 44990000, N'TH011',N'LSP002',23,'2024/02/16',N'D:\img\dell-inspiron-g15-5530-core-i9-rtx-4060-gaming-laptop-1200px-v1-0001.jpg'),
		(N'SP020', N'Laptop gaming Dell G15 5525 R7H165W11GR3060', N'AMD Ryzen 7 6800H (8C / 16T, 3.2 / 4.7GHz, 4MB L2 / 16MB L3), NVIDIA® GeForce RTX™ 3060 6GB GDDR6', 25990000, N'TH011',N'LSP002',23,'2024/02/16',N'D:\img\R.jpg'),
		(N'SP021', N'Laptop gaming Dell G15 5530 i7H165W11GR4050', N'Intel Core i7-13650HX 24 MB cache, 14 core, up to 4.90 GHz, NVIDIA® GeForce RTX™ 4050 6GB GDDR6', 37990000, N'TH011',N'LSP002',23,'2024/02/16',N'D:\img\dell-gaming-g16-7630-lapvip-5-1679560796.jpg'),
		(N'SP022', N'OPPO Reno11 F 5G', N'8GB/256GB Tim', 8990000, N'TH012',N'LSP001',23,'2024/02/16',N'D:\img\oppo-reno-11f-5g-10.jpg'),
		(N'SP023', N'Xiaomi Redmi Note 13', N'8GB/128GB', 4990000, N'TH002',N'LSP001',23,'2024/02/16',N'D:\img\Xiaomi-Redmi-Note-13-Pro-600x600.png'),
		(N'SP024', N'vivo Y100', N'8GB/256GB', 7690000, N'TH008',N'LSP001',23,'2024/02/16',N'D:\img\61adulQolcL._SL1200_.jpg'),
		(N'SP025', N'Samsung Galaxy A55 5G', N'Super AMOLED 6.6" Full HD+', 9990000, N'TH001',N'LSP001',23,'2024/02/16',N'D:\img\Samsung Galaxy A55 5G.jpg'),
		(N'SP026', N'iPhone 13 5G', N'4GB/128GB', 13990000, N'TH004',N'LSP001',23,'2024/02/16',N'D:\img\6443309_sd.jpg'),
		(N'SP027', N'iPhone 14 Pro Max 5G', N'OLED6.7"Super Retina XDR', 26690000, N'TH004',N'LSP001',23,'2024/02/16',N'D:\img\iPhone 14 Pro Max.jpg')	 ,
		(N'SP028', N'Intel Core i9 14900 / Turbo up to 5.8GHz', N'24 Nhan 32 Luong / 36MB / LGA 1700', 15690000, N'TH014',N'LSP003',23,'2024/02/16',N'D:\img\Intel Core i9 14900.jpg')	,
		(N'SP029', N'GIGABYTE AORUS GeForce RTX 4080 XTREME WATERFORCE 16GB', N'2565 MHz / 9728	/ 22.4 Gbps	/ 16GB / DDR6X', 42990000, N'TH015',N'LSP003',23,'2024/02/16',N'D:\img\GIGABYTE AORUS GeForce RTX 4080 XTREME WATERFORCE 16GB.jpg'),
		(N'SP030', N'ASUS ROG Strix GeForce RTX 4080 OC Edition 16GB', N'2655 MHz / 9728 / 22.4 Gbps', 40990000, N'TH005',N'LSP003',23,'2024/02/16',N'D:\img\ASUS ROG Strix GeForce RTX 4080 OC Edition 16GB.jpg'),
		(N'SP031', N'Intel Core i7 14700K / Turbo up to 5.6GHz', N'20 Nhan 28 Luong / 33MB / LGA 1700', 11890000, N'TH015',N'LSP003',23,'2024/02/16',N'D:\img\Intel Core i7 14700K.jpg'),
		(N'SP032', N'RAM Corsair Dominator Titanium Black 64GB (2x32GB)', N'RGB 6600 DDR5', 9290000, N'TH016',N'LSP003',23,'2024/02/16',N'D:\img\DOMINATOR-TITANIUM-RGB.jpg'),
		(N'SP033', N'Main Board ASUS ROG Strix Z790-E GAMING WIFI II DDR5', N'ATX 12 inch x 9,6 inch (30,5 cm x 24,4 cm)', 13990000, N'TH005',N'LSP003',23,'2024/02/16',N'D:\img\Main Board ASUS ROG Strix Z790-E GAMING WIFI II DDR5.jpg'),
		(N'SP034', N'Main Board GIGABYTE Z790 AORUS XTREME X ICE', N'E-ATX; 30,5cm x 28,5cm', 47990000, N'TH015',N'LSP003',23,'2024/02/16',N'D:\img\Main Board GIGABYTE Z790 AORUS XTREME X ICE.jpg'),
		(N'SP035', N'Corsair HX1500i - 80 Plus Platinum', N'Full Modular (1500W) ', 9490000, N'TH016',N'LSP003',23,'2024/02/16',N'D:\img\Corsair HX1500i - 80 Plus Platinum.jpg'),
		(N'SP036', N'SSD Kingston KC3000 1TB', N'M.2 PCIe gen 4 NVMe', 3990000, N'TH017',N'LSP003',23,'2024/02/16',N'D:\img\SSD Kingston KC3000 1TB.jpg'),
		(N'SP037', N'SSD Samsung 870 EVO', N'500G Sata3', 1790000, N'TH001',N'LSP003',23,'2024/02/16',N'D:\img\SSD Samsung 870 EVO.jpg'),
		(N'SP038', N'Loa Bluetooth JBL Partybox Encore 2Mic', N'100 W', 10390000, N'TH007',N'LSP005',23,'2024/02/16',N'D:\img\p_56592_alta_1.png')	,
		(N'SP039', N'Loa Bluetooth Sony SRS-XB100', N'Bluetooth 5.3', 1290000, N'TH018',N'LSP005',23,'2024/02/16',N'D:\img\31232-loa-bluetooth-sony-srs-xb100-6.png'),
		(N'SP040', N'Loa Bluetooth Marshall Woburn III ', N'150 W', 16190000, N'TH019',N'LSP005',23,'2024/02/16',N'D:\img\R.png'),
		(N'SP041', N'Loa Bluetooth Sony SRS-XP500', N'Bluetooth 5.0', 7290000, N'TH018',N'LSP005',23,'2024/02/16',N'D:\img\loa-bluetooth-sony-srs-xp500-ejee7wat.png'),
		(N'SP042', N'Tai nghe Bluetooth True Wireless realme Buds T110', N'ENC10 mm Dynamic Driver', 690000, N'TH020',N'LSP006',23,'2024/02/16',N'D:\img\Tai nghe Bluetooth True Wireless realme Buds T110.png'),
		(N'SP043', N'Tai nghe Bluetooth True Wireless Xiaomi Redmi Buds 5', N'Dynamic Driver 12.4 mmActive Noise Cancelling', 990000, N'TH002',N'LSP006',23,'2024/02/16',N'D:\img\51HhYD53fML.jpg'),
		(N'SP044', N'Tai nghe Bluetooth Out Ear Marshall Monitor II A.N.C.', N'Marshall Signature SoundDriver 40 mm', 7190000, N'TH019',N'LSP006',23,'2024/02/16',N'D:\img\Tai nghe Bluetooth Out Ear Marshall Monitor II A.N.C..jpg'),
		(N'SP045', N'Tai nghe Bluetooth True Wireless OPPO Enco Buds 2 Pro E510A', N'Dynamic Driver 12.4 mmDolby AtmosDirac Audio Tuner', 1290000, N'TH012',N'LSP006',23,'2024/02/16',N'D:\img\1677849999-product-images-black-45side-450-rgb.jpg')

GO


INSERT INTO KhachHang (maKH, tenKH, gioiTinh, diaChi, SDT)
VALUES (N'KH001', N'Nguyen Van A', N'Nam', N'Ha Noi', N'0123456789'),
        (N'KH002', N'Tran Thanh Teo', N'Nam', N'Tp Ho Chi Minh', N'8379120391'),
        (N'KH003', N'Le Tran Viet Tien', N'Nam', N'Can Tho', N'7389178923'),
        (N'KH004', N'Dao Duc Ninh', N'Nam', N'Da Nang', N'8039213312'),
        (N'KH005', N'Pham Thanh Ngan', N'Nu', N'Binh Duong', N'738291321');
GO


INSERT INTO NhanVien (maNV, tenNV, gioiTinh, ngaySinh, SDT, luong, diaChi)
VALUES (N'NV001', N'Hoang Van Viet', N'Nam', '1996-04-01', '0123456789', 6000000, N'Ha Noi'),
        (N'NV002', N'Le Thi Binh', N'Nu', '1997-04-02', '0123456789', 5500000, N'Ho Chi Minh'),
        (N'NV003', N'Tran Quoc Cuong', N'Nam', '1998-04-03', '0123456789', 6500000, N'Hai Phong'),
        (N'NV004', N'Pham Thi Dong Anh', N'Nu', '1999-04-04', '0123456789', 5800000, N'Da Nang'),
        (N'NV005', N'Vo Thi Phuong Thi', N'Nu', '2000-04-05', '0123456789', 7000000, N'Can Tho');
GO


INSERT INTO ChiNhanh(maChiNhanh, tenChiNhanh, diaChi, SDT)
VALUES ('CN001', N'Chi nhanh Ha Noi', N'123 duong ABC, Ha Noi', '0123456789'),
		('CN002', N'Chi nhanh TP.HCM', N'456 duong XYZ, TP.HCM', '0987654321'),
		('CN003', N'Chi nhanh Da Nang', N'789 duong DEF, Da Nang', '0369841572'),
		('CN004', N'Chi nhanh Hai Phong', N'101 duong GHI, Hai Phong', '0928374651'),
		('CN005', N'Chi nhanh Can Tho', N'246 duong KLM, Can Tho', '0857361948')
GO


INSERT INTO DonHang (maDonHang, maKH, ngayMua, tongDonHang, tinhTrangDatHang, phuongThucThanhToan, maSP, soLuong, giaTungSP, phanTramGiamGia, maChiNhanh, maNV)
VALUES 
(N'DH001', N'KH001', '2024-04-01', 25900000, N'Da Giao Hang', N'Thanh Toan Khi Nhan Duoc Hang', N'SP001', 1, 25900000, 0, N'CN001', N'NV001'),
(N'DH002', N'KH002', '2024-04-02', 37900000, N'Da Giao Hang', N'Thanh Toan Khi Nhan Duoc Hang', N'SP002', 1, 37900000, 0, N'CN002', N'NV003'),
(N'DH003', N'KH003', '2024-04-03', 44700000, N'Dang Xu Ly', N'Thanh Toan Qua The', N'SP003', 3, 14900000, 0, N'CN001', N'NV003'),
(N'DH004', N'KH004', '2024-04-04', 38590000, N'Da Giao Hang', N'Thanh Toan Khi Nhan Duoc Hang', N'SP004', 1, 38590000, 3, N'CN003', N'NV004'),
(N'DH005', N'KH005', '2024-04-05', 64990000, N'Da Giao Hang', N'Thanh Toan Khi Nhan Duoc Hang', N'SP005', 1, 64990000, 0, N'CN001', N'NV002'),
(N'DH006', N'KH001', '2024-04-06', 25900000, N'Da Giao Hang', N'Thanh Toan Khi Nhan Duoc Hang', N'SP006', 1, 25900000, 0, N'CN002', N'NV004'),
(N'DH007', N'KH002', '2024-04-07', 87840000, N'Da Giao Hang', N'Thanh Toan Khi Nhan Duoc Hang', N'SP007', 4, 21960000, 6, N'CN003', N'NV004'),
(N'DH008', N'KH003', '2024-04-08', 14900000, N'Da Giao Hang', N'Thanh Toan Khi Nhan Duoc Hang', N'SP003', 1, 14900000, 0, N'CN001', N'NV001'),
(N'DH009', N'KH004', '2024-04-09', 77180000, N'Dang Xu Ly', N'Thanh Toan Qua The', N'SP004', 2, 38590000, 0, N'CN002', N'NV002'),
(N'DH010', N'KH005', '2024-04-10', 64990000, N'Da Giao Hang', N'Thanh Toan Khi Nhan Duoc Hang', N'SP005', 1, 64990000, 12, N'CN001', N'NV005'),
(N'DH011', N'KH001', '2024-04-11', 25900000, N'Da Giao Hang', N'Thanh Toan Khi Nhan Duoc Hang', N'SP006', 1, 25900000, 0, N'CN003', N'NV005'),
(N'DH012', N'KH002', '2024-04-12', 5490000, N'Dang Xu Ly', N'Thanh Toan Bang Tien Mat', N'SP007', 1, 5490000, 0, N'CN002', N'NV003')
GO


INSERT INTO PhieuNhapKho (maPNK, tenSP, ngayNhap, tongDonGia, soLuong, maNV)
VALUES 
('PNK001', N'Iphone 15 Pro Max', '2024-04-01', 129500000, 15, 'NV001'),
('PNK002', N'LapTop Asus Tuf Dash F15', '2024-04-02', 151600000, 12, 'NV002'),
('PNK003', N'Xiaomi Mi 13T Pro', '2024-04-03', 104300000, 11, 'NV004'),
('PNK004', N'SamSung Galaxy S24 Ultra 5G', '2024-04-04', 143000000, 14, 'NV003'),
('PNK005', N'MSI Gaming Stealth 16 AI Studio A1VGG Ultra 9 185H', '2024-04-05', 278700000, 17, 'NV005');
GO


--INSERT INTO Voucher (maVoucher, maDonHang, maSP, ma, phanTramGiamGia, ngayHetHan)
--VALUES 
--(N'VOUCHER001', NULL, NULL, N'DMM123123', 10, '2024-06-30'),
--(N'VOUCHER002', NULL, NULL, N'DMM456456', 15, '2024-06-30'),
--(N'VOUCHER003', NULL, NULL, N'DMM789789', 20, '2024-06-30'),
--(N'VOUCHER004', NULL, NULL, N'DMM987987', 25, '2024-06-30'),
--(N'VOUCHER005', NULL, NULL, N'DMM654654', 30, '2024-06-30');
--GO


select * from ThuongHieu
select * from LoaiSP
select * from SanPham
select * from KhachHang
select * from NhanVien
select * from ChiNhanh
select * from DonHang
select * from PhieuNhapKho
--select * from Voucher
select * from DangNhap


-- Store Procedures


-- Tim kiem san pham theo loai
CREATE PROCEDURE TimKiemSanPhamTheoLoai
    @MaLoai NVARCHAR(20)
AS
BEGIN
    SELECT SP.maSP, SP.tenSP, SP.moTa, SP.Gia, SP.maThuongHieu, SP.maLoai, SP.soLuongTrongKho, SP.NgayNhap, SP.Anh
    FROM SanPham SP
    WHERE SP.maLoai = @MaLoai;
END
GO

-- Hien thi danh sach san pham da mua cua khach hang
CREATE PROCEDURE DanhSachSanPhamDaMua
    @MaKH NVARCHAR(20)
AS
BEGIN
    SELECT DH.maSP, SP.tenSP, DH.soLuong, DH.giaTungSP, DH.ngayMua, DH.maKH
    FROM DonHang DH
    INNER JOIN SanPham SP ON DH.maSP = SP.maSP
    WHERE DH.maKH = @MaKH;
END
GO

-- Hien thi danh sach san pham ma nhan vien suat don
CREATE PROCEDURE DanhSachSanPhamDaBan
    @MaNV NVARCHAR(20)
AS
BEGIN
    SELECT DH.maSP, SP.tenSP, DH.soLuong, DH.giaTungSP, DH.ngayMua, DH.maNV
    FROM DonHang DH
    INNER JOIN SanPham SP ON DH.maSP = SP.maSP
    WHERE DH.maNV = @MaNV;
END
GO

-- Hien thi danh sach san pham theo gia
CREATE PROCEDURE DanhSachSanPhamTheoGia
    @GiaMin FLOAT,
    @GiaMax FLOAT
AS
BEGIN
    SELECT *
    FROM SanPham
    WHERE Gia BETWEEN @GiaMin AND @GiaMax;
END
GO

-- HIen thi danh sach thuong hieu theo quoc gia
CREATE PROCEDURE DanhSachThuongHieuTheoQuocGia
    @QuocGia NVARCHAR(255)
AS
BEGIN
    SELECT *
    FROM ThuongHieu
    WHERE quocGia = @QuocGia;
END
GO

-- Hien thi danh sach san pham theo ngay nhap
CREATE PROCEDURE DanhSachSanPhamTheoNgayNhap
    @NgayBatDau DATE,
    @NgayKetThuc DATE
AS
BEGIN
    SELECT *
    FROM SanPham
    WHERE NgayNhap BETWEEN @NgayBatDau AND @NgayKetThuc;
END
GO

-- Hien thi danh sach don hang theo tong don hang
CREATE PROCEDURE HienThiDSDonHangTheoTongDonHang
    @TongDonHangMin FLOAT,
    @TongDonHangMax FLOAT
AS
BEGIN
    SELECT *
    FROM DonHang
    WHERE tongDonHang BETWEEN @TongDonHangMin AND @TongDonHangMax;
END
GO

-- Hien thi danh sach san pham nhap kho theo nhan vien
CREATE PROCEDURE HienThiSanPhamNhapKhoTheoNhanVien
    @MaNV NVARCHAR(20)
AS
BEGIN
    SELECT *
    FROM PhieuNhapKho
    WHERE maNV = @MaNV;
END
GO
