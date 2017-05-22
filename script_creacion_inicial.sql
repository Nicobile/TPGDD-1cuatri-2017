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


/*Usuario FALTA CONTRASEŅA DEFAULT QUE ES W23A CREO QUE EN SHA256*/
CREATE TABLE [PUSH_IT_TO_THE_LIMIT].Usuario(
	[usuario_id] INT IDENTITY(1,1) PRIMARY KEY,
	[usuario_name] VARCHAR(255) UNIQUE NOT NULL,
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
	[factura_numero] numeric(18,0) unique not null,
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
	[usuario_id] INT,
	
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
	[rendicion_numero] numeric(18,0) not null,
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
	[rendicion_id] INT,
	[viaje_fecha] VARCHAR(15) NOT NULL,--LO CAMBIO DE DATETIME A VARCHAR POR QUE LA FUNCION QUE USO EN LA MIGRACION PARA OBTENER SOLO LA FECHA RETORNA UN VARCHAR, LO MISMO PARA HORA INICIO Y FIN
	[viaje_hora_inicio] VARCHAR(10) not null ,
	[viaje_hora_fin] VARCHAR(10)  ,--IMPORTANTE :LE SAQUE EL NOT NULL POR QUE EN LA TABLA MAESTRA NO HAY , SI NO HAY QUE PONERLE UN DEFAULT
	[cliente_id] INT NOT NULL ,--references [PUSH_IT_TO_THE_LIMIT].Cliente,
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
ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[RegistroViaje] ADD CONSTRAINT RegistroViaje_Chofer FOREIGN KEY (chofer_dni) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Chofer](chofer_dni)

ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[RegistroViaje] ADD CONSTRAINT RegistroViaje_Factura FOREIGN KEY (factura_id) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Factura](factura_id)

ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[RegistroViaje] ADD CONSTRAINT RegistroViaje_Turno FOREIGN KEY (turno_id) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Turno](Turno_id)

ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[RegistroViaje] ADD CONSTRAINT RegistroViaje_Cliente FOREIGN KEY (cliente_id) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Cliente](Cliente_id)

ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[RegistroViaje] ADD CONSTRAINT RegistroViaje_RendicionViaje FOREIGN KEY (rendicion_id) REFERENCES [PUSH_IT_TO_THE_LIMIT].[RendicionViaje](rendicion_id)

--Creamos la fk de Cliente
ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[Cliente] ADD CONSTRAINT Cliente_Usuario FOREIGN KEY (usuario_id) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Usuario](usuario_id)

--Creamos la fks de RendicionViaje 
ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[RendicionViaje] ADD CONSTRAINT RendicionViaje_Chofer FOREIGN KEY (chofer_dni) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Chofer](chofer_dni)

ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[RendicionViaje] ADD CONSTRAINT RendicionViaje_Turno FOREIGN KEY (Turno_id) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Turno](Turno_id)

--Creamos la fk de factura 
ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[Factura] ADD CONSTRAINT Factura_Cliente FOREIGN KEY (cliente_id) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Cliente](cliente_id)

--Creamos las Fk de Auto
ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[RendicionViaje] ADD CONSTRAINT Auto_Chofer FOREIGN KEY (chofer_dni) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Chofer](chofer_dni)

--Creamos las fks de AutoporTurno
ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[AutoporTurno] ADD CONSTRAINT AutoporTurno_Auto FOREIGN KEY (auto_patente) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Auto](auto_patente)

ALTER TABLE [PUSH_IT_TO_THE_LIMIT].[AutoporTurno] ADD CONSTRAINT AutoporTurno_Turno FOREIGN KEY (Turno_id) REFERENCES [PUSH_IT_TO_THE_LIMIT].[Turno](turno_id)


/*Migracion*/

/*Rol*/
insert into [PUSH_IT_TO_THE_LIMIT].Rol (rol_nombre) values
('Administrativo'), 
('Chofer'), 
('Cliente');



/*Funcionalidad*/



insert into [PUSH_IT_TO_THE_LIMIT].Funcionalidad (funcionalidad_descripcion) values
('ABM de Rol'),
('Registro de usuarios'),
('ABM de Clientes'),
('ABM de Automoviles'),
('ABM de turnos'),
('ABM de choferes'),
('Registro de viajes'),
('Rendicion de viajes'),
('Facturacion de clientes'),
('Listado estadistico');


/*RolXFuncionalidad*/
insert into [PUSH_IT_TO_THE_LIMIT].RolporFunciones (rol_id, funcionalidad_id) values
(1,1), (1,2), (1,3), (1,4),(1,5),(1,6),(1,7),(2,8),(3,9),(1,10),(2,10),(3,10);/* no estoy muy seguro de esta*/



/*Usuarios*/


/*Usuario Administrador*/
insert into [PUSH_IT_TO_THE_LIMIT].Usuario (usuario_name, usuario_password) values
('admin',HASHBYTES('SHA2_256','w23e'))

/*Usuarios choferes*/
insert into [PUSH_IT_TO_THE_LIMIT].Usuario (usuario_name, usuario_password)
select distinct cast(Chofer_Dni as varchar(255)), HASHBYTES('SHA2_256',cast(Chofer_Dni as varchar(255)))
from gd_esquema.Maestra
where Chofer_Dni is not null
order by cast(Chofer_Dni as varchar(255))


