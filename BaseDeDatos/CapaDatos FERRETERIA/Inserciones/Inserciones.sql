/*insercion a tabla presentacion*/
INSERT INTO PRESENTACION(Nombre_Presentacion, Descripcion_Presentacion) VALUES ('Bolsa Pequeña','Bolsa pequeña normal');
INSERT INTO PRESENTACION(Nombre_Presentacion, Descripcion_Presentacion) VALUES ('Bolsa Grande','Bolsa nailo grande');
INSERT INTO PRESENTACION(Nombre_Presentacion, Descripcion_Presentacion) VALUES ('Caja','Una unidad por empaque');
INSERT INTO PRESENTACION(Nombre_Presentacion, Descripcion_Presentacion) VALUES ('Caja Pequeña','Una unidad por empaque');
INSERT INTO PRESENTACION(Nombre_Presentacion, Descripcion_Presentacion) VALUES ('Lata 1/5','0.2 litros de líquido');
INSERT INTO PRESENTACION(Nombre_Presentacion, Descripcion_Presentacion) VALUES ('Botella Plástica 1L','Presentacion de litro');
INSERT INTO PRESENTACION(Nombre_Presentacion, Descripcion_Presentacion) VALUES ('Botella Plástica 1Glón.','Contiene 3.79 litros');
INSERT INTO PRESENTACION(Nombre_Presentacion, Descripcion_Presentacion) VALUES ('Cilindro metálico','Presentacion de medio litro');
INSERT INTO PRESENTACION(Nombre_Presentacion, Descripcion_Presentacion) VALUES ('Lata 1/4','Contiene 250 ml');
INSERT INTO PRESENTACION(Nombre_Presentacion, Descripcion_Presentacion) VALUES ('Lata Galón','Contiene 3.79 Lts');
INSERT INTO PRESENTACION(Nombre_Presentacion, Descripcion_Presentacion) VALUES ('Balde Grande','Contiene 20 Lts');
INSERT INTO PRESENTACION(Nombre_Presentacion, Descripcion_Presentacion) VALUES ('Balde Mediano','Contiene 10 Lts');
INSERT INTO PRESENTACION(Nombre_Presentacion, Descripcion_Presentacion) VALUES ('Balde Pequeño','Contiene 5 Lts');
INSERT INTO PRESENTACION(Nombre_Presentacion, Descripcion_Presentacion) VALUES ('Bolsa Carton Grande','Contiene 200 Lbs.');
INSERT INTO PRESENTACION(Nombre_Presentacion, Descripcion_Presentacion) VALUES ('Bolsa Carton Mediana','Contiene 100 Lbs.');
INSERT INTO PRESENTACION(Nombre_Presentacion, Descripcion_Presentacion) VALUES ('Bolsa Carton Pequena','Contiene 25 Lbs.');
INSERT INTO PRESENTACION(Nombre_Presentacion, Descripcion_Presentacion) VALUES ('Caja Cartón','Contiene 50 Lbs.');
INSERT INTO PRESENTACION(Nombre_Presentacion, Descripcion_Presentacion) VALUES ('Caja Cartón Mediana','Contiene 5 pzas.');
INSERT INTO PRESENTACION(Nombre_Presentacion, Descripcion_Presentacion) VALUES ('Caja Cartón Grande','Contiene 4 pzas..');



/*insercion a tabla categoria*/
INSERT INTO CATEGORIA(Nombre_Categoria, Descripcion_Categoria) VALUES ('Construccion','Bueno, es para construir');
INSERT INTO CATEGORIA(Nombre_Categoria, Descripcion_Categoria) VALUES ('Carpinteria','Herramientas para terminados de madera');
INSERT INTO CATEGORIA(Nombre_Categoria, Descripcion_Categoria) VALUES ('Electricidad','Productos para eléctricidad');
INSERT INTO CATEGORIA(Nombre_Categoria, Descripcion_Categoria) VALUES ('Tubería','Materiales para terminados de mantenimiento tubería');
INSERT INTO CATEGORIA(Nombre_Categoria, Descripcion_Categoria) VALUES ('Soldadura','Materiales para valcones, portones, etc.');
INSERT INTO CATEGORIA(Nombre_Categoria, Descripcion_Categoria) VALUES ('Pintura','Mariales para cabados de pintura');
INSERT INTO CATEGORIA(Nombre_Categoria, Descripcion_Categoria) VALUES ('Accesorios','Para los terminados del hogar');
INSERT INTO CATEGORIA(Nombre_Categoria, Descripcion_Categoria) VALUES ('Suelos','Para pisos, ladrillos, cerámica, etc');
INSERT INTO CATEGORIA(Nombre_Categoria, Descripcion_Categoria) VALUES ('Hierro','Para acabados');



