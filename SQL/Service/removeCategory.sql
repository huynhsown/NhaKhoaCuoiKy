USE NHAKHOA
GO
CREATE PROCEDURE [dbo].[removeCategory]
	@MaLoaiDichVu INT
AS
BEGIN
	DELETE FROM DICHVU WHERE MaLoaiDichVu = @MaLoaiDichVu;
	DELETE FROM LOAIDICHVU WHERE MaLoaiDichVu = @MaLoaiDichVu;
END