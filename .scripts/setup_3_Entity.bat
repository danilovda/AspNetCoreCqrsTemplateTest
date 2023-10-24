set /p entityName=Entity name:
set /p apiName=Api name:

dotnet new ca-entity -n %entityName% -ap %apiName%

set /p name=name: