<?php

require_once("./app/templates/componentes.php");


class BaseTemplate {
    protected Componentes $componentes;

    public function __construct(){
        $this->componentes = new Componentes();
    }    

    protected function criarMain(string $conteudo, string $classes = ""){
        return "<main class='container-fluid p-3 $classes'> $conteudo </main>";
    }

    protected function criarHeader(string $pagina){
        $banner = $this->criarBanner();
        $nav = $this->criarNav($pagina);
        $conteudo = $banner .  " " . $nav;
        return $this->componentes->headerPagina($conteudo);
    }


    protected function criarBanner(){
        $banner = $this->componentes->bannerHeader();
        return $this->componentes->divRow($banner);
    }

    protected function criarNav(string $pagina){
        $pagina = strtolower($pagina);
        $paginas = [
            "home"=> ["#", false],
            "produtos"=> ["#", false],
            "serviços"=> ["#", false],
            "contato"=> ["#", false],
            "cadastrar"=> ["#", false],
            "conectar"=> ["./app/modelo-templates/login.html", false]
        ];

        if (!array_key_exists($pagina, $paginas)) {
            throw new InvalidArgumentException("Página inválida.");
        }

        $paginas[$pagina][1] = true;
        $array_links = [];
        foreach($paginas as $pagi => $active){
            $link = $active[0];
            $ativa = $active[1];
            $pag = mb_strtoupper($pagi);
            $array_links[] = $this->componentes->navLink($link, $pag, $ativa);
        }

        $nav = $this->componentes->nav($array_links);
        return $this->componentes->divRow($nav);
    }

    protected function criarRodape(){
        $footer = $this->componentes->rodapePagina();
        return $footer;
    }
}