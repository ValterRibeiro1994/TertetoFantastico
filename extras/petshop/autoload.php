<?php

class AutoLoad {
    public function __construct()
    {
        $pastas = scandir("app/");
        foreach($pastas as $pasta){
            if ($pasta == "templates"){
                $classes = scandir("app/$pasta");
                foreach($classes as $classe){
                    if (str_contains($classe, "Template.php") ){
                        require_once("app/$pasta/$classe");
                    }
                }
            } else if ($pasta == "controller"){
                $classes = scandir("app/$pasta");
                foreach($classes as $classe){
                    if (str_contains($classe, "Controller.php") ){
                        require_once("app/$pasta/$classe");
                    }
                }
            } else if ($pasta == "model"){
                $classes = scandir("app/$pasta");
                foreach($classes as $classe){
                    if (str_contains($classe, ".php") ){
                        require_once("app/$pasta/$classe");
                    }
                }
            } else if ($pasta == "repository"){
                $classes = scandir("app/$pasta");
                foreach($classes as $classe){
                    if (str_contains($classe, ".php") ){
                        require_once("app/$pasta/$classe");
                    }
                }
            } else if ($pasta == "request-server"){
                $classes = scandir("app/$pasta");
                foreach($classes as $classe){
                    if (str_contains($classe, ".php") ){
                        require_once("app/$pasta/$classe");
                    }
                }
            } else if ($pasta == "util"){
                $classes = scandir("app/$pasta");
                foreach($classes as $classe){
                    if (str_contains($classe, ".php") ){
                        require_once("app/$pasta/$classe");
                    }
                } 
            } else if ($pasta == "object-value"){
                $classes = scandir("app/$pasta");
                foreach($classes as $classe){
                    if (str_contains($classe, ".php") ){
                        require_once("app/$pasta/$classe");
                    }
                }
            } 
            else {
                continue;
            }
        }
    }
}