FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build
WORKDIR /build
COPY . .
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1 AS runtime
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT [ "dotnet", "ProjectPorfolioSystem.dll" ]