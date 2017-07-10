/*==============================================================*/
/* DBMS name:      ORACLE Version 10gR2                         */
/* Created on:     19/05/2016 11:31:20                          */
/*==============================================================*/






drop trigger TIB_ASIGNACIONPAQMANT
/

drop trigger TIB_ASIGNACIONPRODUCTO
/

drop trigger TIB_COMMUNE
/

drop trigger TIB_LOCATION
/

drop trigger TIB_MARCA
/

drop trigger TIB_MODELO
/

drop trigger TIB_COUNTRY
/

drop trigger TIB_PAQUETEMANTENCION
/

drop trigger TIB_PERFIL
/

drop trigger TIB_PROVEEDOR
/

drop trigger TIB_REGION
/

drop trigger TIB_TIPOREPUESTO
/

drop trigger TIB_REPUESTOALTERNATIVOUTILIZA
/

drop trigger TIB_PRODUCTO
/

drop trigger TIB_REPUESTOORIGINALUTILIZADO
/

drop trigger TIB_TALLER
/

drop trigger TIB_TIPOPRODUCTO
/

drop trigger TIB_PERSONA
/

drop trigger TIB_VEHICILOMANTENCION
/

alter table ASIGNACIONPAQMANT
   drop constraint FK_ASIGNACI_REFERENCE_TALLER
/

alter table ASIGNACIONPAQMANT
   drop constraint FK_ASIGNACI_REFERENCE_PAQUETEM
/

alter table ASIGNACIONPRODUCTO
   drop constraint FK_ASIG_PRO_REFERENCE_TAL
/

alter table ASIGNACIONPRODUCTO
   drop constraint FK_ASIGNACI_REFERENCE_REPUESTO
/

alter table COMUNA
   drop constraint FK_COMUNA_REFERENCE_REGION
/

alter table LOCALIZACION
   drop constraint FK_LOCALIZA_REFERENCE_COMUNA
/

alter table MODELO
   drop constraint FK_MODELO_REFERENCE_MARCA
/

alter table REGION
   drop constraint FK_REGION_REFERENCE_PAIS
/

alter table REPUESTOALTERNATIVO
   drop constraint FK_ALTER_REFERENCE_PROVEEDO
/

alter table REPUESTOALTERNATIVO
   drop constraint FK_REPUESTO_REFERENCE_TIPOPROD
/

alter table REPUESTOALTERNATIVO
   drop constraint FK_ALT_REFERENCE_ORG
/

alter table REPUESTOALTERNATIVO
   drop constraint FK_ALTER_REFERENCE_MODELO
/

alter table REPUESTOALTERNATIVOUTILIZADO
   drop constraint FK_UTIL_REFERENCE_ALT
/

alter table REPUESTOALTERNATIVOUTILIZADO
   drop constraint FK_UTIL_REFERENCE_PAQUETEM
/

alter table REPUESTOORIGINAL
   drop constraint "FK_Ori_REFERENCE_MODELO"
/

alter table REPUESTOORIGINAL
   drop constraint FK_ORI_REFERENCE_PROVEEDO
/

alter table REPUESTOORIGINAL
   drop constraint FK_PRO_TIP_REFERENCE_TIPO
/

alter table REPUESTOORIGINALUTILIZADO
   drop constraint FK_UTIL_REFERENCE_ORG
/

alter table REPUESTOORIGINALUTILIZADO
   drop constraint FK_ORG_REFERENCE_PAQUETEM
/

alter table TALLER
   drop constraint FK_TALLER_REFERENCE_LOCALIZA
/

alter table USUARIO
   drop constraint FK_USUARIO_REFERENCE_PERFIL
/

alter table VEHICILOMANTENCION
   drop constraint FK_VEHICILO_REFERENCE_VEHICULO
/

alter table VEHICILOMANTENCION
   drop constraint FK_VEHICILO_REFERENCE_PAQUETEM
/

drop table ASIGNACIONPAQMANT cascade constraints
/

drop table ASIGNACIONPRODUCTO cascade constraints
/

drop index IX_NAME4
/

drop table COMUNA cascade constraints
/

drop table LOCALIZACION cascade constraints
/

drop index IX_NAME5
/

drop table MARCA cascade constraints
/

drop index IX_NAME6
/

drop table MODELO cascade constraints
/

drop index IX_NAME2
/

drop table PAIS cascade constraints
/

drop index IX_NAME
/

drop table PAQUETEMANTENCION cascade constraints
/

