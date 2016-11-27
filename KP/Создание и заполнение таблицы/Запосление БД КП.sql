use КП
set NOCOUNT on
DECLARE @Symbol CHAR(52)= 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz',
		@Position INT,
		@i INT,
		@perem1 int,
		@perem2 int,
		@perem3 int,
		@perem4 int,
		@perem5 int,
		@Name1 nvarchar(20),
		@Name2 nvarchar(20),
		@Name3 nvarchar(20),
		@Name4 nvarchar(20),
		@Name5 nvarchar(20),
		@Name6 nvarchar(20),
		@Name7 nvarchar(20),
		@Name8 nvarchar(20),
		@Name9 nvarchar(20),
		@odate1 date,
		@odate2 date,
		@RowCount INT,
		@NameLimit INT,
		@Number int,
		@Phone int,
		@money1 money

		SET @Number=100

BEGIN TRAN

SELECT @i=0 FROM dbo.Должности WITH (TABLOCKX) WHERE 1=0
-- должности
SET @RowCount=1
WHILE @RowCount<=@Number
	BEGIN
	SET @Name1=''
	SET @Name2=''
	SET @money1= 1000000+RAND()*8999999
	SET @NameLimit=5+RAND()*13 
	SET @i=1
	WHILE @i<=@NameLimit
		BEGIN
			SET @Position=RAND()*52
			SET @Name1 = @Name1 + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*52
			SET @Name2 = @Name2 + SUBSTRING(@Symbol, @Position, 1)
			SET @i=@i+1
		END
		INSERT INTO dbo.Должности(НаименованиеДолжности, Оклад,Требования) SELECT @Name1, @money1, @Name2

		SET @RowCount +=1
	END

SELECT @i=0 FROM dbo.Сотрудники WITH (TABLOCKX) WHERE 1=0
-- Сотрудники
SET @RowCount=1
WHILE @RowCount<=@Number
	BEGIN
	SET @Name1=''
	SET @Name2=''
	SET @Name3=''
	SET @Name4=''
	SET @Name5=''
	SET @Name6=''
	SET @Name7=''
	SET @Name8=''
	SET @Name9=''
	SET @i=1
	SET @NameLimit=5+RAND()*13 
	SET @odate1=dateadd(day,-RAND()*15000,GETDATE())
	SET @Phone = 1000000 + RAND()*8999999
	WHILE @i<=@NameLimit
		BEGIN
			SET @Position=RAND()*52
			SET @Name1 = @Name1 + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*52
			SET @Name2 = @Name2 + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*52
			SET @Name3 = @Name3 + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*52
			SET @Name4 = @Name4 + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*52
			SET @Name5 = @Name5 + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*52
			SET @Name6 = @Name6 + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*52
			SET @Name7 = @Name7 + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*52
			SET @Name8 = @Name8 + SUBSTRING(@Symbol, @Position, 1)
			SET @i=@i+1
		END
		INSERT INTO dbo.Сотрудники(Фамилия, Имя,Отчество, Фото, ДатаРождения, Пол, Адрес, Телефон, Образование, ПаспортныеДанные) 
		                SELECT @Name1,
							   @Name2,  
							   @Name3,
							   @Name4,
							   @odate1, 
							   @Name5,
							   @Name6,
							   @Phone,
							   @Name7,
							   @Name8
					
		SET @RowCount +=1
	END

SELECT @i=0 FROM dbo.ПослужнойСписок WITH (TABLOCKX) WHERE 1=0
-- Послужной список
SET @RowCount=1
WHILE @RowCount<=@Number
	BEGIN
	SET @Name2=''
	SET @NameLimit=5+RAND()*13 
	SET @i=1
	SET @odate1=dateadd(day,-RAND()*15000,GETDATE())
	WHILE @i<=@NameLimit
		BEGIN
			SET @Position=RAND()*52
			SET @Name2 = @Name2 + SUBSTRING(@Symbol, @Position, 1)
			SET @i=@i+1
		END
		INSERT INTO dbo.ПослужнойСписок(ДатаЗанятияДолжности,КраткаяХарактеристика, IDДолжности,IDСотрудника) SELECT @odate1, @Name2, CAST( (1+RAND()*(@Number-1)) as int), CAST( (1+RAND()*(@Number-1)) as int) 

		SET @RowCount +=1
	END




SELECT @i=0 FROM dbo.Электрооборудование WITH (TABLOCKX) WHERE 1=0
-- Электрооборудование
SET @RowCount=1
WHILE @RowCount<=@Number
	BEGIN
	SET @Name1=''
	SET @i=1
	SET @perem1=RAND()*1000
	SET @perem2=RAND()*10000
	SET @NameLimit=5+RAND()*10 
	WHILE @i<=@NameLimit
		BEGIN
			SET @Position=RAND()*52
			SET @Name1 = @Name1 + SUBSTRING(@Symbol, @Position, 1)
			SET @i+=1
		END
		INSERT INTO dbo.Электрооборудование(Наименование, Количество, СуточноеВремяРаботы) 
		                SELECT @Name1,
							   @perem1,
							   @perem2 
		SET @RowCount +=1
	END

SELECT @i=0 FROM dbo.ПоказанияСчётчика WITH (TABLOCKX) WHERE 1=0
-- ПоказанияСчётчика
SET @RowCount=1
WHILE @RowCount<=@Number
	BEGIN
	SET @Name1=''
	SET @Name2=''
	SET @i=1
	SET @perem1=RAND()*1000
	SET @perem2=RAND()*10000
	SET @perem3=RAND()*10000
	SET @perem4=RAND()*10000
	SET @odate1=dateadd(day,-RAND()*15000,GETDATE())
	SET @NameLimit=5+RAND()*10 
	WHILE @i<=@NameLimit
		BEGIN
			SET @Position=RAND()*52
			SET @Name1 = @Name1 + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*52
			SET @Name2 = @Name2 + SUBSTRING(@Symbol, @Position, 1)
			SET @i+=1
		END
		INSERT INTO dbo.ПоказанияСчётчика(Номер, Дата, Арендодатель, Месяц, Год, Сумма, IDЭлектрооборудование, IDСотрудника) 
		                SELECT @perem1,
						       @odate1,
							   @Name1,
							   @Name2,
							   @perem2,
							   @perem3,
							   CAST( (1+RAND()*(@Number-1)) as int),
							   CAST( (1+RAND()*(@Number-1)) as int)

		SET @RowCount +=1
	END

SELECT @i=0 FROM dbo.Договор WITH (TABLOCKX) WHERE 1=0
-- Договор
SET @RowCount=1
WHILE @RowCount<=@Number
	BEGIN
	SET @Name1=''
	SET @odate1=dateadd(day,-RAND()*15000,GETDATE())
	SET @odate2=dateadd(day,-RAND()*15000,GETDATE())
	SET @i=1
	SET @NameLimit=5+RAND()*10 
	WHILE @i<=@NameLimit
		BEGIN
			SET @Position=RAND()*52
			SET @Name1 = @Name1 + SUBSTRING(@Symbol, @Position, 1)
			SET @i+=1
		END
		INSERT INTO dbo.Договор(ДатаВъезда, ДатаВыеда, ИнформацияПоПомещению) 
		                SELECT @odate1,
						       @odate2,
							   @Name1

		SET @RowCount +=1
	END

SELECT @i=0 FROM dbo.Здания WITH (TABLOCKX) WHERE 1=0
-- Здания
SET @RowCount=1
WHILE @RowCount<=@Number
	BEGIN
	SET @Name1=''
	SET @Name2=''
	SET @Name3=''
	SET @perem1=RAND()*1000
	SET @perem2=RAND()*1000
	SET @i=1
	SET @NameLimit=5+RAND()*10 
	WHILE @i<=@NameLimit
		BEGIN
			SET @Position=RAND()*52
			SET @Name1 = @Name1 + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*52
			SET @Name2 = @Name2 + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*52
			SET @Name3 = @Name3 + SUBSTRING(@Symbol, @Position, 1)
			SET @i+=1
		END
		INSERT INTO dbo.Здания(Наименование, Этажность, ПочтовыеДанные, НомерПомещения) 
		                SELECT @Name1,
						       @perem1,
							   @Name3,
							   @perem2

		SET @RowCount +=1
	END


