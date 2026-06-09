package com.example.proj140526;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Toast;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {
    public static ArrayList<Produto> lista = new ArrayList<Produto>();

    EditText txtProduto, txtDescricao, txtValor;
    Button btnCadastrar, btnGestao;
    ListView ListaProduto;

    ArrayAdapter<Produto> Adaptador;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        txtProduto = findViewById(R.id.txtNome);
        txtDescricao = findViewById(R.id.txtDescricao);
        txtValor = findViewById(R.id.txtValor);
        btnCadastrar = findViewById(R.id.btnCadastrar);
        ListaProduto = findViewById(R.id.ListaProduto);
        btnGestao = findViewById(R.id.btnGestao);

        Adaptador = new ArrayAdapter<Produto>(
                MainActivity.this,
                        android.R.layout.simple_list_item_1,
                            lista);
        ListaProduto.setAdapter(Adaptador);


        btnCadastrar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view)
            {
                String nome = txtProduto.getText().toString();
                String descricao = txtDescricao.getText().toString();
                String valor = txtValor.getText().toString();

                if (!validarCampos(nome, descricao, valor)){
                    return;
                }

                Produto produto = new Produto(descricao, nome, Double.parseDouble(valor));
                lista.add(produto);
                Adaptador.notifyDataSetChanged();
                limparCampos();

            }

        });
        btnGestao.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view)
            {
                Intent it = new Intent(MainActivity.this, TelaGestao.class);
                        startActivity(it);
            }
        });
    }

    public boolean validarCampos(String nome, String descricao, String valor) {
        if (campoVazio(nome)) {
            notificarResultado("Campo nome está vazio");
            return false;
        }

        if (campoVazio(descricao)) {
            notificarResultado("Campo Descrição está vazio");
            return false;
        }

        if (campoVazio(valor)) {
            notificarResultado("Campo Valor está vazio");
            return false;
        }

        if (!numeroPositivo(Double.parseDouble(valor))) {
            notificarResultado("Informe apenas valores positivos acima de ZERO");
            return false;
        }

        return true;
    }

    private void limparCampos() {
        txtProduto.setText("");
        txtDescricao.setText("");
        txtValor.setText("");
        txtValor.requestFocus();
    }

    private void notificarResultado(String notificacao){
        Toast.makeText(MainActivity.this,
                notificacao,
                Toast.LENGTH_LONG).show();
    }

    private boolean campoVazio(String campo){
        return campo.isEmpty();
    }

    private boolean numeroPositivo(double numero){
        return numero > 0;
    }
}