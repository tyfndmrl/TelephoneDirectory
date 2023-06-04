#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/TelephoneDirectory.Directory/TelephoneDirectory.Directory.API/TelephoneDirectory.Directory.API.csproj", "src/TelephoneDirectory.Directory/TelephoneDirectory.Directory.API/"]
COPY ["src/TelephoneDirectory.Directory/TelephoneDirectory.Directory.DDD/TelephoneDirectory.Directory.DDD.csproj", "src/TelephoneDirectory.Directory/TelephoneDirectory.Directory.DDD/"]
COPY ["src/TelephoneDirectory.Directory/TelephoneDirectory.Directory.DTO/TelephoneDirectory.Directory.DTO.csproj", "src/TelephoneDirectory.Directory/TelephoneDirectory.Directory.DTO/"]
COPY ["src/TelephoneDirectory.Directory/TelephoneDirectory.Directory.Service/TelephoneDirectory.Directory.Service.csproj", "src/TelephoneDirectory.Directory/TelephoneDirectory.Directory.Service/"]
COPY ["src/TelephoneDirectory.Framework/TelephoneDirectory.Repository/TelephoneDirectory.Framework.Repository.csproj", "src/TelephoneDirectory.Framework/TelephoneDirectory.Repository/"]
RUN dotnet restore "src/TelephoneDirectory.Directory/TelephoneDirectory.Directory.API/TelephoneDirectory.Directory.API.csproj"
COPY . .
WORKDIR "/src/src/TelephoneDirectory.Directory/TelephoneDirectory.Directory.API"
RUN dotnet build "TelephoneDirectory.Directory.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TelephoneDirectory.Directory.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TelephoneDirectory.Directory.API.dll"]