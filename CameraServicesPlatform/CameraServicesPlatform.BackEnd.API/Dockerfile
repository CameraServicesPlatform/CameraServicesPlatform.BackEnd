FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
# Expose HTTP ports
EXPOSE 8080
EXPOSE 8081

# Set environment variable to use HTTP
ENV ASPNETCORE_URLS=http://+:8080

# Use the .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files and restore dependencies
COPY ["CameraServicesPlatform.BackEnd.API/CameraServicesPlatform.BackEnd.API.csproj", "CameraServicesPlatform.BackEnd.API/"]
COPY ["CameraServicesPlatform.BackEnd.Application/CameraServicesPlatform.BackEnd.Application.csproj", "CameraServicesPlatform.BackEnd.Application/"]
COPY ["CameraServicesPlatform.BackEnd.Common/CameraServicesPlatform.BackEnd.Common.csproj", "CameraServicesPlatform.BackEnd.Common/"]
COPY ["CameraServicesPlatform.BackEnd.Domain/CameraServicesPlatform.BackEnd.Domain.csproj", "CameraServicesPlatform.BackEnd.Domain/"]
COPY ["CameraServicesPlatform.BackEnd.Infrastructure/CameraServicesPlatform.BackEnd.Infrastructure.csproj", "CameraServicesPlatform.BackEnd.Infrastructure/"]
RUN dotnet restore "./CameraServicesPlatform.BackEnd.API/CameraServicesPlatform.BackEnd.API.csproj"

# Copy remaining source code
COPY . .
WORKDIR "/src/CameraServicesPlatform.BackEnd.API"

# Build the application
RUN dotnet build "./CameraServicesPlatform.BackEnd.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "./CameraServicesPlatform.BackEnd.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final image for production
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CameraServicesPlatform.BackEnd.API.dll"]
