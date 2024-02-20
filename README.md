## Blood Bank Manager 

#### Este projeto é uma API web que implementa um sistema de gerenciamento de um banco de sangue.
#### A API permite que os usuários se cadastrem como doadores de sangue e realizem doações. As doações são armazenadas em um estoque de sangue, separados por tipos sanguíneos.

### Tecnologias utilizadas ⌨️

- ASP.NET Core 7
- Entity Framework Core
- SQL Server

### Funcionalidades ⚙️
- Cadastro de doadores.
- Registro de doações: Os doadores registrados podem realizar doações de sangue. As doações são armazenadas em um estoque de sangue e ficam vinculadas ao usuário do doador.
- Atualização de estoque de sangue por tipos.
- Consulta geral de doações dos últimos 30 dias.
- Consulta de estoque de sangue por tipos.
- Inativar/Ativar doadores.
- Buscar doadores ativos/inativos.

### Regras de negócio 📏
- Quando já existe um e-mail cadastrado, não é possivel cadastra-lo novamente
- Menores de idade não podem realiza doações (mas não impede de possuir um cadastro)
- Para realizar doações tem que pesar no mínimo 50kg
- Mulheres doam a cada 90 dias.
- Homens doam a cada 60 dias.
- A quantidade de doação de sangue vai de 420ml à 470ml.

### Padrões, conceitos e arquitetura utilizada 📂
- Arquitetura Limpa  
- CQRS
- Padrão repository
- SeedData
- Fluent Validation
- Middlewares

### ***Instalação***

Requisitos para rodar o projeto:

SDK .NET 7.0: A versão do .NET Framework necessária para executar a API.

SQL Server: O banco de dados utilizado para armazenar os dados.

1. Clone o repositório do GitHub:

        git clone https://github.com/[seu-usuário]/BloodBankManager.API.git
   
2. Navege até a pasta do projeto:

         cd BloodBankManager.API
3. Abra o projeto na sua IDE de preferência (a IDE utilizada para desenvolvimento foi o Visual Studio)
4. Restaure os pacotes:

         dotnet restore

5. Configure o banco de dados:
   - Abra o arquivo appsettings.json.
   - Altere as configurações do banco de dados para corresponder ao seu ambiente.
6. Execute a API:

       dotnet run


### Exemplo de uso:

Para cadastrar um doador, você pode usar a seguinte chamada HTTP:

      POST  api/v1/donors

O Corpo da requisição deve conter as seguintes informações 

      {
          "fullName": "string",
          "email": "string",
          "birthDate": "2023-12-29T16:24:04.088Z",
          "gender": "Male",
          "weight": 0,
          "bloodType": "A",
          "rhFactor": "Positive",
          "address": {
            "street": "string",
            "state": "string",
            "city": "string",
            "zipCode": "string"
        }


***Este projeto foi criado para fins didáticos e não abrange todas as regras e conceitos necessários de uma aplicação real em produção.****
  
