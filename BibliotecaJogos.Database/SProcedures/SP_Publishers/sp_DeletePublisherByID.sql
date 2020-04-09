CREATE PROCEDURE [dbo].[sp_DeletePublisherByID]
	@id_publisher int
AS
BEGIN
	DECLARE @count1 int, @count2 int

	SELECT @count1 = COUNT(id_publisher) FROM tblPublishers WHERE id_publisher = @id_publisher
	SELECT @count2 = COUNT(id_publisher) FROM tblGames WHERE id_publisher = @id_publisher

	IF(@count1=0)
		SELECT -1 AS ReturnCode
	ELSE
	IF(@count2<>0)
		SELECT -2 AS ReturnCode
	ELSE
	BEGIN
		DELETE FROM tblPublishers WHERE id_publisher = @id_publisher
		SELECT 1 AS ReturnCode
	END
END