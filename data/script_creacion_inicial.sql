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


/* Eliminamos tablas si ya existen*/

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'PUSH_IT_TO_THE_LIMIT.RolporFunciones'))
    DROP TABLE PUSH_IT_TO_THE_LIMIT.RolporFunciones

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'PUSH_IT_TO_THE_LIMIT.RolporUsuario'))
    DROP TABLE PUSH_IT_TO_THE_LIMIT.RolporUsuario

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'PUSH_IT_TO_THE_LIMIT.AutoporTurno'))
    DROP TABLE PUSH_IT_TO_THE_LIMIT.AutoporTurno

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'PUSH_IT_TO_THE_LIMIT.ChoferporAuto'))
	 DROP TABLE PUSH_IT_TO_THE_LIMIT.ChoferporAuto

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'PUSH_IT_TO_THE_LIMIT.RegistroViaje'))
    DROP TABLE PUSH_IT_TO_THE_LIMIT.RegistroViaje

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'PUSH_IT_TO_THE_LIMIT.Factura'))
    DROP TABLE PUSH_IT_TO_THE_LIMIT.Factura

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'PUSH_IT_TO_THE_LIMIT.Cliente'))
    DROP TABLE PUSH_IT_TO_THE_LIMIT.Cliente

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'PUSH_IT_TO_THE_LIMIT.RendicionViaje'))
    DROP TABLE PUSH_IT_TO_THE_LIMIT.RendicionViaje

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'PUSH_IT_TO_THE_LIMIT.Auto'))
    DROP TABLE PUSH_IT_TO_THE_LIMIT.Auto

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'PUSH_IT_TO_THE_LIMIT.Chofer'))
    DROP TABLE PUSH_IT_TO_THE_LIMIT.Chofer

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'PUSH_IT_TO_THE_LIMIT.Usuario'))
    DROP TABLE PUSH_IT_TO_THE_LIMIT.Usuario

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'PUSH_IT_TO_THE_LIMIT.Funcionalidad'))
    DROP TABLE PUSH_IT_TO_THE_LIMIT.Funcionalidad

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'PUSH_IT_TO_THE_LIMIT.Rol'))
    DROP TABLE PUSH_IT_TO_THE_LIMIT.Rol
		

	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'PUSH_IT_TO_THE_LIMIT.Turno'))
    DROP TABLE PUSH_IT_TO_THE_LIMIT.Turno

	
/*Validacion Triggers*/
IF OBJECT_ID('PUSH_IT_TO_THE_LIMIT.insertar_Turno') IS NOT NULL
		DROP TRIGGER PUSH_IT_TO_THE_LIMIT.insertar_Turno
Go

/*Validacion Funciones y Procedimientos*/
IF OBJECT_ID('PUSH_IT_TO_THE_LIMIT.InsertarFuncXRol') IS NOT NULL
    DROP PROCEDURE PUSH_IT_TO_THE_LIMIT.InsertarFuncXRol
GO

IF OBJECT_ID('PUSH_IT_TO_THE_LIMIT.InsertarRol') IS NOT NULL
    DROP PROCEDURE PUSH_IT_TO_THE_LIMIT.InsertarRol
GO

IF OBJECT_ID('PUSH_IT_TO_THE_LIMIT.crear_chofer') IS NOT NULL
    DROP PROCEDURE PUSH_IT_TO_THE_LIMIT.crear_chofer
GO

IF OBJECT_ID('PUSH_IT_TO_THE_LIMIT.crear_cliente') IS NOT NULL
    DROP PROCEDURE PUSH_IT_TO_THE_LIMIT.crear_cliente
GO

IF OBJECT_ID('PUSH_IT_TO_THE_LIMIT.crear_turno') IS NOT NULL
    DROP PROCEDURE PUSH_IT_TO_THE_LIMIT.crear_turno
GO

IF OBJECT_ID('PUSH_IT_TO_THE_LIMIT.pr_agregar_rol_a_usuario') IS NOT NULL
    DROP PROCEDURE PUSH_IT_TO_THE_LIMIT.pr_agregar_rol_a_usuario
GO
IF OBJECT_ID('PUSH_IT_TO_THE_LIMIT.pr_crear_usuario_con_valores') IS NOT NULL
    DROP PROCEDURE PUSH_IT_TO_THE_LIMIT.pr_crear_usuario_con_valores
GO
IF OBJECT_ID('[PUSH_IT_TO_THE_LIMIT].crear_automovil') IS NOT NULL
    DROP PROCEDURE [PUSH_IT_TO_THE_LIMIT].crear_automovil
GO

IF OBJECT_ID('PUSH_IT_TO_THE_LIMIT.pr_agregar_turno_a_automovil') IS NOT NULL
    DROP PROCEDURE PUSH_IT_TO_THE_LIMIT.pr_agregar_turno_a_automovil
GO


IF OBJECT_ID('PUSH_IT_TO_THE_LIMIT.pr_agregar_chofer_a_automovil') IS NOT NULL
    DROP PROCEDURE PUSH_IT_TO_THE_LIMIT.pr_agregar_chofer_a_automovil
GO

IF OBJECT_ID('PUSH_IT_TO_THE_LIMIT.pr_agregar_registro') IS NOT NULL
    DROP PROCEDURE PUSH_IT_TO_THE_LIMIT.pr_agregar_registro
GO
IF OBJECT_ID('PUSH_IT_TO_THE_LIMIT.pr_agregar_factura') IS NOT NULL
    DROP PROCEDURE PUSH_IT_TO_THE_LIMIT.pr_agregar_factura
GO
IF OBJECT_ID('PUSH_IT_TO_THE_LIMIT.pr_usuario_nombre_password') IS NOT NULL
    DROP PROCEDURE PUSH_IT_TO_THE_LIMIT.pr_usuario_nombre_password
GO

IF OBJECT_ID('PUSH_IT_TO_THE_LIMIT.pr_actualizar_factura_registroviaje') IS NOT NULL
    DROP PROCEDURE PUSH_IT_TO_THE_LIMIT.pr_actualizar_factura_registroviaje
GO

