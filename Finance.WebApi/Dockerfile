#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Finance.WebApi/Finance.WebApi.csproj", "Finance.WebApi/"]
COPY ["Finance.Infrastructure/Finance.Infrastructure.csproj", "Finance.Infrastructure/"]
COPY ["Finance.Core/Finance.Core.csproj", "Finance.Core/"]
COPY ["Finance.Repositories/Finance.Repositories.csproj", "Finance.Repositories/"]
COPY ["Finance.Services/Finance.Services.csproj", "Finance.Services/"]
RUN dotnet restore "Finance.WebApi/Finance.WebApi.csproj"
COPY . .
WORKDIR "/src/Finance.WebApi"
RUN dotnet build "Finance.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Finance.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Finance.WebApi.dll"]