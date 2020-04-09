

CREATE PROCEDURE [dbo].[sp_ResetPassword]
	@id_user int,
	@new_password char(64)
AS
BEGIN
	DECLARE @count int

	SELECT @count=COUNT(*) FROM tblUsers WHERE id_user = @id_user

	IF(@count=0)
	BEGIN
		SELECT -1 AS ReturnCode
	END
	ELSE
	BEGIN
		UPDATE tblUsers SET password = @new_password WHERE id_user = @id_user
		SELECT 1 AS ReturnCode
	END
END


