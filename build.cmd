@echo off
SETLOCAL


.paket\paket.bootstrapper.exe
if errorlevel 1 (
  exit /b %errorlevel%
)

.paket\paket.exe restore
if errorlevel 1 (
  exit /b %errorlevel%
)

:Build
cls

SET FAKE_PATH=packages\build\FAKE\tools\Fake.exe
SET Platform=

IF [%1]==[] (
    "%FAKE_PATH%" "build.fsx" "Default" 
) ELSE (
    "%FAKE_PATH%" "build.fsx" %* 
) 

if defined TEAMCITY_PROJECT_NAME goto Quit

rem Loop the build script.
set CHOICE=nothing
echo (Q)uit, (Enter) runs the build again
set /P CHOICE= 
if /i "%CHOICE%"=="Q" goto :Quit

GOTO Build

:Quit
exit /b %errorlevel%
