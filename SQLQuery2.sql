-- Tạo cơ sở dữ liệu Shoes
CREATE DATABASE SHOESSHOP2;
GO

-- Sử dụng cơ sở dữ liệu Shoes
USE SHOESSHOP;
GO

-- Xóa bảng nếu đã tồn tại
DROP TABLE IF EXISTS MauSanPham;
DROP TABLE IF EXISTS SizeSanPham;
DROP TABLE IF EXISTS SanPham;
DROP TABLE IF EXISTS ShoeSales;
DROP TABLE IF EXISTS ShoeStock;
DROP TABLE IF EXISTS ShoeInventory;
-- Tạo bảng Shoes
CREATE TABLE SanPham (
    IDSanPham INT PRIMARY KEY IDENTITY(1,1),
    TenSanPham NVARCHAR(100) NOT NULL,
    ThuongHieu NVARCHAR(100) NOT NULL,
	Loai NVARCHAR(100) NOT NULL,
    Gia DECIMAL(10, 2) NOT NULL,
	 enable BIT NOT NULL DEFAULT 1
);

-- Tạo bảng ShoeSizes
CREATE TABLE SizeSanPham (
    IDSize INT PRIMARY KEY IDENTITY(1,1),
    IDSanPham INT NOT NULL,
    Size INT NOT NULL,
    FOREIGN KEY (IDSanPham) REFERENCES SanPham(IDSanPham)
);

-- Tạo bảng ShoeColors
CREATE TABLE MauSanPham (
    IDMau INT PRIMARY KEY IDENTITY(1,1),
    IDSanPham INT NOT NULL,
    Mau NVARCHAR(50) NOT NULL,
    FOREIGN KEY (IDSanPham) REFERENCES SanPham(IDSanPham)
);
--Bang Kho SanPham--
CREATE TABLE ShoeInventory (
    IDSanPham INT NOT NULL,
    IDSize INT NOT NULL,
    IDMau INT NOT NULL,
    Quantity INT NOT NULL, 
    PRIMARY KEY (IDSanPham, IDSize, IDMau),
    FOREIGN KEY (IDSanPham) REFERENCES SanPham(IDSanPham),
    FOREIGN KEY (IDSize) REFERENCES SizeSanPham(IDSize),
    FOREIGN KEY (IDMau) REFERENCES MauSanPham(IDMau)
);
-- Bảng NhaCungCap
CREATE TABLE NhaCungCap (
    idNCC INT PRIMARY KEY IDENTITY(1,1),
    tenNCC NVARCHAR(100) NOT NULL,
    soDT NVARCHAR(15),
    email NVARCHAR(100),
    diaChi NVARCHAR(255),
    tinhTrangNhap NVARCHAR(100)
);

-- Bảng NhapKho
CREATE TABLE NhapKho (
    idNhapKho INT PRIMARY KEY IDENTITY(1,1),
    idNCC INT NOT NULL,
    idNV INT NOT NULL,
    ngayNhapKho DATE,
    thanhTien DECIMAL(18, 2),
    enable BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_NhapKho_NhaCungCap FOREIGN KEY (idNCC) REFERENCES NhaCungCap(idNCC)
);

-- Bảng ChiTietNhapKho
CREATE TABLE ChiTietNhapKho (
    idChiTietNhapKho INT PRIMARY KEY IDENTITY(1,1),
    idNhapKho INT NOT NULL,
    idSanPham INT NOT NULL,
    soLuong INT NOT NULL,
    giaNhap DECIMAL(18, 2) NOT NULL,
    enable BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_ChiTietNhapKho_NhapKho FOREIGN KEY (idNhapKho) REFERENCES NhapKho(idNhapKho),
    CONSTRAINT FK_ChiTietNhapKho_SanPham FOREIGN KEY (idSanPham) REFERENCES SanPham(IDSanPham)
);
-- Bảng KhachHang

