CREATE PROCEDURE [dbo].[sp_InsertPublisher]
	@name_publisher varchar(50)
AS
BEGIN
	DECLARE @count int
	SELECT @count = COUNT(name_publisher) FROM tblPublishers WHERE name_publisher = @name_publisher
	IF(@count<>0)
	BEGIN
		SELECT -1 AS ReturnCode
	END
	ELSE
	BEGIN
		INSERT INTO tblPublishers VALUES (@name_publisher)
		SELECT 1 AS ReturnCode
	END
END