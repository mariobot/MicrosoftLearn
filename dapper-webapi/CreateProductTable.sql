CREATE TABLE dbo.Products(
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar] (max) NULL,
	[Quantity] [int] NULL,
	[Price] [float] NULL
)