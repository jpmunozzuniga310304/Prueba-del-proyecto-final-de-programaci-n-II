/*
   Segundo Proyecto de Programación II
   Estudiantes: José Pablo Muñoz Zúñiga
                Karina Marina Unfried Montoya
				Dillan Josue Obando Samudio
   Carrera: Ingeniería Informática
   Materia: Programación II
*/

/*En esta parte se crea la base de datos*/

CREATE DATABASE PRUEBAFINALDELPROYECTODEPROGRAMACIONII
GO

/*En esta parte tiene la funcion para denominar una base externa como base de datos actual*/

USE PRUEBAFINALDELPROYECTODEPROGRAMACIONII
GO

/*En esta parte se crea la tabla equipos*/

CREATE TABLE Equipos
(
    EquipoID int identity(1,1), 
	TipoEquipo varchar(50) NOT NULL,
	Modelo varchar(54) NOT NULL,
	UsuarioID int,
	CONSTRAINT pk_idequipos PRIMARY KEY(EquipoID)
)
GO

/*En esta parte se crea la tabla usuarios*/

CREATE TABLE Usuarios
(
    UsuarioID int identity(1,1),
	Nombre varchar(100) NOT NULL,
	CorreoElectronico varchar(107) NOT NULL,
	Telefono int,
	CONSTRAINT pk_idusuarios PRIMARY KEY (UsuarioID),
)
GO

/*En esta parte se crea la tabla tecnicos*/

CREATE TABLE Tecnicos
(
    TecnicoID int identity(1,1),
	Nombre varchar(105) NOT NULL,
	Especialidad varchar(105) NOT NULL,
	CONSTRAINT pk_idtecnicos PRIMARY KEY (TecnicoID),
)
GO

/*En esta parte se crea la tabla reparaciones*/

CREATE TABLE Reparaciones
(
    ReparacionID int identity(1000,35),
	EquipoID int,
	FechaSolicitud datetime constraint df_fecha2 DEFAULT GETDATE(),
	Estado varchar(200) NOT NULL,
	CONSTRAINT pk_idrepaciones PRIMARY KEY (ReparacionID),
	CONSTRAINT fk_idequipos2 FOREIGN KEY (EquipoID) REFERENCES Equipos (EquipoID)
)
GO

/*En esta parte se crea la tabla detallesreparacion*/

CREATE TABLE DetallesReparacion
(
    DetalleID int identity(1002,143),
	ReparacionID int,
	Descripcion varchar(103) NOT NULL,
	FechaInicio datetime constraint df_fecha3 DEFAULT GETDATE(),
	FechaFin datetime constraint df_fecha5 DEFAULT GETDATE(),
	CONSTRAINT pk_iddetallesreparacion PRIMARY KEY (DetalleID),
	CONSTRAINT fk_idequipos3 FOREIGN KEY (ReparacionID) REFERENCES Equipos (EquipoID)
)
GO

/*En esta parte se crea la tabla asignaciones*/

CREATE TABLE Asignaciones
(
    AsignacionID int identity(120,35),
	ReparacionID int,
	TecnicoID int,
	FechaAsignacion datetime constraint df_fecha4 DEFAULT GETDATE(),
	CONSTRAINT pk_idasignaciones PRIMARY KEY (AsignacionID),
	CONSTRAINT fk_idequipos4 FOREIGN KEY (ReparacionID) REFERENCES Equipos (EquipoID)
)
GO

/*En esta parte se crea la tabla reporte equipos*/

CREATE TABLE Reporteequipos
(
    EquipoID int identity(120,35),
	Nombre varchar(103) NOT NULL,
	AsignacionID int,
	FechaAsignacion datetime constraint df_fecha7 DEFAULT GETDATE(),
    ReparacionID int,
	FechaSolicitud datetime constraint df_fecha8 DEFAULT GETDATE(),
    Estado varchar(103) NOT NULL,
	Descripcion varchar(103) NOT NULL,
	TipoEquipo varchar(103) NOT NULL,
	Modelo varchar(103) NOT NULL,
	Nombre1 varchar(103) NOT NULL,
	CorreoElectronico varchar(103) NOT NULL,
	CONSTRAINT pk_idreporteequipos PRIMARY KEY (EquipoID),
	CONSTRAINT fk_idequipos5 FOREIGN KEY (ReparacionID) REFERENCES Equipos (EquipoID)
)
GO

/*En esta parte se crea el perfil de una persona*/

