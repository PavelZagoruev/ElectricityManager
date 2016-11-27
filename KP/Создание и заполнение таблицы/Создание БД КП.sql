create database ��
go
use ��
CREATE TABLE [���������]
( 
	[�������]            varchar(20)  NULL ,
	[���]                varchar(20)  NULL ,
	[��������]           varchar(20)  NULL ,
	[����������������]   varchar(20)  NULL ,
	[ID�������]          integer  NULL ,
	[ID���������]        int IDENTITY(1,1)  NOT NULL 
)
go

ALTER TABLE [���������]
	ADD CONSTRAINT [XPK���������] PRIMARY KEY  CLUSTERED ([ID���������] ASC)
go

CREATE TABLE [������������]
( 
	[������������]       varchar(20)  NULL ,
	[��������������]     varchar(20)  NULL ,
	[ID���������]        integer  NULL ,
	[ID������]           integer  NULL ,
	[ID����������]       integer  NULL ,
	[ID�������]          integer  NULL ,
	[ID������������]     int IDENTITY(1,1)  NOT NULL 
)
go

ALTER TABLE [������������]
	ADD CONSTRAINT [XPK������������] PRIMARY KEY  CLUSTERED ([ID������������] ASC)
go

CREATE TABLE [�������]
( 
	[ID�������]          int IDENTITY(1,1)  NOT NULL ,
	[����������]         datetime  NULL ,
	[���������]          datetime  NULL ,
	[���������������������] varchar(20)  NULL 
)
go

ALTER TABLE [�������]
	ADD CONSTRAINT [XPK�������] PRIMARY KEY  CLUSTERED ([ID�������] ASC)
go

CREATE TABLE [���������]
( 
	[ID���������]        int IDENTITY(1,1)  NOT NULL ,
	[���������������������] varchar(18)  NULL ,
	[�����]              money  NULL ,
	[����������]         varchar(18)  NULL 
)
go

ALTER TABLE [���������]
	ADD CONSTRAINT [XPK���������] PRIMARY KEY  CLUSTERED ([ID���������] ASC)
go

CREATE TABLE [������]
( 
	[������������]       varchar(20)  NULL ,
	[���������]          integer  NULL ,
	[��������������]     varchar(20)  NULL ,
	[��������������]     integer  NULL ,
	[ID������]           int IDENTITY(1,1)  NOT NULL 
)
go

ALTER TABLE [������]
	ADD CONSTRAINT [XPK������] PRIMARY KEY  CLUSTERED ([ID������] ASC)
go

CREATE TABLE [��������������]
( 
	[��������������������] varchar(20)  NULL ,
	[�������]            integer  NULL ,
	[����]               integer  NULL ,
	[ID������]           integer  NULL ,
	[ID������������]     int IDENTITY(1,1)  NOT NULL 
)
go

ALTER TABLE [��������������]
	ADD CONSTRAINT [XPK��������������] PRIMARY KEY  CLUSTERED ([ID������������] ASC)
go

CREATE TABLE [�����������������]
( 
	[�����]              integer  NULL ,
	[����]               datetime  NULL ,
	[������������]       varchar(20)  NULL ,
	[�����]              varchar(20)  NULL ,
	[���]                integer  NULL ,
	[�����]              integer  NULL ,
	[ID�������������������] integer  NULL ,
	[ID��������]         int IDENTITY(1,1)  NOT NULL ,
	[ID����������]       integer  NULL 
)
go

ALTER TABLE [�����������������]
	ADD CONSTRAINT [XPK�����������������] PRIMARY KEY  CLUSTERED ([ID��������] ASC)
go

CREATE TABLE [���������]
( 
	[ID���������]        int IDENTITY(1,1)  NOT NULL ,
	[�������]            integer  NULL ,
	[����]               integer  NULL ,
	[�����]              integer  NULL ,
	[ID������]           integer  NULL ,
	[ID������������]     int  NULL 
)
go

ALTER TABLE [���������]
	ADD CONSTRAINT [XPK���������] PRIMARY KEY  CLUSTERED ([ID���������] ASC)
go

CREATE TABLE [���������������]
( 
	[��������������������] datetime  NULL ,
	[���������������������] varchar(40)  NULL ,
	[ID����������������] int IDENTITY(1,1)  NOT NULL ,
	[ID���������]        int  NULL,
	[ID����������]       int NULL
)
go

ALTER TABLE [���������������]
	ADD CONSTRAINT [XPK���������������] PRIMARY KEY  CLUSTERED ([ID����������������] ASC)
go

CREATE TABLE [����������]
( 
	[�������]            varchar(20)  NULL ,
	[���]                varchar(20)  NULL ,
	[��������]           varchar(20)  NULL ,
	[����]               varchar(20)  NULL ,
	[������������]       datetime  NULL ,
	[���]                varchar(20)  NULL ,
	[�����]              varchar(20)  NULL ,
	[�������]            int  NULL ,
	[�����������]        varchar(20)  NULL ,
	[ID����������]       int IDENTITY(1,1)  NOT NULL ,
	[����������������]   varchar(20)  NULL 
)
go

ALTER TABLE [����������]
	ADD CONSTRAINT [XPK����������] PRIMARY KEY  CLUSTERED ([ID����������] ASC)
go

CREATE TABLE [�������������������]
( 
	[������������]       varchar(20)  NULL ,
	[����������]         integer  NULL ,
	[�������������������] integer  NULL ,
	[ID�������������������] int IDENTITY(1,1)  NOT NULL 
)
go

ALTER TABLE [�������������������]
	ADD CONSTRAINT [XPK�������������������] PRIMARY KEY  CLUSTERED ([ID�������������������] ASC)
go


ALTER TABLE [���������]
	ADD CONSTRAINT [R_15] FOREIGN KEY ([ID�������]) REFERENCES [�������]([ID�������])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [������������]
	ADD CONSTRAINT [R_4] FOREIGN KEY ([ID������]) REFERENCES [������]([ID������])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [������������]
	ADD CONSTRAINT [R_7] FOREIGN KEY ([ID����������]) REFERENCES [����������]([ID����������])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [������������]
	ADD CONSTRAINT [R_16] FOREIGN KEY ([ID�������]) REFERENCES [�������]([ID�������])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [��������������]
	ADD CONSTRAINT [R_2] FOREIGN KEY ([ID������]) REFERENCES [������]([ID������])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [�����������������]
	ADD CONSTRAINT [R_8] FOREIGN KEY ([ID�������������������]) REFERENCES [�������������������]([ID�������������������])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [�����������������]
	ADD CONSTRAINT [R_18] FOREIGN KEY ([ID����������]) REFERENCES [����������]([ID����������])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [���������]
	ADD CONSTRAINT [R_1] FOREIGN KEY ([ID������]) REFERENCES [������]([ID������])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [���������]
	ADD CONSTRAINT [R_13] FOREIGN KEY ([ID������������]) REFERENCES [������������]([ID������������])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [���������������]
	ADD CONSTRAINT [R_21] FOREIGN KEY ([ID���������]) REFERENCES [���������]([ID���������])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [���������������]
	ADD CONSTRAINT [R_19] FOREIGN KEY ([ID����������]) REFERENCES [����������]([ID����������])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

