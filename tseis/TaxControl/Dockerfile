FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["TaxControl/TaxControl.csproj", "TaxControl/"]
RUN dotnet restore "TaxControl/TaxControl.csproj"
COPY . .
WORKDIR "/src/TaxControl"
RUN dotnet build "TaxControl.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TaxControl.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TaxControl.dll"]