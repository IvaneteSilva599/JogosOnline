# Loja de Jogos Online - API

## 📜 Descrição

Esta é uma API de gerenciamento de pedidos e organização de embalagens da **Loja do Seu Manoel**, especializada na venda de jogos online.

A aplicação possui duas funcionalidades principais:

- **CRUD de Pedidos**: permite cadastrar, visualizar, atualizar e excluir pedidos com produtos.
- **Organização de Embalagem**: calcula automaticamente as caixas ideais para embalar os produtos de um pedido, considerando dimensões fixas de caixas.
A lógica de embalagem avalia não apenas o volume dos produtos, mas também se as dimensões cabem fisicamente dentro das caixas.

O projeto foi criado com suporte nativo ao Docker via Visual Studio, utilizando Ubuntu via WSL2 para rodar o backend com **Docker Compose**.

---

## 🚀 Tecnologias Utilizadas

- .NET 8 (ASP.NET Core Web API)
- Docker e Docker Compose
- SQL Server
- Ubuntu via WSL 2

---

## 📦 Caixas Disponíveis para Embalagem

A lógica de embalagem utiliza três tipos de caixas fixas:

| Caixa | Altura | Largura | Comprimento |
|-------|--------|---------|-------------|
| 1     | 30     | 40      | 80          |
| 2     | 80     | 50      | 40          |
| 3     | 50     | 80      | 80          |

---

## ✅ Pré-requisitos e Configuração

Para rodar este projeto com Docker via Visual Studio ou terminal, certifique-se de que possui:

- [Visual Studio 2022+](https://visualstudio.microsoft.com/) com a carga de trabalho:
  - "Desenvolvimento para ASP.NET e web"
  - "Suporte a Docker"
- [WSL 2](https://learn.microsoft.com/pt-br/windows/wsl/install) instalado e configurado com Ubuntu
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) instalado e rodando
- Terminal (PowerShell ou WSL) com permissão para executar Docker.
  
---

> ℹ️ O Visual Studio já gera automaticamente o `Dockerfile`, `docker-compose.yml` e `.dcproj` se você marcar a opção **"Habilitar suporte ao Docker"** ao criar o projeto para facilitar a execução da API com um banco de dados SQL Server.


A API estará disponível em: http://localhost:5000 

---

⚙️ Como Executar o Projeto com Docker

1. Clone o repositório: 
git clone https://github.com/IvaneteSilva599/JogosOnline

2. Execute o Docker Compose para subir a aplicação e o banco:
 docker-compose up -d

## Endpoints principais:

POST /api/embalagem/organizar
Envia uma lista de pedidos com seus produtos para receber a organização da embalagem em caixas.

CRUD /api/pedidos
Endpoints para criar, ler, atualizar e deletar pedidos.

---

💡 Observações
O controller de embalagem está separado do CRUD de pedidos.

Por enquanto, a API de embalagem recebe os pedidos manualmente no corpo da requisição.

Futuramente, é possível integrar com o banco para buscar os pedidos automaticamente e gerar as embalagens com base neles, reutilizando os serviços do CRUD — embora isso não seja obrigatório para um endpoint dedicado.


## Contato:

Desenvolvedor: Ivanete Silva

Email: ivanetevieira1000@gmail.com


