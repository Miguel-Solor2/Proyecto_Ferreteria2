--PROCEDIMIENTOS ALAMACENADOS 
--USUARIO
-------------------------------------------------------------------
--MOSTRAR USUARIO
CREATE PROC SP_MOSTRAR_USUARIO
AS 
SELECT TOP 100 dbo.USUARIO.ID_Usuario, dbo.USUARIO.Acceso, dbo.USUARIO.Usuario, dbo.USUARIO.Trabajador_ID,
dbo.TRABAJADOR.Nombre_Trabajador, dbo.TRABAJADOR.Apellido_Trabajador
FROM     
dbo.TRABAJADOR INNER JOIN dbo.USUARIO ON dbo.TRABAJADOR.ID_Trabajador = dbo.USUARIO.Trabajador_ID
ORDER BY [ID_Usuario] DESC 
GO

--BUSQUEDA USUARIO
CREATE PROC SP_BUSCAR_USUARIO
@BusquedaTexto VARCHAR(60)
AS 
SELECT dbo.USUARIO.ID_Usuario, dbo.USUARIO.Acceso, dbo.USUARIO.Usuario, dbo.USUARIO.Trabajador_ID,
dbo.TRABAJADOR.Nombre_Trabajador, dbo.TRABAJADOR.Apellido_Trabajador
FROM     
dbo.TRABAJADOR INNER JOIN dbo.USUARIO ON dbo.TRABAJADOR.ID_Trabajador = dbo.USUARIO.Trabajador_ID
WHERE [Usuario] LIKE @BusquedaTexto + '%'
ORDER BY [ID_Usuario] DESC
GO

--INSERTAR USUARIO
CREATE PROC SP_INSERTAR_USUARIO
@idusuario INT OUTPUT,
@trabajadorID INT,
@acceso VARCHAR(20),
@usuario VARCHAR(20),
@contrasena VARCHAR(20)
AS
INSERT INTO USUARIO([Trabajador_ID],[Acceso],[Usuario],[Contrasena])
VALUES (@trabajadorID,@acceso,@usuario,@contrasena)
GO

--EDITAR USUARIO
CREATE PROC SP_EDITAR_USUARIO
@idusuario INT,
@trabajadorID INT,
@acceso VARCHAR(20),
@usuario VARCHAR(20),
@contrasena VARCHAR(20)
AS
UPDATE USUARIO SET [Trabajador_ID] = @trabajadorID, [Acceso]= @acceso, [Usuario]= @usuario, [Contrasena]= @contrasena
WHERE [ID_Usuario] = @idusuario 
GO

------Create SPLogin
CREATE PROC SPLOGIN
@Usuario VARCHAR(20),
@Contrasena VARCHAR(20)
AS
 SELECT dbo.TRABAJADOR.ID_Trabajador, dbo.TRABAJADOR.Apellido_Trabajador, dbo.TRABAJADOR.Nombre_Trabajador, dbo.USUARIO.Acceso
FROM     dbo.USUARIO INNER JOIN
                  dbo.TRABAJADOR ON dbo.USUARIO.Trabajador_ID = dbo.TRABAJADOR.ID_Trabajador
				  WHERE Usuario=@Usuario AND Contrasena = @Contrasena
				  GO
select * from usuario
select * from TRABAJADOR
UPDATE TRABAJADOR SET Email_T = 'josemariaalmendares@gmail.com' WHERE ID_Trabajador = 2

----------RECUPERAR CONTRASENA
CREATE PROC SP_CAMBIAR_PASS
@Usuario VARCHAR(20),
@contrasena VARCHAR(20)
AS
UPDATE USUARIO SET  [Contrasena]= @contrasena
WHERE  Usuario=@Usuario