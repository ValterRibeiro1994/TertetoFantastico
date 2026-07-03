<?php
header('Content-Type: text/html; charset=utf-8');

require_once("./autoload.php");
require_once("./app/rotas/roteador.php");


new AutoLoad();

new Roteador();