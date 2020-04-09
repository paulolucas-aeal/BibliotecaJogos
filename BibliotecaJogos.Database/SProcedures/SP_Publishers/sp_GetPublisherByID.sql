CREATE PROCEDURE [dbo].[sp_GetPublisherByID]
	@id_publisher int
AS
BEGIN
	SELECT * FROM tblPublishers WHERE id_publisher = @id_publisher
END
