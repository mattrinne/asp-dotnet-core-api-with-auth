FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /opt/app
EXPOSE 8080
EXPOSE 8443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY [ "SampleApi.csproj", "." ]
RUN dotnet restore "SampleApi.csproj"
WORKDIR /src/asp-dotnet-core-api-with-auth
COPY . .
RUN dotnet build "SampleApi.csproj" -c Release -o /opt/app/build

FROM build AS publish
RUN dotnet publish "SampleApi.csproj" -c Release -o /opt/app/publish

FROM base AS final
WORKDIR /opt/app
COPY --from=publish /opt/app/publish .
ENTRYPOINT ["dotnet", "SampleApi.dll"]