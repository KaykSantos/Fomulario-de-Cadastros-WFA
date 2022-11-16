using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroArrayStruct
{
    public partial class FormIndex : Form
    {
        public struct Usuario
        {
            public int codigo;
            public string nome;
            public string nivel;
            public string login;
            public string senha;
        }
        static public Usuario[] usuario = new Usuario[10];
        static public int contUsuario = 0;
        public struct Cliente
        {
            public int codigo;
            public string nome;
            public string cpf;
            public string rg;
            public string endereco;
            public string bairro;
            public string cidade;
            public string uf;
            public string cep;
            public string telefone;
            public string email;
        }
        static public Cliente[] cliente = new Cliente[10];
        static public int contCliente = 0;
        public struct Produto
        {
            public int codigo;
            public string descricao;
            public string unidade;
            public string quantidade;
            public string precoCusto;
            public string precoVenda;
        }
        static public Produto[] produto = new Produto[10];
        static public int contProduto = 0;
        public FormIndex()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "O Aplicativo será encerrado! Deseja prosseguir?";
            string caption = "Atenção";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                MessageBox.Show("O aplicativo será encerrado!", "Encerrando", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Aperte OK para continuar!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroUsuario abrirCadastroUser = new CadastroUsuario();
            abrirCadastroUser.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroCliente abrirCadastroClient = new CadastroCliente();
            abrirCadastroClient.Show();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroProduto abrirCadastroProduto = new CadastroProduto();
            abrirCadastroProduto.Show();
        }

        private void PdUsuario_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string strDados = "";
            Graphics objImpressao = e.Graphics;
            int pag = 0, linha = 0, i = 0;
            bool cabecalho = true, itens = true;

            while (cabecalho)
            {
                pag++;
                strDados = "                                       RELATÓRIO DE USUÁRIOS"+ (char)10;
                strDados += "Data: " + DateTime.Now.ToString("dd/MM/yyyy") + "                                                        Pag: " + pag.ToString("00") +(char)10;
                strDados += "--------------------------------------------------------------------------------" +(char)10;
                strDados += "Código Nome                                     Nível Login" +(char)10;
                strDados += "--------------------------------------------------------------------------------" +(char)10;
                linha = 5;
                while (itens)
                {
                    strDados += usuario[i].codigo.ToString("000000") + " " + usuario[i].nome.PadRight(40) + "   " + usuario[i].nivel + "   " + usuario[i].login + (char)10;
                    linha++;
                    i++;
                    if (linha >=64)
                    {
                        itens = false;
                        strDados += (char)12;
                    }
                    if(i >= contUsuario)
                    {
                        itens = false;
                        cabecalho = false;
                    }
                }
                objImpressao.DrawString(strDados, new Font("Courier New", 10, FontStyle.Regular), Brushes.Black, 50, 50);
            }
        }
        private void UsuáriosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ppdUsuario.ShowDialog();
        }

        private void ProdutosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ppdProduto.ShowDialog();
        }

        private void PdProduto_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string strDados = "";
            Graphics objImpressao = e.Graphics;
            int pag = 0, linha = 0, i = 0;
            bool cabecalho = true, itens = true;

            while (cabecalho)
            {
                pag++;
                strDados = "                                       RELATÓRIO DE PRODUTOS" + (char)10;
                strDados += "Data: " + DateTime.Now.ToString("dd/MM/yyyy") + "                                                        Pag: " + pag.ToString("00") + (char)10;
                strDados += "--------------------------------------------------------------------------------" + (char)10;
                strDados += "Código Descrição                              Custo(R$) Venda(R$)" + (char)10;
                strDados += "--------------------------------------------------------------------------------" + (char)10;
                linha = 5;
                while (itens)
                {
                    strDados += produto[i].codigo.ToString("000000") + " " + produto[i].descricao.PadRight(40) + " " + produto[i].precoCusto.PadRight(9)+ " " + produto[i].precoVenda.PadRight(9) + (char)10;
                    linha++;
                    i++;
                    if (linha >= 64)
                    {
                        itens = false;
                        strDados += (char)12;
                    }
                    if (i >= contProduto)
                    {
                        itens = false;
                        cabecalho = false;
                    }
                }
                objImpressao.DrawString(strDados, new Font("Courier New", 10, FontStyle.Regular), Brushes.Black, 50, 50);
            }
        }

        private void ClientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ppdCliente.ShowDialog();
        }

        private void PdCliente_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string strDados = "";
            Graphics objImpressao = e.Graphics;
            int pag = 0, linha = 0, i = 0;
            bool cabecalho = true, itens = true;

            while (cabecalho)
            {
                pag++;
                strDados = "                                      RELATÓRIO DE CLIENTES" + (char)10;
                strDados += "Data: " + DateTime.Now.ToString("dd/MM/yyyy") + "                                                        Pag: " + pag.ToString("00") + (char)10;
                strDados += "--------------------------------------------------------------------------------" + (char)10;
                strDados += "Código Nome                                     Email" + (char)10;
                strDados += "--------------------------------------------------------------------------------" + (char)10;
                linha = 5;
                while (itens)
                {
                    strDados += cliente[i].codigo.ToString("000000") + " " + cliente[i].nome.PadRight(40) + " " + cliente[i].email + (char)10;
                    linha++;
                    i++;
                    if (linha >= 64)
                    {
                        itens = false;
                        strDados += (char)12;
                    }
                    if (i >= contCliente)
                    {
                        itens = false;
                        cabecalho = false;
                    }
                }
                objImpressao.DrawString(strDados, new Font("Courier New", 10, FontStyle.Regular), Brushes.Black, 50, 50);
            }
        }

        private void FormIndex_Load(object sender, EventArgs e)
        {

        }
    }
}
