# Estágio de Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o arquivo de projeto e restaura as dependências
# Note que o nome do arquivo no log era Comaagora_API.csproj
COPY ["Comaagora_API.csproj", "./"]
RUN dotnet restore "./Comaagora_API.csproj"

# Copia o restante dos arquivos e compila
COPY . .
RUN dotnet publish "Comaagora_API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Estágio Final (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# No .NET 8, a porta padrão da imagem oficial mudou para 8080
# O Render espera que a aplicação ouça na porta definida na variável PORT ou na 8080
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080

# O nome da DLL deve ser exatamente o que aparece no log de build
ENTRYPOINT ["dotnet", "Comaagora_API.dll"]