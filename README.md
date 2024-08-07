# Cálculo de investimento CDB

## Descrição
Esta solução foi criada para demonstrar a implementação do cálculo de investimento CDB.

Esta solução consiste em quatro projetos principais:

1. **API**: Implementada usando .NET Core 8, esta API fornece um endpoint para calcular o valor bruto e líquido de um investimento em CDB com base na fórmula fornecida e parâmetros fixos.
2. **Models**: Uma biblioteca de classes que contém as definições dos modelos de dados utilizados pela API e pelos serviços.
3. **Services**: Uma biblioteca de classes responsável por implementar a lógica de cálculo do CDB, separando a lógica de negócios da camada de apresentação.
4. **Tests**: Projeto de testes unitários que valida a lógica dos serviços utilizando a biblioteca Moq.

## Estrutura da Solução

### Projetos

1. **API (CalculoInvestimento.API)**
   - **Descrição**: Este projeto é uma API web que expõe endpoints para calcular os valores de um investimento em CDB. Ele recebe as entradas do usuário, processa os dados utilizando os serviços de cálculo e retorna os resultados.
   - **Principais Componentes**:
     - **Controllers**: Contém controladores que lidam com as requisições HTTP.
       - `CdbController`: Controlador principal que processa as solicitações de cálculo de CDB.
     - **Program.cs**: Configurações do middleware e inicialização da aplicação.
     - **Dependências**: Referencia o projeto `Models` e o projeto `Services`.

2. **Models (CalculoInvestimento.Models)**
   - **Descrição**: Este projeto é uma biblioteca de classes que contém as definições dos modelos de dados transferidos entre o cliente e o servidor.
   - **Principais Componentes**:
     - **Classes de Modelos**:
       - `CalculoCdbRequest`: Classe para representar os dados de entrada para o cálculo.
       - `CalculoCdbResult`: Classe para representar os resultados do cálculo.

3. **Services (CalculoInvestimento.Services)**
   - **Descrição**: Este projeto é uma biblioteca de classes que implementa a lógica de negócios para calcular os valores de um investimento em CDB. Isso ajuda a manter a lógica de negócios separada da camada de apresentação.
   - **Principais Componentes**:
     - **Interfaces**: Contém definições de contrato para os serviços.
       - `ICalculoCdb`: Define os métodos que um serviço de cálculo de CDB deve implementar.
     - **Implementations**: Contém implementações das interfaces definidas.
       - `CalculoCdb`: Implementa a lógica de cálculo do CDB baseada nos parâmetros fornecidos.
   - **Dependências**: Referencia o projeto `Models`.

4. **Tests (CalculoInvestimento.Tests)**
   - **Descrição**: Projeto de testes unitários que valida a lógica dos serviços.
   - **Principais Componentes**:
     - **Testes de Unidade**:
       - `CalculoCdbTest`: Contém testes para validar a lógica de cálculo do CDB usando a biblioteca Moq.
   - **Dependências**: Referencia os projetos `Models` e `Services`.

## Requisitos
- .NET Core 8
- Visual Studio 2019 ou superior

## Instruções de Execução

1. **Clonar o Repositório**
   ```bash
   git clone <repository-url>

2. **Restaurar Pacotes NuGet**
- Navegue até a pasta da solução e execute:
    ```bash
    dotnet restore

3. **Executar a API**
- Navegue até a pasta do projeto API e execute:
    ```bash
    dotnet run --project CalculoInvestimento.API

4. **Acessar a Página HTML**
- Abra um navegador e vá para **http://localhost:{porta}/index.html**.

## Testes Unitários

1. **Navegar até o diretório onde está localizado projeto de Testes (CalculoInvestimento.Tests)**
    ```bash
    cd CalculoInvestimento.Test

2. **Executar os Testes**
    ```bash
    dotnet test
    
