--PROCEDIMIENTOS ALAMACENADOS 
--TRABAJADORES
-------------------------------------------------------------------
--MOSTRAR TRABAJADOR
CREATE PROC SP_MOSTRAR_TRABAJADOR
AS
SELECT TOP 100 * FROM TRABAJADOR
ORDER BY [ID_Trabajador] DESC
GO

--BUSQUEDA TRABAJADOR
CREATE PROC SP_BUSCAR_TRABAJADOR
@BusquedaTexto VARCHAR(60)
AS
SELECT * FROM TRABAJADOR
WHERE [Apellido_Trabajador] LIKE @BusquedaTexto + '%'
GO

--INSERTAR TRABAJADOR
CREATE PROC SP_INSERTAR_TRABAJADOR 
@idtrabajador INT OUTPUT,
@nombre_trabajador VARCHAR(30),
@apellido_trabajador VARCHAR(30),
@fecha_nacimiento DATE,
@genero VARCHAR(2),
@tipo_Documento VARCHAR(20),
@direccion VARCHAR(100),
@telefono VARCHAR(8),
@email VARCHAR(60)
AS
INSERT INTO TRABAJADOR([Nombre_Trabajador],[Apellido_Trabajador],[Fecha_Nacimiento],[Genero],[Tipo_Documento],[Direccion_T],[Telefono_T],[Email_T])
VALUES (@nombre_trabajador, @apellido_trabajador, @fecha_nacimiento, @genero, @tipo_Documento, @direccion, @telefono, @email)
GO

--EDITAR TRABAJADOR
CREATE PROC SP_EDITAR_TRABAJADOR 
@idtrabajador INT,
@nombre_trabajador VARCHAR(30),
@apellido_trabajador VARCHAR(30),
@fecha_nacimiento DATE,
@genero VARCHAR(2),
@tipo_Documento VARCHAR(20),
@direccion VARCHAR(100),
@telefono VARCHAR(8),
@email VARCHAR(60)
AS
UPDATE TRABAJADOR SET [Nombre_Trabajador]=@nombre_trabajador,[Apellido_Trabajador]=@apellido_trabajador,[Fecha_Nacimiento]=@fecha_nacimiento,
[Genero]=@genero,[Tipo_Documento]=@tipo_Documento,[Direccion_T]=@direccion,[Telefono_T]=@telefono,[Email_T]=@email
WHERE [ID_Trabajador] = @idtrabajador
GO


-----------VERIFICACION DE CORREO
CREATE PROC SP_VALIDARCORREO 
@email VARCHAR(60)
AS
SELECT * FROM TRABAJADOR WHERE [Email_T]=@email 

SELECT * FROM TRABAJADOR
SELECT * FROM USUARIO
UPDATE TRABAJADOR SET Email_T = 'miguelsolorzano773@gmail.com' WHERE ID_Trabajador = 2