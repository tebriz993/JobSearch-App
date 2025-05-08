# Stage 1: Build Mərhələsi
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1. Əvvəlcə .sln və bütün .csproj fayllarını kopyala.
# Bu, Docker-in layer cache-indən daha effektiv istifadə etməyə imkan verir.
# Əgər .csproj faylları dəyişməyibsə, `dotnet restore` addımı yenidən işləməyəcək.

# Solution faylını kopyala
COPY ["JobSearch.sln", "."] # Kökə (.sln faylının olduğu yerə) kopyalanır: /src/JobSearch.sln

# Bütün layihələrin .csproj fayllarını, qovluq strukturlarını qoruyaraq kopyala
# Mənbə (source) path-lər build context-in kökünə nəzərən verilir.
# Hədəf (destination) path-lər WORKDIR (/src) -ə nəzərən verilir.
COPY ["src/Presentation/JobSearch.WebAPI/JobSearch.WebAPI.csproj", "src/Presentation/JobSearch.WebAPI/"]
COPY ["src/Core/JobSearch.Application/JobSearch.Application.csproj", "src/Core/JobSearch.Application/"]
COPY ["src/Core/JobSearch.Domain/JobSearch.Domain.csproj", "src/Core/JobSearch.Domain/"]
COPY ["src/Infrastructure/JobSearch.Infrastructure/JobSearch.Infrastructure.csproj", "src/Infrastructure/JobSearch.Infrastructure/"]
COPY ["src/Infrastructure/JobSearch.Persistence/JobSearch.Persistence.csproj", "src/Infrastructure/JobSearch.Persistence/"]

# 2. Layihənin asılılıqlarını bərpa et (dotnet restore)
# WORKDIR /src olduğu üçün və JobSearch.sln /src/JobSearch.sln-də olduğu üçün,
# restore əmri bütün kopyalanmış .csproj fayllarını düzgün tapacaq.
RUN dotnet restore "JobSearch.sln"

# 3. Qalan bütün mənbə kodunu kopyala
# Bu əmr build context-də olan hər şeyi WORKDIR (/src) içinə kopyalayacaq.
# Məsələn, context-dəki "src/" qovluğu "/src/src/" olaraq kopyalanacaq.
COPY . .

# 4. Əsas proqramı publish et
# WORKDIR /src olaraq qalır. Publish ediləcək layihənin yolu:
# /src/src/Presentation/JobSearch.WebAPI/JobSearch.WebAPI.csproj
RUN dotnet publish "src/Presentation/JobSearch.WebAPI/JobSearch.WebAPI.csproj" -c Release -o /app/publish --no-restore /p:UseAppHost=false

# Stage 2: Final Runtime Mərhələsi
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "JobSearch.WebAPI.dll"]
