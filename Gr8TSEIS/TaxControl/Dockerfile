#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 54669
EXPOSE 44314

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
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