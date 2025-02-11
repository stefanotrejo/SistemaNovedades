USE [LiquidacionSueldos]
GO
/****** Object:  Table [dbo].[PagosEventuales]    Script Date: 30/06/2022 19:55:05 ******/
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
	[pevFechaCarga] [date] NULL CONSTRAINT [DF_PagosEventuales_ageFechaCarga_3]  DEFAULT (getdate()),
	[pevGenerado] [tinyint] NULL CONSTRAINT [DF_PagosEventuales_ageEstado_3]  DEFAULT ((0)),
	[pevPagoAcumulado] [tinyint] NULL,
	[pevUtlimaVezGenerado] [datetime] NULL,
	[pevNroLote] [varchar](50) NULL,
 CONSTRAINT [PK_PagosEventuales_3] PRIMARY KEY CLUSTERED 
(
	[pevId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[PagosEventuales] ON 

INSERT [dbo].[PagosEventuales] ([pevId], [lpaId], [ageApellidoNombre], [ageDNI], [ageCUIT], [ageSexo], [ageJurisdiccion], [agePrograma], [ageNroControl], [pevLugarPagoCodigo], [pevImporteTotal], [pevFechaCarga], [pevGenerado], [pevPagoAcumulado], [pevUtlimaVezGenerado], [pevNroLote]) VALUES (6335, 263, N'JUAREZ MARIA RAMONA      ', N'32351916', N'27323519167', N'M', N'55', N'14', N'29043833', N'29107', 30000, CAST(N'2022-06-30' AS Date), 0, 0, NULL, NULL)
INSERT [dbo].[PagosEventuales] ([pevId], [lpaId], [ageApellidoNombre], [ageDNI], [ageCUIT], [ageSexo], [ageJurisdiccion], [agePrograma], [ageNroControl], [pevLugarPagoCodigo], [pevImporteTotal], [pevFechaCarga], [pevGenerado], [pevPagoAcumulado], [pevUtlimaVezGenerado], [pevNroLote]) VALUES (6336, 263, N'JUAREZ MARIA RAMONA      ', N'32351916', N'27323519167', N'M', N'55', N'14', N'29043833', N'29107', 30000, CAST(N'2022-06-30' AS Date), 0, 0, NULL, NULL)
INSERT [dbo].[PagosEventuales] ([pevId], [lpaId], [ageApellidoNombre], [ageDNI], [ageCUIT], [ageSexo], [ageJurisdiccion], [agePrograma], [ageNroControl], [pevLugarPagoCodigo], [pevImporteTotal], [pevFechaCarga], [pevGenerado], [pevPagoAcumulado], [pevUtlimaVezGenerado], [pevNroLote]) VALUES (6337, 263, N'JUAREZ MARIA RAMONA      ', N'32351916', N'27323519167', N'M', N'55', N'14', N'29043833', N'29107', 30000, CAST(N'2022-06-30' AS Date), 0, 0, NULL, NULL)
INSERT [dbo].[PagosEventuales] ([pevId], [lpaId], [ageApellidoNombre], [ageDNI], [ageCUIT], [ageSexo], [ageJurisdiccion], [agePrograma], [ageNroControl], [pevLugarPagoCodigo], [pevImporteTotal], [pevFechaCarga], [pevGenerado], [pevPagoAcumulado], [pevUtlimaVezGenerado], [pevNroLote]) VALUES (6338, 252, N'VEGAS DANTE DARIO        ', N'23615133', N'20236151337', N'V', N'55', N'16', N'28013613', N'28522', 30000, CAST(N'2022-06-30' AS Date), 0, 0, NULL, NULL)
INSERT [dbo].[PagosEventuales] ([pevId], [lpaId], [ageApellidoNombre], [ageDNI], [ageCUIT], [ageSexo], [ageJurisdiccion], [agePrograma], [ageNroControl], [pevLugarPagoCodigo], [pevImporteTotal], [pevFechaCarga], [pevGenerado], [pevPagoAcumulado], [pevUtlimaVezGenerado], [pevNroLote]) VALUES (6339, 346, N'MORALEZ MONICA EVA       ', N'20784009', N'27207840098', N'M', N'55', N'12', N'38419131', N'38837', 30000, CAST(N'2022-06-30' AS Date), 0, 0, NULL, NULL)
INSERT [dbo].[PagosEventuales] ([pevId], [lpaId], [ageApellidoNombre], [ageDNI], [ageCUIT], [ageSexo], [ageJurisdiccion], [agePrograma], [ageNroControl], [pevLugarPagoCodigo], [pevImporteTotal], [pevFechaCarga], [pevGenerado], [pevPagoAcumulado], [pevUtlimaVezGenerado], [pevNroLote]) VALUES (6340, 549, N'SALVATIERRA SANDRA MABEL ', N'30798647', N'27307986472', N'M', N'26', N'11', N'77323694', N'77023', 30000, CAST(N'2022-06-30' AS Date), 0, 0, NULL, NULL)
INSERT [dbo].[PagosEventuales] ([pevId], [lpaId], [ageApellidoNombre], [ageDNI], [ageCUIT], [ageSexo], [ageJurisdiccion], [agePrograma], [ageNroControl], [pevLugarPagoCodigo], [pevImporteTotal], [pevFechaCarga], [pevGenerado], [pevPagoAcumulado], [pevUtlimaVezGenerado], [pevNroLote]) VALUES (6341, 265, N'ELIAS FARID ROLANDO      ', N'28980501', N'20289805010', N'V', N'55', N'14', N'29043312', N'29123', 30000, CAST(N'2022-06-30' AS Date), 0, 0, NULL, NULL)
INSERT [dbo].[PagosEventuales] ([pevId], [lpaId], [ageApellidoNombre], [ageDNI], [ageCUIT], [ageSexo], [ageJurisdiccion], [agePrograma], [ageNroControl], [pevLugarPagoCodigo], [pevImporteTotal], [pevFechaCarga], [pevGenerado], [pevPagoAcumulado], [pevUtlimaVezGenerado], [pevNroLote]) VALUES (6342, 265, N'ELIAS FARID ROLANDO      ', N'28980501', N'20289805010', N'V', N'55', N'14', N'29043312', N'29123', 30000, CAST(N'2022-06-30' AS Date), 0, 0, NULL, NULL)
INSERT [dbo].[PagosEventuales] ([pevId], [lpaId], [ageApellidoNombre], [ageDNI], [ageCUIT], [ageSexo], [ageJurisdiccion], [agePrograma], [ageNroControl], [pevLugarPagoCodigo], [pevImporteTotal], [pevFechaCarga], [pevGenerado], [pevPagoAcumulado], [pevUtlimaVezGenerado], [pevNroLote]) VALUES (6343, 356, N'CAJAL SANDRA ISABEL      ', N'23564729', N'27235647295', N'M', N'55', N'11', N'39310895', N'39102', 30000, CAST(N'2022-06-30' AS Date), 0, 0, NULL, NULL)
INSERT [dbo].[PagosEventuales] ([pevId], [lpaId], [ageApellidoNombre], [ageDNI], [ageCUIT], [ageSexo], [ageJurisdiccion], [agePrograma], [ageNroControl], [pevLugarPagoCodigo], [pevImporteTotal], [pevFechaCarga], [pevGenerado], [pevPagoAcumulado], [pevUtlimaVezGenerado], [pevNroLote]) VALUES (6344, 286, N'PAZ WALTER ISAURO        ', N'16447080', N'20164470807', N'V', N'55', N'12', N'38894904', N'38203', 30000, CAST(N'2022-06-30' AS Date), 0, 0, NULL, NULL)
INSERT [dbo].[PagosEventuales] ([pevId], [lpaId], [ageApellidoNombre], [ageDNI], [ageCUIT], [ageSexo], [ageJurisdiccion], [agePrograma], [ageNroControl], [pevLugarPagoCodigo], [pevImporteTotal], [pevFechaCarga], [pevGenerado], [pevPagoAcumulado], [pevUtlimaVezGenerado], [pevNroLote]) VALUES (6345, 285, N'MANSILLA SILVIA BEATRIZ  ', N'25520619', N'27255206198', N'M', N'55', N'12', N'38899205', N'38192', 30000, CAST(N'2022-06-30' AS Date), 0, 0, NULL, NULL)
INSERT [dbo].[PagosEventuales] ([pevId], [lpaId], [ageApellidoNombre], [ageDNI], [ageCUIT], [ageSexo], [ageJurisdiccion], [agePrograma], [ageNroControl], [pevLugarPagoCodigo], [pevImporteTotal], [pevFechaCarga], [pevGenerado], [pevPagoAcumulado], [pevUtlimaVezGenerado], [pevNroLote]) VALUES (6346, 669, N'ROSAS RENTERIA MARTIN    ', N'38225858', N'20382258585', N'V', N'03', N'11', N'90077214', N'90012', 30000, CAST(N'2022-06-30' AS Date), 0, 0, NULL, NULL)
INSERT [dbo].[PagosEventuales] ([pevId], [lpaId], [ageApellidoNombre], [ageDNI], [ageCUIT], [ageSexo], [ageJurisdiccion], [agePrograma], [ageNroControl], [pevLugarPagoCodigo], [pevImporteTotal], [pevFechaCarga], [pevGenerado], [pevPagoAcumulado], [pevUtlimaVezGenerado], [pevNroLote]) VALUES (6347, 669, N'DOMINGUEZ JOSE MARIA     ', N'40603783', N'20406037836', N'V', N'03', N'11', N'90077714', N'90012', 30000, CAST(N'2022-06-30' AS Date), 0, 0, NULL, NULL)
INSERT [dbo].[PagosEventuales] ([pevId], [lpaId], [ageApellidoNombre], [ageDNI], [ageCUIT], [ageSexo], [ageJurisdiccion], [agePrograma], [ageNroControl], [pevLugarPagoCodigo], [pevImporteTotal], [pevFechaCarga], [pevGenerado], [pevPagoAcumulado], [pevUtlimaVezGenerado], [pevNroLote]) VALUES (6348, 669, N'MONTENEGRO HARO GUSTAVO A', N'40782025', N'20407820259', N'V', N'03', N'11', N'90077015', N'90012', 30000, CAST(N'2022-06-30' AS Date), 0, 0, NULL, NULL)
INSERT [dbo].[PagosEventuales] ([pevId], [lpaId], [ageApellidoNombre], [ageDNI], [ageCUIT], [ageSexo], [ageJurisdiccion], [agePrograma], [ageNroControl], [pevLugarPagoCodigo], [pevImporteTotal], [pevFechaCarga], [pevGenerado], [pevPagoAcumulado], [pevUtlimaVezGenerado], [pevNroLote]) VALUES (6349, 669, N'GUARDO PAOLA SILVANA     ', N'36045300', N'27360453001', N'M', N'03', N'11', N'90077112', N'90012', 30000, CAST(N'2022-06-30' AS Date), 0, 0, NULL, NULL)
INSERT [dbo].[PagosEventuales] ([pevId], [lpaId], [ageApellidoNombre], [ageDNI], [ageCUIT], [ageSexo], [ageJurisdiccion], [agePrograma], [ageNroControl], [pevLugarPagoCodigo], [pevImporteTotal], [pevFechaCarga], [pevGenerado], [pevPagoAcumulado], [pevUtlimaVezGenerado], [pevNroLote]) VALUES (6350, 669, N'ESPECHE MARINA ANTONELLA ', N'40051095', N'23400510954', N'M', N'03', N'11', N'90077612', N'90012', 30000, CAST(N'2022-06-30' AS Date), 0, 0, NULL, NULL)
INSERT [dbo].[PagosEventuales] ([pevId], [lpaId], [ageApellidoNombre], [ageDNI], [ageCUIT], [ageSexo], [ageJurisdiccion], [agePrograma], [ageNroControl], [pevLugarPagoCodigo], [pevImporteTotal], [pevFechaCarga], [pevGenerado], [pevPagoAcumulado], [pevUtlimaVezGenerado], [pevNroLote]) VALUES (6351, 669, N'GROS JUAREZ LAUTARO JOEL ', N'39498608', N'23394986089', N'V', N'03', N'11', N'90077413', N'90012', 30000, CAST(N'2022-06-30' AS Date), 0, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[PagosEventuales] OFF

