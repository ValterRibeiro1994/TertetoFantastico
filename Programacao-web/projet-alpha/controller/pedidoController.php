<?php
require_once("../template/templatePedido.php");
require_once("../controller/validateController.php");
require_once("../controller/conexaoController.php");
require_once("../controller/sessaoController.php");

$template = new TemplatePedido();
$validador = new ValidateController();
$database = new ConexaoController();
$gerenciador_sessao = new SessaoController();

if ($_SERVER['REQUEST_METHOD'] === 'GET') {
    $resposta = $gerenciador_sessao->validarSessao();
    if (!$resposta['status']) {
        header("Location: loginController.php");
        return;
    }

    $resposta = $gerenciador_sessao->validarConta();
    if (!$resposta['status']) {
        header("Location: bancoController.php");
        return;
    }

    echo($template->criarTemplate(false, ""));
    return;
} else if ($_SERVER['REQUEST_METHOD'] === "POST") {
    $resposta = $gerenciador_sessao->validarSessao();
    if (!$resposta['status']) {
        header("Location: loginController.php");
        return;
    }

    $resposta = $gerenciador_sessao->validarConta();
    if (!$resposta['status']) {
        header("Location: bancoController.php");
        return;
    }

    if (isset($_POST['historico'])) {
        header("Location: gerenciarController.php");
        exit();
    }

    $resposta = $validador->validarPedido($_POST);
    if (!$resposta['status']) {
        echo($template->criarTemplate(true, $resposta['message']));
        return;
    }

    $taxa = (float) $_POST['taxaUsuario'];
    $tempo = (int) $_POST['tempoUsuario'];
    $capital = (float) $_POST['capitalUsuario'];
    $rendimento = $capital * pow((1 + $taxa), $tempo);
    $template->adicionarResultado("O Montante final desse investimento será de " . (string) number_format($rendimento, 2, ".", ",") . " R$");

    $id = $gerenciador_sessao->obterId();
    $resposta = $database->registrarPedido($id, $taxa, $tempo, $capital, $rendimento);

    if (!$resposta['status']) {
        echo($template->criarTemplate(true, $resposta['message']));
        return;
    }

    echo($template->criarTemplate(false, ""));
    exit();
}