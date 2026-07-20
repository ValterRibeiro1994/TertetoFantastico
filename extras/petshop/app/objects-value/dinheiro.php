<?php

class Dinheiro {
    private int $valor;

    public function __construct(float $valor){
        // valida o valor
        $this->validarDinheiro($valor);
        
        // converte ele para um numero inteiro
        $this->valor = $valor * 100;        
    }

    public function getDinheiro(): float {
        return $this->valor / 100;
    }

    public function aplicarDesconto(int $desconto){
        $porcentagem = $desconto / 100;
        $descount =  ($this->valor * $porcentagem);
        if ($this->valor <= $descount){
            throw new Exception("Desconto Invalido");
        }

        $this->valor -= $descount;
    }

    public function aplicarAumento(int $aumento){
        $porcentagem = $aumento / 100;
        $aumento = $this->valor * $porcentagem;
        $this->valor += $aumento;
    }
    
    public function addDinheiro(float $valor){
        $this->validarDinheiro($valor);
        $number = $valor * 100;
        $this->valor += $number;
    }

    private function validarDinheiro(float $valor){
        // separa o numero em parte inteira e decimal(se existir)
        $partes = explode('.', (string)$valor);

        // verifica se existe a parte decimal
        if (!isset($partes[1])){
            throw new Exception("Número Invalido");
        }
                
        // se existe verifica se foi enviado como .1 ou .10
        $n = strlen($partes[1]);
        if (!($n > 0 && $n <= 2)){
            throw new Exception("Número Invalido");
        }
    }
}