drop table PERFIL cascade constraints
/

drop index IX_NAME7
/

drop table PROVEEDOR cascade constraints
/

drop index IX_NAME3
/

drop table REGION cascade constraints
/

drop table REPUESTOALTERNATIVO cascade constraints
/

drop index UNIQ_UTIL_ALT
/

drop table REPUESTOALTERNATIVOUTILIZADO cascade constraints
/

drop table REPUESTOORIGINAL cascade constraints
/

drop index UNIQ_UTIL_OR
/

drop table REPUESTOORIGINALUTILIZADO cascade constraints
/

drop table TALLER cascade constraints
/

drop index IX_NAME8
/

drop table TIPOPRODUCTO cascade constraints
/

drop index IX_EMAIL
/

drop index IX_RUT
/

drop table USUARIO cascade constraints
/

drop table VEHICILOMANTENCION cascade constraints
/

drop table VEHICULO cascade constraints
/

drop sequence SEQUENCE_1
/

drop sequence SEQUENCE_10
/

drop sequence SEQUENCE_11
/

drop sequence SEQUENCE_2
/

drop sequence SEQUENCE_3
/

drop sequence SEQUENCE_4
/

drop sequence SEQUENCE_5
/

drop sequence SEQUENCE_6
/

drop sequence SEQUENCE_7
/

drop sequence SEQUENCE_8
/

drop sequence SEQUENCE_9
/

create sequence SEQUENCE_1
start with 1
increment by 1
/

create sequence SEQUENCE_10
/

create sequence SEQUENCE_11
/

create sequence SEQUENCE_2
start with 1
increment by 1
/

create sequence SEQUENCE_3
start with 1
increment by 1
/

create sequence SEQUENCE_4
start with 1
increment by 1
/

create sequence SEQUENCE_5
start with 1
increment by 1
/

create sequence SEQUENCE_6
start with 1
increment by 1
/

create sequence SEQUENCE_7
start with 1
increment by 1
/

create sequence SEQUENCE_8
start with 1
increment by 1
/

create sequence SEQUENCE_9
start with 1
increment by 1
/

/*==============================================================*/
/* Table: ASIGNACIONPAQMANT                                     */
/*==============================================================*/
create table ASIGNACIONPAQMANT  (
   ASIGNACIONPAQMANTID  NUMBER(6)                       not null,
   TALLERID             int,
   PAQUETEMANTENCIONID  int,
   constraint PK_ASIGNACIONPAQMANT primary key (ASIGNACIONPAQMANTID)
)
/

/*==============================================================*/
/* Table: ASIGNACIONPRODUCTO                                    */
/*==============================================================*/
create table ASIGNACIONPRODUCTO  (
   ASIGNACIONPRODUCTOID int                             not null,
   TALLERID             int                             not null,
   REPUESTOORIGINALID   int,
   CANTIDAD             int                             not null,
   constraint PK_ASIGNACIONPRODUCTO primary key (ASIGNACIONPRODUCTOID)
)
/

/*==============================================================*/
/* Table: COMUNA                                                */
/*==============================================================*/
create table COMUNA  (
   COMUNAID             int                             not null,
   REGIONID             int                             not null,
   NOMBRECOMUNA         varchar(255)                    not null,
   constraint PK_COMUNA primary key (COMUNAID)
)
/

/*==============================================================*/
/* Index: IX_NAME4                                              */
/*==============================================================*/
create unique index IX_NAME4 on COMUNA (
   NOMBRECOMUNA ASC
)
/

/*==============================================================*/
/* Table: LOCALIZACION                                          */
/*==============================================================*/
create table LOCALIZACION  (
   LOCALIZACIONID       int                             not null,
   COMUNAID             int                             not null,
   NOMBRELOCALIZACION   varchar(255)                    not null,
   constraint PK_LOCALIZACION primary key (LOCALIZACIONID)
)
/

/*==============================================================*/
/* Table: MARCA                                                 */
/*==============================================================*/
create table MARCA  (
   MARCAID              int                             not null,
   NOMBREMARCA          varchar(100)                    not null,
   constraint PK_MARCA primary key (MARCAID)
)
/

/*==============================================================*/
/* Index: IX_NAME5                                              */
/*==============================================================*/
create unique index IX_NAME5 on MARCA (
   NOMBREMARCA ASC
)
/

/*==============================================================*/
/* Table: MODELO                                                */
/*==============================================================*/
create table MODELO  (
   MODELOID             int                             not null,
   MARCAID              int,
   NOMBREMODELO         varchar(100)                    not null,
   constraint PK_MODELO primary key (MODELOID)
)
/

