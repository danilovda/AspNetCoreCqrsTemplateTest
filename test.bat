#!/bin/bash

dotnet new sln -o Sln

dotnet new web -o Api
dotnet new classlib -o Contracts
dotnet new classlib -o Infrastructure
dotnet new classlib -o Application
dotnet new classlib -o Domain

dotnet sln Sln.sln add Api/Api.csproj
dotnet sln Sln.sln add Contracts/Contracts.csproj
dotnet sln Sln.sln add Infrastructure/Infrastructure.csproj
dotnet sln Sln.sln add Application/Application.csproj
dotnet sln Sln.sln add Domain/Domain.csproj
