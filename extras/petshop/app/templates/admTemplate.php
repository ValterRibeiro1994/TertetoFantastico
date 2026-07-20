<?php
require_once __DIR__ . "/baseTemplate.php";

class AdmTemplate extends BaseTemplate {
    
    public function __construct(){
        parent::__construct();
    }

    /**
     * Sobrescreve o método criarNav da BaseTemplate para desenhar as abas da ADM.
     * Isso garante que não alteramos a BaseTemplate original.
     */
    protected function criarNav(string $pagina){
        $pagina = strtolower($pagina);
        
        // Define as abas administrativas solicitadas e seus respectivos links (Query Strings)
        $paginas = [
            "produtos"     => ["?aba=produtos", false],
            "financeira"   => ["?aba=financeira", false],
            "estoque"      => ["?aba=estoque", false],
            "vendas"       => ["?aba=vendas", false],
            "funcionarios" => ["?aba=funcionarios", false],
        ];

        // Se a página solicitada não estiver no array, definimos "produtos" como padrão
        if (!array_key_exists($pagina, $paginas)) {
            $pagina = "produtos";
        }

        // Marca a aba atual como ativa
        $paginas[$pagina][1] = true;
        
        $array_links = [];
        foreach($paginas as $pagi => $active){
            $link = $active[0];
            $ativa = $active[1];
            $pag = mb_strtoupper($pagi);
            // Utiliza o componente navLink existente sem modificá-lo
            $array_links[] = $this->componentes->navLink($link, $pag, $ativa);
        }

        // Utiliza o componente nav existente sem modificá-lo
        $nav = $this->componentes->nav($array_links);
        return $this->componentes->divRow($nav);
    }

    /**
     * Cria a estrutura da página baseada na aba ativa selecionada
     */
    public function criarPagina(string $aba = "produtos"){
        // O criarHeader chamará o nosso criarNav sobrescrito acima
        $header = $this->criarHeader($aba);

        // Renderiza o conteúdo dinâmico do painel principal de acordo com a aba
        switch ($aba) {
            case "produtos":
                $conteudoMain = $this->formProduto();
                break;
            case "financeira":
                $conteudoMain = $this->renderizarFinanceira();
                break;
            case "estoque":
                $conteudoMain = $this->renderizarEstoque();
                break;
            case "vendas":
                $conteudoMain = $this->renderizarVendas();
                break;
            case "funcionarios":
                $conteudoMain = $this->renderizarFuncionarios();
                break;
            default:
                $conteudoMain = $this->criarMain("<h1>Painel Administrativo</h1>");
                break;
        }

        // Monta o documento HTML final usando os métodos intocados de ComponentesTemplate
        $body = $this->componentes->bodyPagina($header . $conteudoMain . $this->criarRodape());
        return $this->componentes->documentoHtml($body, "ADM - " . ucfirst($aba));
    }

    private function formProduto(){
        $form = $this->cadastrarProduto();
        return $this->criarMain($form);
    }
    
    private function cadastrarProduto(){
        $titulo = $this->componentes->subTitulo("Cadastre um novo produto na loja");
        
        // LABELS
        $nome = $this->componentes->criarLabelForm("Nome do Produto");
        $descricao = $this->componentes->criarLabelForm("Descrição do produto");
        $preco = $this->componentes->criarLabelForm("Preço de compra");
        $image = $this->componentes->criarLabelForm("Envie uma imagem do produto");
        $estoque = $this->componentes->criarLabelForm("Informe a quantidade de itens a ser adicionada");

        // INPUTS 
        $nome_input = $this->componentes->criarInputForm("nomeProduto", placeholder: "Informe o nome do produto...");
        $desc_input = $this->componentes->criarInputForm("descricaoProduto", placeholder: "Descreva o produto....");
        $preco_input = $this->componentes->criarInputForm("precoProduto", placeholder: "Informe o valor de compra do produto...");
        $imagem_input = $this->inputImagem();
        $estoque_input = $this->componentes->criarInputForm("quantidadeProduto", placeholder: "Informe a quantidade de itens a ser adicionada");
        
        // BOTÃO
        $btn = $this->componentes->criarInputSubmit("Cadastrar Produto", "cadastroProduto");
        
        $elementos = [
            $titulo,
            $nome, $nome_input, 
            $descricao, $desc_input,
            $preco, $preco_input,
            $image, $imagem_input,
            $estoque, $estoque_input,
            $btn
        ];
        
        return $this->criarForm($elementos, "");
    }

    private function inputImagem(){
        return '<input type="file" name="inputFoto" class="form-control" accept="image/*">';
    }

    private function criarForm(array $elementos, string $action, string $metodo = "post"){
        $n = count($elementos);
        $form = "<form action='$action' method='$metodo' enctype='multipart/form-data' class='mb-3'>";
        for ($x = 0; $x < $n; $x++){
            $form .= " " . $elementos[$x];
        }
        $form .= "</form> ";
        return $form;
    }

    // Métodos placeholders para renderizar as novas abas
    private function renderizarFinanceira(){
        $conteudo = $this->componentes->subTitulo("Gestão Financeira");
        $conteudo .= "<p class='text-center fs-5'>Aqui você pode visualizar o fluxo de caixa, relatórios de despesas e lucros.</p>";
        return $this->criarMain($conteudo);
    }

    private function renderizarEstoque(){
        $conteudo = $this->componentes->subTitulo("Controle de Estoque");
        $conteudo .= "<p class='text-center fs-5'>Gerenciamento de entrada e saída de mercadorias da loja física e online.</p>";
        return $this->criarMain($conteudo);
    }

    private function renderizarVendas(){
        $conteudo = $this->componentes->subTitulo("Histórico de Vendas");
        $conteudo .= "<p class='text-center fs-5'>Acompanhe os pedidos realizados, status de pagamento e faturamento.</p>";
        return $this->criarMain($conteudo);
    }

    private function renderizarFuncionarios(){
        $conteudo = $this->componentes->subTitulo("Cadastro de Funcionários");
        $conteudo .= "<p class='text-center fs-5'>Gerencie os dados cadastrais, cargos e permissões dos operadores do sistema.</p>";
        return $this->criarMain($conteudo);
    }
}