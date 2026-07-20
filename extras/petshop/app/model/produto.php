<?php

class Produto {
    private Id $idProduto;
    private NomeProduto $nome;
    private Categoria $categoria;
    private Descricao $descricao;
    private Dinheiro $valor;
    private Imagem $imagem;

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
