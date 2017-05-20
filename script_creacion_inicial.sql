
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

/*Cliente */
create table [GDD].Cliente(
IdCliente int identity(1,1) primary key,
Nombre varchar(50) not null,
Apellido varchar(50) not null,
Mail varchar(50),
Telefono numeric(18,0) unique not null,
Direccion varchar(255) not null,
Codigo_postal int not null,
Fecha_de_nacimiento datetime not null,
DNI numeric(18,0) unique not null,
IdUsuario int not null references [GDD].Usuario,
)
go

/*Facturacion cliente*/
create table [GDD].FacturacionCliente(
IdFactura int identity(1,1) primary key,
Fecha_inicio_de_factura datetime /*notnull*/,                        /*En la tabla maestra las fechas estan en null, por las dudas comento el not null*/
Fecha_fin_de_factura datetime /*notnull*/,
IdCliente int not null references [GDD].Cliente,
Importe_total_de_factura numeric(18,2) not null,
Viajes_facturados numeric(18,0) not null,               /*MUCHACHOS, CREO QUE ACA LA PIFIAMOS, QUE VIAJES FACTURADOS DEBERIA SER LA PK DE REGISTRO DE VIAJE, PORQUE ESTO CREO QUE VENDRIA A SER EL DETALLE*/
)
go

/*Registro de viaje*/
create table [GDD].RegistroViaje(
IdViaje int identity(1,1) primary key,
/*IdChofer int not null references [GDD].Chofer,*/                          /*Descomentar una vez creada la tabla chofer*/
Automovil int not null,                                                     /*No estoy seguro*/
IdFactura int not null references [GDD].FacturacionCliente,
/*IdTurno int not null references [GDD].Turno,*/                            /*Descomentar una vez creada la tabla turno*/
Cantidad_de_km_viaje numeric(18,0) not null, 
Fecha_hora_inicio_de_viaje datetime not null,
Fecha_hora_fin_de_viaje datetime not null,              /*ACA PODRIAMOS SEPARAR LA FECHA DE LA HORA (SOLO SUGERENCIA)*/
IdCliente int not null references [GDD].Cliente,
)
go