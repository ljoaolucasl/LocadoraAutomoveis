# Locadora de Automóveis - Sistema de Gerenciamento

## Sumário Executivo

Este projeto visa simplificar a gestão de operações em uma locadora de automóveis, abrangendo desde o cadastro de funcionários até a configuração de preços, aluguéis e devoluções. O sistema oferece uma variedade de funcionalidades para otimizar a experiência tanto dos funcionários quanto dos clientes da locadora.

## Funcionalidades Principais

- Cadastro de funcionários, clientes e automóveis.
- Configuração de grupos de automóveis e planos de cobrança.
- Cálculo flexível de preços de aluguéis, considerando tipo de veículo, plano e taxas.
- Devolução de aluguéis com cálculo de quilometragem e combustível.
- Utilização de cupons de desconto e parceiros.
- Interface de usuário intuitiva e eficiente.

## Tecnologias Utilizadas

- **C#:** Linguagem de programação principal.
- **SQL Server:** Banco de dados relacional para persistência de dados.
- **Moq:** Biblioteca de simulação para testes unitários.
- **Entity Framework Core:** ORM (Object-Relational Mapping) para facilitar o acesso e manipulação dos dados no banco de dados.
- **Visual Studio:** Ambiente de desenvolvimento integrado (IDE) utilizado para - codificação, depuração e testes.
- **Git:** Sistema de controle de versão utilizado para gerenciar o código-fonte e - colaboração em equipe.
- **GitHub:** Plataforma de hospedagem de código-fonte utilizada para versionamento, colaboração e controle de problemas.
- **MSTest:** Framework de testes unitários que foi utilizado para escrever e executar testes automatizados.
- **Serilog:** Biblioteca para registro de logs de erros e informações do sistema.
- **JSON:** Formato de dados utilizado para armazenar configurações e dados estruturados.
- **NBuilder:** Biblioteca para construção de objetos fictícios em testes.
- **FluentAssertions:** Biblioteca para escrever assertivas de forma mais fluente e legível nos testes unitários.
- *Entre outras . . .*

## Arquitetura

O projeto segue uma arquitetura de camadas bem definida, com a separação de responsabilidades para garantir a manutenibilidade e escalabilidade. A estrutura do projeto é organizada da seguinte forma:

- `LocadoraAutomoveis.WinApp`: Camada de apresentação em Formulário.
- `LocadoraAutomoveis.Aplicacao`: Camada de aplicação, contendo lógica de negócios.
- `LocadoraAutomoveis.Dominio`: Camada de domínio, contendo entidades e regras de negócios.
- `LocadoraAutomoveis.Infraestrutura`: Camada de infraestrutura, incluindo acesso a dados.
- `LocadoraAutomoveis.Testes`: Camada de testes unitários e de integração.

## Requisitos Funcionais

O sistema inclui os seguintes módulos e funcionalidades principais:

### Módulo de Funcionários

- Cadastro, edição e visualização de informações de funcionários.

### Módulo de Grupo de Automóveis

- Cadastro e gerenciamento de grupos de automóveis.

### Módulo de Planos de Cobrança

- Configuração de diferentes planos de cobrança, incluindo modalidades diárias, de quilometragem controlada e quilometragem livre.

### Módulo de Automóveis

- Cadastro e gerenciamento de informações detalhadas sobre os automóveis disponíveis para aluguel.

### Módulo de Clientes

- Cadastro e gerenciamento de informações de clientes, incluindo pessoas físicas e jurídicas.

### Módulo de Condutores

- Cadastro e gerenciamento de condutores associados aos clientes.

### Módulo de Taxas e Serviços

- Cadastro e gerenciamento de taxas e serviços adicionais para os aluguéis.

### Módulo de Aluguéis

- Cadastro, edição e visualização de informações sobre os aluguéis realizados, com cálculos automáticos de preços.

### Módulo de Configuração de Preços

- Configuração dos preços do combustível para inclusão nos cálculos dos aluguéis.

### Módulo de Parceiros e Cupons

- Cadastro e gerenciamento de parceiros e cupons de desconto.

## Requisitos Não Funcionais

- Testes de unidade e integração implementados.
- Persistência de dados em banco de dados.
- Arquitetura em camadas para organização e separação de responsabilidades.
- Interface de usuário intuitiva e responsiva.

## Testes

O projeto é acompanhado por um conjunto abrangente de testes unitários e de integração para garantir a qualidade e robustez do software. Os testes são desenvolvidos utilizando a biblioteca Moq para simular comportamentos e interações.

## Como Usar

1. Clone ou faça o download deste repositório.
2. Configure a conexão com o banco de dados SQL.
3. Execute as migrações para criar as tabelas.
4. Execute a aplicação e explore as funcionalidades.

## Contribuição

Contribuições são bem-vindas! Abra uma issue ou envie um pull request.

## Desenvolvido por 
- [João Lucas Claudino] - [claudinojoaolucas0@gmail.com]
- [Rafael Santos] - [rafaelsantos138@hotmail.com]
- [Mateus Zancheta Falcão] - [mateuszancheta2005@gmail.com]
