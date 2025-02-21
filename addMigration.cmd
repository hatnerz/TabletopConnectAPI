@echo off
set /p migrationName=Enter Migration Name: 

if "%migrationName%"=="" (
    echo Name cannot be empty string
    pause
    exit /b 1
)

echo Adding migration "%migrationName%"...
dotnet ef migrations add "%migrationName%" --project src/TabletopConnect.Persistence --startup-project src/TabletopConnect.API --context TabletopDbContext

if %ERRORLEVEL% neq 0 (
    echo An error occurred while creating the migration
    pause
    exit /b %ERRORLEVEL%
)

echo Migration added successfully
pause