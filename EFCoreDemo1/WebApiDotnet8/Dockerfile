FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["WebApiDotnet8/WebApiDotnet8.csproj", "WebApiDotnet8/"]
RUN dotnet restore "WebApiDotnet8/WebApiDotnet8.csproj"
COPY . .
WORKDIR "/src/WebApiDotnet8"
RUN dotnet build "WebApiDotnet8.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApiDotnet8.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApiDotnet8.dll"]
