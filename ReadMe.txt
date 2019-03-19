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

Connection String ap�s a cria��o do banco de dados
<add name="NotificationConnection" connectionString="Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=ApplicationNameContext-20151023111236; 
Integrated Security=True;" providerName="System.Data.SqlClient" />

Ao rodar a aplica��o seguir o seguinte fluxo: enviar o arquivo atrav�s da tela de envio de arquivo na tela UploadFiles.
Exibir dados de jogos na tela games.
-----------------------------------------------------------------
#Proposta de Solu��o#

A proposta foi utilizar os conceitos de Rest. e arquitetura de micro servi�os parai isso foi desenvolvida uma API respons�vel por tratar as requisi��es do cliente, implementar as regras de neg�cio e realiza��o as opera��es de acesso a dados.

A camada de Interface cont�m o contrato a ser implementado pela camada de neg�cio.

A camada Business � respons�vel por ler, tratar e retornar o arquivo e tamb�m realizar chamadas de consulta e persist�ncia.

A camada de Dom�nio � respons�vel por realizar as opera��es no banco de dados.

A camada Model possui as entidades utilizadas na solu��o.

O cliente utiliza o padr�o MVC e tem a responsabilidade de orquestrar as requisi��es do usu�rio, exibir os dados para os usu�rios e consumir os servi�os da web API.

Para o banco de dados foi utilizado o EntityFramework com a estrat�gia de CodeFirst.

--------------------------------------------------------------------------------------