IF OBJECT_ID('PUSH_IT_TO_THE_LIMIT.fx_Top5choferesViajesMasLargosEnUnTrimestre') IS NOT NULL
    DROP FUNCTION PUSH_IT_TO_THE_LIMIT.fx_Top5choferesViajesMasLargosEnUnTrimestre
GO
IF OBJECT_ID('PUSH_IT_TO_THE_LIMIT.fx_Top5DechoferesMayorRecaudacionEnUnTrimeste') IS NOT NULL
    DROP FUNCTION PUSH_IT_TO_THE_LIMIT.fx_Top5DechoferesMayorRecaudacionEnUnTrimeste
GO
IF OBJECT_ID('PUSH_IT_TO_THE_LIMIT.fx_Top5clientesMayorConsumoEnUnTrimestre') IS NOT NULL
    DROP FUNCTION PUSH_IT_TO_THE_LIMIT.fx_Top5clientesMayorConsumoEnUnTrimestre
GO
IF OBJECT_ID('PUSH_IT_TO_THE_LIMIT.fx_Top5clientesQueviajaronEnUnMismoAutoEnUnTrimestre') IS NOT NULL
    DROP FUNCTION PUSH_IT_TO_THE_LIMIT.fx_Top5clientesQueviajaronEnUnMismoAutoEnUnTrimestre
GO
IF OBJECT_ID('PUSH_IT_TO_THE_LIMIT.pr_actualizar_rendicion_registroviaje') IS NOT NULL
    DROP PROCEDURE PUSH_IT_TO_THE_LIMIT.pr_actualizar_rendicion_registroviaje
GO
IF OBJECT_ID('PUSH_IT_TO_THE_LIMIT.pr_agregar_rendicion') IS NOT NULL
    DROP PROCEDURE PUSH_IT_TO_THE_LIMIT.pr_agregar_rendicion
GO

IF OBJECT_ID('PUSH_IT_TO_THE_LIMIT.fx_verificarRendicion') IS NOT NULL
    DROP FUNCTION PUSH_IT_TO_THE_LIMIT.fx_verificarRendicion
GO



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
	[rol_id] INTEGER not null,
	[funcionalidad_id] INTEGER not null,
	PRIMARY KEY (rol_id, funcionalidad_id)
)


/*Usuario*/
CREATE TABLE [PUSH_IT_TO_THE_LIMIT].Usuario(
	[usuario_id] INT IDENTITY(1,1) PRIMARY KEY,
	[usuario_name] VARCHAR(255) UNIQUE NOT NULL,
	[usuario_password] NVARCHAR(255) NOT NULL,
	[usuario_habilitado] [BIT] NOT NULL DEFAULT 1,
	[usuario_intentos] [TINYINT] DEFAULT 0
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
	[usuario_id] INT NOT NULL ,
	[cliente_estado] BIT NOT NULL DEFAULT 1 , 
)


/*Facturacion cliente*/ 
CREATE TABLE [PUSH_IT_TO_THE_LIMIT].Factura(
	 	
	[factura_fecha_inicio] DATETIME , 
	[factura_fecha_fin] DATETIME ,
	[factura_id] numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
	[cliente_id] INT NOT NULL ,
	[factura_importe_total] NUMERIC(18,2) ,
	)


	
/* Creo tabla Chofer*/
CREATE TABLE [PUSH_IT_TO_THE_LIMIT].[Chofer] (
	[chofer_id] INT IDENTITY(1,1) PRIMARY KEY,
	[chofer_dni] NUMERIC(18,0) UNIQUE NOT NULL,
	[chofer_nombre] [VARCHAR](255) NOT NULL,
	[chofer_apellido] [VARCHAR](255) NOT NULL,
	[chofer_direccion] [VARCHAR](255),
	[chofer_telefono] NUMERIC(18,0) UNIQUE,
	[chofer_mail] VARCHAR(50) ,
	[chofer_fecha_Nacimiento] DATETIME NOT NULL,
	[chofer_estado] [bit] NOT NULL DEFAULT 1,
	[usuario_id] INT,
	
)


/* Creo Tabla Turno*/
CREATE TABLE [PUSH_IT_TO_THE_LIMIT].[Turno](
	[turno_id] INT IDENTITY(1,1) PRIMARY KEY,
	[turno_hora_inicio]	NUMERIC(18,0) NOT NULL,
	[turno_hora_fin]  NUMERIC(18,0) NOT NULL,
	[turno_descripcion] VARCHAR(255),
	[turno_valor_kilometro] NUMERIC(18,2) NOT NULL,
	[turno_precio_base] NUMERIC(18,2) NOT NULL,
	[turno_habilitado] BIT NOT NULL DEFAULT 1,
)




/*Rendicion Viaje*/
CREATE TABLE [PUSH_IT_TO_THE_LIMIT].[RendicionViaje](
	[rendicion_id] numeric(18,0)  IDENTITY(1,1) PRIMARY KEY,
	[rendicion_fecha] DATETIME NOT NULL,
	[chofer_id] int NOT NULL ,					
	[turno_id] int NOT NULL ,					
	[rendicion_importe_total] NUMERIC(18,2) NOT NULL,    
)

/*Auto*/
CREATE TABLE [PUSH_IT_TO_THE_LIMIT].[Auto](
	[auto_id] INT IDENTITY(1,1) PRIMARY KEY,
	[auto_patente] VARCHAR(10) UNIQUE NOT NULL,
	[auto_marca] VARCHAR(255) NOT NULL,
	[auto_modelo] VARCHAR(255) NOT NULL,
	[auto_estado] BIT not null DEFAULT 1,
	[auto_licencia] VARCHAR(26),
	[auto_rodado] VARCHAR(10),
)

/*Auto por Turno*/
CREATE TABLE [PUSH_IT_TO_THE_LIMIT].[AutoporTurno](
	[auto_id] int,
	[turno_id] INTEGER,
	[auto_turno_estado] BIT not null DEFAULT 1,
	PRIMARY KEY (auto_id, turno_id)
)
/*Registro de viaje*/
create table [PUSH_IT_TO_THE_LIMIT].RegistroViaje(
	[viaje_id] INT IDENTITY(1,1) PRIMARY KEY,
	[chofer_id] INT NOT NULL ,                      
	[auto_id] int NOT NULL,                                              
	[factura_id] numeric(18,0),
	[turno_id] INT NOT NULL ,                           
	[viaje_cantidad_km] NUMERIC(18,0) NOT NULL, 
	[rendicion_id] NUMERIC(18,0),                                                             
	[viaje_fecha] DATETIME NOT NULL,
	[viaje_hora_inicio] time(0)  ,
	[viaje_hora_fin] time(0)  ,
	[cliente_id] INT NOT NULL ,
)


