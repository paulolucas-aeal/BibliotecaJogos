CREATE PROCEDURE [dbo].[sp_UpdatePublisherByID]
	@id_publisher int,
	@name_publisher varchar(50)
AS
BEGIN
	DECLARE @count int
	SELECT @count = COUNT(id_publisher) FROM tblPublishers WHERE id_publisher = @id_publisher

	IF(@count<>1)
	BEGIN
		SELECT -1 AS ReturnCode
	END
	ELSE
	BEGIN
		UPDATE tblPublishers SET name_publisher = @name_publisher WHERE id_publisher = @id_publisher
		SELECT 1 AS ReturnCode
	END
END