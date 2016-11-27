create database КП
go
use КП
CREATE TABLE [Арендатор]
( 
	[Фамилия]            varchar(20)  NULL ,
	[Имя]                varchar(20)  NULL ,
	[Отчество]           varchar(20)  NULL ,
	[ПаспортныеДанные]   varchar(20)  NULL ,
	[IDДоговор]          integer  NULL ,
	[IDАрендатор]        int IDENTITY(1,1)  NOT NULL 
)
go

ALTER TABLE [Арендатор]
	ADD CONSTRAINT [XPKАрендатор] PRIMARY KEY  CLUSTERED ([IDАрендатор] ASC)
go

CREATE TABLE [Арендодатель]
( 
	[Наименование]       varchar(20)  NULL ,
	[ПочтовыеДанные]     varchar(20)  NULL ,
	[IDПомещения]        integer  NULL ,
	[IDЗдания]           integer  NULL ,
	[IDСотрудника]       integer  NULL ,
	[IDДоговор]          integer  NULL ,
	[IDАрендодатель]     int IDENTITY(1,1)  NOT NULL 
)
go

ALTER TABLE [Арендодатель]
	ADD CONSTRAINT [XPKАрендодатель] PRIMARY KEY  CLUSTERED ([IDАрендодатель] ASC)
go

CREATE TABLE [Договор]
( 
	[IDДоговор]          int IDENTITY(1,1)  NOT NULL ,
	[ДатаВъезда]         datetime  NULL ,
	[ДатаВыеда]          datetime  NULL ,
	[ИнформацияПоПомещению] varchar(20)  NULL 
)
go

ALTER TABLE [Договор]
	ADD CONSTRAINT [XPKДоговор] PRIMARY KEY  CLUSTERED ([IDДоговор] ASC)
go

CREATE TABLE [Должности]
( 
	[IDДолжности]        int IDENTITY(1,1)  NOT NULL ,
	[НаименованиеДолжности] varchar(18)  NULL ,
	[Оклад]              money  NULL ,
	[Требования]         varchar(18)  NULL 
)
go

ALTER TABLE [Должности]
	ADD CONSTRAINT [XPKДолжности] PRIMARY KEY  CLUSTERED ([IDДолжности] ASC)
go

CREATE TABLE [Здания]
( 
	[Наименование]       varchar(20)  NULL ,
	[Этажность]          integer  NULL ,
	[ПочтовыеДанные]     varchar(20)  NULL ,
	[НомерПомещения]     integer  NULL ,
	[IDЗдания]           int IDENTITY(1,1)  NOT NULL 
)
go

ALTER TABLE [Здания]
	ADD CONSTRAINT [XPKЗдания] PRIMARY KEY  CLUSTERED ([IDЗдания] ASC)
go

CREATE TABLE [ОбщиеПомещения]
( 
	[НаименованиеКоридоры] varchar(20)  NULL ,
	[Туалеты]            integer  NULL ,
	[Этаж]               integer  NULL ,
	[IDЗдания]           integer  NULL ,
	[IDОбщПомещения]     int IDENTITY(1,1)  NOT NULL 
)
go

ALTER TABLE [ОбщиеПомещения]
	ADD CONSTRAINT [XPKОбщиеПомещения] PRIMARY KEY  CLUSTERED ([IDОбщПомещения] ASC)
go

CREATE TABLE [ПоказанияСчётчика]
( 
	[Номер]              integer  NULL ,
	[Дата]               datetime  NULL ,
	[Арендодатель]       varchar(20)  NULL ,
	[Месяц]              varchar(20)  NULL ,
	[Год]                integer  NULL ,
	[Сумма]              integer  NULL ,
	[IDЭлектрооборудование] integer  NULL ,
	[IDСчётчика]         int IDENTITY(1,1)  NOT NULL ,
	[IDСотрудника]       integer  NULL 
)
go

ALTER TABLE [ПоказанияСчётчика]
	ADD CONSTRAINT [XPKПоказанияСчётчика] PRIMARY KEY  CLUSTERED ([IDСчётчика] ASC)
go

