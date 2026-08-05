<?php 
require_once("../template/appTemplate.php");
require_once("../controller/validateController.php");
require_once("../controller/conexaoController.php");
require_once("../controller/sessaoController.php");

$template = new AppTemplate('cadastro');
$validador = new ValidateController();
$database = new ConexaoController();
$gerenciar_sessao = new SessaoController();

if ($_SERVER['REQUEST_METHOD'] === "GET"){
    $resposta = $gerenciar_sessao->validarSessao();
    
    if (!$resposta['status']){
        echo($template->criarTemplate(false, ""));
        return;
    } else {
        header("Location: gerenciarController.php");
        return;
    }
} else if ($_SERVER['REQUEST_METHOD'] === "POST"){
    if (isset($_POST['login'])){
        header("Location: loginController.php");
        return;
    }
    
    $resposta = $validador->validarCadastro($_POST);
    
    if (!$resposta['status']){
        echo($template->criarTemplate(true, $resposta['message']));
        return;
    }
    
    $resposta = $database->inserirUsuario($_POST);
    
    if (!$resposta['status']){
        echo($template->criarTemplate(true, $resposta['message']));
        return;
    }
    
    header("Location: loginController.php");
    exit();
}