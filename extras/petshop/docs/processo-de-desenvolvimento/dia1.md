# **Valter Tertuliano**

# trabalho realizado 
- Criação da parte inicial da documentação do projeto
    A documentação permite clareza no objetivo do projeto, como o trabalho deve ser desenvolvido e organizado.

- Criação da estrutura inicial de pastas
    A estrutura inicial consiste na ideia de uma arquitera em camadas (model, template, controller, repository), as pastas de recursos para ferramentas externas, a pasta docs para toda documentação do projeto e planejamento de trabalho, visando faciltar o desenvolvivmento e a comunicação entre os desenvolvedores do sistema

- Criação da camada Template
    A camada de template vai centralizar o front-end do projeto, foi criada uma pasta modelo-templates onde o layout inicial é construido com html e com base nele criar as classes de renderização em php.
    Apenas para exemplicar a ideia de como pretendo trabalhar com os templates, do esboço gerado em HTML criei uma classe para gerar os componentes usados na pagina, essa classe serve de base para os templates principais, a pagina index.php tem um exemplo simples do uso dessa ideia, no momento construi apenas o header principal da pagina.
    A ideia é -> CRIAR esboço da pagina -> Decompor os componentes da pagina em uma classe php -> Montar a pagina final com a classe componentes. Com isso se ganha agilidade já que varias paginas html usam os mesmos componentes.

- Criação da Classe componentes
    Essa classe centraliza todos os componentes de um documento HTML sendo a base para criar os templates do projeto.

- Criação da Classe LoginTemplate
    Essa classe por enquanto só possui o header, na pasta modelo-templates o arquivo login.html já possui o formulario, no esboço falta desenvolver o rodape da pagina.
    É preciso decompor os componentes do formulario e passar eles para a classe componentes.

- Criação do caso de uso para Cliente e Processos do sistema
    Desenhei um diagrama simples de caso de uso fazendo uma relação entre o visitante/cliente e as funções que deve conter no site.

- Observações Finais 

    **Continuei o trabalho das 10:00 as 13:00** 
    Finalizei o Formulario de login da classe LoginTemplate, foram adicionados novos componentes a classe Componentes e fiquei em duvida sobre o que seria melhor, Passar todos as classes do bootstrap como parametros dentro dos metodos ou simplesmente não permitir a passagem de parametros para modificar as classes de estilo, porém em algumas situações seria desnecessario estar passando parametros de classe como no cabeçalho do site que vai se manter o mesmo em todo site na visão do cliente/visitante, talvez algo mude para o painel administrativo, fiz um meio a meio em alguns casos não permiti classes como parametros, e em outros sim, como no template de login na qual o formulario pode ser devolvido com uma mensagem de erro.

    **continuei o trabalho das 16:00 as 18:00**
    Elaborei um rodapé padrão para pagina, finalizei a classe loginTemplate, fiz varios testes de design para encontrar o estilo da página. 
    


# informações do trabalho
- **Data: 29/06/2026**
- **Tempo gasto: 3 horas + 3 horas + 2 horas**

# **Lucas Ubraz**

# **Felipe Rodrigo**