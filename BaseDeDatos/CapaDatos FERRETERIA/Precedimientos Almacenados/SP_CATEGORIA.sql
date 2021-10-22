--PROCEDIMIENTOS ALAMACENADOS 

--CATEGORIA
-------------------------------------------------------------------
--MOSTRAR CATEGORIAS 
CREATE PROC SP_MOSTRAR_CATEGORIA 
AS 
SELECT TOP 200 * FROM CATEGORIA 
ORDER BY [ID_Categoria] DESC 
GO

--BUSQUEDA CATEGORIAS
CREATE PROC SP_BUSCAR_CATEGORIA 
@BusquedaTexto VARCHAR(60)
AS 
SELECT * FROM CATEGORIA
WHERE [Nombre_Categoria] LIKE @BusquedaTexto + '%'
GO

--INSERTAR CATEGORIAS
CREATE PROC SP_INSERTAR_CATEGORIA
@idcategoria INT OUTPUT,
@nombre VARCHAR(60),
@descripcion VARCHAR(1024)
AS
INSERT INTO CATEGORIA ([Nombre_Categoria],[Descripcion_Categoria])
VALUES (@nombre, @descripcion)
GO

--EDITAR CATEGORIAS
CREATE PROC SP_EDITAR_CATEGORIA
@idcategoria INT,
@nombre VARCHAR(60),
@descripcion VARCHAR(1024)
AS
UPDATE CATEGORIA SET [Nombre_Categoria]= @nombre, [Descripcion_Categoria]= @descripcion
WHERE [ID_Categoria]= @idcategoria
GO