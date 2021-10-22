--PROCEDIMIENTOS ALAMACENADOS 
--INGRESO
-------------------------------------------------------------------
--INSERTAR DETALLE INGRESO
CREATE PROC SP_INSERTAR_DETALLE_INGRESO
@iddetallle_ingreso INT OUTPUT,
@articuloID INT,
@ingresoID INT,
@precioCompra MONEY,
@stockIngreso INT,
@stockActual INT,
@fechaProduccion DATE,
@fechaVencimiento DATE
AS
INSERT INTO DETALLE_INGRESO ([Art_ID],[Ingreso_ID],[Precio_Compra],[Stock_Ingreso],[Stock_Actual],[Fecha_Produccion],[Fecha_Vencimiento]) 
VALUES (@articuloID, @ingresoID, @precioCompra, @stockIngreso, @stockActual, @fechaProduccion, @fechaVencimiento)
GO

--MOSTRAR DETALLE INGRESO
CREATE PROC SP_MOSTRAR_DETALLE_INGRESO
@BusquedaTexto INT
AS
SELECT dbo.ARTICULO.ID_Art, dbo.ARTICULO.Nombre_Art AS 'Articulo', dbo.DETALLE_INGRESO.Precio_Compra, dbo.DETALLE_INGRESO.Stock_Ingreso, dbo.DETALLE_INGRESO.Fecha_Produccion,
dbo.DETALLE_INGRESO.Fecha_Vencimiento, (dbo.DETALLE_INGRESO.Precio_Compra * dbo.DETALLE_INGRESO.Stock_Ingreso) AS 'SubTotal'
FROM    
dbo.ARTICULO INNER JOIN
dbo.DETALLE_INGRESO ON dbo.ARTICULO.ID_Art = dbo.DETALLE_INGRESO.Art_ID INNER JOIN
dbo.INGRESO ON dbo.DETALLE_INGRESO.Ingreso_ID = dbo.INGRESO.ID_Ingreso
WHERE [ID_Ingreso] = @BusquedaTexto
GO
