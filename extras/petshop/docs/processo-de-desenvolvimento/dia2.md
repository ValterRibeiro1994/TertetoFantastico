# Diário de Desenvolvimento — Dia 2

Responsável: Valter Tertuliano

Resumo das atividades
- Implementação da `BaseTemplate`: métodos para montar cabeçalho, navegação, corpo e rodapé, servindo como base para templates específicos.
- Criação do `CadastroTemplate` com formulários não sensíveis (campos básicos como nome, email e telefone para entregas/agendamentos).
- Ajustes na `LoginTemplate` para herdar comportamentos comuns da `BaseTemplate`.
- Adição de mecanismo de autoload para carregar classes automaticamente.
- Configuração básica de roteamento (arquivo `.htaccess` e roteador simples) para centralizar requisições no `index.php`.

Observações técnicas
- Controllers iniciais (como `loginController`) estão em andamento; validações de POST e regras de autenticação dependem do planejamento de segurança.
- Foi adotado um roteador simples para mapear URLs a controllers e métodos, facilitando o desenvolvimento e testes locais.

Tempo registrado
- Data: 02/07/2026
- Duração aproximada: 2 horas
    - Roteador: Classe para encaminhar as requisições aos seus devidos controllers

