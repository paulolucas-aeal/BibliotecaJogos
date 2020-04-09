CREATE PROCEDURE [dbo].[sp_GetGenreByID]
	@id_genre int
AS
BEGIN
	SELECT * FROM tblGenres WHERE id_genre = @id_genre
END