/*Chofer por Auto*/
CREATE TABLE [PUSH_IT_TO_THE_LIMIT].[ChoferporAuto](
	[chofer_id] INT,
	[auto_id] INT,
	[auto_chofer_estado] BIT not null DEFAULT 1,
	PRIMARY KEY (chofer_id, auto_id)
)

/* Agregamos las FKs */

--Creamos las fk de RolporFunciones
ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[RolporFunciones] ADD CONSTRAINT RolporFunciones_Funcionalidad FOREIGN KEY (funcionalidad_id) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Funcionalidad](funcionalidad_id)

ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[RolporFunciones] ADD CONSTRAINT RolporFunciones_Rol FOREIGN KEY (rol_id) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Rol](rol_id)

--Creamos las Fk de RolporUSuario
ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[RolporUsuario] ADD CONSTRAINT RolporUsuario_Rol FOREIGN KEY (rol_id) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Rol](rol_id)

ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[RolporUsuario] ADD CONSTRAINT RolporUsuario_Usuario FOREIGN KEY (usuario_id) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Usuario](usuario_id)

--Creamos la fk de chofer
ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[Chofer] ADD CONSTRAINT Chofer_Usuario FOREIGN KEY (usuario_id) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Usuario](usuario_id)

--Creamos las fks de Registro
ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[RegistroViaje] ADD CONSTRAINT RegistroViaje_Chofer FOREIGN KEY (chofer_id) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Chofer](chofer_id)

ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[RegistroViaje] ADD CONSTRAINT RegistroViaje_Factura FOREIGN KEY (factura_id) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Factura](factura_id)

ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[RegistroViaje] ADD CONSTRAINT RegistroViaje_Turno FOREIGN KEY (turno_id) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Turno](Turno_id)

ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[RegistroViaje] ADD CONSTRAINT RegistroViaje_Cliente FOREIGN KEY (cliente_id) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Cliente](cliente_id)

ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[RegistroViaje] ADD CONSTRAINT RegistroViaje_RendicionViaje FOREIGN KEY (rendicion_id) REFERENCES [PUSH_IT_TO_THE_LIMIT].[RendicionViaje](rendicion_id)

ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[RegistroViaje] ADD CONSTRAINT RegistroViaje_Auto FOREIGN KEY (auto_id) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Auto](auto_id)
--Creamos la fk de Cliente
ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[Cliente] ADD CONSTRAINT Cliente_Usuario FOREIGN KEY (usuario_id) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Usuario](usuario_id)

--Creamos la fks de RendicionViaje 
ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[RendicionViaje] ADD CONSTRAINT RendicionViaje_Chofer FOREIGN KEY (chofer_id) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Chofer](chofer_id)

ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[RendicionViaje] ADD CONSTRAINT RendicionViaje_Turno FOREIGN KEY (Turno_id) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Turno](Turno_id)

--Creamos la fk de factura 
ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[Factura] ADD CONSTRAINT Factura_Cliente FOREIGN KEY (cliente_id) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Cliente](cliente_id)

--Creamos las fks de AutoporTurno
ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[AutoporTurno] ADD CONSTRAINT AutoporTurno_Auto FOREIGN KEY (auto_id) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Auto](auto_id)

ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[AutoporTurno] ADD CONSTRAINT AutoporTurno_Turno FOREIGN KEY (Turno_id) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Turno](turno_id)

--Creamos las fks de ChoferporAuto
ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[ChoferporAuto] ADD CONSTRAINT ChoferporAuto_Chofer FOREIGN KEY (chofer_id) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Chofer](chofer_id)

ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[ChoferporAuto] ADD CONSTRAINT ChoferporAuto_Auto FOREIGN KEY (auto_id) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Auto](auto_id)


/*Migracion*/

/*Rol*/
insert into [PUSH_IT_TO_THE_LIMIT].Rol (rol_nombre) values
('Administrador'), 
('Chofer'), 
('Cliente');



/*Funcionalidad*/



insert into [PUSH_IT_TO_THE_LIMIT].Funcionalidad (funcionalidad_descripcion) values
('ABM de Rol'),                            
('ABM de Clientes'),                       
('ABM de Automoviles'),                    
('ABM de Turnos'),                         
('ABM de Choferes'),                       
('Registro de Viajes'),                    
('Rendicion de Viajes'),                   
('Facturacion de Clientes'),               
('Listado Estadistico');                   


/*RolXFuncionalidad*/
--Administrador
insert into [PUSH_IT_TO_THE_LIMIT].RolporFunciones (rol_id,funcionalidad_id)
	select distinct R.rol_id, F.funcionalidad_id from [PUSH_IT_TO_THE_LIMIT].Rol R,[PUSH_IT_TO_THE_LIMIT].Funcionalidad F
	where R.rol_nombre = 'Administrador' and
			F.funcionalidad_descripcion in ('ABM de Rol','Facturacion de Clientes','ABM de Clientes','ABM de Automoviles','ABM de turnos','ABM de choferes','Registro de viajes','Listado estadistico','Rendicion de viajes');

--Chofer
insert into [PUSH_IT_TO_THE_LIMIT].RolporFunciones (rol_id,funcionalidad_id)
	select distinct R.rol_id, F.funcionalidad_id from [PUSH_IT_TO_THE_LIMIT].Rol R,[PUSH_IT_TO_THE_LIMIT].Funcionalidad F
	where R.rol_nombre = 'Chofer' and
			F.funcionalidad_descripcion in ('Rendicion de viajes','Listado estadistico');

--Cliente
insert into [PUSH_IT_TO_THE_LIMIT].RolporFunciones (rol_id,funcionalidad_id)
	select distinct R.rol_id, F.funcionalidad_id from [PUSH_IT_TO_THE_LIMIT].Rol R,[PUSH_IT_TO_THE_LIMIT].Funcionalidad F
	where R.rol_nombre = 'Cliente' and
			F.funcionalidad_descripcion in ('Facturacion de clientes');

