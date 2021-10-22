--PROCEDIMIENTOS ALAMACENADOS 
--PROVEEDOR
-------------------------------------------------------------------
--MOSTRAR PROVEEDOR
CREATE PROC SP_PROVEEDOR
AS
SELECT TOP 100 * FROM PROVEEDOR
ORDER BY [ID_Proveedor] DESC
GO

--BUSQUEDA PROVEEDOR
CREATE PROC SP_BUSCAR_PROVEEDOR
@BusquedaTexto VARCHAR(30)
AS
SELECT * FROM PROVEEDOR
WHERE [Razon_Social] LIKE @BusquedaTexto + '%'
GO

--INSERTAR PROVEEDOR
CREATE PROC SP_INSERTAR_PROVEEDOR 
@idproveedor INT OUTPUT,
@razon_Social VARCHAR(30),
@sector_Comercial VARCHAR(30),
@tipo_Documento VARCHAR(20),
@direccion VARCHAR(100),
@telefono VARCHAR(8),
@email VARCHAR(60),
@url VARCHAR(1024)
AS
INSERT INTO
PROVEEDOR([Razon_Social],[Sector_Comercial],[Tipo_Documento],[Direccion_P],[Telefono_P],[Email_P],[url])
VALUES (@razon_Social,@sector_Comercial,@tipo_Documento,@direccion,@telefono,@email,@url)
GO

--EDITAR PROVEEDOR
CREATE PROC SP_EDITAR_PROVEEDOR
@idproveedor INT,
@razon_Social VARCHAR(30),
@sector_comercial VARCHAR(30),
@tipo_documento VARCHAR(20),
@direccion VARCHAR(100),
@telefono VARCHAR(8),
@email VARCHAR(60),
@url VARCHAR(1024)
AS
UPDATE PROVEEDOR SET [Razon_Social]=@razon_Social, [Sector_Comercial]=@sector_Comercial, [Tipo_Documento]=@tipo_documento, [Direccion_P]=@direccion,
[Telefono_P]=@telefono,[Email_P]=@email,[url]=@url
WHERE [ID_Proveedor]=@idproveedor
GO