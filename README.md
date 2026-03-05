# Venda de Ingressos .NET

Sistema de venda de ingressos desenvolvido com .NET. Desenvolvi este projeto para aplicar conceitos de arquitetura de software, como Clean Architecture, SOLID, DDD e TDD.

## Tecnologias

- .NET 8
- ASP.NET Core
- Entity Framework Core
- SQL Server
- JWT
- Swagger
- MassTransit
- RabbitMQ
- MediatR
- xUnit e NSubstitute

## Como executar

Configure a string de conexão com o banco de dados no arquivo appsettings.json

Certifique-se de ter o RabbitMQ e SQLServer instalado e rodando.

```bash
dotnet ef database update
```

```bash
dotnet run
```

## Testes

```bash
dotnet test
```

### Funcionalidades

- [x] Gerenciamento de eventos e tipos de ingressos
- [ ] Processo de reserva de ingressos com controle de concorrência
- [ ] Integração com filas (RabbitMQ) para processamento em segundo plano
- [ ] Histórico de compras e validação de disponibilidade em tempo real.



 