/*==============================================================*/
/* Index: IX_NAME6                                              */
/*==============================================================*/
create unique index IX_NAME6 on MODELO (
   NOMBREMODELO ASC
)
/

/*==============================================================*/
/* Table: PAIS                                                  */
/*==============================================================*/
create table PAIS  (
   PAISID               int                             not null,
   NOMBREPAIS           varchar(255)                    not null,
   constraint PK_PAIS primary key (PAISID)
)
/

/*==============================================================*/
/* Index: IX_NAME2                                              */
/*==============================================================*/
create unique index IX_NAME2 on PAIS (
   NOMBREPAIS ASC
)
/

/*==============================================================*/
/* Table: PAQUETEMANTENCION                                     */
/*==============================================================*/
create table PAQUETEMANTENCION  (
   PAQUETEMANTENCIONID  int                             not null,
   NOMBREPAQUETEMANTENCION varchar(100)                    not null,
   COSTOTOTAL           int                             not null,
   DURACIONDIAS         int                             not null,
   DESCRIPCION          varchar(600)                    not null,
   constraint PK_PAQUETEMANTENCION primary key (PAQUETEMANTENCIONID)
)
/

/*==============================================================*/
/* Index: IX_NAME                                               */
/*==============================================================*/
create unique index IX_NAME on PAQUETEMANTENCION (
   NOMBREPAQUETEMANTENCION ASC
)
/

/*==============================================================*/
/* Table: PERFIL                                                */
/*==============================================================*/
create table PERFIL  (
   PERFILID             int                             not null,
   NOMBREPERFIL         varchar(100)                    not null,
   constraint PK_PERFIL primary key (PERFILID)
)
/

/*==============================================================*/
/* Table: PROVEEDOR                                             */
/*==============================================================*/
create table PROVEEDOR  (
   PROVEEDORID          int                             not null,
   NOMBREPROVEEDOR      varchar(100)                    not null,
   constraint PK_PROVEEDOR primary key (PROVEEDORID)
)
/

/*==============================================================*/
/* Index: IX_NAME7                                              */
/*==============================================================*/
create unique index IX_NAME7 on PROVEEDOR (
   NOMBREPROVEEDOR ASC
)
/

/*==============================================================*/
/* Table: REGION                                                */
/*==============================================================*/
create table REGION  (
   REGIONID             int                             not null,
   PAISID               int                             not null,
   NOMBREREGION         varchar(255)                    not null,
   constraint PK_REGION primary key (REGIONID)
)
/

/*==============================================================*/
/* Index: IX_NAME3                                              */
/*==============================================================*/
create unique index IX_NAME3 on REGION (
   NOMBREREGION ASC
)
/

/*==============================================================*/
/* Table: REPUESTOALTERNATIVO                                   */
/*==============================================================*/
create table REPUESTOALTERNATIVO  (
   REPUESTOALTERNATIVOID int                             not null,
   REPUESTOORIGINALID   int                             not null,
   PROVEEDORID          int,
   TIPOPRODUCTOID       int,
   MODELOID             int,
   constraint PK_REPUESTOALTERNATIVO primary key (REPUESTOALTERNATIVOID)
)
/

/*==============================================================*/
/* Table: REPUESTOALTERNATIVOUTILIZADO                          */
/*==============================================================*/
create table REPUESTOALTERNATIVOUTILIZADO  (
   REPUESTOALTERNATIVOUTILIZADOID int                             not null,
   REPUESTOALTERNATIVOID int                             not null,
   PAQUETEMANTENCIONID  int                             not null,
   CANTIDAD             int                             not null,
   constraint PK_REPUESTOALTERNATIVOUTILIZAD primary key (REPUESTOALTERNATIVOUTILIZADOID)
)
/

/*==============================================================*/
/* Index: UNIQ_UTIL_ALT                                         */
/*==============================================================*/
create unique index UNIQ_UTIL_ALT on REPUESTOALTERNATIVOUTILIZADO (
   REPUESTOALTERNATIVOID ASC,
   PAQUETEMANTENCIONID ASC
)
/

/*==============================================================*/
/* Table: REPUESTOORIGINAL                                      */
/*==============================================================*/
create table REPUESTOORIGINAL  (
   REPUESTOORIGINALID   int                             not null,
   MODELOID             int                             not null,
   PROVEEDORID          int                             not null,
   TIPOPRODUCTOID       int                             not null,
   COSTO                int                             not null,
   constraint PK_REPUESTOORIGINAL primary key (REPUESTOORIGINALID)
)
/

