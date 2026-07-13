<?php

class Cpf {
    private string $cpf;
    public function __construct(string $cpf){
        $cpf_limpo = Texto::limparTextoNumerico($cpf);
        Texto::validarLimite($cpf_limpo, min:11, max:11);
        // escrver codigo para validar cpf
        $this->cpf = $cpf_limpo;
    }

    public function getCpf(): string {
        return $this->cpf;
    }

    private function validarCpf(string $cpf){
        throw new Exception("Escrever função validar CPF");
    }
}