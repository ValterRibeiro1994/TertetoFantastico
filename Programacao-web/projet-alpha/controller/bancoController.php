<?php 
require_once("../template/appTemplate.php");
require_once("../controller/validateController.php");
require_once("../controller/conexaoController.php");
require_once("../controller/sessaoController.php");

$template = new AppTemplate('banco');
$validador = new ValidateController();
$database = new ConexaoController();
$gerenciar_sessao = new SessaoController();

if ($_SERVER['REQUEST_METHOD'] === "GET"){
    $resposta = $gerenciar_sessao->validarSessao();
    
    if (!$resposta['status']){
        header("Location: loginController.php");
        return;
    } else {
        echo($template->criarTemplate(false, ""));
        return;
    }
} else if ($_SERVER['REQUEST_METHOD'] === "POST"){
    $resposta = $gerenciar_sessao->validarSessao();
    
    if (!$resposta['status']){
        header("Location: loginController.php");
        return;
    }
    
    $resposta = $gerenciar_sessao->validarConta();
    
    if ($resposta['status']){
        header("Location: pedidoController.php");
        return;
    }
    
    $resposta = $validador->validarBanco($_POST);
    
    if (!$resposta['status']){
        echo($template->criarTemplate(true, $resposta['message']));
        return;
    }
    
    $resposta = $database->inserirConta($gerenciar_sessao->obterId(), $_POST['bancoUsuario'], $_POST['contaUsuario']);
    
    if (!$resposta['status']){
        echo($template->criarTemplate(true, $resposta['message']));
        return;
    }
    
    $gerenciar_sessao->salvarConta($_POST['bancoUsuario'], $_POST['contaUsuario']);
    
    header("Location: pedidoController.php");
    exit();
}