SELECT @i=0 FROM dbo.Арендодатель WITH (TABLOCKX) WHERE 1=0
-- Арендодатель
SET @RowCount=1
WHILE @RowCount<=@Number
	BEGIN
	SET @Name1=''
	SET @Name2=''
	SET @i=1
	SET @NameLimit=5+RAND()*10 
	WHILE @i<=@NameLimit
		BEGIN
			SET @Position=RAND()*52
			SET @Name1 = @Name1 + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*52
			SET @Name2 = @Name2 + SUBSTRING(@Symbol, @Position, 1)
			SET @i+=1
		END
		INSERT INTO dbo.Арендодатель(Наименование, ПочтовыеДанные, IDПомещения, IDЗдания, IDСотрудника, IDДоговор) 
		                SELECT @Name1,
						       @Name2,
							   CAST( (1+RAND()*(@Number-1)) as int),
							   CAST( (1+RAND()*(@Number-1)) as int),
							   CAST( (1+RAND()*(@Number-1)) as int),
							   CAST( (1+RAND()*(@Number-1)) as int)

		SET @RowCount +=1
	END

SELECT @i=0 FROM dbo.Помещения WITH (TABLOCKX) WHERE 1=0
-- Помещения
SET @RowCount=1
WHILE @RowCount<=@Number
	BEGIN
	SET @perem1=RAND()*1000
	SET @perem2=RAND()*1000
	SET @perem3=RAND()*1000
		INSERT INTO dbo.Помещения(Площадь, Этаж, Номер, IDЗдания, IDАрендодатель) 
		                SELECT @perem1,
						       @perem2,
							   @perem3,
							   CAST( (1+RAND()*(@Number-1)) as int),
							   CAST( (1+RAND()*(@Number-1)) as int)

		SET @RowCount +=1
	END

SELECT @i=0 FROM dbo.ОбщиеПомещения WITH (TABLOCKX) WHERE 1=0
-- ОбщиеПомещения
SET @RowCount=1
WHILE @RowCount<=@Number
	BEGIN
	SET @Name1=''
	SET @perem1=RAND()*1000
	SET @perem2=RAND()*1000
	SET @i=1
	SET @NameLimit=5+RAND()*10 
	WHILE @i<=@NameLimit
		BEGIN
			SET @Position=RAND()*52
			SET @Name1 = @Name1 + SUBSTRING(@Symbol, @Position, 1)
			SET @i+=1
		END
		INSERT INTO dbo.ОбщиеПомещения(НаименованиеКоридоры, Туалеты, Этаж, IDЗдания) 
		                SELECT @Name1,
						       @perem1,
							   @perem2,
							   CAST( (1+RAND()*(@Number-1)) as int)

		SET @RowCount +=1
	END

SELECT @i=0 FROM dbo.Арендатор WITH (TABLOCKX) WHERE 1=0
-- Арендатор
SET @RowCount=1
WHILE @RowCount<=@Number
	BEGIN
	SET @Name1=''
	SET @Name2=''
	SET @Name3=''
	SET @Name4=''
	SET @perem1=RAND()*1000
	SET @i=1
	SET @NameLimit=5+RAND()*10 
	WHILE @i<=@NameLimit
		BEGIN
			SET @Position=RAND()*52
			SET @Name1 = @Name1 + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*52
			SET @Name2 = @Name2 + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*52
			SET @Name3 = @Name3 + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*52
			SET @Name4 = @Name4 + SUBSTRING(@Symbol, @Position, 1)
			SET @i+=1
		END
		INSERT INTO dbo.Арендатор(Фамилия, Имя, Отчество, ПаспортныеДанные, IDДоговор) 
		                SELECT @Name1,
						       @Name2,
							   @Name3,
							   @Name4,
							   CAST( (1+RAND()*(@Number-1)) as int)

		SET @RowCount +=1
	END

	COMMIT TRAN
GO