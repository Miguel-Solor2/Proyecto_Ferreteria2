--PROCEDIMIENTOS ALAMACENADOS 
--DETALLE VENTA
-------------------------------------------------------------------
--INSERTAR DETALLE DE VENTA
CREATE PROC SP_INSERTAR_DETALLE_VENTA
@iddetalle_venta INT OUTPUT,
@idventa INT,
@iddetalle_ingreso INT,
@cantidad INT,
@precio_venta MONEY,
@descuento MONEY
AS
INSERT INTO DETALLE_VENTA ([Venta_ID],[Detalle_IngresoID],[Cantidad],[Precio_Venta],[Descuento])
VALUES (@idventa,@iddetalle_ingreso,@cantidad,@precio_venta,@descuento)
GO

--DISMINUIR STOCK
CREATE PROC SP_DISMINUIR_STOCK
@iddetalle_venta INT,
@cantidad INT
AS
UPDATE DETALLE_INGRESO SET [Stock_Actual] = [Stock_Actual] - @cantidad 
WHERE [IDDetalle_Ingreso] =@iddetalle_venta 
GO

--MOSTRAR LOS DETALLES DE UNA VENTA
CREATE PROC SP_MOSTRAR_DETALLE_VENTA 
@BusquedaTexto VARCHAR(20)
AS
SELECT dbo.DETALLE_INGRESO.IDDetalle_Ingreso, dbo.ARTICULO.Nombre_Art AS 'Articulo',
dbo.DETALLE_VENTA.Cantidad, dbo.DETALLE_VENTA.Precio_Venta, dbo.DETALLE_VENTA.Descuento, 
SUM((dbo.DETALLE_VENTA.Cantidad * dbo.DETALLE_VENTA.Precio_Venta)-dbo.DETALLE_VENTA.Descuento) AS 'SubTotal'
FROM     
dbo.ARTICULO INNER JOIN
dbo.DETALLE_INGRESO ON dbo.ARTICULO.ID_Art = dbo.DETALLE_INGRESO.Art_ID INNER JOIN
dbo.DETALLE_VENTA ON dbo.DETALLE_INGRESO.IDDetalle_Ingreso = dbo.DETALLE_VENTA.Detalle_IngresoID