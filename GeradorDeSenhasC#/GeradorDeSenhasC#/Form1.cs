using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace GeradorDeSenhasC_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int comprimento;

                // Valida a entrada
                if (!int.TryParse(textBox1.Text, out comprimento) || comprimento <= 0 || comprimento > 128)
                {
                    MessageBox.Show("Por favor, insira um comprimento válido (número positivo, até 128 caracteres).");
                    return;
                }

                // Inicializa variáveis para inclusão de caracteres
                bool incluirMaiusculas = checkBox1.Checked; // Letras maiúsculas
                bool incluirMinusculas = checkBox2.Checked; // Letras minúsculas
                bool incluirNumeros = checkBox3.Checked;    // Números
                bool incluirEspeciais = checkBox4.Checked;  // Caracteres especiais

                // Verifica se pelo menos um tipo de caractere foi selecionado
                if (!incluirMaiusculas && !incluirMinusculas && !incluirNumeros && !incluirEspeciais)
                {
                    MessageBox.Show("Selecione pelo menos um tipo de caractere.");
                    return;
                }

                // Gera a senha com base nas opções selecionadas
                string senhaGerada = GerarSenha(comprimento, incluirMaiusculas, incluirMinusculas, incluirNumeros, incluirEspeciais);

                // Debug: Verifica se a senha gerada não é nula ou vazia
                if (string.IsNullOrEmpty(senhaGerada))
                {
                    MessageBox.Show("Erro: Senha gerada está vazia.");
                    return;
                }

                // Atualiza os checkboxes com base nos tipos de caracteres incluídos na senha gerada
                checkBox1.Checked = incluirMaiusculas;
                checkBox2.Checked = incluirMinusculas;
                checkBox3.Checked = incluirNumeros;
                checkBox4.Checked = incluirEspeciais;

                // Exibe a senha gerada no Label
                label1.Text = senhaGerada;
               
                
                // Defina AutoSize como false para permitir o ajuste manual do tamanho da Label
                label1.AutoSize = false;

                // Defina a largura e altura da Label
                label1.Width = 200;
                label1.Height = 50;

                // Alterando a cor do texto e fundo da Label
                label1.ForeColor = Color.Blue;  // Texto azul
                label1.BackColor = Color.LightGray;  // Fundo cinza claro

                // Centralizando o texto horizontal e verticalmente
                label1.TextAlign = ContentAlignment.MiddleCenter; 

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
        private string GerarSenha(int comprimento, bool incluirMaiusculas, bool incluirMinusculas, bool incluirNumeros, bool incluirEspeciais)
        {
            const string letrasMaiusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string letrasMinusculas = "abcdefghijklmnopqrstuvwxyz";
            const string numeros = "0123456789";
            const string especiais = "!@#$%^&*()_-+=[{]}|;:'\",<.>/?";

            var conjuntoCaracteres = "";
            if (incluirMaiusculas) conjuntoCaracteres += letrasMaiusculas;
            if (incluirMinusculas) conjuntoCaracteres += letrasMinusculas;
            if (incluirNumeros) conjuntoCaracteres += numeros;
            if (incluirEspeciais) conjuntoCaracteres += especiais;

            // Verifica se pelo menos um tipo de caractere foi selecionado
            if (string.IsNullOrEmpty(conjuntoCaracteres))
                throw new Exception("Selecione pelo menos um tipo de caractere.");

            var random = new Random();
            return new string(Enumerable.Repeat(conjuntoCaracteres, comprimento)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(label1.Text))
            {
                Clipboard.SetText(label1.Text);
                MessageBox.Show("Senha copiada para a área de transferência!");
            }
            else
            {
                MessageBox.Show("Nenhuma senha para copiar.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
