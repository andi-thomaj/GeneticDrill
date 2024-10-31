FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["GeneticDrill.WebApi/GeneticDrill.WebApi.csproj", "GeneticDrill.WebApi/"]
RUN dotnet restore "GeneticDrill.WebApi/GeneticDrill.WebApi.csproj"
COPY . .
WORKDIR "/src/GeneticDrill.WebApi"
RUN dotnet build "GeneticDrill.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "GeneticDrill.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GeneticDrill.WebApi.dll"]
