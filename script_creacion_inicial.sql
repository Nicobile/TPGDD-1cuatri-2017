
use [GD1C2017]
go
											
create schema [GDD] authorization [gd]
go



/* Creacion de tablas*/

/* Funcionalidad*/
create table [GDD].Funcionalidad(
IdFun int identity (1,1) primary key,
Descripcion varchar(140) not null,
)
go

/*Rol*/
create table [GDD].Rol(
IdRol int identity(1,1) primary key,
Nombre varchar(50) not null,
)
go

/*RolporFunciones*/
create table [GDD].RolporFunciones(
[IdRol] INTEGER,
[IdFun] INTEGER,
 PRIMARY KEY (IdRol, IdFun)
)
go

/*Usuario FALTA CONTRASEÑA DEFAULT QUE ES W23A CREO QUE EN SHA256*/
create table [GDD].Usuario(
IdUsuario int identity(1,1) primary key,
Username varchar(50) unique not null,
U_Password varchar(50) not null,
Habilitado [bit] not null default 1,
Intentos [tinyint] default 0,
U_Admin [bit] not null DEFAULT 0,
)
go

/*RolporUsuario */
create table [GDD].RolporUsuario(
[IdUsuario] INTEGER,
[IdRol] INTEGER,
 PRIMARY KEY (IdUsuario, IdRol)
)
go
