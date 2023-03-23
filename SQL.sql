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
CREATE TABLE lice.tbAprovados(
    apro_Id         INT IDENTITY(1,1),
    soli_Id         INT NOT NULL,
    tili_Id         INT NOT NULL,
    empe_Id         INT NOT NULL,
    sucu_Id         INT NOT NULL,
    apro_Fecha      DATE,     
	apro_UsuCreacion			INT				NOT NULL,
	apro_FechaCreacion			DATETIME		NOT NULL CONSTRAINT DF_apro_FechaCreacion DEFAULT(GETDATE()),
	apro_UsuModificacion		INT,
	apro_FechaModificacion		DATETIME,
	apro_Estado					BIT NOT NULL CONSTRAINT DF_apro_Estado DEFAULT(1),

    CONSTRAINT PK_lice_tbAprovados_apro_Id 										PRIMARY KEY(apro_Id),
	CONSTRAINT FK_lice_tbAprovados_lice_tbSolicitantes_soli_Id			        FOREIGN KEY(soli_Id)					    REFERENCES lice.tbSolicitantes(soli_Id),			
	CONSTRAINT FK_lice_tbAprovados_lice_tbTiposLicencias_tili_Id			    FOREIGN KEY(tili_Id)						REFERENCES lice.tbTiposLicencias(tili_Id),
	CONSTRAINT FK_lice_tbAprovados_acce_tbUsuarios_UserCreate					FOREIGN KEY(apro_UsuCreacion)				REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_lice_tbAprovados_acce_tbUsuarios_UserUpdate					FOREIGN KEY(apro_UsuModificacion)			REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_lice_tbAprovados_lice_tbSucursales_sucu_Id					FOREIGN KEY(sucu_Id)						REFERENCES lice.tbSucursales(sucu_Id),		
	CONSTRAINT FK_lice_tbAprovados_lice_tbEmpleados_empe_Id					    FOREIGN KEY(empe_Id)						REFERENCES lice.tbEmpleados(empe_Id)		


    
)





