FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/CocoaStore.Vendas.Api/CocoaStore.Vendas.Api.csproj", "CocoaStore.Vendas.Api/"]
RUN dotnet restore "src/CocoaStore.Vendas.Api/CocoaStore.Vendas.Api.csproj"
COPY . .
WORKDIR "/src/CocoaStore.Vendas.Api"
RUN dotnet build "CocoaStore.Vendas.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CocoaStore.Vendas.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CocoaStore.Vendas.Api.dll"]