/*==============================================================*/
/* Table: REPUESTOORIGINALUTILIZADO                             */
/*==============================================================*/
create table REPUESTOORIGINALUTILIZADO  (
   REPUESTOORIGINALUTILIZADOID int                             not null,
   REPUESTOORIGINALID   int                             not null,
   PAQUETEMANTENCIONID  int                             not null,
   CANTIDAD             int                             not null,
   constraint PK_REPUESTOORIGINALUTILIZADO primary key (REPUESTOORIGINALUTILIZADOID)
)
/

/*==============================================================*/
/* Index: UNIQ_UTIL_OR                                          */
/*==============================================================*/
create unique index UNIQ_UTIL_OR on REPUESTOORIGINALUTILIZADO (
   REPUESTOORIGINALID ASC,
   PAQUETEMANTENCIONID ASC
)
/

/*==============================================================*/
/* Table: TALLER                                                */
/*==============================================================*/
create table TALLER  (
   TALLERID             int                             not null,
   LOCATIONID           int                             not null,
   NOMBRETALLER         varchar(100)                    not null,
   constraint PK_TALLER primary key (TALLERID)
)
/

/*==============================================================*/
/* Table: TIPOPRODUCTO                                          */
/*==============================================================*/
create table TIPOPRODUCTO  (
   TIPOPRODUCTOID       int                             not null,
   NOMBRETIPO           varchar(100)                    not null,
   constraint PK_TIPOPRODUCTO primary key (TIPOPRODUCTOID)
)
/

/*==============================================================*/
/* Index: IX_NAME8                                              */
/*==============================================================*/
create index IX_NAME8 on TIPOPRODUCTO (
   NOMBRETIPO ASC
)
/

/*==============================================================*/
/* Table: USUARIO                                               */
/*==============================================================*/
create table USUARIO  (
   PERSONAID            int                             not null,
   PERFILID             int,
   RUTPERSONA           varchar(100)                    not null,
   NOMBREPERSONA        varchar(100)                    not null,
   APELLIDOPERSONA      varchar(100)                    not null,
   EMAILPERSONA         varchar(100)                    not null,
   PASSWORDPERSONA      varchar(100)                    not null,
   constraint PK_USUARIO primary key (PERSONAID)
)
/

/*==============================================================*/
/* Index: IX_RUT                                                */
/*==============================================================*/
create unique index IX_RUT on USUARIO (
   RUTPERSONA ASC
)
/

/*==============================================================*/
/* Index: IX_EMAIL                                              */
/*==============================================================*/
create unique index IX_EMAIL on USUARIO (
   EMAILPERSONA ASC
)
/

/*==============================================================*/
/* Table: VEHICILOMANTENCION                                    */
/*==============================================================*/
create table VEHICILOMANTENCION  (
   PAQUETEMANTENCIONID  int                             not null,
   IDVEHICILOMANTENCION int                             not null,
   PATENTE              varchar(50),
   FECHAENTRADA         DATE                            not null,
   FECHASALIDA          DATE                            not null,
   constraint PK_VEHICILOMANTENCION primary key (IDVEHICILOMANTENCION)
)
/

/*==============================================================*/
/* Table: VEHICULO                                              */
/*==============================================================*/
create table VEHICULO  (
   RUTCLIENTE           varchar(20)                     not null,
   NOMBRECLIENTE        varchar(100)                    not null,
   MARCAVEHICULO        varchar(50)                     not null,
   MODELOVEHICULO       varchar(50)                     not null,
   PATENTE              varchar(50)                     not null,
   constraint PK_VEHICULO primary key (PATENTE)
)
/

alter table ASIGNACIONPAQMANT
   add constraint FK_ASIGNACI_REFERENCE_TALLER foreign key (TALLERID)
      references TALLER (TALLERID)
/

alter table ASIGNACIONPAQMANT
   add constraint FK_ASIGNACI_REFERENCE_PAQUETEM foreign key (PAQUETEMANTENCIONID)
      references PAQUETEMANTENCION (PAQUETEMANTENCIONID)
/

alter table ASIGNACIONPRODUCTO
   add constraint FK_ASIG_PRO_REFERENCE_TAL foreign key (TALLERID)
      references TALLER (TALLERID)
/

