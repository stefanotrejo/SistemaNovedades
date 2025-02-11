USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[PagosEventuales.Insertar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[PagosEventuales.Insertar]
(
@ageApellidoNombre nvarchar(255),
@ageDNI nvarchar (255),
@lpaId int,
@ageImporte float,
@ageCUIT nvarchar (255),
@sexo nvarchar(255),
@ageNroControl nvarchar (255),
@pevLugarPagoCodigo varchar(50),
@acumulado tinyint,
@ageJurisdiccion varchar(3),
@agePrograma  varchar(3)
)
as 
Insert into PagosEventuales (
[lpaId],
[ageApellidoNombre],
[ageDNI],
[ageCUIT],
[ageSexo],
[ageNroControl],
[pevLugarPagoCodigo],
[pevImporteTotal],
[pevFechaCarga],
[pevGenerado],
[pevPagoAcumulado],
[ageJurisdiccion],
[agePrograma])
values (
@lpaId,
@ageApellidoNombre,
@ageDNI,
@ageCUIT,
@sexo,@ageNroControl,
@pevLugarPagoCodigo,
@ageImporte,
GETDATE(),
0,
@acumulado,
@ageJurisdiccion,
@agePrograma)
select @@IDENTITY 
GO
