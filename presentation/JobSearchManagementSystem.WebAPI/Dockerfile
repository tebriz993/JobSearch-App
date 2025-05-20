# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Yalnız .sln və .csproj fayllarını kopyala (restore üçün)
# Bu yollar repository kökünə nəzərən olmalıdır
COPY JobSearch.sln .
COPY src/Presentation/JobSearchManagementSystem.WebAPI/JobSearchManagementSystem.WebAPI.csproj ./src/Presentation/JobSearchManagementSystem.WebAPI/
COPY src/Core/JobSearch.Application/JobSearch.Application.csproj ./src/Core/JobSearch.Application/
COPY src/Core/JobSearch.Domain/JobSearch.Domain.csproj ./src/Core/JobSearch.Domain/
COPY src/Infrastructure/JobSearch.Infrastructure/JobSearch.Infrastructure.csproj ./src/Infrastructure/JobSearch.Infrastructure/
COPY src/Infrastructure/JobSearch.Persistence/JobSearch.Persistence.csproj ./src/Infrastructure/JobSearch.Persistence/
# Əgər NuGet.config faylınız varsa və repository kökündədirsə, onu da kopyalayın:
# COPY NuGet.config .

# Asılılıqları bərpa et
RUN dotnet restore "JobSearch.sln"

# Bütün source kodu kopyala (artıq restore edilib)
# Repository kökündəki 'src' qovluğunun məzmununu Docker image-də /src/src/ altına kopyalayacaq
COPY src/ ./src/
# Əgər repository kökündəki 'presentation' qovluğundan da kod və ya fayllar lazımdırsa (Dockerfile-dan başqa):
# COPY presentation/ ./presentation/

# Publish et
# .csproj faylının WORKDIR (/src) daxilindəki düzgün yolu göstərin
RUN dotnet publish "src/Presentation/JobSearchManagementSystem.WebAPI/JobSearchManagementSystem.WebAPI.csproj" -c Release -o /app/publish --no-restore

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "JobSearchManagementSystem.WebAPI.dll"]
