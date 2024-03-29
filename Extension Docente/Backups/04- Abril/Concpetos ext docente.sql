USE [LiquidacionSueldos]
GO
/****** Object:  Table [dbo].[ConceptoExtensionDocente]    Script Date: 28/4/2023 15:02:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ConceptoExtensionDocente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[conId] [int] NULL,
	[conCodigo] [varchar](50) NULL,
 CONSTRAINT [PK_ConceptoExtensionDoente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[ConceptoExtensionDocente] ON 

INSERT [dbo].[ConceptoExtensionDocente] ([id], [conId], [conCodigo]) VALUES (56, 2, N'002')
INSERT [dbo].[ConceptoExtensionDocente] ([id], [conId], [conCodigo]) VALUES (57, 20, N'020')
INSERT [dbo].[ConceptoExtensionDocente] ([id], [conId], [conCodigo]) VALUES (58, 67, N'069')
INSERT [dbo].[ConceptoExtensionDocente] ([id], [conId], [conCodigo]) VALUES (59, 68, N'070')
INSERT [dbo].[ConceptoExtensionDocente] ([id], [conId], [conCodigo]) VALUES (60, 69, N'071')
INSERT [dbo].[ConceptoExtensionDocente] ([id], [conId], [conCodigo]) VALUES (61, 71, N'073')
INSERT [dbo].[ConceptoExtensionDocente] ([id], [conId], [conCodigo]) VALUES (62, 72, N'074')
INSERT [dbo].[ConceptoExtensionDocente] ([id], [conId], [conCodigo]) VALUES (63, 75, N'077')
INSERT [dbo].[ConceptoExtensionDocente] ([id], [conId], [conCodigo]) VALUES (64, 106, N'111')
INSERT [dbo].[ConceptoExtensionDocente] ([id], [conId], [conCodigo]) VALUES (65, 107, N'112')
INSERT [dbo].[ConceptoExtensionDocente] ([id], [conId], [conCodigo]) VALUES (66, 108, N'113')
INSERT [dbo].[ConceptoExtensionDocente] ([id], [conId], [conCodigo]) VALUES (67, 109, N'114')
INSERT [dbo].[ConceptoExtensionDocente] ([id], [conId], [conCodigo]) VALUES (68, 110, N'115')
INSERT [dbo].[ConceptoExtensionDocente] ([id], [conId], [conCodigo]) VALUES (69, 113, N'118')
INSERT [dbo].[ConceptoExtensionDocente] ([id], [conId], [conCodigo]) VALUES (70, 129, N'137')
INSERT [dbo].[ConceptoExtensionDocente] ([id], [conId], [conCodigo]) VALUES (71, 158, N'166')
INSERT [dbo].[ConceptoExtensionDocente] ([id], [conId], [conCodigo]) VALUES (72, 191, N'199')
INSERT [dbo].[ConceptoExtensionDocente] ([id], [conId], [conCodigo]) VALUES (73, 207, N'215')
INSERT [dbo].[ConceptoExtensionDocente] ([id], [conId], [conCodigo]) VALUES (74, 208, N'216')
INSERT [dbo].[ConceptoExtensionDocente] ([id], [conId], [conCodigo]) VALUES (75, 389, N'503')
INSERT [dbo].[ConceptoExtensionDocente] ([id], [conId], [conCodigo]) VALUES (76, 736, N'523')
INSERT [dbo].[ConceptoExtensionDocente] ([id], [conId], [conCodigo]) VALUES (77, 402, N'550')
INSERT [dbo].[ConceptoExtensionDocente] ([id], [conId], [conCodigo]) VALUES (78, 404, N'559')
INSERT [dbo].[ConceptoExtensionDocente] ([id], [conId], [conCodigo]) VALUES (79, 436, N'591')
INSERT [dbo].[ConceptoExtensionDocente] ([id], [conId], [conCodigo]) VALUES (80, 440, N'595')
INSERT [dbo].[ConceptoExtensionDocente] ([id], [conId], [conCodigo]) VALUES (81, 442, N'597')
INSERT [dbo].[ConceptoExtensionDocente] ([id], [conId], [conCodigo]) VALUES (82, 112, N'117')
SET IDENTITY_INSERT [dbo].[ConceptoExtensionDocente] OFF
