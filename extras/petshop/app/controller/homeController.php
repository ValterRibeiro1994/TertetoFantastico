<?php

class HomeController {
    private HomeTemplate $template;
    public function __construct(array $request){
        $this->template = new HomeTemplate();
        $produtos = $this->getProdutos();
        $categorias = $this->getCategorias("1");
        if ($request['funcao'] == "adicionarCarrinho"){
            $this->adicionarCarrinho($request['dados'][0]);
            header("Location: /petshop/home");
            exit();
            // echo($this->template->criarPagina($categorias, $produtos)); 
        } else if ($request['funcao'] == "finalizarCompra"){
            $this->adicionarCarrinho($request['dados'][0]);
            header("Location: /petshop/home");
            exit();
        } else if ($request['funcao'] == "filtro"){
            // settar produtos
            // settar categoria ativa
            header("Location: /petshop/home");
            exit();
        }
        echo($this->template->criarPagina($categorias, $produtos));
    }

    public function getCategorias(string $id){
        $categoria = [];
        for ($x = 1; $x < 10; $x++){
            $nome = "Categoria-$x";
            if ((string) $x == $id){
                $ativo = "active";
            } else {
                $ativo = "";
            }

            $categoria[] = [
                "idCategoria" => $x,
                "nomeCategoria"=>$nome,
                "ativo" => $ativo
            ];

        }
            return [
                "categorias"=> $categoria
            ];
    }

    public function getProdutos(){
  
        $produto = [];
        for ($x = 0; $x < 10; $x++){
            $nome = "produto-$x";
            $descricao = "Produto blabalaslkdasadnlaskda";
            $valor = "50.0$x";
            $imagem = "./app/imagens/logo_p.png";
            $produto[] = [
                "idProduto" => $x,
                "nomeProduto"=>$nome,
                "descricao"=>$descricao,
                "imagem"=>$imagem,
                "preco"=>$valor
            ];
        }

        return [
            "produtos" => $produto
        ];

        
    }

    public function adicionarCarrinho(string $id){
        // usar repositorio para localizar produto
        
        echo("Produto  de id $id salvo no carrinho");
    }
}