DROP TABLE KhachHang
-----------------
CREATE TABLE KhachHang (
    idKhachHang INT PRIMARY KEY IDENTITY(1,1),
    tenKhachHang NVARCHAR(100) NOT NULL,
    soDT NVARCHAR(15),
    diaChi NVARCHAR(255),
    enable BIT NOT NULL DEFAULT 1
);
-- Bảng NhanVien
CREATE TABLE NhanVien (
    idNhanVien INT PRIMARY KEY IDENTITY(1,1),
    tenNhanVien NVARCHAR(100) NOT NULL,
    soDT NVARCHAR(15),
    email NVARCHAR(100),
    tenDangNhap NVARCHAR(100) NOT NULL,
    matKhau NVARCHAR(255) NOT NULL,
    ngayVaoLam DATE,
    viTriCongViec NVARCHAR(100),
    enable BIT NOT NULL DEFAULT 1
);
---Bang Hoa Don---
CREATE TABLE HoaDon (
    idHoaDon INT PRIMARY KEY IDENTITY(1,1),
    idKhachHang INT NOT NULL,
    idNhanVien INT NOT NULL,
    ngayInHoaDon DATE,
    giamGia DECIMAL(18, 2),
    phiShip DECIMAL(18, 2),
    tienThue DECIMAL(18, 2),
    thanhTien DECIMAL(18, 2),
    trangThai NVARCHAR(50),
    enable BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_HoaDon_KhachHang FOREIGN KEY (idKhachHang) REFERENCES KhachHang(idKhachHang),
    CONSTRAINT FK_HoaDon_NhanVien FOREIGN KEY (idNhanVien) REFERENCES NhanVien(idNhanVien)
);
-- Bảng ChiTietHoaDon
CREATE TABLE ChiTietHoaDon (
    idChiTietHoaDon INT PRIMARY KEY IDENTITY(1,1),
    idHoaDon INT NOT NULL,
    idSanPham INT NOT NULL,
    soLuong INT NOT NULL,
    donGia DECIMAL(18, 2) NOT NULL,
    enable BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_ChiTietHoaDon_HoaDon FOREIGN KEY (idHoaDon) REFERENCES HoaDon(idHoaDon),
    CONSTRAINT FK_ChiTietHoaDon_SanPham FOREIGN KEY (idSanPham) REFERENCES SanPham(idSanPham)
);
-- Thêm dữ liệu vào bảng SanPham
INSERT INTO SanPham(TenSanPham, ThuongHieu,Loai, Gia) VALUES
('Air Max 90', 'Nike','Sport', 150.00),
('UltraBoost', 'Adidas','Walking', 180.00),
('Classic Slip-On', 'Vans','Soccer', 60.00);

-- Thêm dữ liệu vào bảng ShoeSizes
INSERT INTO SizeSanPham(IDSanPham, Size) VALUES
(1, 38), (1, 39), (1, 40), -- Sizes for Air Max 90
(2, 40), (2, 41), (2, 42), -- Sizes for UltraBoost
(3, 37), (3, 38), (3, 39); -- Sizes for Classic Slip-On

-- Thêm dữ liệu vào bảng ShoeColors
INSERT INTO MauSanPham(IDSanPham, Mau) VALUES
(1, 'Red'), (1, 'Black'), -- Colors for Air Max 90
(2, 'White'), (2, 'Blue'), -- Colors for UltraBoost
(3, 'Black'), (3, 'Checkerboard'); -- Colors for Classic Slip-On

--Bang sale--


 ---bang stock--

 SELECT 
     S.IDSanPham,
     S.TenSanPham AS ShoeName,
     S.ThuongHieu,
     S.Gia,
     SS.Size AS ShoeSize,
     SC.Mau AS ShoeColor
 FROM SanPham S
 LEFT JOIN SizeSanPham SS ON S.IDSanPham = SS.IDSanPham
 LEFT JOIN MauSanPham SC ON S.IDSanPham = SC.IDSanPham;

 select * from SanPham

 

--Tim so con lai trong kho--

--Xuat kho--

--Truy van--

---Quan ly giay trong kho--

-- Thêm giày vào kho với mỗi size và mỗi màu
INSERT INTO ShoeInventory (IDSanPham, IDSize, IDMau, Quantity)
VALUES
(1, 1, 1, 50),  -- 50 đôi giày Air Max 90, size 38, màu đỏ
(1, 2, 1, 30),  -- 30 đôi giày Air Max 90, size 39, màu đỏ
(2, 1, 2, 100), -- 100 đôi giày UltraBoost, size 40, màu trắng
(3, 1, 3, 200); -- 200 đôi giày Classic Slip-On, size 37, màu đen



DROP PROCEDURE dbo.UpdateShoeInventory;

