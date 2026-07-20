<?php

class RespostaProcessos {
    public static function resposta(bool $status, string $mensagem = null, array $dados = null){
        return ['status'=>$status, 'mensagem'=>$mensagem, 'dados'=>$dados];
    }

    public static function respostaErro(Exception $error, string $msg){
        $dados = [
                "linha"=>$error->getLine(),
                "codigo"=>$error->getCode(),
                "arquivo"=>$error->getFile(),
                "trace"=>$error->getTraceAsString()
            ];
        return ['status'=>false, "mensagem"=>$msg, $dados];
    }
}