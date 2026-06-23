using System;

namespace AppPetShop
{
    internal class Pet
    {
        CodigoBanco codigo;
        Cpf cpf;
        Texto nome_pet;
        Texto especie;
        Texto raca;
        char genero;
        DateTime nascimento;
        byte[] foto;

        public void setCodigo(CodigoBanco codigoStr)
        {
            this.codigo = codigoStr;
        }

        public void setCpfTutor(Cpf cpf)
        {
            this.cpf = cpf;
        }

        public void setNomePet(Texto nomePet)
        {
            this.nome_pet = nomePet;
        }

        public void setEspecie(Texto especiePet)
        {
            this.especie = especiePet;
        }

        public void setRaca(Texto racapet)
        {
            this.raca = racapet;
        }

        public void setGenero(char genero)
        {

            // verifica se o espaço esta em branco
            if (Char.IsWhiteSpace(genero))
            {
                throw new Exception("Genero deve ser informado !!!");
            }

            // ele deve ser uma letra
            if (!Char.IsLetter(genero))
            {
                throw new Exception("Genero deve ser representado apenas com letras ( M|F) !!!");
            }

            // letra maiuscula
            char letra = Char.ToUpper(genero);

            // verifica se é F ou M
            if (letra.Equals('M') || letra.Equals('F'))
            {
                this.genero = letra;
            }
            else
            {
                throw new Exception("Genero de Pet não indentificado !!!");
            }
        }

        public void setNascimento(DateTime dataPet)
        {
            DateTime dataHoje = DateTime.Now;

            if (dataPet > dataHoje)
            {
                throw new Exception("Data de nascimento inválida para pet");
            }
            this.nascimento = dataPet;
        }

        public void setFoto(byte[] foto)
        {
            if (foto == null || foto.Length == 0)
            {
                throw new Exception("Imagem do Pet é obrigatória.");
            }

            this.foto = foto;
        }

        public int getCodigo()
        {
            return this.codigo.getCodigo();
        }

        public string getCpf()
        {
            return this.cpf.getCpf();
        }

        public string getNome()
        {
            return this.nome_pet.getTexto();
        }

        public string getEspecie()
        {
            return this.especie.getTexto();
        }

        public string getRaca()
        {
            return this.raca.getTexto();
        }

        public char getGenero()
        {
            return this.genero;
        }

        public DateTime getNascimento()
        {
            return this.nascimento;
        }

        public byte[] getFoto()
        {
            return this.foto;
        }
    }

}
