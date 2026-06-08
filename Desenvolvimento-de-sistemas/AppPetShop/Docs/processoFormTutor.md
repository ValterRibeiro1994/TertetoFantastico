# Menu Strip Tools
1 - Adicionado Link de Formulario para cadastrar Pet.

# Getters e Setter
1 - Adicionado atributos privados para nome, cpf, email, celular para inserção dos dados do tutor no banco de dados
2 - Adicionado setters para cada atributo com validação adequada, qualquer regra violada o setter levanta um erro
  - informando qual regra foi violada, as regras são definidas dentro do setter com o auxilio da classe Utilidades

# Inserção no banco de dados 
1 - Adicionada a classe de conexão, e StringBuilder
2 - StringBuilder constroi o comando de insert 
3 - a classe conexão recebe os getters com os dados do tutor e executa o comando

# Throw new Exception
1 - Todos os erros são capturados e enviados em forma de MessageBox para o usuario

# Observações
1 - Adicionado Variavel de controle abrir_form para fechar o formulario corretamente 

## Recomendações para possiveis melhorias 
1 - Filtrar os erros lançados pelo banco em caso de duplicações de email, cpf e etc.
2 - Melhorar o design do formulario
