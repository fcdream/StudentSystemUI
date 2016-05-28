use master--ʹ��ϵͳ���ݿ�
go
IF EXISTS ( SELECT * FROM    dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[P_KillConnections]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1 ) --�ж��Ƿ���ڹرս��̵Ĵ洢����
    DROP PROCEDURE [dbo].[P_KillConnections] --ɾ���رս��̵Ĵ洢����
GO
CREATE PROC P_KillConnections @dbname VARCHAR(200)--�����رս��̵Ĵ洢����
AS 
    DECLARE @sql NVARCHAR(500)
    DECLARE @spid NVARCHAR(20)

    DECLARE #tb CURSOR FOR
    SELECT spid=CAST(spid AS VARCHAR(20)) FROM master..sysprocesses WHERE dbid=DB_ID(@dbname)
    OPEN #tb
    FETCH NEXT FROM #tb INTO @spid
    WHILE @@fetch_status = 0 
        BEGIN
            EXEC('kill '+@spid)
            FETCH NEXT FROM #tb INTO @spid
        END
    CLOSE #tb
    DEALLOCATE #tb
go

if exists(select * from sys.databases where [name]='studentdb')--��ѯBookDB���ݿ��Ƿ����
begin
	if exists(SELECT * FROM [Master].[dbo].[SYSPROCESSES] WHERE [DBID] IN ( SELECT [DBID]FROM [Master].[dbo].[SYSDATABASES]WHERE NAME='studentdb'))
	begin		
	 --DROP PROCEDURE [dbo].[P_KillConnections]--�Ͽ�������BookDB������
	 --close studentdb -- �ر����ݿ�	 
	--�޸�һ��
	backup database studentdb To disk='d:\studentdb.bak' 
	EXEC P_KillConnections 'studentdb'
	end
	drop database studentdb--ɾ��BookDB���ݿ�
end
go
create database studentdb
go
use studentdb
go
if exists(select * from sys.objects where [name]='UserInfo')--��ѯ�û���Ϣ���Ƿ����
begin
	drop table UserInfo--ɾ���û���Ϣ��
end
go
create table UserInfo
(
	userid  int primary key identity(1,1),
	username varchar(20),
	userpwd varchar(20)
)
go
insert into UserInfo values('admin','admin')
go
if exists(select * from sys.objects where [name]='ClassInfo')--��ѯ�༶��Ϣ���Ƿ����
begin
	drop table ClassInfo--ɾ���༶��Ϣ��
end
go
create table ClassInfo
(
	classId int identity(1,1) primary key,
	className varchar(20) not null
)
go
insert into ClassInfo values('2016001')
insert into ClassInfo values('2016002')
insert into ClassInfo values('2016003')
insert into ClassInfo values('2016004')
insert into ClassInfo values('2016005')
go
if exists(select * from sys.objects where [name]='studentinfo')--��ѯѧ����Ϣ���Ƿ����
begin
	drop table studentinfo--ɾ��ѧ����Ϣ��
end
go
create table studentinfo
(
	stuNo varchar(10) primary key,
	clasId int references classinfo(classid),
	stuname varchar(20) not null,
	stusex varchar(4) not null,
	stuage int not null,
	stuphone varchar(20) not null,
	stuaddress varchar(20) not null,
	stureamrk varchar(20)
)
go
insert into studentinfo values('201600101',1,'������','Ů',20,'13112345678','����',NULL)
insert into studentinfo values('201600102',1,'ŷ������','��',25,'19856365452','����',NULL)
insert into studentinfo values('201600201',2,'�Ŵ��','��',22,'13152698569','�ӱ�',NULL)
insert into studentinfo values('201600202',2,'��СС','Ů',19,'18745632587','����',NULL)
insert into studentinfo values('201600301',3,'÷����','��',22,'13152698569','�ӱ�',NULL)
insert into studentinfo values('201600302',3,'ΤС��','Ů',19,'18745632587','����',NULL)
insert into studentinfo values('201600401',4,'�Ż�','��',22,'13152698349','�ӱ�',NULL)
insert into studentinfo values('201600402',4,'ţ��','Ů',19,'18745632527','����',NULL)
insert into studentinfo values('201600501',5,'չ��','��',22,'13152698569','�ӱ�',NULL)
insert into studentinfo values('201600502',5,'����','Ů',19,'18745631287','����',NULL)
go
select * from userinfo 
select * from ClassInfo 
select * from studentinfo