CREATE TABLE Persona
(
Id int identity,
correo varchar(60) NOT NULL, 
clave varchar(60) NOT NULL,
nombre varchar(60) NOT NULL, 
idrol int,
Descripcion varchar(60) NOT NULL,
CONSTRAINT pk_idpersona PRIMARY KEY(Id),
CONSTRAINT uq_correo UNIQUE (correo)
)
GO

/*En esta parte son las profesiones de cada persona*/

CREATE TABLE Rol
(
Id int identity,
Descripcion varchar(60) NOT NULL
CONSTRAINT pk_idrol PRIMARY KEY(Id)
)
GO

/*En esta parte es donde se almacena el id de las profesiones y el id del usuario de cada persona*/

CREATE TABLE PersonaRol
(
Id int identity(108,6),
idpersona int, 
idrol int,
fecha datetime CONSTRAINT df_fecha6 DEFAULT GETDATE(),
CONSTRAINT pk_idpersonal PRIMARY KEY(Id),
CONSTRAINT fk_idpersona FOREIGN KEY(idpersona) REFERENCES persona(id),
CONSTRAINT fk_idrol FOREIGN KEY (idrol) REFERENCES rol(Id)
)
GO

-- PROCEDIMIENTOS ALMACENADOS, STORE PROCEDURE, SP, PA

/*En esta parte sirve para agregar equipos*/

CREATE PROCEDURE Agregarequipos
@TIPOEQUIPO VARCHAR(100),
@MODELO VARCHAR(100),
@USUARIOID INT
  AS
    BEGIN
	    INSERT INTO Equipos VALUES (@TIPOEQUIPO, @MODELO, @USUARIOID)
	END
GO

/*En esta parte sirve para borrar equipos*/

CREATE PROCEDURE Borrarequipos
@CODIGO INT
   AS    
     BEGIN
	     DELETE Equipos WHERE EquipoID =@CODIGO
	 END
GO

/*En esta parte sirve para actualizar los equipos*/

CREATE PROCEDURE Actualizarequipos
@CODIGO INT,
@TIPOEQUIPO VARCHAR(100),
@MODELO VARCHAR(100),
@USUARIOID INT
    AS    
      BEGIN
	    UPDATE Equipos SET TipoEquipo=@TIPOEQUIPO WHERE EquipoID =@CODIGO 
	    UPDATE Equipos SET Modelo=@MODELO WHERE EquipoID =@CODIGO 
		UPDATE Equipos SET UsuarioID=@USUARIOID WHERE EquipoID =@CODIGO 
	  END
GO

/*En esta parte sirve para consultar equipos*/

CREATE PROCEDURE Consultaequipos
  AS
    BEGIN
	  SELECT * FROM Equipos
	END
GO

/*En esta parte es la segunda programacion de consultar equipos para que funcione correctamente la consulta de quipos*/

CREATE PROCEDURE Consultarquipos_filtro
@CODIGO INT
  AS
    BEGIN
	  SELECT * FROM Equipos WHERE EquipoID = @CODIGO
	END
GO

/*En esta parte sirve para agregar usuarios*/

CREATE PROCEDURE Agregarusuarios
@NOMBRE VARCHAR(100),
@CORREOELECTRONICO VARCHAR(100),
@TELEFONO INT
  AS
    BEGIN
	    INSERT INTO Usuarios VALUES (@NOMBRE, @CORREOELECTRONICO, @TELEFONO)
	END
GO

/*En esta parte sirve para borrar usuarios*/

CREATE PROCEDURE Borrarusuarios
@CODIGO INT
  AS    
    BEGIN
	   DELETE Usuarios WHERE UsuarioID =@CODIGO
	END
GO

/*En esta parte sirve para actualizar los usuarios*/

CREATE PROCEDURE Actualizarusuarios
@CODIGO INT,
@NOMBRE VARCHAR(100),
@CORREOELECTRONICO VARCHAR(100), 
@TELEFONO INT
    AS    
      BEGIN
	    UPDATE Usuarios SET Nombre=@NOMBRE WHERE UsuarioID=@CODIGO 
        UPDATE Usuarios SET CorreoElectronico=@CORREOELECTRONICO WHERE UsuarioID=@CODIGO 
		UPDATE Usuarios SET Telefono=@TELEFONO WHERE UsuarioID=@CODIGO 
	  END
GO

/*En esta parte sirve para consultar usuarios*/

CREATE PROCEDURE Consultausuarios
  AS
    BEGIN
	  SELECT * FROM Usuarios
	END
GO

