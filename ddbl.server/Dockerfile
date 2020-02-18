FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["ddbl.server/ddbl.server.csproj", "ddbl.server/"]

RUN dotnet restore "ddbl.server/ddbl.server.csproj"
COPY . .
WORKDIR "/src/ddbl.server"
RUN dotnet build "ddbl.server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ddbl.server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ddbl.server.dll"]