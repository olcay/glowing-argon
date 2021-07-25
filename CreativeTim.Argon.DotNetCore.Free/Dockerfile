FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Ookgewoon.Web/Ookgewoon.Web.csproj", "Ookgewoon.Web/"]
RUN dotnet restore "Ookgewoon.Web/Ookgewoon.Web.csproj"
COPY . .
WORKDIR "/src/Ookgewoon.Web"
RUN dotnet build "Ookgewoon.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Ookgewoon.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ookgewoon.Web.dll"]