/*En esta parte es la segunda programacion de consultar usuarios para que funcione correctamente la consulta de usuarios*/

CREATE PROCEDURE Consultausuarios_filtro
@CODIGO INT
  AS
    BEGIN
	  SELECT * FROM Usuarios WHERE UsuarioID = @CODIGO
	END
GO

/*En esta parte sirve para agregar tecnicos*/

CREATE PROCEDURE Agregartecnicos
@NOMBRE VARCHAR(100),
@ESPECIALIDAD VARCHAR(100)
  AS
    BEGIN
	    INSERT INTO Tecnicos (Nombre, Especialidad) VALUES (@NOMBRE, @ESPECIALIDAD)
	END
GO

/*En esta parte sirve para borrar tecnicos*/

CREATE PROCEDURE Borrartecnicos
@CODIGO INT
   AS    
     BEGIN
	     DELETE Tecnicos WHERE TecnicoID =@CODIGO
	 END
GO

/*En esta parte sirve para actualizar los tecnicos*/

CREATE PROCEDURE Actualizartecnicos
@CODIGO INT,
@NOMBRE VARCHAR(100),
@ESPECIALIDAD VARCHAR(100)
    AS    
      BEGIN
	    UPDATE Tecnicos SET Nombre=@NOMBRE WHERE TecnicoID  = @CODIGO
	    UPDATE Tecnicos SET Especialidad=@ESPECIALIDAD WHERE TecnicoID  = @CODIGO
	  END
GO

/*En esta parte sirve para consultar tecnicos*/

CREATE PROCEDURE Consultatecnicos
  AS
    BEGIN
	  SELECT * FROM Tecnicos
	END
GO

/*En esta parte es la segunda programacion de consultar tecnicos para que funcione correctamente la consulta de tecnicos*/

CREATE PROCEDURE Consultatecnicos_filtro
@CODIGO INT
  AS
    BEGIN
	  SELECT * FROM Tecnicos WHERE TecnicoID = @CODIGO
	END
GO

/*En esta parte sirve para agregar las reparaciones*/

CREATE PROCEDURE Agregarreparaciones
@FECHASOLICITUD DATETIME,
@ESTADO VARCHAR(100),
@EQUIPOID INT
  AS
    BEGIN
	    INSERT INTO Reparaciones VALUES (@EQUIPOID, @FECHASOLICITUD, @ESTADO)
	END
GO

/*En esta parte sirve para borrar las reparaciones*/

CREATE PROCEDURE Borrarreparaciones
@CODIGO INT
   AS    
     BEGIN
	     DELETE Reparaciones WHERE ReparacionID =@CODIGO
	 END
GO

/*En esta parte sirve para actualizar las reparaciones*/

CREATE PROCEDURE Actualizarreparaciones
@CODIGO INT,
@FECHASOLICITUD VARCHAR(100),
@ESTADO VARCHAR(100),
@EQUIPOID INT
    AS    
      BEGIN
	    UPDATE Reparaciones SET FechaSolicitud=@FECHASOLICITUD WHERE ReparacionID  = @CODIGO
	    UPDATE Reparaciones SET Estado=@ESTADO WHERE ReparacionID  = @CODIGO
	    UPDATE Reparaciones SET EquipoID=@EQUIPOID WHERE ReparacionID  = @CODIGO
	  END
GO

/*En esta parte sirve para consultar las reparaciones*/

CREATE PROCEDURE Consultarreparaciones
  AS
    BEGIN
	  SELECT * FROM Tecnicos
	END
GO

/*En esta parte es la segunda programacion de consultar reparaciones para que funcione correctamente la consulta de reparaciones*/

CREATE PROCEDURE Consultarreparaciones_filtro
@CODIGO INT
  AS
    BEGIN
	  SELECT * FROM Reparaciones WHERE ReparacionID = @CODIGO
	END
GO

/*En esta parte sirve para agregar los detalles reparacion*/

CREATE PROCEDURE Agregardetallesreparacion
@DESCRIPCION VARCHAR(100),
@FECHAINICIO DATETIME,
@FECHAFIN DATETIME,
@REPARACIONID INT
  AS
    BEGIN
	    INSERT INTO DetallesReparacion VALUES (@REPARACIONID,@DESCRIPCION,@FECHAINICIO,@FECHAFIN)
	END
GO

/*En esta parte sirve para borrar los detalles reparacion*/

