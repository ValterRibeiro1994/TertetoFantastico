<?php

require_once("../controller/respostaFuncao.php");
require_once("../src/PHPMailer.php");
require_once("../src/SMTP.php");
require_once("../src/Exception.php");

use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\Exception;

class EmailController
{
    private PHPMailer $emailSmtp;
    private RespostaFuncao $resposta;

    public function __construct(string $userName, string $senha)
    {
        $this->resposta = new RespostaFuncao();
        $this->emailSmtp = new PHPMailer(true);
        $this->emailSmtp->isSMTP();
        $this->emailSmtp->CharSet = "UTF-8";
        $this->emailSmtp->Host = "smtp.gmail.com";
        $this->emailSmtp->SMTPAuth = true;
        $this->emailSmtp->Username = $userName;
        $this->emailSmtp->Password = $senha;
        $this->emailSmtp->SMTPSecure = PHPMailer::ENCRYPTION_STARTTLS;
        $this->emailSmtp->Port = 587;
        $this->emailSmtp->setFrom($userName, "Sistema");
        $this->emailSmtp->isHTML(true);
    }

    private function setDestinatario(string $emailDestinatario): void
    {
        $this->emailSmtp->clearAddresses();
        $this->emailSmtp->addAddress($emailDestinatario);
    }

    private function setAssunto(string $assunto): void
    {
        $this->emailSmtp->Subject = $assunto;
    }

    private function setMensagem(string $senha): void
    {
        $this->emailSmtp->Body = "
            <h2>Recuperação de Senha</h2>
            <p>Sua senha é: <strong>{$senha}</strong></p>
        ";
    }

    public function enviarMensagem(string $destinatario, string $assunto, string $senha): array
    {
        try {
            $this->setDestinatario($destinatario);
            $this->setAssunto($assunto);
            $this->setMensagem($senha);
            $this->emailSmtp->send();
            return $this->resposta->respostaFuncao(true, "Email enviado com sucesso !!!", []);
        } catch (Exception $e) {
            return $this->resposta->respostaFuncao(false, "Erro SMPT: {$this->emailSmtp->ErrorInfo}. \n-> {$e->getMessage()}", []);
        }
    }
}