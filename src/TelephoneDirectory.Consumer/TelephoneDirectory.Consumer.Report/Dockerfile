#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/TelephoneDirectory.Consumer/TelephoneDirectory.Consumer.Report/TelephoneDirectory.Consumer.Report.csproj", "src/TelephoneDirectory.Consumer/TelephoneDirectory.Consumer.Report/"]
COPY ["src/TelephoneDirectory.Framework/TelephoneDirectory.Framework.RabbitMQ/TelephoneDirectory.Framework.RabbitMQ.csproj", "src/TelephoneDirectory.Framework/TelephoneDirectory.Framework.RabbitMQ/"]
RUN dotnet restore "src/TelephoneDirectory.Consumer/TelephoneDirectory.Consumer.Report/TelephoneDirectory.Consumer.Report.csproj"
COPY . .
WORKDIR "/src/src/TelephoneDirectory.Consumer/TelephoneDirectory.Consumer.Report"
RUN dotnet build "TelephoneDirectory.Consumer.Report.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TelephoneDirectory.Consumer.Report.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TelephoneDirectory.Consumer.Report.dll"]