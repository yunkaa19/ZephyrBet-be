#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /api
EXPOSE 8080
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ZephyrBetAPI/ZephyrBetAPI.csproj", "ZephyrBetAPI/"]
RUN dotnet restore "ZephyrBetAPI/ZephyrBetAPI.csproj"
COPY . .
WORKDIR "/src/ZephyrBetAPI"
RUN dotnet build "ZephyrBetAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ZephyrBetAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ZephyrBetAPI.dll"]