CREATE PROCEDURE [dbo].[sp_InsertUser]
	@username varchar(50),
	@password char(64),
	@email varchar(MAX),
	@role char(1)  = 'U'
AS
BEGIN
	DECLARE @count int

	SELECT @count = COUNT(id_user) FROM tblUsers WHERE username = @username OR email = @email

	IF(@count<>0)
	BEGIN
		SELECT -1 AS ReturnCode
	END
	ELSE
	BEGIN
		INSERT INTO [dbo].[tblUsers]
			   ([username]
			   ,[password]
			   ,[email]
			   ,[role])
		 VALUES (@username, @password, @email, @role)
		SELECT 1 AS ReturnCode
	END
END




