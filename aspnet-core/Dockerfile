FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Ecommerce.HttpApi.Host/Ecommerce.HttpApi.Host.csproj", "src/Ecommerce.HttpApi.Host/"]
COPY ["src/Ecommerce.Domain/Ecommerce.Domain.csproj", "src/Ecommerce.Domain/"]
COPY ["src/Ecommerce.Application/Ecommerce.Application.csproj", "src/Ecommerce.Application/"]
RUN dotnet restore "src/Ecommerce.HttpApi.Host/Ecommerce.HttpApi.Host.csproj"

COPY . .
WORKDIR "/src/src/Ecommerce.HttpApi.Host"
RUN dotnet build "Ecommerce.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ecommerce.HttpApi.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecommerce.HttpApi.Host.dll"]
