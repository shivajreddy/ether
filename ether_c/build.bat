@echo off
setlocal enabledelayedexpansion

:: Set up the Visual Studio environment (Uncomment if needed)
call "C:\Program Files\Microsoft Visual Studio\2022\Community\VC\Auxiliary\Build\vcvars64.bat"

:: Navigate to the project root and create the build directory if needed
mkdir build
pushd build

:: Compile the C file
echo Compiling...
cl -Zi ..\src\main.c user32.lib gdi32.lib

:: Check if compilation succeeded before running
if exist main.exe (
    echo Running the executable...
    start main.exe
) else (
    echo Compilation failed. Exe not found.
)

popd
endlocal

