<?php

class Texto {
    
    // Conta caracteres reais (UTF-8) em vez de bytes
    public static function validarLimite(string $text, int $min = 3, int $max = 80): void {
        $n = mb_strlen($text, 'UTF-8');
        if ($n < $min || $n > $max) {
            throw new Exception("Texto Invalido");
        }
    }

    // Mantém apenas números usando expressão regular direta
    public static function limparTextoNumerico(string $texto): string {
        return preg_replace('/[^\d]/', '', $texto);
    }

    // Mantém letras (com acento), números e espaços
    public static function limparTextoPuro(string $texto): string {
        // Remove tudo que NÃO for letra (\p{L}) ou espaço (\s)
        return preg_replace('/[^\p{L}\s]/u', '', $texto);
    }

    // Valida se a string contém APENAS letras (com acento) e espaços
    public static function validarLetras(string $texto): void {
        if (!preg_match('/^[\p{L}\s]+$/u', $texto)) {
            throw new Exception("Texto Invalido");
        }
    }

    // Valida se a string contém APENAS letras, números e espaços
    public static function validarLetrasNumeros(string $texto): void {
        if (!preg_match('/^[\p{L}\p{N}\s]+$/u', $texto)) {
            throw new Exception("Texto Invalido");
        }
    }
}