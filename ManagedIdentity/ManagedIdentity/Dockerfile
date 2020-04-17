#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["/ManagedIdentity/ManagedIdentity/ManagedIdentity.csproj", "ManagedIdentity/"]
RUN dotnet restore "ManagedIdentity/ManagedIdentity.csproj"
COPY . .
WORKDIR /src/ManagedIdentity/ManagedIdentity
RUN dotnet build "ManagedIdentity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ManagedIdentity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:5000;http://+:5001
ENV ASPNETCORE_ENVIRONMENT=Production
EXPOSE 5000/tcp
EXPOSE 5001/tcp
ENTRYPOINT ["dotnet", "ManagedIdentity.dll"]