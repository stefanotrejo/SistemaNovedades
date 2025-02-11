USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[EmailSalida.ObtenerValidarParametro]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EmailSalida.ObtenerValidarParametro]
as

set dateformat dmy

/*ACTUALIZAR PARAMETROS*/
declare @Retorno int, @RetornoTexto varchar(max)
select @Retorno = 0, @RetornoTexto = ''

/*RETORNO = 1 SIGNIFICA QUE ESTA TODO OK*/

declare @EmailSalida_Fecha datetime
declare @EmailSalida_Cantidad int
declare @EmailSalida_CantidadMaximaDiaria int
declare @FechaHoy datetime

select @EmailSalida_Fecha = CONVERT(datetime,parValor) from Parametro where parNombre = 'EmailSalida_Fecha'
select @EmailSalida_Cantidad = CONVERT(int,parValor) from Parametro where parNombre = 'EmailSalida_Cantidad'
select @EmailSalida_CantidadMaximaDiaria = CONVERT(int,parValor) from Parametro where parNombre = 'EmailSalida_CantidadMaximaDiaria'
select @FechaHoy = CONVERT(datetime,CONVERT(varchar(10),GETDATE(),103))

if @EmailSalida_Fecha = @FechaHoy
	begin
	if @EmailSalida_Cantidad < @EmailSalida_CantidadMaximaDiaria
		begin
		select @Retorno = 1
		select @RetornoTexto = 'Cantidad de emails enviados el dia ' + convert(varchar(10),@EmailSalida_Fecha,103) + ': ' + convert(varchar(50),@EmailSalida_Cantidad) + ' de ' + convert(varchar(50),@EmailSalida_CantidadMaximaDiaria) + ' disponible diario'
		end
	else
		begin
		select @Retorno = 0
		select @RetornoTexto = 'En el dia de HOY (' + convert(varchar(10),@EmailSalida_Fecha,103) + ') NO pueden enviarse mas emails. Cantidad maxima disponible diaria: ' + convert(varchar(50),@EmailSalida_CantidadMaximaDiaria)
	end
end

if @EmailSalida_Fecha <> @FechaHoy
	begin
	update Parametro set parValor = CONVERT(varchar(10),getdate(),103) where parNombre = 'EmailSalida_Fecha'
	update Parametro set parValor = '0' where parNombre = 'EmailSalida_Cantidad'
	
	select @Retorno = 1
	select @RetornoTexto = 'Cantidad de emails enviados el dia ' + convert(varchar(50),@EmailSalida_Fecha,103) + ': ' + convert(varchar(50),@EmailSalida_Cantidad) + ' de ' + convert(varchar(50),@EmailSalida_CantidadMaximaDiaria) + ' disponible diario'	
end

select @Retorno as PermiteEnviarEmail, @RetornoTexto as Cadena


GO
