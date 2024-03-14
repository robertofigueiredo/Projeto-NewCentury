
# Adivinha Número Inteiro - Desafio NewCentury

Este é um jogo de adivinhação de número inteiro desenvolvido como parte de um desafio proposto pela NewCentury. O projeto foi implementado como uma aplicação web seguindo a arquitetura MVC (Model-View-Controller), utilizando SQLite como banco de dados e Entity Framework Core para interação com o banco de dados. Além disso, o projeto foi organizado em três camadas: apresentação, lógica de negócios e acesso a dados.

Como Utilizar

Para utilizar este projeto, siga os passos abaixo:

Certifique-se de ter o .NET 6.0 SDK instalado em sua máquina.

Clone ou faça o download do código-fonte do projeto para o seu ambiente.

Navegue até o diretório raiz do projeto no terminal ou prompt de comando.

Execute o projeto e comece a usar :).

Estrutura do Projeto MVC
O projeto segue uma estrutura em camadas para garantir uma separação clara das responsabilidades. Veja como o projeto está organizado:

Controllers
Os controladores são responsáveis por lidar com as requisições HTTP e direcioná-las para os serviços apropriados. Eles cuidam da entrada e saída de dados da aplicação web.

Services
Os serviços contêm a lógica de negócio e realizam operações nos dados. Eles encapsulam a lógica de negócio e interagem com os repositórios para executar as operações da aplicação web.

Models
Os modelos de visualização contêm os objetos de transferência de dados utilizados para entrada e saída da aplicação. Eles definem a estrutura dos dados que são enviados e recebidos pela aplicação, garantindo uma separação clara entre as entidades do domínio e os dados da aplicação.

Repositories
Os repositórios são responsáveis pela comunicação com o banco de dados e operações de persistência. Eles lidam com a recuperação e persistência dos dados no banco de dados, abstraindo os detalhes de acesso ao banco de dados para os serviços.

Domain
O domínio contém as entidades principais da aplicação. Essas entidades representam os objetos manipulados pela aplicação e contêm as regras de negócio relacionadas a essas entidades.

Essa estrutura em camadas ajuda a manter a separação de responsabilidades, facilitando a manutenção do código e promovendo a reutilização de componentes.
