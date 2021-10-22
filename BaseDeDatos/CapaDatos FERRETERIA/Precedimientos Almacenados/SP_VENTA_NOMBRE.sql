--PROCEDIMIENTOS ALAMACENADOS 
--VENTA NOMBRE
-------------------------------------------------------------------
--VENTA NOMBRE
CREATE PROC SP_VENTA_NOMBRE_ARTICULO
@BusquedaTexto VARCHAR(60)
AS
SELECT dbo.DETALLE_INGRESO.IDDetalle_Ingreso, dbo.ARTICULO.ID_Art, dbo.ARTICULO.Nombre_Art, dbo.CATEGORIA.Nombre_Categoria AS 'Categoria', 
	   dbo.PRESENTACION.Nombre_Presentacion AS 'Presentacion', dbo.DETALLE_INGRESO.Stock_Actual, 
       dbo.DETALLE_INGRESO.Precio_Compra, dbo.DETALLE_VENTA.Precio_Venta, dbo.DETALLE_INGRESO.Fecha_Vencimiento
FROM     
       dbo.DETALLE_INGRESO INNER JOIN
       dbo.ARTICULO ON dbo.DETALLE_INGRESO.Art_ID = dbo.ARTICULO.ID_Art INNER JOIN
       dbo.CATEGORIA ON dbo.ARTICULO.Categoria_ID = dbo.CATEGORIA.ID_Categoria INNER JOIN
       dbo.PRESENTACION ON dbo.ARTICULO.Presentacion_ID = dbo.PRESENTACION.ID_Presentacion INNER JOIN
       dbo.DETALLE_VENTA ON dbo.DETALLE_INGRESO.IDDetalle_Ingreso = dbo.DETALLE_VENTA.Detalle_IngresoID INNER JOIN
       dbo.INGRESO ON dbo.DETALLE_INGRESO.Ingreso_ID = dbo.INGRESO.ID_Ingreso
	   WHERE dbo.ARTICULO.Nombre_Art LIKE @BusquedaTexto + '%' AND dbo.DETALLE_INGRESO.Stock_Actual > 0 AND dbo.INGRESO.Estado <> 'ANULADO'
	   GO

