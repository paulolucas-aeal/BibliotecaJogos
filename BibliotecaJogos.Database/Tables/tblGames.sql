CREATE TABLE [dbo].[tblGames]
(
	[id_game] INT NOT NULL PRIMARY KEY IDENTITY, 
    [title] VARCHAR(50) NOT NULL, 
	[cover_image] VARCHAR(256) NOT NULL, 
    [amount_paid] MONEY NULL, 
    [purchase_date] DATE NULL, 
    [id_publisher] INT NOT NULL, 
    [id_genre] INT NOT NULL, 
	CONSTRAINT [UK_tblGames_title] UNIQUE ([title]), 
    CONSTRAINT [UK_tblGames_cover_image] UNIQUE ([cover_image]), 
	CONSTRAINT [FK_tblGames_tblPublishers] FOREIGN KEY ([id_publisher]) REFERENCES [tblPublishers]([id_publisher]),
    CONSTRAINT [FK_tblGames_tblGenres] FOREIGN KEY ([id_genre]) REFERENCES [tblGenres]([id_genre])
)



