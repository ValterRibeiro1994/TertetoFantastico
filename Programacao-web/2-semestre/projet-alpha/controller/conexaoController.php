<?php
require_once("../controller/respostaFuncao.php");

class ConexaoController {
    private $servidor;
    private $usuario;
    private $senha;
    private $bancoDeDados;
    private $conexao;
    private $resposta;

    public function __construct(){
        $this->servidor = "localhost";
        $this->usuario = "root";
        $this->senha = "";
        $this->bancoDeDados = "db_alpha";
        $this->resposta = new RespostaFuncao();
    }

    private function conectarBd(){
        try {
            $this->conexao = new PDO("mysql:host=$this->servidor;dbname=$this->bancoDeDados;charset=utf8", $this->usuario, $this->senha);
            $this->conexao->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            return $this->resposta->respostaFuncao(true, "Conexão bem-sucedida", []);
        } catch (PDOException $error){
            return $this->resposta->respostaFuncao(false, "Erro de conexão com banco de dados: " . $error->getMessage(), []);
        }
    }

    public function fecharConexao(){
        $this->conexao = null;
    }

    public function buscarConta(int $id){
        $conexao = $this->conectarBd();
        if (!$conexao['status']){
            $this->fecharConexao();
            return $conexao;
        }
        try {
            $comando = "SELECT * FROM tb_conta_usuario WHERE id_usuario = :id";
            $sql = $this->conexao->prepare($comando);
            $sql->bindValue(":id", $id);
            $sql->execute();
            if ($sql->rowCount() == 0){
                return $this->resposta->respostaFuncao(false, "conta não registrada", []);
            }
            $dados = $sql->fetch(PDO::FETCH_ASSOC);
            return $this->resposta->respostaFuncao(true, "Conta localizada", $dados);
        } catch (PDOException $erro){
            return $this->resposta->respostaFuncao(false, $erro->getMessage(), []);
        } finally {
            $this->fecharConexao();
        }
    }

    public function buscarUsuario(string $email){
        $conexao = $this->conectarBd();
        if (!$conexao['status']){
            $this->fecharConexao();
            return $conexao;
        }
        try {
            $comando = "SELECT * FROM tb_usuario WHERE email_usuario = :email";
            $sql = $this->conexao->prepare($comando);
            $sql->bindValue(":email", $email);
            $sql->execute();
            if ($sql->rowCount() == 0){
                return $this->resposta->respostaFuncao(false, "E-mail não cadastrado", []);
            }
            $dados_localizados = $sql->fetch(PDO::FETCH_ASSOC);
            return $this->resposta->respostaFuncao(true, "Cadastro Localizado", $dados_localizados);
        } catch (PDOException $erro){
            return $this->resposta->respostaFuncao(false, "Erro SQL: " . $erro->getMessage(), []);
        } finally {
            $this->fecharConexao();
        }
    }

    public function inserirConta($id, $banco, $conta){
        $conexao = $this->conectarBd();
        if (!$conexao['status']){
            $this->fecharConexao();
            return $conexao;
        }
        try {
            $comando = "INSERT INTO tb_conta_usuario ( id_usuario, nome_banco_conta, numero_conta) VALUES (:id_usuario, :nome_banco, :numero_conta)";
            $sql = $this->conexao->prepare($comando);
            $sql->bindValue(':id_usuario', (int)$id);
            $sql->bindValue(':nome_banco', $banco);
            $sql->bindValue(':numero_conta', (int)$conta);
            $sql->execute();
            return $this->resposta->respostaFuncao(true, "Dados inseridos com sucesso", []);
        } catch (PDOException $erro){
            return $this->resposta->respostaFuncao(false, "Erro Conexão: " . $erro->getMessage(), []);
        } finally {
            $this->fecharConexao();
        }
    }

    public function registrarPedido(int $id, float $taxa, int $tempo, float $capital, float $rendimento){
        $conexao = $this->conectarBd();
        if (!$conexao['status']){
            $this->fecharConexao();
            return $conexao;
        }
        try {
            $comando = "INSERT INTO tb_registros (id_usuario, taxa_registro, tempo_registro, capital_registro, rendimento_registro ) VALUES (:id_usuario, :taxa, :tempo, :capital_pedido, :rendimento)";
            $sql = $this->conexao->prepare($comando);
            $sql->bindValue(":id_usuario", $id);
            $sql->bindValue(":taxa", $taxa);
            $sql->bindValue(":tempo", $tempo);
            $sql->bindValue(":capital_pedido", $capital);
            $sql->bindValue(":rendimento", $rendimento);
            $sql->execute();
            return $this->resposta->respostaFuncao(true, "Dados inseridos com sucesso", []);
        } catch (PDOException $erro){
            return $this->resposta->respostaFuncao(false, "Erro Conexão: " . $erro->getMessage(), []);
        } finally {
            $this->fecharConexao();
        }
    }

