--PROCEDIMIENTOS ALAMACENADOS 

--PRESENTACION
-------------------------------------------------------------------
--MOSTRAR PRESENTACION
CREATE PROC SP_MOSTRAR_PRESENTACION
AS 
SELECT TOP 200 * FROM PRESENTACION
ORDER BY [ID_Presentacion] DESC 
GO

--BUSQUEDA PRESENTACION
CREATE PROC SP_BUSCAR_PRESENTACION
@BusquedaTexto VARCHAR(60)
AS 
SELECT * FROM PRESENTACION
WHERE [Nombre_Presentacion] LIKE @BusquedaTexto + '%'
GO

--INSERTAR PRESENTACION
CREATE PROC SP_INSERTAR_PRESENTACION
@idpresentacion INT OUTPUT,
@nombre VARCHAR(60),
@descripcion VARCHAR(1024)
AS
INSERT INTO PRESENTACION([Nombre_Presentacion],[Descripcion_Presentacion])
VALUES (@nombre, @descripcion)
GO

--EDITAR PRESENTACION
CREATE PROC SP_EDITAR_PRESENTACION
@idpresentacion INT,
@nombre VARCHAR(60),
@descripcion VARCHAR(1024)
AS
UPDATE PRESENTACION SET [Nombre_Presentacion]= @nombre, [Descripcion_Presentacion]= @descripcion
WHERE [ID_Presentacion]= @idpresentacion
GO