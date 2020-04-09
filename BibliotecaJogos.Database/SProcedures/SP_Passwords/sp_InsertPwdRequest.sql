
CREATE PROCEDURE [dbo].[sp_InsertPwdRequest]
	@email VARCHAR(256)
AS
BEGIN
	DECLARE @guid UNIQUEIDENTIFIER, @id_pwdRecoveryRequest int
	
	SET @guid = NEWID()

	SELECT @id_pwdRecoveryRequest = id_pwdRecoveryRequest FROM tblNewPwdRequests WHERE email = @email
	
	IF(@@ROWCOUNT <> 0)
	BEGIN
		UPDATE tblNewPwdRequests SET guid = @guid, email = @email, date_recovery_request = GETDATE() WHERE id_pwdRecoveryRequest = @id_pwdRecoveryRequest
	END
	ELSE
	BEGIN
		INSERT INTO tblNewPwdRequests VALUES (@guid, @email, GETDATE())	
	END

	SELECT @guid AS GUID
END