/*Usuarios*/


/*Usuario Administrador*/
insert into [PUSH_IT_TO_THE_LIMIT].Usuario (usuario_name, usuario_password) values
 ('admin',(SELECT CONVERT(varchar(max),HashBytes('SHA2_256', 'w23e') ,2)))

/*Usuarios choferes*/
insert into [PUSH_IT_TO_THE_LIMIT].Usuario (usuario_name, usuario_password)
select distinct cast(Chofer_Dni as varchar(255)),(SELECT CONVERT(varchar(max),HashBytes('SHA2_256', cast(Chofer_Dni as varchar(255))) ,2))
from gd_esquema.Maestra
where Chofer_Dni is not null
order by cast(Chofer_Dni as varchar(255))


/*usuarios clientes*/
insert into [PUSH_IT_TO_THE_LIMIT].Usuario (usuario_name, usuario_password)
select distinct cast(Cliente_Dni as varchar(255)),(SELECT CONVERT(varchar(max),HashBytes('SHA2_256', cast(Cliente_Dni as varchar(255))) ,2))
from gd_esquema.Maestra
where Cliente_Dni is not null
order by cast(Cliente_Dni as varchar(255))




/*Cliente*/
insert into [PUSH_IT_TO_THE_LIMIT].Cliente (cliente_nombre, cliente_apellido,cliente_dni, cliente_telefono,cliente_direccion,cliente_mail,cliente_fecha_nacimiento, usuario_id)
select distinct m.Cliente_Nombre, m.Cliente_Apellido, m.Cliente_Dni, m.Cliente_Telefono, m.Cliente_Direccion, m.Cliente_Mail, m.Cliente_Fecha_Nac,u.usuario_id   
from gd_esquema.Maestra m , [PUSH_IT_TO_THE_LIMIT].Usuario u
where  cast( m.Cliente_Dni as varchar(255)) = u.usuario_name
order by usuario_ID




/*Chofer*/

insert into [PUSH_IT_TO_THE_LIMIT].Chofer(chofer_nombre, chofer_apellido,chofer_dni, chofer_telefono,chofer_direccion,chofer_mail,chofer_fecha_nacimiento, usuario_id)
select distinct m.chofer_Nombre, m.chofer_Apellido, m.chofer_dni, m.chofer_Telefono, m.chofer_Direccion, m.chofer_Mail, m.chofer_Fecha_Nac, u.usuario_ID
from gd_esquema.Maestra m, [PUSH_IT_TO_THE_LIMIT].Usuario u
where  cast( m.chofer_dni as varchar(255)) = u.usuario_name
order by usuario_ID

/*RolporUsuario*/
/*Admin*/
insert into PUSH_IT_TO_THE_LIMIT.RolporUsuario(usuario_id, rol_id) 
values (1,1)
insert into PUSH_IT_TO_THE_LIMIT.RolporUsuario(usuario_id, rol_id) 
values (1,2)
insert into PUSH_IT_TO_THE_LIMIT.RolporUsuario(usuario_id, rol_id) 
values (1,3)
/*clienteporusuario*/
insert into [PUSH_IT_TO_THE_LIMIT].RolporUsuario( usuario_Id, rol_id)
select distinct u.usuario_ID, r.rol_ID
from [PUSH_IT_TO_THE_LIMIT].Usuario u, [PUSH_IT_TO_THE_LIMIT].Cliente c, [PUSH_IT_TO_THE_LIMIT].Rol r
where u.usuario_name = cast(c.cliente_dni as varchar(255))
and r.rol_nombre = ('Cliente')

/*choferporusuario*/
insert into [PUSH_IT_TO_THE_LIMIT].RolporUsuario( usuario_Id, rol_id)
select distinct u.usuario_ID, r.rol_ID
from [PUSH_IT_TO_THE_LIMIT].Usuario u, [PUSH_IT_TO_THE_LIMIT].Chofer c, [PUSH_IT_TO_THE_LIMIT].Rol r
where u.usuario_name = cast(c.chofer_dni as varchar(255))
and r.rol_nombre = ('Chofer')

/*Turno*/

insert into [PUSH_IT_TO_THE_LIMIT].Turno(turno_descripcion, turno_hora_fin, turno_hora_inicio, turno_precio_base, turno_valor_kilometro)
select distinct Turno_Descripcion,Turno_Hora_Fin, Turno_Hora_Inicio, Turno_Precio_Base, Turno_Valor_Kilometro
from gd_esquema.Maestra
order by Turno_Hora_Inicio




/*RendicionViaje*/  
SET IDENTITY_INSERT [PUSH_IT_TO_THE_LIMIT].RendicionViaje ON
insert into [PUSH_IT_TO_THE_LIMIT].RendicionViaje(chofer_id, rendicion_fecha, rendicion_importe_total, rendicion_id, turno_id)
select distinct c.chofer_id, m.Rendicion_Fecha, sum(m.Rendicion_Importe), m.Rendicion_Nro, t.turno_id 
from gd_esquema.Maestra m,  [PUSH_IT_TO_THE_LIMIT].Chofer c, [PUSH_IT_TO_THE_LIMIT].Turno t
where m.Rendicion_Fecha is not null
and m.Chofer_Dni = c.chofer_dni
and  m.Turno_Hora_Inicio = t.turno_hora_inicio
group by Rendicion_Nro, c.chofer_id, t.turno_id, m.Rendicion_Fecha
SET IDENTITY_INSERT [PUSH_IT_TO_THE_LIMIT].RendicionViaje OFF




/*Auto*/
insert into [PUSH_IT_TO_THE_LIMIT].Auto (auto_licencia, auto_marca, auto_modelo, auto_patente, auto_rodado)
select distinct m.Auto_Licencia, m.Auto_Marca, m.Auto_Modelo, m.Auto_Patente, m.Auto_Rodado
from gd_esquema.Maestra m, [PUSH_IT_TO_THE_LIMIT].Turno t
where m.Auto_Patente is not null


