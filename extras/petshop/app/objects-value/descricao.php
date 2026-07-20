<?php

class Descricao{
    private string $descricao;

    public function __construct(string $descricao){
        Texto::validarLimite($descricao, max:250);
        Texto::validarLetrasNumeros($descricao);
        $this->descricao = $descricao;
    }

    public function getCategoria(): string {
        return $this->descricao;
    }
}