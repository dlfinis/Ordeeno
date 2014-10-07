@ECHO off
sqlcmd -S localhost -E /i db_detach.sql
xcopy /i "C:\SisElectro\DB Backup\sistema.mdf" /D "C:\SisElectro\DB"
xcopy /i "C:\SisElectro\DB Backup\sistema_log.ldf" /D "C:\SisElectro\DB"
sqlcmd -S localhost -E /i db_attach.sql
ECHO.
ECHO. Si no se presenta Errores.Se termino con exito..
Echo.
Pause.
