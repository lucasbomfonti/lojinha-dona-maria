Bem vindo a Lojinha da Dona maria.

-- A WebApi foi desenvolvida em AspNet.Core 2.1 consumindo um banco SQLServer e documentada via Swagger;

Processo de inicialização:

-- abrir a raiz do projeto via terminal e executar o comando docker-compose up -d --build;

-- a Api deverá ser acessada pelo seguinte endereço: https://localhost:{{PORTA DO CONTAINER}}/swagger/index.html

-- O docker-compose está composto de 2 containers sendo a api e o banco de dados;

-- Tive um problema no Docker instalado em minha maquina então caso não inicie a api 
será necessário inicia-lo na mão com o comando "docker run -d -p 8081:80 {{Nome da imagem}}";

-- Ainda em relação ao Docker a imagem de configuração do banco pode ocasionamente gerar conflito de porta,
caso o mesmo aconteça foi deixado comentado no appsettings.json da aplicação outra ConnectionString apontando para
uma base local da qual poderá ser utilizada caso o container do banco não levante;

-- Caso houver algum problema para iniciar a api outra maneira viável é inicia-la pelo visual studio através do IIS Express
apontando para um banco SQLServer local, onde a api se encarregará de rodar a migration inicial juntamente com o seed;

-- O sistema está programado para ao subir a api rodar um seed adicionando registros;

-- Cada requisição necessitar de um token que é adicionado no header;

-- para conseguir esse token devemos realizar um login no endpoint "http://localhost:{{PORTA DO CONTAINER}}/user/login"
passando o seguinte body:
{
  "name": "admin",
  "password": "123456"
}
O mesmo devolverá um token que deve ser adicionado no header para a utilização das outras requisições da api;
