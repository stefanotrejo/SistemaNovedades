USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[EmailSalida.Generar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EmailSalida.Generar]
(
@QueEnviar varchar(50),
@Mes int,
@Año int,
@usuId int
)
as

--[dbo].[EmailSalida.Generar] 'Boton de Pago - Cuota NO vencida',1,2017,1

/*
LAS FACTURAS DE CUOTAS VENCIDAS NO SE GENERA EL BOTON, DEBE BUSCARLO DESDE 
LA PLATAFORMA ALUMNO
*/

set dateformat dmy

declare @CuerpoBotonDePago varchar(max)

/*CUERPO DE BOTON DE PAGO*/
select @CuerpoBotonDePago = '[cAlumno],<br><br>le enviamos el botón de pago correspondiente a la cuota Nro [cCuotaNumero] de [cCantidadDeCuotas], [cCarreraTipo]: [cCarrera], Ciclo lectivo [cCicloLectivo], cuyo importe es $ [cImporte]<br><br>
Para pagar la cuota, por favor hacer clic sobre el botón siguiente y seguir los pasos.
<br><br>
Debe asegurarse que el "Sitio de compra" sea: CuentaDigital.com (Comercio #604414).
<br><br>
<a target=_blank href="https://www.cuentadigital.com/api.php?id=604414&codigo=[cNroReferencia]&precio=[cPrecio]&m0=&m1=&m2=&m3=&m4=&venc=10&concepto=[cConcepto]&moneda=ARS&site=">
<img src="https://www.cuentadigital.com/carro/add_cart.gif" border="0"></a>
<br><br>
Cualquier duda por favor comunicarse con Administracion 
al email: administracion@ides.org.ar o al teléfono: (0299)-4235566.
<br><br>Gracias.
Saludos cordiales,
<br><br>Administracion
IDES'

/*BOTON DE PAGO DE CUOTAS NO VENCIDAS*/
insert into EmailSalida
select 
getdate() as esaFecha,
ltrim(rtrim(alu.aluEmail)) as esaPara,
@QueEnviar as esaTipo,
'IDES | Cuota ' + convert(varchar(50),cuo.cuoNumero) + 
'. Periodo: ' + CONVERT(varchar(50),cuo.cuoMes) + '/' + convert(varchar(50),cuo.cuoAno)+ '. ' + car.carNombre as esaTitulo,
replace(replace(replace(replace(REPLACE(
replace(replace(replace(replace(replace(@CuerpoBotonDePago,'[cAlumno]',ISNULL(alu.aluNombre,'') + 
isnull(' ' + alu.aluApellido,'')),
'[cCuotaNumero]',CONVERT(varchar(50),cuo.cuoNumero)),'[cCantidadDeCuotas]',CONVERT(varchar(50),car.carCantidadCuotas)),
'[cCarreraTipo]',ctp.ctpNombre),'[cCarrera]',car.carNombre),'[cCicloLectivo]',cle.cleNombre),
'[cImporte]',replace(CONVERT(varchar(50),cuo.cuoSaldo),'.00','')),'[cNroReferencia]','cuoId=' + CONVERT(varchar(50),cuo.cuoId)),
'[cPrecio]',replace(CONVERT(varchar(50),cuo.cuoSaldo),'.00','')),'[cConcepto]','IDES | ' + ISNULL(alu.aluNombre,'') + 
isnull(' ' + alu.aluApellido,'') + ISNULL(' (' + alu.aluDocumentoNumero + ')','') + 
' | Pago de Cuota ' + CONVERT(varchar(50),cuo.cuoNumero) + ' de ' + CONVERT(varchar(50),car.carCantidadCuotas) + 
'. Periodo: ' + CONVERT(varchar(50),cuo.cuoMes) + '/' + convert(varchar(50),cuo.cuoAno) + ' | Carrera: ' + car.carNombre)
 as esaCuerpo,
 
@QueEnviar + ' | ' + ISNULL(alu.aluNombre,'') + 
isnull(' ' + alu.aluApellido,'') + ISNULL(' (' + alu.aluDocumentoNumero + ')','') + 
' | Pago de Cuota ' + CONVERT(varchar(50),cuo.cuoNumero) + 
' de ' + CONVERT(varchar(50),car.carCantidadCuotas) + '. Carrera: ' + car.carNombre as esaDescripcion,
cuo.cuoId,
1, @usuId, @usuId, GETDATE(), GETDATE()
from Cuota cuo, Alumno alu, AlumnoCarrera aca, Carrera car, CarreraTipo ctp, CicloLectivo cle
where 1 = 1
and cle.cleId = aca.cleId
and ctp.ctpId = car.ctpId
and aca.carId = car.carId
and aca.acaId = cuo.acaId
and alu.aluId = cuo.aluId
and len(ltrim(rtrim(isnull(alu.aluEmail,'')))) > 0
and cuo.cuoSaldo = cuo.cuoTotal
and cuo.cuoTotal > 0
and DATEADD(dd,-1,DATEADD(mm,1,dateadd(dd,-10,cuo.cuoFechaVence))) >= CONVERT(datetime,CONVERT(varchar(10),getdate(),103))
and cuo.cuoMes = @Mes
and cuo.cuoAno = @Año
and cuo.cuoEsInscripcion = 0
and cuo.cuoId not in 
(
select EmailSalida.cuoId 
from EmailSalida 
where EmailSalida.esaTipo = 'Boton de Pago - Cuota NO vencida'
)


GO
