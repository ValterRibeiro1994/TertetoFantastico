<?php
header('Content-Type: text/html; charset=utf-8');

require_once("./autoload.php");


new AutoLoad();

try {
    $request = new Request();
    $endpoint = new Endpoint($request->getRequest());
} catch(Exception $erro) {
    var_dump($erro);
}