CREATE PROCEDURE [dbo].[sp_InsertGame]
	@title varchar(50),
	@cover_image varchar(256),
	@amount_paid money,
	@purchase_date date,
	@id_publisher int,
	@id_genre int
AS
BEGIN
	DECLARE @count int
	SELECT @count = COUNT(*) FROM tblGames WHERE title = @title OR cover_image = @cover_image
	IF(@count<>0)
	BEGIN
		SELECT -1 AS ReturnCode
	END
	ELSE
	BEGIN
		INSERT INTO tblGames VALUES (@title, @cover_image, @amount_paid, @purchase_date, @id_publisher, @id_genre)
		SELECT 1 AS ReturnCode
	END
END
	
