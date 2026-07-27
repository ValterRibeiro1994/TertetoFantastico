<?php

class LoginController {
    private LoginTemplate $template;

    public function __construct(array $dados){
        $this->template = new LoginTemplate();
        if ($dados['metodo'] == "GET"){
            // quando se requisita a pagina com get ela é iniciada virgem
            try {
                echo($this->template->criarPagina());
                
            } catch (Exception $error){
                echo($error->getMessage());
            }
        }
    }

    
    private function autenticar(string $email = "", string $senha = ""): bool{
        return true;
    }
}