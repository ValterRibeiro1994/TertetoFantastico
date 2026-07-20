<?php

class Categoria {
    private string $categoria;

    public function __construct(string $categoria){
        Texto::validarLimite($categoria, max:20);
        Texto::validarLetras($categoria);
        $this->categoria = $categoria;
    }

    public function getCategoria(): string {
        return $this->categoria;
    }
}