alter table ASIGNACIONPRODUCTO
   add constraint FK_ASIGNACI_REFERENCE_REPUESTO foreign key (REPUESTOORIGINALID)
      references REPUESTOORIGINAL (REPUESTOORIGINALID)
/

alter table COMUNA
   add constraint FK_COMUNA_REFERENCE_REGION foreign key (REGIONID)
      references REGION (REGIONID)
/

alter table LOCALIZACION
   add constraint FK_LOCALIZA_REFERENCE_COMUNA foreign key (COMUNAID)
      references COMUNA (COMUNAID)
/

alter table MODELO
   add constraint FK_MODELO_REFERENCE_MARCA foreign key (MARCAID)
      references MARCA (MARCAID)
/

alter table REGION
   add constraint FK_REGION_REFERENCE_PAIS foreign key (PAISID)
      references PAIS (PAISID)
/

alter table REPUESTOALTERNATIVO
   add constraint FK_ALTER_REFERENCE_PROVEEDO foreign key (PROVEEDORID)
      references PROVEEDOR (PROVEEDORID)
/

alter table REPUESTOALTERNATIVO
   add constraint FK_REPUESTO_REFERENCE_TIPOPROD foreign key (TIPOPRODUCTOID)
      references TIPOPRODUCTO (TIPOPRODUCTOID)
/

alter table REPUESTOALTERNATIVO
   add constraint FK_ALT_REFERENCE_ORG foreign key (REPUESTOORIGINALID)
      references REPUESTOORIGINAL (REPUESTOORIGINALID)
/

alter table REPUESTOALTERNATIVO
   add constraint FK_ALTER_REFERENCE_MODELO foreign key (MODELOID)
      references MODELO (MODELOID)
/

alter table REPUESTOALTERNATIVOUTILIZADO
   add constraint FK_UTIL_REFERENCE_ALT foreign key (REPUESTOALTERNATIVOID)
      references REPUESTOALTERNATIVO (REPUESTOALTERNATIVOID)
/

alter table REPUESTOALTERNATIVOUTILIZADO
   add constraint FK_UTIL_REFERENCE_PAQUETEM foreign key (PAQUETEMANTENCIONID)
      references PAQUETEMANTENCION (PAQUETEMANTENCIONID)
/

alter table REPUESTOORIGINAL
   add constraint "FK_Ori_REFERENCE_MODELO" foreign key (MODELOID)
      references MODELO (MODELOID)
/

alter table REPUESTOORIGINAL
   add constraint FK_ORI_REFERENCE_PROVEEDO foreign key (PROVEEDORID)
      references PROVEEDOR (PROVEEDORID)
/

alter table REPUESTOORIGINAL
   add constraint FK_PRO_TIP_REFERENCE_TIPO foreign key (TIPOPRODUCTOID)
      references TIPOPRODUCTO (TIPOPRODUCTOID)
/

alter table REPUESTOORIGINALUTILIZADO
   add constraint FK_UTIL_REFERENCE_ORG foreign key (REPUESTOORIGINALID)
      references REPUESTOORIGINAL (REPUESTOORIGINALID)
/

alter table REPUESTOORIGINALUTILIZADO
   add constraint FK_ORG_REFERENCE_PAQUETEM foreign key (PAQUETEMANTENCIONID)
      references PAQUETEMANTENCION (PAQUETEMANTENCIONID)
/

alter table TALLER
   add constraint FK_TALLER_REFERENCE_LOCALIZA foreign key (LOCATIONID)
      references LOCALIZACION (LOCALIZACIONID)
/

alter table USUARIO
   add constraint FK_USUARIO_REFERENCE_PERFIL foreign key (PERFILID)
      references PERFIL (PERFILID)
/

alter table VEHICILOMANTENCION
   add constraint FK_VEHICILO_REFERENCE_VEHICULO foreign key (PATENTE)
      references VEHICULO (PATENTE)
/

alter table VEHICILOMANTENCION
   add constraint FK_VEHICILO_REFERENCE_PAQUETEM foreign key (PAQUETEMANTENCIONID)
      references PAQUETEMANTENCION (PAQUETEMANTENCIONID)
/


create trigger TIB_ASIGNACIONPAQMANT before insert
on ASIGNACIONPAQMANT for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column "ASIGNACIONPAQMANTID" uses sequence SEQUENCE_1
    select SEQUENCE_1.NEXTVAL INTO :new.ASIGNACIONPAQMANTID from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/


