# 🚀 RESTAURANTE API

API backend desenvolvida com **Node.js**, **TypeScript**, **Express**, **Prisma** e **tsoa**, com documentação gerada automaticamente pelo **Swagger**.

---

## 📦 Clonar o Repositório

Clone o repositório e entre na pasta do projeto:

**_git clone https://github.com/JoaoIgorPaulinoPinto/delivery_app-api.git_**  
**_cd delivery_app-api_**

---

## ⚙️ Instalar Dependências

Instale todas as dependências necessárias:

**_npm install_**  
ou  
**_yarn_**

---

## 🧱 Configurar Variáveis de Ambiente

Crie um arquivo chamado **.env** na raiz do projeto e adicione suas configurações:

```bash
DATABASE_URL="mysql://usuario:senha@localhost:3306/seubanco"
PORT=3000
```

---

## 🗃️ Prisma

Gere os tipos do Prisma:

**_npx prisma generate_**

Crie e aplique as migrações no banco de dados:

**_npx prisma migrate dev_**

Abra o Prisma Studio (painel visual do banco):

**_npx prisma studio_**

---

## 📘 Gerar Rotas e Documentação Swagger (TSOA)

Gere as rotas e a documentação Swagger:

**_npx tsoa routes_**  
**_npx tsoa spec_**

Esses comandos criam os arquivos:
- **src/routes.ts**
- **src/docs/swagger.json**

---

## 🧰 Compilar o TypeScript

Compile o projeto para JavaScript:

**_npx tsc_**

Os arquivos compilados ficarão dentro da pasta **dist**.

---

## ▶️ Executar o Servidor

Modo desenvolvimento (recarregamento automático):

**_npm run dev_**

Modo produção:

**_npm run build_**  
**_npm start_**

---

## 🌐 Acessar a API

- Servidor: **[http://localhost:3000](http://localhost:3000)**  
- Swagger (documentação): **[http://localhost:3000/docs](http://localhost:3000/docs)**

---

## 🔍 Comandos Úteis

| Comando | Descrição |
|----------|------------|
| **_npm run dev_** | Executa o servidor com nodemon |
| **_npm run build_** | Compila o TypeScript |
| **_npm start_** | Inicia o servidor compilado |
| **_npx prisma migrate dev_** | Aplica as migrações |
| **_npx prisma generate_** | Gera os tipos do Prisma |
| **_npx prisma studio_** | Abre o painel do Prisma |
| **_npx tsoa routes_** | Gera o arquivo de rotas |
| **_npx tsoa spec_** | Gera o arquivo Swagger JSON |

---

## 🧩 Estrutura de Pastas

```
📦 projeto
├── prisma/
│   ├── schema.prisma
│   └── migrations/
├── src/
│   ├── controllers/
│   ├── services/
│   ├── models/
│   ├── dtos/
│   ├── routes.ts          # Gerado pelo tsoa
│   ├── docs/
│   │   └── swagger.json   # Gerado pelo tsoa
│   └── server.ts
├── package.json
├── tsconfig.json
├── tsoa.json
└── .env
```

---

## 🧾 Tecnologias Utilizadas

- **Node.js**
- **TypeScript**
- **Express**
- **Prisma ORM**
- **tsoa**
- **Swagger UI**
- **Nodemon**

---

## 💡 Observações

- Os arquivos **src/routes.ts** e **src/docs/swagger.json** **não devem ser versionados**, pois são gerados automaticamente pelo tsoa.  
- Sempre execute os comandos abaixo antes de iniciar o servidor, caso faça alterações nos controladores:

**_npx tsoa routes && npx tsoa spec_**

---

## 🧑‍💻 Autor

**João Igor Paulino Pinto**  
📧 joaoigor@example.com  
🌐 [https://github.com/JoaoIgorPaulinoPinto](https://github.com/JoaoIgorPaulinoPinto)
