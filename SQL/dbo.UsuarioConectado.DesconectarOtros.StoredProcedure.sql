USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[UsuarioConectado.DesconectarOtros]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UsuarioConectado.DesconectarOtros]
(
@usuId int,
@ucoGuid varchar(max),
@ucoIpPublica varchar(50)
)
as

set dateformat dmy

update UsuarioConectado set ucoDesconectar = 1 where usuId = @usuId and ucoGuid <> @ucoGuid

GO
