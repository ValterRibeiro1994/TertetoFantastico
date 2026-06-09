package com.example.proj140526;

public class Produto {
    //1) Atributos
    private String descricao;
    private String produto;
    private Double valor;

    //2)Construtor
    public Produto(String descricao, String produto, double valor) {
        this.descricao = descricao;
        this.produto = produto;
        this.valor = valor;
    }

    //3) Getters & Setters

    public String getDescricao() {
        return descricao;
    }

    public void setDescricao(String descricao) {
        this.descricao = descricao;
    }

    public String getProduto() {
        return produto;
    }

    public void setProduto(String produto) {
        this.produto = produto;
    }

    public double getValor() {
        return valor;
    }

    public void setValor(double valor) {
        this.valor = valor;
    }

    //ToString
    @Override
    public String toString() {
        return "Produto: " + produto + " | Descrição: " + descricao + " | Por: " + "R$" + valor;
    }
}
