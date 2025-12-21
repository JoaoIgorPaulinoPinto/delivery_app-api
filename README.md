# Delivery App API

![Status](https://img.shields.io/badge/Status-In%20Development-yellow)
![Platform](https://img.shields.io/badge/Platform-.NET-blue)
![Framework](https://img.shields.io/badge/Framework-ASP.NET%20Web%20API-purple)

---

## Sobre o Projeto

Este projeto é uma **API REST desenvolvida em ASP.NET Web API**, utilizada como backend para um aplicativo de delivery.

A API é responsável por gerenciar usuários, estabelecimentos, produtos e pedidos, fornecendo endpoints seguros para consumo por aplicações frontend ou mobile.

---

## Funcionalidades

- Cadastro e autenticação de usuários
- Gerenciamento de estabelecimentos
- Cadastro e listagem de produtos
- Criação e acompanhamento de pedidos
- Controle de status do pedido
- Autenticação e autorização via token
- Integração com banco de dados

---

## Tecnologias Utilizadas

- ASP.NET Web API
- C#
- Entity Framework
- Banco de dados relacional
- JWT para autenticação
- Swagger (documentação da API)

---

## Como Executar o Projeto

### Requisitos

- .NET SDK instalado
- Banco de dados configurado
- Visual Studio ou VS Code

### Executar a API

```bash
dotnet restore
dotnet run
```

#delivery_app-api/
├── Controllers/        # Endpoints da API
├── Models/             # Entidades do domínio
├── DTOs/               # Objetos de transferência
├── Services/           # Regras de negócio
├── Data/               # Contexto e migrations
├── Program.cs
└── README.md
###Autor
#João Igor Paulino Pinto
GitHub: https://github.com/JoaoIgorPaulinoPinto

###Licença

#Copyright © 2025 João Igor Paulino Pinto

#Este projeto possui licença privada.

O código-fonte está disponível apenas para visualização.
É proibido copiar, modificar, distribuir ou utilizar este projeto, total ou parcialmente, sem autorização prévia do autor.
