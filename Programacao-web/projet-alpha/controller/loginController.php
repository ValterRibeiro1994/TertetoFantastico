<?php 
require_once("../template/appTemplate.php");
require_once("../controller/validateController.php");
require_once("../controller/conexaoController.php");
require_once("../controller/sessaoController.php");

$template = new AppTemplate('login');
$validador = new ValidateController();
$database = new ConexaoController();
$gerenciador_sessao = new SessaoController();

if ($_SERVER['REQUEST_METHOD'] === 'GET'){
    $resposta = $gerenciador_sessao->validarSessao();
    
    if (!$resposta['status']){
        echo($template->criarTemplate(false, ""));
        return;
    }
    
    $resposta = $gerenciador_sessao->validarConta();
    
    if (!$resposta['status']){
        header("Location: bancoController.php");
        return;
    }
    
    echo($template->criarTemplate(false, ""));
    return;
} else if ($_SERVER['REQUEST_METHOD'] === "POST"){
    if (isset($_POST['cadastro'])){
        header("Location: cadastroController.php");
        return;
    }
    
    if (isset($_POST['recuperar'])){
        header("Location: recuperarSenhaController.php");
        return;
    }
    
    $resposta = $validador->validarLogin($_POST);
    
    if (!$resposta['status']){
        echo($template->criarTemplate(true, $resposta['message']));
        return;
    }
    
    $resposta = $database->buscarUsuario($_POST['emailUsuario']);
    
    if (!$resposta['status']){
        echo($template->criarTemplate(true, $resposta['message']));
        return;
    }
    
    $dados = $resposta['dados'];
    
    if ($dados['senha_usuario'] !== $_POST['senhaUsuario']){
        echo($template->criarTemplate(true, "Senha invalida !!!"));
        return;
    }
    
    if (!isset($_POST['lembrarUsuario'])){
        $_POST['lembrarUsuario'] = false;
    }
    
    $dados['lembrarUsuario'] = $_POST['lembrarUsuario'];
    $resposta = $gerenciador_sessao->criarUsuario($dados);
    
    if (!$resposta['status']){
        echo($template->criarTemplate(true, $resposta['message']));
        return;
    }
    
    $resposta = $database->buscarConta((int) $gerenciador_sessao->obterId());
    
    if (!$resposta['status']){
        if (str_contains($resposta['message'], "conta não registrada")){
            header("Location: bancoController.php");
            return;
        } else {
            echo($template->criarTemplate(true, $resposta['message']));
            return;
        }
    } else {
        $gerenciador_sessao->salvarConta($resposta['dados']['nome_banco_conta'], $resposta['dados']['numero_conta']);
        header("Location: pedidoController.php");
        return;
    }
} else {
    echo("Método de requisição não permitido para esse site");
    return;
}