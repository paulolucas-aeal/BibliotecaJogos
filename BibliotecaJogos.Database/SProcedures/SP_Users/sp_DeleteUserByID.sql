CREATE PROCEDURE [dbo].[sp_DeleteUserByID]
	@id_user int
AS
BEGIN
	DECLARE @count int

	SELECT @count = COUNT(id_user) FROM tblUsers WHERE id_user = @id_user

	IF(@count=0)
	BEGIN
		SELECT -1 AS ReturnCode
	END
	ELSE
	BEGIN
		DELETE FROM tblUsers WHERE id_user = @id_user
		SELECT 1 AS ReturnCode
	END
END