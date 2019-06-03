FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["StockTrader/StockTrader.csproj", "StockTrader/"]
RUN dotnet restore "StockTrader/StockTrader.csproj"
COPY . .
WORKDIR "/src/StockTrader"
RUN dotnet build "StockTrader.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "StockTrader.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StockTrader.dll"]