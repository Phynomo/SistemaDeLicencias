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
	role_Nombre				NVARCHAR(100) UNIQUE NOT NULL,
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
	prol_Id						INT IDENTITY,
	role_Id						INT NOT NULL,
	pant_Id						INT NOT NULL,
	prol_UsuCreacion			INT NOT NULL,
	prol_FechaCreacion			DATETIME NOT NULL CONSTRAINT DF_pantrole_FechaCreacion DEFAULT(GETDATE()),
	prol_UsuModificacion		INT,
	prol_FechaModificacion		DATETIME,
	prol_Estado					BIT NOT NULL CONSTRAINT DF_pantrole_Estado DEFAULT(1)
	CONSTRAINT FK_acce_tbPantallasPorRoles_acce_tbRoles_role_Id FOREIGN KEY(role_Id) REFERENCES acce.tbRoles(role_Id),
	CONSTRAINT FK_acce_tbPantallasPorRoles_acce_tbPantallas_pant_Id FOREIGN KEY(pant_Id)	REFERENCES acce.tbPantallas(pant_Id),
	CONSTRAINT PK_acce_tbPantallasPorRoles_pantrole_Id PRIMARY KEY(prol_Id)
);
GO

CREATE TABLE acce.tbUsuarios(
	user_Id 				INT IDENTITY(1,1),
	user_NombreUsuario		NVARCHAR(100) NOT NULL,
	user_Contrasena			NVARCHAR(MAX) NOT NULL,
	user_EsAdmin			BIT,
	role_Id					INT,
	empe_Id					INT,
	user_UsuCreacion		INT NOT NULL,
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
ADD CONSTRAINT FK_acce_tbPantallasPorRoles_acce_tbUsuarios_pantrole_UsuCreacion_user_Id FOREIGN KEY([prol_UsuCreacion]) REFERENCES acce.tbUsuarios([user_Id]),
	CONSTRAINT FK_acce_tbPantallasPorRoles_acce_tbUsuarios_pantrole_UsuModificacion_user_Id FOREIGN KEY([prol_UsuModificacion]) REFERENCES acce.tbUsuarios([user_Id])

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
tili_Descripcion			NVARCHAR(100) UNIQUE NOT NULL,
tili_UsuCreacion			INT NOT NULL,
tili_FechaCreacion			DATETIME CONSTRAINT DF_lice_tbTiposLicencias_tili_FechaCreacion DEFAULT(GETDATE()),
tili_UsuModificacion		INT ,
tili_FechaModificacion		DATETIME,
tili_Estado					BIT CONSTRAINT DF_licetbTiposLicencias_tili_Estado DEFAULT(1)
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
    soli_Sexo               CHAR(1) NOT NULL,
    soli_FechaNacimiento    DATE NOT NULL,
    soli_Telefono           NVARCHAR(20),
	muni_Id                 INT NOT NULL,
	soli_Direccion			NVARCHAR(300) NOT NULL,
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
	empe_Identidad				VARCHAR(15)		NOT NULL,
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

--ALTER TABLE [acce].[tbUsuarios]
--ADD CONSTRAINT FK_acce_tbUsuarios_lice_tbEmpleados_empe_Id FOREIGN KEY(empe_Id) REFERENCES lice.tbEmpleados(empe_Id)

GO
CREATE TABLE lice.tbSolicitud(
	stud_Id INT IDENTITY(1,1),
	soli_Id	INT NOT NULL,
	sucu_Id	INT NOT NULL,
	tili_Id INT NOT NULL,
	stud_Pago BIT NOT NULL,
	stud_Intentos INT NOT NULL  CONSTRAINT DF_stud_Intentos DEFAULT(5),
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
	apro_Observaciones	NVARCHAR(500),
	apro_Intentos		INT NOT NULL,
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



CREATE TABLE lice.tbRechazados(
    rech_Id				INT IDENTITY(1,1),
    stud_Id				INT NOT NULL,
    empe_Id				INT NOT NULL,
	rech_Observaciones	NVARCHAR(500),
    rech_Fecha			DATE NOT NULL,     
	rech_UsuCreacion			INT				NOT NULL,
	rech_FechaCreacion			DATETIME		NOT NULL CONSTRAINT DF_rech_FechaCreacion DEFAULT(GETDATE()),
	rech_UsuModificacion		INT,
	rech_FechaModificacion		DATETIME,
	rech_Estado					BIT NOT NULL CONSTRAINT DF_rech_Estado DEFAULT(1),

    CONSTRAINT PK_lice_tbRechazados_apro_Id 										PRIMARY KEY(rech_Id),
	CONSTRAINT FK_lice_tbRechazados_lice_tbSolicitud_stud_Id						FOREIGN KEY(stud_Id)					    REFERENCES lice.tbSolicitud(stud_Id),	
	CONSTRAINT FK_lice_tbRechazados_acce_tbUsuarios_UserCreate					FOREIGN KEY(rech_UsuCreacion)				REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_lice_tbRechazados_acce_tbUsuarios_UserUpdate					FOREIGN KEY(rech_UsuModificacion)			REFERENCES acce.tbUsuarios(user_Id),	
	CONSTRAINT FK_lice_tbRechazados_lice_tbEmpleados_empe_Id					    FOREIGN KEY(empe_Id)						REFERENCES lice.tbEmpleados(empe_Id)		
)

--************************************************---
--******************** INSERTS *******************---


--********** ESTADOS CIVILES TABLE ***************--
GO
INSERT INTO gral.tbEstadosCiviles (eciv_Descripcion, eciv_Estado, eciv_UsuCreacion, eciv_FechaCreacion, eciv_UsuModificacion, eciv_FechaModificacion)
VALUES	('Soltero(a)', '1', 1, GETDATE(), NULL, NULL),
		('Casado(a)', '1', 1, GETDATE(), NULL, NULL),
		('Divorciado(a)', '1', 1, GETDATE(), NULL, NULL),
		('Viudo(a)', '1', 1, GETDATE(), NULL, NULL),
		('Union Libre', '1', 1, GETDATE(), NULL, NULL)


--********** DEPARTAMENTOS TABLE ***************--
GO
INSERT INTO gral.tbDepartamentos(depa_Codigo, depa_Nombre, depa_Estado, depa_UsuCreacion, depa_FechaCreacion, depa_UsuModificacion, depa_FechaModificacion)
VALUES	('01','Atl�ntida', '1', 1, GETDATE(), NULL, NULL),
		('02','Col�n', '1', 1, GETDATE(), NULL, NULL),
		('03','Comayagua', '1', 1, GETDATE(), NULL,NULL),
		('04','Cop�n', '1', 1, GETDATE(), NULL, NULL),
		('05','Cort�s', '1', 1, GETDATE(), NULL, NULL),
		('06','Choluteca', '1', 1, GETDATE(), NULL, NULL),
		('07','El Para�so', '1', 1, GETDATE(), NULL, NULL),
		('08','Francisco Moraz�n', '1', 1, GETDATE(), NULL, NULL),
		('09','Gracias a Dios', '1', 1, GETDATE(), NULL, NULL),
		('10','Intibuc�', '1', 1, GETDATE(), NULL, NULL),
		('11','Islas de la Bah�a', '1', 1, GETDATE(), NULL, NULL),
		('12','La Paz', '1', 1, GETDATE(), NULL, NULL),
		('13','Lempira', '1', 1, GETDATE(), NULL,NULL ),
		('14','Ocotepeque', '1', 1, GETDATE(), NULL, NULL),
		('15','Olancho', '1', 1, GETDATE(), NULL, NULL),
		('16','Santa B�rbara', '1', 1, GETDATE(), NULL, NULL),
		('17','Valle', '1', 1, GETDATE(), NULL, NULL),
		('18','Yoro', '1', 1, GETDATE(), NULL, NULL);



--********** MUNICIPIOS TABLE ***************--
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
		('2','0204','Lim�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('2','0205','Sab�', '1', 1, GETDATE(), NULL, GETDATE()),
		('2','0206','Santa Fe', '1', 1, GETDATE(), NULL, GETDATE()),
		('2','0207','Santa Rosa de Agu�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('2','0208','Sonaguera', '1', 1, GETDATE(), NULL, GETDATE()),
		('2','0209','Tocoa', '1', 1, GETDATE(), NULL, GETDATE()),
		('2','0210','Bonito Oriental', '1', 1, GETDATE(), NULL, GETDATE()),


		('3',		'0301',		'Comayagua', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0302',		'Ajuterique', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0303',		'El Rosario', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0304',		'Esqu�as', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0305',		'Humuya', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0306',		'La Libertad', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0307',		'Laman�', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0308',		'La Trinidad', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0309',		'Lejaman�', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0310',		'Me�mbar', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0311',		'Minas de Oro', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0312',		'Ojos de Agua', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0313',		'San Jer�nimo', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0314',		'San Jos� de Comayagua', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0315',		'San Jos� del Potrero', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0316',		'San Luis', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0317',		'San Sebasti�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0318',		'Siguatepeque', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0319',		'Villa de San Antonio', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0320',		'Las Lajas', '1', 1, GETDATE(), NULL, GETDATE()),
		('3',		'0321',		'Taulab�', '1', 1, GETDATE(), NULL, GETDATE()),


		('4',	'0401','Santa Rosa de Cop�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0402','Caba�as', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0403','Concepci�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0404','Cop�n Ruinas', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0405','Corqu�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0406','Cucuyagua', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0407','Dolores', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0408','Dulce Nombre', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0409','El Para�so', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0410','Florida', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0411','La Jigua', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0412','La Uni�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0413','Nueva Arcadia', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0414','San Agust�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0415','San Antonio', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0416','San Jer�nimo', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0417','San Jos�', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0418','San Juan de Opoa', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0419','San Nicol�s', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0420','San Pedro', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0421','Santa Rita', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0422','Trinidad de Cop�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('4',	'0423','Veracruz', '1', 1, GETDATE(), NULL, GETDATE()),


		('5',	'0501','San Pedro Sula', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0502','Choloma', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0503','Omoa', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0504','Pimienta', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0505','Potrerillos', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0506','Puerto Cort�s', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0507','San Antonio de Cort�s', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0508','San Francisco de Yojoa', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0509','San Manuel', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0510','Santa Cruz de Yojoa', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0511','Villanueva', '1', 1, GETDATE(), NULL, GETDATE()),
		('5',	'0512','La Lima', '1', 1, GETDATE(), NULL, GETDATE()),


		('6',	'0601','Choluteca', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0602','Apacilagua', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0603','Concepci�n de Mar�a', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0604','Duyure', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0605','El Corpus', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0606','El Triunfo', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0607','Marcovia', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0608','Morolica', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0609','Namasig�e', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0610','Orocuina', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0611','Pespire', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0612','San Antonio de Flores', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0613','San Isidro', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0614','San Jos�', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0615','San Marcos de Col�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('6',	'0616','Santa Ana de Yusguare', '1', 1, GETDATE(), NULL, GETDATE()),


		('7', '0701', 'Yuscar�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0702', 'Alauca', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0703', 'Danl�', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0704', 'El Para�so', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0705', 'G�inope', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0706', 'Jacaleapa', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0707', 'Liure', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0708', 'Morocel�', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0709', 'Oropol�', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0710', 'Potrerillos', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0711', 'San Antonio de Flores', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0712', 'San Lucas', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0713', 'San Mat�as', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0714', 'Soledad', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0715', 'Teupasenti', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0716', 'Texiguat', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0717', 'Vado Ancho', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0718', 'Yauyupe', '1', 1, GETDATE(), NULL, GETDATE()),
		('7', '0719', 'Trojes', '1', 1, GETDATE(), NULL, GETDATE()),


		('8', '0801', 'Distrito Central', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0802', 'Alubar�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0803', 'Cedros', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0804', 'Curar�n', '1', 1, GETDATE(), NULL, GETDATE()),
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
		('8', '0823', 'Santa Luc�a', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0824', 'Talanga', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0825', 'Tatumbla', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0826', 'Valle de �ngeles', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0827', 'Villa de San Francisco', '1', 1, GETDATE(), NULL, GETDATE()),
		('8', '0828', 'Vallecillo', '1', 1, GETDATE(), NULL, GETDATE()),
		
		('9', '0901', 'Puerto Lempira', '1', 1, GETDATE(), NULL, GETDATE()),
		('9', '0902', 'Brus Laguna', '1', 1, GETDATE(), NULL, GETDATE()),
		('9', '0903', 'Ahuas', '1', 1, GETDATE(), NULL, GETDATE()),
		('9', '0904', 'Juan Francisco Bulnes', '1', 1, GETDATE(), NULL, GETDATE()),
		('9', '0905', 'Ram�n Villeda Morales', '1', 1, GETDATE(), NULL, GETDATE()),
		('9', '0906', 'Wampusirpe', '1', 1, GETDATE(), NULL, GETDATE()),
		
		('10', '1001', 'La Esperanza', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1002', 'Camasca', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1003', 'Colomoncagua', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1004', 'Concepci�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1005', 'Dolores', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1006', 'Intibuc�', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1007', 'Jes�s de Otoro', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1008', 'Magdalena', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1009', 'Masaguara', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1010', 'San Antonio', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1011', 'San Isidro', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1012', 'San Juan', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1013', 'San Marcos de la Sierra', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1014', 'San Miguel Guancapla', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1015', 'Santa Luc�a', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1016', 'Yamaranguila', '1', 1, GETDATE(), NULL, GETDATE()),
		('10', '1017', 'San Francisco de Opalaca', '1', 1, GETDATE(), NULL, GETDATE()),


		('11', '1101', 'Roat�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('11', '1102', 'Guanaja', '1', 1, GETDATE(), NULL, GETDATE()),
		('11', '1103', 'Jos� Santos Guardiola', '1', 1, GETDATE(), NULL, GETDATE()),
		('11', '1104', 'Utila', '1', 1, GETDATE(), NULL, GETDATE()),


		('12', '1201', 'La Paz', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1202', 'Aguanqueterique', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1203', 'Caba�as', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1204', 'Cane', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1205', 'Chinacla', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1206', 'Guajiquiro', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1207', 'Lauterique', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1208', 'Marcala', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1209', 'Mercedes de Oriente', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1210', 'Opatoro', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1211', 'San Antonio del Norte', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1212', 'San Jos�', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1213', 'San Juan', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1214', 'San Pedro de Tutule', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1215', 'Santa Ana', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1216', 'Santa Elena', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1217', 'Santa Mar�a', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1218', 'Santiago de Puringla', '1', 1, GETDATE(), NULL, GETDATE()),
		('12', '1219', 'Yarula', '1', 1, GETDATE(), NULL, GETDATE()),


		('13', '1301', 'Gracias', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1302', 'Bel�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1303', 'Candelaria', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1304', 'Cololaca', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1305', 'Erandique', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1306', 'Gualcince', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1307', 'Guarita', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1308', 'La Campa', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1309', 'La Iguala', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1310', 'Las Flores', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1311', 'La Uni�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1312', 'La Virtud', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1313', 'Lepaera', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1314', 'Mapulaca', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1315', 'Piraera', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1316', 'San Andr�s', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1317', 'San Francisco', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1318', 'San Juan Guarita', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1319', 'San Manuel Colohete', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1320', 'San Rafael', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1321', 'San Sebasti�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1322', 'Santa Cruz', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1323', 'Talgua', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1324', 'Tambla', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1325', 'Tomal�', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1326', 'Valladolid', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1327', 'Virginia', '1', 1, GETDATE(), NULL, GETDATE()),
		('13', '1328', 'San Marcos de Caiqu�n', '1', 1, GETDATE(), NULL, GETDATE()),


		('14', '1401', 'Ocotepeque', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1402', 'Bel�n Gualcho', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1403', 'Concepci�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1404', 'Dolores Merend�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1405', 'Fraternidad', '1', 1, GETDATE(), NULL, GETDATE()),
		('14', '1406', 'La Encarnaci�n', '1', 1, GETDATE(), NULL, GETDATE()),
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
		('15', '1505', 'Dulce Nombre de Culm�', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1506', 'El Rosario', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1507', 'Esquipulas del Norte', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1508', 'Gualaco', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1509', 'Guarizama', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1510', 'Guata', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1511', 'Guayape', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1512', 'Jano', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1513', 'La Uni�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1514', 'Mangulile', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1515', 'Manto', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1516', 'Salam�', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1517', 'San Esteban', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1518', 'San Francisco de Becerra', '1',1, GETDATE(), NULL, GETDATE()),
		('15', '1519', 'San Francisco de la Paz', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1520', 'Santa Mar�a del Real', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1521', 'Silca', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1522', 'Yoc�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('15', '1523', 'Patuca', '1', 1, GETDATE(), NULL, GETDATE()),


		('16', '1601' , 'Santa B�rbara', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1602' , 'Arada', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1603' , 'Atima', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1604' , 'Azacualpa', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1605' , 'Ceguaca', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1606' , 'Concepci�n del Norte', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1607' , 'Concepci�n del Sur', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1608' , 'Chinda', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1609' , 'El N�spero', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1610' , 'Gualala', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1611' , 'Ilama', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1612' , 'Las Vegas', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1613' , 'Macuelizo', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1614' , 'Naranjito', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1615' , 'Nuevo Celilac', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1616' , 'Nueva Frontera', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1617' , 'Petoa', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1618' , 'Protecci�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1619' , 'Quimist�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1620' , 'San Francisco de Ojuera', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1621' , 'San Jos� de las Colinas', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1622' , 'San Luis', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1623' , 'San Marcos', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1624' , 'San Nicol�s', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1625' , 'San Pedro Zacapa', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1626' , 'San Vicente Centenario', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1627' , 'Santa Rita', '1', 1, GETDATE(), NULL, GETDATE()),
		('16', '1628' , 'Trinidad', '1', 1, GETDATE(), NULL, GETDATE()),


		('17', '1701', 'Nacaome', '1', 1, GETDATE(), NULL, GETDATE()),
		('17', '1702', 'Alianza', '1', 1, GETDATE(), NULL, GETDATE()),
		('17', '1703', 'Amapala', '1', 1, GETDATE(), NULL, GETDATE()),
		('17', '1704', 'Aramecina', '1', 1, GETDATE(), NULL, GETDATE()),
		('17', '1705', 'Caridad', '1', 1, GETDATE(), NULL, GETDATE()),
		('17', '1706', 'Goascor�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('17', '1707', 'Langue', '1', 1, GETDATE(), NULL, GETDATE()),
		('17', '1708', 'San Francisco de Coray', '1', 1, GETDATE(), NULL, GETDATE()),
		('17', '1709', 'San Lorenzo', '1', 1, GETDATE(), NULL, GETDATE()),


		('18', '1801', 'Yoro', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1802', 'Arenal', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1803', 'El Negrito', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1804', 'El Progreso', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1805', 'Joc�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1806', 'Moraz�n', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1807', 'Olanchito', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1808', 'Santa Rita', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1809', 'Sulaco', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1810', 'Victoria', '1', 1, GETDATE(), NULL, GETDATE()),
		('18', '1811', 'Yorito', '1', 1, GETDATE(), NULL, GETDATE());


--********** CARGOS TABLE ***************--
GO
INSERT INTO [lice].[tbCargos] (carg_Descripcion, carg_UsuCreacion, carg_UsuModificacion, carg_FechaModificacion)
VALUES	('Instructor de Manejo'	,1,NULL,NULL),
		('Inpector de Manejo'	,1,NULL,NULL),
		('Tenico Mecanito'		,1,NULL,NULL),
		('Analista Final'		,1,NULL,NULL);
GO
		--** TIPOS LICENCIA TABLE ***--
INSERT INTO lice.tbTiposLicencias (tili_Descripcion, tili_UsuCreacion, tili_UsuModificacion, tili_FechaModificacion)
VALUES    ('Liviana', 1, NULL, NULL),
        ('Pesada',    1, NULL, NULL),
        ('Moto',    1, NULL, NULL);

--********** CARGOS TABLE ***************--
GO
INSERT INTO [lice].[tbSucursales] (sucu_Nombre, muni_Id, sucu_Direccion, sucu_UsuCreacion, sucu_UsuModificacion, sucu_FechaModificacion)
VALUES	('Servicios Policiales San Marcos',	63,	'Col. Satelite'			,1,NULL, NULL ),
		('Centro de Capacitacion Vial',		110,'Col. Lopez Arellano'	,1,NULL, NULL );
		

--********** EMPLEADOS TABLE ***************--
GO
INSERT INTO [lice].[tbEmpleados] (empe_Nombres, empe_Apellidos, empe_Identidad, empe_FechaNacimiento, empe_Sexo, eciv_Id, muni_Id, empe_DireccionExacta, empe_Telefono, empe_CorreoElectronico, sucu_Id, carg_Id, empe_UsuCreacion,  empe_UsuModificacion, empe_FechaModificacion)
VALUES	('Lionel',	'Messi',	'0309-1986-00998', '10-07-1986', 'M', 1, 1, 'calle y #444',	'88264741',  'leoMessi@gmail.com',			1, 1, 1,NULL, NULL),
		('Ana',		'Garc�a',	'1234-5678-90123', '1990-06-15', 'F', 1, 15,'Calle A #123',	'2233-4455', 'ana.garcia@email.com',		1, 1, 1,NULL, NULL),
		('Juan',	'P�rez',	'0801-1999-01234', '1999-01-08', 'M', 2, 22,'Avenida B #456', '9988-7766', 'juan.perez@email.com',		2, 2, 1,NULL, NULL),
		('Mar�a',	'Fern�ndez','0404-1991-01234', '1991-04-04', 'F', 1, 3, 'Calle C #789',	'3344-5566', 'maria.fernandez@email.com',	1, 3, 1,NULL, NULL),
		('Pedro',	'L�pez',	'1509-1988-01234', '1988-09-15', 'M', 2, 41,'Avenida D #1011','6677-8899', 'pedro.lopez@email.com',		2, 2, 1,NULL, NULL),
		('Sof�a',	'Hern�ndez','2802-1996-01234', '1996-02-28', 'F', 1, 52,'Calle E #1213',	'9900-1122', 'sofia.hernandez@email.com',	1, 1, 1,NULL, NULL),
		('Carlos',	'Guti�rrez','2207-1985-01234', '1985-07-22', 'M', 2, 6, 'Avenida F #1415','5544-3322', 'carlos.gutierrez@email.com',	2, 2, 1,NULL, NULL),
		('Luisa',	'Mart�nez', '0703-1981-01234', '1981-03-07', 'F', 1, 37,'Calle G #1617',	'8877-6655', 'luisa.martinez@email.com',	1, 3, 1,NULL, NULL),
		('Javier',	'D�az',		'2705-1994-01234', '1994-05-27', 'M', 2, 8, 'Avenida H #1819','4455-6677', 'javier.diaz@email.com',		2, 4, 1,NULL, NULL);



--********** SOLICITANTES TABLE ***************--
INSERT INTO [lice].[tbSolicitantes] (soli_Nombre, soli_Apellido, soli_Identidad, muni_Id, soli_Sexo, soli_FechaNacimiento,  soli_Telefono, soli_Direccion, soli_UsuCreacion, soli_UsuModificacion, soli_FechaModificacion)
VALUES 
('Ana',		'Garc�a',	'1234567890123', 1, 'F', '1990-06-15', '2233-4455','calle y #444',	  1, NULL, NULL),
('Juan',	'P�rez',	'0801199901234', 2, 'M', '1999-01-08', '9988-7766','Calle A #123',	  1, NULL, NULL),
('Mar�a',	'Fern�ndez','0404199101234', 3, 'F', '1991-04-04', '3344-5566','Avenida B #456',  1, NULL, NULL),
('Pedro',	'L�pez',	'1509198801234', 4, 'M', '1988-09-15', '6677-8899','Calle C #789',	  1, NULL, NULL),
('Sof�a',	'Hern�ndez','2802199601234', 5, 'F', '1996-02-28', '9900-1122','Avenida D #1011', 1, NULL, NULL),
('Carlos',	'Guti�rrez','2207198501234', 6, 'M', '1985-07-22', '5544-3322','Calle E #1213',	  1, NULL, NULL),
('Luisa',	'Mart�nez', '0703198101234', 7, 'F', '1981-03-07', '8877-6655','Avenida F #1415', 1, NULL, NULL),
('Javier',	'D�az',		'2705199401234', 8, 'M', '1994-05-27', '4455-6677','Calle G #1617',	  1, NULL, NULL),
('Fernanda','S�nchez',	'1808199201234', 9, 'F', '1992-08-18', '3322-5544','Avenida H #1819', 1, NULL, NULL),
('Daniel',	'Hern�ndez','2506199301234', 10,'M', '1993-06-25', '8899-3344','Avenida F #1415', 1, NULL, NULL);




--***************************UDP*****************************************--


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


  Go
CREATE OR ALTER PROCEDURE lice.UDP_tbTiposLicencias_Insert 
  @tili_Descripcion nvarchar(100),
  @tili_UsuCreacion int
AS
BEGIN
	BEGIN TRY
		IF EXISTS (SELECT * FROM lice.tbTiposLicencias WHERE tili_Descripcion = @tili_Descripcion AND tili_Estado = 1)
		BEGIN

			SELECT 2 as Proceso

		END
		ELSE IF NOT EXISTS (SELECT * FROM lice.tbTiposLicencias WHERE tili_Descripcion = @tili_Descripcion)
		BEGIN
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

			SELECT 1 as Proceso
		END
		ELSE
		BEGIN
			UPDATE lice.tbTiposLicencias
			SET	 tili_Estado = 1
				,tili_Descripcion = @tili_Descripcion
				,tili_UsuCreacion = @tili_UsuCreacion
				,tili_FechaCreacion = GETDATE()
				,tili_UsuModificacion = NULL
				,tili_FechaModificacion = NULL
			WHERE tili_Descripcion = @tili_Descripcion
		
			select 1
		END
			
	END TRY
	BEGIN CATCH
		SELECT 0 as Proceso
	END CATCH
END
GO
Select * from lice.tbTiposLicencias

  Go
CREATE OR ALTER PROCEDURE lice.UDP_tbTiposLicencias_Update
  @tili_Id			INT,
  @tili_Descripcion nvarchar(100),
  @tili_UsuModificacion int
AS
BEGIN
	BEGIN TRY
		IF EXISTS (SELECT * FROM lice.tbTiposLicencias WHERE (tili_Descripcion = @tili_Descripcion AND tili_Id != @tili_Id))
		BEGIN

			SELECT 2 as Proceso

		END
		ELSE
		BEGIN
		 
			UPDATE lice.tbTiposLicencias
			SET	 tili_Estado = 1
				,tili_Descripcion = @tili_Descripcion
				,tili_UsuModificacion = @tili_UsuModificacion
				,tili_FechaModificacion = GETDATE()
			WHERE tili_Id = @tili_Id

			SELECT 1 as Proceso
		END
			
	END TRY
	BEGIN CATCH
		SELECT 0 as Proceso
	END CATCH
END
GO



  Go
CREATE OR ALTER PROCEDURE lice.UDP_tbTiposLicencias_Delete
  @tili_Id INT
AS
BEGIN
	BEGIN TRY
		
		UPDATE lice.tbTiposLicencias
		SET tili_Estado = 0
		WHERE tili_Id = @tili_Id
		
		SELECT 1
	
	END TRY
	BEGIN CATCH
		SELECT 0 as Proceso
	END CATCH
END


GO
CREATE OR ALTER VIEW acce.VW_tbRoles_View
AS
SELECT T1.[role_Id]
      ,[role_Nombre]
      ,[role_UsuCreacion]
	  ,t2.user_NombreUsuario AS UsuarioCreacion
      ,[role_FechaCreacion]
      ,[role_UsuModificacion]
	  ,t3.user_NombreUsuario AS UsuarioModificacion
      ,[role_FechaModificacion]
      ,[role_Estado]
  FROM [acce].[tbRoles] T1 INNER JOIN acce.tbUsuarios T2
  ON T1.role_UsuCreacion = T2.user_Id LEFT JOIN acce.tbUsuarios T3
  ON T1.role_UsuModificacion = T3.user_Id


 GO
 CREATE OR ALTER PROCEDURE lice.UDP_VW_tbTiposLicencias_View_FIND
(@tili_Id INT)
AS
BEGIN
    SELECT * FROM lice.VW_tbTiposLicencias_View 
    WHERE tili_Id = @tili_Id;
END



  GO
  CREATE OR ALTER PROCEDURE acce.UDP_tbRoles_Select
  AS 
  BEGIN
  
  SELECT * FROM acce.VW_tbRoles_View
  WHERE role_Estado = 1

  END






  Go
CREATE OR ALTER PROCEDURE acce.UDP_tbRoles_Insert 
  @role_Nombre nvarchar(100),
  @role_UsuCreacion int
AS
BEGIN
    BEGIN TRY
        IF EXISTS (SELECT * FROM acce.tbRoles WHERE role_Nombre = @role_Nombre AND role_Estado = 1)
        BEGIN

            SELECT 2 as Proceso

        END
        ELSE IF NOT EXISTS (SELECT * FROM acce.tbRoles WHERE role_Nombre = @role_Nombre)
        BEGIN
		INSERT INTO [acce].[tbRoles]
				   ([role_Nombre]
				   ,[role_UsuCreacion]
				   ,[role_FechaCreacion]
				   ,[role_UsuModificacion]
				   ,[role_FechaModificacion]
				   ,[role_Estado])
			 VALUES
				   (@role_Nombre
				   ,@role_UsuCreacion
				   ,GETDATE()
				   ,Null
				   ,Null
				   ,1)

            SELECT 1 as Proceso
        END
        ELSE
        BEGIN
            UPDATE acce.tbRoles
            SET  role_Estado = 1
				,role_Nombre = @role_Nombre
				,role_UsuCreacion = @role_UsuCreacion
				,role_FechaCreacion = GETDATE()
				,role_UsuModificacion = NULL
				,role_FechaModificacion = NULL
            WHERE role_Nombre = @role_Nombre

            select 1
        END

    END TRY
    BEGIN CATCH
        SELECT 0 as Proceso
    END CATCH
END
GO
Go
CREATE OR ALTER PROCEDURE acce.UDP_tbRoles_Update
  @role_Id				INT,
  @role_Nombre			nvarchar(100),
  @role_UsuModificacion INT
AS
BEGIN
    BEGIN TRY
        IF EXISTS (SELECT * FROM acce.tbRoles WHERE (role_Nombre = @role_Nombre AND role_Id != @role_Id))
        BEGIN

            SELECT 2 as Proceso

        END
        ELSE
        BEGIN

			UPDATE acce.tbRoles
				SET  role_Estado = 1
					,role_Nombre = @role_Nombre
					,role_UsuModificacion = @role_UsuModificacion
					,role_FechaModificacion = GETDATE()
				WHERE role_Id = @role_Id


            SELECT 1 as Proceso
        END

    END TRY
    BEGIN CATCH
        SELECT 0 as Proceso
    END CATCH
END
GO
  Go
CREATE OR ALTER PROCEDURE acce.UDP_tbRoles_Delete
  @role_Id INT
AS
BEGIN
	BEGIN TRY
		
		UPDATE acce.tbRoles
		SET role_Estado = 0
		WHERE role_Id = @role_Id
		
		SELECT 1
	
	END TRY
	BEGIN CATCH
		SELECT 0 as Proceso
	END CATCH
END
GO


GO
CREATE OR ALTER VIEW acce.VW_tbPantallasPorRoles_View
AS
SELECT [prol_Id]
      ,T1.[role_Id]
	  ,T4.role_Nombre
      ,T1.[pant_Id]
	  ,T5.pant_Nombre
	  ,T5.pant_Url
	  ,T5.pant_Menu
	  ,T5.pant_HtmlId
      ,[prol_UsuCreacion]
	  ,t2.user_NombreUsuario AS UsuarioCreacion
      ,[prol_FechaCreacion]
      ,[prol_UsuModificacion]
	  ,t3.user_NombreUsuario AS UsuarioModificacion
      ,[prol_FechaModificacion]
      ,[prol_Estado]
  FROM [acce].[tbPantallasPorRoles] T1 INNER JOIN acce.tbRoles T4
  ON T4.role_Id = T1.role_Id INNER JOIN acce.tbPantallas T5
  ON T5.pant_Id = T1.pant_Id INNER JOIN acce.tbUsuarios T2
  ON T1.prol_UsuCreacion = T2.[user_Id] LEFT JOIN acce.tbUsuarios T3
  ON T1.prol_UsuModificacion = T3.[user_Id]


  GO
  CREATE OR ALTER PROCEDURE acce.UDP_tbPantallasPorRoles_Select
  AS 
  BEGIN
  
  SELECT * FROM acce.VW_tbPantallasPorRoles_View
  WHERE prol_Estado = 1

  END
  GO
  GO

CREATE OR ALTER PROCEDURE acce.UDP_tbPantallasPorRoles_Insert 
	@role_Id int,
	@pant_Id int,
	@prol_UsuCreacion int
AS
BEGIN
    BEGIN TRY
        IF EXISTS (SELECT * FROM acce.tbPantallasPorRoles WHERE role_Id = @role_Id AND pant_Id = @pant_Id AND prol_Estado = 1)
        BEGIN

            SELECT 2 as Proceso

        END
        ELSE IF NOT EXISTS (SELECT * FROM acce.tbPantallasPorRoles WHERE role_Id = @role_Id AND pant_Id = @pant_Id)
        BEGIN
		INSERT INTO [acce].[tbPantallasPorRoles]
           ([role_Id]
           ,[pant_Id]
           ,[prol_UsuCreacion]
           ,[prol_FechaCreacion]
           ,[prol_UsuModificacion]
           ,[prol_FechaModificacion]
           ,[prol_Estado])
     VALUES
           (@role_Id
           ,@pant_Id
           ,@prol_UsuCreacion
           ,GETDATE()
           ,NULL
           ,NULL
           ,1)

            SELECT 1 as Proceso
        END
        ELSE
        BEGIN
            UPDATE acce.tbPantallasPorRoles
            SET  prol_Estado = 1
				,prol_UsuCreacion = @prol_UsuCreacion
				,prol_FechaCreacion = GETDATE()
				,prol_UsuModificacion = NULL
				,prol_FechaModificacion = NULL
            WHERE role_Id = @role_Id AND pant_Id = @pant_Id

            select 1
        END

    END TRY
    BEGIN CATCH
        SELECT 0 as Proceso
    END CATCH
END
GO


CREATE OR ALTER PROCEDURE acce.UDP_tbPantallasPorRoles_Delete
	@role_Id int,
	@pant_Id int
AS
BEGIN
    BEGIN TRY
        
        UPDATE acce.tbPantallasPorRoles
        SET  prol_Estado = 0
        WHERE role_Id = @role_Id AND pant_Id = @pant_Id

        select 1
     
    END TRY
    BEGIN CATCH
        SELECT 0 as Proceso
    END CATCH
END
GO

GO
CREATE OR ALTER VIEW lice.VW_tbEmpleados_View
AS
SELECT T1.[empe_Id]
      ,[empe_Nombres]
      ,[empe_Apellidos]
	  ,[empe_Nombres] + ' ' +  [empe_Apellidos] AS empe_NombreCompleto
      ,[empe_Identidad]
      ,[empe_FechaNacimiento]
      ,[empe_Sexo]
      ,T1.[eciv_Id]
	  ,T4.eciv_Descripcion
      ,T1.[muni_Id]
	  ,T5.muni_Codigo
	  ,T5.muni_Nombre
	  ,T6.depa_Id
	  ,T6.depa_Codigo
	  ,T6.depa_Nombre
      ,[empe_DireccionExacta]
      ,[empe_Telefono]
      ,[empe_CorreoElectronico]
      ,T7.[sucu_Id]
	  ,T7.sucu_Nombre
      ,T8.[carg_Id]
	  ,T8.carg_Descripcion
      ,[empe_UsuCreacion]
	  ,t2.user_NombreUsuario AS UsuarioCreacion
      ,[empe_FechaCreacion]
      ,[empe_UsuModificacion]
	  ,t3.user_NombreUsuario AS UsuarioModificacion
      ,[empe_FechaModificacion]
      ,[empe_Estado]
  FROM [lice].[tbEmpleados] T1 INNER JOIN gral.tbEstadosCiviles T4
  ON T4.eciv_Id = T1.eciv_Id INNER JOIN gral.tbMunicipios T5
  ON T5.muni_Id = T1.muni_Id INNER JOIN gral.tbDepartamentos T6
  ON T5.depa_Id = T6.depa_Id INNER JOIN lice.tbSucursales T7
  ON T7.sucu_Id = T1.sucu_Id INNER JOIN lice.tbCargos T8
  ON T8.carg_Id	= T1.carg_Id INNER JOIN acce.tbUsuarios T2
  ON T1.empe_UsuCreacion = T2.[user_Id] LEFT JOIN acce.tbUsuarios T3
  ON T1.empe_UsuModificacion = T3.[user_Id]


  GO
  CREATE OR ALTER PROCEDURE lice.UDP_tbEmpleados_Select
  AS 
  BEGIN--das
  
  SELECT * FROM lice.VW_tbEmpleados_View
  WHERE empe_Estado = 1

  END
  GO

    GO
  CREATE OR ALTER PROCEDURE lice.UDP_tbEmpleados_Find
  @empe_Id	INT
  AS 
  BEGIN
  
  SELECT * FROM lice.VW_tbEmpleados_View
  WHERE empe_Id = @empe_Id

  END
  GO


  GO
  CREATE OR ALTER PROCEDURE lice.UDP_tbEmpleados_Insert 
	@empe_Nombres nvarchar(200),
	@empe_Apellidos nvarchar(200),
	@empe_Identidad varchar(15),
	@empe_FechaNacimiento date,
	@empe_Sexo char(1),
	@eciv_Id int,
	@muni_Id int,
	@empe_DireccionExacta nvarchar(250),
	@empe_Telefono nvarchar(20),
	@empe_CorreoElectronico nvarchar(200),
	@sucu_Id int,
	@carg_Id int,
	@empe_UsuCreacion int
AS
BEGIN
    BEGIN TRY
        
INSERT INTO [lice].[tbEmpleados]
           ([empe_Nombres]
           ,[empe_Apellidos]
           ,[empe_Identidad]
           ,[empe_FechaNacimiento]
           ,[empe_Sexo]
           ,[eciv_Id]
           ,[muni_Id]
           ,[empe_DireccionExacta]
           ,[empe_Telefono]
           ,[empe_CorreoElectronico]
           ,[sucu_Id]
           ,[carg_Id]
           ,[empe_UsuCreacion]
           ,[empe_FechaCreacion]
           ,[empe_UsuModificacion]
           ,[empe_FechaModificacion]
           ,[empe_Estado])
     VALUES
           (@empe_Nombres
           ,@empe_Apellidos
           ,@empe_Identidad
           ,@empe_FechaNacimiento
           ,@empe_Sexo
           ,@eciv_Id
           ,@muni_Id
           ,@empe_DireccionExacta
           ,@empe_Telefono
           ,@empe_CorreoElectronico
           ,@sucu_Id
           ,@carg_Id
           ,@empe_UsuCreacion
           ,Getdate()
           ,NULL
           ,NULL
           ,1)


		SELECT 1
    END TRY
    BEGIN CATCH
        SELECT 0 as Proceso
    END CATCH
END
GO
Go
  CREATE OR ALTER PROCEDURE lice.UDP_tbEmpleados_Update
	@empe_Id INT,
	@empe_Nombres nvarchar(200),
	@empe_Apellidos nvarchar(200),
	@empe_Identidad varchar(15),
	@empe_FechaNacimiento date,
	@empe_Sexo char(1),
	@eciv_Id int,
	@muni_Id int,
	@empe_DireccionExacta nvarchar(250),
	@empe_Telefono nvarchar(20),
	@empe_CorreoElectronico nvarchar(200),
	@sucu_Id int,
	@carg_Id int,
	@empe_UsuModificacion int
AS
BEGIN
    BEGIN TRY
      
UPDATE [lice].[tbEmpleados]
   SET [empe_Nombres] = @empe_Nombres
      ,[empe_Apellidos] = @empe_Apellidos
      ,[empe_Identidad] = @empe_Identidad
      ,[empe_FechaNacimiento] = @empe_FechaNacimiento
      ,[empe_Sexo] = @empe_Sexo
      ,[eciv_Id] = @eciv_Id
      ,[muni_Id] = @muni_Id
      ,[empe_DireccionExacta] = @empe_DireccionExacta
      ,[empe_Telefono] = @empe_Telefono
      ,[empe_CorreoElectronico] = @empe_CorreoElectronico
      ,[sucu_Id] = @sucu_Id
      ,[carg_Id] = @carg_Id
      ,[empe_UsuModificacion] =  @empe_UsuModificacion
      ,[empe_FechaModificacion] = GETDATE()
 WHERE empe_Id = @empe_Id

        SELECT 1 as Proceso

    END TRY
    BEGIN CATCH
        SELECT 0 as Proceso
    END CATCH
END
GO
  Go

  CREATE OR ALTER PROCEDURE lice.UDP_tbEmpleados_Delete
	@empe_Id INT
AS
BEGIN
	BEGIN TRY
		
		UPDATE lice.tbEmpleados
		SET empe_Estado = 0
		WHERE empe_Id = @empe_Id
		
		SELECT 1
	
	END TRY
	BEGIN CATCH
		SELECT 0 as Proceso
	END CATCH
END
GO




--*************************************
--********** tbSolicitante ***********--

--** ONSERT PROCEDURE **--
CREATE OR ALTER PROCEDURE lice.UDP_tbSolicitantes_INSERT
(@soli_Nombre NVARCHAR(200),
 @soli_Apellido NVARCHAR(200),
 @soli_Identidad NVARCHAR(13),
 @muni_Id INT,
 @soli_Sexo	CHAR(1),
 @soli_FechaNacimiento DATE,
 @soli_Direccion NVARCHAR(300),
 @soli_Telefono NVARCHAR(20),
 @soli_UsuCreacion INT)
AS
BEGIN
	BEGIN TRY
		IF EXISTS (SELECT * FROM lice.tbSolicitantes WHERE soli_Identidad = @soli_Identidad AND soli_Estado = 1 )
			BEGIN
				SELECT 2 AS Proceso
			END

		ELSE IF NOT EXISTS (SELECT * FROM lice.tbSolicitantes WHERE soli_Identidad = @soli_Identidad)
			BEGIN
				INSERT INTO [lice].[tbSolicitantes] (soli_Nombre, soli_Apellido, soli_Identidad, muni_Id, soli_Sexo, soli_FechaNacimiento, soli_Telefono, Soli_Direccion, soli_UsuCreacion, soli_UsuModificacion, soli_FechaModificacion)
				VALUES (@soli_Nombre, @soli_Apellido, @soli_Identidad, @muni_Id, @soli_Sexo, @soli_FechaNacimiento, @soli_Telefono, @soli_Direccion, @soli_UsuCreacion, NULL, NULL)
				SELECT 1 AS Proceso
			END

		ELSE
			BEGIN
				UPDATE lice.tbSolicitantes
				SET		[soli_Nombre] = @soli_Nombre,
						[soli_Apellido] = @soli_Apellido,
						[muni_Id] = @muni_Id,
						[soli_Sexo] = @soli_Sexo,
						[soli_FechaNacimiento] = @soli_FechaNacimiento,
						[soli_Telefono] = @soli_Telefono,
						[soli_Direccion] = @soli_Direccion,
						[soli_Estado] = 1,
						[soli_UsuCreacion] = @soli_UsuCreacion,
						[soli_FechaCreacion] = GETDATE(),
						[soli_UsuModificacion] = NULL,
						[soli_FechaModificacion] = NULL
				WHERE	soli_Identidad = @soli_Identidad

				SELECT 1 AS Proceso
			END
	END	TRY
	BEGIN CATCH
		SELECT 0 AS Proceso
	END CATCH
END


--** UPDATE PROCEDURE **--
GO
CREATE OR ALTER PROCEDURE lice.UDP_tbSolicitantes_UPDATE
(@soli_Id				INT,
 @soli_Nombre			NVARCHAR(200),
 @soli_Apellido			NVARCHAR(200),
 @soli_Identidad		NVARCHAR(13),
 @muni_Id				INT,
 @soli_Sexo				CHAR(1),
 @soli_FechaNacimiento	DATE,
 @soli_Telefono			NVARCHAR(20),
 @soli_Direccion		NVARCHAR(200),
 @soli_UsuModificacion	INT)
AS
BEGIN
	
	BEGIN TRY

		IF EXISTS (SELECT * FROM lice.tbSolicitantes WHERE (soli_Identidad = @soli_Identidad AND soli_Id != @soli_Id))
			BEGIN
				SELECT 2 AS Proceso 
			END
		ELSE
			BEGIN
				UPDATE [lice].[tbSolicitantes]
				   SET [soli_Nombre] = @soli_Nombre
					  ,[soli_Apellido] = @soli_Apellido
					  ,[soli_Identidad] = @soli_Identidad
					  ,[muni_Id] = @muni_Id
					  ,[soli_Sexo] = @soli_Sexo
					  ,[soli_FechaNacimiento] = @soli_FechaNacimiento
					  ,[soli_Telefono] = @soli_Telefono
					  ,[soli_Direccion] = @soli_Direccion
					  ,[soli_UsuModificacion] = @soli_UsuModificacion
					  ,[soli_FechaModificacion] = GETDATE()
				 WHERE soli_Id = @soli_Id

				 SELECT 1 AS Proceso
			END

	END TRY
	BEGIN CATCH
		SELECT 0 AS Proceso
	END CATCH
END


--** DELETE PROCEDURE **--
GO
CREATE OR ALTER PROCEDURE lice.UDP_tbSolicitantes_DELETE
(@soli_Id INT)
AS
BEGIN
	BEGIN TRY
		UPDATE	[lice].[tbSolicitantes]
		SET		soli_Estado = 0
		WHERE	soli_Id = @soli_Id

		SELECT 1 AS	Proceso
	END TRY
	BEGIN CATCH
		SELECT 0 AS Proceso 
	END CATCH
END


-- ** VISTA **--
GO
CREATE OR ALTER VIEW lice.VW_tbSolicitantes_View
AS
SELECT	soli_Id, 
		soli_Nombre, 
		soli_Apellido, 
		soli_Nombre + ' ' + soli_Apellido AS soli_NombreCompleto,
		soli_Identidad, 
		soli_Sexo, 
		soli_FechaNacimiento, 
		soli_Telefono, 
		T1.muni_Id,
		T2.muni_Nombre,
		T2.depa_Id,
		T3.depa_Nombre,
		soli_Direccion,
		soli_UsuCreacion,
		T4.user_NombreUsuario AS UsuarioCreacion,
		soli_FechaCreacion, 
		soli_UsuModificacion, 
		T5.user_NombreUsuario AS UsuarioModificacion,
		soli_FechaModificacion, 
		soli_Estado
FROM lice.tbSolicitantes AS T1 INNER JOIN gral.tbMunicipios AS T2
ON T1.muni_Id = T2.muni_Id INNER JOIN gral.tbDepartamentos AS T3 
ON T2.depa_Id = T3.depa_Id INNER JOIN ACCE.tbUsuarios AS T4
ON T1.soli_UsuCreacion = T4.[user_Id] LEFT JOIN acce.tbUsuarios AS T5
ON T1.soli_UsuModificacion = T5.[user_Id]


--*** RUN VIEW PROCEDURE ***--
GO
CREATE OR ALTER PROCEDURE lice.UDP_tbSolicitantes_SELECT
AS
BEGIN
	SELECT * FROM VW_tbSolicitantes_View
	WHERE soli_Estado = 1
END



--*** FIND PROCEDURE ***--
GO
CREATE OR ALTER PROCEDURE lice.UDP_VW_tbSolicitantes_View_FIND
(@soli_Id INT)
AS
BEGIN
	SELECT * FROM VW_tbSolicitantes_View
	WHERE soli_Id = @soli_Id;
END


--*****************************************************************************--
--*****************************************************************************--
-- ************************* TABLA USUARIOS **/**********************--
GO
ALTER TABLE [acce].[tbUsuarios]
ADD CONSTRAINT FK_acce_tbUsuarios_lice_tbEmpleados_empe_Id FOREIGN KEY(empe_Id) REFERENCES lice.tbEmpleados(empe_Id)

---***  INSERT PROCEDURE ***---
GO
CREATE OR ALTER PROCEDURE acce.UDP_tbusuarios_INSERT
(@user_NombreUsuario NVARCHAR(100),
 @user_Contrasena NVARCHAR(MAX),
 @user_EsAdmin BIT,
 @role_Id INT,
 @empe_Id INT,
 @user_UsuCreacion INT)
AS
BEGIN
	BEGIN TRY
		IF EXISTS (SELECT * FROM acce.tbUsuarios WHERE user_NombreUsuario = @user_NombreUsuario AND user_Estado = 1 )
			BEGIN
				SELECT 2 AS Proceso
			END

		ELSE IF NOT EXISTS (SELECT * FROM acce.tbUsuarios WHERE user_NombreUsuario = @user_NombreUsuario)
			BEGIN
				INSERT INTO [acce].[tbUsuarios] (user_NombreUsuario, user_Contrasena, user_EsAdmin, role_Id, empe_Id, user_UsuCreacion, user_UsuModificacion, user_FechaModificacion)
				VALUES (@user_NombreUsuario, @user_Contrasena, @user_EsAdmin, @role_Id, @empe_Id, @user_UsuCreacion, NULL, NULL)
				SELECT 1 AS Proceso

				SELECT 1 AS Proceso
			END
		ELSE
			BEGIN
				UPDATE [acce].[tbUsuarios]
				SET [user_Estado] = 1,
					[user_UsuCreacion] = @user_UsuCreacion,
					[user_FechaCreacion] = GETDATE(),
					[user_UsuModificacion] = NULL,
					[user_FechaModificacion] = NULL
				WHERE [user_NombreUsuario] = @user_NombreUsuario;

				SELECT 1 AS Proceso;
			END

	END TRY
	BEGIN CATCH
		SELECT 0 AS Processo
	END CATCH
END
 

--** UPDATE PROCEDURE **--
GO
CREATE OR ALTER PROCEDURE acce.UDP_tbusuarios_UPDATE
(@user_Id INT,
 @user_EsAdmin BIT,
 @role_Id INT,
 @empe_Id INT,
 @user_UsuModificacion INT)
AS
BEGIN
	BEGIN TRY
		UPDATE [acce].[tbUsuarios]
		SET [user_EsAdmin] = @user_EsAdmin,
			[role_Id] = @role_Id,
			[empe_Id] = @empe_Id,
			[user_UsuModificacion] = @user_UsuModificacion,
			[user_FechaModificacion] = GETDATE()
		WHERE [user_Id] = @user_Id;
		SELECT 1 AS Proceso;

	END TRY
	BEGIN CATCH
		SELECT 0 AS Proceso;

	END CATCH
END


--** DELETE PROCEDURE **--
GO
CREATE OR ALTER PROCEDURE acce.UDP_tbusuarios_DELETE
(@user_Id INT)
AS
BEGIN
	BEGIN TRY
		UPDATE [acce].[tbUsuarios]
		SET [user_Estado]  = 0,
			[user_FechaModificacion] = GETDATE()
		WHERE [user_Id] = @user_Id

		SELECT 1 AS Proceso

	END TRY
	BEGIN CATCH
		SELECT 0 AS Proceso
	END CATCH
END


---*** VIEW ***---
GO
CREATE OR ALTER VIEW acce.VW_tbUsuarios_View
AS
SELECT T1.[user_Id]
      ,T1.[user_NombreUsuario]
      ,T1.[user_Contrasena]
      ,T1.[user_EsAdmin]
      ,T1.[role_Id]
	  ,T4.role_Nombre
      ,T1.[empe_Id]
	  ,T5.empe_Nombres
	  ,T5.empe_Apellidos
	  ,T5.empe_Nombres + ' ' + T5.empe_Apellidos As empe_NombreCompleto
	  ,T5.sucu_Id
	  ,T7.sucu_Nombre
	  ,T5.carg_Id
	  ,T6.carg_Descripcion
      ,T1.[user_UsuCreacion]
      ,T1.[user_FechaCreacion]
      ,T1.[user_UsuModificacion]
      ,T1.[user_FechaModificacion]
      ,T1.[user_Estado]
  FROM [acce].[tbUsuarios] T1 LEFT JOIN acce.tbRoles T4
  ON T1.role_Id = T4.role_Id INNER JOIN lice.tbEmpleados T5
  ON T1.empe_Id = T5.empe_Id INNER JOIN lice.tbCargos T6
  ON T5.carg_Id = T6.carg_Id INNER JOIN Lice.tbSucursales T7 
  ON T5.sucu_Id = T7.sucu_Id INNER JOIN acce.tbUsuarios T2
  ON T1.user_UsuCreacion = T2.[user_Id] LEFT JOIN acce.tbUsuarios T3
  ON T1.user_UsuModificacion = T3.[user_Id]


--*** RUN VIEW PROCEDURE ***--
GO
CREATE OR ALTER PROCEDURE acce.UDP_tbUsuarios_SELECT
AS
BEGIN
	SELECT * FROM acce.VW_tbUsuarios_View
	WHERE user_Estado = 1
END


--*** FIND PROCEDURE ***--
GO
CREATE OR ALTER PROCEDURE acce.UDP_VW_tbUsuarios_View_FIND 
(@user_Id INT)
AS
BEGIN
	SELECT * FROM acce.VW_tbUsuarios_View
	WHERE [user_Id] = @user_Id;
END


 --*****************************************************************************--
--*****************************************************************************--
-- ************************* TABLA SOLICITUD **/**********************--
-- ************************* TABLA SOLICITUD **/**********************--

---***  INSERT PROCEDURE ***---
GO
CREATE OR ALTER PROCEDURE lice.UDP_tbSolicitud_INSERT 
(@soli_Id INT,
 @sucu_Id INT,
 @tili_Id INT,
 @stud_Pago BIT,
 @stud_UsuCreacion INT)
AS
BEGIN 

	BEGIN TRY
		
			INSERT INTO [lice].[tbSolicitud]
				   ([soli_Id]
				   ,[sucu_Id]
				   ,[tili_Id]
				   ,[stud_Pago] 
				   ,[stud_UsuCreacion]
				   ,[stud_UsuModificacion]
				   ,[stud_FechaModificacion])
			 VALUES
				   (@soli_Id
				   ,@sucu_Id
				   ,@tili_Id
				   ,@stud_Pago
				   ,@stud_UsuCreacion
				   ,NULL
				   ,NULL)
			SELECT 1 AS Proceso
	END TRY
	BEGIN CATCH
		SELECT 0 AS Proceso
	END CATCH
END



---***  UPDATE PROCEDURE ***---
GO
CREATE OR ALTER PROCEDURE lice.UDP_tbSolicitud_UPDATE
(@stud_Id INT,
 @sucu_Id INT,
 @tili_Id INT,
 @stud_Pago BIT,
 @stud_UsuModificacion INT)
AS
BEGIN
	BEGIN TRY
		
		UPDATE [lice].[tbSolicitud]
		   SET [sucu_Id] = @sucu_Id
			  ,[tili_Id] = @tili_Id
			  ,[stud_Pago] = @stud_Pago
			  ,[stud_UsuModificacion] = @stud_UsuModificacion
			  ,[stud_FechaModificacion] = GETDATE()
		 WHERE [stud_Id] = @stud_Id;

		 SELECT 1 AS Proceso
	END TRY
	BEGIN CATCH
		 SELECT 0 AS Proceso
	END CATCH
END

---***  DELETE PROCEDURE ***---
GO
CREATE OR ALTER PROCEDURE lice.UDP_tbSolicitud_DELETE
(@stud_Id INT)
AS
BEGIN
	BEGIN TRY
		
		UPDATE [lice].[tbSolicitud]
		   SET [stud_Estado] = 0
			  ,[stud_FechaModificacion] = GETDATE()
		 WHERE [stud_Id] = @stud_Id;

		 SELECT 1 AS Proceso
	END TRY
	BEGIN CATCH
		 SELECT 0 AS Proceso
	END CATCH
END



--- VISTA ---
GO
CREATE OR ALTER VIEW lice.VW_tbSolicitud_View
AS
SELECT    stud_Id, 
        T1.soli_Id, 
        T2.soli_Nombre,
        T2.soli_Apellido,
        T2.soli_Nombre + ' ' + T2.soli_Apellido AS soli_NombreCompleto,
        T1.sucu_Id, 
        T3.sucu_Nombre,
        T1.tili_Id, 
        T4.tili_Descripcion,
        stud_Pago,
        stud_Intentos,
        stud_UsuCreacion, 
        T5.user_NombreUsuario AS UsuarioCreacion,
        stud_FechaCreacion, 
        stud_UsuModificacion, 
        T6.user_NombreUsuario AS UsuarioModificacion,
        stud_FechaModificacion, 
        stud_Estado
FROM [lice].[tbSolicitud] AS T1 INNER JOIN [lice].[tbSolicitantes] AS T2
ON T1.soli_Id = T2.soli_Id INNER JOIN [lice].[tbSucursales] AS T3
ON T1.sucu_Id = T3.sucu_Id INNER JOIN [lice].[tbTiposLicencias] AS T4
ON T1.tili_Id = T4.tili_Id INNER JOIN [acce].[tbUsuarios] AS T5 
ON T1.stud_UsuCreacion = T5.[user_Id] LEFT JOIN [acce].[tbUsuarios] AS T6
ON T1.stud_UsuModificacion = T6.[user_Id]


--*** RUN VIEW PROCEDURE ***--
GO
CREATE OR ALTER PROCEDURE lice.UDP_tbSolicitud_SELECT
AS
BEGIN
	SELECT * FROM LICE.VW_tbSolicitud_View
	WHERE stud_Estado = 1;
END


--*** FIND PROCEDURE ***--
GO
CREATE OR ALTER PROCEDURE lice.UDP_VW_tbSolicitud_View_FIND
(@stud_Id INT)
AS
BEGIN
	SELECT * FROM VW_tbSolicitud_View
	WHERE stud_Id = @stud_Id;
END


--*****************************************************************************--
--*****************************************************************************--
-- ****************************** TABLA APROVADOS *****************************--


---*** REJECT PROCEDURE ***---
GO
CREATE OR ALTER PROCEDURE lice.UDP_tbSolicitud_REJECT
(@stud_Id INT,
 @empe_Id INT,
 @rech_Observaciones NVARCHAR(500),
 @rech_UsuCreacion INT)
AS
BEGIN 
	BEGIN TRY

		UPDATE	lice.tbSolicitud
		SET		[stud_Intentos] = (SELECT [stud_Intentos] - 1 FROM lice.tbSolicitud WHERE stud_Id = @stud_Id)
		WHERE	stud_Id = @stud_Id;

		IF((SELECT [stud_Intentos] FROM lice.tbSolicitud WHERE stud_Id = @stud_Id) = 0) 
			BEGIN
				UPDATE lice.tbSolicitud
				SET stud_Estado = 0
				WHERE stud_Id = @stud_Id
			 END

		IF((SELECT [stud_Intentos] FROM lice.tbSolicitud WHERE stud_Id = @stud_Id) >= 0) 
			BEGIN

				INSERT INTO lice.tbRechazados (stud_Id, empe_Id, rech_Observaciones, rech_Fecha, rech_UsuCreacion, rech_UsuModificacion, rech_FechaModificacion) 
				VALUES	(@stud_Id, @empe_Id, @rech_Observaciones, GETDATE(), @rech_UsuCreacion, NULL, NULL );
				
			END
		
		SELECT 1 AS Proceso

	END TRY
	BEGIN CATCH
		SELECT 0 AS Proceso
	END CATCH
END




-- ** ACCEPT PROCEDURE **--
GO
CREATE OR ALTER PROCEDURE lice.UDP_tbSolicitud_ACCEPT
(@stud_Id INT,
 @empe_Id INT,
 @apro_Observaciones NVARCHAR(500),
 @apro_UsuCreacion INT)
AS
BEGIN
	BEGIN TRY

	IF (SELECT stud_Pago FROM lice.tbSolicitud WHERE stud_Id = @stud_Id) = 1
	BEGIN

		IF EXISTS (SELECT * FROM lice.tbAprobados WHERE stud_Id = @stud_Id AND apro_Estado = 1 )
			BEGIN
				SELECT 2 AS Proceso
			END
		ELSE IF NOT EXISTS (SELECT * FROM lice.tbAprobados WHERE stud_Id = @stud_Id)
			BEGIN			

INSERT INTO [lice].[tbAprobados]
           ([stud_Id]
           ,[empe_Id]
           ,[apro_Observaciones]
           ,[apro_Intentos]
           ,[apro_Fecha]
           ,[apro_UsuCreacion]
           ,[apro_FechaCreacion]
           ,[apro_UsuModificacion]
           ,[apro_FechaModificacion]
           ,[apro_Estado])
     VALUES
           (@stud_Id
           ,@empe_Id
           ,@apro_Observaciones
           ,6 - (SELECT stud_Intentos FROM lice.tbSolicitud WHERE stud_Id = @stud_Id)
           ,GETDATE()
           ,@apro_UsuCreacion
           ,GETDATE()
           ,null
           ,null
           ,1)

		UPDATE [lice].[tbSolicitud]
		   SET [stud_Estado] = 0
		 WHERE stud_Id = @stud_Id




						SELECT 1 AS Proceso
			END
		ELSE
			BEGIN
				UPDATE	[lice].[tbAprobados]
				SET		apro_Estado = 1,
						apro_UsuCreacion = @apro_UsuCreacion,
						apro_FechaCreacion = GETDATE(),
						apro_UsuModificacion = NULL,
						apro_FechaModificacion = NULL
				WHERE	[stud_Id] = @stud_Id
			END
			SELECT 1 AS Proceso
		END
		ELSE
		BEGIN
			SELECT 99
		END
	END TRY
	BEGIN CATCH
		SELECT 0 AS Proceso
	END CATCH
END



---- ** UPDATE PROCEDURE **--
--GO
--CREATE OR ALTER PROCEDURE lice.UDP_tbAprobados_UPDATE
--(@apro_Id INT,
-- @stud_Id INT,
-- @empe_Id INT,
-- @apro_Aceptado BIT,
-- @apro_Observaciones NVARCHAR(500),
-- @apro_Fecha DATE,
-- @apro_UsuModificacion INT)
--AS
--BEGIN
--	BEGIN TRY
--		IF EXISTS (SELECT * FROM lice.tbAprobados WHERE (stud_Id = @stud_Id AND apro_Id != @apro_Id))
--			BEGIN
--				SELECT 2 AS Proceso 
--			END
--		ELSE
--			BEGIN

--				UPDATE [lice].[tbAprobados]
--				   SET [stud_Id] = @stud_Id
--					  ,[empe_Id] = @empe_Id
--					  ,[apro_Aceptado] = @apro_Aceptado
--					  ,[apro_Observaciones] = @apro_Observaciones
--					  ,[apro_Fecha] = @apro_Fecha
--					  ,[apro_UsuModificacion] = @apro_UsuModificacion
--					  ,[apro_FechaModificacion] = GETDATE()
--				 WHERE apro_Id = @apro_Id

--				SELECT 1 AS Proceso;
--			END
--	END TRY
--	BEGIN CATCH
--				SELECT 0 AS Proceso;
--	END CATCH
--END


-- ** DELETE PROCEDURE **--
GO
CREATE OR ALTER PROCEDURE lice.UDP_tbAprobados_DELETE
(@apro_Id INT)
AS
BEGIN
	BEGIN TRY
		UPDATE	[lice].[tbAprobados]
		SET		apro_Estado = 0
		WHERE	apro_Id = @apro_Id;

		SELECT 1 AS Proceso;
	END TRY
	BEGIN CATCH
		SELECT 0 AS Proceso;
	END CATCH
END


---*** VISTA ***---
GO
CREATE OR ALTER VIEW lice.VW_tbAprobados_View
AS
SELECT	apro_Id, 
		T1.stud_Id, 
		T5.soli_Id,
		T6.soli_Nombre,
		T6.soli_Apellido,
		T6.soli_Nombre + ' ' + T6.soli_Apellido AS soli_NombreCompleto,
		T6.soli_Identidad,
		T6.soli_Sexo,
		T7.tili_Id,
		T7.tili_Descripcion,
		T8.sucu_Id,
		T8.[sucu_Nombre],
		T1.empe_Id, 
		T2.empe_Nombres,
		T2.empe_Apellidos,
		T2.empe_Nombres + ' ' + T2.empe_Apellidos as empe_NombreCompleto,
		apro_Observaciones,
		T1.apro_Intentos, 
		apro_Fecha, 
		apro_UsuCreacion, 
		T3.user_NombreUsuario AS UsuarioCreacion,
		apro_FechaCreacion, 
		apro_UsuModificacion, 
		T4.user_NombreUsuario AS UsuarioModificacion,
		apro_FechaModificacion, 
		apro_Estado
FROM [lice].[tbAprobados] AS T1 INNER JOIN [lice].[tbEmpleados] AS T2
ON T1.empe_Id = T2.empe_Id INNER JOIN [acce].[tbUsuarios] AS T3
ON T1.apro_UsuCreacion = T3.[user_Id] LEFT JOIN [acce].[tbUsuarios] AS T4
ON T1.apro_UsuModificacion = T4.[user_Id] INNER JOIN lice.tbSolicitud T5
ON t5.stud_Id = T1.stud_Id INNER JOIN lice.tbSolicitantes T6
ON T6.soli_Id = T5.soli_Id INNER JOIN lice.tbTiposLicencias T7
ON t7.tili_Id = T5.tili_Id INNER JOIN Lice.tbSucursales T8
ON T8.sucu_Id = T5.sucu_Id



--*** RUN VIEW PROCEDURE ***--
GO
CREATE OR ALTER PROCEDURE lice.UDP_tbAprovados_SELECT
AS
BEGIN
	SELECT * FROM LICE.VW_tbAprobados_View
	WHERE apro_Estado = 1;
END
GO
GO
CREATE OR ALTER PROCEDURE lice.UDP_tbAprovados_Find
@apro_Id INT
AS
BEGIN
	SELECT * FROM LICE.VW_tbAprobados_View
	WHERE apro_Id = @apro_Id;
END
GO


GO
GO
CREATE OR ALTER VIEW lice.VW_tbRechazados_View
AS
SELECT	rech_Id, 
		T1.stud_Id, 
		T5.soli_Id,
		T6.soli_Nombre,
		T6.soli_Apellido,
		T6.soli_Nombre + ' ' + T6.soli_Apellido AS soli_NombreCompleto,
		T6.soli_Identidad,
		T6.soli_Sexo,
		T7.tili_Id,
		T7.tili_Descripcion,
		T8.sucu_Id,
		T8.[sucu_Nombre],
		T1.empe_Id, 
		T2.empe_Nombres,
		T2.empe_Apellidos,
		T2.empe_Nombres + ' ' + T2.empe_Apellidos as empe_NombreCompleto,
		rech_Observaciones, 
		rech_Fecha, 
		rech_UsuCreacion, 
		T3.user_NombreUsuario AS UsuarioCreacion,
		rech_FechaCreacion, 
		rech_UsuModificacion, 
		T4.user_NombreUsuario AS UsuarioModificacion,
		rech_FechaModificacion, 
		rech_Estado
FROM [lice].[tbRechazados] AS T1 INNER JOIN [lice].[tbEmpleados] AS T2
ON T1.empe_Id = T2.empe_Id INNER JOIN [acce].[tbUsuarios] AS T3
ON T1.rech_UsuCreacion = T3.[user_Id] LEFT JOIN [acce].[tbUsuarios] AS T4
ON T1.rech_UsuModificacion = T4.[user_Id] INNER JOIN lice.tbSolicitud T5
ON t5.stud_Id = T1.stud_Id INNER JOIN lice.tbSolicitantes T6
ON T6.soli_Id = T5.soli_Id INNER JOIN lice.tbTiposLicencias T7
ON t7.tili_Id = T5.tili_Id INNER JOIN Lice.tbSucursales T8
ON T8.sucu_Id = T5.sucu_Id


GO
CREATE OR ALTER PROCEDURE lice.UDP_tbRechazados_SELECT
AS
BEGIN
	SELECT DISTINCT stud_Id,soli_Id, soli_Nombre, soli_Apellido, soli_NombreCompleto, soli_Identidad, soli_Sexo, tili_Id, tili_Descripcion, sucu_Id, [sucu_Nombre], empe_Id, empe_Nombres, empe_Apellidos, empe_NombreCompleto        
	FROM lice.VW_tbRechazados_View
	WHERE rech_Estado = 1
END
GO


GO
CREATE OR ALTER PROCEDURE lice.UDP_tbRechazados_SELECTXSolicitud
@stud_Id	INT
AS
BEGIN
	SELECT *        
	FROM lice.VW_tbRechazados_View
	WHERE rech_Estado = 1 AND stud_Id = @stud_Id
END
GO

GO
CREATE OR ALTER PROCEDURE lice.UDP_tbRechazados_Find
@stud_Id	INT
AS
BEGIN
	SELECT TOP(1) *        
	FROM lice.VW_tbRechazados_View
	WHERE rech_Estado = 1 AND stud_Id = @stud_Id
END
GO


GO
GO
CREATE OR ALTER VIEW lice.VW_tbRechazados_View
AS
SELECT	rech_Id, 
		T1.stud_Id, 
		T5.soli_Id,
		T6.soli_Nombre,
		T6.soli_Apellido,
		T6.soli_Nombre + ' ' + T6.soli_Apellido AS soli_NombreCompleto,
		T6.soli_Identidad,
		T6.soli_Sexo,
		T7.tili_Id,
		T7.tili_Descripcion,
		T8.sucu_Id,
		T8.sucu_Nombre,
		T1.empe_Id, 
		T2.empe_Nombres,
		T2.empe_Apellidos,
		T2.empe_Nombres + ' ' + T2.empe_Apellidos as empe_NombreCompleto,
		rech_Observaciones, 
		rech_Fecha, 
		rech_UsuCreacion, 
		T3.user_NombreUsuario AS UsuarioCreacion,
		rech_FechaCreacion, 
		rech_UsuModificacion, 
		T4.user_NombreUsuario AS UsuarioModificacion,
		rech_FechaModificacion, 
		rech_Estado
FROM [lice].[tbRechazados] AS T1 INNER JOIN [lice].[tbEmpleados] AS T2
ON T1.empe_Id = T2.empe_Id INNER JOIN [acce].[tbUsuarios] AS T3
ON T1.rech_UsuCreacion = T3.[user_Id] LEFT JOIN [acce].[tbUsuarios] AS T4
ON T1.rech_UsuModificacion = T4.[user_Id] INNER JOIN lice.tbSolicitud T5
ON t5.stud_Id = T1.stud_Id INNER JOIN lice.tbSolicitantes T6
ON T6.soli_Id = T5.soli_Id INNER JOIN lice.tbTiposLicencias T7
ON t7.tili_Id = T5.tili_Id INNER JOIN Lice.tbSucursales T8
ON T8.sucu_Id = T5.sucu_Id


GO
CREATE OR ALTER PROCEDURE lice.UDP_VW_tbTiposLicencias_View_FIND
(@tili_Id INT)
AS
BEGIN
    SELECT * FROM lice.VW_tbTiposLicencias_View 
    WHERE tili_Id = @tili_Id;
END


---*** DROP DOWN LIST DEPARTAMENTOS ***---
GO
CREATE OR ALTER PROCEDURE gral.UDP_tbDepartamentos_DDL
AS
BEGIN
	SELECT depa_Id, depa_Nombre
	FROM gral.tbDepartamentos 
	WHERE depa_Estado = 1
END


---*** DROP DOWN LIST MUNICIPIO POR DEPARTAMENTO ***---
GO
CREATE OR ALTER PROCEDURE gral.UDP_tbMunicipios_DDL
(@depa_Id INT)
AS
BEGIN
	SELECT muni_Id, muni_Nombre
	FROM gral.tbMunicipios 
	WHERE depa_Id = @depa_Id
END


GO
CREATE OR ALTER PROCEDURE lice.UDP_tbCargos_SELECT
AS
BEGIN
	SELECT * FROM LICE.tbCargos
	WHERE carg_Estado = 1;
END
GO

GO
CREATE OR ALTER PROCEDURE lice.UDP_tbSucursales_SELECT
AS
BEGIN
	SELECT * FROM LICE.tbSucursales
	WHERE sucu_Estado = 1;
END
GO

GO
CREATE OR ALTER PROCEDURE gral.UDP_tbEstadosCiviles_SELECT
AS
BEGIN
	SELECT * FROM gral.tbEstadosCiviles
	WHERE eciv_Estado = 1;
END
GO

UPDATE [acce].[tbUsuarios]
   SET [role_Id] = 1
 WHERE [user_Id] = 1
GO




CREATE OR ALTER VIEW acce.VW_tbUsuarios_View
AS
SELECT T1.[user_Id]
      ,T1.[user_NombreUsuario]
      ,T1.[user_Contrasena]
      ,T1.[user_EsAdmin]
      ,T1.[role_Id]
	  ,T4.role_Nombre
      ,T1.[empe_Id]
	  ,T5.empe_Nombres
	  ,T5.empe_Apellidos
	  ,T5.empe_Nombres + ' ' + T5.empe_Apellidos As empe_NombreCompleto
	  ,T5.sucu_Id
	  ,T7.sucu_Nombre
	  ,T5.carg_Id
	  ,T6.carg_Descripcion
      ,T1.[user_UsuCreacion]
      ,T1.[user_FechaCreacion]
      ,T1.[user_UsuModificacion]
      ,T1.[user_FechaModificacion]
      ,T1.[user_Estado]
  FROM [acce].[tbUsuarios] T1 LEFT JOIN acce.tbRoles T4
  ON T1.role_Id = T4.role_Id INNER JOIN lice.tbEmpleados T5
  ON T1.empe_Id = T5.empe_Id INNER JOIN lice.tbCargos T6
  ON T5.carg_Id = T6.carg_Id INNER JOIN Lice.tbSucursales T7 
  ON T5.sucu_Id = T7.sucu_Id INNER JOIN acce.tbUsuarios T2
  ON T1.user_UsuCreacion = T2.[user_Id] LEFT JOIN acce.tbUsuarios T3
  ON T1.user_UsuModificacion = T3.[user_Id]
		
GO

CREATE OR ALTER PROCEDURE acce.UDP_IniciarSesion
@user_NombreUsuario	NVARCHAR(100),
@user_Contrasena	NVARCHAR(MAX)
AS
BEGIN
DECLARE @password NVARCHAR(MAX)=(SELECT HASHBYTES('Sha2_512', @user_Contrasena));


SELECT *
  FROM acce.VW_tbUsuarios_View
  WHERE user_NombreUsuario = @user_NombreUsuario AND user_Contrasena = @password



END
GO
CREATE OR ALTER PROCEDURE acce.UDP_RecuperarUsuario
@user_NombreUsuario	NVARCHAR(100),
@user_Contrasena	NVARCHAR(MAX)
AS
BEGIN
BEGIN TRY

DECLARE @password NVARCHAR(MAX)=(SELECT HASHBYTES('Sha2_512', @user_Contrasena));

UPDATE [acce].[tbUsuarios]
   SET [user_Contrasena] = @password
 WHERE @user_NombreUsuario = user_NombreUsuario

 
 IF EXISTS (select * FROM acce.tbUsuarios WHERE user_NombreUsuario = @user_NombreUsuario
												AND [user_Contrasena] = @Password)
 BEGIN
 SELECT 1 as Proceso
 END
 ELSE
 SELECT 0 as Proceso
END TRY
BEGIN CATCH
 SELECT 0 as Proceso
END CATCH



END--quiero guardarlo xd
GO

CREATE OR ALTER PROCEDURE lice.UDP_tbSolicitantes_DDL
AS
BEGIN
	SELECT soli_Id, soli_Nombre + ' ' + soli_Apellido AS NombreCompleto
	FROM lice.tbSolicitantes
	WHERE soli_Estado = 1;
END


GO
CREATE OR ALTER PROCEDURE lice.UDP_tbTipoLicencis_DDL
AS
BEGIN
	SELECT tili_Id, tili_Descripcion
	FROM lice.tbTiposLicencias
	WHERE tili_Estado = 1;
END
