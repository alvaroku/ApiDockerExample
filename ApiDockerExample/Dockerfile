# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar el .csproj desde la carpeta del proyecto
COPY ["ApiDockerExample/ApiDockerExample.csproj", "./"]
RUN dotnet restore "ApiDockerExample.csproj"

# Copiar el resto del código
COPY ApiDockerExample/. .
RUN dotnet publish "ApiDockerExample.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "ApiDockerExample.dll"]
