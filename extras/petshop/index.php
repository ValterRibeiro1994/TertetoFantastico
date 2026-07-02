<?php
header('Content-Type: text/html; charset=utf-8');
require_once("./app/templates/cadastroTemplate.php");

// Teste da pagina de Login
$pagina = new CadastroTemplate();
echo($pagina->criarPagina());