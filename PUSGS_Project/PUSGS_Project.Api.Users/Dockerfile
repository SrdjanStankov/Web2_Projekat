#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PUSGS_Project.Api.Users/PUSGS_Project.Api.Users.csproj", "PUSGS_Project.Api.Users/"]
COPY ["Persistance.User/Persistance.User.csproj", "Persistance.User/"]
COPY ["Core/Core.csproj", "Core/"]
RUN dotnet restore "PUSGS_Project.Api.Users/PUSGS_Project.Api.Users.csproj"
COPY . .
WORKDIR "/src/PUSGS_Project.Api.Users"
RUN dotnet build "PUSGS_Project.Api.Users.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PUSGS_Project.Api.Users.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PUSGS_Project.Api.Users.dll"]