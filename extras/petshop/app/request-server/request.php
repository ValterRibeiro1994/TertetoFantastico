<?php

class Request {
    private array $request;
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
            $this->request = [
                "metodo" => $requisicao,
                "classe" => $classe,
                "funcao" => $metodo,
                "dados" => $parametros
            ];
            

            // if ($classe == "home") {
            //     new HomeController();
            // } else if ($classe == "login") {
            //     new LoginController($requisicao, $request);
            // } else if ($classe == 'cadastro'){
            //     new CadastroController($requisicao, $metodo, $parametros);
            // } else {
            //     echo("PAGE NOT FOUND 404");
            // }
            // new Roteador($requisicao, $classe, $metodo, $parametros);
        }  else if ($requisicao == "POST"){
            if (isset($_POST['formLogin'])){
                $this->request = [
                    "metodo" => $requisicao,
                    "classe" => "login",
                    "funcao" => "autenticar",
                    "dados" => $_POST
                ];
            } else if (isset($_POST['formCadastro'])){
                $this->request = [
                    "metodo" => $requisicao,
                    "classe" => "cadastro",
                    "funcao" => "cadastrar",
                    "dados" => $_POST
                ];
            }
        } 
    }

    public function getRequest(): array {
        return $this->request;
    }
}