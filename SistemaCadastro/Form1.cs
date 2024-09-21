using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro {
    public partial class Form1 : Form {

        List<Pessoa> listaPessoas;

        public Form1() {
            InitializeComponent();
            listaPessoas = new List<Pessoa>();
        }

        private void label1_Click(object sender, EventArgs e) {

        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e) {

        }


        private void Form1_Load(object sender, EventArgs e) {

        }


        private void btnCadastrar_Click(object sender, EventArgs e) {

            int index = -1;

            foreach(Pessoa pes in listaPessoas) {
                if(pes.CPF == txtCPF.Text) {
                    index = listaPessoas.IndexOf(pes);
                }
            }

            if(txtNome.Text == "") {
                MessageBox.Show("<<< Preencha o campo nome >>>");
                txtNome.Focus();
                return;
            }

            if(txtCPF.Text == "" || txtCPF.Text.Length != 11) {
                MessageBox.Show("<<< Preencha o campo CPF >>>: ");
                txtCPF.Focus();
                return;
            }
            else {
                foreach(Pessoa pes in listaPessoas) {
                    if(pes.CPF == txtCPF.Text) {
                        MessageBox.Show("<<< CPF já cadastrado >>>");
                        txtCPF.Text = "";
                        txtCPF.Focus();
                        return;
                    }
                }
            }

            if(txtTelefone.Text == "(  )         ") {
                MessageBox.Show("<<< Preencha o campo Telefone >>>");
                txtTelefone.Focus();
                return;
            }


            char sexo;
            if(radioMasculino.Checked) {
                sexo = 'M';
            }
            else if(radioFeminino.Checked) {
                sexo = 'F';
            }
            else {
                sexo = 'O';
            }



            Pessoa pessoa = new Pessoa(txtNome.Text, txtCPF.Text, txtNascimento.Text, ComboEstadoCivil.SelectedItem.ToString(),
                txtTelefone.Text, checkCasa.Checked, checkVeiculo.Checked, sexo);

            if(index < 0) {
                listaPessoas.Add(pessoa);
            }
            else {
                listaPessoas[index] = pessoa;
                MessageBox.Show("<<< Cliente atualizado >>>");
            }

            btnLimpar_Click(btnLimpar, EventArgs.Empty);

            Listar();

        }


        private void btnExcluir_Click(object sender, EventArgs e) {

            try {
                int indice = listaBox.SelectedIndex;
                listaPessoas.RemoveAt(indice);
                Listar();
            }
            catch(Exception) {
                MessageBox.Show($"<<< Selecione um cliente do cadastro para exclução >>>");
            }

        }


        private void btnLimpar_Click(object sender, EventArgs e) {

            // Limpar os campos digitados 
            txtNome.Text = "";
            txtCPF.Text = "";
            txtNascimento.Text = "";
            ComboEstadoCivil.Text = "";
            txtTelefone.Text = "";
            checkCasa.Checked = false;
            checkVeiculo.Checked = false;
            radioMasculino.Checked = true;
            radioFeminino.Checked = false;
            radioOutros.Checked = false;

            // Deixar o curso da digitação selecionado no nome
            txtNome.Focus();

        }


        private void Listar() {
            listaBox.Items.Clear();

            foreach(Pessoa pes in listaPessoas) {
                listaBox.Items.Add(pes.Nome);
            }
        }

    }
}
