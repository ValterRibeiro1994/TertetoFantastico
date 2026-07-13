<?php

class Produto {
    private int $idProduto;
    private NomeProduto $nome;
    private string $categoria;
    private string $descricao;
    private string $valor;
    private string $imagem;

    /**
     * Getter dinâmico para acessar propriedades privadas.
     */
    public function __get(string $propriedade) {
        if (property_exists($this, $propriedade)) {
            return $this->$propriedade;
        }
        throw new \Exception("Propriedade {$propriedade} não encontrada ou não é acessível.");
    }

    /**
     * Setter dinâmico para modificar propriedades privadas.
     */
    public function __set(string $propriedade, $valor): void {
        if (property_exists($this, $propriedade)) {
            $this->$propriedade = $valor;
        } else {
            throw new \Exception("Propriedade {$propriedade} não encontrada ou não é acessível.");
        }
    }
}

?>
