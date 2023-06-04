#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/TelephoneDirectory.Report/TelephoneDirectory.Report.API/TelephoneDirectory.Report.API.csproj", "src/TelephoneDirectory.Report/TelephoneDirectory.Report.API/"]
COPY ["src/TelephoneDirectory.Report/TelephoneDirectory.Report.DDD/TelephoneDirectory.Report.DDD.csproj", "src/TelephoneDirectory.Report/TelephoneDirectory.Report.DDD/"]
COPY ["src/TelephoneDirectory.Report/TelephoneDirectory.Report.DTO/TelephoneDirectory.Report.DTO.csproj", "src/TelephoneDirectory.Report/TelephoneDirectory.Report.DTO/"]
COPY ["src/TelephoneDirectory.Report/TelephoneDirectory.Report.Service/TelephoneDirectory.Report.Service.csproj", "src/TelephoneDirectory.Report/TelephoneDirectory.Report.Service/"]
COPY ["src/TelephoneDirectory.Framework/TelephoneDirectory.Repository/TelephoneDirectory.Framework.Repository.csproj", "src/TelephoneDirectory.Framework/TelephoneDirectory.Repository/"]
COPY ["src/TelephoneDirectory.Framework/TelephoneDirectory.RabbitMQ/TelephoneDirectory.Framework.RabbitMQ.csproj", "src/TelephoneDirectory.Framework/TelephoneDirectory.RabbitMQ/"]
RUN dotnet restore "src/TelephoneDirectory.Report/TelephoneDirectory.Report.API/TelephoneDirectory.Report.API.csproj"
COPY . .
WORKDIR "/src/src/TelephoneDirectory.Report/TelephoneDirectory.Report.API"
RUN dotnet build "TelephoneDirectory.Report.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TelephoneDirectory.Report.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TelephoneDirectory.Report.API.dll"]