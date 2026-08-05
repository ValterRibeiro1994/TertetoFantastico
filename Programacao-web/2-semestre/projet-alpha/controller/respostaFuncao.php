<?php 

class RespostaFuncao {
    public function respostaFuncao(bool $resposta, string $mensagem, array $dados){
        if (!$resposta){             
            return ['status'=>$resposta, 'message'=> $mensagem];
        }

        if (count($dados) === 0){
            return ['status'=>$resposta, 'message'=> $mensagem];
        }

        return ['status'=>$resposta, 'message'=>$mensagem, 'dados'=>$dados];
    }
}