<?php


class HomeTemplate extends BaseTemplate {
    public function __construct(){
        parent::__construct();
    }

    public function criarPagina(array $categorias, array $produtos){
        $header = $this->criarHeader("home");
        $footer = $this->criarRodape();
        $layout = $this->criarLayout($categorias, $produtos);
        $main = $this->criarMain($layout);
        $conteudo = $header . $main . $footer;
        $body = $this->componentes->bodyPagina($conteudo);
        return $this->componentes->documentoHtml($body, "HOME");
    }

    public function criarLayout(array $categorias, array $produtos){
        $aside = $this->criarAside($categorias);
        $produtos = $this->layoutProdutos($produtos);
        return $this->componentes->divRow($aside . $produtos);
    }

    public function layoutProdutos(array $dadosProdutos){
        $div = "<div class='col-9 mx-auto'>";
        $div .= $this->adicionarProdutos($dadosProdutos);
        $div .= "</div>";
        return $div;
    }
    
    private function criarAside(array $dadosCategoria){
        $aside = "<aside class='col-2'>";
        $nav = "<nav>";
        $ul = $this->adicionarCategorias($dadosCategoria['categorias']);
        $nav .= $ul . "</nav>";
        $aside .= $nav . "</aside>";
        return $aside;
    }

    private function adicionarCategorias(array $dadosCategoria){
        $ul = "<ul class='nav nav-pills flex-column'>";
        foreach($dadosCategoria as $categoria){
            $href = "home/filtro/" . $categoria['idCategoria'];
            $nome = $categoria['nomeCategoria'];
            $ativo = $categoria['ativo'];
            $a = "<a class='nav-link $ativo' href='$href'>$nome</a>";
            $li = "<li class='nav-item'> $a </li>";
            $ul .= $li;
        }
        $ul .= "</ul>";
        return $ul;
    }

    private function adicionarProdutos(array $dadosProdutos){
        if (count($dadosProdutos['produtos']) > 10){
            throw new Exception("Limite de produtos excedido !!!");
        }

        $produtos = $dadosProdutos['produtos'];
        $div = "<div class='d-flex flex-wrap'>";
        foreach ($produtos as $produto){
            $div .= $this->criarCard($produto);
        }
        $div .= "</div>";
        return $div;
    }

    private function criarCard(array $produto){
        $nome = $produto['nomeProduto'];
        $imagem = $produto['imagem'];
        $descricao = $produto['descricao'];
        $valor = "R$ " . number_format($produto['preco'], 2,);  
        $carrinho = "home/adicionarCarrinho/" . $produto['idProduto'];
        $comprar = "home/finalizarCompra/" . $produto['idProduto'];  
        return "
            <div class='card mx-2 mb-2' style='width: 200px;'>
                <img src='$imagem' alt='' class='card-img-top'>
                <div class='card-body'>
                    <h4 class='card-title'>$nome</h4>
                    <p class='card-text'>$descricao</p>
                    <h5 class='fw-bold'>$valor</h5>
                    <a href='$carrinho' class='btn btn-outline-primary m-2'>Adicionar ao carrinho</a>
                    <a href='$comprar' class='btn btn-primary m-2 w-100'>Comprar</a>
                </div>

            </div>
            ";
    }

    private function pagina(array $dadosProdutos){
        
    }
}