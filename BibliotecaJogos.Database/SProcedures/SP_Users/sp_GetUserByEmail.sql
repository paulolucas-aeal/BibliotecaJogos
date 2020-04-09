CREATE PROCEDURE [dbo].[sp_GetUserByEmail]
	@email varchar(256)
AS
BEGIN
	SELECT * FROM tblUsers WHERE email = @email
END
