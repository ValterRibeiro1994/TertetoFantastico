<?php

require_once('../template/componentes.php');

class TemplateLogin {
    private ComponentesTemplates $componentes;

    public function __construct()
    {
        $this->componentes = new ComponentesTemplates();
    }
    
    public function criarTemplate(bool $erro, string $msg){
        $html = $this->componentes->criarDocumentoHtml('Projeto Alpha - Login');
        

        $inputEmail = $this->componentes->criarInputFormText('E-mail', 'emailUsuario', 'email', 'Digite o e-mail...');
        $inputSenha = $this->componentes->criarInputFormText('Senha', 'senhaUsuario', 'password', 'Digite a senha');
        $inputLembrar = $this->componentes->criarInputFormCheck("lembrar", "lembrarUsuario");

        $botao = $this->componentes->criarBotaoSubmit('Conectar', "login");
        $botao .= $this->componentes->criarBotaoSubmit('Criar conta', "cadastro");
        $botao .= $this->componentes->criarBotaoSubmit('Recuperar Senha', "recuperar");
        

        $inputs = [];
        if ($erro){
            $msg_erro = $this->componentes->criarLabelErro($msg);
            $inputs = [$inputEmail, $inputSenha, $inputLembrar, $msg_erro];
        } else {
            $inputs = [$inputEmail, $inputSenha, $inputLembrar];
        }

        $formulario = $this->componentes->criarForm($inputs, '../controller/loginController.php', 'Conecte-se', $botao);

        $body = $this->componentes->criarBody($formulario);

        $documento = $html . ' ' . $body . ' ' . $this->componentes->fecharDocumentoHtml();
        return $documento;
    }
}

