INSERT INTO PRESENTACION(Nombre_Presentacion, Descripcion_Presentacion) VALUES ('Bolsa Pequeña','Bolsa pequeña normal');

INSERT INTO CATEGORIA(Nombre_Categoria, Descripcion_Categoria) VALUES ('Construccion','Bueno, es para construir');

INSERT INTO ARTICULO(Categoria_ID, Presentacion_ID, Nombre_Art, Descripcion_Art) VALUES (1,1,'Tornillos','Tornillos 7cm');

INSERT INTO PROVEEDOR(Razon_Social,Sector_Comercial,Tipo_Documento,Direccion_P,Telefono_P,Email_P,url,N_Documento) 
VALUES ('UNICAH','MISERIA','DNI','Calle hacia la Concepcion','33333333','unicah@gmail.com','yftuvutfuccc','252551525');

INSERT INTO TRABAJADOR(Nombre_Trabajador,Apellido_Trabajador,Fecha_Nacimiento,Genero,Tipo_Documento,Direccion_T,Telefono_T,Email_T,N_Documento) 
VALUES ('Miguel Angel','Solorzano','2001-02-02','M','DNI','Barrio el castaño','1111111','Miguel@gmail.com','90989098');

INSERT INTO USUARIO(Trabajador_ID,Acceso,Usuario,Contrasena)
VALUES (1,'Gerente','usuario','contraseña')

INSERT INTO CLIENTE(Nombre_Cliente,Apellido_Cliente,Fecha_Nacimiento,Genero,Tipo_Documento,Direccion_C,Telefono_C,Email_C,N_Documento) 
VALUES ('Henry Heraldo','Lazaro','2001-01-01','M','DNI','Barrio barrio','1111111','Henry@gmail.com','255355');

INSERT INTO INGRESO ([Proveedor_ID],[Usuario_ID],[Fecha_Ingreso],[Tipo_Comprobante],[Serie],[IVA],[Estado])
VALUES (1,1,'2004-01-01','Factura','0001',0.15,'Activo')

INSERT INTO DETALLE_INGRESO ([Art_ID],[Ingreso_ID],[Precio_Compra],[Stock_Ingreso],[Stock_Actual],[Fecha_Produccion],[Fecha_Vencimiento])
VALUES (1,1,200,60,60,'2001-01-01','2010-01-01')

INSERT INTO [dbo].[VENTA] ([Cliente_ID],[Usuario_ID],[Fecha_Venta],[Tipo_Comprobante],[Serie],[ISV])
VALUES (1,1,'2009-01-01','Fatura','1234',0.18)
































TRUNCATE TABLE [dbo].[ARTICULO]
TRUNCATE TABLE [dbo].[CATEGORIA]
TRUNCATE TABLE [dbo].[CLIENTE]
TRUNCATE TABLE [dbo].[DETALLE_INGRESO]
TRUNCATE TABLE [dbo].[DETALLE_VENTA]
TRUNCATE TABLE [dbo].[INGRESO]
TRUNCATE TABLE [dbo].[PRESENTACION]
TRUNCATE TABLE [dbo].[PROVEEDOR]
TRUNCATE TABLE [dbo].[TRABAJADOR]
TRUNCATE TABLE [dbo].[USUARIO]
TRUNCATE TABLE [dbo].[VENTA]



INSERT INTO DETALLE_VENTA ([Venta_ID],[Detalle_IngresoID],[Cantidad],[Precio_Venta],[Descuento]) VALUES (2,1,12,200,12)
SELECT * FROM DETALLE_INGRESO

SELECT * FROM DETALLE_VENTA



--Muestra Ventas en SQL SERVER

SELECT  dbo.VENTA.ID_Venta, dbo.DETALLE_VENTA.IDDetalle_Venta,(dbo.TRABAJADOR.Nombre_Trabajador+' '+dbo.TRABAJADOR.Apellido_Trabajador) AS 'Trabajador',
(dbo.CLIENTE.Nombre_Cliente+' '+dbo.CLIENTE.Apellido_Cliente) AS 'Cliente', dbo.VENTA.Fecha_Venta, dbo.VENTA.Tipo_Comprobante, 
dbo.VENTA.Serie, dbo.ARTICULO.Nombre_Art AS 'Articulo', dbo.DETALLE_VENTA.Precio_Venta, 
dbo.DETALLE_VENTA.Cantidad, 
SUM((dbo.DETALLE_VENTA.Cantidad * dbo.DETALLE_VENTA.Precio_Venta)) AS 'SubTotal', dbo.DETALLE_VENTA.Descuento,
SUM((dbo.DETALLE_VENTA.Cantidad * dbo.DETALLE_VENTA.Precio_Venta)*dbo.VENTA.ISV) AS ISV,
SUM(((dbo.DETALLE_VENTA.Cantidad * dbo.DETALLE_VENTA.Precio_Venta)-dbo.DETALLE_VENTA.Descuento)+(dbo.DETALLE_VENTA.Cantidad * dbo.DETALLE_VENTA.Precio_Venta)*dbo.VENTA.ISV) AS 'Total'

FROM     dbo.VENTA INNER JOIN
                  dbo.USUARIO ON dbo.VENTA.Usuario_ID = dbo.USUARIO.ID_Usuario INNER JOIN
                  dbo.TRABAJADOR ON dbo.USUARIO.Trabajador_ID = dbo.TRABAJADOR.ID_Trabajador INNER JOIN
                  dbo.INGRESO ON dbo.USUARIO.ID_Usuario = dbo.INGRESO.Usuario_ID INNER JOIN
                  dbo.PROVEEDOR ON dbo.INGRESO.Proveedor_ID = dbo.PROVEEDOR.ID_Proveedor INNER JOIN
                  dbo.DETALLE_VENTA ON dbo.VENTA.ID_Venta = dbo.DETALLE_VENTA.Venta_ID INNER JOIN
                  dbo.DETALLE_INGRESO ON dbo.INGRESO.ID_Ingreso = dbo.DETALLE_INGRESO.Ingreso_ID AND dbo.DETALLE_VENTA.Detalle_IngresoID = dbo.DETALLE_INGRESO.IDDetalle_Ingreso INNER JOIN
                  dbo.CLIENTE ON dbo.VENTA.Cliente_ID = dbo.CLIENTE.ID_Cliente INNER JOIN
                  dbo.ARTICULO ON dbo.DETALLE_INGRESO.Art_ID = dbo.ARTICULO.ID_Art INNER JOIN
                  dbo.PRESENTACION ON dbo.ARTICULO.Presentacion_ID = dbo.PRESENTACION.ID_Presentacion INNER JOIN
                  dbo.CATEGORIA ON dbo.ARTICULO.Categoria_ID = dbo.CATEGORIA.ID_Categoria

				  GROUP BY 
				  dbo.DETALLE_VENTA.IDDetalle_Venta, dbo.ARTICULO.Nombre_Art ,
dbo.DETALLE_VENTA.Cantidad, dbo.DETALLE_VENTA.Precio_Venta, dbo.DETALLE_VENTA.Descuento, dbo.VENTA.ID_Venta, dbo.VENTA.Fecha_Venta, dbo.VENTA.Tipo_Comprobante, 
dbo.VENTA.Serie,(dbo.CLIENTE.Nombre_Cliente+' '+dbo.CLIENTE.Apellido_Cliente), 
(dbo.TRABAJADOR.Nombre_Trabajador+' '+dbo.TRABAJADOR.Apellido_Trabajador), dbo.VENTA.ISV



























