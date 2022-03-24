use ProyectoFinal
go

insert into Usuario (LogueoUsuario, Contrasena, Nombre, Apellido)
values
	('Santi', '123456', 'Santiago', 'García'),
	('Cami', 'Cami123', 'Camila', 'Pérez'),
	('Jime', 'Jimena456', 'Jimena', 'Campo'),
	('Jorjito', 'Jorge333', 'Jorge', 'Fernández'),
	('Josecito', 'Jose666', 'Jose', 'López'),
	('Fer', 'FerTiempo', 'Fernanda', 'Ojeda'),
	('Marta', 'MartaTiempo', 'Marta', 'Gómez'),
	('Mari', 'MarianaPass', 'Mariana', 'González')
go

insert into Pais (CodigoPais, NombrePais)
values
	('BRA', 'Brasil'),
	('URU', 'Uruguay'),
	('ARG', 'Argentina'),
	('POR', 'Portugal')
go

insert into Ciudad (CodigoPais, CodigoCiudad, NombreCiudad)
values
	('BRA', 'SAL', 'Salvador'),
	('BRA', 'RIO', 'Rio de Janeiro'),
	('BRA', 'POA', 'Porto Alegre'),
	('URU', 'RIV', 'Rivera'),
	('ARG', 'MEN', 'Mendoza'),
	('POR', 'LIS', 'Lisboa')
go

DECLARE @idPronostico INT

insert into Pronostico (Plluvia, Ptormenta, TMaxima, TMinima, FechaHora, VelocidadViento,
						TipoCielo, CodigoUsuario, CodigoPais, CodigoCiudad)
values
	(5, 0, 30, 20, '2021-12-31 17:30:00', 11, 'Nuboso', 'Jime', 'BRA', 'SAL')
	SELECT @idPronostico = @@IDENTITY

insert into Pronostico (Plluvia, Ptormenta, TMaxima, TMinima, FechaHora, VelocidadViento,
						TipoCielo, CodigoUsuario, CodigoPais, CodigoCiudad)
values
	(5, 0, 35, 25, '2022-01-20 13:00:00', 16, 'Despejado', 'Jime', 'BRA', 'SAL')
	SELECT @idPronostico = @@IDENTITY

insert into Pronostico (Plluvia, Ptormenta, TMaxima, TMinima, FechaHora, VelocidadViento,
						TipoCielo, CodigoUsuario, CodigoPais, CodigoCiudad)
values
	(30, 10, 40, 28, '2022-01-20 12:00:00', 22, 'Parcialmente Nuboso', 'Cami', 'BRA', 'RIO')
	SELECT @idPronostico = @@IDENTITY

insert into Pronostico (Plluvia, Ptormenta, TMaxima, TMinima, FechaHora, VelocidadViento,
						TipoCielo, CodigoUsuario, CodigoPais, CodigoCiudad)
values
	(40, 8, 33, 20, '2022-02-11 10:30:00', 25, 'Nuboso', 'Santi', 'URU', 'RIV')
	SELECT @idPronostico = @@IDENTITY
	
insert into Pronostico (Plluvia, Ptormenta, TMaxima, TMinima, FechaHora, VelocidadViento,
						TipoCielo, CodigoUsuario, CodigoPais, CodigoCiudad)
values
	(75, 30, 31, 23, '2022-02-05 14:00:00', 35, 'Nuboso', 'Jorjito', 'ARG', 'MEN')
	SELECT @idPronostico = @@IDENTITY

insert into Pronostico (Plluvia, Ptormenta, TMaxima, TMinima, FechaHora, VelocidadViento,
						TipoCielo, CodigoUsuario, CodigoPais, CodigoCiudad)
values
	(20, 0, 25, 15, '2022-03-10 17:30:00', 20, 'Despejado', 'Jorjito', 'POR', 'LIS')
	SELECT @idPronostico = @@IDENTITY

insert into Pronostico (Plluvia, Ptormenta, TMaxima, TMinima, FechaHora, VelocidadViento,
						TipoCielo, CodigoUsuario, CodigoPais, CodigoCiudad)
values
	(60, 10, 40, 30, '2022-04-05 12:00:00', 20, 'Parcialmente Nuboso', 'Marta', 'BRA', 'SAL')
	SELECT @idPronostico = @@IDENTITY

insert into Pronostico (Plluvia, Ptormenta, TMaxima, TMinima, FechaHora, VelocidadViento,
						TipoCielo, CodigoUsuario, CodigoPais, CodigoCiudad)
values
	(20, 0, 38, 25, '2022-03-16 15:30:00', 16, 'Despejado', 'Jorjito', 'BRA', 'RIO')
	SELECT @idPronostico = @@IDENTITY

insert into Pronostico (Plluvia, Ptormenta, TMaxima, TMinima, FechaHora, VelocidadViento,
						TipoCielo, CodigoUsuario, CodigoPais, CodigoCiudad)
values
	(50, 10, 30, 20, '2022-03-16 09:00:00', 11, 'Parcialmente Nuboso', 'Fer', 'URU', 'RIV')
	SELECT @idPronostico = @@IDENTITY	
go