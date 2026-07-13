<?php

class SessaoController {
    public function __construct()
    {
        // Uma boa prática é verificar se a sessão já não foi iniciada antes
        if (session_status() === PHP_SESSION_NONE) {
            session_start();
        }
    }

    private function iniciarPaginas(){
        $_SESSION['catalogo'] = [
            'paginaAtual' => 1,
            'paginas' => []
        ];
    }

    public function criarTodasAsPaginas(array $produtos){
        // Inicializa a estrutura limpa na sessão
        $this->iniciarPaginas();

        // Divide todos os produtos em blocos de 10
        $paginasAgrupadas = array_chunk($produtos, 10);

        // Percorre cada bloco (que representa uma página)
        foreach($paginasAgrupadas as $indice => $produtosDaPagina){
            $numeroDaPagina = $indice + 1;
            $itensFormatados = [];

            // Formata os produtos desta página específica
            foreach($produtosDaPagina as $produto){
                $itensFormatados[] = [
                    "idProduto"        => $produto->id, // Geralmente usamos o ID aqui, e não o nome
                    "nomeProduto"      => $produto->nome,
                    "descricaoProduto" => $produto->descricao,
                    "precoProduto"     => $produto->preco,
                    "imagem"           => $produto->imagem,
                ];
            }

            // Salva a página inteira estruturada dentro da sessão
            $_SESSION['catalogo']['paginas'][$numeroDaPagina] = $itensFormatados;
        }
    }
}