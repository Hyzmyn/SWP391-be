# Use .NET base image for Linux
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SWP391_PawFund/SWP391_PawFund.csproj", "SWP391_PawFund/"]
COPY ["ServiceLayer/ServiceLayer.csproj", "ServiceLayer/"]
COPY ["RepositoryLayer/RepositoryLayer.csproj", "RepositoryLayer/"]
COPY ["ModelLayer/ModelLayer.csproj", "ModelLayer/"]
RUN dotnet restore "./SWP391_PawFund/SWP391_PawFund.csproj"
COPY . .
WORKDIR "/src/SWP391_PawFund"
RUN dotnet build "./SWP391_PawFund.csproj" -c %BUILD_CONFIGURATION% -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SWP391_PawFund.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SWP391_PawFund.dll"]