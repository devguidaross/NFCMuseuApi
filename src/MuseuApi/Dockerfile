FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
LABEL version="1.0" mainteiner="Guilherme Daros"

WORKDIR /app

COPY ./publish .

ENTRYPOINT ["dotnet", "MuseuApi.dll"]