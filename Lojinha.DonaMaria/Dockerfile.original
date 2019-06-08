FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 56132
EXPOSE 44397

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Lojinha.DonaMaria/Lojinha.DonaMaria.csproj", "Lojinha.DonaMaria/"]
RUN dotnet restore "Lojinha.DonaMaria/Lojinha.DonaMaria.csproj"
COPY . .
WORKDIR "/src/Lojinha.DonaMaria"
RUN dotnet build "Lojinha.DonaMaria.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Lojinha.DonaMaria.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Lojinha.DonaMaria.dll"]