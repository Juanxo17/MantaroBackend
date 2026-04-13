# Imagen base para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

# Imagen de construcción (SDK)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos el archivo de proyecto y restauramos dependencias
COPY ["MantaroBot.csproj", "./"]
RUN dotnet restore "MantaroBot.csproj"

# Copiamos el resto del código y construimos
COPY . .
WORKDIR "/src/"
RUN dotnet build "MantaroBot.csproj" -c Release -o /app/build

# Publicamos la aplicación
FROM build AS publish
RUN dotnet publish "MantaroBot.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Imagen final (mezcla la base con lo publicado)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MantaroBot.dll"]