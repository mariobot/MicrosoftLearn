USE [ProductsList]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 8/2/2023 11:44:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

USE [ProductsList]
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([Id], [Title], [Quantity], [Message], [City]) VALUES (1, N'Xbox', 12, N'Microsoft XBox', N'New York')
GO
INSERT [dbo].[Orders] ([Id], [Title], [Quantity], [Message], [City]) VALUES (2, N'PlayStation', 10, N'Sony Play Station', N'LA')
GO
INSERT [dbo].[Orders] ([Id], [Title], [Quantity], [Message], [City]) VALUES (3, N'Call of Duty', 5, N'Xbox Game', N'New York')
GO
INSERT [dbo].[Orders] ([Id], [Title], [Quantity], [Message], [City]) VALUES (4, N'San Andreas', 3, N'Game', N'Washington')
GO
INSERT [dbo].[Orders] ([Id], [Title], [Quantity], [Message], [City]) VALUES (5, N'Mario Bros', 4, N'Game', N'LA')
GO
INSERT [dbo].[Orders] ([Id], [Title], [Quantity], [Message], [City]) VALUES (6, N'Camera Sony', 2, N'Sony Company', N'New York')
GO
INSERT [dbo].[Orders] ([Id], [Title], [Quantity], [Message], [City]) VALUES (8, N'Camera Nikon', 2, N'Black', N'New York')
GO
INSERT [dbo].[Orders] ([Id], [Title], [Quantity], [Message], [City]) VALUES (9, N'Plasma monitor', 2, N'Black', N'New York')
GO
INSERT [dbo].[Orders] ([Id], [Title], [Quantity], [Message], [City]) VALUES (10, N'Plasma TV', 6, N'Sony Brand', N'New York')
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
