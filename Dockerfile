# Estágio de Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1. Copia apenas o projeto primeiro para aproveitar o cache de camadas
# Se o seu arquivo for 'comaagora.csproj', o Docker vai encontrar
COPY *.csproj ./
RUN dotnet restore

# 2. Copia o restante dos arquivos e compila
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Estágio Final (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# Força a porta 10000 (comum no Render e visível no seu log anterior)
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

# CERTIFIQUE-SE de que o nome da DLL abaixo é exatamente o nome do seu projeto
ENTRYPOINT ["dotnet", "comaagora.dll"]