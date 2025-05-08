# 1. ASP.NET Core runtime - final stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

# 2. SDK image for build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Layihənin bütün fayllarını konteynerə kopyala
COPY . .

# WebAPI layihəsinin qovluğuna keç
WORKDIR /src/presentation/JobSearchManagementSystem.WebAPI

# Restore: bütün layihə asılılıqları
RUN dotnet restore JobSearchManagementSystem.WebAPI.csproj

# Publish: yayıma hazırla
RUN dotnet publish JobSearchManagementSystem.WebAPI.csproj -c Release -o /app/publish

# 3. Final image - sadəcə işləmək üçün lazım olanlar
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "JobSearchManagementSystem.WebAPI.dll"]