/*AutosporTurno*/
insert into [PUSH_IT_TO_THE_LIMIT].AutoporTurno (auto_id, turno_id)
select distinct  a.auto_id, t.turno_id
from gd_esquema.Maestra m, [PUSH_IT_TO_THE_LIMIT].[Auto] a, [PUSH_IT_TO_THE_LIMIT].Turno t
where m.Auto_Patente = a.auto_patente
and m.Turno_Hora_Inicio = t.turno_hora_inicio

/*Chofer por Auto*/
insert into [PUSH_IT_TO_THE_LIMIT].ChoferporAuto(chofer_id, auto_id)
select distinct c.chofer_id, a.auto_id
from  [PUSH_IT_TO_THE_LIMIT].[Chofer] c, [PUSH_IT_TO_THE_LIMIT].[Auto] a, gd_esquema.Maestra m
where m.Chofer_Dni = c.chofer_dni
and m.Auto_Patente = a.auto_patente

/*Factura*/

		SET IDENTITY_INSERT [PUSH_IT_TO_THE_LIMIT].Factura ON					
	INSERT INTO [PUSH_IT_TO_THE_LIMIT].Factura(factura_id,cliente_id,factura_fecha_inicio,factura_fecha_fin,factura_importe_total)			
	SELECT	Factura_Nro,
		   cliente.cliente_id,
		   Factura_Fecha_Inicio,
		   Factura_Fecha_Fin,
		   SUM(Turno_Precio_Base+Turno_Valor_Kilometro*Viaje_Cant_Kilometros)
		   From [gd_esquema].Maestra m JOIN [PUSH_IT_TO_THE_LIMIT].Cliente cliente on (cliente.cliente_dni = m.Cliente_Dni)
			WHERE Factura_Nro IS NOT NULL
	GROUP BY Factura_Nro, cliente.cliente_id, Factura_Fecha, Factura_Fecha_Inicio, Factura_Fecha_Fin
	SET IDENTITY_INSERT [PUSH_IT_TO_THE_LIMIT].RendicionViaje OFF



/*RegistroViaje*/
insert into [PUSH_IT_TO_THE_LIMIT].RegistroViaje (auto_id, chofer_id, cliente_id, rendicion_id, turno_id, viaje_cantidad_km, viaje_fecha,viaje_hora_inicio, factura_id)

select auto.auto_id,
		choferes.chofer_id,
		cliente.cliente_id,
		viajeCompleto.Rendicion_Nro,
		turno.turno_id,	
		m.Viaje_Cant_Kilometros,
		convert(date,m.Viaje_Fecha),
		CONVERT(time,m.Viaje_Fecha),
		viajeCompleto.Factura_Nro FROM [gd_esquema].Maestra m
	LEFT JOIN (
				SELECT DISTINCT 
					conRendicion.Auto_Patente,
					conRendicion.Chofer_dni,
					conRendicion.Cliente_Dni,
					conRendicion.Rendicion_Nro,
					conRendicion.Turno_Hora_Inicio,
					conRendicion.Viaje_Cant_Kilometros,
					conRendicion.Viaje_Fecha,	
					conFactura.Factura_Nro
				From [gd_esquema].Maestra conrendicion JOIN [gd_esquema].[Maestra] confactura on
				(conRendicion.Cliente_Dni = confactura.Cliente_Dni			
					AND conrendicion.Viaje_Fecha = confactura.Viaje_Fecha 
					AND conrendicion.Chofer_Dni = confactura.Chofer_Dni)
				WHERE (conrendicion.Rendicion_Nro IS NOT NULL AND confactura.Factura_Nro IS NOT NULL)
			)viajeCompleto									
				on (viajeCompleto.Chofer_Dni = m.Chofer_Dni 
					AND viajeCompleto.Cliente_Dni = m.Cliente_Dni 
					AND viajeCompleto.Viaje_Fecha = m.Viaje_Fecha)		
			JOIN [PUSH_IT_TO_THE_LIMIT].Chofer choferes on (choferes.chofer_dni=m.Chofer_Dni)		
			JOIN [PUSH_IT_TO_THE_LIMIT].Auto auto on (auto.auto_patente=m.Auto_Patente)			
			JOIN [PUSH_IT_TO_THE_LIMIT].Cliente cliente on (cliente.cliente_dni = m.Cliente_Dni)		
		JOIN [PUSH_IT_TO_THE_LIMIT].Turno turno on (turno.turno_hora_inicio = m.Turno_Hora_Inicio)	
		WHERE (m.Factura_Nro IS NULL AND m.Rendicion_Nro IS NULL)

/*Triggers*/
--Agrego Trigger para evitar que al actualizar o cargar un nuevo turno se superpongan, voy chequeando que las franjas no se incluyan 

Go
CREATE TRIGGER insertar_Turno
ON [PUSH_IT_TO_THE_LIMIT].[Turno]
AFTER INSERT,UPDATE  AS 
	BEGIN
		IF(SELECT COUNT(*) FROM PUSH_IT_TO_THE_LIMIT.Turno T,inserted I 
			WHERE ((I.turno_hora_inicio > T.turno_hora_inicio AND I.turno_hora_inicio < T.turno_hora_fin)
				
				OR( I.turno_hora_fin > T.turno_hora_inicio AND I.turno_hora_fin < T.turno_hora_fin)	)	
				
				AND I.turno_id <>T.turno_id	AND T.turno_habilitado = 1)> 0
		
				BEGIN
					rollback transaction;
					throw 51000,'El turno ingresado se superpone con otro',1;
				END
		
		IF(SELECT COUNT(*) FROM PUSH_IT_TO_THE_LIMIT.Turno T,inserted I 
			WHERE ((T.turno_hora_inicio > I.turno_hora_inicio AND T.turno_hora_inicio < I.turno_hora_fin)
				
				OR( T.turno_hora_fin > I.turno_hora_inicio AND T.turno_hora_fin < I.turno_hora_fin)	)	
				
				AND I.turno_id <>T.turno_id  AND T.turno_habilitado=1	)> 0
								
				BEGIN
					rollback transaction;
					throw 51001,'El turno ingresado se superpone con otro',1;
				END

		IF(SELECT COUNT(*) FROM PUSH_IT_TO_THE_LIMIT.Turno T,inserted I 
			WHERE (T.turno_hora_inicio = I.turno_hora_inicio AND T.turno_hora_fin = I.turno_hora_fin)
								
				AND I.turno_id <>T.turno_id  AND T.turno_habilitado=1	)> 0
								
				BEGIN
					rollback transaction;
				
					throw 51002,'El turno ingresado ya existe y esta Activo',1;
				END

		IF(SELECT COUNT(*) FROM PUSH_IT_TO_THE_LIMIT.Turno T,inserted I 
			WHERE (T.turno_hora_inicio = I.turno_hora_inicio AND T.turno_hora_fin = I.turno_hora_fin)
								
				AND I.turno_id <>T.turno_id  AND T.turno_habilitado=0	)> 0
								
				BEGIN
					rollback transaction;
				
					throw 51003,'El turno ingresado ya existe y esta Deshabilitado ',1;
				END

		IF EXISTS (SELECT turno_hora_inicio,turno_hora_fin  FROM inserted 
					WHERE turno_hora_inicio>turno_hora_fin 
							OR turno_hora_inicio < 0 
							OR turno_hora_fin > 24)
			BEGIN
				rollback transaction;
				throw 51004,'El horario ingresado es mayor a un dia o es invalido',1;
			END

	END


