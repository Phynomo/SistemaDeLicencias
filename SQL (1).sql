CREATE DATABASE SistemaDeLicencias

GO
USE SistemaDeLicencias
GO 
CREATE SCHEMA gral;
GO
CREATE SCHEMA lice;
GO
CREATE SCHEMA acce;
GO

CREATE TABLE acce.tbRoles(
	role_Id					INT IDENTITY,
	role_Nombre				NVARCHAR(100) NOT NULL,
	role_UsuCreacion		INT NOT NULL,
	role_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_role_FechaCreacion DEFAULT(GETDATE()),
	role_UsuModificacion	INT,
	role_FechaModificacion	DATETIME,
	role_Estado				BIT NOT NULL CONSTRAINT DF_role_Estado DEFAULT(1)
	CONSTRAINT PK_acce_tbRoles_role_Id PRIMARY KEY(role_Id)
);
GO

CREATE TABLE acce.tbPantallas(
	pant_Id					INT IDENTITY,
	pant_Nombre				NVARCHAR(100) NOT NULL,
	pant_Url				NVARCHAR(300) NOT NULL,
	pant_Menu				NVARCHAR(300) NOT NULL,
	pant_HtmlId				NVARCHAR(80) NOT NULL,
	pant_UsuCreacion		INT NOT NULL,
	pant_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_pant_FechaCreacion DEFAULT(GETDATE()),
	pant_UsuModificacion	INT,
	pant_FechaModificacion	DATETIME,
	pant_Estado				BIT NOT NULL CONSTRAINT DF_pant_Estado DEFAULT(1)
	CONSTRAINT PK_acce_tbPantallas_pant_Id PRIMARY KEY(pant_Id)
);


CREATE TABLE acce.tbPantallasPorRoles(
	pantrole_Id					INT IDENTITY,
	role_Id						INT NOT NULL,
	pant_Id						INT NOT NULL,
	pantrole_UsuCreacion		INT NOT NULL,
	pantrole_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_pantrole_FechaCreacion DEFAULT(GETDATE()),
	pantrole_UsuModificacion	INT,
	pantrole_FechaModificacion	DATETIME,
	pantrole_Estado				BIT NOT NULL CONSTRAINT DF_pantrole_Estado DEFAULT(1)
	CONSTRAINT FK_acce_tbPantallasPorRoles_acce_tbRoles_role_Id FOREIGN KEY(role_Id) REFERENCES acce.tbRoles(role_Id),
	CONSTRAINT FK_acce_tbPantallasPorRoles_acce_tbPantallas_pant_Id FOREIGN KEY(pant_Id)	REFERENCES acce.tbPantallas(pant_Id),
	CONSTRAINT PK_acce_tbPantallasPorRoles_pantrole_Id PRIMARY KEY(pantrole_Id),
);
GO

CREATE TABLE acce.tbUsuarios(
	user_Id 				INT IDENTITY(1,1),
	user_NombreUsuario		NVARCHAR(100) NOT NULL,
	user_Contrasena			NVARCHAR(MAX) NOT NULL,
	user_EsAdmin			BIT,
	role_Id					INT,
	empe_Id					INT,
	user_UsuCreacion		INT,
	user_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_user_FechaCreacion DEFAULT(GETDATE()),
	user_UsuModificacion	INT,
	user_FechaModificacion	DATETIME,
	user_Estado				BIT NOT NULL CONSTRAINT DF_user_Estado DEFAULT(1)
	CONSTRAINT PK_acce_tbUsuarios_user_Id  PRIMARY KEY(user_Id),
);

GO
CREATE OR ALTER PROCEDURE acce.UDP_InsertUsuario
	@user_NombreUsuario NVARCHAR(100),	
    @user_Contrasena NVARCHAR(200),
	@user_EsAdmin BIT,					
    @role_Id INT, 
	@empe_Id INT										
AS
BEGIN
	DECLARE @password NVARCHAR(MAX)=(SELECT HASHBYTES('Sha2_512', @user_Contrasena));

	INSERT acce.tbUsuarios(user_NombreUsuario, user_Contrasena, user_EsAdmin, role_Id, empe_Id, user_UsuCreacion)
	VALUES(@user_NombreUsuario, @password, @user_EsAdmin, @role_Id, @empe_Id, 1);
END;


GO
EXEC acce.UDP_InsertUsuario 'Cristian', '123', 1, NULL, 1;
GO
ALTER TABLE acce.tbRoles
ADD CONSTRAINT FK_acce_tbRoles_acce_tbUsuarios_role_UsuCreacion_user_Id 	FOREIGN KEY(role_UsuCreacion) REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_acce_tbRoles_acce_tbUsuarios_role_UsuModificacion_user_Id FOREIGN KEY(role_UsuModificacion) REFERENCES acce.tbUsuarios(user_Id);

GO
INSERT INTO acce.tbRoles(role_Nombre, role_UsuCreacion)
VALUES ('Admin', 1)

