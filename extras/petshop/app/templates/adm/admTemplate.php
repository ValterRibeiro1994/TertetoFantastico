<?php

class AdmTemplate extends BaseTemplate {
    public function __construct(){
        parent::__construct();
    }
    
    private function cadastrarProduto(){
        $nome = $this->componentes->criarLabelForm("Nome do Produto");
        $descricao = $this->componentes->criarLabelForm("Descrição do produto");
        $preco = $this->componentes->criarLabelForm("Preço de compra");
        $image = $this->componentes->criarLabelForm("Envie uma imagem do produto");
        $estoque = $this->componentes->criarLabelForm("Informe a quantidade em estoque");

    }

    private function inputImagem(){
        return '<input type="file"  name="inputFoto" accept="image/*">';
    }

    private function criarForm(array $elementos, string $action, string $metodo = "post"){
        $n = count($elementos);
        $form = "<form action='$action' method='$metodo' enctype='multipart/form-data' >";
        for ($x = 0; $x < $n; $x++){
            $form .= " " . $elementos[$x];
        }
        $form .= "</form> ";
        return $form;
    }
}