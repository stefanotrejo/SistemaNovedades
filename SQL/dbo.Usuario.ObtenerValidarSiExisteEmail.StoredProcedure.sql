USE [LiquidacionSueldos]
GO
/****** Object:  StoredProcedure [dbo].[Usuario.ObtenerValidarSiExisteEmail]    Script Date: 27/10/2022 20:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Usuario.ObtenerValidarSiExisteEmail]
(
@Usuario varchar(50),
@Email varchar(50)
)
as

select * from Usuario where usuNombreIngreso = @Usuario and usuEmail = @Email and usuActivo = 1

GO