CREATE PROCEDURE Borrardetallesreparacion
@CODIGO INT
   AS    
     BEGIN
	     DELETE DetallesReparacion WHERE ReparacionID =@CODIGO
	 END
GO

/*En esta parte sirve para actualizar los detalles reparacion*/

CREATE PROCEDURE Actualizardetallesreparacion
@CODIGO INT,
@DESCRIPCION VARCHAR(100),
@FECHAINICIO VARCHAR(100),
@FECHAFIN VARCHAR(100),
@REPARACIONID INT
    AS    
      BEGIN
	    UPDATE DetallesReparacion SET Descripcion=@DESCRIPCION WHERE DetalleID  = @CODIGO
	    UPDATE DetallesReparacion SET FechaInicio=@FECHAINICIO WHERE DetalleID  = @CODIGO
	    UPDATE DetallesReparacion SET FechaFin=@FECHAFIN WHERE DetalleID  = @CODIGO
	    UPDATE DetallesReparacion SET ReparacionID=@REPARACIONID WHERE DetalleID  = @CODIGO
	  END
GO

/*En esta parte sirve para consultar los detalles reparacion*/

CREATE PROCEDURE Consultardetallesreparacion
  AS
    BEGIN
	  SELECT * FROM DetallesReparacion
	END
GO

/*En esta parte es la segunda programacion de consultar de los detalles reparacion para que funcione correctamente la consulta de los detalles reparacion*/

CREATE PROCEDURE Consultardetallesreparacion_filtro
@CODIGO INT
  AS
    BEGIN
	  SELECT * FROM DetallesReparacion WHERE DetalleID = @CODIGO
	END
GO

/*En esta parte sirve para agregar las asignaciones*/

CREATE PROCEDURE Agregarasignaciones
@FECHAASIGNACION DATETIME,
@REPARACIONID INT,
@TECNICOID INT
  AS
    BEGIN
	    INSERT INTO Asignaciones VALUES (@REPARACIONID,@TECNICOID,@FECHAASIGNACION)
	END
GO

/*En esta parte sirve para borrar las asignaciones*/


CREATE PROCEDURE Borrarasignaciones
@CODIGO INT
   AS    
     BEGIN
	     DELETE Asignaciones WHERE AsignacionID =@CODIGO
	 END
GO

/*En esta parte sirve para actualizar las asignaciones*/

CREATE PROCEDURE Actualizarasignaciones
@CODIGO INT,
@FECHAASIGNACION VARCHAR(100),
@REPARACIONID INT,
@TECNICOID INT
    AS    
      BEGIN
	    UPDATE Asignaciones SET FechaAsignacion=@FECHAASIGNACION WHERE AsignacionID  = @CODIGO
	    UPDATE Asignaciones SET ReparacionID=@REPARACIONID WHERE AsignacionID  = @CODIGO
	    UPDATE Asignaciones SET TecnicoID=@TECNICOID WHERE AsignacionID  = @CODIGO
	  END
GO

/*En esta parte sirve para consultar las asignaciones*/

CREATE PROCEDURE Consultarasignaciones
  AS
    BEGIN
	  SELECT * FROM Asignaciones
	END
GO

/*En esta parte es la segunda programacion de consultar de las asignaciones para que funcione correctamente la consulta de las asignaciones*/

CREATE PROCEDURE Consultarasignaciones_filtro
@CODIGO INT
  AS
    BEGIN
	  SELECT * FROM Asignaciones WHERE AsignacionID = @CODIGO
	END
GO


/*En esta parte sirve para consultar las reporteequipos*/

CREATE PROCEDURE Consultarreportequipos
  AS
    BEGIN
	  SELECT * FROM Reporteequipos
	END
GO

/*En esta parte es la segunda programacion de consultar reparaciones para que funcione correctamente la consulta de reporteequipos*/

CREATE PROCEDURE Consultarreporteequipos_filtro
@CODIGO INT
  AS
    BEGIN
	  SELECT * FROM Reporteequipos WHERE EquipoID = @CODIGO
		END
    GO

/*En esta parte tiene la funcion guardar el correo, la clave y el nombre de una persona*/

CREATE PROCEDURE Validapersona
@Correo varchar(60),
@Clave varchar(60)

AS
BEGIN
    SELECT Correo, Clave, Nombre FROM PERSONA WHERE CORREO = @Correo AND CLAVE= @Clave
END
GO

/*En esta parte se agrega un primer equipo nuevo*/

INSERT INTO Equipos (TipoEquipo, Modelo, UsuarioID) VALUES ('EQUIPO DE SOFTWARE','PROLIANT',33)
GO