    public function inserirUsuario(array $dadosUsuario){
        $conexao = $this->conectarBd();
        if (!$conexao['status']){
            $this->fecharConexao();
            return $conexao;
        }
        try {
            $sql = "INSERT INTO tb_usuario (nome_usuario, email_usuario, cpf_usuario, celular_usuario, data_nascimento_usuario, senha_usuario) VALUES (:nome, :email, :cpf, :celular, :data_nascimento, :senha)";
            $consulta = $this->conexao->prepare($sql);
            $consulta->bindValue(":nome", $dadosUsuario['nomeUsuario']);
            $consulta->bindValue(":email", $dadosUsuario['emailUsuario']);
            $consulta->bindValue(":cpf", $dadosUsuario['cpfUsuario']);
            $consulta->bindValue(":celular", $dadosUsuario['celularUsuario']);
            $consulta->bindValue(":data_nascimento", $dadosUsuario['nascimentoUsuario']);
            $consulta->bindValue(":senha", $dadosUsuario['senhaUsuario']);
            $consulta->execute();
            return $this->resposta->respostaFuncao(true, "Cadastro efetuado", []);
        } catch (PDOException $error){
            if ($error->getCode() == "23000") {
                $msg_erro = $error->getMessage();
                if (str_contains($msg_erro, 'email')){
                    return $this->resposta->respostaFuncao(false, "Este e-mail já está em uso.", []);
                }
                if (str_contains($msg_erro, 'cpf')){
                    return $this->resposta->respostaFuncao(false, "Este CPF já está cadastrado.", []);
                }
            }
            return $this->resposta->respostaFuncao(false, "Erro conexão: " . $error->getMessage(), []);
        } finally {
            $this->fecharConexao();
        }
    }

    public function buscarRegistros(int $id){
        $conexao = $this->conectarBd();
        if (!$conexao['status']){
            $this->fecharConexao();
            return $conexao;
        }
        try {
            $comando = " SELECT taxa_registro, tempo_registro, capital_registro, rendimento_registro FROM tb_registros WHERE id_usuario = :id ORDER BY id_registro DESC ";
            $sql = $this->conexao->prepare($comando);
            $sql->bindValue(":id", $id);
            $sql->execute();
            $dados = $sql->fetchAll(PDO::FETCH_ASSOC);
            return $this->resposta->respostaFuncao(true, "Registros localizados com sucesso !!!", $dados);
        } catch(PDOException $erro){
            return $this->resposta->respostaFuncao(false, $erro->getMessage(), []);
        } finally {
            $this->fecharConexao();
        }
    }

    public function editarNome(int $id, string $novo_nome){
        $conexao = $this->conectarBd();
        if (!$conexao['status']){
            $this->fecharConexao();
            return $conexao;
        }
        try {
            $comando = "UPDATE tb_usuario SET nome_usuario = :nome WHERE id_usuario = :id ";
            $sql = $this->conexao->prepare($comando);
            $sql->bindValue(":nome", $novo_nome);
            $sql->bindValue(":id", $id);
            $sql->execute();
            return $this->resposta->respostaFuncao(true, "Nome modificado com sucesso",[]);
        } catch (PDOException $erro){
            return $this->resposta->respostaFuncao(false, $erro->getMessage(),[]);
        } finally {
            $this->fecharConexao();
        }
    }

    public function editarEmail(int $id, string $novo_email){
        $conexao = $this->conectarBd();
        if (!$conexao['status']){
            $this->fecharConexao();
            return $conexao;
        }
        try {
            $comando = "UPDATE tb_usuario SET email_usuario = :email WHERE id_usuario = :id ";
            $sql = $this->conexao->prepare($comando);
            $sql->bindValue(":email", $novo_email);
            $sql->bindValue(":id", $id);
            $sql->execute();
            return $this->resposta->respostaFuncao(true, "Nome modificado com sucesso", []);
        } catch (PDOException $erro){
            return $this->resposta->respostaFuncao(false, $erro->getMessage(), []);
        } finally {
            $this->fecharConexao();
        }
    }
}