create trigger TIB_ASIGNACIONPRODUCTO before insert
on ASIGNACIONPRODUCTO for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column "ASIGNACIONPRODUCTOID" uses sequence SEQUENCE_1
    select SEQUENCE_1.NEXTVAL INTO :new.ASIGNACIONPRODUCTOID from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/


create trigger TIB_COMMUNE before insert
on COMUNA for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column "COMUNAID" uses sequence SEQUENCE_1
    select SEQUENCE_1.NEXTVAL INTO :new.COMUNAID from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/


create trigger TIB_LOCATION before insert
on LOCALIZACION for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column "LOCALIZACIONID" uses sequence SEQUENCE_1
    select SEQUENCE_1.NEXTVAL INTO :new.LOCALIZACIONID from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/


create trigger TIB_MARCA before insert
on MARCA for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column "MARCAID" uses sequence SEQUENCE_5
    select SEQUENCE_5.NEXTVAL INTO :new.MARCAID from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/


create trigger TIB_MODELO before insert
on MODELO for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column "MODELOID" uses sequence SEQUENCE_6
    select SEQUENCE_6.NEXTVAL INTO :new.MODELOID from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/


create trigger TIB_COUNTRY before insert
on PAIS for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column "PAISID" uses sequence SEQUENCE_1
    select SEQUENCE_1.NEXTVAL INTO :new.PAISID from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/


create trigger TIB_PAQUETEMANTENCION before insert
on PAQUETEMANTENCION for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column "PAQUETEMANTENCIONID" uses sequence SEQUENCE_1
    select SEQUENCE_1.NEXTVAL INTO :new.PAQUETEMANTENCIONID from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/


create trigger TIB_PERFIL before insert
on PERFIL for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column "PERFILID" uses sequence SEQUENCE_1
    select SEQUENCE_1.NEXTVAL INTO :new.PERFILID from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/


create trigger TIB_PROVEEDOR before insert
on PROVEEDOR for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column "PROVEEDORID" uses sequence SEQUENCE_3
    select SEQUENCE_3.NEXTVAL INTO :new.PROVEEDORID from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/


create trigger TIB_REGION before insert
on REGION for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column "REGIONID" uses sequence SEQUENCE_1
    select SEQUENCE_1.NEXTVAL INTO :new.REGIONID from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/


create trigger TIB_TIPOREPUESTO before insert
on REPUESTOALTERNATIVO for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column "REPUESTOALTERNATIVOID" uses sequence SEQUENCE_2
    select SEQUENCE_2.NEXTVAL INTO :new.REPUESTOALTERNATIVOID from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/


create trigger TIB_REPUESTOALTERNATIVOUTILIZA before insert
on REPUESTOALTERNATIVOUTILIZADO for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column "REPUESTOALTERNATIVOUTILIZADOID" uses sequence SEQUENCE_1
    select SEQUENCE_1.NEXTVAL INTO :new.REPUESTOALTERNATIVOUTILIZADOID from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/


create trigger TIB_PRODUCTO before insert
on REPUESTOORIGINAL for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column "REPUESTOORIGINALID" uses sequence SEQUENCE_1
    select SEQUENCE_1.NEXTVAL INTO :new.REPUESTOORIGINALID from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/


create trigger TIB_REPUESTOORIGINALUTILIZADO before insert
on REPUESTOORIGINALUTILIZADO for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column "REPUESTOORIGINALUTILIZADOID" uses sequence SEQUENCE_1
    select SEQUENCE_1.NEXTVAL INTO :new.REPUESTOORIGINALUTILIZADOID from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/


create trigger TIB_TALLER before insert
on TALLER for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column "TALLERID" uses sequence SEQUENCE_1
    select SEQUENCE_1.NEXTVAL INTO :new.TALLERID from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/


create trigger TIB_TIPOPRODUCTO before insert
on TIPOPRODUCTO for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column "TIPOPRODUCTOID" uses sequence SEQUENCE_4
    select SEQUENCE_4.NEXTVAL INTO :new.TIPOPRODUCTOID from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/


create trigger TIB_PERSONA before insert
on USUARIO for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column "PERSONAID" uses sequence SEQUENCE_2
    select SEQUENCE_2.NEXTVAL INTO :new.PERSONAID from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/


create trigger TIB_VEHICILOMANTENCION before insert
on VEHICILOMANTENCION for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column "IDVEHICILOMANTENCION" uses sequence SEQUENCE_1
    select SEQUENCE_1.NEXTVAL INTO :new.IDVEHICILOMANTENCION from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/

