# Objetivo do Projeto

Este projeto tem por objetivo desenvolver uma plataforma web de e-commerce para petshops, pensada para ser reutilizável
por diferentes lojas. A solução permitirá que cada cliente (loja) personalize aspectos visuais e comerciais do site,
além de gerenciar produtos, serviços e preços de venda.

Principais metas:
- Fornecer um painel administrativo para gerenciar produtos, categorias, imagens, preços e estoque.
- Permitir personalização visual básica: cores, banners, slogan e logo por loja.
- Disponibilizar catálogo público com possibilidade de compra online e/ou agendamento de serviços (banho, tosa, etc.).
- Implementar um modelo de templates que facilite a reutilização da loja em múltiplos clientes.
- Adotar organização em camadas (Model, Repository, Controller, Template) para facilitar manutenção e evolução.

Escopo inicial:
- Painel administrativo com CRUD de produtos, categorias e imagens.
- Configuração visual (tema simples) e campos de identificação da loja (nome, slogan, banner).
- Rotas públicas para exibição do catálogo e formulário de contato/agendamento.
- Estrutura de persistência (banco de dados relacional) com esquema básico para lojas, produtos, pedidos e serviços.

Critérios de sucesso:
- Código organizado e documentado para permitir reaproveitamento em outras lojas.
- Documentação didática e atualizada na pasta `docs` para orientar implantação e customização.

Observações:
- Requisitos de segurança, autenticação e pagamentos serão planejados e implementados nas próximas iterações.
- O projeto deve ser compatível com hospedagem comum em servidores LAMP/Windows com PHP e MySQL.