<?php

// capturar $_GET['url']
class Roteador {
    public function __construct()
    {
         $requisicao = $_SERVER['REQUEST_METHOD'];
        if ($requisicao === "GET"){
            if (!isset($_GET['url'])){
                // dados não foram enviados
                $classe = "home";
                $metodo = "index";
                $parametros = [];
            } else {
                // captura os parametros
                $array = explode("/", $_GET['url']);
                // checa se o primeiro parametro está vazio
                if (empty($array[0])){
                    $classe = "home";
                } else {
                    $classe = $array[0];
                }

                // remove a classe / primeiro parametro
                array_shift($array);

                // checa se ainda tem parametros
                if (count($array) == 0){
                    $metodo = "index";
                    $parametros = [];
                } else {
                    // verifica se o parametro está vazio
                    if (empty($array[0])){
                        $metodo = "index";
                    } else {
                        $metodo = $array[0];
                    }

                    // remove o método
                    array_shift($array);

                    // checa se ainda restou parametros
                    if (count($array) > 0){
                        $parametros = $array;
                    } else {
                        $parametros = [];
                    }
                }
            }

            $classe = mb_strtolower($classe);
            if ($classe == "home") {
                $nav = <<<HTML
                <div class="row">  
                    <ul class="nav nav-tabs nav-justified my-3">
                        <li class="nav-item"><a class="nav-link" href="/petshop/home">HOME</a></li>
                        <li class="nav-item"><a class="nav-link" href="#">PRODUTOS</a></li>
                        <li class="nav-item"><a class="nav-link" href="#">SERVIÇOS</a></li>
                        <li class="nav-item"><a class="nav-link" href="#">CONTATO</a></li>
                        <li class="nav-item"><a class="nav-link" href="/petshop/cadastro">CADASTRAR</a></li>
                        <li class="nav-item"><a class="nav-link active" href="/petshop/login">CONECTAR</a></li>
                    </ul> 
                </div>
                HTML;
                echo($nav);
            } else if ($classe == "login") {
                new LoginController($requisicao, $metodo, $parametros);
            } else {
                echo("PAGE NOT FOUND 404");
            }
            // new Roteador($requisicao, $classe, $metodo, $parametros);
        }  else if ($requisicao == "POST"){
            if (isset($_POST['formLogin'])){
                echo("isso mesmo");
            }
        } 
    }
}