--Procedures
Go
create proc [PUSH_IT_TO_THE_LIMIT].InsertarFuncXRol
@rol int,
@funcionalidad int
as
begin
declare @respuesta int
begin tran ta
begin try
insert into [PUSH_IT_TO_THE_LIMIT].RolporFunciones(rol_id,funcionalidad_id) values(@rol,@funcionalidad);
set @respuesta =(select funcionalidad_id from [PUSH_IT_TO_THE_LIMIT].RolporFunciones   where rol_id = @rol and funcionalidad_id = @funcionalidad)
select @respuesta as respuesta
commit tran ta
end try
begin catch
rollback tran ta
set @respuesta=0
select @respuesta as respuesta
end catch
end
GO
-------------------------------------------------------------
Go
create proc [PUSH_IT_TO_THE_LIMIT].InsertarRol
@rol nvarchar(100),
@estado bit
as
begin
declare @respuesta int
begin tran ta
begin try
	insert into [PUSH_IT_TO_THE_LIMIT].Rol (rol_nombre,rol_estado) values(@rol,@estado);
	set @respuesta =(select rol_id from [PUSH_IT_TO_THE_LIMIT].Rol where rol_nombre = @rol)
	select @respuesta as respuesta
commit tran ta
end try
begin catch
rollback tran ta
set @respuesta=0
select @respuesta as respuesta
end catch
end
GO

------------------------------------------------
--Procedure para crear un chofer 
create proc [PUSH_IT_TO_THE_LIMIT].crear_chofer
    @Nombre nvarchar(255),
    @Apellido varchar(50),
    @DNI numeric(18,0),
    @Direccion varchar(255),
    @Telefono numeric(18,0),
    @Mail varchar(50),
	@Fecha_Nacimiento datetime,
	@Activo bit,
	@User_id int,
	@id int OUTPUT
AS
BEGIN
    INSERT INTO [PUSH_IT_TO_THE_LIMIT].Chofer
        (chofer_nombre, chofer_apellido,chofer_dni,  chofer_direccion, chofer_telefono, chofer_mail, chofer_fecha_Nacimiento,chofer_estado,usuario_id) 
    VALUES 
        (@Nombre, @Apellido, @DNI, @Direccion, @Telefono, @Mail, @Fecha_Nacimiento,@Activo,@User_id)
    SET @id = SCOPE_IDENTITY(); 
END
GO


--Procedure para crear un cliente
create proc [PUSH_IT_TO_THE_LIMIT].crear_cliente
    @Nombre nvarchar(255),
    @Apellido varchar(255),
	@Mail varchar(255),
	@Telefono numeric(18,0),
	@Direccion varchar(255),
	@Codigo_Postal int,
	@Fecha_Nacimiento datetime,
    @DNI numeric(18,0),
	@Activo bit,
	@User_id int,
	@id int OUTPUT
AS
BEGIN
    INSERT INTO [PUSH_IT_TO_THE_LIMIT].Cliente
        (cliente_nombre, cliente_apellido, cliente_mail,  cliente_telefono, cliente_direccion, cliente_codigo_postal, cliente_fecha_nacimiento,cliente_dni,cliente_estado,usuario_id) 
    VALUES 
        (@Nombre, @Apellido, @Mail, @Telefono, @Direccion, @Codigo_Postal, @Fecha_Nacimiento,@DNI,@Activo,@User_id)
    SET @id = SCOPE_IDENTITY(); 
END
GO

--Procedure para crear un turno
CREATE PROCEDURE [PUSH_IT_TO_THE_LIMIT].crear_turno
    @hora_inicio numeric(18,0),
    @hora_fin numeric(18,0),
    @descripcion nvarchar(255),
    @valor_km numeric(18,2),
    @precio_base numeric(18,2),
    @habilitado bit,
	@id int OUTPUT
AS
BEGIN
    INSERT INTO PUSH_IT_TO_THE_LIMIT.Turno 
        (turno_hora_inicio,turno_hora_fin,turno_descripcion,turno_valor_kilometro,turno_precio_base,turno_habilitado) 
    VALUES 
        (@hora_inicio,@hora_fin,@descripcion,@valor_km,@precio_base,@habilitado)
    SET @id = SCOPE_IDENTITY(); 
END
GO


--Procedure para agregarle un rol a un usuario
CREATE PROCEDURE PUSH_IT_TO_THE_LIMIT.pr_agregar_rol_a_usuario
    @usuario_id int,
    @rol_id int
AS
BEGIN
    INSERT INTO PUSH_IT_TO_THE_LIMIT.RolporUsuario
        (rol_id, usuario_id)
    VALUES
        (@rol_id, @usuario_id)
END
GO

--Procedure para agregar un usuario con valores
CREATE PROCEDURE  PUSH_IT_TO_THE_LIMIT.pr_crear_usuario_con_valores
    @username nvarchar(50),
    @password nvarchar(150),
    @usuario_id INT OUTPUT
AS
BEGIN
    INSERT INTO  PUSH_IT_TO_THE_LIMIT.Usuario
        (usuario_name, usuario_password) 
    VALUES 
        (@username, @password)
    SET @usuario_id = SCOPE_IDENTITY(); 
