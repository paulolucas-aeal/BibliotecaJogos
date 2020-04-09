CREATE TABLE [dbo].[tblGenres]
(
	[id_genre] INT NOT NULL PRIMARY KEY IDENTITY, 
    [description_genre] VARCHAR(50) NOT NULL, 
    CONSTRAINT [UK_tblGenres_description_genre] UNIQUE ([description_genre])
)

