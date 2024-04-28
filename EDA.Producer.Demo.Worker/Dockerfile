FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["EDA.Producer.Demo/EDA.Producer.Demo.csproj", "EDA.Producer.Demo/"]
RUN dotnet restore "EDA.Producer.Demo/EDA.Producer.Demo.csproj"
COPY . .
WORKDIR "/src/EDA.Producer.Demo"
RUN dotnet build "EDA.Producer.Demo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EDA.Producer.Demo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EDA.Producer.Demo.dll"]
