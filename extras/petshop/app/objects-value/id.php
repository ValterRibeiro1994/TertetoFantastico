<?php 

class Id {
    private int $id;
    public function __construct(mixed $id){
        if (!ctype_digit($id)){
            throw new Exception("Id invalido");
        }

        $id = (int) $id;
        if ($id <= 0){
            throw new Exception("Id invalido");
        }

        $this->id = $id;

    }

    public function getId(): int {
        return $this->id;
    }
}


