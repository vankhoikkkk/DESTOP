CREATE DATABASE QuanLyDiemRenLuyen
go
use QuanLyDiemRenLuyen


CREATE TABLE Account (
id_TK INT IDENTITY(1,1) PRIMARY KEY,
tenTK NVARCHAR(100) UNIQUE,
pass NVARCHAR(100),
isAdmin int 
)
go

SELECT * FROM Account WHERE tenTK = 'khoi1' AND pass = 'khoi1'


ALTER TABLE Account
ALTER COLUMN isAdmin int ;
ALTER TABLE account
ADD CONSTRAINT DF_kich_hoat DEFAULT 0 FOR isAdmin;

select * from Account


CREATE TABLE SinhVien (
    MaSV INT IDENTITY(1,1) PRIMARY KEY, -- tự động tăng từ 1, bước nhảy 1
    HoTen NVARCHAR(100) NOT NULL
);

CREATE TABLE SuKienRenLuyen (
    MaSuKien INT IDENTITY(1,1) PRIMARY KEY,
    TenSuKien NVARCHAR(100) NOT NULL,
    NgayToChuc DATE NOT NULL,
    DiemCong INT NOT NULL
);

CREATE TABLE ThamGia (
    MaSV INT,
    MaSuKien INT,
    PRIMARY KEY (MaSV, MaSuKien),
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV),
    FOREIGN KEY (MaSuKien) REFERENCES SuKienRenLuyen(MaSuKien)
);

INSERT INTO  Account (tenTK, pass, isAdmin) VALUES ('khoi1', 'khoi1', 0)




INSERT INTO SinhVien (HoTen) VALUES
(N'Nguyễn Văn A'),
(N'Trần Thị B'),
(N'Lê Văn C'),
(N'Phạm Thị D'),
(N'Huỳnh Văn E'),
(N'Đỗ Thị F'),
(N'Vũ Văn G'),
(N'Ngô Thị H'),
(N'Bùi Văn I'),
(N'Tạ Thị J'),
(N'Hồ Văn K'),
(N'Lý Thị L'),
(N'Cao Văn M'),
(N'Đinh Thị N'),
(N'Hà Văn O'),
(N'Trịnh Thị P'),
(N'Mai Văn Q'),
(N'Châu Thị R'),
(N'Kiều Văn S'),
(N'Tống Thị T');

INSERT INTO SinhVien (HoTen) VALUES
(N'Nguyễn Văn Khoi')

INSERT INTO SuKienRenLuyen (TenSuKien, NgayToChuc, DiemCong) VALUES
(N'Tình nguyện Mùa Hè Xanh', '2025-01-10', 5),
(N'Hiến máu nhân đạo', '2025-01-20', 4),
(N'Vệ sinh ký túc xá', '2025-02-01', 3),
(N'Chạy bộ gây quỹ', '2025-02-15', 4),
(N'Hội thảo kỹ năng mềm', '2025-02-25', 2),
(N'Tập huấn PCCC', '2025-03-05', 2),
(N'Tọa đàm hướng nghiệp', '2025-03-12', 3),
(N'Triển lãm sách', '2025-03-20', 2),
(N'Tổ chức trò chơi dân gian', '2025-04-01', 4),
(N'Tình nguyện Mùa Đông ấm', '2025-04-10', 5),
(N'Cuộc thi Olympic Tin học', '2025-04-20', 5),
(N'Ngày hội việc làm', '2025-04-30', 3),
(N'Trồng cây gây rừng', '2025-05-05', 4),
(N'Ngày hội Thể thao', '2025-05-10', 3),
(N'Tập huấn kỹ năng thuyết trình', '2025-05-15', 2),
(N'Dọn rác bãi biển', '2025-05-20', 4),
(N'Hoạt động giao lưu sinh viên', '2025-05-25', 3),
(N'Chương trình văn nghệ chào xuân', '2025-05-30', 3),
(N'Thăm hỏi người già neo đơn', '2025-06-05', 5),
(N'Phát quà cho trẻ em nghèo', '2025-06-10', 5);

select * from SuKienRenLuyen
INSERT INTO ThamGia (MaSV, MaSuKien) VALUES
(1, 1), (1, 2), (1, 3),
(2, 2), (2, 4),
(3, 5), (3, 6), (3, 7),
(4, 1), (4, 8),
(5, 9), (5, 10), (5, 11),
(6, 12), (6, 13),
(7, 1), (7, 3), (7, 5),
(8, 4), (8, 6), (8, 7),
(9, 8), (9, 10), (9, 12),
(10, 11), (10, 13), (10, 14),
(11, 15), (11, 16), (11, 17),
(12, 18), (12, 19),
(13, 1), (13, 20),
(14, 2), (14, 4), (14, 6),
(15, 8), (15, 9),
(16, 10), (16, 11), (16, 12),
(17, 13), (17, 14),
(18, 15), (18, 17), (18, 19),
(19, 16), (19, 18),
(20, 3), (20, 6), (20, 9);


SELECT 
    sv.MaSV,
    sv.HoTen,
    ISNULL(SUM(sk.DiemCong), 0) AS TongDiemRenLuyen
FROM 
    SinhVien sv
LEFT JOIN 
    ThamGia tg ON sv.MaSV = tg.MaSV
LEFT JOIN 
    SuKienRenLuyen sk ON tg.MaSuKien = sk.MaSuKien
GROUP BY 
    sv.MaSV, sv.HoTen
ORDER BY
    sv.MaSV;

	select * from SuKienRenLuyen

	Update SinhVien SET HoTen = 'tu' WHERE MaSV = 22
	DELETE FROM SinhVien WHERE MaSV = 22

	INSERT INTO SuKienRenLuyen (TenSuKien, NgayToChuc, DiemCong) VALUES
(N'Tình nguyện Mùa Hè Xanh CON', '2025-01-10', 5)

UPDATE SuKienRenLuyen SET TenSuKien = N'CON CC' , NgayToChuc = '20250510' , DiemCong = 3  WHERE MaSuKien = 21

DELETE FROM SuKienRenLuyen WHERE MaSuKien = 21

SELECT sv.MaSV, sk.MaSuKien , sv.HoTen, sk.TenSuKien, NgayToChuc, DiemCong FROM SinhVien sv JOIN ThamGia tg ON sv.MaSV = tg.MaSV 
JOIN  SuKienRenLuyen sk ON tg.MaSuKien = sk.MaSuKien ORDER BY sv.MaSV;


SELECT sv.MaSV, sv.HoTen,  ISNULL(SUM(sk.DiemCong), 0) as TongDiemRenLuyen FROM SinhVien sv LEFT JOIN ThamGia tg ON sv.MaSV = tg.MaSV
LEFT JOIN SuKienRenLuyen sk ON tg.MaSuKien = sk.MaSuKien GROUP BY sv.MaSV, sv.HoTen
ORDER BY sv.MaSV;

INSERT INTO ThamGia (MaSV, MaSuKien) VALUES
(1, 1)

SELECT COUNT(*) FROM ThamGia WHERE MaSV = 99 AND MaSuKien = 99

SELECT * FROM SukienRenLuyen







