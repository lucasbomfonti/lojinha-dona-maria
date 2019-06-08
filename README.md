Bem vindo a Lojinha da Dona maria.

-- A WebApi foi desenvolvida em AspNet.Core e documentada via Swagger;

Processo de inicialização:

-- abrir a raiz do projeto via terminal e executar o comando docker-compose up -d --build;


-- O docker-compose está composto de 2 containers sendo a api e o banco de dados;


-- Tive um problema no Docker instalado em minha maquina então caso não inicie a api 
será necessário inicia-lo na mão com o comando "docker run -d -p 8081:80 {{Nome da imagem}}";


-- Ainda em relação ao Docker a imagem de configuração do banco pode ocasionamente gerar conflito de porta
caso o mesmo aconteça foi deixado comentado no appsettings.json da aplicação outra ConnectionString da qual 
poderá ser utilizada caso o container do banco não levante;

-- O sistema está programado para cada requisição necessitar de um token que é adicionado no header
-- para conseguir esse token devemos realizar um login no endpoint "http://localhost:8081/user/login"
passando o seguinte body:
{
  "name": "admin",
  "password": "123456"
}
O mesmo devolverá um token que deve ser adicionado no header para a utilização das outras requisições da api;
