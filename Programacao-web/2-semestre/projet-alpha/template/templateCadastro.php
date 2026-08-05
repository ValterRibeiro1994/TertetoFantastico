<?php

require_once('../template/componentes.php');

class TemplateCadastro {
    private ComponentesTemplates $componentes;

    public function __construct()
    {
        $this->componentes = new ComponentesTemplates();
    }

        public function criarTemplate(bool $erro, string $msg){
        $html = $this->componentes->criarDocumentoHtml('Projeto Alpha - Cadastro');
        

        $inputNome = $this->componentes->criarInputFormText("Nome", "nomeUsuario", "text", "Digite o seu nome");
        $inputCpf = $this->componentes->criarInputFormText("Cpf", "cpfUsuario", "text", "Digite o seu cpf");
        $inputNascimento = $this->componentes->criarInputFormText("Data de nascimento", "nascimentoUsuario", "date", "Digite a data de nascimento");
        $inputCelular = $this->componentes->criarInputFormText("Número do celular", "celularUsuario", "text", "Digite o numero do celular com DDD (apenas numeros)");
        $inputEmail = $this->componentes->criarInputFormText('E-mail', 'emailUsuario', 'email', 'Digite o e-mail...');
        $inputSenha = $this->componentes->criarInputFormText('Senha', 'senhaUsuario', 'password', 'Digite a senha');
        $inputConfirmarSenha = $this->componentes->criarInputFormText('Confirmar Senha', 'senhaConfirmacaoUsuario', 'password', 'Confirme a senha');
        

        $botao = $this->componentes->criarBotaoSubmit('Cadastrar', "cadastro");
        $botao_logar = $this->componentes->criarBotaoSubmit('Fazer login', "login");

        $inputs = [];
        if ($erro){
            $msg_erro = $this->componentes->criarLabelErro($msg);
            $inputs = [$msg_erro, $inputNome, $inputCpf, $inputNascimento, $inputCelular, $inputEmail, $inputSenha, $inputConfirmarSenha];
        } else {
            $inputs = [$inputNome, $inputCpf, $inputNascimento, $inputCelular, $inputEmail, $inputSenha, $inputConfirmarSenha];
        }

        $formulario = $this->componentes->criarForm($inputs, '../controller/cadastroController.php', 'Cadastrar', $botao . $botao_logar);

        $body = $this->componentes->criarBody($formulario);

        $documento = $html . ' ' . $body . ' ' . $this->componentes->fecharDocumentoHtml();
        return $documento;
    }
}

