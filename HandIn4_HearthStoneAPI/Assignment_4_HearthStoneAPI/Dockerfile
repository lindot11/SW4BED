# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Assignment_4_HearthStoneAPI/*.csproj ./Assignment_4_HearthStoneAPI/
RUN dotnet restore

# copy everything else and build app
COPY Assignment_4_HearthStoneAPI/. ./Assignment_4_HearthStoneAPI/
WORKDIR /source/Assignment_4_HearthStoneAPI
RUN dotnet publish -c release -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "Assignment_4_HearthStoneAPI.dll"]