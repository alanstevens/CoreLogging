dotnet build src/corelogging/corelogging.csproj -c Release
dotnet pack src/corelogging/corelogging.csproj -o %CD%\output -c Release