GO
ALTER TABLE [acce].[tbUsuarios]
ADD CONSTRAINT FK_acce_tbUsuarios_acce_tbUsuarios_user_UsuCreacion_user_Id  FOREIGN KEY(user_UsuCreacion) REFERENCES acce.tbUsuarios([user_Id]),
	CONSTRAINT FK_acce_tbUsuarios_acce_tbUsuarios_user_UsuModificacion_user_Id  FOREIGN KEY(user_UsuModificacion) REFERENCES acce.tbUsuarios([user_Id]),
	CONSTRAINT FK_acce_tbUsuarios_acce_tbRoles_role_Id FOREIGN KEY(role_Id) REFERENCES acce.tbRoles(role_Id)

GO 
ALTER TABLE [acce].[tbPantallasPorRoles]
ADD CONSTRAINT FK_acce_tbPantallasPorRoles_acce_tbUsuarios_pantrole_UsuCreacion_user_Id FOREIGN KEY([pantrole_UsuCreacion]) REFERENCES acce.tbUsuarios([user_Id]),
	CONSTRAINT FK_acce_tbPantallasPorRoles_acce_tbUsuarios_pantrole_UsuModificacion_user_Id FOREIGN KEY([pantrole_UsuModificacion]) REFERENCES acce.tbUsuarios([user_Id])

--********TABLA DEPARTAMENTO****************---
GO
CREATE TABLE [gral].[tbDepartamentos](
    depa_Id                     INT IDENTITY(1,1),
	depa_Nombre 				NVARCHAR(100) NOT NULL,
	depa_Codigo  				CHAR(2) NOT NULL,
	depa_UsuCreacion			INT NOT NULL,
	depa_FechaCreacion			DATETIME NOT NULL CONSTRAINT DF_depa_FechaCreacion DEFAULT(GETDATE()),
	depa_UsuModificacion		INT,
	depa_FechaModificacion		DATETIME,
	depa_Estado					BIT NOT NULL CONSTRAINT DF_depa_Estado DEFAULT(1)
	CONSTRAINT PK_gral_tbDepartamentos_depa_Id 									PRIMARY KEY(depa_Id),
	CONSTRAINT FK_gral_tbDepartamentos_acce_tbUsuarios_depa_UsuCreacion_user_Id  		FOREIGN KEY(depa_UsuCreacion) 		REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_gral_tbDepartamentos_acce_tbUsuarios_depa_UsuModificacion_user_Id  	FOREIGN KEY(depa_UsuModificacion) 	REFERENCES acce.tbUsuarios(user_Id)
);


--********TABLA MUNICIPIO****************---
GO
CREATE TABLE gral.tbMunicipios(
	muni_Id                 INT IDENTITY(1,1),
    muni_Nombre				NVARCHAR(80) NOT NULL,
	muni_Codigo				CHAR(4)	NOT NULL,
	depa_Id					INT	NOT NULL,
	muni_UsuCreacion		INT	NOT NULL,
	muni_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_muni_FechaCreacion DEFAULT(GETDATE()),
	muni_UsuModificacion	INT,
	muni_FechaModificacion	DATETIME,
	muni_Estado				BIT	NOT NULL CONSTRAINT DF_muni_Estado DEFAULT(1)
	CONSTRAINT PK_gral_tbMunicipios_muni_Id 										PRIMARY KEY(muni_Id),
	CONSTRAINT FK_gral_tbMunicipios_gral_tbDepartamentos_depa_Id 					FOREIGN KEY (depa_Id) 						REFERENCES gral.tbDepartamentos(depa_Id),
	CONSTRAINT FK_gral_tbMunicipios_acce_tbUsuarios_muni_UsuCreacion_user_Id  		FOREIGN KEY(muni_UsuCreacion) 				REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_gral_tbMunicipios_acce_tbUsuarios_muni_UsuModificacion_user_Id  	FOREIGN KEY(muni_UsuModificacion) 			REFERENCES acce.tbUsuarios(user_Id)
);


-- ESTADOS CIVILES --
GO
CREATE TABLE gral.tbEstadosCiviles(
eciv_Id                        INT IdENTITY(1,1),
eciv_Descripcion            VARCHAR(100),
eciv_UsuCreacion            INT NOT NULL,
eciv_FechaCreacion            DATETIME NOT NULL CONSTRAINT DF_gral_TbEstadosCiviles_eciv_FechaCreacion    DEFAULT(GETDATE()),
eciv_UsuModificacion        INT,
eciv_FechaModificacion        DATETIME,
eciv_Estado                    BIT NOT NULL CONSTRAINT DF_gral_TbEstadosCiviles_eciv_Estado    DEFAULT(1)
CONSTRAINT     PK_gral_tbEstadosCiviles_ectv_Id PRIMARY KEY(eciv_Id),
CONSTRAINT    FK_gral_tbEstadosCiviles_UsuCreacion_usua_Id        FOREIGN KEY(eciv_UsuCreacion) REFERENCES acce.tbUsuarios(user_Id),
CONSTRAINT    FK_gral_tbEstadosCiviles_UsuModificacion_usua_Id    FOREIGN KEY(eciv_UsuModificacion) REFERENCES acce.tbUsuarios(user_Id)
);

