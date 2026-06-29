<?php
require_once("./app/templates/loginTemplate.php");

// Teste da pagina de Login
$pagina = new LoginTemplate();
echo($pagina->criarPagina());