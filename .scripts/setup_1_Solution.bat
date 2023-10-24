set /p solutionName=Solution name:

dotnet new sln -o %solutionName%
mkdir %solutionName%\Services

set /p name=name: