# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CameraServicesPlatform.BackEnd.API/CameraServicesPlatform.BackEnd.API.csproj", "CameraServicesPlatform.BackEnd.API/"]
COPY ["CameraServicesPlatform.BackEnd.Application/CameraServicesPlatform.BackEnd.Application.csproj", "CameraServicesPlatform.BackEnd.Application/"]
COPY ["CameraServicesPlatform.BackEnd.Common/CameraServicesPlatform.BackEnd.Common.csproj", "CameraServicesPlatform.BackEnd.Common/"]
COPY ["CameraServicesPlatform.BackEnd.Domain/CameraServicesPlatform.BackEnd.Domain.csproj", "CameraServicesPlatform.BackEnd.Domain/"]
COPY ["CameraServicesPlatform.BackEnd.Infrastructure/CameraServicesPlatform.BackEnd.Infrastructure.csproj", "CameraServicesPlatform.BackEnd.Infrastructure/"]
RUN dotnet restore "./CameraServicesPlatform.BackEnd.API/CameraServicesPlatform.BackEnd.API.csproj"
COPY . .
WORKDIR "/src/CameraServicesPlatform.BackEnd.API"
RUN dotnet build "./CameraServicesPlatform.BackEnd.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish Stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CameraServicesPlatform.BackEnd.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final Stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CameraServicesPlatform.BackEnd.API.dll"]
