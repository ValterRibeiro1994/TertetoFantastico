<?php

// require_once("./app/templates/baseTemplate.php");

class CadastroTemplate extends BaseTemplate {

        public function __construct(){
            parent::__construct();
        }

        public function criarPagina(bool $erro = false, string $msg = ""){
            $header = $this->criarHeader("cadastrar"); // criar metodo interno para criar header
            $form = $this->criarForm($erro, $msg);
            $main = $this->criarMain($form); // criar conteudo principal
            $footer = $this->criarRodape(); // criar rodape da pagina
            $conteudo = $header . " " . $main . " " . $footer;
            $body = $this->componentes->bodyPagina($conteudo, "p-2");
            return $this->componentes->documentoHtml($body, "Cadastrar");
        }

        private function criarForm(bool $erro = false, string $msg = ""){
            $nome_label = $this->componentes->criarLabelForm("Nome");
            $sobrenome_label = $this->componentes->criarLabelForm("Sobrenome");
            $email_label = $this->componentes->criarLabelForm("Email");
            $senha_label = $this->componentes->criarLabelForm("Senha");
            $confirmar_senha_label = $this->componentes->criarLabelForm("Confirmar Senha");
            $whatsapp_label = $this->componentes->criarLabelForm("Whatsapp");
            
            $nome_input = $this->componentes->criarInputForm("inputNome", placeholder: "Digite seu nome...");
            $sobrenome_input = $this->componentes->criarInputForm("inputSobrenome", placeholder: "Digite o sobrenome");
            $email_input = $this->componentes->criarInputForm("inputEmail", "email", "Digite o email aqui....");
            $senha_input = $this->componentes->criarInputForm("inputSenha", "password");
            $confirmar_senha_input = $this->componentes->criarInputForm("inputConfirmarSenha", "password");
            $whatsapp_input = $this->componentes->criarInputForm("inputWhatsapp", "tel", "(xx) x-xxxx-xxxx");
            
            $submit = $this->componentes->criarInputSubmit("Cadastrar", "formCadastro");
            $subtitulo = $this->componentes->subTitulo("Cadastre-se", "rounded-5 my-2 mx-auto");
            if ($erro){
                $subtitulo = $this->componentes->subTitulo("Cadastre-se", " m-1");
                $label_erro = "<br>" . $this->componentes->criarLabelForm("ERRO: $msg", "bg-danger border border-1 m-1 p-1 rounded-3 fs-2 text-white") . "<br>";
                $elementos = [
                    $subtitulo, 
                    $nome_label, $nome_input, 
                    $sobrenome_label, $sobrenome_input, 
                    $email_label, $email_input,
                    $whatsapp_label, $whatsapp_input,
                    $senha_label, $senha_input,
                    $confirmar_senha_label, $confirmar_senha_input,
                    $label_erro,
                    $submit
                    ];
            } else {
                $elementos = [
                    $subtitulo, 
                    $nome_label, $nome_input, 
                    $sobrenome_label, $sobrenome_input, 
                    $email_label, $email_input,
                    $whatsapp_label, $whatsapp_input,
                    $senha_label, $senha_input,
                    $confirmar_senha_label, $confirmar_senha_input,
                    $submit
                    ];
            }

            $form = $this->componentes->criarForm($elementos, "/cadastro");
            $div = $this->componentes->divRow($form, "p-1 shadow-lg rounded-5 border border-1 border-primary w-50 mx-auto");
            return $div;
            }

        
}