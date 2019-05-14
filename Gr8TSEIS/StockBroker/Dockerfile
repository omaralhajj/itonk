#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM gcr.io/google-appengine/aspnetcore:2.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM gcr.io/google-appengine/aspnetcore:2.1 AS build
WORKDIR /src
COPY ["StockBroker/StockBroker.csproj", "StockBroker/"]
RUN dotnet restore "StockBroker/StockBroker.csproj"
COPY . .
WORKDIR "/src/StockBroker"
RUN dotnet build "StockBroker.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "StockBroker.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StockBroker.dll"]