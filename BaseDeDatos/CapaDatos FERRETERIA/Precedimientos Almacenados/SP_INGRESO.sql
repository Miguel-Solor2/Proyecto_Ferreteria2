--PROCEDIMIENTOS ALAMACENADOS 
--INGRESO
-------------------------------------------------------------------
--MOSTRAR INGRESO
CREATE PROC SP_MOSTRAR_INGRESO
AS 
SELECT TOP 100 dbo.INGRESO.ID_Ingreso, (dbo.TRABAJADOR.Nombre_Trabajador+' '+
dbo.TRABAJADOR.Apellido_Trabajador) AS 'Nombre Trabajador', dbo.USUARIO.Usuario, dbo.PROVEEDOR.Razon_Social AS 'Proveedor',
dbo.INGRESO.Fecha_Ingreso, dbo.INGRESO.Tipo_Comprobante, dbo.INGRESO.Serie, dbo.INGRESO.Estado,SUM( 
dbo.DETALLE_INGRESO.Precio_Compra * dbo.DETALLE_INGRESO.Stock_Ingreso) AS 'Total'
FROM     
dbo.INGRESO INNER JOIN 
dbo.USUARIO ON dbo.INGRESO.Usuario_ID = dbo.USUARIO.ID_Usuario INNER JOIN
dbo.TRABAJADOR ON dbo.USUARIO.Trabajador_ID = dbo.TRABAJADOR.ID_Trabajador INNER JOIN
dbo.PROVEEDOR ON dbo.INGRESO.Proveedor_ID = dbo.PROVEEDOR.ID_Proveedor INNER JOIN
dbo.DETALLE_INGRESO ON dbo.INGRESO.ID_Ingreso = dbo.DETALLE_INGRESO.Ingreso_ID
GROUP BY
dbo.INGRESO.ID_Ingreso, (dbo.TRABAJADOR.Nombre_Trabajador+' '+
dbo.TRABAJADOR.Apellido_Trabajador), dbo.USUARIO.Usuario, dbo.PROVEEDOR.Razon_Social,
dbo.INGRESO.Fecha_Ingreso, dbo.INGRESO.Tipo_Comprobante, dbo.INGRESO.Serie, dbo.INGRESO.Estado
ORDER BY dbo.INGRESO.ID_Ingreso DESC
GO

--BUSQUEDA INGRESO
CREATE PROC SP_BUSCAR_INGRESO
@BusquedaTexto VARCHAR(20),
@BusquedaTexto2 VARCHAR(20)
AS 
SELECT dbo.INGRESO.ID_Ingreso, (dbo.TRABAJADOR.Nombre_Trabajador+' '+
dbo.TRABAJADOR.Apellido_Trabajador) AS 'Nombre Trabajador', dbo.USUARIO.Usuario, dbo.PROVEEDOR.Razon_Social AS 'Proveedor',
dbo.INGRESO.Fecha_Ingreso, dbo.INGRESO.Tipo_Comprobante, dbo.INGRESO.Serie, dbo.INGRESO.Estado,SUM( 
dbo.DETALLE_INGRESO.Precio_Compra * dbo.DETALLE_INGRESO.Stock_Ingreso) AS 'Total'
FROM     
dbo.INGRESO INNER JOIN 
dbo.USUARIO ON dbo.INGRESO.Usuario_ID = dbo.USUARIO.ID_Usuario INNER JOIN
dbo.TRABAJADOR ON dbo.USUARIO.Trabajador_ID = dbo.TRABAJADOR.ID_Trabajador INNER JOIN
dbo.PROVEEDOR ON dbo.INGRESO.Proveedor_ID = dbo.PROVEEDOR.ID_Proveedor INNER JOIN
dbo.DETALLE_INGRESO ON dbo.INGRESO.ID_Ingreso = dbo.DETALLE_INGRESO.Ingreso_ID
GROUP BY
dbo.INGRESO.ID_Ingreso, (dbo.TRABAJADOR.Nombre_Trabajador+' '+
dbo.TRABAJADOR.Apellido_Trabajador), dbo.USUARIO.Usuario, dbo.PROVEEDOR.Razon_Social,
dbo.INGRESO.Fecha_Ingreso, dbo.INGRESO.Tipo_Comprobante, dbo.INGRESO.Serie, dbo.INGRESO.Estado
HAVING 
dbo.INGRESO.Fecha_Ingreso>= @BusquedaTexto  AND dbo.INGRESO.Fecha_Ingreso<= @BusquedaTexto2 
GO

--INSERTAR INGRESO
CREATE PROC SP_INSERTAR_INGRESO
@idingreso INT OUTPUT,
@proveedorID INT,
@usuarioID INT,
@fecha_ingreso DATE,
@tipoComprobante VARCHAR(20),
@serie VARCHAR(10),
@iva DECIMAL(4,2),
@estado VARCHAR(10)
AS
INSERT INTO INGRESO ([Proveedor_ID],[Usuario_ID],[Fecha_Ingreso],[Tipo_Comprobante],[Serie],[IVA],[Estado]) 
VALUES (@proveedorID,@usuarioID,@fecha_ingreso,@tipoComprobante,@serie,@iva,@estado)
SET @idingreso = @@IDENTITY
GO

--ANULAR INGRESO
CREATE PROC SP_EDITAR_INGRESO
@idingreso INT
AS
UPDATE INGRESO SET [Estado]= 'ANULADO'
WHERE ID_Ingreso = @idingreso
GO




