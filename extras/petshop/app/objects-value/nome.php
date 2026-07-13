<?php

interface Nome {
    public function getNome();
}



class NomePessoa implements Nome {
    /*
    Um nome de Pessoa possui apenas letras
    No banco o limite desse nome deve ser de 80 caracteres
    */
    private string $nome;

    public function __construct(string $nome){
        Texto::validarLimite($nome);
        Texto::validarLetras($nome);
        $this->nome = $nome;
    }

    public function getNome(): string {
        return $this->nome;
    }
}

class NomePet implements Nome {
    /*
    Um nome de Pet possui apenas letras
    No banco o limite desse nome deve ser de 20 caracteres
    */
    private string $nome;

    public function __construct(string $nome){
        Texto::validarLimite($nome, max:20);
        Texto::validarLetras($nome);
        $this->nome = $nome;
    }

    public function getNome(): string {
        return $this->nome;
    }
}


class NomeProduto implements Nome {
    /*
    Um nome de produto pode ter numeros e letras
    No banco o limite desse nome é de 50 caracteres
    */
    private string $nome;

    public function __construct(string $nome){
        Texto::validarLimite($nome, max:50);
        Texto::validarLetrasNumeros($nome);
        $this->nome = $nome;
    }

    public function getNome(): string {
        return $this->nome;
    }
}