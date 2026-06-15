using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AppPetShop
{
    internal class Pet
    {
        int codigo;
        string cpf_tutor;
        string nome_pet;
        string especie;
        string raca;
        char genero;
        DateTime nascimento;
        byte[] foto;

        public void setCodigo(string codigoStr)
        {
            if (String.IsNullOrEmpty(codigoStr))
            {
                throw new Exception("Campo código não deve estar vazio !!!");
            }

            try
            {
                int codigoInt = int.Parse(codigoStr);
                if (codigoInt <= 0)
                {
                    throw new Exception("Código de Pet Inválido !!!");
                }
                this.codigo = codigoInt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void setCpfTutor(string cpf)
        {
            if (String.IsNullOrEmpty(cpf))
            {
                throw new Exception("Campo cpf não pode estar vazio !!!");
            }

            // checa se todos os caracteres são numeros
            int n = cpf.Length;
            for (int i = 0; i < n; i++)
            {
                char letra = cpf[i];
                if (char.IsDigit(letra))
                {
                    continue;
                }
                else
                {
                    throw new Exception("Informe apenas números para o cpf !!!");
                }

            }

            if (n != 11)
            {
                throw new Exception("Campo cpf deve conter 11 números");
            }

            this.cpf_tutor = cpf;
        }

        public void setNomePet(string nomePet)
        {
            if (String.IsNullOrEmpty(nomePet))
            {
                throw new Exception("Campo nome do pet não pode estar vazio!!!");
            }

            int n = nomePet.Length;
            if (n > 30)
            {
                throw new Exception("Limite de 30 caracteres!");
            }

            this.nome_pet = nomePet;
        }

        public void setEspecie(string especiePet)
        {
            if (String.IsNullOrEmpty(especiePet))
            {
                throw new Exception("Especie do pet deve ser Informado !!!");
            }

            if (especiePet.Length > 30)
            {
                throw new Exception("Limite de caracteres invalido para Pet");
            }

            this.especie = especiePet;
        }

        public void setRaca(string racapet)
        {
            if (String.IsNullOrEmpty(racapet))
            {
                throw new Exception("Campo raça pet não pode estar vazio");
            }

            if (racapet.Length > 30)
            {
                throw new Exception("Limite de caracteres invalido");
            }

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
        
        public void setDataPet(DateTimePicker dataPet)
        {
            DateTime dataHoje = DateTime.Now;

            if (dataPet.Value > dataHoje)
            {
                throw new Exception("Data de nascimento inválida para pet");
            }
        }
    
        public void setFoto(PictureBox imagem)
        {
            if (String.IsNullOrEmpty(imagem.ImageLocation))
            {
                throw new Exception("Imagem do Pet é Obrigatorio");
            }

            try
            {
                this.foto = File.ReadAllBytes(imagem.ImageLocation);
            }
            catch (Exception e)
            {
                throw new Exception("Erro de Foto: " + e.Message);
            }
        }
    }

}
