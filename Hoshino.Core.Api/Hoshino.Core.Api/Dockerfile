FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 81
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Hoshino.Core.Api/Hoshino.Core.Api/Hoshino.Core.Api.csproj", "Hoshino.Core.Api/Hoshino.Core.Api/"]
RUN dotnet restore "Hoshino.Core.Api/Hoshino.Core.Api/Hoshino.Core.Api.csproj"
COPY . .
WORKDIR "/src/Hoshino.Core.Api/Hoshino.Core.Api"
RUN dotnet build "Hoshino.Core.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Hoshino.Core.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Hoshino.Core.Api.dll"]