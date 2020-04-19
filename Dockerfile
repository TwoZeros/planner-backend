#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["WorkerCRM/WorkerCRM.csproj", "WorkerCRM/"]  && \
["WorkerCRM.Services.Contract/WorkerCRM.Services.Contract.csproj", "WorkerCRM.Services.Contract/"] \
["WorkCRM.Models/WorkerCRM.Models.csproj", "WorkCRM.Models/"] && \
["WorkerCRM.Common/WorkerCRM.Common.csproj", "WorkerCRM.Common/"] && \
["WorkerCRM.Services/WorkerCRM.Services.csproj", "WorkerCRM.Services/"] && \
["WorkerCRM.Data/WorkerCRM.Data.csproj", "WorkerCRM.Data/"] && \
["WorkerCRM.Data.Contract/WorkerCRM.Data.Contract.csproj", "WorkerCRM.Data.Contract/"]
RUN dotnet restore "WorkerCRM/WorkerCRM.csproj"
COPY . .
WORKDIR "/src/WorkerCRM"
RUN dotnet build "WorkerCRM.csproj" -c Release -o /app/build 
FROM build AS publish
RUN dotnet publish "WorkerCRM.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WorkerCRM.dll"]