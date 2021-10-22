--PROCEDIMIENTOS ALAMACENADOS 
--ARTICULO 
-------------------------------------------------------------------
--MOSTRAR ARTICULO
CREATE PROC SP_MOSTRAR_ARTICULO
AS 
SELECT TOP 100
dbo.ARTICULO.ID_Art, dbo.ARTICULO.Nombre_Art, dbo.ARTICULO.Descripcion_Art, dbo.ARTICULO.Imagen,
dbo.ARTICULO.Categoria_ID, dbo.CATEGORIA.Nombre_Categoria, dbo.ARTICULO.Presentacion_ID, 
dbo.PRESENTACION.Nombre_Presentacion
FROM     
dbo.CATEGORIA INNER JOIN
dbo.ARTICULO ON dbo.CATEGORIA.ID_Categoria = dbo.ARTICULO.Categoria_ID INNER JOIN
dbo.PRESENTACION ON dbo.ARTICULO.Presentacion_ID = dbo.PRESENTACION.ID_Presentacion
ORDER BY dbo.ARTICULO.ID_Art DESC 
GO

--BUSQUEDA ARTICULO
CREATE PROC SP_BUSCAR_ARTICULO
@BusquedaTexto VARCHAR(60)
AS 
SELECT 
dbo.ARTICULO.ID_Art, dbo.ARTICULO.Nombre_Art, dbo.ARTICULO.Descripcion_Art, dbo.ARTICULO.Imagen,
dbo.ARTICULO.Categoria_ID, dbo.CATEGORIA.Nombre_Categoria, dbo.ARTICULO.Presentacion_ID, 
dbo.PRESENTACION.Nombre_Presentacion
FROM     
dbo.CATEGORIA INNER JOIN
dbo.ARTICULO ON dbo.CATEGORIA.ID_Categoria = dbo.ARTICULO.Categoria_ID INNER JOIN
dbo.PRESENTACION ON dbo.ARTICULO.Presentacion_ID = dbo.PRESENTACION.ID_Presentacion
WHERE dbo.ARTICULO.Nombre_Art LIKE @BusquedaTexto + '%'
ORDER BY dbo.ARTICULO.ID_Art DESC
GO

--INSERTAR ARTICULO
CREATE PROC SP_INSERTAR_ART
@idart INT OUTPUT,
@categoriaID INT,
@presentacionID INT,
@nombre VARCHAR(60),
@descripcion VARCHAR(1024),
@imagen IMAGE
AS
INSERT INTO
ARTICULO([Categoria_ID],[Presentacion_ID],[Nombre_Art],[Descripcion_Art],[Imagen])
VALUES (@categoriaID,@presentacionID,@nombre,@descripcion,@imagen)
GO

--EDITAR ARTICULO
CREATE PROC SP_EDITAR_ART
@idart INT,
@categoriaID INT,
@presentacionID INT,
@nombre VARCHAR(60),
@descripcion VARCHAR(1024),
@imagen IMAGE
AS
UPDATE ARTICULO SET [Categoria_ID]=@categoriaID, [Presentacion_ID]=@presentacionID, [Nombre_Art]=@nombre, [Descripcion_Art]=@descripcion,
[Imagen]=@imagen
WHERE [ID_Art]=@idart
GO
