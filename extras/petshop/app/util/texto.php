<?php


class Texto {
    public static function validarLimite(string $text, int $min = 3, int $max = 80): void {
        $n = strlen($text);
        if ($n < $min || $n > $max){
            throw new Exception("Texto Invalido");
        }
    }

    public static function limparTextoNumerico(string $texto): string {
        $n = strlen($texto);
        $texto_limpo = "";
        for ($x = 0; $x < $n; $x++){
            $letra = $texto[$x];
            if (ctype_digit($letra)){
                $texto_limpo .= $letra;
            }
        }
        return $texto_limpo;
    }

    public static function limparTextoPuro(string $texto): string{
        $n = strlen($texto);
        $texto_limpo = "";
        for  ($x = 0; $x < $n; $x++){
            $letra = $texto[$x];
            if (ctype_alpha($letra) || ctype_space($letra)){
                $texto_limpo .= $letra;
            }
        }

        return $texto_limpo;
    }

    public static function validarLetras(string $texto): void {
        $n = strlen($texto);
        for ($x = 0; $x < $n; $x++){
            $letra = $texto[$x];
            if (!(ctype_alpha($letra) || ctype_space($letra))){
                throw new Exception("Texto Invalido");
            }
        }
    }

    public static function validarLetrasNumeros(string $texto): void {
        $n = strlen($texto);
        for ($x = 0; $x < $n; $x++){
            $letra = $texto[$x];
            if (!(ctype_alpha($letra) || ctype_space($letra) || ctype_digit($letra))){
                throw new Exception("Texto Invalido");
            }
        }
    }
}