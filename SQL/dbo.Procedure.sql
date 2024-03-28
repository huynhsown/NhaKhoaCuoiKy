CREATE PROCEDURE [dbo].[addPatient]
	@MaBenhNhan		INT output,
	@HoVaTen		VARCHAR(255),
	@GioiTinh		VARCHAR (5),
    @NgaySinh		DATE, 
    @SoNha			INT,        
    @Phuong			VARCHAR(255),
    @ThanhPho		VARCHAR(255),
    @Anh			IMAGE,
    @SoDienThoai	VARCHAR(50)
AS
begin 
	insert into BENHNHAN 
	values (@HoVaTen,@GioiTinh, @NgaySinh,  @SoNha, @Phuong, @ThanhPho, @Anh, @SoDienThoai);
	set @MaBenhNhan = SCOPE_IDENTITY();
	return 1;
end