/*insercion a tabla articulo*/
INSERT INTO ARTICULO(Categoria_ID, Presentacion_ID, Nombre_Art, Descripcion_Art) VALUES (1,1,'Tornillos','Tornillos 7cm');
INSERT INTO ARTICULO(Categoria_ID, Presentacion_ID, Nombre_Art, Descripcion_Art) VALUES (1,2,'Cemento','Para construcción y remodelación');
INSERT INTO ARTICULO(Categoria_ID, Presentacion_ID, Nombre_Art, Descripcion_Art) VALUES (7,3,'Lava manos','Para baños');
INSERT INTO ARTICULO(Categoria_ID, Presentacion_ID, Nombre_Art, Descripcion_Art) VALUES (7,3,'Tasa rural','Para baños');
INSERT INTO ARTICULO(Categoria_ID, Presentacion_ID, Nombre_Art, Descripcion_Art) VALUES (3,1,'Interruptor sencillo','Swith sencillo');
INSERT INTO ARTICULO(Categoria_ID, Presentacion_ID, Nombre_Art, Descripcion_Art) VALUES (3,1,'Interruptor doble','Swith doble');
INSERT INTO ARTICULO(Categoria_ID, Presentacion_ID, Nombre_Art, Descripcion_Art) VALUES (3,1,'Interruptor triple','Swith triple');
INSERT INTO ARTICULO(Categoria_ID, Presentacion_ID, Nombre_Art, Descripcion_Art) VALUES (8,19,'Cerámica','Para suelos y terminados');
INSERT INTO ARTICULO(Categoria_ID, Presentacion_ID, Nombre_Art, Descripcion_Art) VALUES (8,19,'Pintura Corona','Para terminados');
INSERT INTO ARTICULO(Categoria_ID, Presentacion_ID, Nombre_Art, Descripcion_Art) VALUES (6,11,'Pintura Covermore','Para terminados');
INSERT INTO ARTICULO(Categoria_ID, Presentacion_ID, Nombre_Art, Descripcion_Art) VALUES (6,12,'Pintura Américana','Para terminados');
INSERT INTO ARTICULO(Categoria_ID, Presentacion_ID, Nombre_Art, Descripcion_Art) VALUES (6,13,'Pintura Diamons','Para terminados');
INSERT INTO ARTICULO(Categoria_ID, Presentacion_ID, Nombre_Art, Descripcion_Art) VALUES (1,15,'Arenilla','Para construcción');
INSERT INTO ARTICULO(Categoria_ID, Presentacion_ID, Nombre_Art, Descripcion_Art) VALUES (1,15,'Pega Cerámica','Para construcción');
INSERT INTO ARTICULO(Categoria_ID, Presentacion_ID, Nombre_Art, Descripcion_Art) VALUES (1,16,'Fraguador','Para terminados de suelos');
INSERT INTO ARTICULO(Categoria_ID, Presentacion_ID, Nombre_Art, Descripcion_Art) VALUES (9,20,'Grapas','Para terminados');


