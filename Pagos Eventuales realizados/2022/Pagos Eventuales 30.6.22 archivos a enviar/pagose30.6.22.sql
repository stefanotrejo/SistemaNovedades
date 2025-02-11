USE [LiquidacionSueldos]
GO
/****** Object:  Table [dbo].[PagosEventuales]    Script Date: 30/06/2022 20:11:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PagosEventuales](
	[pevId] [int] IDENTITY(1,1) NOT NULL,
	[lpaId] [int] NULL,
	[ageApellidoNombre] [nvarchar](255) NULL,
	[ageDNI] [nvarchar](255) NULL,
	[ageCUIT] [nvarchar](255) NULL,
	[ageSexo] [nvarchar](255) NULL,
	[ageJurisdiccion] [varchar](3) NULL,
	[agePrograma] [varchar](3) NULL,
	[ageNroControl] [nvarchar](255) NULL,
	[pevLugarPagoCodigo] [varchar](50) NULL,
	[pevImporteTotal] [float] NULL,
	[pevFechaCarga] [date] NULL CONSTRAINT [DF_PagosEventuales_ageFechaCarga_5]  DEFAULT (getdate()),
	[pevGenerado] [tinyint] NULL CONSTRAINT [DF_PagosEventuales_ageEstado_5]  DEFAULT ((0)),
	[pevPagoAcumulado] [tinyint] NULL,
	[pevUtlimaVezGenerado] [datetime] NULL,
	[pevNroLote] [varchar](50) NULL,
 CONSTRAINT [PK_PagosEventuales_5] PRIMARY KEY CLUSTERED 
(
	[pevId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[PagosEventuales] ON 

INSERT [dbo].[PagosEventuales] ([pevId], [lpaId], [ageApellidoNombre], [ageDNI], [ageCUIT], [ageSexo], [ageJurisdiccion], [agePrograma], [ageNroControl], [pevLugarPagoCodigo], [pevImporteTotal], [pevFechaCarga], [pevGenerado], [pevPagoAcumulado], [pevUtlimaVezGenerado], [pevNroLote]) VALUES (6352, 377, N'JIMENEZ PAGANI, MARIA E. ', N'30443384', N'27304433847', N'M', N'12', N'14', N'43014101', N'43011', 25000, CAST(N'2022-06-30' AS Date), 0, 0, NULL, NULL)
INSERT [dbo].[PagosEventuales] ([pevId], [lpaId], [ageApellidoNombre], [ageDNI], [ageCUIT], [ageSexo], [ageJurisdiccion], [agePrograma], [ageNroControl], [pevLugarPagoCodigo], [pevImporteTotal], [pevFechaCarga], [pevGenerado], [pevPagoAcumulado], [pevUtlimaVezGenerado], [pevNroLote]) VALUES (6353, 377, N'URQUIZA LLANOS RICHARD F.', N'26570065', N'23265700659', N'V', N'12', N'14', N'43011425', N'43011', 25000, CAST(N'2022-06-30' AS Date), 0, 0, NULL, NULL)
INSERT [dbo].[PagosEventuales] ([pevId], [lpaId], [ageApellidoNombre], [ageDNI], [ageCUIT], [ageSexo], [ageJurisdiccion], [agePrograma], [ageNroControl], [pevLugarPagoCodigo], [pevImporteTotal], [pevFechaCarga], [pevGenerado], [pevPagoAcumulado], [pevUtlimaVezGenerado], [pevNroLote]) VALUES (6354, 662, N'CEJAS MARIA LUISA        ', N'12391791', N'27123917915', N'M', N'60', N'11', N'88007361', N'88013', 25000, CAST(N'2022-06-30' AS Date), 0, 0, NULL, NULL)
INSERT [dbo].[PagosEventuales] ([pevId], [lpaId], [ageApellidoNombre], [ageDNI], [ageCUIT], [ageSexo], [ageJurisdiccion], [agePrograma], [ageNroControl], [pevLugarPagoCodigo], [pevImporteTotal], [pevFechaCarga], [pevGenerado], [pevPagoAcumulado], [pevUtlimaVezGenerado], [pevNroLote]) VALUES (6355, 662, N'FARIAS JORGE FRANCISCO   ', N'12422449', N'20124224498', N'V', N'60', N'11', N'88006373', N'88013', 25000, CAST(N'2022-06-30' AS Date), 0, 0, NULL, NULL)
INSERT [dbo].[PagosEventuales] ([pevId], [lpaId], [ageApellidoNombre], [ageDNI], [ageCUIT], [ageSexo], [ageJurisdiccion], [agePrograma], [ageNroControl], [pevLugarPagoCodigo], [pevImporteTotal], [pevFechaCarga], [pevGenerado], [pevPagoAcumulado], [pevUtlimaVezGenerado], [pevNroLote]) VALUES (6356, 662, N'LEDESMA DANIEL OSVALDO   ', N'20307234', N'20203072342', N'V', N'60', N'11', N'88007264', N'88013', 25000, CAST(N'2022-06-30' AS Date), 0, 0, NULL, NULL)
INSERT [dbo].[PagosEventuales] ([pevId], [lpaId], [ageApellidoNombre], [ageDNI], [ageCUIT], [ageSexo], [ageJurisdiccion], [agePrograma], [ageNroControl], [pevLugarPagoCodigo], [pevImporteTotal], [pevFechaCarga], [pevGenerado], [pevPagoAcumulado], [pevUtlimaVezGenerado], [pevNroLote]) VALUES (6357, 235, N'CORDERO OSCAR ANDRES     ', N'27390024', N'20273900242', N'V', N'12', N'44', N'26002183', N'26016', 25000, CAST(N'2022-06-30' AS Date), 0, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[PagosEventuales] OFF
