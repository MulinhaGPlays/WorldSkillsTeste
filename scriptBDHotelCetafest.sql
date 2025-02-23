USE [bdHotelCetafest]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 05/10/2016 14:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[codigoPais] [int] NOT NULL,
	[codigoProfissao] [int] NOT NULL,
	[nome] [varchar](100) NULL,
	[Rua] [varchar](100) NULL,
	[bairro] [varchar](100) NULL,
	[cep] [varchar](10) NULL,
	[NumeroCasa] [int] NULL,
	[TipoDocumento] [char](1) NOT NULL,
	[NumeroDocumento] [varchar](50) NULL,
	[TipoPessoa] [bit] NOT NULL,
	[Sexo] [char](1) NULL,
	[DataNascimento] [smalldatetime] NULL,
	[Telefone] [varchar](10) NULL,
	[Celular] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 05/10/2016 14:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pais](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](100) NOT NULL,
	[sigla] [char](3) NULL,
	[Populacao] [int] NULL,
	[Continente] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Profissao]    Script Date: 05/10/2016 14:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Profissao](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[descricao] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Pais] ON 

INSERT [dbo].[Pais] ([codigo], [nome], [sigla], [Populacao], [Continente]) VALUES (1, N'BRASILIA', N'BRA', 54000000, NULL)
INSERT [dbo].[Pais] ([codigo], [nome], [sigla], [Populacao], [Continente]) VALUES (11, N'SUECIA', N'SUE', 13, NULL)
INSERT [dbo].[Pais] ([codigo], [nome], [sigla], [Populacao], [Continente]) VALUES (12, N'Coreias', N'COR', 4546, NULL)
INSERT [dbo].[Pais] ([codigo], [nome], [sigla], [Populacao], [Continente]) VALUES (13, N'maria', N'mar', 444, NULL)
SET IDENTITY_INSERT [dbo].[Pais] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [U_sigla]    Script Date: 05/10/2016 14:58:51 ******/
ALTER TABLE [dbo].[Pais] ADD  CONSTRAINT [U_sigla] UNIQUE NONCLUSTERED 
(
	[sigla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [fk_clientePais] FOREIGN KEY([codigoPais])
REFERENCES [dbo].[Pais] ([codigo])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [fk_clientePais]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [fk_clienteProfissao] FOREIGN KEY([codigoProfissao])
REFERENCES [dbo].[Profissao] ([codigo])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [fk_clienteProfissao]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [chk_doc] CHECK  (([TipoDocumento]='O' OR [TipoDocumento]='N' OR [TipoDocumento]='H' OR [TipoDocumento]='C' OR [TipoDocumento]='P' OR [TipoDocumento]='R'))
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [chk_doc]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [chk_sexo] CHECK  (([sexo]='M' OR [sexo]='F'))
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [chk_sexo]
GO
ALTER TABLE [dbo].[Pais]  WITH CHECK ADD  CONSTRAINT [ChK_PopMaior0] CHECK  (([Populacao]>(0)))
GO
ALTER TABLE [dbo].[Pais] CHECK CONSTRAINT [ChK_PopMaior0]
GO
