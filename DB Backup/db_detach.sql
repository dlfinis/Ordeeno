USE master;
GO
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'sistema')
BEGIN
    DROP DATABASE sistema
END
go
