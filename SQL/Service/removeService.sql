CREATE PROCEDURE [dbo].[removeService]
	@MaDichVu INT
AS
BEGIN
	DELETE FROM [dbo].[DICHVU] WHERE MaDichVu = @MaDichVu;
	RETURN 1;
END