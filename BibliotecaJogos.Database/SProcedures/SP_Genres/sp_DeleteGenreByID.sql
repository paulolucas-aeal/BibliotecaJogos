CREATE PROCEDURE [dbo].[sp_DeleteGenreByID]
	@id_genre int
AS
BEGIN
	DECLARE @count1 int, @count2 int

	SELECT @count1 = COUNT(id_genre) FROM tblGenres WHERE id_genre = @id_genre
	SELECT @count2 = COUNT(id_genre) FROM tblGames WHERE id_genre = @id_genre

	IF(@count1=0)
		SELECT -1 AS ReturnCode
	ELSE
	IF(@count2<>0)
		SELECT -2 AS ReturnCode
	ELSE
	BEGIN
		DELETE FROM tblGenres WHERE id_genre = @id_genre
		SELECT 1 AS ReturnCode
	END
END
