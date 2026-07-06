<?php

class CadastroController {
    private CadastroTemplate $template;
    public function __construct(array $request){
        $this->template = new CadastroTemplate();
        if ($request['metodo'] == "GET"){
            echo($this->template->criarPagina());
            
        } else if ($request['metodo'] == "POST"){
            var_dump($_POST);
        }
    }

    
    private function autenticar(string $email = "", string $senha = ""): bool{
        return true;
    }
}