/*insercion a tabla proveedores*/
INSERT INTO PROVEEDOR(Razon_Social,Sector_Comercial,Tipo_Documento,Direccion_P,Telefono_P,Email_P,url,N_Documento) 
VALUES ('UNICAH','MISERIA','DNI','Calle hacia la Concepcion','33333333','unicah@gmail.com','yftuvutfuccc','252551525');
INSERT INTO PROVEEDOR(Razon_Social,Sector_Comercial,Tipo_Documento,Direccion_P,Telefono_P,Email_P,url,N_Documento) 
VALUES ('La Global','Tubería','DNI','Barrio Palmira, Juticalpa','98453621','laglobal@gmail.com','htps//gtdtte.bcbdj.es','252554532');
INSERT INTO PROVEEDOR(Razon_Social,Sector_Comercial,Tipo_Documento,Direccion_P,Telefono_P,Email_P,url,N_Documento) 
VALUES ('FERROMAX','Hierro','DNI','Barrio El Tical, Tegucigalpa','33338675','ferro@gmail.com','htps//gtuuuye.bcbdj.es','267551525');
INSERT INTO PROVEEDOR(Razon_Social,Sector_Comercial,Tipo_Documento,Direccion_P,Telefono_P,Email_P,url,N_Documento) 
VALUES ('Alutech','Techos','DNI','Calle principal, San Esteba','98733333','aluch@gmail.com','htps//gtdtte.kj67.p','098751525');
INSERT INTO PROVEEDOR(Razon_Social,Sector_Comercial,Tipo_Documento,Direccion_P,Telefono_P,Email_P,url,N_Documento) 
VALUES ('Cacerez','Construción','DNI','Calle hacia la Concepcion, Juticalpa','90453333','Cace@gmail.com','htps//gtdop8.hbdj.es','09876525');

/*insercion a tabla trabajadores*/
INSERT INTO TRABAJADOR(Nombre_Trabajador,Apellido_Trabajador,Fecha_Nacimiento,Genero,Tipo_Documento,Direccion_T,Telefono_T,Email_T,N_Documento) 
VALUES ('Miguel Angel','Solorzano','2001-02-02','M','DNI','Barrio el castaño','1111111','Miguel@gmail.com','90989098');
INSERT INTO TRABAJADOR(Nombre_Trabajador,Apellido_Trabajador,Fecha_Nacimiento,Genero,Tipo_Documento,Direccion_T,Telefono_T,Email_T,N_Documento) 
VALUES ('Gerson Dvid','Barralaga','2000-02-23','M','Factura','Barrio el colegio','98765434','gerson@gmail.com','98766789');
INSERT INTO TRABAJADOR(Nombre_Trabajador,Apellido_Trabajador,Fecha_Nacimiento,Genero,Tipo_Documento,Direccion_T,Telefono_T,Email_T,N_Documento) 
VALUES ('Wilder Oqueli','Maldonado','2000-09-02','M','DNI','Colonia San Pedro','78654321','wilder@gmail.com','12342123');
INSERT INTO TRABAJADOR(Nombre_Trabajador,Apellido_Trabajador,Fecha_Nacimiento,Genero,Tipo_Documento,Direccion_T,Telefono_T,Email_T,N_Documento) 
VALUES ('Bertha Nohemy','Lainez','2001-05-29','F','Recibo','Barrio el castaño','87678908','bertha@gmail.com','98767898');
INSERT INTO TRABAJADOR(Nombre_Trabajador,Apellido_Trabajador,Fecha_Nacimiento,Genero,Tipo_Documento,Direccion_T,Telefono_T,Email_T,N_Documento) 
VALUES ('Byron José','Escobar','1999-02-02','M','DNI','Barrio el castaño','56435821','byron@gmail.com','90827688');
INSERT INTO TRABAJADOR(Nombre_Trabajador,Apellido_Trabajador,Fecha_Nacimiento,Genero,Tipo_Documento,Direccion_T,Telefono_T,Email_T,N_Documento) 
VALUES ('Juan Miguel','Solorzano','2001-03-10','M','DNI','Barrio el centro','34256789','juan@gmail.com','87289098');

/*insercion a tabla usuario*/
INSERT INTO USUARIO(Trabajador_ID,Acceso,Usuario,Contrasena)
VALUES (1,'Gerente','usuario','contraseña')
INSERT INTO USUARIO(Trabajador_ID,Acceso,Usuario,Contrasena)
VALUES (3,'Administrador','gerba','operar1')
INSERT INTO USUARIO(Trabajador_ID,Acceso,Usuario,Contrasena)
VALUES (2,'Administrador','wildo','operar2')

