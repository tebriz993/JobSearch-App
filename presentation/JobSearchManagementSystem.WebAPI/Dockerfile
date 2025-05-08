# 1. Base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

# 2. Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Faylları konteynerə kopyala
COPY . .

# Sadəcə .csproj faylının olduğu yerə keç
WORKDIR /src/presentation/JobSearchManagementSystem.WebAPI

# Restore və build
RUN dotnet restore JobSearchManagementSystem.WebAPI.csproj
RUN dotnet publish JobSearchManagementSystem.WebAPI.csproj -c Release -o /app/publish

# 3. Final image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "JobSearchManagementSystem.WebAPI.dll"]