/*En esta parte se agrega un segundo equipo nuevo*/

INSERT INTO Equipos (TipoEquipo, Modelo, UsuarioID) VALUES ('EQUIPO DE HARDWARE','HP',77)
GO

/*En esta parte se agrega un tercer equipo nuevo*/

INSERT INTO Equipos (TipoEquipo, Modelo, UsuarioID) VALUES ('EQUIPO DE FIRMWARE','DELL',41)
GO

/*En esta parte se agrega un cuarto equipo nuevo*/

INSERT INTO Equipos (TipoEquipo, Modelo, UsuarioID) VALUES ('EQUIPO DE ROBOTICA','PowerEdge',22)
GO

/*En esta parte se agrega un primer usuario nuevo*/

INSERT INTO Usuarios (Nombre, CorreoElectronico, Telefono) VALUES ('MARIO ZAMORA','MarioZam@gmail.com',23213432)
GO

/*En esta parte se agrega un segundo usuario nuevo*/

INSERT INTO Usuarios  (Nombre, CorreoElectronico, Telefono) VALUES ('ALEXIS BERRIOS','Alexis@gmail.com',54345676)
GO

/*En esta parte se agrega un tercer usuario nuevo*/

INSERT INTO Usuarios  (Nombre, CorreoElectronico, Telefono) VALUES ('ADRIAN SALGADO','Adrian@gmail.com',90653211)
GO

/*En esta parte se agreganun cuarto usuario nuevo*/

INSERT INTO Usuarios (Nombre, CorreoElectronico, Telefono) VALUES ('MARIANA GUTIERREZ','Mariana@gmail.com',55443211)
GO

/*En esta parte se agrega un primer tecnico nuevo*/

INSERT INTO Tecnicos (Nombre, Especialidad) VALUES ('JAVIER RAMIREZ','TECNICO DE SOFTWARE')
GO

/*En esta parte se agrega un segundo tecnico nuevo*/

INSERT INTO Tecnicos (Nombre, Especialidad) VALUES ('FERNADO ORTEGA','TECNICO DE HARDWARE')
GO

/*En esta parte se agrega un tercer tecnico nuevo*/

INSERT INTO Tecnicos (Nombre, Especialidad) VALUES ('ALISON GUTIERREZ','TECNICO DE ARDUINOS')
GO

/*En esta parte se agrega un cuarto tecnico nuevo*/

INSERT INTO Tecnicos (Nombre, Especialidad) VALUES ('BELINDA MONGE','TECNICO DE ROBOTICA')
GO

/*En esta parte se agrega una primer reparacion nueva*/

INSERT INTO Reparaciones (EquipoID, FechaSolicitud, Estado) VALUES (1,'06-06-2023','A')
GO

/*En esta parte se agrega una segunda reparacion nueva*/

INSERT INTO Reparaciones (EquipoID, FechaSolicitud, Estado) VALUES (2,'09-12-2023','A')
GO

/*En esta parte se agrega una tercer reparacion nueva*/

INSERT INTO Reparaciones (EquipoID, FechaSolicitud, Estado) VALUES (3,'10-12-2023','A')
GO

/*En esta parte se agrega una cuarta reparacion nueva*/

INSERT INTO Reparaciones (EquipoID, FechaSolicitud, Estado) VALUES (4,'11-12-2023','A')
GO

/*En esta parte se agrega un primer detallereparacion nuevo*/

INSERT INTO DetallesReparacion (ReparacionID, Descripcion, FechaInicio, FechaFin) VALUES (1,'REPARAR EL BIOS DE LA COMPUTADORA CAMILA MUÑOZ','06-05-2023',GETDATE())
GO

/*En esta parte se agrega un segundo detallereparacion nuevo*/

INSERT INTO DetallesReparacion (ReparacionID, Descripcion, FechaInicio, FechaFin) VALUES (2,'REPARAR EL CELULAR DE MADISON LOPEZ','11-11-2023',GETDATE())
GO

/*En esta parte se agrega un tercer detallereparacion nuevo*/

INSERT INTO DetallesReparacion (ReparacionID, Descripcion, FechaInicio,FechaFin) VALUES (3,'REPARAR LA TABLE DE ALISON RAMIREZ','11-11-2023',GETDATE())
GO

/*En esta parte se un cuarto detallereparacion nuevo*/

INSERT INTO DetallesReparacion (ReparacionID, Descripcion, FechaInicio, FechaFin) VALUES (4,'REPARAR LA COMPUTADORA DE BRENDA NUÑES','02-12-2023',GETDATE())
GO

