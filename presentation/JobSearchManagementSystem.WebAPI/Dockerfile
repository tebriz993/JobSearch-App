# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Yalnız .sln və .csproj fayllarını kopyala (restore üçün)
COPY JobSearch.sln .
COPY src/Presentation/JobSearch.WebAPI/JobSearch.WebAPI.csproj ./src/Presentation/JobSearch.WebAPI/
COPY src/Core/JobSearch.Application/JobSearch.Application.csproj ./src/Core/JobSearch.Application/
COPY src/Core/JobSearch.Domain/JobSearch.Domain.csproj ./src/Core/JobSearch.Domain/
COPY src/Infrastructure/JobSearch.Infrastructure/JobSearch.Infrastructure.csproj ./src/Infrastructure/JobSearch.Infrastructure/
COPY src/Infrastructure/JobSearch.Persistence/JobSearch.Persistence.csproj ./src/Infrastructure/JobSearch.Persistence/
# Əgər NuGet.config faylınız varsa, onu da kopyalayın
# COPY NuGet.config .

# Asılılıqları bərpa et
RUN dotnet restore "JobSearch.sln"

# Bütün source kodu kopyala (artıq restore edilib)
# 'src' qovluğundakı bütün məzmunu /src/src altına kopyalayacaq
COPY src/ ./src/
# Əgər presentation qovluğunda da kod varsa və lazımdırsa:
# COPY presentation/ ./presentation/

# Publish et
# Publish üçün .csproj faylının WORKDIR (/src) içindəki düzgün yolunu göstərin
RUN dotnet publish "src/Presentation/JobSearch.WebAPI/JobSearch.WebAPI.csproj" -c Release -o /app/publish --no-restore

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "JobSearch.WebAPI.dll"]
