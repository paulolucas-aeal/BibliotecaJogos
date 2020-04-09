CREATE PROCEDURE [dbo].[sp_UpdateGenreByID]
	@id_genre int,
	@description_genre varchar(50)
AS
BEGIN
	DECLARE @count int
	SELECT @count = COUNT(id_genre) FROM tblGenres WHERE id_genre = @id_genre

	IF(@count<>1)
	BEGIN
		SELECT -1 AS ReturnCode
	END
	ELSE
	BEGIN
		UPDATE tblGenres SET description_genre = @description_genre WHERE id_genre = @id_genre
		SELECT 1 AS ReturnCode
	END
END