/*insercion a tabla cliente*/
INSERT INTO CLIENTE(Nombre_Cliente,Apellido_Cliente,Fecha_Nacimiento,Genero,Tipo_Documento,Direccion_C,Telefono_C,Email_C,N_Documento) 
VALUES ('Henry Heraldo','Lazaro','2001-01-01','M','DNI','Barrio barrio','1111111','Henry@gmail.com','255355');
INSERT INTO CLIENTE(Nombre_Cliente,Apellido_Cliente,Fecha_Nacimiento,Genero,Tipo_Documento,Direccion_C,Telefono_C,Email_C,N_Documento) 
VALUES ('Karla Patricia','Gutierrez','1998-03-01','F','Factura','Barrio el centro','87654578','karka@gmail.com','255356');
INSERT INTO CLIENTE(Nombre_Cliente,Apellido_Cliente,Fecha_Nacimiento,Genero,Tipo_Documento,Direccion_C,Telefono_C,Email_C,N_Documento) 
VALUES ('Alicia Anais','Fúnez','1980-09-30','F','DNI','Barrio las flores','67554565','alicia@gmail.com','255357');
INSERT INTO CLIENTE(Nombre_Cliente,Apellido_Cliente,Fecha_Nacimiento,Genero,Tipo_Documento,Direccion_C,Telefono_C,Email_C,N_Documento) 
VALUES ('María Eufemia','Guzmán','2000-02-01','F','Factura','Barrio el progreso','89765678','mary@gmail.com','255358');
INSERT INTO CLIENTE(Nombre_Cliente,Apellido_Cliente,Fecha_Nacimiento,Genero,Tipo_Documento,Direccion_C,Telefono_C,Email_C,N_Documento) 
VALUES ('Camila Reina ','Santos','2001-01-29','F','DNI','Barrio los lirios','90876767','cami@gmail.com','255359');
INSERT INTO CLIENTE(Nombre_Cliente,Apellido_Cliente,Fecha_Nacimiento,Genero,Tipo_Documento,Direccion_C,Telefono_C,Email_C,N_Documento) 
VALUES ('Santos Dionisio','Cabrera','2002-01-10','M','Factura','Barrio el centro','32445322','santos@gmail.com','255360');
INSERT INTO CLIENTE(Nombre_Cliente,Apellido_Cliente,Fecha_Nacimiento,Genero,Tipo_Documento,Direccion_C,Telefono_C,Email_C,N_Documento) 
VALUES ('Carmen Suyapa','Sarmiento','1988-08-01','F','Factura','Barrio cohodefor','98787867','suyapa@gmail.com','255361');
INSERT INTO CLIENTE(Nombre_Cliente,Apellido_Cliente,Fecha_Nacimiento,Genero,Tipo_Documento,Direccion_C,Telefono_C,Email_C,N_Documento) 
VALUES ('Celestino Adalid','Escobar','2001-12-01','M','DNI','Barrio san jerónimo','98675434','celestino@gmail.com','255362');
INSERT INTO CLIENTE(Nombre_Cliente,Apellido_Cliente,Fecha_Nacimiento,Genero,Tipo_Documento,Direccion_C,Telefono_C,Email_C,N_Documento) 
VALUES ('Fredy Anael','Carías','2000-11-01','M','DNI','Barrio castañeda','32455445','fredy@gmail.com','255363');
INSERT INTO CLIENTE(Nombre_Cliente,Apellido_Cliente,Fecha_Nacimiento,Genero,Tipo_Documento,Direccion_C,Telefono_C,Email_C,N_Documento) 
VALUES ('Kevin Eduardo','Sosa','2000-05-11','M','Factura','Barrio san jerónimo','23987656','kevin@gmail.com','255364');
INSERT INTO CLIENTE(Nombre_Cliente,Apellido_Cliente,Fecha_Nacimiento,Genero,Tipo_Documento,Direccion_C,Telefono_C,Email_C,N_Documento) 
VALUES ('Gamaliel Jose','Maradiaga','2000-07-01','M','DNI','Barrio el centro','34333221','jose@gmail.com','255365');

