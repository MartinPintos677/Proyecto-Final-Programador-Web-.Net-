use ProyectoFinal
go

-- LOGUEO Y CONTRASEÑA --
create proc sp_logueousuario @logueo varchar(20), @contrasena varchar(15) 
AS
	select * from Usuario where LogueoUsuario = @logueo and Contrasena = @contrasena		
go

-- ABM PAÍSES --

-- BUSCAR PAÍS
create proc sp_BuscarPais @CodigoPais char(3)
AS
	 select * from Pais where CodigoPais = @CodigoPais
go

-- TODOS LOS PAISES
create proc sp_TodoslosPaises
AS
	select * from Pais
go

-- EDITAR PAÍS
create proc sp_EditarPais @codPais char(3), @nomPais varchar(100)
AS
	if not exists (select * from Pais where CodigoPais = @codPais)
	    return -1
	
		update Pais set NombrePais = @nomPais	
		where CodigoPais = @codPais		
	
	if @@ERROR<>0
		return -2
	else
		return 1
go

-- REGISTRAR PAÍS
create proc sp_RegistrarPais @CodigoPais char(3), @Nombre varchar(100)
AS
	if exists (select * from Pais where CodigoPais = @CodigoPais)
	   return -1

	if exists (select * from Pais where NombrePais = @Nombre)
	   return -2

	insert into Pais(CodigoPais, NombrePais)
	   values(@CodigoPais, @Nombre)

	if @@ERROR <> 0
	  return -3
	else
	  return 1
go

-- ELIMINAR PAÍS
create proc sp_EliminarPais @CodigoPais char(3)
AS			
	if not exists(select * from Pais where CodigoPais = @CodigoPais)
		return -1

	if exists(select * from Pronostico where CodigoPais = @CodigoPais)
		return -2

	begin tran
		begin try				
			begin
			DELETE from Ciudad where CodigoPais = @CodigoPais
			DELETE from Pais where CodigoPais = @CodigoPais			
			end						
	commit tran
	    return 1
		end try

	begin catch
		rollback tran
		return -3
	end catch
go

-- ABM DE CIUDADES --

-- BUSCAR CIUDAD
create proc sp_BuscarCiudad @CodigoPais char(3), @CodigoCiudad char(3) 
AS
	 select * from Ciudad where CodigoPais = @CodigoPais and CodigoCiudad = @CodigoCiudad
go

-- TODAS LAS CIUDADES
create proc sp_ListadodeCiudades
AS
	select * from Ciudad
go

-- EDITAR CIUDAD
create proc sp_EditarCiudad @codPais char(3), @codCiudad char(3), @nomCiudad varchar(100)
AS
	if not exists (select * from Ciudad where CodigoPais = @codPais and CodigoCiudad = @codCiudad)
	   return -1
	
		update Ciudad set NombreCiudad = @nomCiudad	
		where CodigoPais = @codPais and CodigoCiudad = @codCiudad
		
		if @@ERROR<>0
		return -2
	else
		return 1
go	

-- REGISTRAR CIUDAD
create proc sp_RegistrarCiudad @CodigoPais char(3), @CodigoCiudad char(3), @Nombre varchar(100)
AS
	if exists (select * from Ciudad where CodigoPais = @CodigoPais and CodigoCiudad = @CodigoCiudad)
	   return -1

	if not exists (select * from Pais where CodigoPais = @CodigoPais)
		return -2

	insert into Ciudad(CodigoPais, CodigoCiudad, NombreCiudad)
	   values(@CodigoPais, @CodigoCiudad, @Nombre)

	if @@ERROR <> 0
	   return -3
	else
	   return 1
go

-- ELIMINAR CIUDAD
create proc sp_EliminarCiudad @CodigoPais char(3), @CodigoCiudad char(3)
AS			
	if not exists(select * from Ciudad where CodigoPais = CodigoPais and CodigoCiudad = @CodigoCiudad)
		return -1

	begin tran
		begin try			
			
			DELETE from Pronostico where CodigoPais = @CodigoPais and CodigoCiudad = @CodigoCiudad
			DELETE from Ciudad where CodigoPais = @CodigoPais and CodigoCiudad = @CodigoCiudad					
						
	commit tran
	    return 1
		end try

	begin catch
		rollback tran
		return -2
	end catch
