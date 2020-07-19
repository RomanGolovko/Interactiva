#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Presentation/WebUI/WebUI.csproj", "src/Presentation/WebUI/"]
COPY ["src/Services/BLL.Interfaces/BLL.Interfaces.csproj", "src/Services/BLL.Interfaces/"]
COPY ["src/Shared/Model/Model.csproj", "src/Shared/Model/"]
COPY ["src/Services/BLL.Configuration/BLL.Configuration.csproj", "src/Services/BLL.Configuration/"]
COPY ["src/DataAccess/DAL.Configuration/DAL.Configuration.csproj", "src/DataAccess/DAL.Configuration/"]
COPY ["src/DataAccess/DAL.Implementation.EF/DAL.Implementation.EF.csproj", "src/DataAccess/DAL.Implementation.EF/"]
COPY ["src/DataAccess/DAL.Interfaces/DAL.Interfaces.csproj", "src/DataAccess/DAL.Interfaces/"]
COPY ["src/Services/BLL.Implementation/BLL.Implementation.csproj", "src/Services/BLL.Implementation/"]
RUN dotnet restore "src/Presentation/WebUI/WebUI.csproj"
COPY . .
WORKDIR "/src/src/Presentation/WebUI"
RUN dotnet build "WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebUI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebUI.dll"]
