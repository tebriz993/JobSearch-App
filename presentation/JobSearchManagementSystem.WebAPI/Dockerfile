# 1. Runtime üçün ASP.NET image (son mərhələ üçün)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

# 2. Build mərhələsi üçün SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Layihənin bütün mənbə kodlarını konteynerə kopyala
COPY . .

# WebAPI layihəsinin qovluğuna keç
WORKDIR /src/presentation/JobSearchManagementSystem.WebAPI

# .csproj faylını explicit göstər və bərpa et
RUN dotnet restore JobSearchManagementSystem.WebAPI.csproj

# Layihəni yayımla
RUN dotnet publish JobSearchManagementSystem.WebAPI.csproj -c Release -o /app/publish

# 3. Final image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "JobSearchManagementSystem.WebAPI.dll"]