--****************** lice ******************************--

--********** CARGOS *****************--
--** CARGOS *--
GO
CREATE TABLE lice.tbCargos(
carg_Id INT IDENTITY(1,1),
carg_Descripcion         NVARCHAR(100) NOT NULL,
carg_UsuCreacion         INT NOT NULL,
carg_FechaCreacion         DATETIME CONSTRAINT DF_lice_tbCargos_carg_FechaCreacion DEFAULT(GETDATE()),
carg_UsuModificacion     INT ,
carg_FechaModificacion     DATETIME,
carg_Estado             BIT CONSTRAINT DF_lice_tbCargos_carg_Estado DEFAULT(1)
CONSTRAINT PK_lice_tbcargos_carg_Id                                 PRIMARY KEY(carg_Id),
CONSTRAINT PK_lice_tbCargos_acce_tbUsuarios_carg_UsuCreacion         FOREIGN KEY(carg_UsuCreacion) REFERENCES acce.tbUsuarios(User_Id),
CONSTRAINT PK_lice_tbCargos_acce_tbUsuarios_carg_UsuModificacion     FOREIGN KEY(carg_UsuModificacion) REFERENCES acce.tbUsuarios(User_Id)
);
--* TIPO LICENCIA **
GO
CREATE TABLE lice.tbTiposLicencias(
tili_Id INT IDENTITY(1,1),
tili_Descripcion         NVARCHAR(100) NOT NULL,
tili_UsuCreacion         INT NOT NULL,
tili_FechaCreacion         DATETIME CONSTRAINT DF_lice_tbTiposLicencias_tili_FechaCreacion DEFAULT(GETDATE()),
tili_UsuModificacion     INT ,
tili_FechaModificacion     DATETIME,
tili_Estado             BIT CONSTRAINT DF_licetbTiposLicencias_tili_Estado DEFAULT(1)
CONSTRAINT PK_lice_tbTiposLicencias_tili_Id                                 PRIMARY KEY(tili_Id),
CONSTRAINT FK_lice_tbTiposLicencias_acce_tbUsuarios_tili_UsuCreacion         FOREIGN KEY(tili_UsuCreacion) REFERENCES acce.tbUsuarios(User_Id),
CONSTRAINT FK_lice_tbTiposLicencias_acce_tbUsuarios_tili_UsuModificacion     FOREIGN KEY(tili_UsuModificacion) REFERENCES acce.tbUsuarios(User_Id)
);

--* SUCURSAL **
GO
CREATE TABLE lice.tbSucursales(
sucu_Id                        INT IDENTITY(1,1),
sucu_Nombre                    NVARCHAR(200)     NOT NULL,
muni_Id                        INT         NOT NULL,
sucu_Direccion                NVARCHAR(200)    NOT NULL,
sucu_UsuCreacion            INT             NOT NULL,
sucu_FechaCreacion            DATETIME         CONSTRAINT DF_lice_tbSucursales_sucu_FechaCreacion    DEFAULT(GETDATE()),
sucu_UsuModificacion        INT,
sucu_FechaModificacion        DATETIME,
sucu_Estado                    BIT             CONSTRAINT DF_lice_tbSucursales_sucu_Estado DEFAULT (1)
CONSTRAINT PK_lice_tbSucursales_sucu_Id                                    PRIMARY KEY(sucu_Id),
CONSTRAINT FK_lice_tbSucursales_gral_tbMunicipios_muni_Id                FOREIGN KEY(muni_Id)                 REFERENCES gral.tbMunicipios(muni_Id),
CONSTRAINT FK_lice_tbSucursales_acce_tbUsuarios_sucu_UsuCreacion         FOREIGN KEY(sucu_UsuCreacion)         REFERENCES acce.tbUsuarios(User_Id),
CONSTRAINT FK_lice_tbSucursales_acce_tbUsuarios_sucu_UsuModificacion     FOREIGN KEY(sucu_UsuModificacion)     REFERENCES acce.tbUsuarios(User_Id)
);




