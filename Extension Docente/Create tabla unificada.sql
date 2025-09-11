USE [LiquidacionSueldos]
GO

/****** Object:  Table [dbo].[agentes_extension_docente_abril25_unificado]    Script Date: 18/6/2025 19:05:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[agentes_extension_docente_abril25_unificado](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[age_id] [int] NULL,
	[NroCOntrol] [varchar](50) NULL,
	[PlantaTipo] [varchar](50) NULL,
	[tipo_planta_OP] [varchar](50) NULL,
	[agrupamiento] [varchar](50) NULL,
	[tramo] [varchar](50) NULL,
	[apertura] [varchar](50) NULL,
	[cuil] [varchar](50) NULL,
	[LugarPago] [varchar](50) NULL,
	[Escuela] [varchar](50) NULL,
	[Juris] [varchar](50) NULL,
	[Prog] [varchar](50) NULL,
	[SubP] [varchar](50) NULL,
	[Actividad] [varchar](50) NULL,
	[fuente] [varchar](50) NULL,
	[dias_trabajados] [varchar](50) NULL,
	[haberSinAporte] [varchar](50) NULL,
	[haberConAporte] [varchar](50) NULL,
	[total_haberes] [varchar](50) NULL,
	[total_descuentos] [varchar](50) NULL,
	[total_liquido] [varchar](50) NULL,
	[AP_IOSEP] [numeric](18, 2) NULL,
	[AP_OSPLAD] [numeric](18, 2) NULL,
	[AP_ANSES] [numeric](18, 2) NULL,
	[C01] [varchar](50) NULL,
	[I01] [varchar](50) NULL,
	[C02] [varchar](50) NULL,
	[I02] [varchar](50) NULL,
	[C03] [varchar](50) NULL,
	[I03] [varchar](50) NULL,
	[C04] [varchar](50) NULL,
	[I04] [varchar](50) NULL,
	[C05] [varchar](50) NULL,
	[I05] [varchar](50) NULL,
	[C06] [varchar](50) NULL,
	[I06] [varchar](50) NULL,
	[C07] [varchar](50) NULL,
	[I07] [varchar](50) NULL,
	[C08] [varchar](50) NULL,
	[I08] [varchar](50) NULL,
	[C09] [varchar](50) NULL,
	[I09] [varchar](50) NULL,
	[C10] [varchar](50) NULL,
	[I10] [varchar](50) NULL,
	[mes] [varchar](2) NULL,
	[anio] [varchar](2) NULL,
	[liq_id] [int] NULL,
	[fecha_creacion] [datetime] NULL,
	[recibo_id] [int] NULL,
 CONSTRAINT [PK_agentes_extension_docente_abril25_unificado] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[agentes_extension_docente_abril25_unificado]  WITH CHECK ADD  CONSTRAINT [FK_agentes_extension_docente_abril25_unificado_LiquidacionExtensionDocente] FOREIGN KEY([liq_id])
REFERENCES [dbo].[LiquidacionExtensionDocente] ([id])
GO

ALTER TABLE [dbo].[agentes_extension_docente_abril25_unificado] CHECK CONSTRAINT [FK_agentes_extension_docente_abril25_unificado_LiquidacionExtensionDocente]
GO
