- BuildingEvents
	- EventSourcing - Project
		Camada responsável por persistir os eventos da aplicação
		
- Services
	- Core
		Camada responsável por centralizar ações e objetos comuns as demais camadas da aplição
	- Sales
		Camada responsável pelo contexto de vendas da aplicação, dividos em Application(camada de negócio), Domain (objetos de domínio, regras de negócio), Infrastructure(camada esturutral de acesso a dados, mensagerias e serviços externos) e Tests(camada de testes do contexto de vendas)
		
- WebApps
	- WebApi
		Camada de apresentação e ponto de entrada da API, contém também as configurações iniciais bem como injeção de dependências para a criação dos serviços da aplicação
			