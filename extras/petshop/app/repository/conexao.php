<?php


class Conexao {
    // conexão
    private ?PDO $conexao = null;

    // dados da conexão
    private string $servidor = "localhost";
    private string $usuario = "root";
    private string $senha = "";
    private string $bancoDeDados = "petshop_db";

    public function conectarBd(){
        try {
            // isso garante que só exista uma conexão aberta por repositorio
            // a conexão vai ser iniciado no repositorio, o repositorio vai executar o comando
            // e fechar a conexão
            if ($this->conexao === null){    
                $this->conexao = new PDO("mysql:host=$this->servidor;dbname=$this->bancoDeDados;charset=utf8", $this->usuario, $this->senha);
                $this->conexao->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            }
            return RespostaProcessos::resposta(true, "Conexão iniciada");
        } catch (PDOException $error){
            return RespostaProcessos::respostaErro($error, "ErroException: " . $error->getMessage() . " !!!");
        }
    }

    public function fecharConexao(){
        $this->conexao = null;
    }

    public function getConexao(): PDO {
        return $this->conexao;
    }

}