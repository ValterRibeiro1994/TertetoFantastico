## Etapas e Processos

Convenções de documentação
- Registre o trabalho diário em `docs/processo-de-desenvolvimento` como arquivos `dia1.md`, `dia2.md`, etc.
- Cada entrada deve conter:
  - Título com a data e o responsável.
  - Descrição do que foi feito (arquivos afetados, decisões técnicas e motivações).
  - Tempo gasto.

Fluxo de trabalho sugerido
- Planejar a tarefa em uma nota rápida (escopo e critérios de aceitação).
- Implementar em uma branch dedicada.
- Criar/atualizar testes quando aplicável.
- Atualizar a documentação relacionada (`docs/`) e o diário de desenvolvimento.

Estrutura de diretórios (resumo)
- `docs/`: Documentação do projeto e diário de desenvolvimento.
- `recursos/`: Bibliotecas e assets (ex.: Bootstrap).
- `modelo-templates/`: Esboços em HTML usados para criar classes de template.
- `imagens/`: Imagens do site (produtos, banners, logos).
- `templates/`: Classes PHP responsáveis pela renderização do front-end.

Práticas recomendadas
- Favor manter commits pequenos e atômicos com mensagens descritivas.
- Documente decisões de arquitetura importantes no `docs/`.
- Prefira convenções claras ao nomear rotas, controllers e métodos para facilitar manutenção.

