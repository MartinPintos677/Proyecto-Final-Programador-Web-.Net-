CREATE DATABASE ProyectoFinal
go
USE ProyectoFinal
go

CREATE TABLE Usuario
(
	LogueoUsuario varchar(20) primary key,
	Contrasena varchar(15) not null,
	Nombre varchar(50) not null,
	Apellido varchar(50) not null
)

CREATE TABLE Pais
(
	CodigoPais char(3) check(len(CodigoPais) = 3) Primary Key,
	NombrePais varchar(100) not null
)

CREATE TABLE Ciudad
(
	CodigoPais char(3) not null foreign key references Pais(CodigoPais),
	CodigoCiudad char(3) not null check(len(CodigoCiudad) = 3),
	NombreCiudad varchar(100) not null,
	Primary Key(CodigoPais, CodigoCiudad)
)

CREATE TABLE Pronostico
(
	Codigo int identity (1,1) primary key,
	Plluvia int not null check (Plluvia >= 0 and Plluvia <= 100),
	Ptormenta int not null check (Ptormenta >= 0 and Ptormenta <= 100),
	TMinima int not null,
	TMaxima int not null,
	FechaHora datetime unique not null,
	VelocidadViento int not null check (VelocidadViento >= 0),
	TipoCielo varchar(20) not null check (TipoCielo = 'despejado' or 
										  TipoCielo = 'parcialmente nuboso' or 
										  TipoCielo = 'nuboso'),
	CodigoUsuario varchar(20) not null foreign key references Usuario(LogueoUsuario),
	CodigoPais char(3) not null,
	CodigoCiudad char(3) not null,
	foreign key (CodigoPais, CodigoCiudad) references Ciudad(CodigoPais, CodigoCiudad)
)	