---  CẬP NHẬT GIÀY TRONG KHO---
CREATE PROCEDURE UpdateShoeInventory
    @ShoeID INT,
    @ShoeSizeID INT,
    @ShoeColorID INT,
    @QuantityChange INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra nếu tồn tại giày với các thông tin đầu vào
    IF EXISTS (
        SELECT 1
        FROM ShoeInventory
        WHERE IDSanPham = @ShoeID AND IDSize = @ShoeSizeID AND IDMau = @ShoeColorID
    )
    BEGIN
        -- Cập nhật số lượng giày
        UPDATE ShoeInventory
        SET Quantity = Quantity + @QuantityChange
        WHERE IDSanPham = @ShoeID AND IDSize = @ShoeSizeID AND IDMau = @ShoeColorID;

        -- Kiểm tra nếu số lượng sau khi cập nhật nhỏ hơn 0
        IF EXISTS (
            SELECT 1
            FROM ShoeInventory
            WHERE IDSanPham = @ShoeID AND IDSize = @ShoeSizeID AND IDMau = @ShoeColorID AND Quantity < 0
        )
        BEGIN
            -- Rollback số lượng về 0 và báo lỗi
            UPDATE ShoeInventory
            SET Quantity = 0
            WHERE IDSanPham = @ShoeID AND IDSize = @ShoeSizeID AND IDMau = @ShoeColorID;

            PRINT 'Số lượng không thể nhỏ hơn 0. Số lượng đã được đặt lại về 0.';
        END
        ELSE
        BEGIN
            PRINT 'Cập nhật số lượng thành công.';
        END
    END
    ELSE
    BEGIN
        PRINT 'Không tìm thấy sản phẩm với thông tin đã cung cấp.';
    END
END;

DROP PROCEDURE dbo.UpdateShoeInventory1;
      
---Cap nhat kho---
CREATE PROCEDURE UpdateShoeInventory1
    @ShoeID INT,
    @ShoeSize NVARCHAR(50),
    @ShoeColor NVARCHAR(50),
    @QuantityChange INT
AS
BEGIN
    UPDATE ShoeInventory
    SET Quantity = Quantity - @QuantityChange
    FROM ShoeInventory SI
    JOIN SizeSanPham SS ON SI.IDSize = SS.IDSize
    JOIN MauSanPham SC ON SI.IDMau = SC.IDMau
    WHERE SI.IDSanPham = @ShoeID AND SS.Size = @ShoeSize AND SC.Mau = @ShoeColor;
END;

--Test Select * SanPham trong kho---
        SELECT 
    S.IDSanPham,
    S.TenSanPham AS ShoeName,
    S.ThuongHieu,
    S.Gia,
    SS.Size AS ShoeSize,
    SC.Mau AS ShoeColor,
    SI.Quantity
FROM ShoeInventory SI
JOIN SanPham S ON SI.IDSanPham = S.IDSanPham
JOIN SizeSanPham SS ON SI.IDSize = SS.IDSize
JOIN MauSanPham SC ON SI.IDMau = SC.IDMau;

------------CODE của Lâm----------
INSERT INTO NhaCungCap (tenNCC, soDT, email, diaChi, tinhTrangNhap) 
VALUES 
(N'Nhà cung cấp A', '0901234567', N'nccA@gmail.com', N'123 Đường A, Quận 1', N'Đang cung cấp'),
(N'Nhà cung cấp B', '0912345678', N'nccB@gmail.com', N'456 Đường B, Quận 2', N'Tạm dừng cung cấp'),
(N'Nhà cung cấp C', '0901232322', N'nccc@gmail.com', N'432 Đường C, Quận 1', N'Đang cung cấp'),
(N'Nhà cung cấp D', '0912332232', N'nccd@gmail.com', N'542 Đường D, Quận 2', N'Đang cung cấp');

INSERT INTO KhachHang (tenKhachHang, soDT, diaChi) 
VALUES 
(N'Nguyễn Văn A', '0123456789', N'Quận 1, TP.HCM'),
(N'Trần Thị B', '0987654321',  N'Quận 3, TP.HCM'),
(N'Lê Văn C', '0912345678',  N'Quận 7, TP.HCM');

set dateformat dmy 
---HAM 2-- CHAY DUOC---
DROP PROCEDURE dbo.UpdateShoeInventory1;
      
---Cap nhat kho---
CREATE PROCEDURE UpdateShoeInventory1
    @ShoeID INT,
    @ShoeSize NVARCHAR(50),
    @ShoeColor NVARCHAR(50),
    @QuantityChange INT
AS
BEGIN
    UPDATE ShoeInventory
    SET Quantity = Quantity - @QuantityChange
    FROM ShoeInventory SI
    JOIN SizeSanPham SS ON SI.IDSize = SS.IDSize
    JOIN MauSanPham SC ON SI.IDMau = SC.IDMau
    WHERE SI.IDSanPham = @ShoeID AND SS.Size = @ShoeSize AND SC.Mau = @ShoeColor;
END;

go
INSERT INTO NhanVien (tenNhanVien, soDT, email, tenDangNhap, matKhau, ngayVaoLam, viTriCongViec) 
VALUES 
(N'Nguyễn Văn D', '0909876543', N'nguyenvand@example.com', 'vand', '123456', '15/11/2024', N'Nhân viên bán hàng'),
(N'Trần Thị E', '0918765432', N'tranthie@example.com', 'thie', '123456', '20/11/2024', N'Quản lý kho');

set dateformat dmy 
go
INSERT INTO HoaDon (idKhachHang, idNhanVien, ngayInHoaDon, giamGia, phiShip, tienThue, thanhTien, trangThai) 
VALUES 
(1, 1, '25/11/2024', 50000, 30000, 70000, 2570000, N'Đã thanh toán'),
(2, 1, '26/11/2024', 0, 20000, 60000, 5060000, N'Đã thanh toán');

INSERT INTO ChiTietHoaDon (idHoaDon, idSanPham, soLuong, donGia) 
VALUES 
(1, 1, 1, 3500000),
(2, 2, 1, 3000000);

set dateformat dmy 
go
INSERT INTO NhapKho (idNCC, idNV, ngayNhapKho, thanhTien) 
VALUES 
(1, 2, '01/11/2024', 15000000),
(1, 2, '05/11/2024', 80000000);
SELECT * FROM NhapKho;

INSERT INTO ChiTietNhapKho (idNhapKho, idSanPham, soLuong, giaNhap) 
VALUES 
(1, 1, 20, 2800000),
(1, 2, 15, 2500000),
(2, 3, 30, 1800000);

---------------------------------------------------------------------

SELECT * FROM NhapKho;
SELECT * FROM ChiTietNhapKho;
SELECT * FROM NhaCungCap;
SELECT * FROM SanPham;

--IF OBJECT_ID('sp_ThemSuaNhaCungCap', 'P') IS NOT NULL
--DROP PROCEDURE sp_ThemSuaNhaCungCap;
--GO

--CREATE PROCEDURE sp_ThemSuaNhaCungCap
--    @idNCC INT,
--    @tenNCC NVARCHAR(100),
--    @soDT NVARCHAR(15),
--    @email NVARCHAR(100),
--    @diaChi NVARCHAR(200),
--	@tinhTrangNhap NVARCHAR(200)
--AS
--BEGIN
--    IF @idNCC > 0
--    BEGIN
--        UPDATE NhaCungCap
--        SET tenNCC = @tenNCC, soDT = @soDT, email = @email, diaChi = @diaChi, tinhTrangNhap = @tinhTrangNhap
--        WHERE idNCC = @idNCC;
--    END
--    ELSE
--    BEGIN
--        INSERT INTO NhaCungCap (tenNCC, soDT, email, diaChi, tinhTrangNhap)
--        VALUES (@tenNCC, @soDT, @email, @diaChi, @tinhTrangNhap);
--    END
--END;

CREATE PROCEDURE sp_SuaLuuNhaCungCap
    @idNCC INT = NULL, -- ID nhà cung cấp (NULL khi thêm mới)
    @tenNCC NVARCHAR(100),
    @soDT NVARCHAR(15),
    @email NVARCHAR(100),
    @diaChi NVARCHAR(255),
    @tinhTrangNhap NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra xem idNCC có tồn tại hay không
    IF EXISTS (SELECT 1 FROM NhaCungCap WHERE idNCC = @idNCC)
    BEGIN
        -- Nếu tồn tại, thực hiện UPDATE
        UPDATE NhaCungCap
        SET 
            tenNCC = @tenNCC,
            soDT = @soDT,
            email = @email,
            diaChi = @diaChi,
            tinhTrangNhap = @tinhTrangNhap
        WHERE idNCC = @idNCC;
    END
    ELSE
    BEGIN
        -- Nếu không tồn tại, thực hiện INSERT
        INSERT INTO NhaCungCap (tenNCC, soDT, email, diaChi, tinhTrangNhap)
        VALUES (@tenNCC, @soDT, @email, @diaChi, @tinhTrangNhap);
    END
