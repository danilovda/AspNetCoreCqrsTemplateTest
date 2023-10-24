set /p solutionName=Solution name:
set /p serviceName=Api name:
set /p entityName=Entity name:

dotnet new sln -o %solutionName%
mkdir %solutionName%\Services

cd %solutionName%\Services
dotnet new mywebapi -n %serviceName%

cd ..

dotnet sln add Services\%serviceName%\src\%serviceName%.Api\%serviceName%.Api.csproj
dotnet sln add Services\%serviceName%\src\%serviceName%.Contracts\%serviceName%.Contracts.csproj
dotnet sln add Services\%serviceName%\src\%serviceName%.Infrastructure\%serviceName%.Infrastructure.csproj
dotnet sln add Services\%serviceName%\src\%serviceName%.Application\%serviceName%.Application.csproj
dotnet sln add Services\%serviceName%\src\%serviceName%.Domain\%serviceName%.Domain.csproj

dotnet sln add Services\%serviceName%\tests\%serviceName%.FunctionalTests\%serviceName%.FunctionalTests.csproj

cd .\Services\
dotnet new cqrs -n %entityName% -ap %apiName%
@REM dotnet new cqrs -n Department -ap %serviceName%

set /p name=name: