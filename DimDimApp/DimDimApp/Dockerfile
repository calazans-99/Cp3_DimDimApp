# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .
RUN dotnet restore ./LocadoraCarrosAPI.csproj
RUN dotnet publish ./LocadoraCarrosAPI.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

RUN adduser --disabled-password appuser
USER appuser

COPY --from=build /app/publish .

ENV ConnectionStrings__DefaultConnection="Server=db;Database=CP2LocadoraDb;User Id=sa;Password=Your_password123;"
ENV DatabaseProvider=SqlServer

EXPOSE 80
ENTRYPOINT ["dotnet", "LocadoraCarrosAPI.dll"]
