USE [Embargos]
GO
/****** Object:  Table [dbo].[auto]    Script Date: 24/1/2025 18:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[auto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[cuenta] [bigint] NULL,
	[cuil] [varchar](11) NULL,
	[created_at] [date] NULL,
	[updated_at] [date] NULL,
	[deleted_at] [date] NULL,
 CONSTRAINT [PK_auto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[banco]    Script Date: 24/1/2025 18:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[banco](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[sucursal] [varchar](50) NULL,
	[created_at] [date] NULL,
	[updated_at] [date] NULL,
	[deleted_at] [date] NULL,
 CONSTRAINT [PK_banco] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[carga_familia_cabecera]    Script Date: 24/1/2025 18:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[carga_familia_cabecera](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[planta] [varchar](1) NULL,
	[legajo] [varchar](7) NULL,
	[numero_control] [varchar](8) NULL,
	[created_at] [date] NULL,
	[updated_at] [date] NULL,
	[deleted_at] [date] NULL,
 CONSTRAINT [PK_carga_familia_cabecera] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[carga_familia_detalle]    Script Date: 24/1/2025 18:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[carga_familia_detalle](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[carga_familia_cabecera_id] [int] NULL,
	[orden] [varchar](2) NULL,
	[fecha_novedad] [varchar](6) NULL,
	[estado_civil] [varchar](1) NULL,
	[salario] [varchar](1) NULL,
	[apellido_nombre] [varchar](30) NULL,
	[tipo_documento] [varchar](1) NULL,
	[numero_documento] [varchar](8) NULL,
	[sexo] [varchar](1) NULL,
	[escolaridad] [varchar](1) NULL,
	[invalidez] [varchar](1) NULL,
	[created_at] [date] NULL,
	[updated_at] [date] NULL,
	[deleted_at] [date] NULL,
 CONSTRAINT [PK_carga_familia_detalle] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[embargo]    Script Date: 24/1/2025 18:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[embargo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[oficio_encabezado_id] [int] NULL,
	[embargo_tipo_id] [int] NULL,
	[fecha_inicio] [date] NULL,
	[numero_control] [varchar](8) NULL,
	[planta] [varchar](1) NULL,
	[created_at] [date] NULL,
	[updated_at] [date] NULL,
	[deleted_at] [date] NULL,
 CONSTRAINT [PK_embargo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[embargo_tipo]    Script Date: 24/1/2025 18:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[embargo_tipo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[created_at] [date] NULL,
	[updated_at] [date] NULL,
	[deleted_at] [date] NULL,
 CONSTRAINT [PK_embargo_tipo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[embargos_efectuados]    Script Date: 24/1/2025 18:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[embargos_efectuados](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[monto_descontado] [numeric](18, 2) NULL,
	[numero_orden] [int] NULL,
	[liquidacion_id] [int] NULL,
	[embargo_id] [int] NULL,
	[created_at] [date] NULL,
	[updated_at] [date] NULL,
	[deleted_at] [date] NULL,
 CONSTRAINT [PK_embargos_efectuados] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[expediente]    Script Date: 24/1/2025 18:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[expediente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[gedo] [bit] NULL,
	[codigo] [varchar](50) NULL,
	[fecha_ingreso] [date] NULL,
	[oficio_encabezado_id] [int] NULL,
	[created_at] [date] NULL,
	[updated_at] [date] NULL,
	[deleted_at] [date] NULL,
 CONSTRAINT [PK_expediente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[juzgado]    Script Date: 24/1/2025 18:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[juzgado](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](200) NULL,
	[created_at] [date] NULL,
	[updated_at] [date] NULL,
	[deleted_at] [date] NULL,
 CONSTRAINT [PK_juzgado] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[liquidacion_embargos]    Script Date: 24/1/2025 18:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[liquidacion_embargos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mes] [varchar](50) NULL,
	[anio] [varchar](50) NULL,
	[estado] [varchar](1) NULL,
	[created_at] [date] NULL,
	[updated_at] [date] NULL,
	[deleted_at] [date] NULL,
 CONSTRAINT [PK_liquidacion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[oficio_carga_familia]    Script Date: 24/1/2025 18:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[oficio_carga_familia](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[carga_familia_detalle_id] [int] NULL,
	[oficio_detalle_familia_id] [int] NULL,
	[created_at] [date] NULL,
	[updated_at] [date] NULL,
	[deleted_at] [date] NULL,
 CONSTRAINT [PK_oficio_carga_familia] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[oficio_detalle_comercial]    Script Date: 24/1/2025 18:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[oficio_detalle_comercial](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[oficio_encabezado_id] [int] NULL,
	[monto] [numeric](18, 2) NULL,
	[created_at] [date] NULL,
	[updated_at] [date] NULL,
	[deleted_at] [date] NULL,
 CONSTRAINT [PK_oficio_detalle_comercial] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[oficio_detalle_familia]    Script Date: 24/1/2025 18:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[oficio_detalle_familia](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[oficio_encabezado_id] [int] NULL,
	[porcentaje] [int] NULL,
	[haberes] [bit] NULL,
	[sac] [bit] NULL,
	[asignaciones_familiares] [bit] NULL,
	[ayuda_escolar] [bit] NULL,
	[bonos] [bit] NULL,
	[obra_social] [bit] NULL,
	[created_at] [date] NULL,
	[updated_at] [date] NULL,
	[deleted_at] [date] NULL,
 CONSTRAINT [PK_oficio_detalle_familiar] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[oficio_encabezado]    Script Date: 24/1/2025 18:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[oficio_encabezado](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[auto_id] [int] NULL,
	[juzgado_id] [int] NULL,
	[numero_control_demandado] [varchar](8) NULL,
	[cuil_demandado] [varchar](11) NULL,
	[banco_id] [int] NULL,
	[cuenta_judicial] [varchar](50) NULL,
	[cbu] [bigint] NULL,
	[expediente_id] [int] NULL,
	[expediente_judicial] [varchar](50) NULL,
	[created_at] [date] NULL,
	[updated_at] [date] NULL,
	[deleted_at] [date] NULL,
 CONSTRAINT [PK_oficio_encabezado] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Products]    Script Date: 24/1/2025 18:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Products](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[description] [varchar](255) NULL,
	[image] [varchar](100) NULL,
	[idCategoryProduct] [int] NOT NULL,
	[price] [decimal](10, 0) NOT NULL,
	[discount] [tinyint] NOT NULL,
	[idColor] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[auto] ON 

INSERT [dbo].[auto] ([id], [nombre], [cuenta], [cuil], [created_at], [updated_at], [deleted_at]) VALUES (11, N'test10', 123456, N'12345', CAST(N'1900-01-01' AS Date), NULL, NULL)
INSERT [dbo].[auto] ([id], [nombre], [cuenta], [cuil], [created_at], [updated_at], [deleted_at]) VALUES (12, N'test10', 123456, N'12345', CAST(N'1900-01-01' AS Date), NULL, NULL)
INSERT [dbo].[auto] ([id], [nombre], [cuenta], [cuil], [created_at], [updated_at], [deleted_at]) VALUES (13, N'test10', 123456, N'12345', CAST(N'1900-01-01' AS Date), NULL, NULL)
INSERT [dbo].[auto] ([id], [nombre], [cuenta], [cuil], [created_at], [updated_at], [deleted_at]) VALUES (14, N'test10', 123456, N'12345', CAST(N'1900-01-01' AS Date), NULL, NULL)
INSERT [dbo].[auto] ([id], [nombre], [cuenta], [cuil], [created_at], [updated_at], [deleted_at]) VALUES (15, N'test10', 123456, N'12345', CAST(N'1900-01-01' AS Date), NULL, NULL)
INSERT [dbo].[auto] ([id], [nombre], [cuenta], [cuil], [created_at], [updated_at], [deleted_at]) VALUES (16, N'test10', 123456, N'12345', CAST(N'1900-01-01' AS Date), NULL, NULL)
INSERT [dbo].[auto] ([id], [nombre], [cuenta], [cuil], [created_at], [updated_at], [deleted_at]) VALUES (17, N'test10', 123456, N'12345', CAST(N'1900-01-01' AS Date), NULL, NULL)
INSERT [dbo].[auto] ([id], [nombre], [cuenta], [cuil], [created_at], [updated_at], [deleted_at]) VALUES (18, N'test10', 123456, N'12345', CAST(N'1900-01-01' AS Date), NULL, CAST(N'2024-08-28' AS Date))
INSERT [dbo].[auto] ([id], [nombre], [cuenta], [cuil], [created_at], [updated_at], [deleted_at]) VALUES (19, N'test13', 1234568, N'20368783545', CAST(N'1900-01-01' AS Date), NULL, CAST(N'2024-08-28' AS Date))
INSERT [dbo].[auto] ([id], [nombre], [cuenta], [cuil], [created_at], [updated_at], [deleted_at]) VALUES (20, N'maria chara', 123456, N'20368783545', CAST(N'2024-08-28' AS Date), CAST(N'2024-08-28' AS Date), NULL)
INSERT [dbo].[auto] ([id], [nombre], [cuenta], [cuil], [created_at], [updated_at], [deleted_at]) VALUES (21, N'stefano', 456789, N'20368783545', CAST(N'2024-08-28' AS Date), CAST(N'2024-08-28' AS Date), NULL)
INSERT [dbo].[auto] ([id], [nombre], [cuenta], [cuil], [created_at], [updated_at], [deleted_at]) VALUES (22, N'stefano', 456789, N'20368783545', CAST(N'2024-09-04' AS Date), CAST(N'2024-09-04' AS Date), NULL)
INSERT [dbo].[auto] ([id], [nombre], [cuenta], [cuil], [created_at], [updated_at], [deleted_at]) VALUES (23, N'juana', 123456789, N'20123456789', CAST(N'2025-01-23' AS Date), CAST(N'2025-01-23' AS Date), NULL)
INSERT [dbo].[auto] ([id], [nombre], [cuenta], [cuil], [created_at], [updated_at], [deleted_at]) VALUES (30, N'eugenia', 12345678911, N'20368783545', CAST(N'2025-01-23' AS Date), CAST(N'2025-01-23' AS Date), NULL)
INSERT [dbo].[auto] ([id], [nombre], [cuenta], [cuil], [created_at], [updated_at], [deleted_at]) VALUES (31, N'juliana', 123456, N'20368783545', CAST(N'2025-01-23' AS Date), CAST(N'2025-01-23' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[auto] OFF
SET IDENTITY_INSERT [dbo].[banco] ON 

INSERT [dbo].[banco] ([id], [descripcion], [sucursal], [created_at], [updated_at], [deleted_at]) VALUES (1, N'bse', N'151', NULL, NULL, NULL)
INSERT [dbo].[banco] ([id], [descripcion], [sucursal], [created_at], [updated_at], [deleted_at]) VALUES (2, N'BSE', N'asd', CAST(N'2024-09-04' AS Date), CAST(N'2024-09-04' AS Date), NULL)
INSERT [dbo].[banco] ([id], [descripcion], [sucursal], [created_at], [updated_at], [deleted_at]) VALUES (3, N'test 500', N'500', CAST(N'2024-09-04' AS Date), CAST(N'2024-09-05' AS Date), NULL)
INSERT [dbo].[banco] ([id], [descripcion], [sucursal], [created_at], [updated_at], [deleted_at]) VALUES (4, N'bse 5', N'abc', CAST(N'2024-09-04' AS Date), CAST(N'2024-09-05' AS Date), CAST(N'2024-09-05' AS Date))
INSERT [dbo].[banco] ([id], [descripcion], [sucursal], [created_at], [updated_at], [deleted_at]) VALUES (5, N'test 500', N'200', CAST(N'2024-09-17' AS Date), CAST(N'2024-09-17' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[banco] OFF
SET IDENTITY_INSERT [dbo].[carga_familia_cabecera] ON 

INSERT [dbo].[carga_familia_cabecera] ([id], [planta], [legajo], [numero_control], [created_at], [updated_at], [deleted_at]) VALUES (1, N'T', N'1234567', N'12345678', CAST(N'2024-10-23' AS Date), CAST(N'2024-10-23' AS Date), CAST(N'2024-10-23' AS Date))
INSERT [dbo].[carga_familia_cabecera] ([id], [planta], [legajo], [numero_control], [created_at], [updated_at], [deleted_at]) VALUES (2, N'P', N'1234567', N'12345678', CAST(N'2024-10-23' AS Date), CAST(N'2024-10-23' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[carga_familia_cabecera] OFF
SET IDENTITY_INSERT [dbo].[carga_familia_detalle] ON 

INSERT [dbo].[carga_familia_detalle] ([id], [carga_familia_cabecera_id], [orden], [fecha_novedad], [estado_civil], [salario], [apellido_nombre], [tipo_documento], [numero_documento], [sexo], [escolaridad], [invalidez], [created_at], [updated_at], [deleted_at]) VALUES (12, 2, N'01', N'041224', N'2', N'1', N'TREJO STEFANO', N'1', N'36878354', N'V', N'0', N'0', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[carga_familia_detalle] OFF
SET IDENTITY_INSERT [dbo].[embargo] ON 

INSERT [dbo].[embargo] ([id], [oficio_encabezado_id], [embargo_tipo_id], [fecha_inicio], [numero_control], [planta], [created_at], [updated_at], [deleted_at]) VALUES (1, 3, 1, CAST(N'2024-10-23' AS Date), N'12345678', N'T', CAST(N'2024-10-23' AS Date), CAST(N'2024-10-23' AS Date), CAST(N'2024-10-23' AS Date))
INSERT [dbo].[embargo] ([id], [oficio_encabezado_id], [embargo_tipo_id], [fecha_inicio], [numero_control], [planta], [created_at], [updated_at], [deleted_at]) VALUES (2, 3, 1, CAST(N'2024-09-18' AS Date), N'12345678', N'P', CAST(N'2024-10-23' AS Date), CAST(N'2024-10-23' AS Date), NULL)
INSERT [dbo].[embargo] ([id], [oficio_encabezado_id], [embargo_tipo_id], [fecha_inicio], [numero_control], [planta], [created_at], [updated_at], [deleted_at]) VALUES (3, 3, 1, CAST(N'2024-09-18' AS Date), N'12345678', N'1', CAST(N'2024-10-23' AS Date), CAST(N'2024-10-23' AS Date), NULL)
INSERT [dbo].[embargo] ([id], [oficio_encabezado_id], [embargo_tipo_id], [fecha_inicio], [numero_control], [planta], [created_at], [updated_at], [deleted_at]) VALUES (4, 3, 1, CAST(N'2024-09-18' AS Date), N'12345678', N'p', CAST(N'2024-10-23' AS Date), CAST(N'2024-10-23' AS Date), NULL)
INSERT [dbo].[embargo] ([id], [oficio_encabezado_id], [embargo_tipo_id], [fecha_inicio], [numero_control], [planta], [created_at], [updated_at], [deleted_at]) VALUES (5, 3, 1, CAST(N'2024-09-18' AS Date), N'12345678', N't', CAST(N'2024-10-23' AS Date), CAST(N'2024-10-23' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[embargo] OFF
SET IDENTITY_INSERT [dbo].[embargo_tipo] ON 

INSERT [dbo].[embargo_tipo] ([id], [descripcion], [created_at], [updated_at], [deleted_at]) VALUES (1, N'comercial', CAST(N'2024-09-12' AS Date), CAST(N'2024-09-12' AS Date), CAST(N'2024-09-12' AS Date))
SET IDENTITY_INSERT [dbo].[embargo_tipo] OFF
SET IDENTITY_INSERT [dbo].[embargos_efectuados] ON 

INSERT [dbo].[embargos_efectuados] ([id], [monto_descontado], [numero_orden], [liquidacion_id], [embargo_id], [created_at], [updated_at], [deleted_at]) VALUES (2, CAST(2000.00 AS Numeric(18, 2)), 1234, 2, 3, CAST(N'2024-11-07' AS Date), CAST(N'2024-11-07' AS Date), CAST(N'2024-11-07' AS Date))
SET IDENTITY_INSERT [dbo].[embargos_efectuados] OFF
SET IDENTITY_INSERT [dbo].[expediente] ON 

INSERT [dbo].[expediente] ([id], [gedo], [codigo], [fecha_ingreso], [oficio_encabezado_id], [created_at], [updated_at], [deleted_at]) VALUES (2, 1, N'EX 2024 0123456 SGO MS', CAST(N'2023-09-18' AS Date), 1000, CAST(N'2024-09-18' AS Date), CAST(N'2024-09-18' AS Date), NULL)
INSERT [dbo].[expediente] ([id], [gedo], [codigo], [fecha_ingreso], [oficio_encabezado_id], [created_at], [updated_at], [deleted_at]) VALUES (3, 1, N'EX 2024 0123456 SGO MS', CAST(N'2024-09-18' AS Date), 12, CAST(N'2024-09-18' AS Date), CAST(N'2024-09-18' AS Date), NULL)
INSERT [dbo].[expediente] ([id], [gedo], [codigo], [fecha_ingreso], [oficio_encabezado_id], [created_at], [updated_at], [deleted_at]) VALUES (4, 1, N'EX 2024 0123456 SGO MS', CAST(N'2024-09-18' AS Date), 12, CAST(N'2024-09-18' AS Date), CAST(N'2024-09-18' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[expediente] OFF
SET IDENTITY_INSERT [dbo].[juzgado] ON 

INSERT [dbo].[juzgado] ([id], [descripcion], [created_at], [updated_at], [deleted_at]) VALUES (1, N'test 500', CAST(N'2024-09-05' AS Date), CAST(N'2024-09-05' AS Date), CAST(N'2024-09-05' AS Date))
SET IDENTITY_INSERT [dbo].[juzgado] OFF
SET IDENTITY_INSERT [dbo].[liquidacion_embargos] ON 

INSERT [dbo].[liquidacion_embargos] ([id], [mes], [anio], [estado], [created_at], [updated_at], [deleted_at]) VALUES (1, N'10', N'23', N'P', CAST(N'2024-09-18' AS Date), CAST(N'2024-09-18' AS Date), CAST(N'2024-09-18' AS Date))
INSERT [dbo].[liquidacion_embargos] ([id], [mes], [anio], [estado], [created_at], [updated_at], [deleted_at]) VALUES (2, N'10', N'24', N'P', CAST(N'2024-10-23' AS Date), CAST(N'2024-10-23' AS Date), CAST(N'2024-10-23' AS Date))
SET IDENTITY_INSERT [dbo].[liquidacion_embargos] OFF
SET IDENTITY_INSERT [dbo].[oficio_carga_familia] ON 

INSERT [dbo].[oficio_carga_familia] ([id], [carga_familia_detalle_id], [oficio_detalle_familia_id], [created_at], [updated_at], [deleted_at]) VALUES (2, 12, 3, CAST(N'2024-12-05' AS Date), CAST(N'2024-12-05' AS Date), CAST(N'2024-12-05' AS Date))
SET IDENTITY_INSERT [dbo].[oficio_carga_familia] OFF
SET IDENTITY_INSERT [dbo].[oficio_detalle_familia] ON 

INSERT [dbo].[oficio_detalle_familia] ([id], [oficio_encabezado_id], [porcentaje], [haberes], [sac], [asignaciones_familiares], [ayuda_escolar], [bonos], [obra_social], [created_at], [updated_at], [deleted_at]) VALUES (1, 3, 50, 1, 1, 1, 1, 1, 1, NULL, NULL, NULL)
INSERT [dbo].[oficio_detalle_familia] ([id], [oficio_encabezado_id], [porcentaje], [haberes], [sac], [asignaciones_familiares], [ayuda_escolar], [bonos], [obra_social], [created_at], [updated_at], [deleted_at]) VALUES (3, 4, 40, 1, 1, 1, 1, 1, 1, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[oficio_detalle_familia] OFF
SET IDENTITY_INSERT [dbo].[oficio_encabezado] ON 

INSERT [dbo].[oficio_encabezado] ([id], [auto_id], [juzgado_id], [numero_control_demandado], [cuil_demandado], [banco_id], [cuenta_judicial], [cbu], [expediente_id], [expediente_judicial], [created_at], [updated_at], [deleted_at]) VALUES (3, 22, 1, N'12345678', N'20368783545', 1, N'123456', 3100052807141721, 2, N'DEF', CAST(N'2024-10-22' AS Date), CAST(N'2024-10-22' AS Date), NULL)
INSERT [dbo].[oficio_encabezado] ([id], [auto_id], [juzgado_id], [numero_control_demandado], [cuil_demandado], [banco_id], [cuenta_judicial], [cbu], [expediente_id], [expediente_judicial], [created_at], [updated_at], [deleted_at]) VALUES (4, 21, 1, N'12345678', N'20368783545', 1, N'123456', 3100052807141721, 2, N'3100052807141721', CAST(N'2024-10-22' AS Date), CAST(N'2024-10-22' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[oficio_encabezado] OFF
ALTER TABLE [dbo].[carga_familia_detalle]  WITH CHECK ADD  CONSTRAINT [FK_carga_familia_detalle_carga_familia_cabecera] FOREIGN KEY([carga_familia_cabecera_id])
REFERENCES [dbo].[carga_familia_cabecera] ([id])
GO
ALTER TABLE [dbo].[carga_familia_detalle] CHECK CONSTRAINT [FK_carga_familia_detalle_carga_familia_cabecera]
GO
ALTER TABLE [dbo].[embargo]  WITH CHECK ADD  CONSTRAINT [FK_embargo_embargo_tipo] FOREIGN KEY([embargo_tipo_id])
REFERENCES [dbo].[embargo_tipo] ([id])
GO
ALTER TABLE [dbo].[embargo] CHECK CONSTRAINT [FK_embargo_embargo_tipo]
GO
ALTER TABLE [dbo].[embargo]  WITH CHECK ADD  CONSTRAINT [FK_embargo_oficio_encabezado] FOREIGN KEY([oficio_encabezado_id])
REFERENCES [dbo].[oficio_encabezado] ([id])
GO
ALTER TABLE [dbo].[embargo] CHECK CONSTRAINT [FK_embargo_oficio_encabezado]
GO
ALTER TABLE [dbo].[embargos_efectuados]  WITH CHECK ADD  CONSTRAINT [FK_embargos_efectuados_embargo] FOREIGN KEY([embargo_id])
REFERENCES [dbo].[embargo] ([id])
GO
ALTER TABLE [dbo].[embargos_efectuados] CHECK CONSTRAINT [FK_embargos_efectuados_embargo]
GO
ALTER TABLE [dbo].[embargos_efectuados]  WITH CHECK ADD  CONSTRAINT [FK_embargos_efectuados_liquidacion] FOREIGN KEY([liquidacion_id])
REFERENCES [dbo].[liquidacion_embargos] ([id])
GO
ALTER TABLE [dbo].[embargos_efectuados] CHECK CONSTRAINT [FK_embargos_efectuados_liquidacion]
GO
ALTER TABLE [dbo].[oficio_carga_familia]  WITH CHECK ADD  CONSTRAINT [FK_oficio_carga_familia_carga_familia_detalle] FOREIGN KEY([carga_familia_detalle_id])
REFERENCES [dbo].[carga_familia_detalle] ([id])
GO
ALTER TABLE [dbo].[oficio_carga_familia] CHECK CONSTRAINT [FK_oficio_carga_familia_carga_familia_detalle]
GO
ALTER TABLE [dbo].[oficio_carga_familia]  WITH CHECK ADD  CONSTRAINT [FK_oficio_carga_familia_oficio_detalle_familiar] FOREIGN KEY([oficio_detalle_familia_id])
REFERENCES [dbo].[oficio_detalle_familia] ([id])
GO
ALTER TABLE [dbo].[oficio_carga_familia] CHECK CONSTRAINT [FK_oficio_carga_familia_oficio_detalle_familiar]
GO
ALTER TABLE [dbo].[oficio_detalle_comercial]  WITH CHECK ADD  CONSTRAINT [FK_oficio_detalle_comercial_oficio_encabezado] FOREIGN KEY([oficio_encabezado_id])
REFERENCES [dbo].[oficio_encabezado] ([id])
GO
ALTER TABLE [dbo].[oficio_detalle_comercial] CHECK CONSTRAINT [FK_oficio_detalle_comercial_oficio_encabezado]
GO
ALTER TABLE [dbo].[oficio_detalle_familia]  WITH CHECK ADD  CONSTRAINT [FK_oficio_detalle_familiar_oficio_encabezado] FOREIGN KEY([oficio_encabezado_id])
REFERENCES [dbo].[oficio_encabezado] ([id])
GO
ALTER TABLE [dbo].[oficio_detalle_familia] CHECK CONSTRAINT [FK_oficio_detalle_familiar_oficio_encabezado]
GO
ALTER TABLE [dbo].[oficio_encabezado]  WITH CHECK ADD  CONSTRAINT [FK_oficio_encabezado_auto] FOREIGN KEY([auto_id])
REFERENCES [dbo].[auto] ([id])
GO
ALTER TABLE [dbo].[oficio_encabezado] CHECK CONSTRAINT [FK_oficio_encabezado_auto]
GO
ALTER TABLE [dbo].[oficio_encabezado]  WITH CHECK ADD  CONSTRAINT [FK_oficio_encabezado_banco] FOREIGN KEY([banco_id])
REFERENCES [dbo].[banco] ([id])
GO
ALTER TABLE [dbo].[oficio_encabezado] CHECK CONSTRAINT [FK_oficio_encabezado_banco]
GO
ALTER TABLE [dbo].[oficio_encabezado]  WITH CHECK ADD  CONSTRAINT [FK_oficio_encabezado_expediente] FOREIGN KEY([expediente_id])
REFERENCES [dbo].[expediente] ([id])
GO
ALTER TABLE [dbo].[oficio_encabezado] CHECK CONSTRAINT [FK_oficio_encabezado_expediente]
GO
ALTER TABLE [dbo].[oficio_encabezado]  WITH CHECK ADD  CONSTRAINT [FK_oficio_encabezado_juzgado] FOREIGN KEY([juzgado_id])
REFERENCES [dbo].[juzgado] ([id])
GO
ALTER TABLE [dbo].[oficio_encabezado] CHECK CONSTRAINT [FK_oficio_encabezado_juzgado]
GO
