# MusicamFluereAPI

## Descrição
O **MusicamFluereAPI** é o motor backend robusto que alimenta a plataforma MusicamFluere. Desenvolvido com **.NET 8**, este serviço fornece uma API para o gerenciamento completo do catálogo musical, incluindo músicas, artistas e metadados associados. Ele foi projetado para ser rápido, escalável e integrar com o frontend da [MusicamFluere](https://github.com/haze1997/MusicamFluere).

## Funcionalidades (Endpoints de Músicas)
O projeto é uma Minimal API feita utilizando o framework .NET 8 para expor os recursos sob a tag **"Musics"** (que pode ser vista no Swagger) servindo como backend para o MusicamFluere. Abaixo estão os endpoints da **MusicamFluereAPI**:

- **`GET /musics`**: Lista todas as músicas cadastradas no banco de dados.
- **`GET /musics/{id}`**: Busca os detalhes específicos de uma única música através do seu identificador único.
- **`POST /musics`**: Realiza o cadastro de uma nova música, recebendo dados como título, letra, link do YouTube e associações.
- **`PUT /musics/{id}`**: Permite a atualização completa dos dados de uma música existente.
- **`DELETE /musics/{id}`**: Remove uma música permanentemente do catálogo.

## Tecnologias Utilizadas
- **Plataforma:** .NET 8 (LTS)
- **Linguagem:** C#
- **Arquitetura:** Minimal APIs para alta performance e código limpo.
- **Testes:** Swagger integrado para testes de endpoints.
- **Containerização:** Docker (Dockerfile incluso para deploy facilitado).

## Como instalar e executar o projeto

### Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) instalado.

### Execução Local
1. Clone o repositório do backend:
   ```bash
   git clone https://github.com/haze1997/MusicamFluereAPI
   cd MusicamFluereAPI
   ```

2. Restaure as dependências do projeto:
   ```bash
   dotnet restore
   ```

3. Rode a aplicação:
   ```bash
   dotnet run dev
   ```
   A API estará disponível por padrão em `http://localhost:80` (ou na porta configurada no seu ambiente). Você pode acessar o Swagger em `/swagger/index.html`.

### Execução via Docker
1. Construa a imagem:
   ```bash
   docker build -t musicamfluere-api .
   ```
2. Inicie o container:
   ```bash
   docker run -p 5000:80 musicamfluere-api
   ```

## Licença
Este projeto está licenciado sob os termos da **Apache License 2.0**. Consulte o arquivo `LICENSE` na raiz do repositório para mais detalhes.