/*insercion a tabla ingreso*/
INSERT INTO INGRESO ([Proveedor_ID],[Usuario_ID],[Fecha_Ingreso],[Tipo_Comprobante],[Serie],[IVA],[Estado])
VALUES (1,1,'2004-01-01','Factura','0001',0.15,'Activo')
INSERT INTO INGRESO ([Proveedor_ID],[Usuario_ID],[Fecha_Ingreso],[Tipo_Comprobante],[Serie],[IVA],[Estado])
VALUES (1,3,'2004-01-21','Factura','0015',0.15,'Activo')
INSERT INTO INGRESO ([Proveedor_ID],[Usuario_ID],[Fecha_Ingreso],[Tipo_Comprobante],[Serie],[IVA],[Estado])
VALUES (2,1,'2004-05-03','Factura','0021',0.15,'Inactivo')
INSERT INTO INGRESO ([Proveedor_ID],[Usuario_ID],[Fecha_Ingreso],[Tipo_Comprobante],[Serie],[IVA],[Estado])
VALUES (2,3,'2004-07-23','Factura','0112',0.15,'Inactivo')
INSERT INTO INGRESO ([Proveedor_ID],[Usuario_ID],[Fecha_Ingreso],[Tipo_Comprobante],[Serie],[IVA],[Estado])
VALUES (2,2,'2004-11-01','Factura','0907',0.15,'Activo')
INSERT INTO INGRESO ([Proveedor_ID],[Usuario_ID],[Fecha_Ingreso],[Tipo_Comprobante],[Serie],[IVA],[Estado])
VALUES (5,1,'2005-02-01','Factura','0201',0.15,'Activo')
INSERT INTO INGRESO ([Proveedor_ID],[Usuario_ID],[Fecha_Ingreso],[Tipo_Comprobante],[Serie],[IVA],[Estado])
VALUES (4,3,'2005-04-21','Factura','0032',0.15,'Inactivo')
INSERT INTO INGRESO ([Proveedor_ID],[Usuario_ID],[Fecha_Ingreso],[Tipo_Comprobante],[Serie],[IVA],[Estado])
VALUES (4,3,'2005-08-22','Factura','0061',0.15,'Activo')
INSERT INTO INGRESO ([Proveedor_ID],[Usuario_ID],[Fecha_Ingreso],[Tipo_Comprobante],[Serie],[IVA],[Estado])
VALUES (1,1,'2005-12-01','Factura','0011',0.15,'Activo')
INSERT INTO INGRESO ([Proveedor_ID],[Usuario_ID],[Fecha_Ingreso],[Tipo_Comprobante],[Serie],[IVA],[Estado])
VALUES (2,2,'2006-01-14','Factura','1515',0.15,'Activo')

