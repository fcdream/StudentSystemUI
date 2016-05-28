use master--使用系统数据库
go
IF EXISTS ( SELECT * FROM    dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[P_KillConnections]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1 ) --判断是否存在关闭进程的存储过程
    DROP PROCEDURE [dbo].[P_KillConnections] --删除关闭进程的存储过程
GO
CREATE PROC P_KillConnections @dbname VARCHAR(200)--创建关闭进程的存储过程
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

if exists(select * from sys.databases where [name]='studentdb')--查询BookDB数据库是否存在
begin
	if exists(SELECT * FROM [Master].[dbo].[SYSPROCESSES] WHERE [DBID] IN ( SELECT [DBID]FROM [Master].[dbo].[SYSDATABASES]WHERE NAME='studentdb'))
	begin		
	 --DROP PROCEDURE [dbo].[P_KillConnections]--断开所有与BookDB的连接
	 --close studentdb -- 关闭数据库	 
	--修改一下
	backup database studentdb To disk='d:\studentdb.bak' 
	EXEC P_KillConnections 'studentdb'
	end
	drop database studentdb--删除BookDB数据库
end
go
create database studentdb
go
use studentdb
go
if exists(select * from sys.objects where [name]='UserInfo')--查询用户信息表是否存在
begin
	drop table UserInfo--删除用户信息表
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
if exists(select * from sys.objects where [name]='ClassInfo')--查询班级信息表是否存在
begin
	drop table ClassInfo--删除班级信息表
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
if exists(select * from sys.objects where [name]='studentinfo')--查询学生信息表是否存在
begin
	drop table studentinfo--删除学生信息表
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
insert into studentinfo values('201600101',1,'张秋丽','女',20,'13112345678','重庆',NULL)
insert into studentinfo values('201600102',1,'欧阳俊雄','男',25,'19856365452','北京',NULL)
insert into studentinfo values('201600201',2,'张大大','男',22,'13152698569','河北',NULL)
insert into studentinfo values('201600202',2,'李小小','女',19,'18745632587','东北',NULL)
insert into studentinfo values('201600301',3,'梅超风','男',22,'13152698569','河北',NULL)
insert into studentinfo values('201600302',3,'韦小宝','女',19,'18745632587','东北',NULL)
insert into studentinfo values('201600401',4,'张花','男',22,'13152698349','河北',NULL)
insert into studentinfo values('201600402',4,'牛二','女',19,'18745632527','东北',NULL)
insert into studentinfo values('201600501',5,'展昭','男',22,'13152698569','河北',NULL)
insert into studentinfo values('201600502',5,'包拯','女',19,'18745631287','东北',NULL)
go
select * from userinfo 
select * from ClassInfo 
select * from studentinfo