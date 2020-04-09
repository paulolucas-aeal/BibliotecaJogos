CREATE PROCEDURE [dbo].[sp_UpdateGameByID]
	@id_game int,
	@title varchar(50),
	@cover_image varchar(256),
    @amount_paid money,
    @purchase_date date,
    @id_publisher int,
    @id_genre int
AS
BEGIN
	DECLARE @count int
	SELECT @count = COUNT(id_game) FROM tblGames WHERE id_game = @id_game

	IF(@count<>1)
	BEGIN
		SELECT -1 AS ReturnCode
	END
	ELSE
	BEGIN
		UPDATE tblGames SET title = @title
			,cover_image = @cover_image
			,amount_paid = @amount_paid
			,purchase_date = @purchase_date
			,id_publisher = @id_publisher
			,id_genre = @id_genre
		WHERE id_game = @id_game
		SELECT 1 AS ReturnCode
	END
END