<?php
require_once("../controller/respostaFuncao.php");

class SessaoController
{
    private RespostaFuncao $resposta;

    public function __construct()
    {
        session_start();
        $this->resposta = new RespostaFuncao();
    }

    private function erro(string $msg): array
    {
        return $this->resposta->respostaFuncao(false, $msg, []);
    }

    private function sucesso(string $msg): array
    {
        return $this->resposta->respostaFuncao(true, $msg, []);
    }

    private function obter(string $chave): mixed
    {
        return $_SESSION['usuario'][$chave] ?? null;
    }

    private function salvar(string $chave, mixed $valor): void
    {
        $_SESSION['usuario'][$chave] = $valor;
    }

    private function existe(string $chave): bool
    {
        return isset($_SESSION['usuario'][$chave]);
    }

    public function obterId(): mixed
    {
        return $this->obter("id");
    }

    public function obterNome(): mixed
    {
        return $this->obter("nome");
    }

    public function obterEmail(): mixed
    {
        return $this->obter("email");
    }

    public function editarNome(string $nome): void
    {
        $this->salvar("nome", $nome);
    }

    public function editarEmail(string $email): void
    {
        $this->salvar("email", $email);
    }

    public function salvarConta(string $nomeBanco, string $numeroConta): void
    {
        $this->salvar("banco", $nomeBanco);
        $this->salvar("conta", $numeroConta);
    }

    public function validarConta(): array
    {
        if (!$this->existe("banco") || !$this->existe("conta")) {
            return $this->erro("Conta não existe");
        }
        return $this->sucesso("Conta cadastrada");
    }

    public function criarUsuario(array $dados): array
    {
        try {
            $_SESSION['usuario'] = [
                "id" => $dados['id_usuario'],
                "nome" => $dados['nome_usuario'],
                "cpf" => $dados['cpf_usuario'],
                "email" => $dados['email_usuario']
            ];

            $this->logarUsuario($dados['lembrarUsuario']);
            return $this->sucesso("Usuario criado com sucesso");
        } catch (Exception $error) {
            return $this->erro($error->getMessage());
        }
    }

    private function logarUsuario(bool $lembrar): void
    {
        $data = new DateTime();

        if ($lembrar) {
            $data->modify('+10 minutes');
        } else {
            $data->modify('+30 seconds');
        }

        $_SESSION['logado'] = true;
        $_SESSION['expira_em'] = $data->getTimestamp();
    }

    public function desconectarUsuario(): void
    {
        $_SESSION = [];
        session_destroy();
    }

    public function validarSessao(): array
    {
        if (!isset($_SESSION['logado'])) {
            return $this->erro("Usuario não está logado");
        }

        if (time() > $_SESSION['expira_em']) {
            $this->desconectarUsuario();
            return $this->erro("Tempo de sessão expirado");
        }

        return $this->sucesso("Usuario conectado");
    }
}