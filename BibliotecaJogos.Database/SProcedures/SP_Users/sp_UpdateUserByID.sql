CREATE PROCEDURE [dbo].[sp_UpdateUserByID]
	@id_user int,
	@username varchar(50),
	@password char(64),
	@email varchar(MAX),
	@role char(1)
AS
BEGIN
	DECLARE @count int
	SELECT @count = COUNT(id_user) FROM tblUsers WHERE id_user = @id_user

	IF(@count<>1)
	BEGIN
		SELECT -1 AS ReturnCode
	END
	ELSE
	BEGIN
		UPDATE tblUsers
		SET username = @username, password = @password, email = @email, role = @role WHERE id_user = @id_user
		SELECT 1 AS ReturnCode
	END
END