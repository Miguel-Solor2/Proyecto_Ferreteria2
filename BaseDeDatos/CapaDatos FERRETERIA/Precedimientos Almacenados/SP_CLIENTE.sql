--PROCEDIMIENTOS ALAMACENADOS 
--CLIENTE
-------------------------------------------------------------------
--MOSTRAR CLIENTE
CREATE PROC SP_MOSTRAR_CLIENTE
AS
SELECT TOP 100 * FROM CLIENTE
ORDER BY [ID_Cliente] DESC
GO

--BUSQUEDA CLIENTE
CREATE PROC SP_BUSCAR_CLIENTE
@BusquedaTexto VARCHAR(60)
AS
SELECT * FROM CLIENTE
WHERE Apellido_Cliente LIKE @BusquedaTexto + '%'
GO

--INSERTAR CLIENTE
CREATE PROC SP_INSERTAR_CLIENTE 
@idcliente INT OUTPUT,
@nombre_cliente VARCHAR(30),
@apellido_cliente VARCHAR(30),
@fecha_nacimiento DATE,
@genero VARCHAR(2),
@tipo_Documento VARCHAR(20),
@direccion VARCHAR(100),
@telefono VARCHAR(8),
@email VARCHAR(60)
AS
INSERT INTO CLIENTE([Nombre_Cliente],[Apellido_Cliente],[Fecha_Nacimiento],[Genero],[Tipo_Documento],[Direccion_C],[Telefono_C],[Email_C])
VALUES (@nombre_cliente, @apellido_cliente, @fecha_nacimiento, @genero, @tipo_Documento, @direccion, @telefono, @email)
GO

--EDITAR CLIENTE
CREATE PROC SP_EDITAR_CLIENTE 
@idcliente INT OUTPUT,
@nombre_cliente VARCHAR(30),
@apellido_cliente VARCHAR(30),
@fecha_nacimiento DATE,
@genero VARCHAR(2),
@tipo_Documento VARCHAR(20),
@direccion VARCHAR(100),
@telefono VARCHAR(8),
@email VARCHAR(60)
AS
UPDATE CLIENTE SET [Nombre_Cliente]=@idcliente,[Apellido_Cliente]=@apellido_cliente,[Fecha_Nacimiento]=@fecha_nacimiento,
[Genero]=@genero,[Tipo_Documento]=@tipo_Documento,[Direccion_C]=@direccion,[Telefono_C]=@telefono,[Email_C]=@email
WHERE [ID_Cliente]= @idcliente
GO