package com.example.proj140526;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;

public class TelaGestao extends AppCompatActivity {
    double valor_orcamento = 0;

    // componentes da tela
    TextView lblValor;
    ListView lista_gestao;

    // adaptador para array
    ArrayAdapter<Produto> adaptador;

    // array de produtos -> array estatico
    ArrayList<Produto> lista_recuperada = MainActivity.lista;

    // array de produtos clicados
    ArrayList<Produto> carrinho = new ArrayList<Produto>();
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_tela_gestao);
        // Iniciar atributos
        lblValor = findViewById(R.id.lblValorFinal);
        lista_gestao = findViewById(R.id.ListaGestao);

        // valida a lista recuperada
        if (!validarLista(lista_recuperada)){
            return;
        }

        // adiciona os eventos
        eventoProdutos(lista_gestao, lista_recuperada);

        // modificar tela de exibição
        setValor(valor_orcamento);
        exibirLista(lista_recuperada, lista_gestao);

    }

    public void setValor(double valor){
        lblValor.setText("Valor Total: " + valor);
    }

    public double somarProdutos(ArrayList<Produto> lista){
        int comprimento = lista.size();
        int contador = 0;
        for (int x = 0; x < comprimento; x++){
            Produto produto_atual = lista.get(x);
            contador += produto_atual.getValor();
        }
        return contador;
    }

    public void exibirLista(ArrayList<Produto> lista_produtos, ListView lista){
        adaptador = new ArrayAdapter<Produto>(
                TelaGestao.this,
                android.R.layout.simple_list_item_1,
                lista_produtos
        );
        lista.setAdapter(adaptador);
    }

    public boolean validarLista(ArrayList<Produto> lista){
        if (lista.size() == 0){
            notificarResultado("Lista de produtos está vazia !!!");
            return false;
        }
        return true;
    }
    private void notificarResultado(String notificacao){
        Toast.makeText(TelaGestao.this,
                notificacao,
                Toast.LENGTH_LONG).show();
    }

    private void eventoProdutos(ListView lista, ArrayList<Produto> produtos){
        lista.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                // adiciona o produto no array
                carrinho.add(produtos.get(i));
                valor_orcamento = somarProdutos(carrinho);
                setValor(valor_orcamento);
                notificarResultado("Produto adicionado ao carrinho");
            }
        });

        lista.setOnItemLongClickListener(new AdapterView.OnItemLongClickListener() {
            @Override
            public boolean onItemLongClick(AdapterView<?> adapterView, View view, int i, long l) {
                Produto produto = produtos.get(i);
                String nome = produto.getProduto();
                String desc = produto.getDescricao();

                // verifica se o produto foi adicionado em carrinho
                int posicao = localizarProduto(carrinho, nome, desc);
                if (posicao == -1){
                    notificarResultado("Esse produto não foi adicionado a lista");
                    return true;
                }

                // remove o produto localizado no vetor
                carrinho.remove(posicao);

                // calcula o valor total do orçamento
                valor_orcamento = somarProdutos(carrinho);

                // envia uma notificação
                notificarResultado("Produto removido do carrinho");

                // atualiza o valor
                setValor(valor_orcamento);
                return true;
            }
        });

    }

    private int localizarProduto(ArrayList<Produto> vetor, String nome, String desc){
        int n = vetor.size();
        for (int x = 0; x < n; x++){
            Produto produto = vetor.get(x);
            String nome_localizado = produto.getProduto();
            String desc_localizado = produto.getDescricao();

            if (nome.equals(nome_localizado) && desc.equals(desc_localizado)){
                return x;
            }
        }
        return -1;
    }

}