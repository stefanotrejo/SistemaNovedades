USE [LiquidacionSueldos]
GO
/****** Object:  Table [dbo].[DetallePagoEventual]    Script Date: 30/06/2022 20:12:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DetallePagoEventual](
	[dpeId] [int] IDENTITY(1,1) NOT NULL,
	[pevId] [int] NULL,
	[dpeMes] [int] NULL,
	[dpeAnio] [int] NULL,
	[dpeConcepto] [varchar](50) NULL,
 CONSTRAINT [PK_DetallePagoEventual_5] PRIMARY KEY CLUSTERED 
(
	[dpeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[DetallePagoEventual] ON 


INSERT [dbo].[DetallePagoEventual] ([dpeId], [pevId], [dpeMes], [dpeAnio], [dpeConcepto]) VALUES (296, 6352, 6, 2022, N'Bono aguinaldo 2022')
INSERT [dbo].[DetallePagoEventual] ([dpeId], [pevId], [dpeMes], [dpeAnio], [dpeConcepto]) VALUES (297, 6353, 6, 2022, N'Bono aguinaldo 2022')
INSERT [dbo].[DetallePagoEventual] ([dpeId], [pevId], [dpeMes], [dpeAnio], [dpeConcepto]) VALUES (298, 6354, 6, 2022, N'Bono aguinaldo 2022')
INSERT [dbo].[DetallePagoEventual] ([dpeId], [pevId], [dpeMes], [dpeAnio], [dpeConcepto]) VALUES (299, 6355, 6, 2022, N'Bono aguinaldo 2022')
INSERT [dbo].[DetallePagoEventual] ([dpeId], [pevId], [dpeMes], [dpeAnio], [dpeConcepto]) VALUES (300, 6356, 6, 2022, N'Bono aguinaldo 2022')
INSERT [dbo].[DetallePagoEventual] ([dpeId], [pevId], [dpeMes], [dpeAnio], [dpeConcepto]) VALUES (301, 6357, 6, 2022, N'Bono aguinaldo 2022')
SET IDENTITY_INSERT [dbo].[DetallePagoEventual] OFF


exec [PagosEventuales.GenerarExcel] '30/06/2022'