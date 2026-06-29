<?php

class Componentes {

    public function documentoHtml(string $body, string $titulo){
        return "
        <!DOCTYPE html>
        <html lang=\"pt-br\">
        <head>
            <meta charset=\"UTF-8\">
            <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">
            <link rel=\"stylesheet\" href=\"./app/recursos/bootstrap-5.3.8-dist/css/bootstrap.min.css\">
            <title>$titulo</title>
        </head> 
        $body
        </html>
        ";

    }

    public function bodyPagina(string $conteudo, string $classes = ""){
        return "<body class='container-fluid $classes'> $conteudo </body>";
    }

    public function headerPagina(string $conteudo, string $classes = ""){
        return "<header class='p-1 $classes'> $conteudo </header>";
    }

    public function nav(array $links){
        $n = count($links);
        $nav = "<ul class='nav nav-tabs nav-justified'>";
        for ($x = 0; $x < $n; $x++){
            $nav .= "<li class='nav-item'>" . $links[$x] . "</li>";
        }
        $nav .= "</ul>";
        return $nav;
    }

    public function navLink(string $link, string $pagina, bool $actived = false){
        $ativar = $actived ? "active" : "";
        
        $a = "<a class='nav-link $ativar' ";
        $a .= "href='$link'> ";
        $a .= $pagina . "</a>";
        return $a;
    }

    public function bannerHeader(){
        $banner = '
        <figure class="col-4">
            <img class="img-fluid" src="./app/imagens/logo_p.png" alt="">
        </figure>
        <h1 class="display-2 col text-center ">Pet shop dos Amigos</h1>';
        return $banner;
    }

    public function divRow(string $conteudo, string $classes = ""){
        return "<div class='row $classes'>  $conteudo </div>";
    }
}

// // exemplo login
// $componentes = new Componentes();

// // banner do site 
// $banner = $componentes->bannerHeader();
// $div_banner = $componentes->divRow($banner);

// // barra de navegaçao

// // - links da barra de navegação
// $link_home = $componentes->navLink("#", "Home", true);
// $link_produtos = $componentes->navLink("#", "Produtos");
// $link_servicos = $componentes->navLink("#", "servicos");
// $link_contato = $componentes->navLink("#", "contato");
// $link_cadastrar = $componentes->navLink("#", "cadastrar");
// $link_conectar = $componentes->navLink("#", "conectar");

// // - array de links
// $array_links = [$link_home, $link_produtos, $link_servicos, $link_contato, $link_cadastrar, $link_conectar];

// // - constroi a barra de navegaçao com os links
// $nav = $componentes->nav($array_links);
// $div_nav = $componentes->divRow($nav);

// // une o banner e a barra de navegação
// $conteudo_header = $div_banner . "\n\t" . $div_nav;

// // cria o header da página
// $header = $componentes->headerPagina($conteudo_header);

// // cri o corpo da página
// $body = $componentes->bodyPagina($header);

// // cria o documento final
// $html = $componentes->documentoHtml($body, "Home");
// echo($html);
