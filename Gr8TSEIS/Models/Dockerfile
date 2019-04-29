#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 56148
EXPOSE 44388

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["Models/Models.csproj", "Models/"]
RUN dotnet restore "Models/Models.csproj"
COPY . .
WORKDIR "/src/Models"
RUN dotnet build "Models.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Models.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Models.dll"]