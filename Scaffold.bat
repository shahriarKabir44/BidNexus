@echo off
for /f "delims=" %%i in ('powershell -Command "(Get-Content appsettings.json | ConvertFrom-Json).ConnectionStrings.DefaultConnectionString"') do set connStr=%%i
echo Scaffolding models from database...
dotnet ef dbcontext scaffold "%connStr%" Microsoft.EntityFrameworkCore.SqlServer -o Models --force
pause
