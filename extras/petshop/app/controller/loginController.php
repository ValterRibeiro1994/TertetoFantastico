<?php

class LoginController {
    private LoginTemplate $template;
    public function __construct(string $requisicao, string $metodo, array $parametros = []){
        $this->template = new LoginTemplate();
        if ($requisicao == "GET"){
            if ($metodo == "index"){
                echo($this->template->criarPagina());
            }
        } else if ($requisicao == "POST"){
            var_dump($_POST);
        }
    }

    
    private function autenticar(string $email = "", string $senha = ""): bool{
        return true;
    }
}