USE [Transporte]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 10/18/2022 1:20:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[IdEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[Origen] [nvarchar](50) NULL,
	[TiempoTranscurrido] [int] NULL,
	[NombrePasajero] [nvarchar](150) NULL,
	[PlacaVehiculo] [nvarchar](50) NULL,
	[HoraViaje] [nvarchar](50) NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[spEmpleadoAll]    Script Date: 10/18/2022 1:20:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spEmpleadoAll] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
     SELECT 
		IdEmpleado, 
		Origen, 
		TiempoTranscurrido,
		NombrePasajero,
		PlacaVehiculo,
		HoraViaje 
	 from Empleado

   
END
GO
/****** Object:  StoredProcedure [dbo].[spEmpleadoAllId]    Script Date: 10/18/2022 1:20:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nelson Chan
-- Create date: 17/10/2022
-- Description:	consultar la Empleado Id
-- =============================================
CREATE PROCEDURE  [dbo].[spEmpleadoAllId]
       -- Parametros
		@PrmEmpleadoId int
 
	
AS
BEGIn
	 select 
		 IdEmpleado,
		 Origen,
		 TiempoTranscurrido,
		 NombrePasajero,
		 PlacaVehiculo,
		 HoraViaje
	 from Empleado
	 Where IdEmpleado = @PrmEmpleadoId

   
END
GO
/****** Object:  StoredProcedure [dbo].[spEmpleadoDelete]    Script Date: 10/18/2022 1:20:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spEmpleadoDelete]
	   -- Parametros
	@IdEmpleado int
	
AS
BEGIN
delete from Empleado where IdEmpleado = @IdEmpleado

END

GO
/****** Object:  StoredProcedure [dbo].[spEmpleadoInsert]    Script Date: 10/18/2022 1:20:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nelson Chan
-- Create date: 17/10/2021
-- Description:	Registro de Usuario
-- =============================================
CREATE PROCEDURE [dbo].[spEmpleadoInsert]
	-- Add the parameters for the stored procedure here
	--Parametros
    @Origen varchar(70),
	@TiempoTranscurrido int,
	@NombrePasajero varchar(70),	
	@PlacaVehiculo varchar(70),
	@HoraViaje varchar(70)

AS
BEGIN
	Insert into Empleado 
		(Origen,
		TiempoTranscurrido,
		NombrePasajero,
		PlacaVehiculo,
		HoraViaje) 
	values 
		(@Origen,
		 @TiempoTranscurrido,
		 @NombrePasajero,
		 @PlacaVehiculo,
		 @HoraViaje)

END
GO
/****** Object:  StoredProcedure [dbo].[spEmpleadoUpdate]    Script Date: 10/18/2022 1:20:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nelson Chan
-- Create date: 17/10/2022
-- Description:	actualizacion de CompanyId
-- =============================================
CREATE PROCEDURE [dbo].[spEmpleadoUpdate]
	-- Parametros
	@IdEmpleado int,  
	@Origen varchar(70),
	@TiempoTranscurrido int,
	@NombrePasajero varchar(70),
	@PlacaVehiculo varchar(70),
	@HoraViaje varchar(70)
	
AS
BEGIN
	update Empleado set 
	Origen = @Origen,
	TiempoTranscurrido = @TiempoTranscurrido,
	NombrePasajero = @NombrePasajero,
	PlacaVehiculo = @PlacaVehiculo,
	HoraViaje = @HoraViaje
	where IdEmpleado = @IdEmpleado

END
GO
