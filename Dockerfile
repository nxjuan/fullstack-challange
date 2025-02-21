FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["pinterestapi.csproj", "./"]
RUN dotnet restore "pinterestapi.csproj"

COPY . .
RUN dotnet publish "pinterestapi.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "pinterestapi.dll"]