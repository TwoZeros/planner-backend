#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Planner/Planner.csproj", "Planner/"]  && \
["Planner.Services.Contract/Planner.Services.Contract.csproj", "Planner.Services.Contract/"] \
["Planner.Models/Planner.Models.csproj", "Planner.Models/"] && \
["Planner.Common/Planner.Common.csproj", "Planner.Common/"] && \
["Planner.Services/Planner.Services.csproj", "Planner.Services/"] && \
["Planner.Data/Planner.Data.csproj", "Planner.Data/"] && \
["Planner.Data.Contract/Planner.Data.Contract.csproj", "Planner.Data.Contract/"]
RUN dotnet restore "Planner/Planner.csproj"
COPY . .
WORKDIR "/src/Planner"
RUN dotnet build "Planner.csproj" -c Release -o /app/build 
FROM build AS publish
RUN dotnet publish "Planner.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Planner.dll"]