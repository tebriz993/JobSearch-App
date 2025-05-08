FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# .csproj-ı düzgün path-dən kopyala
COPY ["src/Presentation/JobSearch.WebAPI/JobSearch.WebAPI.csproj", "src/Presentation/JobSearch.WebAPI/"]
RUN dotnet restore "src/Presentation/JobSearch.WebAPI/JobSearch.WebAPI.csproj" # ← Düzəliş!

# Sonra bütün faylları kopyala
COPY . .
WORKDIR "/src/src/Presentation/JobSearch.WebAPI"
RUN dotnet build "JobSearch.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JobSearch.WebAPI.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JobSearch.WebAPI.dll"] # DLL adı da dəyişdi!
