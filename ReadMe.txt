-----------------------------------------------------------------
Quake Log Parse
Version:1
Autor: Eriton Silva Quaresma
------------------------------------------------------------------
#Setup#

Requisitos:

IIS ou IISExpress do Visual Studio
Sql Server 
Visual Studio Communit 

Hospedar a API e o site no ISS ou rodar os dois projetos no Visual Studio
Apontar connection string  da API para o banco de dados SQL local 
Apontar connection string da UI para o banco de dados SQL local

Connection String Inicial
<add name="ApplicationName" connectionString="Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=ApplicationNameContext-20151023111236; Integrated Security=True; 
MultipleActiveResultSets=True; AttachDbFilename=|DataDirectory|ApplicationNameContext-20151023111236.mdf" providerName="System.Data.SqlClient" />

Connection String após a criação do banco de dados
<add name="NotificationConnection" connectionString="Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=ApplicationNameContext-20151023111236; 
Integrated Security=True;" providerName="System.Data.SqlClient" />

Ao rodar a aplicação seguir o seguinte fluxo: enviar o arquivo através da tela de envio de arquivo na tela UploadFiles.
Exibir dados de jogos na tela games.
-----------------------------------------------------------------
#Proposta de Solução#

A proposta foi utilizar os conceitos de Rest. e arquitetura de micro serviços parai isso foi desenvolvida uma API responsável por tratar as requisições do cliente, implementar as regras de negócio e realização as operações de acesso a dados.

A camada de Interface contém o contrato a ser implementado pela camada de negócio.

A camada Business é responsável por ler, tratar e retornar o arquivo e também realizar chamadas de consulta e persistência.

A camada de Domínio é responsável por realizar as operações no banco de dados.

A camada Model possui as entidades utilizadas na solução.

O cliente utiliza o padrão MVC e tem a responsabilidade de orquestrar as requisições do usuário, exibir os dados para os usuários e consumir os serviços da web API.

Para o banco de dados foi utilizado o EntityFramework com a estratégia de CodeFirst.

--------------------------------------------------------------------------------------

