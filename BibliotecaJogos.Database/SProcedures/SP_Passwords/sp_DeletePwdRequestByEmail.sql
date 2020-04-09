CREATE PROCEDURE [dbo].[sp_DeletePwdRequestByEmail]
	@email varchar(50)
AS
BEGIN
	DECLARE @count int
	SELECT @count = COUNT(*) FROM tblNewPwdRequests WHERE email = @email

	IF(@count=0)
	BEGIN
		SELECT -1 AS ReturnCode
	END
	ELSE
	BEGIN
		DELETE FROM tblNewPwdRequests WHERE email = @email
		SELECT 1 AS ReturnCode
	END
END