END
GO
--Procedure para crear un Auto
create proc [PUSH_IT_TO_THE_LIMIT].crear_automovil
    @Patente nvarchar(255),
    @Marca nvarchar(255),
    @Modelo nvarchar(255),
    @Activo bit,
	@id int OUTPUT
AS
BEGIN
    INSERT INTO [PUSH_IT_TO_THE_LIMIT].Auto
        (auto_patente, auto_marca,auto_modelo, auto_estado) 
    VALUES 
        (@Patente, @Marca, @Modelo,@Activo)
    SET @id = SCOPE_IDENTITY(); 
END
GO
--Procedure para agregarle un Turno a un Auto
CREATE PROCEDURE PUSH_IT_TO_THE_LIMIT.pr_agregar_turno_a_automovil
    @turno_id int,
    @auto_id int
AS
BEGIN
    INSERT INTO PUSH_IT_TO_THE_LIMIT.AutoporTurno
        (turno_id, auto_id)
    VALUES
        (@turno_id, @auto_id)
END
GO
--Procedure para agregarle un Chofer a un Auto
CREATE PROCEDURE PUSH_IT_TO_THE_LIMIT.pr_agregar_chofer_a_automovil
    @chofer_id int,
    @auto_id int
AS
BEGIN
	if((SELECT COUNT(*) FROM PUSH_IT_TO_THE_LIMIT.ChoferporAuto C JOIN PUSH_IT_TO_THE_LIMIT.AUTO A ON (A.auto_id=C.auto_id) WHERE A.auto_estado=1 AND  chofer_id=@chofer_id AND auto_chofer_estado=1)=0)  
		BEGIN 
			INSERT INTO PUSH_IT_TO_THE_LIMIT.ChoferporAuto
			(chofer_id, auto_id)
			VALUES
			(@chofer_id, @auto_id)
		END
	ELSE 
		throw 51005,'El Chofer ya tiene un Coche activo asignado ',1;
	
END
GO

--Procedure de creacion de un registro de viaje nuevo
  CREATE PROCEDURE PUSH_IT_TO_THE_LIMIT.pr_agregar_registro
  @Cantidad_km numeric(18,0),
  @Fecha date,
  @HoraInicio time,
  @HoraFin time,
  @idChofer int,
  @idAuto int,
  @idCliente int,
  @idTurno int,
  @id int OUTPUT
  AS
BEGIN	
	if exists(select 1 from [PUSH_IT_TO_THE_LIMIT].RegistroViaje where(chofer_id = @idChofer AND
	(@HoraInicio >= viaje_hora_inicio OR @HoraFin <= viaje_hora_fin )
	AND viaje_fecha = @fecha)) throw 51015,'EL chofer ya tiene otro viaje registrado en ese horario',16;

	
	if exists(select 1 from [PUSH_IT_TO_THE_LIMIT].RegistroViaje 
	where(cliente_id = @idCliente AND
	(@HoraInicio >= viaje_hora_inicio OR @HoraFin <= viaje_hora_fin)
	AND viaje_fecha = @fecha)
	
	) throw 51016,'EL cliente ya tiene otro viaje registrado en ese horario',16;
	
    INSERT INTO [PUSH_IT_TO_THE_LIMIT].RegistroViaje
        (viaje_cantidad_km, viaje_fecha,viaje_hora_inicio, viaje_hora_fin,chofer_id,auto_id,cliente_id,turno_id) 
    VALUES 
        (@Cantidad_km,@Fecha,@HoraInicio,@HoraFin,@idChofer,@idAuto,@idCliente,@idTurno)
    SET @id = SCOPE_IDENTITY(); 
END
GO

--Procedure de creacion de una factura
 CREATE PROCEDURE PUSH_IT_TO_THE_LIMIT.pr_agregar_factura
  @FechaInicio DateTime,
  @FechaFin DateTime,
  @idCliente int,
  @ImporteTotal int,
  @id int OUTPUT
AS
BEGIN

	INSERT INTO PUSH_IT_TO_THE_LIMIT.Factura 
		(factura_fecha_inicio,factura_fecha_fin,cliente_id,factura_importe_total)
	VALUES	
		(@FechaInicio,@FechaFin,@idCliente,@ImporteTotal)
	SET @id = SCOPE_IDENTITY(); 
END
GO


--procedure para la creacion de una rendicion de viaje
 CREATE PROCEDURE PUSH_IT_TO_THE_LIMIT.pr_agregar_rendicion
  @fecha DateTime,
  @idChofer int,
  @idTurno int,
  @importeTotal int,
  @id int OUTPUT
AS
BEGIN

	INSERT INTO PUSH_IT_TO_THE_LIMIT.RendicionViaje
		(rendicion_fecha,chofer_id,turno_id,rendicion_importe_total)
	VALUES	
		(@fecha,@idChofer,@idTurno,@importeTotal)
	SET @id = SCOPE_IDENTITY(); 
END
GO


--procedure para actualizar el registro con el id de factura
CREATE PROCEDURE PUSH_IT_TO_THE_LIMIT.pr_actualizar_factura_registroviaje
  @idFactura int,
  @FechaInicio DateTime,
  @FechaFin DateTime,
  @idCliente int
 
AS
BEGIN
	if(@idFactura>0)
		BEGIN
		UPDATE PUSH_IT_TO_THE_LIMIT.RegistroViaje SET factura_id= @idFactura 
		WHERE viaje_id IN (
			SELECT viaje_id FROM PUSH_IT_TO_THE_LIMIT.RegistroViaje R JOIN PUSH_IT_TO_THE_LIMIT.Turno T ON(R.turno_id = T.turno_id) WHERE viaje_fecha>=@fechaInicio AND viaje_fecha<=@fechaFin AND factura_id IS NULL AND cliente_id =@idCliente
			)
		END

END
GO


--procedure para actualizar el registro con el id de rendicion
CREATE PROCEDURE PUSH_IT_TO_THE_LIMIT.pr_actualizar_rendicion_registroviaje
  @idRendicion int,
  @Fecha DateTime,
  @idChofer int,
  @idTurno int
