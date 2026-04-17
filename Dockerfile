FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY *.csproj ./
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# Pega a variavél do Render ou se não tiver definida coloca como 80 por padrão
ARG PORT=80
ENV PORT=$PORT

# O Program.cs já lê essa variável
EXPOSE $PORT

ENTRYPOINT ["dotnet", "MusicamFluereAPI.dll"]
