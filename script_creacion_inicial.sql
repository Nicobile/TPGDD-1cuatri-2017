
use [GD1C2017]
go
/*Creacion del Schema*/
IF NOT EXISTS (SELECT * FROM SYS.schemas
				WHERE name = 'PUSH_IT_TO_THE_LIMIT'	)											
BEGIN
	EXEC('CREATE SCHEMA PUSH_IT_TO_THE_LIMIT AUTHORIZATION gd')

END
go
/*FIN DE LA CREACION DEL SCHEMA*/
/*si no lo encuentra en la tabla de catalogo sys.schema lo crea*/


/* Creacion de tablas*/

/* Funcionalidad*/
create table [PUSH_IT_TO_THE_LIMIT].Funcionalidad(
IdFun int identity (1,1) primary key,
Descripcion varchar(140) not null,
)


/*Rol*/
create table [PUSH_IT_TO_THE_LIMIT].Rol(
IdRol int identity(1,1) primary key,
Nombre varchar(50) not null,
Estado bit not null default 1,
)


/*RolporFunciones*/
create table [PUSH_IT_TO_THE_LIMIT].RolporFunciones(
[IdRol] INTEGER,
[IdFun] INTEGER,
 PRIMARY KEY (IdRol, IdFun)
)


/*Usuario FALTA CONTRASEÑA DEFAULT QUE ES W23A CREO QUE EN SHA256*/
create table [PUSH_IT_TO_THE_LIMIT].Usuario(
IdUsuario int identity(1,1) primary key,
Username varchar(50) unique not null,
U_Password varchar(50) not null,
Habilitado [bit] not null default 1,
Intentos [tinyint] default 0,
U_Admin [bit] not null DEFAULT 0,
)


/*RolporUsuario */
create table [PUSH_IT_TO_THE_LIMIT].RolporUsuario(
[IdUsuario] INTEGER,
[IdRol] INTEGER,
 PRIMARY KEY (IdUsuario, IdRol)
)


/*Cliente */
create table [PUSH_IT_TO_THE_LIMIT].Cliente(
IdCliente int identity(1,1) primary key,
Nombre varchar(50) not null,
Apellido varchar(50) not null,
Mail varchar(50),
Telefono numeric(18,0) unique not null,
Direccion varchar(255) not null,
Codigo_postal int not null,
Fecha_de_nacimiento datetime not null,
DNI numeric(18,0) unique not null,
IdUsuario int not null references [PUSH_IT_TO_THE_LIMIT].Usuario,
Estado bit not null default 1 , 
)


/*Facturacion cliente*/
create table [PUSH_IT_TO_THE_LIMIT].FacturacionCliente(
IdFactura int identity(1,1) primary key,
Fecha_inicio_de_factura datetime /*notnull*/,                        /*En la tabla maestra las fechas estan en null, por las dudas comento el not null*/
Fecha_fin_de_factura datetime /*notnull*/,
IdCliente int not null references [PUSH_IT_TO_THE_LIMIT].Cliente,
Importe_total_de_factura numeric(18,2) not null,
Viajes_facturados numeric(18,0) not null,   
       /*MUCHACHOS, CREO QUE ACA LA PIFIAMOS, QUE VIAJES FACTURADOS DEBERIA SER LA PK DE REGISTRO DE VIAJE, PORQUE ESTO CREO QUE VENDRIA A SER EL DETALLE*/
)





/* Creo tabla Chofer*/
CREATE TABLE [PUSH_IT_TO_THE_LIMIT].[Chofer] (
	[chofer_dni]  NUMERIC(18,0) PRIMARY KEY,
	[chofer_nombre] [VARCHAR](255) NOT NULL,
	[chofer_apellido] [VARCHAR](255) NOT NULL,
	[chofer_direccion] [VARCHAR](255),
	[chofer_telefono] NUMERIC(18,0),
	[chofer_mail] VARCHAR(50) ,
	[chofer_fechaDeNacimiento]	DATETIME ,
	--[chofer_idUsuario] seria una FK , depues hay que ponerla con el resto de las FK
	IdUsuario int unique not null references [PUSH_IT_TO_THE_LIMIT].Usuario,
)


/* Creo Tabla Turno*/
CREATE TABLE [PUSH_IT_TO_THE_LIMIT].[Turno](
	[turno_id] INT IDENTITY(1,1) PRIMARY KEY,
	[turno_hora_inicio]	NUMERIC(18,0) NOT NULL,
	[turno_hora_fin] NUMERIC(18,0) NOT NULL,
	[turno_descripcion] VARCHAR(255),
	[turno_valor_kilometro] NUMERIC(18,2),
	[turno_precio_base] NUMERIC(18,2) not null,
	[turno_habilitado] BIT not null DEFAULT 1,
)




/*Rendicion Viaje*/
CREATE TABLE [PUSH_IT_TO_THE_LIMIT].[RendicionViaje](
	[rendicion_id] INT IDENTITY(1,1) PRIMARY KEY,
	[rendicion_fecha] DATETIME NOT NULL,
	[chofer_dni] numeric(18,0) NOT NULL REFERENCES [PUSH_IT_TO_THE_LIMIT].[Chofer],					
	[turno_id] int NOT NULL REFERENCES [PUSH_IT_TO_THE_LIMIT].[Turno],					
	[rendicion_importe_total] NUMERIC(18,2) NOT NULL,    
)

/*Auto*/
CREATE TABLE [PUSH_IT_TO_THE_LIMIT].[Auto](
	[auto_patente] VARCHAR(8) PRIMARY KEY,
	[auto_marca] VARCHAR(255) NOT NULL,
	[auto_modelo] VARCHAR(255) NOT NULL,
	[chofer_dni] numeric(18,0) NOT NULL REFERENCES [PUSH_IT_TO_THE_LIMIT].[Chofer],					
	[turno_id] INT NOT NULL REFERENCES [PUSH_IT_TO_THE_LIMIT].[Turno],					
	[auto_estado] BIT not null DEFAULT 1,
	[auto_licencia] VARCHAR(26),
	[auto_rodado] VARCHAR(10),
)

/*Auto por Turno*/
CREATE TABLE [PUSH_IT_TO_THE_LIMIT].[AutoporTurno](
[auto_patente] VARCHAR(8),
[turno_id] INTEGER,
 PRIMARY KEY (auto_patente, turno_id)
)
/*Registro de viaje*/
create table [PUSH_IT_TO_THE_LIMIT].RegistroViaje(
IdViaje int identity(1,1) primary key,
IdChofer NUMERIC(18,0) not null references [PUSH_IT_TO_THE_LIMIT].Chofer,                        
Automovil VARCHAR(8) not null references[PUSH_IT_TO_THE_LIMIT].[Auto],                                              
IdFactura int not null references [PUSH_IT_TO_THE_LIMIT].FacturacionCliente,
IdTurno int not null references [PUSH_IT_TO_THE_LIMIT].Turno,                            
Cantidad_de_km_viaje numeric(18,0) not null, 
Fecha_hora_inicio_de_viaje datetime not null,
Fecha_hora_fin_de_viaje datetime not null,              /*ACA PODRIAMOS SEPARAR LA FECHA DE LA HORA (SOLO SUGERENCIA)*/
IdCliente int not null references [PUSH_IT_TO_THE_LIMIT].Cliente,
)