CREATE PROCEDURE [dbo].[sp_GetGameByID]
	@id_game int
AS
BEGIN
	SELECT * FROM tblGames WHERE id_game = @id_game
END
