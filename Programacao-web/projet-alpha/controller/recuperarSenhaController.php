<?php
require_once("../template/appTemplate.php");
require_once("../controller/validateController.php");
require_once("../controller/conexaoController.php");
require_once("../controller/sessaoController.php");
require_once("../controller/emailController.php");

$template = new AppTemplate("recuperarSenha");
$validador = new ValidateController();
$database = new ConexaoController(); 
$sessao = new SessaoController();

if ($_SERVER['REQUEST_METHOD'] === "GET"){
    echo($template->criarTemplate(false, ""));
    return;
} else if ($_SERVER['REQUEST_METHOD'] === "POST"){
    $resposta = $validador->validarRecuperarSenha($_POST);
    if (!$resposta['status']){
        echo($template->criarTemplate(true, $resposta['message']));
        exit();
    }

    $resposta = $database->buscarUsuario($_POST['emailUsuario']);
    if (!$resposta['status']){
        echo($template->criarTemplate(true, $resposta['message']));
        exit();
    }

    $dados = $resposta['dados'];
    $cpf_banco = $dados['cpf_usuario'];
    $telefone_banco = $dados['celular_usuario'];
    $nascimento_banco = $dados['data_nascimento_usuario'];

    $cpf = $_POST['cpfUsuario'];
    $celular = $_POST['celularUsuario'];
    $nascimento = $_POST['nascimentoUsuario'];

    $dados_banco = [$cpf_banco, $telefone_banco, $nascimento_banco];
    $dados_usuario = [$cpf, $celular, $nascimento];
    $n = count($dados_usuario);
    
    for($x = 0; $x < $n; $x++){
        if ($dados_banco[$x] !== $dados_usuario[$x]){
            echo($template->criarTemplate(true, "Dados informados não são compativeis com a conta"));
            exit();
        }
    }
    
    $email = new EmailController("digite seu email aqui", "digite sua senha aqui");
    $resposta = $email->enviarMensagem($_POST['emailUsuario'], "Recuperação de senha", $dados['senha_usuario']);
    
    if (!$resposta['status']) {
        echo $template->criarTemplate(true, $resposta['message']);
    } else {
        echo $template->criarTemplate(true, "Email enviado com sucesso");
    }
    exit();
}