AS
BEGIN
	if(@idRendicion>0)
		BEGIN
		UPDATE PUSH_IT_TO_THE_LIMIT.RegistroViaje SET rendicion_id= @idRendicion
		WHERE viaje_id IN (
			SELECT viaje_id FROM PUSH_IT_TO_THE_LIMIT.RegistroViaje R JOIN PUSH_IT_TO_THE_LIMIT.Turno T ON(R.turno_id = T.turno_id) WHERE viaje_fecha = @Fecha AND rendicion_id IS NULL AND chofer_id =@idChofer
			)
		END

END
GO










--Procedure de actualizacion usuario y contrase�a
CREATE PROCEDURE PUSH_IT_TO_THE_LIMIT.pr_usuario_nombre_password
  @idUsuario INT,
  @nombreUsuario NVARCHAR(255),
  @passwordUsuario NVARCHAR(255)
AS
BEGIN
	UPDATE PUSH_IT_TO_THE_LIMIT.Usuario 
		SET usuario_name=@nombreUsuario ,usuario_password=@passwordUsuario
			WHERE usuario_id=@idUsuario
END
GO



--Funciones para listado estadistico

--  Para cada chofer se selecciona su viaje mas largo (mayor cantidad de kilometros) y luego se ordenan de forma descendente


CREATE FUNCTION PUSH_IT_TO_THE_LIMIT.fx_Top5choferesViajesMasLargosEnUnTrimestre(@anio int,@trimestre int)
RETURNS TABLE
AS
RETURN(
		SELECT TOP 5 (chofer.chofer_apellido+' '+chofer.chofer_nombre)as Chofer, max(viaje_cantidad_km) as Distancia
		FROM PUSH_IT_TO_THE_LIMIT.RegistroViaje viaje JOIN PUSH_IT_TO_THE_LIMIT.Chofer chofer on  viaje.chofer_id = chofer.chofer_id
		GROUP BY  chofer.chofer_apellido,chofer.chofer_nombre
		ORDER BY Distancia DESC
)
GO

--  Se agrupan las rendiciones por chofer luego se suman los importes de cada una de la rendicion pr ultimo se ordenan de forma descendente seg�n el total 
 
CREATE FUNCTION PUSH_IT_TO_THE_LIMIT.fx_Top5DechoferesMayorRecaudacionEnUnTrimeste(@anio int, @trimestre int)
RETURNS TABLE
AS
RETURN(
		SELECT TOP 5 (chofer.chofer_apellido+' '+chofer.chofer_nombre) as Chofer,
			sum(rendicion_importe_total) as 'Total($)'	
			from [PUSH_IT_TO_THE_LIMIT].RendicionViaje rendicion join [PUSH_IT_TO_THE_LIMIT].Chofer chofer on (rendicion.chofer_id = chofer.chofer_id)
			where year(rendicion.rendicion_fecha)=@anio AND DATEPART(qq,rendicion.rendicion_fecha)=@trimestre 
			Group by rendicion.chofer_id, chofer.chofer_apellido, chofer.chofer_nombre, chofer.chofer_direccion, chofer.chofer_mail,chofer.chofer_telefono
			order by sum(rendicion_importe_total) desc
)
GO
--  Los viajes se ordenan, para cada cliente, en forma descendente segun la cantidad de veces que utiliz� el mismo auto	y se selecciona el veh�culo, de los 5 primerosc clientes, con el que mayor viajes realiz�.

CREATE FUNCTION PUSH_IT_TO_THE_LIMIT.fx_Top5clientesQueviajaronEnUnMismoAutoEnUnTrimestre(@anio int,@trimestre int)
RETURNS TABLE
AS
RETURN(
		SELECT TOP 5 (cliente.cliente_apellido+' '+cliente.cliente_nombre)as Cliente,auto.auto_marca, auto.auto_patente,Viajes
		FROM ( SELECT viaje.cliente_id, viaje.auto_id,
				ROW_NUMBER() OVER (PARTITION BY viaje.cliente_id ORDER BY count(*) DESC) AS Fila,
				count(*) as Viajes
			FROM PUSH_IT_TO_THE_LIMIT.RegistroViaje viaje
			WHERE YEAR(viaje_fecha)=@anio AND DATEPART(qq,viaje_fecha) = @trimestre
			GROUP BY viaje.cliente_id,viaje.auto_id)Resultados JOIN PUSH_IT_TO_THE_LIMIT.Cliente cliente ON (Resultados.cliente_id = cliente.cliente_id)
												JOIN PUSH_IT_TO_THE_LIMIT.Auto auto on (Resultados.auto_id = auto.auto_id)
			 WHERE Resultados.Fila = 1
			ORDER BY Viajes DESC
)
GO

--  Se agrupan las facturas por cliente  luego para cada cliente se suman los importes de cada una de estas facturas  y ordenan de mayor a menor seg�n el total de cada cliente 

CREATE FUNCTION PUSH_IT_TO_THE_LIMIT.fx_Top5clientesMayorConsumoEnUnTrimestre(@anio int,@trimestre int)
RETURNS TABLE
AS
RETURN(
		SELECT TOP 5 (cliente.cliente_apellido+' '+cliente.cliente_nombre) as Cliente,sum(factura_importe_total) as ConsumoCliente 
		from PUSH_IT_TO_THE_LIMIT.Factura fact join PUSH_IT_TO_THE_LIMIT.Cliente cliente on (fact.cliente_id = cliente.cliente_id)
		WHERE year(fact.factura_fecha_fin) = @anio AND DATEPART(qq,fact.factura_fecha_fin) = @trimestre
		GROUP BY fact.cliente_id,cliente.cliente_apellido, cliente.cliente_nombre
		ORDER BY ConsumoCliente Desc
)
GO
--me fijo si el chofer ya tiene una rendicion en esa fecha. si no tiene el count devuelve 0 y le puedo crear una rendicion
CREATE FUNCTION PUSH_IT_TO_THE_LIMIT.fx_verificarRendicion(@fecha nvarchar(15),@idchofer int)
RETURNS TABLE
as
return (select count(*) as CantidadRegistros from PUSH_IT_TO_THE_LIMIT.RendicionViaje r where convert(date,r.rendicion_fecha) =convert(date, @fecha) and r.chofer_id= @idchofer)
go