#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PUSGS_Project.Api.RentACars/PUSGS_Project.Api.RentACars.csproj", "PUSGS_Project.Api.RentACars/"]
COPY ["Persistance.User/Persistance.User.csproj", "Persistance.User/"]
COPY ["Core/Core.csproj", "Core/"]
COPY ["Persistance.RentACar/Persistance.RentACar.csproj", "Persistance.RentACar/"]
RUN dotnet restore "PUSGS_Project.Api.RentACars/PUSGS_Project.Api.RentACars.csproj"
COPY . .
WORKDIR "/src/PUSGS_Project.Api.RentACars"
RUN dotnet build "PUSGS_Project.Api.RentACars.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PUSGS_Project.Api.RentACars.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PUSGS_Project.Api.RentACars.dll"]