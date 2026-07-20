<?php

class AdmController {
    private AdmTemplate $template;
    public function __construct()
    {
        $this->template = new AdmTemplate();
        $abaAtiva = isset($_GET['aba']) ? $_GET['aba'] : 'produtos';
        echo($this->template->criarPagina($abaAtiva));
    }
}