CREATE TABLE [dbo].[Categories]
(
	[CategoryID] INT IDENTITY(1,1) NOT NULL, 
    [CategoryName] NVARCHAR(15) NOT NULL, 
    [Description] NTEXT NULL, 
    [Picture] IMAGE NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED ([CategoryID])
)