/*En esta parte se una primer asignacion nueva*/

INSERT INTO Asignaciones (ReparacionID, TecnicoID, FechaAsignacion) VALUES (1,1,'08-04-2023')
GO

/*En esta parte se una segunda asignacion nueva*/

INSERT INTO Asignaciones (ReparacionID, TecnicoID, FechaAsignacion) VALUES (2,2,'09-06-2023')
GO

/*En esta parte se una tercer asignacion nueva*/

INSERT INTO Asignaciones (ReparacionID, TecnicoID, FechaAsignacion) VALUES (3,3,'03-11-2023')
GO

/*En esta parte se una cuarta asignacion nueva*/

INSERT INTO Asignaciones (ReparacionID, TecnicoID, FechaAsignacion) VALUES (4,4,'05-12-2023')
GO

/*En esta parte se agrega la primer informacion de la tabla primer reporteequipos*/

INSERT INTO Reporteequipos (Nombre, AsignacionID, FechaAsignacion, ReparacionID, FechaSolicitud, Estado, Descripcion, TipoEquipo, Modelo, Nombre1, CorreoElectronico) VALUES ('JAVIER RAMIREZ',120,GETDATE(),2,GETDATE(),'A','REPARAR EL BIOS DE LA COMPUTADORA CAMILA MUÑOZ','EQUIPO DE SOFTWARE','PROLIANT','MARIO ZAMORA','MarioZam@gmail.com')
GO

/*En esta parte se agrega la segunda informacion de la tabla segundo reporteequipos*/

INSERT INTO Reporteequipos (Nombre, AsignacionID, FechaAsignacion, ReparacionID, FechaSolicitud, Estado, Descripcion, TipoEquipo, Modelo, Nombre1, CorreoElectronico) VALUES ('FERNADO ORTEGA',155,GETDATE(),2,GETDATE(),'A','REPARAR EL CELULAR DE MADISON LOPEZ','EQUIPO DE HARDWARE','HP','ALEXIS BERRIOS','Alexis@gmail.com')
GO

/*En esta parte se agrega la tercer informacion de la tabla tercer reporteequipos*/

INSERT INTO Reporteequipos (Nombre, AsignacionID, FechaAsignacion, ReparacionID, FechaSolicitud, Estado, Descripcion, TipoEquipo, Modelo, Nombre1, CorreoElectronico) VALUES ('ALISON GUTIERREZ',199,GETDATE(),2,GETDATE(),'A','REPARAR LA TABLE DE ALISON RAMIREZ','EQUIPO DE FIRMWARE','DELL','ADRIAN SALGADO','Adrian@gmail.com')
GO

/*En esta parte se agrega la cuarta informacion de la tabla cuarto reporteequipos*/

INSERT INTO Reporteequipos (Nombre, AsignacionID, FechaAsignacion, ReparacionID, FechaSolicitud, Estado, Descripcion, TipoEquipo, Modelo, Nombre1, CorreoElectronico) VALUES ('BELINDA MONGE',1,GETDATE(),2,GETDATE(),'A','REPARAR LA COMPUTADORA DE BRENDA NUÑES','EQUIPO DE ROBOTICA','PowerEdge','MARIANA GUTIERREZ','Mariana@gmail.com')
GO

/*En esta parte se muestran los correos, las claves y los nombres de las personas donde al meter el correo y la clave en la pagina de C# se podra acceder a la pagina de C#*/

SELECT Correo, Clave, Nombre, idrol, descripcion FROM Persona
GO

/*En esta parte se muestran los datos digitadps de la tabla equipos*/

SELECT * FROM Equipos 
GO

/*En esta parte se muestran los datos digitadps de la tabla usuarios*/

SELECT * FROM Usuarios 
GO

/*En esta parte se muestran los datos digitadps de la tabla tecnicos*/

SELECT * FROM Tecnicos 
GO

/*En esta parte se muestran los datos digitadps de la tabla reparaciones*/

SELECT * FROM Reparaciones 
GO

/*En esta parte se muestran los datos digitadps de la tabla detallesreparacion*/

SELECT * FROM DetallesReparacion 
GO

/*En esta parte se muestran los datos digitadps de la tabla asignaciones*/

SELECT * FROM Asignaciones 
GO

/*En esta parte se muestran los datos digitadps de la tabla reporteequipos*/

SELECT * FROM Reporteequipos 
GO

























