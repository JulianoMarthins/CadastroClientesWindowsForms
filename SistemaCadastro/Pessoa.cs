using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCadastro {
    internal class Pessoa {

        public string Nome { get; set; }
        public string CPF { get; set; }
        public string DataNascimento { get; set; }
        public string EstadoCivil { get; set; }
        public string Telefone { get; set; }
        public bool CasaPropria { get; set; }
        public bool Veiculo { get; set; }
        public char Sexo { get; set; }


        public Pessoa(string nome, string cpf, string nascimento, string estadoCivil, string telefone,
            bool casaPropria, bool veiculo, char sexo) {
            Nome = nome;
            CPF = cpf;
            DataNascimento = nascimento;
            EstadoCivil = estadoCivil;
            Telefone = telefone;
            CasaPropria = casaPropria;
            Veiculo = veiculo;
            Sexo = sexo;
        }

    }
}
