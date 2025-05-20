# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Solution və layihə fayllarını yuxarıdan gətir
COPY ../../JobSearch.sln .

COPY ../../src/Presentation/JobSearch.WebAPI/JobSearch.WebAPI.csproj src/Presentation/JobSearch.WebAPI/
COPY ../../src/Core/JobSearch.Application/JobSearch.Application.csproj src/Core/JobSearch.Application/
COPY ../../src/Core/JobSearch.Domain/JobSearch.Domain.csproj src/Core/JobSearch.Domain/
COPY ../../src/Infrastructure/JobSearch.Infrastructure/JobSearch.Infrastructure.csproj src/Infrastructure/JobSearch.Infrastructure/
COPY ../../src/Infrastructure/JobSearch.Persistence/JobSearch.Persistence.csproj src/Infrastructure/JobSearch.Persistence/

# Asılılıqları bərpa et
RUN dotnet restore "JobSearch.sln"

# Qalan faylları gətir
COPY ../../ .

# Publish et
RUN dotnet publish "src/Presentation/JobSearch.WebAPI/JobSearch.WebAPI.csproj" -c Release -o /app/publish --no-restore

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "JobSearch.WebAPI.dll"]