go

-- ABM DE USUARIOS --

-- BUSCAR USUARIO
create proc sp_BuscarUsuario @logueoUsuario varchar(20)
AS
	select * from Usuario where LogueoUsuario = @logueoUsuario
go

-- EDITAR USUARIO
create proc sp_EditarUsuario @loginUsuario varchar(20), @contrasena varchar(15), 
							 @nombre varchar(50), @apellido varchar(50)
AS
	if not exists (select * from Usuario where LogueoUsuario = @loginUsuario)
	   return -1
	
		update Usuario set Contrasena = @contrasena, Nombre = @nombre,
		Apellido = @apellido
		where LogueoUsuario = @loginUsuario
		
		if @@ERROR<>0
		return -2
	else
		return 1
go

-- REGISTRAR USUARIO
create proc sp_RegistrarUsuario @loginUsuario varchar(20), @contrasena varchar(15), 
							 @nombre varchar(50), @apellido varchar(50)
AS
	if exists (select * from Usuario where LogueoUsuario = @loginUsuario)
	   return -1

	insert into Usuario(LogueoUsuario, Contrasena, Nombre, Apellido)
	   values(@loginUsuario, @contrasena, @nombre, @apellido)

	if @@ERROR <> 0
	  return -2
	else
	  return 1
go

-- ELIMINAR USUARIO
create proc sp_EliminarUsuario @loginUsuario varchar(20)
AS	
	if exists (select * from Pronostico where CodigoUsuario = @loginUsuario)
	   return -1

	if not exists(select * from Usuario where LogueoUsuario = @loginUsuario)
		return -2

	delete Usuario where LogueoUsuario = @loginUsuario
	
	if @@ERROR <> 0
	  return -3
	else
	  return 1   
go

-- BTN ELIMINAR
create proc sp_EliminarUsuariobtn @loginUsuario varchar(20)
AS
	if exists(select * from Pronostico where CodigoUsuario = @loginUsuario)
		return 1
	else
		return -1
go

-- REGISTRAR PRONOSTICO
create proc sp_RegistrarPronostico @PLluvia int, @PTormenta int, @TMinima int, @TMaxima int,
								   @fechaHora datetime, @VelViento int, @TipoCielo varchar(20),
								   @CodigoUsuario varchar(20), @CodigoPais char(3), @CodigoCiudad char(3)
AS
	IF NOT EXISTS(SELECT * FROM Usuario WHERE LogueoUsuario = @CodigoUsuario)
		return -1

	IF NOT EXISTS(SELECT * FROM Ciudad WHERE CodigoPais = @CodigoPais and CodigoCiudad = @CodigoCiudad)
		return -2	
	
			DECLARE @idPronostico INT

			INSERT INTO Pronostico(Plluvia, Ptormenta, TMinima, TMaxima, FechaHora, VelocidadViento,
								   TipoCielo, CodigoUsuario, CodigoPais, CodigoCiudad)

			VALUES (@PLluvia, @PTormenta, @TMinima, @TMaxima, @fechaHora, @VelViento, @TipoCielo,
					@CodigoUsuario, @CodigoPais, @CodigoCiudad)

	if @@ERROR <> 0
			return -3
	else	
	begin	
			SET @idPronostico = @@IDENTITY
			return @idPronostico			
	end
go

-- LISTADO CIUDADES DE PAIS
create proc sp_CiudadesdePais @CodigoPais char(3)
AS
	select * from Ciudad where CodigoPais = @CodigoPais
go

-- LISTADO PRONOSTICOS FECHA INGRESADA Y PARA DEFAULT
create proc sp_pronosticoFechaIngresada @fecha datetime 
AS
	select * from Pronostico where convert(date, FechaHora) = convert (date, @fecha)
go

-- PRONOSTICOS POR CADA CIUDAD	
create proc sp_PronosticosCiudad @CodigoPais char(3), @CodigoCiudad char(3)
AS	
	select *
	from Pronostico	
	where Pronostico.CodigoPais = @CodigoPais and Pronostico.CodigoCiudad = @CodigoCiudad
	order by Pronostico.FechaHora asc
go

-- 20 SP