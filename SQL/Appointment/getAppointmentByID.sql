CREATE PROCEDURE [dbo].[getAppointmentByID]
	@MaLichHen INT
AS
BEGIN
	SELECT * FROM [dbo].[LICHHEN] WHERE MaLichHen = @MaLichHen;
	RETURN 1;
END