<?php

class ComponentesTemplates {
    
    
    public function criarDocumentoHtml(string $titulo){
        return '
        <!DOCTYPE html>
        <html lang="pt-br">
        <head>
            <meta charset="UTF-8">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">

            <!-- Importação do Bootstrap -->
            <link rel="stylesheet" href="../bootstrap/css/bootstrap.css">

            <!-- Título da página -->
            <title>' . $titulo . '</title> 
        </head>
        ';
    }

    
    public function fecharDocumentoHtml(){
        return "</html>";
    }

    
    public function criarBody(string $conteudo){
        return '
            <body class="container-fluid p-5">
                ' . $conteudo . '
            </body>
        '; 
    }

    
    public function criarInputFormText(string $rotulo, string $name, string $type, string $placeholder){
        return '
            <!-- Campo de entrada -->
            <label class="form-label">' . $rotulo . '</label>

            <input 
                type="' . $type . '" 
                name="' . $name . '" 
                class="form-control" 
                placeholder="' . $placeholder . '"
            >
        '; 
    }
    
    
    public function criarInputFormCheck(string $rotulo, string $name){
        return '
            <!-- Campo checkbox -->
            <label class="form-check-label">' . $rotulo . '</label>

            <input 
                type="checkbox" 
                name="' . $name . '" 
                class="form-check-input"
            >
        '; 
    }

    
    public function criarForm(array $inputs, string $action, string $titulo, string $botao){

        $n = count($inputs);

        $form = '
            <form 
                action="' . $action . '" 
                method="post" 
                class="border border-dark p-3 rounded-4 mx-auto shadow-lg mb-4 bg-white"
            >

                <!-- Título do formulário -->
                <h1 class="display-4 bg-secondary text-white text-center rounded-4">
                    ' . $titulo . '
                </h1>

                <br>
        ';

        for ($input = 0; $input < $n; $input++){
            $form .= $inputs[$input] . '<br>';
        }

        $form .= $botao . '</form>';

        return $form;
    }

    
    public function criarBotaoSubmit(string $titulo, string $name){
        return '
            <button 
                name="' . $name . '" 
                type="submit" 
                class="btn btn-secondary mt-3 w-100"
            >
                ' . $titulo . '
            </button>
        ';
    }

    
    public function criarLabelErro(string $msg){
        return '
            <br>

            <label class="bg-dark text-white text-center mx-auto p-3 mb-3 rounded-4 border border-2 border-danger w-100">
                ' . $msg . '
            </label>
        ';
    }

    
    public function criarRotuloResultadp(string $informe, string $resultado) {
        return '
            <hr>

            <span class="display-6 text-center d-block">
                ' . $informe . '
                <br>
                ' . $resultado . '
            </span>
        ';
    }

    
    public function criarTabelaDados(array $linhasCabecalho, array $dadosTabela) {

        $tabela = '<table class="table table-dark table-striped table-hover">';

        
        $cabecalho = '<thead><tr>';

        for ($i = 0; $i < count($linhasCabecalho); $i++) {

            $cabecalho .= '
                <th>
                    ' . $linhasCabecalho[$i] . '
                </th>
            ';
        }

        $cabecalho .= '</tr></thead>';

        
        $corpo = '<tbody>';

        for ($i = 0; $i < count($dadosTabela); $i++) {

            $corpo .= '<tr>';

            
            $valores = array_values($dadosTabela[$i]);

            for ($j = 0; $j < count($valores); $j++) {

                $corpo .= '
                    <td>
                        ' . (string)$valores[$j] . '
                    </td>
                ';
            }

            $corpo .= '</tr>';
        }

        $corpo .= '</tbody>';

        return $tabela . $cabecalho . $corpo . '</table>';
    }
}