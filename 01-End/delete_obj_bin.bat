@echo off
set /p folder=Enter folder path:
echo Deleting obj and bin folders in %folder% ...

for /d /r "%folder%" %%a in (obj bin) do (
    echo Deleting "%%a" ...
    rd /s /q "%%a"
)

echo All obj and bin folders have been deleted.
pause
