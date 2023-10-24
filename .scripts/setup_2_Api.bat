set /p serviceName=Api name:

dotnet new mywebapi -n %serviceName%

cd ..

dotnet sln add Services\%serviceName%\src\%serviceName%.Api\%serviceName%.Api.csproj
dotnet sln add Services\%serviceName%\src\%serviceName%.Contracts\%serviceName%.Contracts.csproj
dotnet sln add Services\%serviceName%\src\%serviceName%.Infrastructure\%serviceName%.Infrastructure.csproj
dotnet sln add Services\%serviceName%\src\%serviceName%.Application\%serviceName%.Application.csproj
dotnet sln add Services\%serviceName%\src\%serviceName%.Domain\%serviceName%.Domain.csproj

dotnet sln add Services\%serviceName%\tests\%serviceName%.FunctionalTests\%serviceName%.FunctionalTests.csproj

set /p name=name: