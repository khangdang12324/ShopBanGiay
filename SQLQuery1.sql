-- Tạo cơ sở dữ liệu Shoes


-- Sử dụng cơ sở dữ liệu Shoes
USE SHOESSHOP;
GO

-- Xóa bảng nếu đã tồn tại
DROP TABLE IF EXISTS ShoeColors;
DROP TABLE IF EXISTS ShoeSizes;
DROP TABLE IF EXISTS Shoes;

-- Tạo bảng Shoes
CREATE TABLE Shoes (
    ShoeID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Brand NVARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL
);

-- Tạo bảng ShoeSizes
CREATE TABLE ShoeSizes (
    ShoeSizeID INT PRIMARY KEY IDENTITY(1,1),
    ShoeID INT NOT NULL,
    Size INT NOT NULL,
    FOREIGN KEY (ShoeID) REFERENCES Shoes(ShoeID)
);

-- Tạo bảng ShoeColors
CREATE TABLE ShoeColors (
    ShoeColorID INT PRIMARY KEY IDENTITY(1,1),
    ShoeID INT NOT NULL,
    Color NVARCHAR(50) NOT NULL,
    FOREIGN KEY (ShoeID) REFERENCES Shoes(ShoeID)
);

-- Thêm dữ liệu vào bảng Shoes
INSERT INTO Shoes (Name, Brand, Price) VALUES
('Air Max 90', 'Nike', 150.00),
('UltraBoost', 'Adidas', 180.00),
('Classic Slip-On', 'Vans', 60.00);

-- Thêm dữ liệu vào bảng ShoeSizes
INSERT INTO ShoeSizes (ShoeID, Size) VALUES
(1, 38), (1, 39), (1, 40), -- Sizes for Air Max 90
(2, 40), (2, 41), (2, 42), -- Sizes for UltraBoost
(3, 37), (3, 38), (3, 39); -- Sizes for Classic Slip-On

-- Thêm dữ liệu vào bảng ShoeColors
INSERT INTO ShoeColors (ShoeID, Color) VALUES
(1, 'Red'), (1, 'Black'), -- Colors for Air Max 90
(2, 'White'), (2, 'Blue'), -- Colors for UltraBoost
(3, 'Black'), (3, 'Checkerboard'); -- Colors for Classic Slip-On

--Bang sale--
DROP TABLE ShoeSales
CREATE TABLE ShoeSales (
    ShoeID INT NOT NULL,
    ShoeSizeID INT NOT NULL,
    ShoeColorID INT NOT NULL,
    QuantitySold INT NOT NULL,  -- Số lượng bán
    SaleDate DATETIME NOT NULL,  -- Ngày bán
    PRIMARY KEY (ShoeID, ShoeSizeID, ShoeColorID, SaleDate),
    FOREIGN KEY (ShoeID) REFERENCES Shoes(ShoeID),
    FOREIGN KEY (ShoeSizeID) REFERENCES ShoeSizes(ShoeSizeID),
    FOREIGN KEY (ShoeColorID) REFERENCES ShoeColors(ShoeColorID)
);


  --bang stock--
  DROP TABLE ShoeStock
  CREATE TABLE ShoeStock (
    ShoeID INT NOT NULL,
    ShoeSizeID INT NOT NULL,
    ShoeColorID INT NOT NULL,
    Quantity INT NOT NULL,  -- Số lượng còn trong kho
    PRIMARY KEY (ShoeID, ShoeSizeID, ShoeColorID),
    FOREIGN KEY (ShoeID) REFERENCES Shoes(ShoeID),
    FOREIGN KEY (ShoeSizeID) REFERENCES ShoeSizes(ShoeSizeID),
    FOREIGN KEY (ShoeColorID) REFERENCES ShoeColors(ShoeColorID)
);

 SELECT 
     S.ShoeID,
     S.Name AS ShoeName,
     S.Brand,
     S.Price,
     SS.Size AS ShoeSize,
     SC.Color AS ShoeColor
 FROM Shoes S
 LEFT JOIN ShoeSizes SS ON S.ShoeID = SS.ShoeID
 LEFT JOIN ShoeColors SC ON S.ShoeID = SC.ShoeID;

 select * from Shoes

 SELECT 
    S.ShoeID,
    SS.Size AS ShoeSize,
    SC.Color AS ShoeColor,
    COUNT(SSold.QuantitySold) AS TotalQuantity
FROM Shoes S
JOIN ShoeSizes SS ON S.ShoeID = SS.ShoeID
JOIN ShoeColors SC ON S.ShoeID = SC.ShoeID
LEFT JOIN ShoeSales SSold ON SS.ShoeSizeID = SSold.ShoeSizeID
                           AND SC.ShoeColorID = SSold.ShoeColorID
                           AND S.ShoeID = SSold.ShoeID
GROUP BY 
    S.ShoeID,
    SS.Size,
    SC.Color
ORDER BY S.ShoeID, SS.Size, SC.Color;

--Tim so con lai trong kho--
CREATE TABLE ShoeStock (
    ShoeID INT NOT NULL,
    ShoeSizeID INT NOT NULL,
    ShoeColorID INT NOT NULL,
    StockIn INT NOT NULL,  -- Số lượng giày nhập kho
    PRIMARY KEY (ShoeID, ShoeSizeID, ShoeColorID),
    FOREIGN KEY (ShoeID) REFERENCES Shoes(ShoeID),
    FOREIGN KEY (ShoeSizeID) REFERENCES ShoeSizes(ShoeSizeID),
    FOREIGN KEY (ShoeColorID) REFERENCES ShoeColors(ShoeColorID)
);
--Xuat kho--
CREATE TABLE ShoeSales (
    ShoeID INT NOT NULL,
    ShoeSizeID INT NOT NULL,
    ShoeColorID INT NOT NULL,
    QuantitySold INT NOT NULL,  -- Số lượng giày đã bán
    SaleDate DATETIME NOT NULL,  -- Ngày bán
    PRIMARY KEY (ShoeID, ShoeSizeID, ShoeColorID, SaleDate),
    FOREIGN KEY (ShoeID) REFERENCES Shoes(ShoeID),
    FOREIGN KEY (ShoeSizeID) REFERENCES ShoeSizes(ShoeSizeID),
    FOREIGN KEY (ShoeColorID) REFERENCES ShoeColors(ShoeColorID)
);
--Truy van--
SELECT 
    S.ShoeID,
    S.Name AS ShoeName,
    S.Brand,
    S.Price,
    SS.Size AS ShoeSize,
    SC.Color AS ShoeColor,
    ISNULL(SUM(ST.StockIn), 0) - ISNULL(SUM(SSold.QuantitySold), 0) AS Quantity
FROM Shoes S
JOIN ShoeSizes SS ON S.ShoeID = SS.ShoeID
JOIN ShoeColors SC ON S.ShoeID = SC.ShoeID
LEFT JOIN ShoeStock ST ON S.ShoeID = ST.ShoeID AND SS.ShoeSizeID = ST.ShoeSizeID AND SC.ShoeColorID = ST.ShoeColorID
LEFT JOIN ShoeSales SSold ON S.ShoeID = SSold.ShoeID AND SS.ShoeSizeID = SSold.ShoeSizeID AND SC.ShoeColorID = SSold.ShoeColorID
GROUP BY 
    S.ShoeID, 
    S.Name, 
    S.Brand, 
    S.Price, 
    SS.Size, 
    SC.Color
ORDER BY 
    S.ShoeID, 
    SS.Size, 
    SC.Color;

---Quan ly giay trong kho--
CREATE TABLE ShoeInventory (
    ShoeID INT NOT NULL,
    ShoeSizeID INT NOT NULL,
    ShoeColorID INT NOT NULL,
    Quantity INT NOT NULL,  -- Số lượng giày tồn kho
    PRIMARY KEY (ShoeID, ShoeSizeID, ShoeColorID),
    FOREIGN KEY (ShoeID) REFERENCES Shoes(ShoeID),
    FOREIGN KEY (ShoeSizeID) REFERENCES ShoeSizes(ShoeSizeID),
    FOREIGN KEY (ShoeColorID) REFERENCES ShoeColors(ShoeColorID)
);
-- Thêm giày vào kho với mỗi size và mỗi màu
INSERT INTO ShoeInventory (ShoeID, ShoeSizeID, ShoeColorID, Quantity)
VALUES
(1, 1, 1, 50),  -- 50 đôi giày Air Max 90, size 38, màu đỏ
(1, 2, 1, 30),  -- 30 đôi giày Air Max 90, size 39, màu đỏ
(2, 1, 2, 100), -- 100 đôi giày UltraBoost, size 40, màu trắng
(3, 1, 3, 200); -- 200 đôi giày Classic Slip-On, size 37, màu đen


SELECT 
    S.ShoeID,
    S.Name AS ShoeName,
    S.Brand,
    S.Price,
    SS.Size AS ShoeSize,
    SC.Color AS ShoeColor,
    SI.Quantity
FROM ShoeInventory SI
JOIN Shoes S ON SI.ShoeID = S.ShoeID
JOIN ShoeSizes SS ON SI.ShoeSizeID = SS.ShoeSizeID
JOIN ShoeColors SC ON SI.ShoeColorID = SC.ShoeColorID;


