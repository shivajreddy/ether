@echo off
setlocal enabledelayedexpansion

:: Set up the Visual Studio environment (Uncomment if needed)
REM call "C:\Program Files\Microsoft Visual Studio\2022\Community\VC\Auxiliary\Build\vcvars64.bat"

:: Navigate to the project root and create the build directory if needed
mkdir build
pushd build

:: Compile the C file
echo Compiling...
REM cl -Zi ..\src\main.c user32.lib gdi32.lib
cl /Zi /Od ..\src\main.c user32.lib gdi32.lib

:: Check if compilation succeeded before running
if exist main.exe (
    REM echo Running the executable...
    start main.exe
    echo Debugging the executable...
    REM For first time just run 'devenv main.exe' so that VS2022 opens this exe
    REM start devenv "main.exe"
) else (
    echo Compilation failed. Exe not found.
)

popd
endlocal

