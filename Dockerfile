FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY *.csproj ./
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# O Render define a variável PORT automaticamente
# O Program.cs já lê essa variável
EXPOSE 80

ENTRYPOINT ["dotnet", "MusicamFluereAPI.dll"]
