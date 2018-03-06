USE [master]
GO

/****** Object:  StoredProcedure [dbo].[p_BackupDB]    Script Date: 10/24/2016 08:35:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_BackupDB]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[p_BackupDB]
GO

USE [master]
GO

/****** Object:  StoredProcedure [dbo].[p_BackupDB]    Script Date: 10/24/2016 08:35:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

---�ڶ���������3���洢���� �ֱ�Ϊp_BackupDB,p_RestoreDB,p_CreateJob
create PROC [dbo].[p_BackupDB]
    @DBNAME SYSNAME='',       --Ҫ���ݵ����ݿ�����,��ָ���򱸷ݵ�ǰ���ݿ�
    @BKPATH NVARCHAR(260)='', --�����ļ��Ĵ��Ŀ¼,��ָ����ʹ��SQLĬ�ϵı���Ŀ¼
    @BKFNAME NVARCHAR(260)='',--�����ļ���,�ļ����п�����\DBNAME\�������ݿ���,\DATE\��������,\TIME\����ʱ��
    @BKTYPE NVARCHAR(10)='DB',--��������:'DB'�������ݿ�,'DF' ���챸��,'LOG' ��־����
    @APPENDFILE BIT=1         --׷��/���Ǳ����ļ�
AS
BEGIN
    DECLARE @SQL VARCHAR(8000)
    IF ISNULL(@DBNAME,'')=''  SET @DBNAME=DB_NAME()--��ǰ���ݿ�
    IF ISNULL(@BKPATH,'')=''  SET @BKPATH=dbo.f_GetDBPath(NULL)
    IF ISNULL(@BKFNAME,'')='' SET @BKFNAME='\DBNAME\_\DATE\_\TIME\.BAK'
    
    SET @BKFNAME=REPLACE(REPLACE(REPLACE(@BKFNAME,'\DBNAME\',@DBNAME)
    ,'\DATE\',CONVERT(VARCHAR,GETDATE(),112))
    ,'\TIME\',REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''))
    
    SET @SQL='BACKUP '+CASE @BKTYPE WHEN 'LOG' THEN 'LOG ' ELSE 'DATABASE ' END
    +'['+@DBNAME+']'
    +' TO DISK='''+@BKPATH+@BKFNAME
    +''' WITH '+CASE @BKTYPE WHEN 'DF' THEN 'DIFFERENTIAL,' ELSE '' END
    +CASE @APPENDFILE WHEN 1 THEN 'NOINIT' ELSE 'INIT' END
    
    PRINT @SQL
    
    EXEC(@SQL)
    
    IF @@ERROR=0
    BEGIN
       PRINT '������־'
       INSERT INTO dbo.sys_BackupHistory(DBName,BackupFileName,BackupPath,BackupTime) VALUES
       (@DBNAME,@BKFNAME,@BKPATH+@BKFNAME,GETDATE())
    END
END
go

--=================================================================================================================--=================================================================================================================
USE [master]
GO

/****** Object:  StoredProcedure [dbo].[p_CreateJob]    Script Date: 10/24/2016 08:37:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_CreateJob]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[p_CreateJob]
GO

USE [master]
GO

/****** Object:  StoredProcedure [dbo].[p_CreateJob]    Script Date: 10/24/2016 08:37:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[p_CreateJob]
@jobname varchar(100), --��ҵ����
@sql varchar(8000), --Ҫִ�е�����
@dbname sysname='', --Ĭ��Ϊ��ǰ�����ݿ���
@freqtype varchar(6)='day', --ʱ������,month ��,week ��,day ��
@fsinterval int=1, --�����ÿ�յ��ظ�����
@time int=170000 --��ʼִ��ʱ��,�����ظ�ִ�е���ҵ,����0�㵽23:59��
as
if isnull(@dbname,'')='' set @dbname=db_name()

--������ҵ
exec msdb..sp_add_job @job_name=@jobname

--������ҵ����
exec msdb..sp_add_jobstep @job_name=@jobname,
@step_name = '���ݴ���',
@subsystem = 'TSQL',
@database_name=@dbname,
@command = @sql,
@retry_attempts = 5, --���Դ���
@retry_interval = 5 --���Լ��

--��������
declare @ftype int,@fstype int,@ffactor int
select @ftype=case @freqtype when 'day' then 4
when 'week' then 8
when 'month' then 16 end
,@fstype=case @fsinterval when 1 then 0 else 8 end
if @fsinterval<>1 set @time=0
set @ffactor=case @freqtype when 'day' then 0 else 1 end

EXEC msdb..sp_add_jobschedule @job_name=@jobname,
@name = 'ʱ�䰲��',
@freq_type=@ftype , --ÿ��,8 ÿ��,16 ÿ��
@freq_interval=1, --�ظ�ִ�д���
@freq_subday_type=@fstype, --�Ƿ��ظ�ִ��
@freq_subday_interval=@fsinterval, --�ظ�����
@freq_recurrence_factor=@ffactor,
@active_start_time=@time --����17:00:00��ִ��


GO
--=================================================================================================================--=================================================================================================================
USE [master]
GO

/****** Object:  StoredProcedure [dbo].[p_RestoreDB]    Script Date: 10/24/2016 08:39:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_RestoreDB]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[p_RestoreDB]
GO

USE [master]
GO

/****** Object:  StoredProcedure [dbo].[p_RestoreDB]    Script Date: 10/24/2016 08:39:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[p_RestoreDB]
    @BKFILE NVARCHAR(1000),   --����Ҫ�ָ��ı����ļ���
    @DBNAME SYSNAME,          --����ָ�������ݿ���,Ĭ��Ϊ���ݵ��ļ���
    @RETYPE NVARCHAR(10)='DB',--�ָ�����:'DB'�����ָ����ݿ�,'DBNOR' Ϊ����ָ�,��־�ָ����������ָ�,'DF' ���챸�ݵĻָ�,'LOG' ��־�ָ�
    @FILENUMBER INT=1,        --�ָ����ļ���
    @OVEREXIST BIT=1          --�Ƿ񸲸��Ѿ����ڵ����ݿ�,��@RETYPEΪ 
AS
BEGIN
    DECLARE @SQL VARCHAR(8000)
    --�õ��ָ�������ݿ���
    IF ISNULL(@DBNAME,'')=''
       SELECT @SQL=REVERSE(@BKFILE)
       ,@SQL=CASE WHEN CHARINDEX('.',@SQL)=0 THEN @SQL
       ELSE SUBSTRING(@SQL,CHARINDEX('.',@SQL)+1,1000) END
       ,@SQL=CASE WHEN CHARINDEX('\',@SQL)=0 THEN @SQL
       ELSE LEFT(@SQL,CHARINDEX('\',@SQL)-1) END
       ,@DBNAME=REVERSE(@SQL)
    --�������ݿ�ָ����
    SET @SQL='RESTORE '+CASE @RETYPE WHEN 'LOG' THEN 'LOG ' ELSE 'DATABASE ' END
       +'['+@DBNAME+']'
       +' FROM DISK='''+@BKFILE+''''
       +' WITH FILE='+CAST(@FILENUMBER AS VARCHAR)
       +CASE WHEN @OVEREXIST=1 AND @RETYPE IN('DB','DBNOR') THEN ',REPLACE' ELSE '' END
       +CASE @RETYPE WHEN 'DBNOR' THEN ',NORECOVERY' ELSE ',RECOVERY' END
    --�赱ǰ���ݿ�����״̬
    EXEC('ALTER DATABASE ['+@DBNAME+'] SET OFFLINE WITH ROLLBACK IMMEDIATE') 
    --�ָ����ݿ�
    EXEC(@SQL)
    --�赱ǰ���ݿ�����״̬
    EXEC('ALTER DATABASE ['+@DBNAME+'] SET ONLINE')
END

GO

--=================================================================================================================
--=================================================================================================================


USE [master]
GO

/****** Object:  UserDefinedFunction [dbo].[f_splitSTR]    Script Date: 10/24/2016 08:39:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[f_splitSTR]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[f_splitSTR]
GO

USE [master]
GO

/****** Object:  UserDefinedFunction [dbo].[f_splitSTR]    Script Date: 10/24/2016 08:39:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--����1��ѭ����ȡ��
CREATE FUNCTION [dbo].[f_splitSTR](
@s   varchar(8000),   --���ֲ���ַ���
@split varchar(10)     --���ݷָ���
)RETURNS @re TABLE(col varchar(100))
AS
BEGIN
 DECLARE @splitlen int
 SET @splitlen=LEN(@split+'a')-2
 WHILE CHARINDEX(@split,@s)>0
 BEGIN
  INSERT @re VALUES(LEFT(@s,CHARINDEX(@split,@s)-1))
  SET @s=STUFF(@s,1,CHARINDEX(@split,@s)+@splitlen,'')
 END
 INSERT @re VALUES(@s)
 RETURN
END

GO

--================================================================================================================
--================================================================================================================
USE [master]
GO

/****** Object:  UserDefinedFunction [dbo].[f_getdbpath]    Script Date: 10/24/2016 08:42:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[f_getdbpath]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[f_getdbpath]
GO

USE [master]
GO

/****** Object:  UserDefinedFunction [dbo].[f_getdbpath]    Script Date: 10/24/2016 08:42:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create function [dbo].[f_getdbpath](@dbname sysname)
returns nvarchar(260)
as
begin
declare @re nvarchar(260)
---���ݿ�����Ϊ�ջ���ϵͳ�����ڴ����ݿ������
if @dbname is null or db_id(@dbname) is null
	--select rtrim(reverse(filename)) from master..sysdatabases where name='master'
	select @re=rtrim(reverse(filename)) from master..sysdatabases where name='master'
else
	select @re=rtrim(reverse(filename)) from master..sysdatabases where name=@dbname
---
if @dbname is null
	set @re=reverse(substring(@re,charindex('\',@re)+5,260))+'BACKUP'
else
	set @re=reverse(substring(@re,charindex('\',@re),260))
return(@re)
end

GO

















