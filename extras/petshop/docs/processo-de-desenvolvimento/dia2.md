# **Valter Tertuliano**

# trabalho realizado
- BaseTemplate
    A classe constroi os elementos padrão do site (cabeçalho, barra de navegação, corpo da página e rodapé) a vantagem é ter um unico ponto de modificação para o layout geral da página, além de poder sobreescrever algum método se necessario,os Templates devem herdar essa classe e apenas criar o método criarPagina aonde o conteudo da pagina deve ser passada como parametro dentro do metodo criarMain.

- CadastroTemplate
    Cadastro construido sem a intenção de obter nenhum dado sensivel, de fato será necessario o email para cadastro e o telefone para serviços de entrega e agendamento.

- LoginTemplate
    A classe de login agora está herdando da classe Base, ela apenas cria os componentes necessarios da página e que são unicos dela, no caso apenas o formulario.

- Autoload
    A classe importa automaticamente todos os recursos permitidos dentro do projeto, agilizando o trabalho e a criação dos objetos

- .htacces
    Concentra todas as requisições para o index do projeto, permitindo mais controle sobre as rotas e os arquivos do projeto

- Pasta rotas:
    - Roteador: Classe para encaminhar as requisições aos seus devidos controllers

- Pasta controller
    - loginController: Classe para gerenciar todas as requisições recebidas para a página de login, sendo elas GET e POST, está em fase de construção, falta definir os métodos para Post onde os dados são validados, e depende do planejamento de segurança que ainda não foi realizado, PHP permiti gerenciar sessões de maneira facil, porém estou estudando a possibilidade de cordenar as sessões em um banco de dados.

- Observações Finais:
    - Templates: Classe base teve algumas rotas definidas na barra de navegação, ainda não foi construida a pagina home, usei um modelo simples de navegação apenas para testar o funcionamento das rotas e o direcionamento das requisiçoes.
    - Controllers

# informações do trabalho
- **Data: 02/07/2026**
- **Tempo gasto: 2 horas**
 
