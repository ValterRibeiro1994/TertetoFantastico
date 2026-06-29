<?php

require_once("./app/templates/componentes.php");

class LoginTemplate {
    private Componentes $componentes;
    public function __construct(){
        $this->componentes = new Componentes();
    }

    public function criarPagina(){
        $header = $this->criarHeader(); // criar metodo interno para criar header
        $main = ""; // criar conteudo principal
        $footer = ""; // criar rodape da pagina
        $conteudo = $header . " " . $main . " " . $footer;
        $body = $this->componentes->bodyPagina($conteudo);
        return $this->componentes->documentoHtml($body, "Conectar");
    }

    private function criarHeader(){
        $banner = $this->criarBanner();
        $nav = $this->criarNav();
        $conteudo = $banner .  " " . $nav;
        return $this->componentes->headerPagina($conteudo);
    }

    private function criarBanner(){
        $banner = $this->componentes->bannerHeader();
        return $this->componentes->divRow($banner);
    }

    private function criarNav(){
        $link_home = $this->componentes->navLink("#", "Home");
        $link_produtos = $this->componentes->navLink("#", "Produtos");
        $link_servicos = $this->componentes->navLink("#", "servicos");
        $link_contato = $this->componentes->navLink("#", "contato");
        $link_cadastrar = $this->componentes->navLink("#", "cadastrar");
        $link_conectar = $this->componentes->navLink("#", "conectar", true);

        // - array de links
        $array_links = [$link_home, $link_produtos, $link_servicos, $link_contato, $link_cadastrar, $link_conectar];

        // - constroi a barra de navegaçao com os links
        $nav = $this->componentes->nav($array_links);
        return $this->componentes->divRow($nav);
    }
}
