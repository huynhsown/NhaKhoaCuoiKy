CREATE PROCEDURE [dbo].[getByPhone]
	@SoDienThoai VARCHAR(50)
AS
	SELECT * FROM BENHNHAN WHERE SoDienThoai = @SoDienThoai;
RETURN 0