CREATE TABLE [Помещения]
( 
	[IDПомещения]        int IDENTITY(1,1)  NOT NULL ,
	[Площадь]            integer  NULL ,
	[Этаж]               integer  NULL ,
	[Номер]              integer  NULL ,
	[IDЗдания]           integer  NULL ,
	[IDАрендодатель]     int  NULL 
)
go

ALTER TABLE [Помещения]
	ADD CONSTRAINT [XPKПомещения] PRIMARY KEY  CLUSTERED ([IDПомещения] ASC)
go

CREATE TABLE [ПослужнойСписок]
( 
	[ДатаЗанятияДолжности] datetime  NULL ,
	[КраткаяХарактеристика] varchar(40)  NULL ,
	[IDПослужногоСписка] int IDENTITY(1,1)  NOT NULL ,
	[IDДолжности]        int  NULL,
	[IDСотрудника]       int NULL
)
go

ALTER TABLE [ПослужнойСписок]
	ADD CONSTRAINT [XPKПослужнойСписок] PRIMARY KEY  CLUSTERED ([IDПослужногоСписка] ASC)
go

CREATE TABLE [Сотрудники]
( 
	[Фамилия]            varchar(20)  NULL ,
	[Имя]                varchar(20)  NULL ,
	[Отчество]           varchar(20)  NULL ,
	[Фото]               varchar(20)  NULL ,
	[ДатаРождения]       datetime  NULL ,
	[Пол]                varchar(20)  NULL ,
	[Адрес]              varchar(20)  NULL ,
	[Телефон]            int  NULL ,
	[Образование]        varchar(20)  NULL ,
	[IDСотрудника]       int IDENTITY(1,1)  NOT NULL ,
	[ПаспортныеДанные]   varchar(20)  NULL 
)
go

ALTER TABLE [Сотрудники]
	ADD CONSTRAINT [XPKСотрудники] PRIMARY KEY  CLUSTERED ([IDСотрудника] ASC)
go

CREATE TABLE [Электрооборудование]
( 
	[Наименование]       varchar(20)  NULL ,
	[Количество]         integer  NULL ,
	[СуточноеВремяРаботы] integer  NULL ,
	[IDЭлектрооборудование] int IDENTITY(1,1)  NOT NULL 
)
go

ALTER TABLE [Электрооборудование]
	ADD CONSTRAINT [XPKЭлектрооборудование] PRIMARY KEY  CLUSTERED ([IDЭлектрооборудование] ASC)
go


ALTER TABLE [Арендатор]
	ADD CONSTRAINT [R_15] FOREIGN KEY ([IDДоговор]) REFERENCES [Договор]([IDДоговор])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [Арендодатель]
	ADD CONSTRAINT [R_4] FOREIGN KEY ([IDЗдания]) REFERENCES [Здания]([IDЗдания])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [Арендодатель]
	ADD CONSTRAINT [R_7] FOREIGN KEY ([IDСотрудника]) REFERENCES [Сотрудники]([IDСотрудника])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [Арендодатель]
	ADD CONSTRAINT [R_16] FOREIGN KEY ([IDДоговор]) REFERENCES [Договор]([IDДоговор])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [ОбщиеПомещения]
	ADD CONSTRAINT [R_2] FOREIGN KEY ([IDЗдания]) REFERENCES [Здания]([IDЗдания])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [ПоказанияСчётчика]
	ADD CONSTRAINT [R_8] FOREIGN KEY ([IDЭлектрооборудование]) REFERENCES [Электрооборудование]([IDЭлектрооборудование])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [ПоказанияСчётчика]
	ADD CONSTRAINT [R_18] FOREIGN KEY ([IDСотрудника]) REFERENCES [Сотрудники]([IDСотрудника])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [Помещения]
	ADD CONSTRAINT [R_1] FOREIGN KEY ([IDЗдания]) REFERENCES [Здания]([IDЗдания])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [Помещения]
	ADD CONSTRAINT [R_13] FOREIGN KEY ([IDАрендодатель]) REFERENCES [Арендодатель]([IDАрендодатель])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [ПослужнойСписок]
	ADD CONSTRAINT [R_21] FOREIGN KEY ([IDДолжности]) REFERENCES [Должности]([IDДолжности])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [ПослужнойСписок]
	ADD CONSTRAINT [R_19] FOREIGN KEY ([IDСотрудника]) REFERENCES [Сотрудники]([IDСотрудника])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