--**************** SOLICITANTES **********************
CREATE TABLE lice.tbSolicitantes(
    soli_Id                 INT IDENTITY(1,1),
    soli_Nombre             NVARCHAR(200) NOT NULL,
    soli_Apellido           NVARCHAR(200) NOT NULL,
    soli_Identidad          NVARCHAR(13) UNIQUE NOT NULL ,
    muni_Id                 INT NOT NULL,
    soli_Sexo               CHAR(1) NOT NULL,
    soli_FechaNacimiento    DATE NOT NULL,
    soli_Telefono           NVARCHAR(20),
    soli_UsuCreacion        INT NOT NULL,
    soli_FechaCreacion      DATETIME CONSTRAINT DF_lice_tbSolicitantes_soli_FechaCreacion DEFAULT(GETDATE()),
    soli_UsuModificacion    INT ,
    soli_FechaModificacion  DATETIME,
    soli_Estado             BIT CONSTRAINT DF_lice_tbSolicitantes_soli_Estado DEFAULT(1)

    CONSTRAINT PK_lice_tbSolicitantes_soli_Id 	PRIMARY KEY(soli_Id),
    CONSTRAINT CK_lice_tbSolicitantes_soli_Sexo CHECK(soli_Sexo IN ('F', 'M')),
    CONSTRAINT FK_lice_tbSolicitantes_acce_tbUsuarios_soli_UsuCreacion_user_Id  	FOREIGN KEY(soli_UsuCreacion) 		REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_lice_tbSolicitantes_acce_tbUsuarios_soli_UsuModificacion_user_Id  FOREIGN KEY(soli_UsuModificacion) 	REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_lice_tbSolicitantes_gral_tbMunicipios_muni_Id						FOREIGN KEY(muni_Id)				REFERENCES gral.tbMunicipios(muni_Id)			
)

--********TABLA EMPLEADOS****************---
GO
CREATE TABLE lice.tbEmpleados(
	empe_Id						INT IDENTITY(1,1),
	empe_Nombres				NVARCHAR(200)	NOT NULL,
	empe_Apellidos				NVARCHAR(200)	NOT NULL,
	empe_Identidad				VARCHAR(13)		NOT NULL,
	empe_FechaNacimiento		DATE			NOT NULL,
	empe_Sexo					CHAR(1)			NOT NULL,
	eciv_Id					    INT				NOT NULL,
	muni_Id						INT	    		NOT NULL,
	empe_DireccionExacta		NVARCHAR(250)	NOT NULL,
	empe_Telefono				NVARCHAR(20)	NOT NULL,
	empe_CorreoElectronico		NVARCHAR(200)	NULL,
	sucu_Id						INT				NOT NULL,
	carg_Id						int				NOT NULL,
	empe_UsuCreacion			INT				NOT NULL,
	empe_FechaCreacion			DATETIME		NOT NULL CONSTRAINT DF_empe_FechaCreacion DEFAULT(GETDATE()),
	empe_UsuModificacion		INT,
	empe_FechaModificacion		DATETIME,
	empe_Estado					BIT NOT NULL CONSTRAINT DF_empe_Estado DEFAULT(1),
	
	CONSTRAINT PK_lice_tbEmpleados_empe_Id 										PRIMARY KEY(empe_Id),
	CONSTRAINT CK_lice_tbEmpleados_empe_Sexo									CHECK(empe_sexo IN ('F', 'M')),
	CONSTRAINT FK_lice_tbEmpleados_gral_tbEstadosCiviles_eciv_Id        		FOREIGN KEY(eciv_Id)					    REFERENCES gral.tbEstadosCiviles(eciv_Id),			
	CONSTRAINT FK_lice_tbEmpleados_gral_tbMunicipios_muni_Id					FOREIGN KEY(muni_Id)						REFERENCES gral.tbMunicipios(muni_Id),
	CONSTRAINT FK_lice_tbEmpleados_lice_tbCargos_carg_Id						FOREIGN KEY(carg_Id)						REFERENCES lice.tbCargos(carg_Id),
	CONSTRAINT FK_lice_tbEmpleados_acce_tbUsuarios_UserCreate					FOREIGN KEY(empe_UsuCreacion)				REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_lice_tbEmpleados_acce_tbUsuarios_UserUpdate					FOREIGN KEY(empe_UsuModificacion)			REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_lice_tbEmpleados_lice_tbSucursales_sucu_Id					FOREIGN KEY(sucu_Id)						REFERENCES lice.tbSucursales(sucu_Id)		
);

GO
CREATE TABLE lice.tbSolicitud(
	stud_Id INT IDENTITY(1,1),
	soli_Id	INT NOT NULL,
	sucu_Id	INT NOT NULL,
	tili_Id INT NOT NULL,
	stud_Pago BIT NOT NULL,
	stud_UsuCreacion			INT				NOT NULL,
	stud_FechaCreacion			DATETIME		NOT NULL CONSTRAINT DF_stud_FechaCreacion DEFAULT(GETDATE()),
	stud_UsuModificacion		INT,
	stud_FechaModificacion		DATETIME,
	stud_Estado					BIT NOT NULL CONSTRAINT DF_stud_Estado DEFAULT(1),

	CONSTRAINT PK_lice_tbSolicitud_stud_Id										PRIMARY KEY(stud_Id),			
	CONSTRAINT FK_lice_tbSolicitud_lice_tbSolicitantes_soli_Id					FOREIGN KEY(soli_Id)						REFERENCES lice.tbSolicitantes(soli_Id),
	CONSTRAINT FK_lice_tbSolicitud_lice_tbTiposLiciencias_tili_Id				FOREIGN KEY(tili_Id)						REFERENCES lice.tbTiposLicencias(tili_Id),
	CONSTRAINT FK_lice_tbSolicitud_lice_tbSucursales_sucu_Id					FOREIGN KEY(sucu_Id)						REFERENCES lice.tbSucursales(sucu_Id),	
	CONSTRAINT FK_lice_tbSolicitud_acce_tbUsuarios_UserCreate					FOREIGN KEY(stud_UsuCreacion)				REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_lice_tbSolicitud_acce_tbUsuarios_UserUpdate					FOREIGN KEY(stud_UsuModificacion)			REFERENCES acce.tbUsuarios(user_Id)
)



