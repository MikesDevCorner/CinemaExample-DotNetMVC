USE [movies]
GO

/****** Object:  Table [dbo].[user]    Script Date: 11.04.2019 01:40:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[user](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nchar](30) NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[movies]    Script Date: 11.04.2019 01:39:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[movies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nchar](40) NOT NULL,
	[Description] [nchar](255) NULL,
	[Price] [float] NULL,
 CONSTRAINT [PK_movies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



/****** Object:  Table [dbo].[cart]    Script Date: 11.04.2019 01:40:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[cart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_CalElement] [int] NOT NULL,
	[Id_User] [int] NOT NULL,
 CONSTRAINT [PK_cart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



/****** Object:  Table [dbo].[calelements]    Script Date: 11.04.2019 01:38:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[calelements](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Movie] [int] NOT NULL,
	[Start] [datetime] NOT NULL,
 CONSTRAINT [PK_calelements] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[calelements]  WITH CHECK ADD  CONSTRAINT [FK_calelements_movies] FOREIGN KEY([Id_Movie])
REFERENCES [dbo].[movies] ([Id])
GO

ALTER TABLE [dbo].[calelements] CHECK CONSTRAINT [FK_calelements_movies]
GO

ALTER TABLE [dbo].[cart]  WITH CHECK ADD  CONSTRAINT [FK_cart_calelements] FOREIGN KEY([Id_CalElement])
REFERENCES [dbo].[calelements] ([Id])
GO

ALTER TABLE [dbo].[cart] CHECK CONSTRAINT [FK_cart_calelements]
GO

ALTER TABLE [dbo].[cart]  WITH CHECK ADD  CONSTRAINT [FK_cart_user] FOREIGN KEY([Id_User])
REFERENCES [dbo].[user] ([Id])
GO

ALTER TABLE [dbo].[cart] CHECK CONSTRAINT [FK_cart_user]
GO
