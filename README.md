# 💼 Instituição Financeira DimDim – Projeto DimDimApp

Este projeto foi desenvolvido como parte do 3º Checkpoint da disciplina **DevOps Tools & Cloud Computing**, com foco em automação de ambientes utilizando **Docker**, **boas práticas de persistência de dados** e **execução de aplicações em containers isolados**.

---

## 🚗 Sobre o DimDimApp

O **DimDimApp** é uma aplicação ASP.NET Core que disponibiliza uma **API RESTful** para cadastro de veículos e simulação de locações, incluindo cálculo automático de valores com descontos progressivos.


## 📦 Tecnologias Utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server (em container)
- Docker + Docker CLI
- Swagger (documentação da API)

---

## 🧱 Estrutura do Projeto

```
DimDimApp/
├── Controllers/
│   ├── LocacoesController.cs
│   └── VeiculosController.cs
├── Data/
│   └── DimDimDbContext.cs
├── Models/
│   ├── Veiculo.cs
│   └── LocacaoRequest.cs
├── Program.cs
├── DimDimApp.csproj
├── Dockerfile
└── README.md
```

---

## 🐳 Como Executar com Docker

### 1️⃣ Criar rede Docker

```bash
docker network create dimdimnet
```

### 2️⃣ Subir container do SQL Server

```bash
docker run -d \
  --name db \
  -e "ACCEPT_EULA=Y" \
  -e "SA_PASSWORD=Your_password123" \
  -e "MSSQL_PID=Developer" \
  -v sqlvolume:/var/opt/mssql \
  --network dimdimnet \
  mcr.microsoft.com/mssql/server:2022-latest
```

### 3️⃣ Buildar imagem da aplicação

```bash
docker build -t dimdimapp .
```

### 4️⃣ Subir container da aplicação

```bash
docker run -d \
  --name app \
  -p 8080:80 \
  --network dimdimnet \
  -e ConnectionStrings__DefaultConnection="Server=db;Database=CP2LocadoraDb;User Id=sa;Password=Your_password123;" \
  -e DatabaseProvider=SqlServer \
  dimdimapp
```

---

## 🧪 Testes esperados

### ✅ CRUD completo de veículos:

- `GET /api/veiculos`
- `POST /api/veiculos`
- `PUT /api/veiculos/{id}`
- `DELETE /api/veiculos/{id}`

### ✅ Simulação de locação:

- `POST /api/locacoes/calcular`

#### 📌 Exemplo de JSON:

```json
{
  "veiculoId": 1,
  "dataInicio": "2025-05-22",
  "dataFim": "2025-05-25"
}
```

---

## 📸 Evidências exigidas

### Dentro do container da aplicação:

```bash
docker exec -it app sh
whoami
pwd
ls
```

> **Prints esperados:**
> - `whoami` → `appuser`
> - `pwd` → `/app`
> - Confirmação de pastas e execução

---

## 📘 Swagger

Acesse em:

```
http://localhost:8080/swagger
```

---

## 👨‍💻 Desenvolvido por

- Marcus Vinicius de Souza Calazans (RM: 556620)

---

## 🔗 Repositório GitHub

[https://github.com/calazans-99/Cp3_DimDimApp.git](https://github.com/calazans-99/Cp3_DimDimApp.git)
