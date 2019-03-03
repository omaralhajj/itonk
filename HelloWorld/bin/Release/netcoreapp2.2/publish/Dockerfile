FROM gcr.io/google-appengine/aspnetcore:2.2
ADD ./ /app
ENV ASPNETCORE_URLS=http://*:${PORT}
WORKDIR /app
ENTRYPOINT [ "dotnet", "HW-MVCANCF19ITONKjrt.dll"]