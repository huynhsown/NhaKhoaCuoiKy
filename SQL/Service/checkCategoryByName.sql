CREATE PROCEDURE [dbo].[checkCategoryByName]
	@TenLoaiDichVu NVARCHAR(MAX)
AS
BEGIN
	SELECT COUNT(*) FROM [dbo].[LOAIDICHVU] WHERE TenLoaiDichVu = @TenLoaiDichVu;
	RETURN 1;
END