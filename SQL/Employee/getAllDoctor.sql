CREATE PROCEDURE [dbo].[getAllDoctor]
AS
BEGIN
	SELECT NHANVIEN.*, BACSI.HocVi, BACSI.ChuyenMon FROM NHANVIEN
	INNER JOIN BACSI ON NHANVIEN.MaNhanVien = BACSI.MaNhanVien;
	RETURN 1;
END