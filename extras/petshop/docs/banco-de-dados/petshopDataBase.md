# Planejamento do Banco de Dados

Este documento descreve o esquema inicial proposto para suportar a plataforma de e-commerce para petshops.

Entidades principais (visão inicial)
- `loja`: informações da loja/cliente (nome, slogan, cores, banners, configurações).
- `produto`: nome, descrição, preço, estoque, referências a imagens e categoria.
- `categoria`: categorias de produto (ex.: rações, brinquedos, higiene).
- `imagem`: metadados das imagens (caminho/URL, tipo, referência ao produto ou banner).
- `servico`: serviços oferecidos (nome, descrição, preço, duração, disponibilidade para agendamento).
- `pedido`: registros de compras (itens, quantidades, total, status, dados do cliente, data).
- `usuario`: contas administrativas (nome, email, permissões). Autenticação e senhas não estão detalhadas aqui.

Exemplo simplificado de tabelas (resumo):

- lojas(id, nome, slug, slogan, cor_primaria, cor_secundaria, banner_url, criado_em)
- categorias(id, loja_id, nome, slug, criado_em)
- produtos(id, loja_id, categoria_id, nome, descricao, preco, estoque, ativo, criado_em)
- imagens(id, produto_id, loja_id, caminho, tipo, criado_em)
- servicos(id, loja_id, nome, descricao, preco, duracao_minutos, criado_em)
- pedidos(id, loja_id, cliente_nome, cliente_email, status, total, criado_em)
- pedido_itens(id, pedido_id, produto_id, quantidade, preco_unitario)
- usuarios(id, loja_id, nome, email, senha_hash, papel, criado_em)

Observações e próximos passos
- Normalizar campos sensíveis (e.g., `senha_hash`) e definir política de senhas.
- Planejar índices e relações (FK) com base em consultas esperadas.
- Definir esquema para imagens: armazenamento em disco vs. banco (recomenda-se armazenar caminho/URL no DB).
- Criar scripts de migração SQL para as tabelas iniciais.