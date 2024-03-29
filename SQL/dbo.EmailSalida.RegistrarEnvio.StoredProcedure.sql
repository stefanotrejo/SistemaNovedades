USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[EmailSalida.RegistrarEnvio]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EmailSalida.RegistrarEnvio]
(
@esaId int
)

as

set dateformat dmy

begin tran

delete from EmailSalida where esaId = @esaId

update Parametro set parValor = CONVERT(varchar(50),CONVERT(int,parValor) + 1) where parNombre = 'EmailSalida_Cantidad'

commit tran

GO
