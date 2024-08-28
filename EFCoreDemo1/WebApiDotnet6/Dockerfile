FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebApiDotnet6/WebApiDotnet6.csproj", "WebApiDotnet6/"]
RUN dotnet restore "WebApiDotnet6/WebApiDotnet6.csproj"
COPY . .
WORKDIR "/src/WebApiDotnet6"
RUN dotnet build "WebApiDotnet6.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApiDotnet6.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApiDotnet6.dll"]
