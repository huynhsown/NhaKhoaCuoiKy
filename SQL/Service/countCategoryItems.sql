CREATE PROCEDURE [dbo].[countCategoryItems]
	@MaLoaiDichVu INT
AS
BEGIN
	SELECT COUNT(*) FROM DICHVU WHERE MaLoaiDichVu = @MaLoaiDichVu;
	RETURN 1;
END