CREATE TABLE lice.tbAprobados(
    apro_Id				INT IDENTITY(1,1),
    stud_Id				INT NOT NULL,
    empe_Id				INT NOT NULL,
	apro_Aceptado		BIT NOT NULL,
	apro_Observaciones	NVARCHAR(500),
    apro_Fecha			DATE NOT NULL,     
	apro_UsuCreacion			INT				NOT NULL,
	apro_FechaCreacion			DATETIME		NOT NULL CONSTRAINT DF_apro_FechaCreacion DEFAULT(GETDATE()),
	apro_UsuModificacion		INT,
	apro_FechaModificacion		DATETIME,
	apro_Estado					BIT NOT NULL CONSTRAINT DF_apro_Estado DEFAULT(1),

    CONSTRAINT PK_lice_tbAprovados_apro_Id 										PRIMARY KEY(apro_Id),
	CONSTRAINT FK_lice_tbAprovados_lice_tbSolicitud_stud_Id						FOREIGN KEY(stud_Id)					    REFERENCES lice.tbSolicitud(stud_Id),	
	CONSTRAINT FK_lice_tbAprovados_acce_tbUsuarios_UserCreate					FOREIGN KEY(apro_UsuCreacion)				REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_lice_tbAprovados_acce_tbUsuarios_UserUpdate					FOREIGN KEY(apro_UsuModificacion)			REFERENCES acce.tbUsuarios(user_Id),	
	CONSTRAINT FK_lice_tbAprovados_lice_tbEmpleados_empe_Id					    FOREIGN KEY(empe_Id)						REFERENCES lice.tbEmpleados(empe_Id)		


    
)

GO
CREATE OR ALTER VIEW lice.VW_tbTiposLicencias_View
AS
SELECT [tili_Id]
      ,[tili_Descripcion]
      ,[tili_UsuCreacion]
      ,t2.user_NombreUsuario AS UsuarioCreacion
      ,[tili_FechaCreacion]
      ,[tili_UsuModificacion] 
      ,t3.user_NombreUsuario AS UsuarioModificacion
      ,[tili_FechaModificacion]
      ,[tili_Estado]
  FROM [lice].[tbTiposLicencias] T1 INNER JOIN acce.tbUsuarios T2
  ON T1.tili_UsuCreacion = T2.user_Id LEFT JOIN acce.tbUsuarios T3
  ON T1.tili_UsuModificacion = T3.user_Id


  GO
  CREATE OR ALTER PROCEDURE lice.UDP_tbTiposLicencias_Select
  AS 
  BEGIN
  
  SELECT * FROM lice.VW_tbTiposLicencias_View
  WHERE tili_Estado = 1

  END
  GO
  
  GO
  CREATE OR ALTER PROCEDURE lice.UDP_tbTiposLicencias_Insert
  @tili_Descripcion nvarchar(100),
  @tili_UsuCreacion int
  AS 
  BEGIN
  BEGIN TRY

  INSERT INTO [lice].[tbTiposLicencias]
           ([tili_Descripcion]
           ,[tili_UsuCreacion]
           ,[tili_FechaCreacion]
           ,[tili_UsuModificacion]
           ,[tili_FechaModificacion]
           ,[tili_Estado])
     VALUES
           (@tili_Descripcion
           ,@tili_UsuCreacion
           ,GETDATE()
           ,null
           ,null
           ,1)

		   SELECT 1
  END TRY
  BEGIN CATCH
	SELECT 0
  END CATCH

  END
  GO


INSERT INTO gral.tbEstadosCiviles (eciv_Descripcion, eciv_Estado, eciv_UsuCreacion, eciv_FechaCreacion, eciv_UsuModificacion, eciv_FechaModificacion)
VALUES	('Soltero(a)', '1', 1, GETDATE(), NULL, NULL),
		('Casado(a)', '1', 1, GETDATE(), NULL, NULL),
		('Divorciado(a)', '1', 1, GETDATE(), NULL, NULL),
		('Viudo(a)', '1', 1, GETDATE(), NULL, NULL),
		('Union Libre', '1', 1, GETDATE(), NULL, NULL)
GO


