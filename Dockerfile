FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY DNS-HousingAnywhere.sln ./
COPY DNS-HousingAnywhere/DNS-HousingAnywhere.csproj DNS-HousingAnywhere/
COPY HA.DNS.Business/HA.DNS.Business.csproj HA.DNS.Business/
COPY HA.DNS.Models/HA.DNS.Models.csproj HA.DNS.Models/
RUN dotnet restore "DNS-HousingAnywhere/DNS-HousingAnywhere.csproj"
COPY . .
WORKDIR "/src/DNS-HousingAnywhere"
RUN dotnet build "DNS-HousingAnywhere.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DNS-HousingAnywhere.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENV ASPNETCORE_URLS="http://*:80"
ENTRYPOINT ["dotnet", "DNS-HousingAnywhere.dll"]
