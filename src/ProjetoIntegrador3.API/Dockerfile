FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ProjetoIntegrador3.API/ProjetoIntegrador3.API.csproj", "ProjetoIntegrador3.API/"]
COPY ["src/ProjetoIntegrador3.Infra.Identity/ProjetoIntegrador3.Infra.Identity.csproj", "ProjetoIntegrador3.Infra.Identity/"]
COPY ["src/ProjetoIntegrador3.Infra.Data/ProjetoIntegrador3.Infra.Data.csproj", "ProjetoIntegrador3.Infra.Data/"]
RUN dotnet restore "ProjetoIntegrador3.API/ProjetoIntegrador3.API.csproj"
WORKDIR "ProjetoIntegrador3.API"
COPY . .
RUN dotnet build "ProjetoIntegrador3.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ProjetoIntegrador3.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjetoIntegrador3.API.dll"]
