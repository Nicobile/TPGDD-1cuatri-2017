
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
CREATE TABLE [PUSH_IT_TO_THE_LIMIT].Funcionalidad(
	[funcionalidad_id] INT IDENTITY (1,1) PRIMARY KEY,
	[funcionalidad_descripcion] VARCHAR(100) NOT NULL,
)
			

/*Rol*/
CREATE TABLE [PUSH_IT_TO_THE_LIMIT].Rol(
	[rol_id] INT IDENTITY(1,1) PRIMARY KEY,
	[rol_nombre] VARCHAR(100) NOT NULL,
	[rol_estado] BIT NOT NULL DEFAULT 1,
)


/*RolporFunciones*/
CREATE TABLE [PUSH_IT_TO_THE_LIMIT].RolporFunciones(
	[rol_id] INTEGER,
	[funcionalidad_id] INTEGER,
	PRIMARY KEY (rol_id, funcionalidad_id)
)


/*Usuario FALTA CONTRASEÑA DEFAULT QUE ES W23A CREO QUE EN SHA256*/
CREATE TABLE [PUSH_IT_TO_THE_LIMIT].Usuario(
	[usuario_id] INT IDENTITY(1,1) PRIMARY KEY,
	[usuario_name] VARCHAR(50) UNIQUE NOT NULL,
	[usuario_password] VARCHAR(50) NOT NULL,
	[usuario_habilitado] [BIT] NOT NULL DEFAULT 1,
	[usuario_intentos] [TINYINT] DEFAULT 0,
	[usuario_admin] [BIT] NOT NULL DEFAULT 0,
)


/*RolporUsuario */
CREATE TABLE [PUSH_IT_TO_THE_LIMIT].RolporUsuario(
	[usuario_id] INTEGER,
	[rol_id] INTEGER,
	PRIMARY KEY (usuario_id, rol_id)
)


/*Cliente */
CREATE TABLE [PUSH_IT_TO_THE_LIMIT].Cliente(
	[cliente_id] INT IDENTITY(1,1) PRIMARY KEY,
	[cliente_nombre] VARCHAR(255) NOT NULL,
	[cliente_apellido] VARCHAR(255) NOT NULL,
	[cliente_mail] VARCHAR(255),
	[cliente_telefono] NUMERIC(18,0) UNIQUE NOT NULL,
	[cliente_direccion] VARCHAR(255) NOT NULL,
	[cliente_codigo_postal] INT ,
	[cliente_fecha_nacimiento] DATETIME NOT NULL,
	[cliente_dni] NUMERIC(18,0) UNIQUE NOT NULL,
	[usuario_id] INT NOT NULL ,/*references [PUSH_IT_TO_THE_LIMIT].Usuario,*/
	[cliente_estado] BIT NOT NULL DEFAULT 1 , 
)


/*Facturacion cliente*/ /*SACAMOS TODOS LOS NOT NULL POR QUE EN LA TABLA MAESTRA HAY FECHAS EN NULL*/
CREATE TABLE [PUSH_IT_TO_THE_LIMIT].Factura(
	[factura_id] INT IDENTITY(1,1) PRIMARY KEY,
	[factura_fecha_inicio] DATETIME , /*En la tabla maestra las fechas estan en null, por las dudas comento el not null*/
	[factura_fecha_fin] DATETIME ,
	[cliente_id] INT NOT NULL REFERENCES [PUSH_IT_TO_THE_LIMIT].Cliente,
	[factura_importe_total] NUMERIC(18,2) ,
	)





/* Creo tabla Chofer*/
CREATE TABLE [PUSH_IT_TO_THE_LIMIT].[Chofer] (
	[chofer_dni]  NUMERIC(18,0) PRIMARY KEY,
	[chofer_nombre] [VARCHAR](255) NOT NULL,
	[chofer_apellido] [VARCHAR](255) NOT NULL,
	[chofer_direccion] [VARCHAR](255),
	[chofer_telefono] NUMERIC(18,0) UNIQUE,
	[chofer_mail] VARCHAR(50) ,
	[chofer_fecha_Nacimiento] DATETIME NOT NULL,
	[usuario_id] INT,-- seria una FK , depues hay que ponerla con el resto de las FK
	--IdUsuario int unique not null references [PUSH_IT_TO_THE_LIMIT].Usuario, Hay que hacerlo con las otras fks
)


