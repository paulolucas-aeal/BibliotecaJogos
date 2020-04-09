CREATE TABLE [dbo].[tblPublishers]
(
	[id_publisher] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name_publisher] VARCHAR(50) NOT NULL, 
    CONSTRAINT [UK_tblPublishers_name_publisher] UNIQUE ([name_publisher])
)

