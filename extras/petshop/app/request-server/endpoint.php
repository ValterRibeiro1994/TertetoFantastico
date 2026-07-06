<?php

class Endpoint {
    public function __construct(array $request){
        if ($request['metodo'] == "GET"){
            $this->endpointGets($request);
        }
    }

    private function endpointGets(array $request){
        if ($request['classe'] == "home"){
            new HomeController($request);
        } else if ($request['classe'] == "login"){
            new LoginController($request);
        } else if ($request['classe'] == "cadastro"){
            new CadastroController($request);
        } else {
            echo("PAGINA NÂO CONHECIDA ");
            new HomeController($request);
        }
    }
}