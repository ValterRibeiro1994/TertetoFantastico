<?php

require_once("./app/templates/componentes.php");
require_once("./app/templates/baseTemplate.php");

class LoginTemplate extends BaseTemplate {

    public function __construct(){
        parent::__construct();
    }
    
    public function criarPagina(bool $erro = false, string $msg = ""){
        $header = $this->criarHeader("conectar"); // criar metodo interno para criar header
        $form_login = $this->criarFormLogin($erro, $msg);
        $main = $this->criarMain($form_login); // criar conteudo principal
        $footer = $this->criarRodape(); // criar rodape da pagina
        $conteudo = $header . " " . $main . " " . $footer;
        $body = $this->componentes->bodyPagina($conteudo, "p-2");
        return $this->componentes->documentoHtml($body, "Conectar");
    }

    

    public function criarFormLogin(bool $erro = false, string $msg = ""){
        $label_email = $this->componentes->criarLabelForm("Email");
        $input_email = $this->componentes->criarInputForm("inputEmail", type: "email", placeholder: "Digite seu email aqui...");
        $label_senha = $this->componentes->criarLabelForm("Senha");
        $input_senha = $this->componentes->criarInputForm("inputSenha", "password", "Digite sua senha aqui...");
        $input_submit = $this->componentes->criarInputSubmit("Conectar");
        $input_lembrar = $this->componentes->criarInputFormCheck("Lembrar", "inputLembrar");
        $subtitulo = $this->componentes->subTitulo("Conecte-se", "rounded-5 my-2 mx-auto");

        if ($erro){
            $subtitulo = $this->componentes->subTitulo("Conecte-se", " m-1");
            $label_erro = "<br>" . $this->componentes->criarLabelForm("ERRO: $msg", "bg-danger border border-1 m-1 p-1 rounded-3 fs-2 text-white") . "<br>";
            $elementos = [$subtitulo, $label_email, $input_email, $label_senha, $input_senha, $label_erro, $input_lembrar, $input_submit ];
        } else {
            $elementos = [$subtitulo, $label_email, $input_email, $label_senha, $input_senha, $input_lembrar, $input_submit];
        }

        $form = $this->componentes->criarForm($elementos, "");
        $div = $this->componentes->divRow($form, "p-1 shadow-lg rounded-5 border border-1 border-primary w-50 mx-auto");
        return $div;
    }


}
