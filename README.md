
![image](https://github.com/MarlonJerold/testecsharp/assets/63025001/1536424c-c039-4cdb-97d8-f8d4ca7a728d)


## Dependências do Projeto

- **Aspire.Npgsql.EntityFrameworkCore.PostgreSQL** (v8.0.1)
- **AutoMapper** (v12.0.1)
- **AutoMapper.Extensions.Microsoft.DependencyInjection** (v12.0.1)
- **Microsoft.AspNetCore.Authentication.JwtBearer** (v8.0.6)
- **Microsoft.AspNetCore.Mvc.NewtonsoftJson** (v8.0.6)
- **Microsoft.AspNetCore.OpenApi** (v8.0.6)
- **Microsoft.EntityFrameworkCore** (v8.0.6)
- **Microsoft.EntityFrameworkCore.Design** (v8.0.6)
  - *IncludeAssets*: runtime; build; native; contentfiles; analyzers; buildtransitive
  - *PrivateAssets*: all
- **Microsoft.EntityFrameworkCore.InMemory** (v8.0.6)
- **Moq** (v4.20.70)
- **Npgsql.EntityFrameworkCore.PostgreSQL** (v8.0.4)
- **Swashbuckle.AspNetCore** (v6.4.0)
- **xunit** (v2.8.1)

# Executando a aplicação .NET 8

## Requisitos

* .NET 8 instalado no computador
* Visual Studio Code ou outro editor de código
* O repositório do teste técnico clonado em um diretório local

## Passos para executar a aplicação

### 1. Clonar o repositório

Clona o repositório do teste técnico em um diretório local usando o comando:
```bash
git clone https://github.com/MarlonJerold/testecsharp
```
2. Navegar até o diretório do repositório
Navegue até o diretório do repositório clonado usando o comando:

cd repositório

3. Instalar as dependências

Instale as dependências do projeto usando o comando:
```
dotnet restore
```
4. Compilar a aplicação
5. 
Compile a aplicação usando o comando:
```
dotnet build
```
5. Executar a aplicação
   
Execute a aplicação usando o comando:
```
dotnet run
```
6. Acessar a aplicação
Acessa a aplicação em um navegador web usando a URL http://localhost:5000/swagger/index.html 

7. Testar a aplicação
Testa a aplicação executando os testes unitários e de integração. Você pode usar ferramentas como xUnit ou NUnit para executar os testes.

8. Depurar a aplicação
Se necessário, depure a aplicação usando o Visual Studio Code ou outro editor de código. Você pode configurar breakpoints e executar a aplicação em modo de depuração.

Notas
Se você estiver usando o Visual Studio, você pode abrir o projeto e executá-lo clicando no botão "Start" no menu "Debug".
Se você estiver usando o Visual Studio Code, você pode abrir o diretório do repositório e executar o comando dotnet run no terminal.
Certifique-se de que o .NET 8 esteja instalado no seu computador e que o repositório esteja clonado corretamente.
