#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Market.WebAPI/Market.WebAPI.csproj", "Market.WebAPI/"]
COPY ["Market.Application/Market.Application.csproj", "Market.Application/"]
COPY ["Market.Domain/Market.Domain.csproj", "Market.Domain/"]
COPY ["Market.Persistence/Market.Persistence.csproj", "Market.Persistence/"]
RUN dotnet restore "Market.WebAPI/Market.WebAPI.csproj"
COPY . .
WORKDIR "/src/Market.WebAPI"
RUN dotnet build "Market.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Market.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Market.WebAPI.dll"]