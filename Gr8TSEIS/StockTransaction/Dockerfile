#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 54651
EXPOSE 44365

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["StockTransaction/StockTransaction.csproj", "StockTransaction/"]
RUN dotnet restore "StockTransaction/StockTransaction.csproj"
COPY . .
WORKDIR "/src/StockTransaction"
RUN dotnet build "StockTransaction.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "StockTransaction.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StockTransaction.dll"]