/* Creo Tabla Turno*/
CREATE TABLE [PUSH_IT_TO_THE_LIMIT].[Turno](
	[turno_id] INT IDENTITY(1,1) PRIMARY KEY,
	[turno_hora_inicio]	NUMERIC(18,0) NOT NULL,
	[turno_hora_fin] NUMERIC(18,0) NOT NULL,
	[turno_descripcion] VARCHAR(255),
	[turno_valor_kilometro] NUMERIC(18,2) NOT NULL,
	[turno_precio_base] NUMERIC(18,2) NOT NULL,
	[turno_habilitado] BIT NOT NULL DEFAULT 1,
)




/*Rendicion Viaje*/
CREATE TABLE [PUSH_IT_TO_THE_LIMIT].[RendicionViaje](
	[rendicion_id] INT IDENTITY(1,1) PRIMARY KEY,
	[rendicion_fecha] DATETIME NOT NULL,
	[chofer_dni] numeric(18,0) NOT NULL ,--REFERENCES [PUSH_IT_TO_THE_LIMIT].[Chofer],					
	[turno_id] int NOT NULL ,--REFERENCES [PUSH_IT_TO_THE_LIMIT].[Turno],					
	[rendicion_importe_total] NUMERIC(18,2) NOT NULL,    
)

/*Auto*/
CREATE TABLE [PUSH_IT_TO_THE_LIMIT].[Auto](
	[auto_patente] VARCHAR(10) PRIMARY KEY,
	[auto_marca] VARCHAR(255) NOT NULL,
	[auto_modelo] VARCHAR(255) NOT NULL,
	[chofer_dni] numeric(18,0) NOT NULL,-- REFERENCES [PUSH_IT_TO_THE_LIMIT].[Chofer],					
	[turno_id] INT NOT NULL,-- REFERENCES [PUSH_IT_TO_THE_LIMIT].[Turno],					
	[auto_estado] BIT not null DEFAULT 1,
	[auto_licencia] VARCHAR(26) NOT NULL,
	[auto_rodado] VARCHAR(10),
)

/*Auto por Turno*/
CREATE TABLE [PUSH_IT_TO_THE_LIMIT].[AutoporTurno](
	[auto_patente] VARCHAR(10),
	[turno_id] INTEGER,
	PRIMARY KEY (auto_patente, turno_id)
)
/*Registro de viaje*/
create table [PUSH_IT_TO_THE_LIMIT].RegistroViaje(
	[viaje_id] INT IDENTITY(1,1) PRIMARY KEY,
	[chofer_dni] NUMERIC(18,0) NOT NULL ,--references [PUSH_IT_TO_THE_LIMIT].Chofer,                        
	[viaje_automovil] VARCHAR(8) NOT NULL, --references[PUSH_IT_TO_THE_LIMIT].[Auto],                                              
	[factura_id] INT NOT NULL ,--references [PUSH_IT_TO_THE_LIMIT].Factura,
	[turno_id] INT NOT NULL ,--references [PUSH_IT_TO_THE_LIMIT].Turno,                            
	[viaje_cantidad_km] NUMERIC(18,0) NOT NULL, 
	[viaje_fecha_hora_inicio] DATETIME NOT NULL,
	[viaje_fecha_hora_fin] DATETIME NOT NULL,              /*ACA PODRIAMOS SEPARAR LA FECHA DE LA HORA (SOLO SUGERENCIA)*/
	[cliente_id] INT NOT NULL ,--references [PUSH_IT_TO_THE_LIMIT].Cliente,
)