INSERT INTO gral.tbDepartamentos(depa_Codigo, depa_Nombre, depa_Estado, depa_UsuCreacion, depa_FechaCreacion, depa_UsuModificacion, depa_FechaModificacion)
VALUES	('01','Atlántida', '1', 1, GETDATE(), NULL, NULL),
		('02','Colón', '1', 1, GETDATE(), NULL, NULL),
		('03','Comayagua', '1', 1, GETDATE(), NULL,NULL),
		('04','Copán', '1', 1, GETDATE(), NULL, NULL),
		('05','Cortés', '1', 1, GETDATE(), NULL, NULL),
		('06','Choluteca', '1', 1, GETDATE(), NULL, NULL),
		('07','El Paraíso', '1', 1, GETDATE(), NULL, NULL),
		('08','Francisco Morazán', '1', 1, GETDATE(), NULL, NULL),
		('09','Gracias a Dios', '1', 1, GETDATE(), NULL, NULL),
		('10','Intibucá', '1', 1, GETDATE(), NULL, NULL),
		('11','Islas de la Bahía', '1', 1, GETDATE(), NULL, NULL),
		('12','La Paz', '1', 1, GETDATE(), NULL, NULL),
		('13','Lempira', '1', 1, GETDATE(), NULL,NULL ),
		('14','Ocotepeque', '1', 1, GETDATE(), NULL, NULL),
		('15','Olancho', '1', 1, GETDATE(), NULL, NULL),
		('16','Santa Bárbara', '1', 1, GETDATE(), NULL, NULL),
		('17','Valle', '1', 1, GETDATE(), NULL, NULL),
		('18','Yoro', '1', 1, GETDATE(), NULL, NULL);
GO