END;
GO

--IF OBJECT_ID('sp_ThongKeHoaDonNhap', 'P') IS NOT NULL
--DROP PROCEDURE sp_ThongKeHoaDonNhap;
--GO

--CREATE PROCEDURE sp_ThongKeHoaDonNhap
--    @idNCC INT,
--    @tuNgay DATE,
--    @denNgay DATE
--AS
--BEGIN
--    -- Lấy danh sách hóa đơn nhập kho
--    SELECT nk.idNhapKho, nk.ngayNhapKho, nk.thanhTien
--    FROM NhapKho nk
--    WHERE nk.idNCC = @idNCC AND nk.ngayNhapKho BETWEEN @tuNgay AND @denNgay;

--    -- Thống kê tổng số đơn hàng và tổng tiền
--    SELECT 
--        COUNT(*) AS tongSoDon,
--        SUM(nk.thanhTien) AS tongTien
--    FROM NhapKho nk
--    WHERE nk.idNCC = @idNCC AND nk.ngayNhapKho BETWEEN @tuNgay AND @denNgay;
--END;

--CREATE PROCEDURE sp_LayDanhSachMaGiay
--    @idNCC INT
--AS
--BEGIN
--    -- Lấy danh sách giày cung cấp từ nhà cung cấp
--    SELECT DISTINCT 
--        ct.idSanPham, 
--        sp.tenSanPham, 
--        sp.giaBan 
--    FROM ChiTietNhapKho ct
--    INNER JOIN SanPham sp ON ct.idSanPham = sp.idSanPham
--    INNER JOIN NhapKho nk ON ct.idNhapKho = nk.idNhapKho
--    WHERE nk.idNCC = @idNCC;  -- Lọc theo idNCC từ bảng NhapKho
--END;

--select *
--from NhapKho
select * from SanPham
 SELECT 
     S.IDSanPham,
     S.TenSanPham,
     S.ThuongHieu,
     S.Loai,
     S.Gia,
     SS.Size,
     SC.Mau,
     SI.Quantity,
	 S.enable
 FROM ShoeInventory SI
 JOIN SanPham S ON SI.IDSanPham = S.IDSanPham
 JOIN SizeSanPham SS ON SI.IDSize = SS.IDSize
 JOIN MauSanPham SC ON SI.IDMau = SC.IDMau;

 CREATE TABLE Hoadon1 (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NgayLap DATETIME,
    TongTien DECIMAL(18, 2),
    TinhTrang NVARCHAR(50)
);
INSERT INTO Hoadon1 (NgayLap, TongTien, TinhTrang)
VALUES ('2024-11-28', 150000, 'Chưa thanh toán'),
       ('2024-11-29', 200000, 'Chưa thanh toán'),
       ('2024-11-30', 50000, 'Đã thanh toán');
	   SELECT * FROM Hoadon;
	   SELECT * FROM Hoadon1;

	  
 CREATE TABLE HoaDon (
    IDHoaDon INT IDENTITY(1,1) PRIMARY KEY,
    NgayBan DATETIME,
    TongTien DECIMAL(18, 2),
    TinhTrang NVARCHAR(50)
);

INSERT INTO dbo.HoaDon
(
    NgayBan,
    TongTien,
    TinhTrang
)
VALUES
('2024-11-28', 150000, 'Chưa thanh toán'),
       ('2020-1-29', 200000, 'Chưa thanh toán'),
       ('2025-3-30', 50000, 'Đã thanh toán');

SELECT DB_NAME() AS CurrentDatabase;

SELECT IDHoaDon, NgayBan, TongTien FROM HoaDon
SELECT FORMAT(NgayBan, 'MM/yyyy') AS Thang, SUM(TongTien) AS TongDoanhThu FROM HoaDon GROUP BY FORMAT(NgayBan, 'MM/yyyy') ORDER BY FORMAT(NgayBan, 'MM/yyyy')