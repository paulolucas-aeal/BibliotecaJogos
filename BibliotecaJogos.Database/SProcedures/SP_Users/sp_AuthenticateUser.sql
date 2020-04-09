-- Versão 1
--CREATE PROCEDURE [dbo].[sp_AuthenticateUser]
--	@username varchar(50),
--	@password char(64)
--AS
--BEGIN
--	DECLARE @count int
	
--	SELECT @count = COUNT(username) FROM tblUsers WHERE username = @username AND password = @password

--	IF(@count = 1)
--	BEGIN
--		SELECT 1 AS ReturnCode
--		SELECT * FROM tblUsers WHERE username = @username AND password = @password
--	END
--	ELSE
--	BEGIN
--		SELECT -1 AS ReturnCode
--	END
--END


--Versão 2
CREATE PROCEDURE [dbo].[sp_AuthenticateUser]
	@username varchar(50),
	@password char(64)
AS
BEGIN
	DECLARE @count int, @is_locked bit, @nr_attempts int, @locked_date_time DATETIME

	SELECT @is_locked = ISNULL(is_locked,0), @locked_date_time = locked_date_time FROM tblUsers WHERE username = @username

	IF(@is_locked = 1 AND DATEDIFF(HOUR, @locked_date_time, GETDATE()) >= 24)
	BEGIN
		SET @is_locked = 0
	END

	IF(@is_locked <> 1)
	BEGIN
		SELECT @count = COUNT(username) FROM tblUsers WHERE username = @username AND password = @password
		IF(@count=0)
		BEGIN
			UPDATE tblUsers SET nr_attempts = ISNULL(nr_attempts, 0) + 1 WHERE username = @username
			SELECT @nr_attempts = nr_attempts FROM tblUsers WHERE username = @username
			IF(@nr_attempts > 3)
			BEGIN
				UPDATE tblUsers SET is_locked = 1, nr_attempts = 0, locked_date_time = GETDATE() WHERE username = @username
			END
		END
		ELSE
		BEGIN
			UPDATE tblUsers SET is_locked = 0, nr_attempts = 0, locked_date_time = NULL WHERE username = @username
		END
	END

	SELECT * FROM tblUsers WHERE username = @username
END