INSERT INTO gral.tbMunicipios(depa_Id, muni_Codigo, muni_Nombre, muni_Estado, muni_UsuCreacion, muni_FechaCreacion, muni_UsuModificacion, muni_FechaModificacion)
VALUES	('1','0101','La Ceiba', '1', 1, GETDATE(), NULL, GETDATE()),
		('1','0102','El Porvenir', '1', 1, GETDATE(), NULL, GETDATE()),
		('1','0103','Tela', '1', 1, GETDATE(), NULL, GETDATE()),
		('1','0104','Jutiapa', '1', 1, GETDATE(), NULL, GETDATE()),
		('1','0105','La Masica', '1', 1, GETDATE(), NULL, GETDATE()),
		('1','0106','San Francisco', '1', 1, GETDATE(), NULL, GETDATE()),
		('1','0107','Arizona', '1', 1, GETDATE(), NULL, GETDATE()),
		('1','0108','Esparta', '1', 1, GETDATE(), NULL, GETDATE()),
	

		('2','0201','Trujillo', '1', 1, GETDATE(), NULL, GETDATE()),
		('2','0202','Balfate', '1', 1, GETDATE(), NULL, GETDATE()),
		('2','0203','Iriona', '1', 1, GETDATE(), NULL, GETDATE()),
		('2','0204','Limón', '1', 1, GETDATE(), NULL, GETDATE()),
		('2','0205','Sabá', '1', 1, GETDATE(), NULL, GETDATE()),
		('2','0206','Santa Fe', '1', 1, GETDATE(), NULL, GETDATE()),
		('2','0207','Santa Rosa de Aguán', '1', 1, GETDATE(), NULL, GETDATE()),
		('2','0208','Sonaguera', '1', 1, GETDATE(), NULL, GETDATE()),
		('2','0209','Tocoa', '1', 1, GETDATE(), NULL, GETDATE()),
		('2','0210','Bonito Oriental', '1', 1, GETDATE(), NULL, GETDATE()),


		('3',		'0301',		'Comayagua', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0302',		'Ajuterique', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0303',		'El Rosario', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0304',		'Esquías', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0305',		'Humuya', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0306',		'La Libertad', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0307',		'Lamaní', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0308',		'La Trinidad', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0309',		'Lejamaní', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0310',		'Meámbar', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0311',		'Minas de Oro', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0312',		'Ojos de Agua', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0313',		'San Jerónimo', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0314',		'San José de Comayagua', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0315',		'San José del Potrero', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0316',		'San Luis', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0317',		'San Sebastián', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0318',		'Siguatepeque', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0319',		'Villa de San Antonio', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0320',		'Las Lajas', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0321',		'Taulabé', '1', 1, GETDATE(), NULL, GETDATE()),


		('4',	'0401','Santa Rosa de Copán', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0402','Cabañas', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0403','Concepción', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0404','Copán Ruinas', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0405','Corquín', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0406','Cucuyagua', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0407','Dolores', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0408','Dulce Nombre', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0409','El Paraíso', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0410','Florida', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0411','La Jigua', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0412','La Unión', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0413','Nueva Arcadia', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0414','San Agustín', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0415','San Antonio', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0416','San Jerónimo', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0417','San José', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0418','San Juan de Opoa', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0419','San Nicolás', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0420','San Pedro', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0421','Santa Rita', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0422','Trinidad de Copán', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0423','Veracruz', '1', 1, GETDATE(), NULL, GETDATE()),


		('5',	'0501','San Pedro Sula', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0502','Choloma', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0503','Omoa', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0504','Pimienta', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0505','Potrerillos', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0506','Puerto Cortés', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0507','San Antonio de Cortés', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0508','San Francisco de Yojoa', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0509','San Manuel', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0510','Santa Cruz de Yojoa', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0511','Villanueva', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0512','La Lima', '1', 1, GETDATE(), NULL, GETDATE()),


		('6',	'0601','Choluteca', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0602','Apacilagua', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0603','Concepción de María', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0604','Duyure', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0605','El Corpus', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0606','El Triunfo', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0607','Marcovia', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0608','Morolica', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0609','Namasigüe', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0610','Orocuina', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0611','Pespire', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0612','San Antonio de Flores', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0613','San Isidro', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0614','San José', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0615','San Marcos de Colón', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0616','Santa Ana de Yusguare', '1', 1, GETDATE(), NULL, GETDATE()),


		('7', '0701', 'Yuscarán', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0702', 'Alauca', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0703', 'Danlí', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0704', 'El Paraíso', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0705', 'Güinope', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0706', 'Jacaleapa', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0707', 'Liure', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0708', 'Morocelí', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0709', 'Oropolí', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0710', 'Potrerillos', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0711', 'San Antonio de Flores', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0712', 'San Lucas', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0713', 'San Matías', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0714', 'Soledad', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0715', 'Teupasenti', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0716', 'Texiguat', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0717', 'Vado Ancho', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0718', 'Yauyupe', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0719', 'Trojes', '1', 1, GETDATE(), NULL, GETDATE()),


		('8', '0801', 'Distrito Central', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0802', 'Alubarén', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0803', 'Cedros', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0804', 'Curarén', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0805', 'El Porvenir', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0806', 'Guaimaca', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0807', 'La Libertad', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0808', 'La Venta', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0809', 'Lepaterique', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0810', 'Maraita', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0811', 'Marale', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0812', 'Nueva Armenia', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0813', 'Ojojona', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0814', 'Orica', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0815', 'Reitoca', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0816', 'Sabanagrande', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0817', 'San Antonio de Oriente', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0818', 'San Buenaventura', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0819', 'San Ignacio', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0820', 'San Juan de Flores', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0821', 'San Miguelito', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0822', 'Santa Ana', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0823', 'Santa Lucía', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0824', 'Talanga', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0825', 'Tatumbla', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0826', 'Valle de Ángeles', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0827', 'Villa de San Francisco', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0828', 'Vallecillo', '1', 1, GETDATE(), NULL, GETDATE()),
		
		('9', '0901', 'Puerto Lempira', '1', 1, GETDATE(), NULL, GETDATE()),
		('9', '0902', 'Brus Laguna', '1', 1, GETDATE(), NULL, GETDATE()),
		('9', '0903', 'Ahuas', '1', 1, GETDATE(), NULL, GETDATE()),
		('9', '0904', 'Juan Francisco Bulnes', '1', 1, GETDATE(), NULL, GETDATE()),
		('9', '0905', 'Ramón Villeda Morales', '1', 1, GETDATE(), NULL, GETDATE()),
		('9', '0906', 'Wampusirpe', '1', 1, GETDATE(), NULL, GETDATE()),
		
		('10', '1001', 'La Esperanza', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1002', 'Camasca', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1003', 'Colomoncagua', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1004', 'Concepción', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1005', 'Dolores', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1006', 'Intibucá', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1007', 'Jesús de Otoro', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1008', 'Magdalena', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1009', 'Masaguara', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1010', 'San Antonio', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1011', 'San Isidro', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1012', 'San Juan', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1013', 'San Marcos de la Sierra', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1014', 'San Miguel Guancapla', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1015', 'Santa Lucía', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1016', 'Yamaranguila', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1017', 'San Francisco de Opalaca', '1', 1, GETDATE(), NULL, GETDATE()),


		('11', '1101', 'Roatán', '1', 1, GETDATE(), NULL, GETDATE()),
		('11', '1102', 'Guanaja', '1', 1, GETDATE(), NULL, GETDATE()),
		('11', '1103', 'José Santos Guardiola', '1', 1, GETDATE(), NULL, GETDATE()),
		('11', '1104', 'Utila', '1', 1, GETDATE(), NULL, GETDATE()),


		('12', '1201', 'La Paz', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1202', 'Aguanqueterique', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1203', 'Cabañas', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1204', 'Cane', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1205', 'Chinacla', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1206', 'Guajiquiro', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1207', 'Lauterique', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1208', 'Marcala', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1209', 'Mercedes de Oriente', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1210', 'Opatoro', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1211', 'San Antonio del Norte', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1212', 'San José', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1213', 'San Juan', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1214', 'San Pedro de Tutule', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1215', 'Santa Ana', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1216', 'Santa Elena', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1217', 'Santa María', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1218', 'Santiago de Puringla', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1219', 'Yarula', '1', 1, GETDATE(), NULL, GETDATE()),


		('13', '1301', 'Gracias', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1302', 'Belén', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1303', 'Candelaria', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1304', 'Cololaca', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1305', 'Erandique', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1306', 'Gualcince', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1307', 'Guarita', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1308', 'La Campa', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1309', 'La Iguala', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1310', 'Las Flores', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1311', 'La Unión', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1312', 'La Virtud', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1313', 'Lepaera', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1314', 'Mapulaca', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1315', 'Piraera', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1316', 'San Andrés', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1317', 'San Francisco', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1318', 'San Juan Guarita', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1319', 'San Manuel Colohete', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1320', 'San Rafael', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1321', 'San Sebastián', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1322', 'Santa Cruz', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1323', 'Talgua', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1324', 'Tambla', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1325', 'Tomalá', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1326', 'Valladolid', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1327', 'Virginia', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1328', 'San Marcos de Caiquín', '1', 1, GETDATE(), NULL, GETDATE()),


		('14', '1401', 'Ocotepeque', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1402', 'Belén Gualcho', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1403', 'Concepción', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1404', 'Dolores Merendón', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1405', 'Fraternidad', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1406', 'La Encarnación', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1407', 'La Labor', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1408', 'Lucerna', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1409', 'Mercedes', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1410', 'San Fernando', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1411', 'San Francisco del Valle', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1412', 'San Jorge', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1413', 'San Marcos', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1414', 'Santa Fe', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1415', 'Sensenti', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1416', 'Sinuapa', '1', 1, GETDATE(), NULL, GETDATE()),


		('15', '1501', 'Juticalpa', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1502', 'Campamento', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1503', 'Catacamas', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1504', 'Concordia', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1505', 'Dulce Nombre de Culmí', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1506', 'El Rosario', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1507', 'Esquipulas del Norte', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1508', 'Gualaco', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1509', 'Guarizama', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1510', 'Guata', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1511', 'Guayape', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1512', 'Jano', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1513', 'La Unión', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1514', 'Mangulile', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1515', 'Manto', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1516', 'Salamá', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1517', 'San Esteban', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1518', 'San Francisco de Becerra', '1',1, GETDATE(), NULL, GETDATE()),
		('15', '1519', 'San Francisco de la Paz', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1520', 'Santa María del Real', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1521', 'Silca', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1522', 'Yocón', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1523', 'Patuca', '1', 1, GETDATE(), NULL, GETDATE()),


		('16', '1601' , 'Santa Bárbara', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1602' , 'Arada', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1603' , 'Atima', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1604' , 'Azacualpa', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1605' , 'Ceguaca', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1606' , 'Concepción del Norte', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1607' , 'Concepción del Sur', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1608' , 'Chinda', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1609' , 'El Níspero', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1610' , 'Gualala', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1611' , 'Ilama', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1612' , 'Las Vegas', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1613' , 'Macuelizo', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1614' , 'Naranjito', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1615' , 'Nuevo Celilac', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1616' , 'Nueva Frontera', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1617' , 'Petoa', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1618' , 'Protección', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1619' , 'Quimistán', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1620' , 'San Francisco de Ojuera', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1621' , 'San José de las Colinas', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1622' , 'San Luis', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1623' , 'San Marcos', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1624' , 'San Nicolás', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1625' , 'San Pedro Zacapa', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1626' , 'San Vicente Centenario', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1627' , 'Santa Rita', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1628' , 'Trinidad', '1', 1, GETDATE(), NULL, GETDATE()),


		('17', '1701', 'Nacaome', '1', 1, GETDATE(), NULL, GETDATE()),
		('17', '1702', 'Alianza', '1', 1, GETDATE(), NULL, GETDATE()),
		('17', '1703', 'Amapala', '1', 1, GETDATE(), NULL, GETDATE()),
		('17', '1704', 'Aramecina', '1', 1, GETDATE(), NULL, GETDATE()),
		('17', '1705', 'Caridad', '1', 1, GETDATE(), NULL, GETDATE()),
		('17', '1706', 'Goascorán', '1', 1, GETDATE(), NULL, GETDATE()),
		('17', '1707', 'Langue', '1', 1, GETDATE(), NULL, GETDATE()),
		('17', '1708', 'San Francisco de Coray', '1', 1, GETDATE(), NULL, GETDATE()),
		('17', '1709', 'San Lorenzo', '1', 1, GETDATE(), NULL, GETDATE()),


		('18', '1801', 'Yoro', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1802', 'Arenal', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1803', 'El Negrito', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1804', 'El Progreso', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1805', 'Jocón', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1806', 'Morazán', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1807', 'Olanchito', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1808', 'Santa Rita', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1809', 'Sulaco', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1810', 'Victoria', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1811', 'Yorito', '1', 1, GETDATE(), NULL, GETDATE());
GO


