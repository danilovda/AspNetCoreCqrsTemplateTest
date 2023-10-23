```bash
$name="Skeleton"
$path=".\$name\src"
$pathTest=".\$name\tests"
dotnet new sln -o $name

cd $name

mkdir .github\workflows
New-Item .github\workflows\$name.yml
#touch .github\workflows\$name.yml

dotnet new web -o $path\$name.Api
dotnet new classlib -o $path\$name.Contracts
dotnet new classlib -o $path\$name.Infrastructure
dotnet new classlib -o $path\$name.Application
dotnet new classlib -o $path\$name.Domain

dotnet new xunit -o $pathTest\$name.FunctionalTests

rm $path\$name.Contracts\class1.cs
rm $path\$name.Infrastructure\class1.cs
rm $path\$name.Application\class1.cs
rm $path\$name.Domain\class1.cs

#dotnet build

#dotnet sln add (ls -r \*\*\*.csproj)
dotnet sln add $path\$name.Api\$name.Api.csproj
dotnet sln add $path\$name.Contracts\$name.Contracts.csproj
dotnet sln add $path\$name.Infrastructure\$name.Infrastructure.csproj
dotnet sln add $path\$name.Application\$name.Application.csproj
dotnet sln add $path\$name.Domain\$name.Domain.csproj
dotnet sln add $pathTest\$name.FunctionalTests\$name.FunctionalTests.csproj

dotnet build

dotnet add $path\$name.Api reference $path\$name.Contracts $path\$name.Application $path\$name.Infrastructure
dotnet add $path\$name.Infrastructure reference $path\$name.Application
dotnet add $path\$name.Application reference $path\$name.Domain
dotnet add $pathTest\$name.FunctionalTests reference $path\$name.Api $path\$name.Infrastructure

dotnet add $path\$name.Application package FluentValidation
dotnet add $path\$name.Application package FluentValidation.AspNetCore
dotnet add $path\$name.Application package Mapster
dotnet add $path\$name.Application package Mapster.DependencyInjection
dotnet add $path\$name.Application package MediatR
dotnet add $path\$name.Application package Microsoft.Extensions.DependencyInjection.Abstractions

dotnet add $path\$name.Infrastructure package Microsoft.EntityFrameworkCore
dotnet add $path\$name.Infrastructure package Microsoft.EntityFrameworkCore.SqlServer
dotnet add $path\$name.Infrastructure package Microsoft.Extensions.Configuration

dotnet add $pathTest\$name.FunctionalTests package Microsoft.AspNetCore.Mvc.Testing

```
