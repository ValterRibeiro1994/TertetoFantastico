# Projeto Alpha

## Sobre o Projeto

Este projeto é uma aplicação web educacional desenvolvida para demonstrar uma arquitetura em camadas usando PHP, templates e controle básico de banco de dados. O objetivo é mostrar uma estrutura organizada de código, separação de responsabilidades e fluxos comuns de um sistema de cadastro / login / recuperação de senha.

## Objetivo

- Demonstrar padrões de organização em um projeto PHP.
- Fornecer uma base para estudos de MVC simplificado e separação de responsabilidades.
- Ajudar no aprendizado da criação de rotas/controller, templates, conexões com banco de dados e envio de e-mail.
- Servir como projeto educacional para praticar PHP e desenvolvimento web com estruturas manuais.

## Arquitetura e Camadas

A aplicação é organizada em camadas para tornar o código mais legível e fácil de manter:

1. **Camada de Apresentação**
   - Diretório `template/`
   - Arquivos de template responsáveis pela interface e apresentação das páginas.
   - Exemplo: `templateLogin.php`, `templateCadastro.php`, `templateRecuperarSenha.php`, `templateGerenciar.php`.

2. **Camada de Controle**
   - Diretório `controller/`
   - Controllers lidam com as requisições do usuário, validações e execução da lógica principal.
   - Exemplo: `loginController.php`, `cadastroController.php`, `recuperarSenhaController.php`, `pedidoController.php`.

3. **Camada de Dados / Persistência**
   - Diretório `banco_de_dados/`
   - Contém scripts e informações do banco de dados utilizados pela aplicação.
   - Exemplo: `db_alpha.sql`, `codigo_tabela.md`

4. **Camada de Infraestrutura / Serviços**
   - Diretório `src/`
   - Contém bibliotecas e classes auxiliares, como envio de e-mail e autenticação SMTP/POP3.
   - Exemplo: `PHPMailer.php`, `SMTP.php`, `OAuth.php`, `DSNConfigurator.php`

5. **Recursos Estáticos**
   - Diretório `bootstrap/`
   - Arquivos CSS e JS do Bootstrap para estilização e interatividade.

## Fluxo Geral

- O usuário acessa uma rota ou página.
- O controller correspondente processa a requisição.
- O controller pode validar dados, consultar/inserir no banco de dados e chamar templates.
- A camada de template exibe o resultado final para o usuário.
- Os serviços auxiliares (`src/`) cuidam de operações como envio de e-mail ou integração com SMTP.

## Estrutura de Pastas

- `index.php` — ponto de entrada da aplicação.
- `controller/` — lógica de controle e roteamento.
- `template/` — arquivos de visualização.
- `banco_de_dados/` — scripts e esquema do banco.
- `src/` — bibliotecas e classes de suporte.
- `bootstrap/` — CSS e JS de interface.

## Instalação

1. Instale um servidor local com PHP e MySQL (por exemplo, WAMP, XAMPP ou similar).
2. Copie o projeto para a pasta pública do servidor local (por exemplo, `www` no WAMP).
3. Importe o banco de dados usando o arquivo `banco_de_dados/db_alpha.sql`.
4. Ajuste as configurações de conexão com o banco, se necessário, nos arquivos de configuração do projeto.
5. Acesse o projeto pelo navegador em `http://localhost/projet-alpha` ou no caminho configurado no servidor.

## Observações

- Este é um projeto educacional e serve principalmente para aprendizado e estudo.
- Não é aconselhável utilizá-lo em produção sem melhorias em segurança, tratamento de erros e validações adicionais.

## Tecnologias Utilizadas

- PHP
- HTML / templates PHP
- Bootstrap
- MySQL
- PHPMailer / SMTP para envio de e-mails

## Licença

Projeto educacional. Use para estudo e aprendizado.
