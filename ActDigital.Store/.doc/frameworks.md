Foi utilizado CQRS como padrão arquitetural, e Event Sourci e conceitos do DDD como Aggregation, Rich Domain, Bounded Context entre outros. A vantagem dessa abordagem é que facilita a separação entre comandos e consultas,
o que flexibiliza a necssidade de utilizar uma ou mais fontes de dados, temos a rastreabilidade dos eventos ocorridos, e todas as regras de negócio separadas no domínio. 
Foi utilizado o padrão Mediator para a comunicação e para que tenha um baixo acomplamento entre as camadas de apresentação e aplicação. 
Foi utilizado o Entity Framework Core para persitência de dados, sendo um ORM de dados muito eficiente e prático.
Foi utilizado o padrão Repository para o isolamento da camada de acesso a dados e para a separação limpa, fornecendo uma visão mais orientada a objetos da camada de persistência.
Foi utilizado o padrão Factory para abstração de instância de objetos.
Foi utilizado o Sql Server com LocalDb como banco de dados.
Foi utilizado o Entity Framework Core para persitência de dados.
Foi utilizado o Swagger como documentação e interface com usuário.
Foi utilizado o pacote Fluent Validations para a validação de dados.
Foi utilizado o Data Anotations para validação de campos.
Foi utilizado o XUnit para os testes unitários.