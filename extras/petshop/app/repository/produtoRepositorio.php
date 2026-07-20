<?php 

class ProdutoRepositorio {
    private Conexao $conexao;
    public function __construct(Conexao $conexao){
        $this->conexao = $conexao;
    }

    public function buscarProdutoId(int $id){
        try {
            // valida o id recebido
            $id = new Id($id);

            // inicia a conexão
            $resposta = $this->conexao->conectarBd();
            if (!$resposta['status']){
                return $resposta;
            }

            $conexao = $this->conexao->getConexao();

            // comando de consulta
            $comando = "
            SELECT 
            nome_produto as nomeProduto,
            marca_produto as marcaProduto,
            categoria_produto as categoriaProduto,
            descricao_produto as descricaoProduto,
            imagem_produto as imagemProduto
            FROM produto_tb WHERE id = :id";

            // prepara o comando
            $sql = $conexao->prepare($comando);
            
            // envia os parametros
            $sql->bindValue(":id", $id->getId());

            // executa 
            $sql->execute();

            // checa o resultado da consulta
            if ($sql->rowCount() == 0){
                return RespostaProcessos::resposta(false, "Produto não localizado");
            }

            // transforma a resposta em um array associativo
            $dados = $sql->fetch(PDO::FETCH_ASSOC);
            return RespostaProcessos::resposta(true, "Produto localizado", $dados);
        } catch (Exception $erro){
            return RespostaProcessos::respostaErro($erro, "ErroException: " . $erro->getMessage() . " !!!");
        } finally {
            $this->conexao->fecharConexao();
        }
    }
}