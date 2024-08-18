# Establecer la imagen base para el SDK de .NET
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

# Establecer el directorio de trabajo
WORKDIR /app

# Copiar el archivo .csproj y restaurar las dependencias
COPY Api.Verbs.Dictionary/*.csproj ./Api.Verbs.Dictionary/
RUN dotnet restore Api.Verbs.Dictionary/Api.Verbs.Dictionary.csproj

# Copiar el resto de los archivos y construir la aplicación
COPY Api.Verbs.Dictionary/ ./Api.Verbs.Dictionary/
WORKDIR /app/Api.Verbs.Dictionary
RUN dotnet build -c Release -o /app/build

# Establecer la imagen base para el runtime de .NET
FROM mcr.microsoft.com/dotnet/aspnet:7.0

# Establecer el directorio de trabajo
WORKDIR /app

# Copiar los archivos de la compilación desde el contenedor anterior
COPY --from=build-env /app/build .

# Exponer el puerto y ejecutar la aplicación
EXPOSE 80
ENTRYPOINT ["dotnet", "Api.Verbs.Dictionary.dll"]

