set /p entityName=Entity name:
set /p apiName=Api name:

dotnet new cqrs -n %entityName% -ap %apiName%

set /p name=name: