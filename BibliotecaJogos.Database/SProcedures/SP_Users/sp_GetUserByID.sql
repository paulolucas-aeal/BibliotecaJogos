CREATE PROCEDURE [dbo].[sp_GetUserByID]
	@id_user int
AS
BEGIN
	SELECT * FROM tblUsers WHERE id_user = @id_user
END

