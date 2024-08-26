FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EFCore1VN/EFCore1VN.csproj", "EFCore1VN/"]
RUN dotnet restore "EFCore1VN/EFCore1VN.csproj"
COPY . .
WORKDIR "/src/EFCore1VN"
RUN dotnet build "EFCore1VN.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EFCore1VN.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EFCore1VN.dll"]
