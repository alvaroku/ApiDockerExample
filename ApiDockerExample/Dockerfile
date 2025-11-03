# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar csproj y restaurar dependencias
COPY ["ApiDockerExample/ApiDockerExample.csproj", "./ApiDockerExample/"]
RUN dotnet restore "./ApiDockerExample/ApiDockerExample.csproj"

# Copiar todo el código y compilar
COPY . .
WORKDIR "/src/ApiDockerExample"
RUN dotnet build "ApiDockerExample.csproj" -c Release -o /app/build

# Etapa 2: publish
FROM build AS publish
RUN dotnet publish "ApiDockerExample.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa 3: final
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "ApiDockerExample.dll"]
