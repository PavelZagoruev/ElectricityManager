use ��
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

SELECT @i=0 FROM dbo.��������� WITH (TABLOCKX) WHERE 1=0
-- ���������
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
		INSERT INTO dbo.���������(���������������������, �����,����������) SELECT @Name1, @money1, @Name2

		SET @RowCount +=1
	END

SELECT @i=0 FROM dbo.���������� WITH (TABLOCKX) WHERE 1=0
-- ����������
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
		INSERT INTO dbo.����������(�������, ���,��������, ����, ������������, ���, �����, �������, �����������, ����������������) 
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

SELECT @i=0 FROM dbo.��������������� WITH (TABLOCKX) WHERE 1=0
-- ��������� ������
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
		INSERT INTO dbo.���������������(��������������������,���������������������, ID���������,ID����������) SELECT @odate1, @Name2, CAST( (1+RAND()*(@Number-1)) as int), CAST( (1+RAND()*(@Number-1)) as int) 

		SET @RowCount +=1
	END




SELECT @i=0 FROM dbo.������������������� WITH (TABLOCKX) WHERE 1=0
-- �������������������
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
		INSERT INTO dbo.�������������������(������������, ����������, �������������������) 
		                SELECT @Name1,
							   @perem1,
							   @perem2 
		SET @RowCount +=1
	END

SELECT @i=0 FROM dbo.����������������� WITH (TABLOCKX) WHERE 1=0
-- �����������������
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
		INSERT INTO dbo.�����������������(�����, ����, ������������, �����, ���, �����, ID�������������������, ID����������) 
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

SELECT @i=0 FROM dbo.������� WITH (TABLOCKX) WHERE 1=0
-- �������
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
		INSERT INTO dbo.�������(����������, ���������, ���������������������) 
		                SELECT @odate1,
						       @odate2,
							   @Name1

		SET @RowCount +=1
	END

SELECT @i=0 FROM dbo.������ WITH (TABLOCKX) WHERE 1=0
-- ������
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
		INSERT INTO dbo.������(������������, ���������, ��������������, ��������������) 
		                SELECT @Name1,
						       @perem1,
							   @Name3,
							   @perem2

		SET @RowCount +=1
	END


SELECT @i=0 FROM dbo.������������ WITH (TABLOCKX) WHERE 1=0
-- ������������
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
		INSERT INTO dbo.������������(������������, ��������������, ID���������, ID������, ID����������, ID�������) 
		                SELECT @Name1,
						       @Name2,
							   CAST( (1+RAND()*(@Number-1)) as int),
							   CAST( (1+RAND()*(@Number-1)) as int),
							   CAST( (1+RAND()*(@Number-1)) as int),
							   CAST( (1+RAND()*(@Number-1)) as int)

		SET @RowCount +=1
	END

SELECT @i=0 FROM dbo.��������� WITH (TABLOCKX) WHERE 1=0
-- ���������
SET @RowCount=1
WHILE @RowCount<=@Number
	BEGIN
	SET @perem1=RAND()*1000
	SET @perem2=RAND()*1000
	SET @perem3=RAND()*1000
		INSERT INTO dbo.���������(�������, ����, �����, ID������, ID������������) 
		                SELECT @perem1,
						       @perem2,
							   @perem3,
							   CAST( (1+RAND()*(@Number-1)) as int),
							   CAST( (1+RAND()*(@Number-1)) as int)

		SET @RowCount +=1
	END

SELECT @i=0 FROM dbo.�������������� WITH (TABLOCKX) WHERE 1=0
-- ��������������
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
		INSERT INTO dbo.��������������(��������������������, �������, ����, ID������) 
		                SELECT @Name1,
						       @perem1,
							   @perem2,
							   CAST( (1+RAND()*(@Number-1)) as int)

		SET @RowCount +=1
	END

SELECT @i=0 FROM dbo.��������� WITH (TABLOCKX) WHERE 1=0
-- ���������
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
		INSERT INTO dbo.���������(�������, ���, ��������, ����������������, ID�������) 
		                SELECT @Name1,
						       @Name2,
							   @Name3,
							   @Name4,
							   CAST( (1+RAND()*(@Number-1)) as int)

		SET @RowCount +=1
	END

	COMMIT TRAN
GO