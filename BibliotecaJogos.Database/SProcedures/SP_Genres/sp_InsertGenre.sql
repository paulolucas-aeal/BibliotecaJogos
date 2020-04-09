CREATE PROCEDURE [dbo].[sp_InsertGenre]
	@description_genre varchar(50)
AS
BEGIN
	DECLARE @count int
	SELECT @count = COUNT(description_genre) FROM tblGenres WHERE description_genre = @description_genre
	IF(@count<>0)
	BEGIN
		SELECT -1 AS ReturnCode
	END
	ELSE
	BEGIN
		INSERT INTO tblGenres VALUES (@description_genre)
		SELECT 1 AS ReturnCode
	END
END
