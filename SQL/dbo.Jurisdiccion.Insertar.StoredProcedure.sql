USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Jurisdiccion.Insertar]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Jurisdiccion.Insertar] 
@jurCodigo int,
@jurNombre varchar,
@ftiId int,
@jurActivo int,
@usuIdCreacion int,
@jurFechaHoraCreacion int
AS
BEGIN
insert into Jurisdiccion
(jurCodigo,
jurNombre,
ftiId,
jurActivo,
usuIdCreacion,
jurFechaHoraCreacion) 
values 
(@jurCodigo,
@jurNombre,
@ftiId,
@jurActivo,
@usuIdCreacion,
@jurFechaHoraCreacion) 

select @@IDENTITY 
END




GO
