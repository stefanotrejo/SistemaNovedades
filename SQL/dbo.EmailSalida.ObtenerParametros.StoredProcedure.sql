USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[EmailSalida.ObtenerParametros]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[EmailSalida.ObtenerParametros]
as

declare @ServidorEmail_De varchar(max)
declare @ServidorEmail_Clave varchar(max)
declare @ServidorEmail_Servidor varchar(max)
declare @ServidorEmail_Puerto varchar(max)
declare @ServidorEmail_EnableSSL varchar(max)

select @ServidorEmail_De = parValor from Parametro where parNombre = 'ServidorEmail_De'
select @ServidorEmail_Clave = parValor from Parametro where parNombre = 'ServidorEmail_Clave'
select @ServidorEmail_Servidor = parValor from Parametro where parNombre = 'ServidorEmail_Servidor'
select @ServidorEmail_Puerto = parValor from Parametro where parNombre = 'ServidorEmail_Puerto'
select @ServidorEmail_EnableSSL = parValor from Parametro where parNombre = 'ServidorEmail_EnableSSL'

select
@ServidorEmail_De as ServidorEmail_De, 
@ServidorEmail_Clave as ServidorEmail_Clave, 
@ServidorEmail_Servidor as ServidorEmail_Servidor,
@ServidorEmail_Puerto as ServidorEmail_Puerto, 
@ServidorEmail_EnableSSL as ServidorEmail_EnableSSL
GO