/*insercion a tabla detalle_ingreso*/
INSERT INTO DETALLE_INGRESO ([Art_ID],[Ingreso_ID],[Precio_Compra],[Stock_Ingreso],[Stock_Actual],[Fecha_Produccion],[Fecha_Vencimiento])
VALUES (12,1,200,60,60,'2003-01-01','2010-01-01')
INSERT INTO DETALLE_INGRESO ([Art_ID],[Ingreso_ID],[Precio_Compra],[Stock_Ingreso],[Stock_Actual],[Fecha_Produccion],[Fecha_Vencimiento])
VALUES (13,2,250,60,80,'2004-02-01','2010-02-01')
INSERT INTO DETALLE_INGRESO ([Art_ID],[Ingreso_ID],[Precio_Compra],[Stock_Ingreso],[Stock_Actual],[Fecha_Produccion],[Fecha_Vencimiento])
VALUES (1,3,20,60,120,'2004-02-20','2010-02-20')
INSERT INTO DETALLE_INGRESO ([Art_ID],[Ingreso_ID],[Precio_Compra],[Stock_Ingreso],[Stock_Actual],[Fecha_Produccion],[Fecha_Vencimiento])
VALUES (4,4,50,20,60,'2005-01-01','2010-01-01')
INSERT INTO DETALLE_INGRESO ([Art_ID],[Ingreso_ID],[Precio_Compra],[Stock_Ingreso],[Stock_Actual],[Fecha_Produccion],[Fecha_Vencimiento])
VALUES (6,5,40,50,60,'2005-01-01','2011-01-01')
INSERT INTO DETALLE_INGRESO ([Art_ID],[Ingreso_ID],[Precio_Compra],[Stock_Ingreso],[Stock_Actual],[Fecha_Produccion],[Fecha_Vencimiento])
VALUES (10,6,35,30,90,'2005-01-01','2012-01-01')
INSERT INTO DETALLE_INGRESO ([Art_ID],[Ingreso_ID],[Precio_Compra],[Stock_Ingreso],[Stock_Actual],[Fecha_Produccion],[Fecha_Vencimiento])
VALUES (11,7,200,60,90,'2005-01-22','2010-01-22')
INSERT INTO DETALLE_INGRESO ([Art_ID],[Ingreso_ID],[Precio_Compra],[Stock_Ingreso],[Stock_Actual],[Fecha_Produccion],[Fecha_Vencimiento])
VALUES (7,8,300,60,60,'2006-01-01','2010-01-01')
INSERT INTO DETALLE_INGRESO ([Art_ID],[Ingreso_ID],[Precio_Compra],[Stock_Ingreso],[Stock_Actual],[Fecha_Produccion],[Fecha_Vencimiento])
VALUES (8,9,500,20,60,'2006-01-01','2010-01-01')
INSERT INTO DETALLE_INGRESO ([Art_ID],[Ingreso_ID],[Precio_Compra],[Stock_Ingreso],[Stock_Actual],[Fecha_Produccion],[Fecha_Vencimiento])
VALUES (4,10,350,50,50,'2006-01-01','2010-01-01')

/*insercion a tabla venta*/
INSERT INTO [dbo].[VENTA] ([Cliente_ID],[Usuario_ID],[Fecha_Venta],[Tipo_Comprobante],[Serie],[ISV])
VALUES (9,1,'2009-01-01','Fatura','1234',0.18)
INSERT INTO [dbo].[VENTA] ([Cliente_ID],[Usuario_ID],[Fecha_Venta],[Tipo_Comprobante],[Serie],[ISV])
VALUES (7,1,'2009-08-01','Factura','1235',0.15)
INSERT INTO [dbo].[VENTA] ([Cliente_ID],[Usuario_ID],[Fecha_Venta],[Tipo_Comprobante],[Serie],[ISV])
VALUES (3,3,'2009-09-12','Factura','1236',0.15)
INSERT INTO [dbo].[VENTA] ([Cliente_ID],[Usuario_ID],[Fecha_Venta],[Tipo_Comprobante],[Serie],[ISV])
VALUES (10,3,'2009-07-01','Factura','1237',0.18)
INSERT INTO [dbo].[VENTA] ([Cliente_ID],[Usuario_ID],[Fecha_Venta],[Tipo_Comprobante],[Serie],[ISV])
VALUES (3,1,'2010-01-21','Factura','1238',0.15)
INSERT INTO [dbo].[VENTA] ([Cliente_ID],[Usuario_ID],[Fecha_Venta],[Tipo_Comprobante],[Serie],[ISV])
VALUES (2,2,'2010-09-13','Factura','1239',0.15)
INSERT INTO [dbo].[VENTA] ([Cliente_ID],[Usuario_ID],[Fecha_Venta],[Tipo_Comprobante],[Serie],[ISV])
VALUES (5,3,'2010-01-30','Factura','1240',0.15)
INSERT INTO [dbo].[VENTA] ([Cliente_ID],[Usuario_ID],[Fecha_Venta],[Tipo_Comprobante],[Serie],[ISV])
VALUES (6,2,'2010-04-01','Factura','1241',0.15)
INSERT INTO [dbo].[VENTA] ([Cliente_ID],[Usuario_ID],[Fecha_Venta],[Tipo_Comprobante],[Serie],[ISV])
VALUES (2,2,'2010-06-19','Factura','1242',0.15)
INSERT INTO [dbo].[VENTA] ([Cliente_ID],[Usuario_ID],[Fecha_Venta],[Tipo_Comprobante],[Serie],[ISV])
VALUES (8,1,'2010-09-01','Factura','1243',0.15)
































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
