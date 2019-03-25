#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM gcr.io/google-appengine/aspnetcore:2.1
ADD dist /app
WORKDIR /app
ENTRYPOINT [ "dotnet", "frontend.dll"]