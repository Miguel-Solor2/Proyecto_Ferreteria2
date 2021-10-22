--PROCEDIMIENTOS ALAMACENADOS 
--VENTAS
-------------------------------------------------------------------
--MOSTRAR VENTA
CREATE PROC SP_MOSTRAR_VENTA
AS
SELECT TOP 100 dbo.VENTA.ID_Venta, (dbo.TRABAJADOR.Nombre_Trabajador+' '+dbo.TRABAJADOR.Apellido_Trabajador) AS 'Trabajador',
(dbo.CLIENTE.Nombre_Cliente+' '+dbo.CLIENTE.Apellido_Cliente) AS 'Cliente', dbo.VENTA.Fecha_Venta, dbo.VENTA.Tipo_Comprobante, 
dbo.VENTA.Serie, SUM((dbo.DETALLE_VENTA.Cantidad * dbo.DETALLE_VENTA.Precio_Venta)-dbo.DETALLE_VENTA.Descuento) AS 'Total'
FROM     
dbo.CLIENTE INNER JOIN
dbo.VENTA ON dbo.CLIENTE.ID_Cliente = dbo.VENTA.Cliente_ID INNER JOIN
dbo.USUARIO ON dbo.VENTA.Usuario_ID = dbo.USUARIO.ID_Usuario INNER JOIN
dbo.TRABAJADOR ON dbo.USUARIO.Trabajador_ID = dbo.TRABAJADOR.ID_Trabajador INNER JOIN
dbo.DETALLE_VENTA ON dbo.VENTA.ID_Venta = dbo.DETALLE_VENTA.Venta_ID
GROUP BY 
dbo.VENTA.ID_Venta, (dbo.TRABAJADOR.Nombre_Trabajador+' '+dbo.TRABAJADOR.Apellido_Trabajador),
(dbo.CLIENTE.Nombre_Cliente+' '+dbo.CLIENTE.Apellido_Cliente), dbo.VENTA.Fecha_Venta, dbo.VENTA.Tipo_Comprobante, 
dbo.VENTA.Serie
ORDER BY 
dbo.VENTA.ID_Venta
DESC
GO 

--BUSCAR VENTA
CREATE PROC SP_BUSCAR_VENTA
@BusquedaTexto VARCHAR(20),
@BusquedaTexto2 VARCHAR(20)
AS 
SELECT TOP 100 dbo.VENTA.ID_Venta, (dbo.TRABAJADOR.Nombre_Trabajador+' '+dbo.TRABAJADOR.Apellido_Trabajador) AS 'Trabajador',
(dbo.CLIENTE.Nombre_Cliente+' '+dbo.CLIENTE.Apellido_Cliente) AS 'Cliente', dbo.VENTA.Fecha_Venta, dbo.VENTA.Tipo_Comprobante, 
dbo.VENTA.Serie, SUM((dbo.DETALLE_VENTA.Cantidad * dbo.DETALLE_VENTA.Precio_Venta)-dbo.DETALLE_VENTA.Descuento) AS 'Total'
FROM     
dbo.CLIENTE INNER JOIN
dbo.VENTA ON dbo.CLIENTE.ID_Cliente = dbo.VENTA.Cliente_ID INNER JOIN
dbo.USUARIO ON dbo.VENTA.Usuario_ID = dbo.USUARIO.ID_Usuario INNER JOIN
dbo.TRABAJADOR ON dbo.USUARIO.Trabajador_ID = dbo.TRABAJADOR.ID_Trabajador INNER JOIN
dbo.DETALLE_VENTA ON dbo.VENTA.ID_Venta = dbo.DETALLE_VENTA.Venta_ID
GROUP BY 
dbo.VENTA.ID_Venta, (dbo.TRABAJADOR.Nombre_Trabajador+' '+dbo.TRABAJADOR.Apellido_Trabajador),
(dbo.CLIENTE.Nombre_Cliente+' '+dbo.CLIENTE.Apellido_Cliente), dbo.VENTA.Fecha_Venta, dbo.VENTA.Tipo_Comprobante, 
dbo.VENTA.Serie
HAVING
dbo.VENTA.Fecha_Venta>= @BusquedaTexto AND dbo.VENTA.Fecha_Venta<= @BusquedaTexto2 
GO

--INSERTAR VENTA
CREATE PROC SP_INSERTAR_VENTA
@idventa INT = NULL OUTPUT,
@clienteID INT,
@usuarioID INT,
@fecha_venta DATE,
@tipoComprobante VARCHAR(20),
@serie VARCHAR(10),
@isv DECIMAL(4,2)
AS
INSERT INTO VENTA ([Cliente_ID],[Usuario_ID],[Fecha_Venta],[Tipo_Comprobante],[Serie],[ISV])
VALUES (@clienteID,@usuarioID,@fecha_venta,@tipoComprobante,@serie,@isv)
SET @idventa = @@IDENTITY
GO