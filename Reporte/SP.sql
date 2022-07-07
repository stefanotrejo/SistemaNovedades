USE [GESTIONESCOLAR]
GO
/****** Object:  StoredProcedure [dbo].[InformeInscripcionCursado]    Script Date: 12/09/2018 10:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[InformeInscripcionCursado]
(
@carId int,
@plaId int,
@curId int,
@camId int,
@escId int,
@anio int
)

as

select InscripcionCursado.icuAnoCursado, 
EspacioCurricular.escNombre, Carrera.carNombre, PlanEstudio.plaNombre, Curso.curNombre, Campo.camNombre, Alumno.aluNombre,
Alumno.aluDoc
from InscripcionCursado as InscripcionCursado 
join Carrera on Carrera.carId = InscripcionCursado.carId
join PlanEstudio on PlanEstudio.carId = InscripcionCursado.carId and PlanEstudio.plaId = InscripcionCursado.plaId
join Curso on Curso.plaId = InscripcionCursado.plaId and Curso.curId = InscripcionCursado.curId
join Campo on Campo.plaId = InscripcionCursado.plaId and Campo.curId =InscripcionCursado.curId and CAmpo.camId = InscripcionCursado.camId  
join EspacioCurricular on EspacioCurricular.escId = InscripcionCursado.escId
join Alumno on Alumno.aluId = InscripcionCursado.aluId

where 1 = 1 
and (InscripcionCursado.carId = @carId or @carId = 0) 
and (InscripcionCursado.plaId = @plaId or @plaId = 0)
and (InscripcionCursado.curId = @curId or @curId = 0)
and (InscripcionCursado.camId = @camId or @camId = 0)
and (InscripcionCursado.escId = @escId or @escId = 0)
and (InscripcionCursado.icuAnoCursado = @anio or @anio = 0)
and Alumno.aluActivo = 1


--exec InformeInscripcionCursado 1,1,1,0,0,0


-- select * from InscripcionCursado

