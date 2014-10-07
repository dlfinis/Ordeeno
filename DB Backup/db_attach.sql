use master;
go
create database sistema
on primary (filename = 'C:\SisElectro\DB\sistema.mdf')
log on (filename =     'C:\SisE\DB\sistema_log.ldf')
for attach
go