/*usuarios clientes*/
insert into [PUSH_IT_TO_THE_LIMIT].Usuario (usuario_name, usuario_password)
select distinct cast(Cliente_Dni as varchar(255)), HASHBYTES('SHA2_256',cast(Cliente_Dni as varchar(255)))
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





/*Turno*/

insert into [PUSH_IT_TO_THE_LIMIT].Turno(turno_descripcion, turno_hora_fin, turno_hora_inicio, turno_precio_base, turno_valor_kilometro)
select distinct Turno_Descripcion, Turno_Hora_Fin, Turno_Hora_Inicio, Turno_Precio_Base, Turno_Valor_Kilometro
from gd_esquema.Maestra
order by Turno_Hora_Inicio



/*Factura*/
insert into [PUSH_IT_TO_THE_LIMIT].Factura (cliente_id, factura_fecha_inicio, factura_fecha_fin, factura_numero, factura_importe_total)
select distinct c.cliente_id, m.Factura_Fecha_Inicio, m.Factura_Fecha_Fin, m.Factura_Nro, ( select sum(m2.Turno_Precio_Base + ( m2.Viaje_Cant_Kilometros * m2.Turno_Valor_Kilometro))   
																							 from gd_esquema.Maestra m2
																							where m2.Factura_Nro = m.Factura_Nro)
from  gd_esquema.Maestra m,[PUSH_IT_TO_THE_LIMIT].Cliente c
where Factura_Nro is not null
and c.cliente_dni = m.Cliente_Dni
order by Factura_Nro





/*Auto*/
insert into [PUSH_IT_TO_THE_LIMIT].Auto (auto_licencia, auto_marca, auto_modelo, auto_patente, auto_rodado, chofer_dni)
select distinct m.Auto_Licencia, m.Auto_Marca, m.Auto_Modelo, m.Auto_Patente, m.Auto_Rodado, c.chofer_dni
from gd_esquema.Maestra m, [PUSH_IT_TO_THE_LIMIT].Chofer c, [PUSH_IT_TO_THE_LIMIT].Turno t
where m.Auto_Patente is not null
and m.Chofer_Dni = c.chofer_dni

/*AutosporTurno*/
insert into [PUSH_IT_TO_THE_LIMIT].AutoporTurno (auto_patente, turno_id)
select distinct  a.auto_patente, t.turno_id
from gd_esquema.Maestra m, [PUSH_IT_TO_THE_LIMIT].[Auto] a, [PUSH_IT_TO_THE_LIMIT].Turno t
where m.Auto_Patente = a.auto_patente
and m.Turno_Hora_Inicio = t.turno_hora_inicio


/*RolporUsuario*/
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


/*RendicionViaje*/  
insert into [PUSH_IT_TO_THE_LIMIT].RendicionViaje( chofer_dni, rendicion_fecha, rendicion_importe_total, rendicion_numero, turno_id)
select distinct c.chofer_dni, m.Rendicion_Fecha, sum(m.Rendicion_Importe), m.Rendicion_Nro, t.turno_id --tira error por que en vez de c.chofer_dni decia c.chofer_direccion
from gd_esquema.Maestra m,  [PUSH_IT_TO_THE_LIMIT].Chofer c, [PUSH_IT_TO_THE_LIMIT].Turno t
where m.Rendicion_Fecha is not null
and m.Chofer_Dni = c.chofer_dni
and m.Turno_Hora_Inicio = t.turno_hora_inicio
group by Rendicion_Nro, c.chofer_dni, t.turno_id, m.Rendicion_Fecha,c.chofer_direccion
order by Rendicion_Nro

/*RegistroViaje*/
insert into [PUSH_IT_TO_THE_LIMIT].RegistroViaje (viaje_automovil, chofer_dni, cliente_id, rendicion_id, turno_id, viaje_cantidad_km, viaje_fecha,viaje_hora_inicio, factura_id)
select distinct  a.auto_patente, ch.chofer_dni, cl.cliente_id, r.rendicion_id, t.turno_id, m.Viaje_Cant_Kilometros,CONVERT(varchar(10),m.Viaje_Fecha,120) viajeFecha,STUFF(m.Viaje_Fecha,1,11,''), f.factura_id
from [PUSH_IT_TO_THE_LIMIT].[Auto] a, [PUSH_IT_TO_THE_LIMIT].Chofer ch, [PUSH_IT_TO_THE_LIMIT].Cliente cl, [PUSH_IT_TO_THE_LIMIT].RendicionViaje r, [PUSH_IT_TO_THE_LIMIT].Turno t, gd_esquema.Maestra m, gd_esquema.Maestra m2, [PUSH_IT_TO_THE_LIMIT].Factura f
where m.Viaje_Cant_Kilometros is not null
and m.Auto_Patente = a.auto_patente
and m.Chofer_Dni = ch.chofer_dni
and m.Cliente_Dni = cl.cliente_dni
and m.Rendicion_Nro = r.rendicion_numero
and m.Turno_Hora_Inicio = t.turno_hora_inicio
and m.Chofer_Dni = m2.Chofer_Dni
and m.Cliente_Dni = m2.Cliente_Dni
and m.Viaje_Fecha = m2.Viaje_Fecha
and m2.Factura_Nro = f.factura_numero
order by viajeFecha