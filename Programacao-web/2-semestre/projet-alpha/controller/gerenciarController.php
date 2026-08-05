<?php
require_once("../template/templateGerenciar.php");
require_once("../controller/validateController.php");
require_once("../controller/conexaoController.php");
require_once("../controller/sessaoController.php");

$template = new TemplateGerenciar();
$validador = new ValidateController();
$database = new ConexaoController();

function criarTabela(SessaoController $gerenciador_sessao, TemplateGerenciar $template, ConexaoController $database){
    $id = (int) $gerenciador_sessao->obterId();
    $resposta = $database->buscarRegistros($id);

    if (!$resposta['status']){
        echo($template->criarTemplate(true, $resposta['message']));
        return;
    }

    $dados_registro = $resposta['dados'];
    $chaves = ["taxa", "tempo", "capital", "rendimento"];
    $template->criarTabela($chaves, $dados_registro);

    $nome = $gerenciador_sessao->obterNome();
    $email = $gerenciador_sessao->obterEmail();
    $template->editarPlaceHolder($nome, $email);
    return;
}

function autorizarPagina(SessaoController $gerenciador_sessao){
    $resposta = $gerenciador_sessao->validarSessao();

    if (!$resposta['status']){
        header("Location: loginController.php");
        return;
    }

    $resposta = $gerenciador_sessao->validarConta();

    if (!$resposta['status']){
        header("Location: bancoController.php");
        return;
    }
}

$gerenciador_sessao = new SessaoController();

if ($_SERVER['REQUEST_METHOD'] === "GET"){
    autorizarPagina($gerenciador_sessao);
    criarTabela($gerenciador_sessao, $template, $database);
    echo($template->criarTemplate(false, ""));
    exit();
} else if ($_SERVER['REQUEST_METHOD'] === "POST"){
    autorizarPagina($gerenciador_sessao);

    if (isset($_POST['editarNome'])){
        $novo_nome = $_POST['editarNome'];
        $resposta = $validador->validarNome($novo_nome);

        if (!$resposta['status']){
            criarTabela($gerenciador_sessao, $template, $database);
            echo($template->criarTemplate(true, $resposta['message']));
            exit();
        }

        $id = (int) $gerenciador_sessao->obterId();
        $resposta = $database->editarNome($id, $novo_nome);

        if (!$resposta['status']){
            criarTabela($gerenciador_sessao, $template, $database);
            echo($template->criarTemplate(true, $resposta['message']));
            exit();
        }

        $gerenciador_sessao->editarNome($novo_nome);
        criarTabela($gerenciador_sessao, $template, $database);
        echo($template->criarTemplate(true, "Nome modificado com sucesso"));
        exit();
    }

    if (isset($_POST['editarEmail'])){
        $novo_email = $_POST['editarEmail'];
        $resposta = $validador->validarEmail($novo_email);

        if (!$resposta['status']){
            criarTabela($gerenciador_sessao, $template, $database);
            echo($template->criarTemplate(true, $resposta['message']));
            exit();
        }

        $id = (int) $gerenciador_sessao->obterId();
        $resposta = $database->editarEmail($id, $novo_email);

        if (!$resposta['status']){
            criarTabela($gerenciador_sessao, $template, $database);
            echo($template->criarTemplate(true, $resposta['message']));
            exit();
        }

        $gerenciador_sessao->editarEmail($novo_email);
        criarTabela($gerenciador_sessao, $template, $database);
        echo($template->criarTemplate(true, "E-mail modificado com sucesso"));
        exit();
    }

    if (isset($_POST['btnCalcularRendimento'])){
        header("Location: pedidoController.php");
        exit();
    }
} else {
    echo("Requisição invalida para esse projeto");
    exit();
}